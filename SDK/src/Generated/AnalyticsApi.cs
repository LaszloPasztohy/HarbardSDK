using Newtonsoft.Json.Linq;

namespace Harbard
{
	namespace Api
	{
		public class DetectorList : AJsonSerializable
		{
			public List<DetectorInfo>? _Detectors;

			public override JObject? serialize()
			{
				JObject _detectorList = new JObject();

				if(_Detectors != null)
				{ _detectorList.Add("Detectors",Serializers.serialize_ListDetectorInfo(_Detectors)); }

				return _detectorList;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Detectors = (JObject?)data["Detectors"];
				if(data_Detectors != null)
				{ _Detectors = Deserializers.deserialize_ListDetectorInfo(data_Detectors); }
				else
				{ success = false; }


				return success;
			}
		}

		public class DetectorCreateConfiguration : AJsonSerializable
		{
			public string? _DetectorID;
			public string? _DetectorClass;

			public override JObject? serialize()
			{
				JObject _detectorCreateConfiguration = new JObject();


				_detectorCreateConfiguration.Add(new JProperty("DetectorID", _DetectorID));


				_detectorCreateConfiguration.Add(new JProperty("DetectorClass", _DetectorClass));

				return _detectorCreateConfiguration;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_DetectorID = data["DetectorID"];
				if(data_DetectorID != null)
				{ _DetectorID = Convert.ToString(data_DetectorID); }
				else
				{ success = false; }

				var data_DetectorClass = data["DetectorClass"];
				if(data_DetectorClass != null)
				{ _DetectorClass = Convert.ToString(data_DetectorClass); }
				else
				{ success = false; }


				return success;
			}
		}

		public class SupportedDetectors : AJsonSerializable
		{
			public List<DetectorTypeInfo>? _DetectorClasses;

			public override JObject? serialize()
			{
				JObject _supportedDetectors = new JObject();

				if(_DetectorClasses != null)
				{ _supportedDetectors.Add("DetectorClasses",Serializers.serialize_ListDetectorTypeInfo(_DetectorClasses)); }

				return _supportedDetectors;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_DetectorClasses = (JObject?)data["DetectorClasses"];
				if(data_DetectorClasses != null)
				{ _DetectorClasses = Deserializers.deserialize_ListDetectorTypeInfo(data_DetectorClasses); }
				else
				{ success = false; }


				return success;
			}
		}

		public class Detector : AJsonSerializable
		{
			public DetectorConfiguration? _Config;
			public string? _DetectorID;

			public override JObject? serialize()
			{
				JObject _detector = new JObject();

				if(_Config != null)
				{ _detector.Add(new JProperty("Config", _Config.serialize())); }


				_detector.Add(new JProperty("DetectorID", _DetectorID));

				return _detector;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_Config = new DetectorConfiguration();
				var data_Config = (JObject?)data["Config"];
				if(data_Config != null)
				{ success = success && _Config.deserialize(data_Config); }

				var data_DetectorID = data["DetectorID"];
				if(data_DetectorID != null)
				{ _DetectorID = Convert.ToString(data_DetectorID); }
				else
				{ success = false; }


				return success;
			}
		}

		public class DetectorRequest : AJsonSerializable
		{
			public string? _DetectorID;

			public override JObject? serialize()
			{
				JObject _detectorRequest = new JObject();


				_detectorRequest.Add(new JProperty("DetectorID", _DetectorID));

				return _detectorRequest;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_DetectorID = data["DetectorID"];
				if(data_DetectorID != null)
				{ _DetectorID = Convert.ToString(data_DetectorID); }
				else
				{ success = false; }


				return success;
			}
		}

		public class DetectorState : AJsonSerializable
		{
			public int _State;

			public override JObject? serialize()
			{
				JObject _detectorState = new JObject();


				_detectorState.Add(new JProperty("State", _State));

				return _detectorState;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_State = data["State"];
				if(data_State != null)
				{ _State = Convert.ToInt32(data_State); }
				else
				{ success = false; }


				return success;
			}
		}

		public class DetectorClassRequest : AJsonSerializable
		{
			public string? _DetectorClass;

			public override JObject? serialize()
			{
				JObject _detectorClassRequest = new JObject();


				_detectorClassRequest.Add(new JProperty("DetectorClass", _DetectorClass));

				return _detectorClassRequest;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_DetectorClass = data["DetectorClass"];
				if(data_DetectorClass != null)
				{ _DetectorClass = Convert.ToString(data_DetectorClass); }
				else
				{ success = false; }


				return success;
			}
		}

		public class TrackerConfiguration : AJsonSerializable
		{
			public TrackerConfiguration_Config? _Config;

			public override JObject? serialize()
			{
				JObject _trackerConfiguration = new JObject();

				if(_Config != null)
				{ _trackerConfiguration.Add(new JProperty("Config", _Config.serialize())); }

				return _trackerConfiguration;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_Config = new TrackerConfiguration_Config();
				var data_Config = (JObject?)data["Config"];
				if(data_Config != null)
				{ success = success && _Config.deserialize(data_Config); }


				return success;
			}
		}

		public class AnprEngineConfiguration : AJsonSerializable
		{
			public AnprEngineConfiguration_Config? _Config;

			public override JObject? serialize()
			{
				JObject _anprEngineConfiguration = new JObject();

				if(_Config != null)
				{ _anprEngineConfiguration.Add(new JProperty("Config", _Config.serialize())); }

				return _anprEngineConfiguration;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_Config = new AnprEngineConfiguration_Config();
				var data_Config = (JObject?)data["Config"];
				if(data_Config != null)
				{ success = success && _Config.deserialize(data_Config); }


				return success;
			}
		}

		public class AnprEngineState : AJsonSerializable
		{
			public AnprEngineState_Config? _Config;

			public override JObject? serialize()
			{
				JObject _anprEngineState = new JObject();

				if(_Config != null)
				{ _anprEngineState.Add(new JProperty("Config", _Config.serialize())); }

				return _anprEngineState;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_Config = new AnprEngineState_Config();
				var data_Config = (JObject?)data["Config"];
				if(data_Config != null)
				{ success = success && _Config.deserialize(data_Config); }


				return success;
			}
		}

		public class AnalyticsEngineTrigger : AJsonSerializable
		{
			public string? _Target;
			public int _Count;
			public AnalyticsEngineTrigger_TriggerSource? _TriggerSource;

			public override JObject? serialize()
			{
				JObject _analyticsEngineTrigger = new JObject();


				_analyticsEngineTrigger.Add(new JProperty("Target", _Target));


				_analyticsEngineTrigger.Add(new JProperty("Count", _Count));

				if(_TriggerSource != null)
				{ _analyticsEngineTrigger.Add(new JProperty("TriggerSource", _TriggerSource.serialize())); }

				return _analyticsEngineTrigger;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Target = data["Target"];
				if(data_Target != null)
				{ _Target = Convert.ToString(data_Target); }
				else
				{ success = false; }

				var data_Count = data["Count"];
				if(data_Count != null)
				{ _Count = Convert.ToInt32(data_Count); }
				else
				{ success = false; }

				_TriggerSource = new AnalyticsEngineTrigger_TriggerSource();
				var data_TriggerSource = (JObject?)data["TriggerSource"];
				if(data_TriggerSource != null)
				{ success = success && _TriggerSource.deserialize(data_TriggerSource); }


				return success;
			}
		}

		public class AnalyticsEngineTriggerResponse : AJsonSerializable
		{
			public string? _Source;
			public string? _Name;
			public DateTime _Timestamp;

			public override JObject? serialize()
			{
				JObject _analyticsEngineTriggerResponse = new JObject();


				_analyticsEngineTriggerResponse.Add(new JProperty("Source", _Source));


				_analyticsEngineTriggerResponse.Add(new JProperty("Name", _Name));


				_analyticsEngineTriggerResponse.Add(new JProperty("Timestamp", DateTimeConverter.convertToTimeStamp(_Timestamp)));

				return _analyticsEngineTriggerResponse;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Source = data["Source"];
				if(data_Source != null)
				{ _Source = Convert.ToString(data_Source); }
				else
				{ success = false; }

				var data_Name = data["Name"];
				if(data_Name != null)
				{ _Name = Convert.ToString(data_Name); }
				else
				{ success = false; }

				var data_Timestamp = data["Timestamp"];
				if(data_Timestamp != null)
				{ _Timestamp = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_Timestamp)); }
				else
				{ success = false; }


				return success;
			}
		}

		public class BufferedEventsRequest : AJsonSerializable
		{
			public List<string>? _Filter;

			public override JObject? serialize()
			{
				JObject _bufferedEventsRequest = new JObject();

				if(_Filter != null)
				{ _bufferedEventsRequest.Add("Filter",Serializers.serialize_Listguid(_Filter)); }

				return _bufferedEventsRequest;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Filter = (JObject?)data["Filter"];
				if(data_Filter != null)
				{ _Filter = Deserializers.deserialize_Listguid(data_Filter); }
				else
				{ success = false; }


				return success;
			}
		}

		public class BufferedEvents : AJsonSerializable
		{
			public List<Event>? _EventList;
			public int _DiscardedEvents;

			public override JObject? serialize()
			{
				JObject _bufferedEvents = new JObject();

				if(_EventList != null)
				{ _bufferedEvents.Add("EventList",Serializers.serialize_ListEvent(_EventList)); }

				_bufferedEvents.Add(new JProperty("DiscardedEvents", _DiscardedEvents));

				return _bufferedEvents;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_EventList = (JObject?)data["EventList"];
				if(data_EventList != null)
				{ _EventList = Deserializers.deserialize_ListEvent(data_EventList); }
				else
				{ success = false; }

				var data_DiscardedEvents = data["DiscardedEvents"];
				if(data_DiscardedEvents != null)
				{ _DiscardedEvents = Convert.ToInt32(data_DiscardedEvents); }
				else
				{ success = false; }


				return success;
			}
		}

	}
}