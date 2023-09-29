using System;
using Harbard.Api;
using System.Diagnostics;

namespace Harbard
{
    public class LiveEventQuery
    {
        volatile bool stopRequest;
        private AnalyticsSession analyticsSession;
        private BufferedEventsRequest bufferedEventsRequest;
        private Func<BufferedEvents?, ApiException?, bool> callback;

        public LiveEventQuery(AnalyticsSession sess, Func<BufferedEvents?, ApiException?, bool> callback)
        {
            analyticsSession = sess;
            this.callback = callback;
            stopRequest = false;

            bufferedEventsRequest = new BufferedEventsRequest();
        }

        public void RequestStop() { stopRequest = true; }

        public void Run()
        {
            ApiResult start_response = analyticsSession.StartEvents(bufferedEventsRequest);

            if((start_response.data == null) && (start_response.error != null))
            {
                throw new InvalidDataException("Starting events failed. No data to read.");
            }

            do
            {
                if(!stopRequest)
                {
                    try
                    {
                        bool externalStopRequested = !callback(analyticsSession.GetEvents(), null);

                        if(externalStopRequested)
                        { RequestStop(); }
                    }
                    catch(ApiException e)
                    {
                        callback(null, e);
                        RequestStop();
                    }
                }
                else
                {
                    analyticsSession.StopEvents();
                }
                
            } while (!stopRequest);
        }

        public void RunAsync()
        {
            analyticsSession.StartEventsAsync(bufferedEventsRequest, (ApiResult start_result) =>
            {
                if(start_result.error != null)
                {
                    throw new ApiException(start_result.error.exceptionClass, start_result.error.errorMessage);
                }
            });

            analyticsSession.GetEventsAsync(asyncCallback);
        }

        private void asyncCallback(BufferedEvents result, ApiException? error)
        {
            if(error != null)
            {
                callback(null, error);
                RequestStop();
            }

            if(!stopRequest)
            {
                try
                {
                    bool externalStopRequested = !callback(result, null);

                    if(externalStopRequested)
                    { RequestStop(); }
                    else
                    { analyticsSession.GetEventsAsync(asyncCallback); }
                }
                catch(ApiException e)
                {
                    callback(null, e);
                    RequestStop();
                }                
            }
            else
            {
                analyticsSession.StopEvents();
            }
        }
    }
}