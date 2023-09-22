using Newtonsoft.Json.Linq;

namespace Harbard
{
	namespace Api
	{
		public class StorageEventsRequest : AJsonSerializable
		{
			public string? _ID;
			public DateTime _StartTime;
			public DateTime _EndTime;
			public StorageEventsRequestFilter? _Filter;

			public override JObject? serialize()
			{
				JObject _storageEventsRequest = new JObject();


				_storageEventsRequest.Add(new JProperty("ID", _ID));


				_storageEventsRequest.Add(new JProperty("StartTime", DateTimeConverter.convertToTimeStamp(_StartTime)));


				_storageEventsRequest.Add(new JProperty("EndTime", DateTimeConverter.convertToTimeStamp(_EndTime)));

				if(_Filter != null)
				{ _storageEventsRequest.Add(new JProperty("Filter", _Filter.serialize())); }

				return _storageEventsRequest;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_ID = data["ID"];
				if(data_ID != null)
				{ _ID = Convert.ToString(data_ID); }
				else
				{ success = false; }

				var data_StartTime = data["StartTime"];
				if(data_StartTime != null)
				{ _StartTime = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_StartTime)); }
				else
				{ success = false; }

				var data_EndTime = data["EndTime"];
				if(data_EndTime != null)
				{ _EndTime = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_EndTime)); }
				else
				{ success = false; }

				_Filter = new StorageEventsRequestFilter();
				var data_Filter = (JObject?)data["Filter"];
				if(data_Filter != null)
				{ success = success && _Filter.deserialize(data_Filter); }


				return success;
			}
		}

		public class StorageEvents : StorageEventsRequest
		{
			public List<Event>? _EventList;
			public string? _Status;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventList != null)
					{ base_jobj.Add("EventList",Serializers.serialize_ListEvent(_EventList)); }

					base_jobj.Add(new JProperty("Status", _Status));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_EventList = (JObject?)data["EventList"];
				if(data_EventList != null)
				{ _EventList = Deserializers.deserialize_ListEvent(data_EventList); }
				else
				{ success = false; }

				var data_Status = data["Status"];
				if(data_Status != null)
				{ _Status = Convert.ToString(data_Status); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class StorageStatistics : AJsonSerializable
		{
			public DateTime _StartTime;
			public DateTime _EndTime;
			public long _InUse;
			public long _Total;

			public override JObject? serialize()
			{
				JObject _storageStatistics = new JObject();


				_storageStatistics.Add(new JProperty("StartTime", DateTimeConverter.convertToTimeStamp(_StartTime)));


				_storageStatistics.Add(new JProperty("EndTime", DateTimeConverter.convertToTimeStamp(_EndTime)));


				_storageStatistics.Add(new JProperty("InUse", _InUse));


				_storageStatistics.Add(new JProperty("Total", _Total));

				return _storageStatistics;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_StartTime = data["StartTime"];
				if(data_StartTime != null)
				{ _StartTime = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_StartTime)); }
				else
				{ success = false; }

				var data_EndTime = data["EndTime"];
				if(data_EndTime != null)
				{ _EndTime = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_EndTime)); }
				else
				{ success = false; }

				var data_InUse = data["InUse"];
				if(data_InUse != null)
				{ _InUse = Convert.ToInt64(data_InUse); }
				else
				{ success = false; }

				var data_Total = data["Total"];
				if(data_Total != null)
				{ _Total = Convert.ToInt64(data_Total); }
				else
				{ success = false; }


				return success;
			}
		}

	}
}