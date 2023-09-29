using Newtonsoft.Json.Linq;

namespace Harbard
{
	namespace Api
	{
		public static class Serializers
		{
			public static JObject? serialize_ListDetectorInfo(List<DetectorInfo> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(idx0++.ToString(), entry0.serialize()));
				}

				return part0;
			}

			public static JObject? serialize_ListDetectorTypeInfo(List<DetectorTypeInfo> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(idx0++.ToString(), entry0.serialize()));
				}

				return part0;
			}

			public static JObject? serialize_ListArrayint16(List<short[]> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					JArray part1 = new JArray();
					foreach(var entry1 in entry0)
					{
						part1.Add(entry1);
					}

					part0.Add(new JProperty(idx0++.ToString(), part1));
				}

				return part0;
			}

			public static JObject? serialize_Liststring(List<string> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(idx0++.ToString(), entry0));
				}

				return part0;
			}

			public static JObject? serialize_Listguid(List<string> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(idx0++.ToString(), entry0));
				}

				return part0;
			}

			public static JObject? serialize_ListEvent(List<Event> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(idx0++.ToString(), entry0.serialize()));
				}

				return part0;
			}

			public static JObject? serialize_MapSystemSettingsModule(Dictionary<string, SystemSettingsModule> container)
			{
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(entry0.Key, entry0.Value.serialize()));
				}

				return part0;
			}

			public static JObject? serialize_MapGpioInputPort(Dictionary<string, GpioInputPort> container)
			{
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(entry0.Key, entry0.Value.serialize()));
				}

				return part0;
			}

			public static JObject? serialize_MapGpioOutputPort(Dictionary<string, GpioOutputPort> container)
			{
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(entry0.Key, entry0.Value.serialize()));
				}

				return part0;
			}

			public static JObject? serialize_MapGpioPortState(Dictionary<string, GpioPortState> container)
			{
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(entry0.Key, entry0.Value.serialize()));
				}

				return part0;
			}

			public static JObject? serialize_Mapint64(Dictionary<string, long> container)
			{
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(entry0.Key, entry0.Value));
				}

				return part0;
			}

			public static JObject? serialize_ListActiveSession(List<ActiveSession> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(idx0++.ToString(), entry0.serialize()));
				}

				return part0;
			}

			public static JObject? serialize_ListUser(List<User> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(idx0++.ToString(), entry0.serialize()));
				}

				return part0;
			}

			public static JArray? serialize_Arrayint16(short[] container)
			{
				JArray part0 = new JArray();
				foreach(var entry0 in container)
				{
					part0.Add(entry0);
				}

				return part0;
			}

			public static JObject? serialize_ListGeometryLineSegment(List<GeometryLineSegment> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(idx0++.ToString(), entry0.serialize()));
				}

				return part0;
			}

			public static JObject? serialize_ListGeometryLineGroup(List<GeometryLineGroup> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(idx0++.ToString(), entry0.serialize()));
				}

				return part0;
			}

			public static JObject? serialize_MapListstring(Dictionary<string, List<string>> container)
			{
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					int idx1 = 0;
					JObject part1 = new JObject();
					foreach(var entry1 in entry0.Value)
					{
						part1.Add(new JProperty(idx1++.ToString(), entry1));
					}

					part0.Add(new JProperty(entry0.Key, part1));
				}

				return part0;
			}

			public static JObject? serialize_ListIndexedTrackingDetectorLines(List<IndexedTrackingDetectorLines> container)
			{
				int idx0 = 0;
				JObject part0 = new JObject();
				foreach(var entry0 in container)
				{
					part0.Add(new JProperty(idx0++.ToString(), entry0.serialize()));
				}

				return part0;
			}

		}
	}
}
