using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace Harbard
{
    public class ApiException : System.Exception
    {
        public string exceptionClass;
        public string errorMessage;

        public ApiException(string eclass = "", string emsg = "") : base(emsg)
        {
            exceptionClass = eclass;
            errorMessage = emsg;
        }

        public override string ToString()
        {
            return ($"{exceptionClass}: {errorMessage}");
        }
    }

    public struct ApiResult
    {
        public JObject? data;
        public ApiException? error;

        public ApiResult(JObject? jObjData = null, ApiException? apiExc = null)
        {
            data = jObjData;
            error = apiExc;
        }

        public override string ToString()
        {
            if(data != null)
            {
                return data.ToString();
            }
            else if(error != null)
            {
                return error.ToString();
            }

            return "";
        }
    }

    public class Session : IDisposable
    {
        private string address;
        private string user;
        private string password;
        private int port;
        HttpClient httpClient;
        private string protocol;

        private string sid = "";
        private ApiException? lastError;
        private bool isSecureConnection;
        HttpClientHandler clientHandler;

        public string Id
        {
            get { return sid; }
        }

        public ApiException? LastError
        {
            get { return lastError; }
        }

        public string Address
        {
            get { return address; }
        }

        public int Port
        {
            get { return port; }
        }

        public Session(string inputAddress, string inputUser, string inputPassword, int inputPort = 80, bool secureConnection = false)
        {
            isSecureConnection = secureConnection;

            if(inputAddress.StartsWith("http://"))
            {
                address = inputAddress.Substring("http://".Length);
            }
            else if(inputAddress.StartsWith("https://"))
            {
                address = inputAddress.Substring("https://".Length);
                isSecureConnection = true;
            }
            else
            {
                address = inputAddress;
            }

            user = inputUser;
            password = inputPassword;

            port = inputPort;
            if((port == 80) && isSecureConnection)
            { port = 443; }
            
            protocol = isSecureConnection ? "https://" : "http://";
            
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = ServerCertificateCustomValidation;

            httpClient = new HttpClient(clientHandler);
        }
        private static bool ServerCertificateCustomValidation(HttpRequestMessage requestMessage, X509Certificate2? certificate, X509Chain? chain, SslPolicyErrors sslErrors)
        {
            return true;
        }


        public bool login()
        {
            try
            {
                JObject jsonToSend = new JObject(new JProperty("User",user), new JProperty("Password",password));

                var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

                HttpResponseMessage response;


                using(var requestMessage = new HttpRequestMessage(HttpMethod.Post, protocol + address + ":" + port + "/login"))
                {
                    requestMessage.Content = new StringContent(jsonToSend.ToString(), System.Text.Encoding.UTF8, "application/json");
                    response = httpClient.Send(requestMessage);
                }

                using(StreamReader reader = new StreamReader(response.Content.ReadAsStream()))
                {
                    string responseString = reader.ReadToEnd();

                    var result = JObject.Parse(responseString);
                    lastError = new ApiException("ProtocolError");
                
                    JToken? responseType = result["Type"];
                    JToken? responseData = result["Data"];

                    if((responseType != null) && (responseData != null))
                    {
                        string responseTypeValue = responseType.ToString();

                        if((responseTypeValue == "Response") || (responseTypeValue == "Error"))
                        {
                            if(responseTypeValue == "Response")
                            {
                                JToken? responseDataSid = responseData["sid"];
                                if(responseDataSid != null)
                                {
                                    sid = responseDataSid.ToString();
                                    
                                    lastError = null;

                                    return true;
                                }
                            }
                            else
                            {
                                JToken? responseDataErrorMessage = responseData["ErrorMessage"];
                                JToken? responseDataExceptionClass = responseData["ExceptionClass"];

                                if((responseDataErrorMessage != null) && (responseDataExceptionClass != null))
                                {
                                    lastError.exceptionClass = responseDataExceptionClass.ToString();
                                    lastError.errorMessage = responseDataErrorMessage.ToString();
                                }
                            }
                        }
                    }
                    
                    return false;
                }
            }
            catch(HttpRequestException re)
            {
                lastError = new ApiException("RequestError", re.Message);
                return false;
            }
            catch(Exception e)
            {
                //unlikely
                lastError = new ApiException("Unknown",e.Message);
                return false;
            }
        }

        public void logout()
        {
            try
            {
                using(var requestMessage = new HttpRequestMessage(HttpMethod.Post, protocol + address + "/logout?sid=" + sid))
                {
                    requestMessage.Content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");
                    var response = httpClient.Send(requestMessage);
                }
            }
            catch(HttpRequestException re)
            {
                lastError = new ApiException("RequestError", re.Message);
            }
            catch(Exception e)
            {
                //unlikely
                lastError = new ApiException("Unknown",e.Message);
            }
            finally
            {
                sid = "";
            }
        }

        public ApiResult executeCommand(string category, string method, JObject? data = null)
        {
            if(sid == "")
            {
                lastError = new ApiException("RequestError", "Unauthorized, missing session ID");
                return new ApiResult(null, lastError);
            }

            try
            {
                JObject? jsonToSend = data;

                var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

                HttpResponseMessage response;

                using(var requestMessage = new HttpRequestMessage(HttpMethod.Post,
                        protocol + address + ":" + port + "/api/" + category + "/" + method + "?sid=" + sid))
                {
                    requestMessage.Content = new StringContent((jsonToSend != null) ? jsonToSend.ToString() : "", System.Text.Encoding.UTF8, "application/json");
                    response = httpClient.Send(requestMessage);
                }

                using(StreamReader reader = new StreamReader(response.Content.ReadAsStream()))
                {
                    string responseString = reader.ReadToEnd();

                    var result = JObject.Parse(responseString);
                    lastError = new ApiException("ProtocolError");
                
                    JToken? responseType = result["Type"];
                    JToken? responseData = result["Data"];

                    if((responseType != null) && (responseData != null))
                    {
                        string responseTypeValue = responseType.ToString();

                        if((responseTypeValue == "Response") || (responseTypeValue == "Error"))
                        {
                            if(responseTypeValue == "Response")
                            {
                                return new ApiResult((JObject)responseData);
                            }
                            else
                            {
                                JToken? responseDataErrorMessage = responseData["ErrorMessage"];
                                JToken? responseDataExceptionClass = responseData["ExceptionClass"];

                                if((responseDataErrorMessage != null) && (responseDataExceptionClass != null))
                                {
                                    lastError.exceptionClass = responseDataExceptionClass.ToString();
                                    lastError.errorMessage = responseDataErrorMessage.ToString();
                                }
                            }
                        }
                    }
                    
                    return new ApiResult(null, lastError);
                }
            }
            catch(HttpRequestException re)
            {
                lastError = new ApiException("RequestError", re.Message);
                return new ApiResult(null, lastError);
            }
            catch(Exception e)
            {
                //unlikely
                lastError = new ApiException("Unknown",e.Message);
                return new ApiResult(null, lastError);
            }
        }

        public ApiResult executeCommand(string path, JObject? data = null)
        {
            string category = "";
            string method = "";

            if(path.Contains(".") || path.Contains("/"))
            {
                string[] pathParts = path.Split(path.Contains(".") ? '.' : '/');
                if(pathParts.Length > 1)
                {
                    category = pathParts[0];
                    method = pathParts[1];
                }
            }
            
            if((category == "") || (method == ""))
            {
                lastError = new ApiException("RequestError","Wrong path format. Try using <Category/Method> or <Category.Method>");
                return new ApiResult(null, lastError);
            }

            return executeCommand(category, method, data);
        }

        public void executeCommandAsync(string category, string method, Action<ApiResult> callback, JObject? data = null)
        {
            Task.Run(() => 
            {
                var retval = executeCommand(category, method, data);
                callback(retval);
            });
        }

        public Task<ApiResult> executeCommandAsync(string category, string method, JObject? data = null)
        {
            return Task<ApiResult>.Run(() => 
            {
                return executeCommand(category, method, data);
            });
        }

        public (HttpResponseMessage?, ApiResult?) requestHttpGet(string url) 
        {
            HttpResponseMessage? response = null;

            if(!url.StartsWith("/")) { url = "/" + url; }

            try
            {
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, protocol + address + ":" + port + url))
                {
                    response = httpClient.Send(requestMessage);
                }
                return (response, null);
            }
            catch (HttpRequestException re)
            {
                lastError = new ApiException("RequestError", re.Message);
                return (response, new ApiResult(null, lastError));
            }
            catch (Exception e)
            {
                //unlikely
                lastError = new ApiException("Unknown", e.Message);
                return (response, new ApiResult(null, lastError));
            }
        }

        public void Dispose()
        {
            logout();
            
            clientHandler.Dispose();
            httpClient.Dispose();
        }
    }
}
