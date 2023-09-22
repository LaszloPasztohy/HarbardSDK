using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Harbard
{
    class HttpMultiPartStream : IDisposable
    {
       struct MultipartInfo
       {
            public int contentSize = 0;
            public string contentType = "";
            public int contentPosInReadBuffer = -1;
            public Dictionary<string, string> headers;

            public MultipartInfo()
            {
                headers = new Dictionary<string, string>();
            }
       }
       struct RequestInfo
       {
            public string request_message = "";
            public string address = "";
            public Int16  port = 0;

            public RequestInfo(){}
            public bool isValid() 
            { return (address != "") && (port > 0) && (request_message != ""); }
       }

       public const Int32 CONTENT_SIZE_LIMIT = 25*1024*1024;
       public const Int32 READ_BUFFER_SIZE = 4096;


       private Func<Dictionary<string , string>, byte[]?, bool>            contentCallback;
       private RequestInfo                                                 requestInfo;
       private TcpClient?                                                  client;
       private byte[]?                                                     readBuffer;
       private string                                                      httpMultipartBoundary = "";
       private volatile bool                                               externalStopRequested;
       private int                                                         contentSizeLimit;
       private TimeSpan                                                    readTimeout;
       



        public HttpMultiPartStream(string url, Func<Dictionary<string , string>, byte[]?, bool> content_callback, TimeSpan read_timeout = new TimeSpan(), int content_size_limit = CONTENT_SIZE_LIMIT)
        {
            if(url.StartsWith("http://"))
            { url = url.Remove(0, "http://".Length); }
            else if(url.StartsWith("https://"))
            { 
                url = url.Remove(0, "https://".Length);
                throw new NotSupportedException("Secure Socket Layer is not supported for HttpMultiPartStream.");
            }
            else
            { throw new ArgumentException("Invalid url. Must start with http:// or https://"); }

            Int16 port = 80;
            string url_path = "/";
            string address = url;
            requestInfo = new RequestInfo();

            if(url.Contains("/"))
            {
                int end_of_address = url.IndexOf("/");
                address = url.Substring(0, end_of_address);
                url_path += url.Substring(end_of_address + 1);
            }

            if(address.Contains(":"))
            {
                int end_of_ip = address.IndexOf(":");
                requestInfo.address = address.Substring(0, end_of_ip);
                port = Convert.ToInt16(address.Substring(end_of_ip + 1));
            }
            else
            { requestInfo.address = address; }

            requestInfo.port = port;

            requestInfo.request_message = "GET " + url_path + " HTTP/1.1\r\nHost: " + requestInfo.address + "\r\nAccept: multipart/mixed\r\n\r\n";

            contentCallback = content_callback;

            externalStopRequested = false;

            contentSizeLimit = content_size_limit;

            readTimeout = read_timeout;
        }

        public void Dispose()
        {
            StopAsync();

            if(client != null)
            { client.Dispose(); }
        }


        public void Run()
        {
            if(!requestInfo.isValid())
            {
                throw new ArgumentNullException();
            }

            client = new TcpClient(requestInfo.address, requestInfo.port);
            readBuffer = new byte[READ_BUFFER_SIZE];
            bool stop_requested = false;
            bool accepted_multipart_connection = false;

            using(NetworkStream stream = client.GetStream())
            {
                //send request
                {
                    byte[] request_msg_bytes = Encoding.UTF8.GetBytes(requestInfo.request_message);
                    stream.Write(request_msg_bytes, 0, request_msg_bytes.Length);  
                }

                int read_buffer_offset = 0;

                while(!stop_requested && !externalStopRequested)
                {
                    //read response
                    bool try_read = false;
                    do
                    {
                        int bytes_to_read = readBuffer.Length - read_buffer_offset;
                        try_read = false;

                        try
                        {
                            int actual_bytes_read = readTcpStream(stream, readBuffer, read_buffer_offset, bytes_to_read, false);
                            read_buffer_offset += actual_bytes_read; 
                        }
                        catch(TimeoutException)
                        {
                            Dictionary<string, string> keepalive_headers = new Dictionary<string, string>();
                            keepalive_headers.Add("Content-Type", "application/x-keepalive");
                            keepalive_headers.Add("Content-Length", "0");
                            keepalive_headers.Add("X-SocketPoll", "true");

                            stop_requested = !contentCallback(keepalive_headers, null);

                            if(!stop_requested)
                            { try_read = true; }
                        }
                        catch(Exception)
                        {
                            if(!stop_requested && !externalStopRequested)
                            { throw; }
                        }

                        if(stop_requested || externalStopRequested) { break; }

                    } while(try_read);

                    if(stop_requested || externalStopRequested) { break; }


                    string response_as_str = Encoding.UTF8.GetString(readBuffer, 0, read_buffer_offset);


                    //parse http response
                    if(!accepted_multipart_connection)
                    {
                        if(response_as_str.IndexOf("HTTP/") != 0) { throw new InvalidDataException(); }


                        int start_of_status_code = response_as_str.IndexOf(' ') + 1;
                        if(start_of_status_code < 0) { throw new InvalidDataException("Cannot find HTTP status code"); }
                        int end_of_status_code = response_as_str.IndexOf(' ', start_of_status_code);
                        if(end_of_status_code < 0) { throw new InvalidDataException("Cannot find HTTP status code"); }

                        int length_of_status_code = end_of_status_code - start_of_status_code;
                        if(length_of_status_code < 0) { throw new InvalidDataException("Cannot find HTTP status code"); }

                        string status_code_as_str = response_as_str.Substring(start_of_status_code, length_of_status_code);
                        int status_code_as_int = Convert.ToInt32(status_code_as_str);

                        HttpStatusCode http_status_code = (HttpStatusCode)status_code_as_int;

                        if(response_as_str.IndexOf("200 OK") < 0)
                        {
                            string request_error_message = (int)http_status_code + " " + http_status_code.ToString();
                            throw new HttpRequestException(request_error_message, null, http_status_code);
                        }
                        
                        const string boundary_key = "boundary=";
                        int boundary_key_pos = response_as_str.IndexOf(boundary_key);
                        if(boundary_key_pos < 0) { throw new InvalidDataException(); }
                        int boundary_value_pos = boundary_key_pos + boundary_key.Length;
                        int boundary_value_length = response_as_str.IndexOf("\r\n", boundary_value_pos);
                        if(boundary_value_length < 0) { throw new InvalidDataException(); }
                        boundary_value_length -= boundary_value_pos;

                        httpMultipartBoundary = "--" + response_as_str.Substring(boundary_value_pos, boundary_value_length);
                        accepted_multipart_connection = true;  
                    }


                    //parse multipart header
                    {
                        MultipartInfo multipart_info = new MultipartInfo();

                        int multipart_header_pos = response_as_str.IndexOf(httpMultipartBoundary);
                        if(multipart_header_pos < 0) { continue; }

                        const string http_end_of_lines = "\r\n\r\n";
                        int multipart_header_end_pos = response_as_str.IndexOf(http_end_of_lines, multipart_header_pos + httpMultipartBoundary.Length);
                        if(multipart_header_end_pos < 0) { continue; }

                        multipart_info.contentPosInReadBuffer = multipart_header_end_pos + http_end_of_lines.Length;

                        string multipart_header = response_as_str.Substring(multipart_header_pos, multipart_header_end_pos - multipart_header_pos);
                        string[] multipart_header_lines = multipart_header.Split("\r\n");
                        if(multipart_header_lines.Length < 2) { throw new InvalidDataException(); }


                        foreach(string header_line in multipart_header_lines)
                        {
                            string[] key_value_pair = header_line.Split(":");
                            if(key_value_pair.Length == 2)
                            {
                                multipart_info.headers.Add(key_value_pair[0].Trim(), key_value_pair[1].Trim());
                            }
                            
                        }

                        //parse content type and content length
                        {
                            if(!multipart_info.headers.ContainsKey("Content-Type") && !multipart_info.headers.ContainsKey("Content-Length"))
                            { throw new InvalidDataException(); }

                            multipart_info.contentType = multipart_info.headers["Content-Type"];
                            multipart_info.contentSize = Convert.ToInt32(multipart_info.headers["Content-Length"]);

                            if((multipart_info.contentSize < 0) || (multipart_info.contentSize > contentSizeLimit))
                            { throw new InvalidDataException(); }
                        }

                        //read content
                        {
                            int read_buffer_data_size = read_buffer_offset;
                            read_buffer_offset = multipart_info.contentPosInReadBuffer;

                            //allocate content buffer
                            byte[]? content_buffer = null;
                            if(multipart_info.contentSize > 0)
                            {
                                content_buffer = new byte[multipart_info.contentSize];
                                int content_size_to_read = multipart_info.contentSize;
                                int content_buffer_offset = 0;

                                //There is content in ReadBuffer must be copied to content buffer
                                if(multipart_info.contentPosInReadBuffer < read_buffer_data_size)
                                {
                                    int remaining_byte_count = read_buffer_data_size - read_buffer_offset;
                                    int bytes_to_read = Math.Min(content_size_to_read, remaining_byte_count);
                                    
                                    Buffer.BlockCopy(readBuffer, read_buffer_offset, content_buffer, 0, bytes_to_read);
                                    content_size_to_read -= bytes_to_read;
                                    content_buffer_offset += bytes_to_read;
                                    read_buffer_offset += bytes_to_read;
                                }

                                if(content_size_to_read > 0)
                                {
                                    try_read = false;
                                    do
                                    {
                                        try
                                        {
                                            if(readTcpStream(stream, content_buffer, content_buffer_offset, content_size_to_read) != content_size_to_read)
                                            { throw new IndexOutOfRangeException(); }                        
                                        }
                                        catch(TimeoutException)
                                        {
                                            Dictionary<string, string> keepalive_headers = new Dictionary<string, string>();
                                            keepalive_headers.Add("Content-Type", "application/x-keepalive");
                                            keepalive_headers.Add("Content-Length", "0");
                                            keepalive_headers.Add("X-SocketPoll", "true");

                                            stop_requested = !contentCallback(keepalive_headers, null);

                                            if(!stop_requested)
                                            { try_read = true; }
                                        }
                                        catch(Exception)
                                        {
                                            if(!stop_requested && !externalStopRequested)
                                            { throw; }
                                        }

                                        if(stop_requested || externalStopRequested) { break; }

                                    } while(try_read);

                                    if(stop_requested || externalStopRequested) { break; }
                                }
                            }

                            
                            //yield with content
                            stop_requested = !contentCallback(multipart_info.headers, content_buffer);

                            //must copy remaining bytes from read buffer before reading into it again
                            if(read_buffer_offset != read_buffer_data_size)
                            {
                                int remaining_byte_count = read_buffer_data_size - read_buffer_offset;
                                Buffer.BlockCopy(readBuffer, read_buffer_offset, readBuffer, 0, remaining_byte_count);
                                read_buffer_offset = remaining_byte_count;
                            }
                            else
                            {
                                read_buffer_offset = 0;
                            }
                        }

                    }
                }
            }
        }

        public void RunAsync(Action<Exception> error_callback)
        {
            Task.Run(() => 
            { 
                try
                {
                    Run();
                }
                catch(Exception e)
                {
                    error_callback(e);
                } 
            });
        }

        public void StopAsync()
        {
            externalStopRequested = true;
        }

        private int readTcpStream(NetworkStream stream, byte[] buffer, int offset, int length, bool read_all = true)
        {
            int bytes;
            int read_bytes = 0;
            int read_max = Math.Min((buffer.Length - offset), length);
            
            if(readTimeout.TotalMilliseconds != 0)
            {
                double microsec_wait = readTimeout.TotalMilliseconds * 1000.0;
                bool can_read = stream.Socket.Poll(Convert.ToInt32(microsec_wait), SelectMode.SelectRead);

                if(!can_read)
                { throw new TimeoutException("read timeout"); }
            }

            do
            {
                bytes = stream.Read(buffer, offset + read_bytes, read_max - read_bytes);
                read_bytes += bytes;
            } while(read_all && (bytes > 0) && (read_bytes < length));

            return read_bytes;
        }
    }
    
}