using Newtonsoft.Json.Linq;

namespace Harbard
{
	namespace Api
	{
		public class StorageSession : AApiSession
		{
			public StorageSession(Session parent) : base(parent) {}

			public StorageEvents GetEvents(StorageEventsRequest data)
			{
				ApiResult ApiRes = session.executeCommand("Storage", "GetEvents", data.serialize());
				var response = new StorageEvents();

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

			public void GetEventsAsync(StorageEventsRequest data, Action<StorageEvents, ApiException?> callback)
			{
				session.executeCommandAsync("Storage", "GetEvents", (ApiResult ApiRes) =>
				{
					var response = new StorageEvents();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				}, data.serialize());
			}

			public StorageStatistics GetStatistics()
			{
				ApiResult ApiRes = session.executeCommand("Storage", "GetStatistics");
				var response = new StorageStatistics();

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

			public void GetStatisticsAsync(Action<StorageStatistics, ApiException?> callback)
			{
				session.executeCommandAsync("Storage", "GetStatistics", (ApiResult ApiRes) =>
				{
					var response = new StorageStatistics();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

		}	}
}