using Newtonsoft.Json.Linq;

namespace Harbard
{
	namespace Api
	{
		public class AnalyticsSession : AApiSession
		{
			public AnalyticsSession(Session parent) : base(parent) {}

			public SupportedDetectors GetSupportedDetectors()
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetSupportedDetectors");
				var response = new SupportedDetectors();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetSupportedDetectorsAsync(Action<SupportedDetectors, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetSupportedDetectors", (ApiResult ApiRes) =>
				{
					var response = new SupportedDetectors();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public DetectorList GetDetectors()
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetDetectors");
				var response = new DetectorList();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetDetectorsAsync(Action<DetectorList, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetDetectors", (ApiResult ApiRes) =>
				{
					var response = new DetectorList();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public Detector GetDetector(DetectorRequest data)
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetDetector", data.serialize());
				var response = new Detector();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetDetectorAsync(DetectorRequest data, Action<Detector, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetDetector", (ApiResult ApiRes) =>
				{
					var response = new Detector();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				}, data.serialize());
			}

			public ApiResult SetDetector(Detector data)
			{
				ApiResult ApiRes = Session.executeCommand("Analytics", "SetDetector", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void SetDetectorAsync(Detector data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("Analytics", "SetDetector", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult EnableDetector(DetectorRequest data)
			{
				ApiResult ApiRes = Session.executeCommand("Analytics", "EnableDetector", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void EnableDetectorAsync(DetectorRequest data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("Analytics", "EnableDetector", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult DisableDetector(DetectorRequest data)
			{
				ApiResult ApiRes = Session.executeCommand("Analytics", "DisableDetector", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void DisableDetectorAsync(DetectorRequest data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("Analytics", "DisableDetector", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult CreateDetector(DetectorCreateConfiguration data)
			{
				ApiResult ApiRes = Session.executeCommand("Analytics", "CreateDetector", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void CreateDetectorAsync(DetectorCreateConfiguration data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("Analytics", "CreateDetector", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult DeleteDetector(DetectorRequest data)
			{
				ApiResult ApiRes = Session.executeCommand("Analytics", "DeleteDetector", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void DeleteDetectorAsync(DetectorRequest data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("Analytics", "DeleteDetector", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult DeleteAllDetectors()
			{
				ApiResult ApiRes = Session.executeCommand("Analytics", "DeleteAllDetectors");

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void DeleteAllDetectorsAsync(Action<ApiResult> callback)
			{
				session.executeCommandAsync("Analytics", "DeleteAllDetectors", (ApiResult ApiRes) => { callback(ApiRes); });
			}

			public DetectorState GetDetectorState(DetectorRequest data)
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetDetectorState", data.serialize());
				var response = new DetectorState();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetDetectorStateAsync(DetectorRequest data, Action<DetectorState, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetDetectorState", (ApiResult ApiRes) =>
				{
					var response = new DetectorState();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				}, data.serialize());
			}

			public Detector GetDetectorDefaults(DetectorClassRequest data)
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetDetectorDefaults", data.serialize());
				var response = new Detector();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetDetectorDefaultsAsync(DetectorClassRequest data, Action<Detector, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetDetectorDefaults", (ApiResult ApiRes) =>
				{
					var response = new Detector();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				}, data.serialize());
			}

			public TrackerConfiguration GetTracker()
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetTracker");
				var response = new TrackerConfiguration();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetTrackerAsync(Action<TrackerConfiguration, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetTracker", (ApiResult ApiRes) =>
				{
					var response = new TrackerConfiguration();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public ApiResult SetTracker(TrackerConfiguration data)
			{
				ApiResult ApiRes = Session.executeCommand("Analytics", "SetTracker", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void SetTrackerAsync(TrackerConfiguration data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("Analytics", "SetTracker", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public TrackerConfiguration GetTrackerDefaults()
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetTrackerDefaults");
				var response = new TrackerConfiguration();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetTrackerDefaultsAsync(Action<TrackerConfiguration, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetTrackerDefaults", (ApiResult ApiRes) =>
				{
					var response = new TrackerConfiguration();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public AnprEngineConfiguration GetAnprEngine()
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetAnprEngine");
				var response = new AnprEngineConfiguration();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetAnprEngineAsync(Action<AnprEngineConfiguration, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetAnprEngine", (ApiResult ApiRes) =>
				{
					var response = new AnprEngineConfiguration();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public AnprEngineConfiguration GetAnprEngineDefaults()
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetAnprEngineDefaults");
				var response = new AnprEngineConfiguration();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetAnprEngineDefaultsAsync(Action<AnprEngineConfiguration, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetAnprEngineDefaults", (ApiResult ApiRes) =>
				{
					var response = new AnprEngineConfiguration();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public ApiResult SetAnprEngine(AnprEngineConfiguration data)
			{
				ApiResult ApiRes = Session.executeCommand("Analytics", "SetAnprEngine", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void SetAnprEngineAsync(AnprEngineConfiguration data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("Analytics", "SetAnprEngine", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public AnprEngineState GetAnprEngineState()
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetAnprEngineState");
				var response = new AnprEngineState();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetAnprEngineStateAsync(Action<AnprEngineState, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetAnprEngineState", (ApiResult ApiRes) =>
				{
					var response = new AnprEngineState();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public AnalyticsEngineTriggerResponse TriggerEngine(AnalyticsEngineTrigger data)
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "TriggerEngine", data.serialize());
				var response = new AnalyticsEngineTriggerResponse();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void TriggerEngineAsync(AnalyticsEngineTrigger data, Action<AnalyticsEngineTriggerResponse, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "TriggerEngine", (ApiResult ApiRes) =>
				{
					var response = new AnalyticsEngineTriggerResponse();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				}, data.serialize());
			}

			public ApiResult StartEvents(BufferedEventsRequest data)
			{
				ApiResult ApiRes = Session.executeCommand("Analytics", "StartEvents", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void StartEventsAsync(BufferedEventsRequest data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("Analytics", "StartEvents", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult StopEvents()
			{
				ApiResult ApiRes = Session.executeCommand("Analytics", "StopEvents");

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void StopEventsAsync(Action<ApiResult> callback)
			{
				session.executeCommandAsync("Analytics", "StopEvents", (ApiResult ApiRes) => { callback(ApiRes); });
			}

			public BufferedEvents GetEvents()
			{
				ApiResult ApiRes = session.executeCommand("Analytics", "GetEvents");
				var response = new BufferedEvents();

				if(ApiRes.data != null)
				{
					if(response.deserialize(ApiRes.data))
					{
						return response;
					}
				}

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return response;
			}

			public void GetEventsAsync(Action<BufferedEvents, ApiException?> callback)
			{
				session.executeCommandAsync("Analytics", "GetEvents", (ApiResult ApiRes) =>
				{
					var response = new BufferedEvents();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

		}	}
}