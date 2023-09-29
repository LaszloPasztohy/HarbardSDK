using Newtonsoft.Json.Linq;

namespace Harbard
{
	namespace Api
	{
		public static class Deserializers
		{
			public static List<DetectorInfo>? deserialize_ListDetectorInfo(JObject jobj)
			{
				List<DetectorInfo>? part0 = new List<DetectorInfo>();
				foreach(var entry0 in jobj)
				{
					DetectorInfo obj0 = new DetectorInfo();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static List<DetectorTypeInfo>? deserialize_ListDetectorTypeInfo(JObject jobj)
			{
				List<DetectorTypeInfo>? part0 = new List<DetectorTypeInfo>();
				foreach(var entry0 in jobj)
				{
					DetectorTypeInfo obj0 = new DetectorTypeInfo();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static List<short[]>? deserialize_ListArrayint16(JObject jobj)
			{
				List<short[]>? part0 = new List<short[]>();
				foreach(var entry0 in jobj)
				{
					if(entry0.Value != null)
					{
						var entry0_Collection = new short[((JArray)entry0.Value).Count];
						int array_index0 = 0;

						foreach(var entry1 in entry0.Value)
						{
							entry0_Collection[array_index0] = Convert.ToInt16(entry1)!;
							array_index0++;
						}

						part0.Add(entry0_Collection);
					}
				}

				return part0;
			}

			public static List<string>? deserialize_Liststring(JObject jobj)
			{
				List<string>? part0 = new List<string>();
				foreach(var entry0 in jobj)
				{
					part0.Add(Convert.ToString(entry0.Value)!);
				}

				return part0;
			}

			public static List<string>? deserialize_Listguid(JObject jobj)
			{
				List<string>? part0 = new List<string>();
				foreach(var entry0 in jobj)
				{
					part0.Add(Convert.ToString(entry0.Value)!);
				}

				return part0;
			}

			public static List<Event>? deserialize_ListEvent(JObject jobj)
			{
				List<Event>? part0 = new List<Event>();
				foreach(var entry0 in jobj)
				{
					Event obj0 = new Event();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static Dictionary<string, SystemSettingsModule>? deserialize_MapSystemSettingsModule(JObject jobj)
			{
				Dictionary<string, SystemSettingsModule>? part0 = new Dictionary<string, SystemSettingsModule>();
				foreach(var entry0 in jobj)
				{
					SystemSettingsModule obj0 = new SystemSettingsModule();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(entry0.Key, obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static Dictionary<string, GpioInputPort>? deserialize_MapGpioInputPort(JObject jobj)
			{
				Dictionary<string, GpioInputPort>? part0 = new Dictionary<string, GpioInputPort>();
				foreach(var entry0 in jobj)
				{
					GpioInputPort obj0 = new GpioInputPort();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(entry0.Key, obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static Dictionary<string, GpioOutputPort>? deserialize_MapGpioOutputPort(JObject jobj)
			{
				Dictionary<string, GpioOutputPort>? part0 = new Dictionary<string, GpioOutputPort>();
				foreach(var entry0 in jobj)
				{
					GpioOutputPort obj0 = new GpioOutputPort();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(entry0.Key, obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static Dictionary<string, GpioPortState>? deserialize_MapGpioPortState(JObject jobj)
			{
				Dictionary<string, GpioPortState>? part0 = new Dictionary<string, GpioPortState>();
				foreach(var entry0 in jobj)
				{
					GpioPortState obj0 = new GpioPortState();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(entry0.Key, obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static Dictionary<string, long>? deserialize_Mapint64(JObject jobj)
			{
				Dictionary<string, long>? part0 = new Dictionary<string, long>();
				foreach(var entry0 in jobj)
				{
					part0.Add(entry0.Key, Convert.ToInt64(entry0.Value)!);
				}

				return part0;
			}

			public static List<ActiveSession>? deserialize_ListActiveSession(JObject jobj)
			{
				List<ActiveSession>? part0 = new List<ActiveSession>();
				foreach(var entry0 in jobj)
				{
					ActiveSession obj0 = new ActiveSession();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static List<User>? deserialize_ListUser(JObject jobj)
			{
				List<User>? part0 = new List<User>();
				foreach(var entry0 in jobj)
				{
					User obj0 = new User();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static short[]? deserialize_Arrayint16(JArray jobj)
			{
				short[]? part0 = new short[jobj.Count];
				int array_index0 = 0;

				foreach(var entry0 in jobj)
				{
					part0[array_index0] = Convert.ToInt16(entry0)!;
					array_index0++;
				}

				return part0;
			}

			public static List<GeometryLineSegment>? deserialize_ListGeometryLineSegment(JObject jobj)
			{
				List<GeometryLineSegment>? part0 = new List<GeometryLineSegment>();
				foreach(var entry0 in jobj)
				{
					GeometryLineSegment obj0 = new GeometryLineSegment();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static List<GeometryLineGroup>? deserialize_ListGeometryLineGroup(JObject jobj)
			{
				List<GeometryLineGroup>? part0 = new List<GeometryLineGroup>();
				foreach(var entry0 in jobj)
				{
					GeometryLineGroup obj0 = new GeometryLineGroup();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

			public static Dictionary<string, List<string>>? deserialize_MapListstring(JObject jobj)
			{
				Dictionary<string, List<string>>? part0 = new Dictionary<string, List<string>>();
				foreach(var entry0 in jobj)
				{
					if(entry0.Value != null)
					{
						var entry0_Collection = new List<string>();
						foreach(var entry1 in entry0.Value)
						{
							entry0_Collection.Add(Convert.ToString(entry1)!);
						}

						part0.Add(entry0.Key, entry0_Collection);
					}
				}

				return part0;
			}

			public static List<IndexedTrackingDetectorLines>? deserialize_ListIndexedTrackingDetectorLines(JObject jobj)
			{
				List<IndexedTrackingDetectorLines>? part0 = new List<IndexedTrackingDetectorLines>();
				foreach(var entry0 in jobj)
				{
					IndexedTrackingDetectorLines obj0 = new IndexedTrackingDetectorLines();
					if(entry0.Value != null)
					{
						obj0.deserialize((JObject)entry0.Value);
						part0.Add(obj0);
					}
					else
					{ continue; /*unlikely*/ }
				}

				return part0;
			}

		}
	}
}
