using Newtonsoft.Json.Linq;

namespace Harbard
{
	namespace Api
	{
		public class DetectorInfo : AJsonSerializable
		{
			public string? _DetectorID;
			public string? _DetectorClass;
			public int _DetectorClassID;
			public int _Version;
			public string? _Description;
			public string? _DisplayName;
			public string? _State;
			public bool _BuiltIn;

			public override JObject? serialize()
			{
				JObject _detectorInfo = new JObject();


				_detectorInfo.Add(new JProperty("DetectorID", _DetectorID));


				_detectorInfo.Add(new JProperty("DetectorClass", _DetectorClass));


				_detectorInfo.Add(new JProperty("DetectorClassID", _DetectorClassID));


				_detectorInfo.Add(new JProperty("Version", _Version));


				_detectorInfo.Add(new JProperty("Description", _Description));


				_detectorInfo.Add(new JProperty("DisplayName", _DisplayName));


				_detectorInfo.Add(new JProperty("State", _State));


				_detectorInfo.Add(new JProperty("BuiltIn", _BuiltIn));

				return _detectorInfo;
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

				var data_DetectorClassID = data["DetectorClassID"];
				if(data_DetectorClassID != null)
				{ _DetectorClassID = Convert.ToInt32(data_DetectorClassID); }
				else
				{ success = false; }

				var data_Version = data["Version"];
				if(data_Version != null)
				{ _Version = Convert.ToInt32(data_Version); }
				else
				{ success = false; }

				var data_Description = data["Description"];
				if(data_Description != null)
				{ _Description = Convert.ToString(data_Description); }
				else
				{ success = false; }

				var data_DisplayName = data["DisplayName"];
				if(data_DisplayName != null)
				{ _DisplayName = Convert.ToString(data_DisplayName); }
				else
				{ success = false; }

				var data_State = data["State"];
				if(data_State != null)
				{ _State = Convert.ToString(data_State); }
				else
				{ success = false; }

				var data_BuiltIn = data["BuiltIn"];
				if(data_BuiltIn != null)
				{ _BuiltIn = Convert.ToBoolean(data_BuiltIn); }
				else
				{ success = false; }


				return success;
			}
		}

		public class DetectorTypeInfo : AJsonSerializable
		{
			public string? _DetectorClass;
			public int _Version;
			public int _InstanceLimit;
			public int _InstanceCount;

			public override JObject? serialize()
			{
				JObject _detectorTypeInfo = new JObject();


				_detectorTypeInfo.Add(new JProperty("DetectorClass", _DetectorClass));


				_detectorTypeInfo.Add(new JProperty("Version", _Version));


				_detectorTypeInfo.Add(new JProperty("InstanceLimit", _InstanceLimit));


				_detectorTypeInfo.Add(new JProperty("InstanceCount", _InstanceCount));

				return _detectorTypeInfo;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_DetectorClass = data["DetectorClass"];
				if(data_DetectorClass != null)
				{ _DetectorClass = Convert.ToString(data_DetectorClass); }
				else
				{ success = false; }

				var data_Version = data["Version"];
				if(data_Version != null)
				{ _Version = Convert.ToInt32(data_Version); }
				else
				{ success = false; }

				var data_InstanceLimit = data["InstanceLimit"];
				if(data_InstanceLimit != null)
				{ _InstanceLimit = Convert.ToInt32(data_InstanceLimit); }
				else
				{ success = false; }

				var data_InstanceCount = data["InstanceCount"];
				if(data_InstanceCount != null)
				{ _InstanceCount = Convert.ToInt32(data_InstanceCount); }
				else
				{ success = false; }


				return success;
			}
		}

		public class TrackerConfiguration_Config : AJsonSerializable
		{
			public List<short[]>? _Masks;

			public override JObject? serialize()
			{
				JObject _trackerConfiguration_Config = new JObject();

				if(_Masks != null)
				{ _trackerConfiguration_Config.Add("Masks",Serializers.serialize_ListArrayint16(_Masks)); }

				return _trackerConfiguration_Config;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Masks = (JObject?)data["Masks"];
				if(data_Masks != null)
				{ _Masks = Deserializers.deserialize_ListArrayint16(data_Masks); }
				else
				{ success = false; }


				return success;
			}
		}

		public class AnprEngineConfiguration_Config : AJsonSerializable
		{
			public List<short[]>? _Masks;
			public string? _Type;
			public string? _TriggerMode;
			public List<string>? _TriggerModes;
			public bool _ColorRecognition;
			public bool _InterruptOnRecognition;
			public int _ValidInTimeWindow;
			public sbyte _Confidence;
			public string? _CountryPreference;
			public string? _RecognitionMode;
			public HardwareTriggerSettings? _HardwareTriggerSettings;
			public SoftwareTriggerSettings? _SoftwareTriggerSettings;
			public bool _MMR;
			public bool _Direction;

			public override JObject? serialize()
			{
				JObject _anprEngineConfiguration_Config = new JObject();

				if(_Masks != null)
				{ _anprEngineConfiguration_Config.Add("Masks",Serializers.serialize_ListArrayint16(_Masks)); }

				_anprEngineConfiguration_Config.Add(new JProperty("Type", _Type));


				_anprEngineConfiguration_Config.Add(new JProperty("TriggerMode", _TriggerMode));

				if(_TriggerModes != null)
				{ _anprEngineConfiguration_Config.Add("TriggerModes",Serializers.serialize_Liststring(_TriggerModes)); }

				_anprEngineConfiguration_Config.Add(new JProperty("ColorRecognition", _ColorRecognition));


				_anprEngineConfiguration_Config.Add(new JProperty("InterruptOnRecognition", _InterruptOnRecognition));


				_anprEngineConfiguration_Config.Add(new JProperty("ValidInTimeWindow", _ValidInTimeWindow));


				_anprEngineConfiguration_Config.Add(new JProperty("Confidence", _Confidence));


				_anprEngineConfiguration_Config.Add(new JProperty("CountryPreference", _CountryPreference));


				_anprEngineConfiguration_Config.Add(new JProperty("RecognitionMode", _RecognitionMode));

				if(_HardwareTriggerSettings != null)
				{ _anprEngineConfiguration_Config.Add(new JProperty("HardwareTriggerSettings", _HardwareTriggerSettings.serialize())); }

				if(_SoftwareTriggerSettings != null)
				{ _anprEngineConfiguration_Config.Add(new JProperty("SoftwareTriggerSettings", _SoftwareTriggerSettings.serialize())); }


				_anprEngineConfiguration_Config.Add(new JProperty("MMR", _MMR));


				_anprEngineConfiguration_Config.Add(new JProperty("Direction", _Direction));

				return _anprEngineConfiguration_Config;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Masks = (JObject?)data["Masks"];
				if(data_Masks != null)
				{ _Masks = Deserializers.deserialize_ListArrayint16(data_Masks); }
				else
				{ success = false; }

				var data_Type = data["Type"];
				if(data_Type != null)
				{ _Type = Convert.ToString(data_Type); }
				else
				{ success = false; }

				var data_TriggerMode = data["TriggerMode"];
				if(data_TriggerMode != null)
				{ _TriggerMode = Convert.ToString(data_TriggerMode); }
				else
				{ success = false; }

				var data_TriggerModes = (JObject?)data["TriggerModes"];
				if(data_TriggerModes != null)
				{ _TriggerModes = Deserializers.deserialize_Liststring(data_TriggerModes); }
				else
				{ success = false; }

				var data_ColorRecognition = data["ColorRecognition"];
				if(data_ColorRecognition != null)
				{ _ColorRecognition = Convert.ToBoolean(data_ColorRecognition); }
				else
				{ success = false; }

				var data_InterruptOnRecognition = data["InterruptOnRecognition"];
				if(data_InterruptOnRecognition != null)
				{ _InterruptOnRecognition = Convert.ToBoolean(data_InterruptOnRecognition); }
				else
				{ success = false; }

				var data_ValidInTimeWindow = data["ValidInTimeWindow"];
				if(data_ValidInTimeWindow != null)
				{ _ValidInTimeWindow = Convert.ToInt32(data_ValidInTimeWindow); }
				else
				{ success = false; }

				var data_Confidence = data["Confidence"];
				if(data_Confidence != null)
				{ _Confidence = Convert.ToSByte(data_Confidence); }
				else
				{ success = false; }

				var data_CountryPreference = data["CountryPreference"];
				if(data_CountryPreference != null)
				{ _CountryPreference = Convert.ToString(data_CountryPreference); }
				else
				{ success = false; }

				var data_RecognitionMode = data["RecognitionMode"];
				if(data_RecognitionMode != null)
				{ _RecognitionMode = Convert.ToString(data_RecognitionMode); }
				else
				{ success = false; }

				_HardwareTriggerSettings = new HardwareTriggerSettings();
				var data_HardwareTriggerSettings = (JObject?)data["HardwareTriggerSettings"];
				if(data_HardwareTriggerSettings != null)
				{ success = success && _HardwareTriggerSettings.deserialize(data_HardwareTriggerSettings); }

				_SoftwareTriggerSettings = new SoftwareTriggerSettings();
				var data_SoftwareTriggerSettings = (JObject?)data["SoftwareTriggerSettings"];
				if(data_SoftwareTriggerSettings != null)
				{ success = success && _SoftwareTriggerSettings.deserialize(data_SoftwareTriggerSettings); }

				var data_MMR = data["MMR"];
				if(data_MMR != null)
				{ _MMR = Convert.ToBoolean(data_MMR); }
				else
				{ success = false; }

				var data_Direction = data["Direction"];
				if(data_Direction != null)
				{ _Direction = Convert.ToBoolean(data_Direction); }
				else
				{ success = false; }


				return success;
			}
		}

		public class AnprEngineState_Config : AJsonSerializable
		{
			public bool _Configured;
			public bool _Active;
			public string? _Version;

			public override JObject? serialize()
			{
				JObject _anprEngineState_Config = new JObject();


				_anprEngineState_Config.Add(new JProperty("Configured", _Configured));


				_anprEngineState_Config.Add(new JProperty("Active", _Active));


				_anprEngineState_Config.Add(new JProperty("Version", _Version));

				return _anprEngineState_Config;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Configured = data["Configured"];
				if(data_Configured != null)
				{ _Configured = Convert.ToBoolean(data_Configured); }
				else
				{ success = false; }

				var data_Active = data["Active"];
				if(data_Active != null)
				{ _Active = Convert.ToBoolean(data_Active); }
				else
				{ success = false; }

				var data_Version = data["Version"];
				if(data_Version != null)
				{ _Version = Convert.ToString(data_Version); }
				else
				{ success = false; }


				return success;
			}
		}

		public class HardwareTriggerSettings : AJsonSerializable
		{
			public bool _InterruptOnRecognition;
			public string? _TriggerMode;
			public int _ReadCount;
			public string? _Port;

			public override JObject? serialize()
			{
				JObject _hardwareTriggerSettings = new JObject();


				_hardwareTriggerSettings.Add(new JProperty("InterruptOnRecognition", _InterruptOnRecognition));


				_hardwareTriggerSettings.Add(new JProperty("TriggerMode", _TriggerMode));


				_hardwareTriggerSettings.Add(new JProperty("ReadCount", _ReadCount));


				_hardwareTriggerSettings.Add(new JProperty("Port", _Port));

				return _hardwareTriggerSettings;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_InterruptOnRecognition = data["InterruptOnRecognition"];
				if(data_InterruptOnRecognition != null)
				{ _InterruptOnRecognition = Convert.ToBoolean(data_InterruptOnRecognition); }
				else
				{ success = false; }

				var data_TriggerMode = data["TriggerMode"];
				if(data_TriggerMode != null)
				{ _TriggerMode = Convert.ToString(data_TriggerMode); }
				else
				{ success = false; }

				var data_ReadCount = data["ReadCount"];
				if(data_ReadCount != null)
				{ _ReadCount = Convert.ToInt32(data_ReadCount); }
				else
				{ success = false; }

				var data_Port = data["Port"];
				if(data_Port != null)
				{ _Port = Convert.ToString(data_Port); }
				else
				{ success = false; }


				return success;
			}
		}

		public class SoftwareTriggerSettings : AJsonSerializable
		{
			public bool _InterruptOnRecognition;

			public override JObject? serialize()
			{
				JObject _softwareTriggerSettings = new JObject();


				_softwareTriggerSettings.Add(new JProperty("InterruptOnRecognition", _InterruptOnRecognition));

				return _softwareTriggerSettings;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_InterruptOnRecognition = data["InterruptOnRecognition"];
				if(data_InterruptOnRecognition != null)
				{ _InterruptOnRecognition = Convert.ToBoolean(data_InterruptOnRecognition); }
				else
				{ success = false; }


				return success;
			}
		}

		public class AnalyticsEngineTrigger_TriggerSource : AJsonSerializable
		{
			public string? _Name;

			public override JObject? serialize()
			{
				JObject _analyticsEngineTrigger_TriggerSource = new JObject();


				_analyticsEngineTrigger_TriggerSource.Add(new JProperty("Name", _Name));

				return _analyticsEngineTrigger_TriggerSource;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Name = data["Name"];
				if(data_Name != null)
				{ _Name = Convert.ToString(data_Name); }
				else
				{ success = false; }


				return success;
			}
		}

		public class EventANPRLicensePlate_TriggerSource : AJsonSerializable
		{
			public string? _Source;
			public string? _Name;
			public DateTime _Timestamp;

			public override JObject? serialize()
			{
				JObject _eventANPRLicensePlate_TriggerSource = new JObject();


				_eventANPRLicensePlate_TriggerSource.Add(new JProperty("Source", _Source));


				_eventANPRLicensePlate_TriggerSource.Add(new JProperty("Name", _Name));


				_eventANPRLicensePlate_TriggerSource.Add(new JProperty("Timestamp", DateTimeConverter.convertToTimeStamp(_Timestamp)));

				return _eventANPRLicensePlate_TriggerSource;
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

		public class StorageEventsRequestFilter : AJsonSerializable
		{
			public string? _Pattern;
			public string? _Params;
			public bool _FuzzySearch;

			public override JObject? serialize()
			{
				JObject _storageEventsRequestFilter = new JObject();


				_storageEventsRequestFilter.Add(new JProperty("Pattern", _Pattern));


				_storageEventsRequestFilter.Add(new JProperty("Params", _Params));


				_storageEventsRequestFilter.Add(new JProperty("FuzzySearch", _FuzzySearch));

				return _storageEventsRequestFilter;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Pattern = data["Pattern"];
				if(data_Pattern != null)
				{ _Pattern = Convert.ToString(data_Pattern); }
				else
				{ success = false; }

				var data_Params = data["Params"];
				if(data_Params != null)
				{ _Params = Convert.ToString(data_Params); }
				else
				{ success = false; }

				var data_FuzzySearch = data["FuzzySearch"];
				if(data_FuzzySearch != null)
				{ _FuzzySearch = Convert.ToBoolean(data_FuzzySearch); }
				else
				{ success = false; }


				return success;
			}
		}

		public class SystemSettingsDevice : AJsonSerializable
		{
			public string? _ProductName;
			public string? _ProductDisplayName;
			public string? _ProductClass;
			public string? _ProductSubclass;
			public string? _FirmwareVersion;
			public string? _RequiredFirmwareVersion;
			public string? _Serial;
			public string? _Description;

			public override JObject? serialize()
			{
				JObject _systemSettingsDevice = new JObject();


				_systemSettingsDevice.Add(new JProperty("ProductName", _ProductName));


				_systemSettingsDevice.Add(new JProperty("ProductDisplayName", _ProductDisplayName));


				_systemSettingsDevice.Add(new JProperty("ProductClass", _ProductClass));


				_systemSettingsDevice.Add(new JProperty("ProductSubclass", _ProductSubclass));


				_systemSettingsDevice.Add(new JProperty("FirmwareVersion", _FirmwareVersion));


				_systemSettingsDevice.Add(new JProperty("RequiredFirmwareVersion", _RequiredFirmwareVersion));


				_systemSettingsDevice.Add(new JProperty("Serial", _Serial));


				_systemSettingsDevice.Add(new JProperty("Description", _Description));

				return _systemSettingsDevice;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_ProductName = data["ProductName"];
				if(data_ProductName != null)
				{ _ProductName = Convert.ToString(data_ProductName); }
				else
				{ success = false; }

				var data_ProductDisplayName = data["ProductDisplayName"];
				if(data_ProductDisplayName != null)
				{ _ProductDisplayName = Convert.ToString(data_ProductDisplayName); }
				else
				{ success = false; }

				var data_ProductClass = data["ProductClass"];
				if(data_ProductClass != null)
				{ _ProductClass = Convert.ToString(data_ProductClass); }
				else
				{ success = false; }

				var data_ProductSubclass = data["ProductSubclass"];
				if(data_ProductSubclass != null)
				{ _ProductSubclass = Convert.ToString(data_ProductSubclass); }
				else
				{ success = false; }

				var data_FirmwareVersion = data["FirmwareVersion"];
				if(data_FirmwareVersion != null)
				{ _FirmwareVersion = Convert.ToString(data_FirmwareVersion); }
				else
				{ success = false; }

				var data_RequiredFirmwareVersion = data["RequiredFirmwareVersion"];
				if(data_RequiredFirmwareVersion != null)
				{ _RequiredFirmwareVersion = Convert.ToString(data_RequiredFirmwareVersion); }
				else
				{ success = false; }

				var data_Serial = data["Serial"];
				if(data_Serial != null)
				{ _Serial = Convert.ToString(data_Serial); }
				else
				{ success = false; }

				var data_Description = data["Description"];
				if(data_Description != null)
				{ _Description = Convert.ToString(data_Description); }
				else
				{ success = false; }


				return success;
			}
		}

		public class SystemSettingsModule : AJsonSerializable
		{
			public JObject? _Data;

			public override JObject? serialize()
			{
				JObject _systemSettingsModule = new JObject();


				_systemSettingsModule.Add(new JProperty("Data", _Data));

				return _systemSettingsModule;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_Data = data;

				return success;
			}
		}

		public class LocationSettings : AJsonSerializable
		{
			public GPSSettings? _GPS;

			public override JObject? serialize()
			{
				JObject _locationSettings = new JObject();

				if(_GPS != null)
				{ _locationSettings.Add(new JProperty("GPS", _GPS.serialize())); }

				return _locationSettings;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_GPS = new GPSSettings();
				var data_GPS = (JObject?)data["GPS"];
				if(data_GPS != null)
				{ success = success && _GPS.deserialize(data_GPS); }


				return success;
			}
		}

		public class GPSSettings : AJsonSerializable
		{
			public double _Latitude;
			public double _Longitude;

			public override JObject? serialize()
			{
				JObject _gPSSettings = new JObject();


				_gPSSettings.Add(new JProperty("Latitude", _Latitude));


				_gPSSettings.Add(new JProperty("Longitude", _Longitude));

				return _gPSSettings;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Latitude = data["Latitude"];
				if(data_Latitude != null)
				{ _Latitude = Convert.ToDouble(data_Latitude); }
				else
				{ success = false; }

				var data_Longitude = data["Longitude"];
				if(data_Longitude != null)
				{ _Longitude = Convert.ToDouble(data_Longitude); }
				else
				{ success = false; }


				return success;
			}
		}

		public class GpioPort : GpioPortId
		{
			public bool _ActiveState;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("ActiveState", _ActiveState));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_ActiveState = data["ActiveState"];
				if(data_ActiveState != null)
				{ _ActiveState = Convert.ToBoolean(data_ActiveState); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class GpioPortState : GpioPortId
		{
			public bool _Active;
			public DateTime _Timestamp;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Active", _Active));


					base_jobj.Add(new JProperty("Timestamp", DateTimeConverter.convertToTimeStamp(_Timestamp)));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Active = data["Active"];
				if(data_Active != null)
				{ _Active = Convert.ToBoolean(data_Active); }
				else
				{ success = false; }

				var data_Timestamp = data["Timestamp"];
				if(data_Timestamp != null)
				{ _Timestamp = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_Timestamp)); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class GpioPortStateChange : GpioPortState
		{
			public string? _Type;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Type", _Type));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Type = data["Type"];
				if(data_Type != null)
				{ _Type = Convert.ToString(data_Type); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class ActiveSession : AJsonSerializable
		{
			public string? _User;
			public string? _Source;
			public long _LastSeen;

			public override JObject? serialize()
			{
				JObject _activeSession = new JObject();


				_activeSession.Add(new JProperty("User", _User));


				_activeSession.Add(new JProperty("Source", _Source));


				_activeSession.Add(new JProperty("LastSeen", _LastSeen));

				return _activeSession;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_User = data["User"];
				if(data_User != null)
				{ _User = Convert.ToString(data_User); }
				else
				{ success = false; }

				var data_Source = data["Source"];
				if(data_Source != null)
				{ _Source = Convert.ToString(data_Source); }
				else
				{ success = false; }

				var data_LastSeen = data["LastSeen"];
				if(data_LastSeen != null)
				{ _LastSeen = Convert.ToInt64(data_LastSeen); }
				else
				{ success = false; }


				return success;
			}
		}

		public class DetectorConfiguration : AJsonSerializable
		{
			public string? _Class;
			public int _Version;
			public int _DetectorClassID;
			public bool _BuiltIn;
			public string? _DetectorID;
			public string? _DisplayName;
			public string? _Description;
			public TimeSpan _ViolationTimeMs;
			public long _RestoreDelayMs;
			public double _FpsLimit;
			public bool _Enabled;

			public override JObject? serialize()
			{
				JObject _detectorConfiguration = new JObject();


				_detectorConfiguration.Add(new JProperty("Class", _Class));


				_detectorConfiguration.Add(new JProperty("Version", _Version));


				_detectorConfiguration.Add(new JProperty("DetectorClassID", _DetectorClassID));


				_detectorConfiguration.Add(new JProperty("BuiltIn", _BuiltIn));


				_detectorConfiguration.Add(new JProperty("DetectorID", _DetectorID));


				_detectorConfiguration.Add(new JProperty("DisplayName", _DisplayName));


				_detectorConfiguration.Add(new JProperty("Description", _Description));


				_detectorConfiguration.Add(new JProperty("ViolationTimeMs", DateTimeConverter.convertToTimeStamp(_ViolationTimeMs)));


				_detectorConfiguration.Add(new JProperty("RestoreDelayMs", _RestoreDelayMs));


				_detectorConfiguration.Add(new JProperty("FpsLimit", _FpsLimit));


				_detectorConfiguration.Add(new JProperty("Enabled", _Enabled));

				return _detectorConfiguration;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Class = data["Class"];
				if(data_Class != null)
				{ _Class = Convert.ToString(data_Class); }
				else
				{ success = false; }

				var data_Version = data["Version"];
				if(data_Version != null)
				{ _Version = Convert.ToInt32(data_Version); }
				else
				{ success = false; }

				var data_DetectorClassID = data["DetectorClassID"];
				if(data_DetectorClassID != null)
				{ _DetectorClassID = Convert.ToInt32(data_DetectorClassID); }
				else
				{ success = false; }

				var data_BuiltIn = data["BuiltIn"];
				if(data_BuiltIn != null)
				{ _BuiltIn = Convert.ToBoolean(data_BuiltIn); }
				else
				{ success = false; }

				var data_DetectorID = data["DetectorID"];
				if(data_DetectorID != null)
				{ _DetectorID = Convert.ToString(data_DetectorID); }
				else
				{ success = false; }

				var data_DisplayName = data["DisplayName"];
				if(data_DisplayName != null)
				{ _DisplayName = Convert.ToString(data_DisplayName); }
				else
				{ success = false; }

				var data_Description = data["Description"];
				if(data_Description != null)
				{ _Description = Convert.ToString(data_Description); }
				else
				{ success = false; }

				var data_ViolationTimeMs = data["ViolationTimeMs"];
				if(data_ViolationTimeMs != null)
				{ _ViolationTimeMs = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(data_ViolationTimeMs)); }
				else
				{ success = false; }

				var data_RestoreDelayMs = data["RestoreDelayMs"];
				if(data_RestoreDelayMs != null)
				{ _RestoreDelayMs = Convert.ToInt64(data_RestoreDelayMs); }
				else
				{ success = false; }

				var data_FpsLimit = data["FpsLimit"];
				if(data_FpsLimit != null)
				{ _FpsLimit = Convert.ToDouble(data_FpsLimit); }
				else
				{ success = false; }

				var data_Enabled = data["Enabled"];
				if(data_Enabled != null)
				{ _Enabled = Convert.ToBoolean(data_Enabled); }
				else
				{ success = false; }


				return success;
			}
		}

		public class DetectorConfigurationANPR : DetectorConfiguration
		{
			public bool _Whitelist;
			public string? _Filter;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Whitelist", _Whitelist));


					base_jobj.Add(new JProperty("Filter", _Filter));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Whitelist = data["Whitelist"];
				if(data_Whitelist != null)
				{ _Whitelist = Convert.ToBoolean(data_Whitelist); }
				else
				{ success = false; }

				var data_Filter = data["Filter"];
				if(data_Filter != null)
				{ _Filter = Convert.ToString(data_Filter); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationTest : DetectorConfiguration
		{
			public long _Interval;
			public DateTime _Timeout;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Interval", _Interval));


					base_jobj.Add(new JProperty("Timeout", DateTimeConverter.convertToTimeStamp(_Timeout)));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Interval = data["Interval"];
				if(data_Interval != null)
				{ _Interval = Convert.ToInt64(data_Interval); }
				else
				{ success = false; }

				var data_Timeout = data["Timeout"];
				if(data_Timeout != null)
				{ _Timeout = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_Timeout)); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationIO : DetectorConfiguration
		{
			public string? _InputPort;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("InputPort", _InputPort));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_InputPort = data["InputPort"];
				if(data_InputPort != null)
				{ _InputPort = Convert.ToString(data_InputPort); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class Event : AJsonSerializable
		{
			public int _DetectorVersion;
			public string? _DetectorID;
			public int _DetectorClassID;
			public DateTime _EventTime;
			public DateTime _EventTriggerTime;
			public string? _State;
			public int _EventCode;
			public string? _EventID;
			public string? _DetectorEventType;
			public DetectorConfiguration? _Config;
			public DetectorDeviceInfo? _Device;
			public JObject? _SourceData;

			public override JObject? serialize()
			{
				JObject _event = new JObject();


				_event.Add(new JProperty("DetectorVersion", _DetectorVersion));


				_event.Add(new JProperty("DetectorID", _DetectorID));


				_event.Add(new JProperty("DetectorClassID", _DetectorClassID));


				_event.Add(new JProperty("EventTime", DateTimeConverter.convertToTimeStamp(_EventTime)));


				_event.Add(new JProperty("EventTriggerTime", DateTimeConverter.convertToTimeStamp(_EventTriggerTime)));


				_event.Add(new JProperty("State", _State));


				_event.Add(new JProperty("EventCode", _EventCode));


				_event.Add(new JProperty("EventID", _EventID));


				_event.Add(new JProperty("DetectorEventType", _DetectorEventType));

				if(_Config != null)
				{ _event.Add(new JProperty("Config", _Config.serialize())); }

				if(_Device != null)
				{ _event.Add(new JProperty("Device", _Device.serialize())); }


				_event.Add(new JProperty("SourceData", _SourceData));

				return _event;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_DetectorVersion = data["DetectorVersion"];
				if(data_DetectorVersion != null)
				{ _DetectorVersion = Convert.ToInt32(data_DetectorVersion); }
				else
				{ success = false; }

				var data_DetectorID = data["DetectorID"];
				if(data_DetectorID != null)
				{ _DetectorID = Convert.ToString(data_DetectorID); }
				else
				{ success = false; }

				var data_DetectorClassID = data["DetectorClassID"];
				if(data_DetectorClassID != null)
				{ _DetectorClassID = Convert.ToInt32(data_DetectorClassID); }
				else
				{ success = false; }

				var data_EventTime = data["EventTime"];
				if(data_EventTime != null)
				{ _EventTime = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_EventTime)); }
				else
				{ success = false; }

				var data_EventTriggerTime = data["EventTriggerTime"];
				if(data_EventTriggerTime != null)
				{ _EventTriggerTime = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_EventTriggerTime)); }
				else
				{ success = false; }

				var data_State = data["State"];
				if(data_State != null)
				{ _State = Convert.ToString(data_State); }
				else
				{ success = false; }

				var data_EventCode = data["EventCode"];
				if(data_EventCode != null)
				{ _EventCode = Convert.ToInt32(data_EventCode); }
				else
				{ success = false; }

				var data_EventID = data["EventID"];
				if(data_EventID != null)
				{ _EventID = Convert.ToString(data_EventID); }
				else
				{ success = false; }

				var data_DetectorEventType = data["DetectorEventType"];
				if(data_DetectorEventType != null)
				{ _DetectorEventType = Convert.ToString(data_DetectorEventType); }
				else
				{ success = false; }

				_Config = new DetectorConfiguration();
				var data_Config = (JObject?)data["Config"];
				if(data_Config != null)
				{ success = success && _Config.deserialize(data_Config); }

				_Device = new DetectorDeviceInfo();
				var data_Device = (JObject?)data["Device"];
				if(data_Device != null)
				{ success = success && _Device.deserialize(data_Device); }

				_SourceData = data;

				return success;
			}
			public EventANPR? asEventANPR()
			{
				EventANPR obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorANPR") && (_SourceData != null))
				{
					obj = new EventANPR();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventIO? asEventIO()
			{
				EventIO obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorIO") && (_SourceData != null))
				{
					obj = new EventIO();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventTest? asEventTest()
			{
				EventTest obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorTest") && (_SourceData != null))
				{
					obj = new EventTest();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventEmergencyLane? asEventEmergencyLane()
			{
				EventEmergencyLane obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorEmergencyLane") && (_SourceData != null))
				{
					obj = new EventEmergencyLane();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventForbiddenZone? asEventForbiddenZone()
			{
				EventForbiddenZone obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorForbiddenZone") && (_SourceData != null))
				{
					obj = new EventForbiddenZone();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventLane? asEventLane()
			{
				EventLane obj = null;

				if((_Config != null) && (_Config._Class == "ALarmDetectorLane") && (_SourceData != null))
				{
					obj = new EventLane();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventRedStop? asEventRedStop()
			{
				EventRedStop obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorRedStop") && (_SourceData != null))
				{
					obj = new EventRedStop();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventStoppedObject? asEventStoppedObject()
			{
				EventStoppedObject obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorStoppedObject") && (_SourceData != null))
				{
					obj = new EventStoppedObject();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventStopViolation? asEventStopViolation()
			{
				EventStopViolation obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorStopViolation") && (_SourceData != null))
				{
					obj = new EventStopViolation();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventTrafficLine? asEventTrafficLine()
			{
				EventTrafficLine obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorTrafficLine") && (_SourceData != null))
				{
					obj = new EventTrafficLine();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventUTurn? asEventUTurn()
			{
				EventUTurn obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorUTurn") && (_SourceData != null))
				{
					obj = new EventUTurn();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventWhiteLineViolation? asEventWhiteLineViolation()
			{
				EventWhiteLineViolation obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorWhiteLineViolation") && (_SourceData != null))
				{
					obj = new EventWhiteLineViolation();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventWrongTurn? asEventWrongTurn()
			{
				EventWrongTurn obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorWrongTurn") && (_SourceData != null))
				{
					obj = new EventWrongTurn();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

			public EventWrongWay? asEventWrongWay()
			{
				EventWrongWay obj = null;

				if((_Config != null) && (_Config._Class == "AlarmDetectorWrongWay") && (_SourceData != null))
				{
					obj = new EventWrongWay();
					obj.deserialize(_SourceData);
				}

				return obj;
			}

		}

		public class DetectorDeviceInfo : AJsonSerializable
		{
			public string? _Name;
			public string? _Description;
			public string? _Serial;
			public LocationSettings? _Location;

			public override JObject? serialize()
			{
				JObject _detectorDeviceInfo = new JObject();


				_detectorDeviceInfo.Add(new JProperty("Name", _Name));


				_detectorDeviceInfo.Add(new JProperty("Description", _Description));


				_detectorDeviceInfo.Add(new JProperty("Serial", _Serial));

				if(_Location != null)
				{ _detectorDeviceInfo.Add(new JProperty("Location", _Location.serialize())); }

				return _detectorDeviceInfo;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Name = data["Name"];
				if(data_Name != null)
				{ _Name = Convert.ToString(data_Name); }
				else
				{ success = false; }

				var data_Description = data["Description"];
				if(data_Description != null)
				{ _Description = Convert.ToString(data_Description); }
				else
				{ success = false; }

				var data_Serial = data["Serial"];
				if(data_Serial != null)
				{ _Serial = Convert.ToString(data_Serial); }
				else
				{ success = false; }

				_Location = new LocationSettings();
				var data_Location = (JObject?)data["Location"];
				if(data_Location != null)
				{ success = success && _Location.deserialize(data_Location); }


				return success;
			}
		}

		public class EventANPR : Event
		{
			public EventANPRLicensePlate? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new EventANPRLicensePlate();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class MMR : AJsonSerializable
		{
			public string? _Category;
			public string? _Make;
			public string? _Model;
			public string? _Color;
			public double _CategoryConfidence;
			public double _MakeAndModelConfidence;
			public double _ColorConfidence;

			public override JObject? serialize()
			{
				JObject _mMR = new JObject();


				_mMR.Add(new JProperty("Category", _Category));


				_mMR.Add(new JProperty("Make", _Make));


				_mMR.Add(new JProperty("Model", _Model));


				_mMR.Add(new JProperty("Color", _Color));


				_mMR.Add(new JProperty("CategoryConfidence", _CategoryConfidence));


				_mMR.Add(new JProperty("MakeAndModelConfidence", _MakeAndModelConfidence));


				_mMR.Add(new JProperty("ColorConfidence", _ColorConfidence));

				return _mMR;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Category = data["Category"];
				if(data_Category != null)
				{ _Category = Convert.ToString(data_Category); }
				else
				{ success = false; }

				var data_Make = data["Make"];
				if(data_Make != null)
				{ _Make = Convert.ToString(data_Make); }
				else
				{ success = false; }

				var data_Model = data["Model"];
				if(data_Model != null)
				{ _Model = Convert.ToString(data_Model); }
				else
				{ success = false; }

				var data_Color = data["Color"];
				if(data_Color != null)
				{ _Color = Convert.ToString(data_Color); }
				else
				{ success = false; }

				var data_CategoryConfidence = data["CategoryConfidence"];
				if(data_CategoryConfidence != null)
				{ _CategoryConfidence = Convert.ToDouble(data_CategoryConfidence); }
				else
				{ success = false; }

				var data_MakeAndModelConfidence = data["MakeAndModelConfidence"];
				if(data_MakeAndModelConfidence != null)
				{ _MakeAndModelConfidence = Convert.ToDouble(data_MakeAndModelConfidence); }
				else
				{ success = false; }

				var data_ColorConfidence = data["ColorConfidence"];
				if(data_ColorConfidence != null)
				{ _ColorConfidence = Convert.ToDouble(data_ColorConfidence); }
				else
				{ success = false; }


				return success;
			}
		}

		public class EventANPRLicensePlate : AJsonSerializable
		{
			public string? _Text;
			public double _Confidence;
			public string? _Country;
			public int _CountryCode;
			public short[]? _Coords;
			public EventANPRLicensePlate_TriggerSource? _TriggerSource;
			public string? _BackgroundColor;
			public string? _DedicatedAreaColor;
			public string? _TextColor;
			public int _CharacterSize;
			public string? _Direction;
			public MMR? _MMR;

			public override JObject? serialize()
			{
				JObject _eventANPRLicensePlate = new JObject();


				_eventANPRLicensePlate.Add(new JProperty("Text", _Text));


				_eventANPRLicensePlate.Add(new JProperty("Confidence", _Confidence));


				_eventANPRLicensePlate.Add(new JProperty("Country", _Country));


				_eventANPRLicensePlate.Add(new JProperty("CountryCode", _CountryCode));

				if(_Coords != null)
				{ _eventANPRLicensePlate.Add("Coords",Serializers.serialize_Arrayint16(_Coords)); }
				if(_TriggerSource != null)
				{ _eventANPRLicensePlate.Add(new JProperty("TriggerSource", _TriggerSource.serialize())); }


				_eventANPRLicensePlate.Add(new JProperty("BackgroundColor", _BackgroundColor));


				_eventANPRLicensePlate.Add(new JProperty("DedicatedAreaColor", _DedicatedAreaColor));


				_eventANPRLicensePlate.Add(new JProperty("TextColor", _TextColor));


				_eventANPRLicensePlate.Add(new JProperty("CharacterSize", _CharacterSize));


				_eventANPRLicensePlate.Add(new JProperty("Direction", _Direction));

				if(_MMR != null)
				{ _eventANPRLicensePlate.Add(new JProperty("MMR", _MMR.serialize())); }

				return _eventANPRLicensePlate;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Text = data["Text"];
				if(data_Text != null)
				{ _Text = Convert.ToString(data_Text); }
				else
				{ success = false; }

				var data_Confidence = data["Confidence"];
				if(data_Confidence != null)
				{ _Confidence = Convert.ToDouble(data_Confidence); }
				else
				{ success = false; }

				var data_Country = data["Country"];
				if(data_Country != null)
				{ _Country = Convert.ToString(data_Country); }
				else
				{ success = false; }

				var data_CountryCode = data["CountryCode"];
				if(data_CountryCode != null)
				{ _CountryCode = Convert.ToInt32(data_CountryCode); }
				else
				{ success = false; }

				var data_Coords = (JArray?)data["Coords"];
				if(data_Coords != null)
				{ _Coords = Deserializers.deserialize_Arrayint16(data_Coords); }
				else
				{ success = false; }

				_TriggerSource = new EventANPRLicensePlate_TriggerSource();
				var data_TriggerSource = (JObject?)data["TriggerSource"];
				if(data_TriggerSource != null)
				{ success = success && _TriggerSource.deserialize(data_TriggerSource); }

				var data_BackgroundColor = data["BackgroundColor"];
				if(data_BackgroundColor != null)
				{ _BackgroundColor = Convert.ToString(data_BackgroundColor); }
				else
				{ success = false; }

				var data_DedicatedAreaColor = data["DedicatedAreaColor"];
				if(data_DedicatedAreaColor != null)
				{ _DedicatedAreaColor = Convert.ToString(data_DedicatedAreaColor); }
				else
				{ success = false; }

				var data_TextColor = data["TextColor"];
				if(data_TextColor != null)
				{ _TextColor = Convert.ToString(data_TextColor); }
				else
				{ success = false; }

				var data_CharacterSize = data["CharacterSize"];
				if(data_CharacterSize != null)
				{ _CharacterSize = Convert.ToInt32(data_CharacterSize); }
				else
				{ success = false; }

				var data_Direction = data["Direction"];
				if(data_Direction != null)
				{ _Direction = Convert.ToString(data_Direction); }
				else
				{ success = false; }

				_MMR = new MMR();
				var data_MMR = (JObject?)data["MMR"];
				if(data_MMR != null)
				{ success = success && _MMR.deserialize(data_MMR); }


				return success;
			}
		}

		public class EventIO : Event
		{

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{


				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				base.deserialize(data);

				return success;
			}
		}

		public class EventTest : Event
		{
			public long _Index;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Index", _Index));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Index = data["Index"];
				if(data_Index != null)
				{ _Index = Convert.ToInt64(data_Index); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class GeometryLineSegment : AJsonSerializable
		{
			public int _X0;
			public int _Y0;
			public int _X1;
			public int _Y1;

			public override JObject? serialize()
			{
				JObject _geometryLineSegment = new JObject();


				_geometryLineSegment.Add(new JProperty("X0", _X0));


				_geometryLineSegment.Add(new JProperty("Y0", _Y0));


				_geometryLineSegment.Add(new JProperty("X1", _X1));


				_geometryLineSegment.Add(new JProperty("Y1", _Y1));

				return _geometryLineSegment;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_X0 = data["X0"];
				if(data_X0 != null)
				{ _X0 = Convert.ToInt32(data_X0); }
				else
				{ success = false; }

				var data_Y0 = data["Y0"];
				if(data_Y0 != null)
				{ _Y0 = Convert.ToInt32(data_Y0); }
				else
				{ success = false; }

				var data_X1 = data["X1"];
				if(data_X1 != null)
				{ _X1 = Convert.ToInt32(data_X1); }
				else
				{ success = false; }

				var data_Y1 = data["Y1"];
				if(data_Y1 != null)
				{ _Y1 = Convert.ToInt32(data_Y1); }
				else
				{ success = false; }


				return success;
			}
		}

		public class GeometryLine : AJsonSerializable
		{
			public List<GeometryLineSegment>? _Lines;

			public override JObject? serialize()
			{
				JObject _geometryLine = new JObject();

				if(_Lines != null)
				{ _geometryLine.Add("Lines",Serializers.serialize_ListGeometryLineSegment(_Lines)); }

				return _geometryLine;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Lines = (JObject?)data["Lines"];
				if(data_Lines != null)
				{ _Lines = Deserializers.deserialize_ListGeometryLineSegment(data_Lines); }
				else
				{ success = false; }


				return success;
			}
		}

		public class GeometryLineGroup : AJsonSerializable
		{
			public List<GeometryLineSegment>? _Lines;
			public int _SequenceNumber;

			public override JObject? serialize()
			{
				JObject _geometryLineGroup = new JObject();

				if(_Lines != null)
				{ _geometryLineGroup.Add("Lines",Serializers.serialize_ListGeometryLineSegment(_Lines)); }

				_geometryLineGroup.Add(new JProperty("SequenceNumber", _SequenceNumber));

				return _geometryLineGroup;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Lines = (JObject?)data["Lines"];
				if(data_Lines != null)
				{ _Lines = Deserializers.deserialize_ListGeometryLineSegment(data_Lines); }
				else
				{ success = false; }

				var data_SequenceNumber = data["SequenceNumber"];
				if(data_SequenceNumber != null)
				{ _SequenceNumber = Convert.ToInt32(data_SequenceNumber); }
				else
				{ success = false; }


				return success;
			}
		}

		public class GeometryLineGroups : AJsonSerializable
		{
			public List<GeometryLineGroup>? _LineGroups;

			public override JObject? serialize()
			{
				JObject _geometryLineGroups = new JObject();

				if(_LineGroups != null)
				{ _geometryLineGroups.Add("LineGroups",Serializers.serialize_ListGeometryLineGroup(_LineGroups)); }

				return _geometryLineGroups;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_LineGroups = (JObject?)data["LineGroups"];
				if(data_LineGroups != null)
				{ _LineGroups = Deserializers.deserialize_ListGeometryLineGroup(data_LineGroups); }
				else
				{ success = false; }


				return success;
			}
		}

		public class GeometryRectangle : AJsonSerializable
		{
			public int _X0;
			public int _Y0;
			public int _X1;
			public int _Y1;

			public override JObject? serialize()
			{
				JObject _geometryRectangle = new JObject();


				_geometryRectangle.Add(new JProperty("X0", _X0));


				_geometryRectangle.Add(new JProperty("Y0", _Y0));


				_geometryRectangle.Add(new JProperty("X1", _X1));


				_geometryRectangle.Add(new JProperty("Y1", _Y1));

				return _geometryRectangle;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_X0 = data["X0"];
				if(data_X0 != null)
				{ _X0 = Convert.ToInt32(data_X0); }
				else
				{ success = false; }

				var data_Y0 = data["Y0"];
				if(data_Y0 != null)
				{ _Y0 = Convert.ToInt32(data_Y0); }
				else
				{ success = false; }

				var data_X1 = data["X1"];
				if(data_X1 != null)
				{ _X1 = Convert.ToInt32(data_X1); }
				else
				{ success = false; }

				var data_Y1 = data["Y1"];
				if(data_Y1 != null)
				{ _Y1 = Convert.ToInt32(data_Y1); }
				else
				{ success = false; }


				return success;
			}
		}

		public class GeometryPolygons : AJsonSerializable
		{
			public List<short[]>? _Masks;

			public override JObject? serialize()
			{
				JObject _geometryPolygons = new JObject();

				if(_Masks != null)
				{ _geometryPolygons.Add("Masks",Serializers.serialize_ListArrayint16(_Masks)); }

				return _geometryPolygons;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Masks = (JObject?)data["Masks"];
				if(data_Masks != null)
				{ _Masks = Deserializers.deserialize_ListArrayint16(data_Masks); }
				else
				{ success = false; }


				return success;
			}
		}

		public class ModuleIO : SystemSettingsModule
		{
			public List<string>? _Inputs;
			public List<string>? _Outputs;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Inputs != null)
					{ base_jobj.Add("Inputs",Serializers.serialize_Liststring(_Inputs)); }
					if(_Outputs != null)
					{ base_jobj.Add("Outputs",Serializers.serialize_Liststring(_Outputs)); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Inputs = (JObject?)data["Inputs"];
				if(data_Inputs != null)
				{ _Inputs = Deserializers.deserialize_Liststring(data_Inputs); }
				else
				{ success = false; }

				var data_Outputs = (JObject?)data["Outputs"];
				if(data_Outputs != null)
				{ _Outputs = Deserializers.deserialize_Liststring(data_Outputs); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class ModuleAnalytics : SystemSettingsModule
		{
			public string? _RequiredCarmenVersion;
			public List<string>? _Features;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("RequiredCarmenVersion", _RequiredCarmenVersion));

					if(_Features != null)
					{ base_jobj.Add("Features",Serializers.serialize_Liststring(_Features)); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_RequiredCarmenVersion = data["RequiredCarmenVersion"];
				if(data_RequiredCarmenVersion != null)
				{ _RequiredCarmenVersion = Convert.ToString(data_RequiredCarmenVersion); }
				else
				{ success = false; }

				var data_Features = (JObject?)data["Features"];
				if(data_Features != null)
				{ _Features = Deserializers.deserialize_Liststring(data_Features); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class ModuleMedia : SystemSettingsModule
		{
			public int _Sensors;
			public int _Streams;
			public Dictionary<string, List<string>>? _Features;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Sensors", _Sensors));


					base_jobj.Add(new JProperty("Streams", _Streams));

					if(_Features != null)
					{ base_jobj.Add("Features",Serializers.serialize_MapListstring(_Features)); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Sensors = data["Sensors"];
				if(data_Sensors != null)
				{ _Sensors = Convert.ToInt32(data_Sensors); }
				else
				{ success = false; }

				var data_Streams = data["Streams"];
				if(data_Streams != null)
				{ _Streams = Convert.ToInt32(data_Streams); }
				else
				{ success = false; }

				var data_Features = (JObject?)data["Features"];
				if(data_Features != null)
				{ _Features = Deserializers.deserialize_MapListstring(data_Features); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class OptionNumericRange : AJsonSerializable
		{
			public double _Default;
			public double _Minimum;
			public double _Maximum;

			public override JObject? serialize()
			{
				JObject _optionNumericRange = new JObject();


				_optionNumericRange.Add(new JProperty("Default", _Default));


				_optionNumericRange.Add(new JProperty("Minimum", _Minimum));


				_optionNumericRange.Add(new JProperty("Maximum", _Maximum));

				return _optionNumericRange;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Default = data["Default"];
				if(data_Default != null)
				{ _Default = Convert.ToDouble(data_Default); }
				else
				{ success = false; }

				var data_Minimum = data["Minimum"];
				if(data_Minimum != null)
				{ _Minimum = Convert.ToDouble(data_Minimum); }
				else
				{ success = false; }

				var data_Maximum = data["Maximum"];
				if(data_Maximum != null)
				{ _Maximum = Convert.ToDouble(data_Maximum); }
				else
				{ success = false; }


				return success;
			}
		}

		public class OptionValueList : AJsonSerializable
		{
			public string? _Default;
			public List<string>? _Values;

			public override JObject? serialize()
			{
				JObject _optionValueList = new JObject();


				_optionValueList.Add(new JProperty("Default", _Default));

				if(_Values != null)
				{ _optionValueList.Add("Values",Serializers.serialize_Liststring(_Values)); }

				return _optionValueList;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Default = data["Default"];
				if(data_Default != null)
				{ _Default = Convert.ToString(data_Default); }
				else
				{ success = false; }

				var data_Values = (JObject?)data["Values"];
				if(data_Values != null)
				{ _Values = Deserializers.deserialize_Liststring(data_Values); }
				else
				{ success = false; }


				return success;
			}
		}

		public class TrackingDetectorConfiguration : DetectorConfiguration
		{
			public List<string>? _ObjectTypes;
			public bool _Center;
			public bool _ConfidenceEnabled;
			public sbyte _Confidence;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_ObjectTypes != null)
					{ base_jobj.Add("ObjectTypes",Serializers.serialize_Liststring(_ObjectTypes)); }

					base_jobj.Add(new JProperty("Center", _Center));


					base_jobj.Add(new JProperty("ConfidenceEnabled", _ConfidenceEnabled));


					base_jobj.Add(new JProperty("Confidence", _Confidence));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_ObjectTypes = (JObject?)data["ObjectTypes"];
				if(data_ObjectTypes != null)
				{ _ObjectTypes = Deserializers.deserialize_Liststring(data_ObjectTypes); }
				else
				{ success = false; }

				var data_Center = data["Center"];
				if(data_Center != null)
				{ _Center = Convert.ToBoolean(data_Center); }
				else
				{ success = false; }

				var data_ConfidenceEnabled = data["ConfidenceEnabled"];
				if(data_ConfidenceEnabled != null)
				{ _ConfidenceEnabled = Convert.ToBoolean(data_ConfidenceEnabled); }
				else
				{ success = false; }

				var data_Confidence = data["Confidence"];
				if(data_Confidence != null)
				{ _Confidence = Convert.ToSByte(data_Confidence); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class IndexedTrackingDetectorLines : GeometryLineSegment
		{
			public sbyte _Id;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Id", _Id));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Id = data["Id"];
				if(data_Id != null)
				{ _Id = Convert.ToSByte(data_Id); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationEmergencyLane : TrackingDetectorConfiguration
		{
			public List<short[]>? _Masks;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Masks != null)
					{ base_jobj.Add("Masks",Serializers.serialize_ListArrayint16(_Masks)); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Masks = (JObject?)data["Masks"];
				if(data_Masks != null)
				{ _Masks = Deserializers.deserialize_ListArrayint16(data_Masks); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationForbiddenZone : TrackingDetectorConfiguration
		{
			public List<short[]>? _Masks;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Masks != null)
					{ base_jobj.Add("Masks",Serializers.serialize_ListArrayint16(_Masks)); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Masks = (JObject?)data["Masks"];
				if(data_Masks != null)
				{ _Masks = Deserializers.deserialize_ListArrayint16(data_Masks); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationLane : TrackingDetectorConfiguration
		{
			public List<short[]>? _Masks;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Masks != null)
					{ base_jobj.Add("Masks",Serializers.serialize_ListArrayint16(_Masks)); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Masks = (JObject?)data["Masks"];
				if(data_Masks != null)
				{ _Masks = Deserializers.deserialize_ListArrayint16(data_Masks); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class TrafficLight : GeometryRectangle
		{
			public string? _Type;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Type", _Type));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Type = data["Type"];
				if(data_Type != null)
				{ _Type = Convert.ToString(data_Type); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationRedStop : TrackingDetectorConfiguration
		{
			public List<GeometryLineSegment>? _Lines;
			public List<IndexedTrackingDetectorLines>? _ExitLines;
			public string? _Direction;
			public long _GracePeriod;
			public TrafficLight? _TrafficLight;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Lines != null)
					{ base_jobj.Add("Lines",Serializers.serialize_ListGeometryLineSegment(_Lines)); }
					if(_ExitLines != null)
					{ base_jobj.Add("ExitLines",Serializers.serialize_ListIndexedTrackingDetectorLines(_ExitLines)); }

					base_jobj.Add(new JProperty("Direction", _Direction));


					base_jobj.Add(new JProperty("GracePeriod", _GracePeriod));

					if(_TrafficLight != null)
					{ base_jobj.Add(new JProperty("TrafficLight", _TrafficLight.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Lines = (JObject?)data["Lines"];
				if(data_Lines != null)
				{ _Lines = Deserializers.deserialize_ListGeometryLineSegment(data_Lines); }
				else
				{ success = false; }

				var data_ExitLines = (JObject?)data["ExitLines"];
				if(data_ExitLines != null)
				{ _ExitLines = Deserializers.deserialize_ListIndexedTrackingDetectorLines(data_ExitLines); }
				else
				{ success = false; }

				var data_Direction = data["Direction"];
				if(data_Direction != null)
				{ _Direction = Convert.ToString(data_Direction); }
				else
				{ success = false; }

				var data_GracePeriod = data["GracePeriod"];
				if(data_GracePeriod != null)
				{ _GracePeriod = Convert.ToInt64(data_GracePeriod); }
				else
				{ success = false; }

				_TrafficLight = new TrafficLight();
				var data_TrafficLight = (JObject?)data["TrafficLight"];
				if(data_TrafficLight != null)
				{ success = success && _TrafficLight.deserialize(data_TrafficLight); }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationStopViolation : TrackingDetectorConfiguration
		{
			public List<GeometryLineSegment>? _Lines;
			public string? _Direction;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Lines != null)
					{ base_jobj.Add("Lines",Serializers.serialize_ListGeometryLineSegment(_Lines)); }

					base_jobj.Add(new JProperty("Direction", _Direction));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Lines = (JObject?)data["Lines"];
				if(data_Lines != null)
				{ _Lines = Deserializers.deserialize_ListGeometryLineSegment(data_Lines); }
				else
				{ success = false; }

				var data_Direction = data["Direction"];
				if(data_Direction != null)
				{ _Direction = Convert.ToString(data_Direction); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationStoppedObject : TrackingDetectorConfiguration
		{
			public List<short[]>? _Masks;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Masks != null)
					{ base_jobj.Add("Masks",Serializers.serialize_ListArrayint16(_Masks)); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Masks = (JObject?)data["Masks"];
				if(data_Masks != null)
				{ _Masks = Deserializers.deserialize_ListArrayint16(data_Masks); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationTrafficLine : TrackingDetectorConfiguration
		{
			public List<GeometryLineSegment>? _Lines;
			public string? _Direction;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Lines != null)
					{ base_jobj.Add("Lines",Serializers.serialize_ListGeometryLineSegment(_Lines)); }

					base_jobj.Add(new JProperty("Direction", _Direction));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Lines = (JObject?)data["Lines"];
				if(data_Lines != null)
				{ _Lines = Deserializers.deserialize_ListGeometryLineSegment(data_Lines); }
				else
				{ success = false; }

				var data_Direction = data["Direction"];
				if(data_Direction != null)
				{ _Direction = Convert.ToString(data_Direction); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationUTurn : TrackingDetectorConfiguration
		{
			public GeometryPolygons? _Lines;
			public string? _Direction;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Lines != null)
					{ base_jobj.Add(new JProperty("Lines", _Lines.serialize())); }


					base_jobj.Add(new JProperty("Direction", _Direction));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_Lines = new GeometryPolygons();
				var data_Lines = (JObject?)data["Lines"];
				if(data_Lines != null)
				{ success = success && _Lines.deserialize(data_Lines); }

				var data_Direction = data["Direction"];
				if(data_Direction != null)
				{ _Direction = Convert.ToString(data_Direction); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationWhiteLineViolation : TrackingDetectorConfiguration
		{
			public List<GeometryLineSegment>? _Lines;
			public string? _Direction;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Lines != null)
					{ base_jobj.Add("Lines",Serializers.serialize_ListGeometryLineSegment(_Lines)); }

					base_jobj.Add(new JProperty("Direction", _Direction));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Lines = (JObject?)data["Lines"];
				if(data_Lines != null)
				{ _Lines = Deserializers.deserialize_ListGeometryLineSegment(data_Lines); }
				else
				{ success = false; }

				var data_Direction = data["Direction"];
				if(data_Direction != null)
				{ _Direction = Convert.ToString(data_Direction); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationWrongTurn : TrackingDetectorConfiguration
		{
			public List<GeometryLineGroup>? _LineGroups;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_LineGroups != null)
					{ base_jobj.Add("LineGroups",Serializers.serialize_ListGeometryLineGroup(_LineGroups)); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_LineGroups = (JObject?)data["LineGroups"];
				if(data_LineGroups != null)
				{ _LineGroups = Deserializers.deserialize_ListGeometryLineGroup(data_LineGroups); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class DetectorConfigurationWrongWay : TrackingDetectorConfiguration
		{
			public List<short[]>? _Masks;
			public double _Angle;
			public double _AngleRange;
			public int _LocationX;
			public int _LocationY;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Masks != null)
					{ base_jobj.Add("Masks",Serializers.serialize_ListArrayint16(_Masks)); }

					base_jobj.Add(new JProperty("Angle", _Angle));


					base_jobj.Add(new JProperty("AngleRange", _AngleRange));


					base_jobj.Add(new JProperty("LocationX", _LocationX));


					base_jobj.Add(new JProperty("LocationY", _LocationY));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Masks = (JObject?)data["Masks"];
				if(data_Masks != null)
				{ _Masks = Deserializers.deserialize_ListArrayint16(data_Masks); }
				else
				{ success = false; }

				var data_Angle = data["Angle"];
				if(data_Angle != null)
				{ _Angle = Convert.ToDouble(data_Angle); }
				else
				{ success = false; }

				var data_AngleRange = data["AngleRange"];
				if(data_AngleRange != null)
				{ _AngleRange = Convert.ToDouble(data_AngleRange); }
				else
				{ success = false; }

				var data_LocationX = data["LocationX"];
				if(data_LocationX != null)
				{ _LocationX = Convert.ToInt32(data_LocationX); }
				else
				{ success = false; }

				var data_LocationY = data["LocationY"];
				if(data_LocationY != null)
				{ _LocationY = Convert.ToInt32(data_LocationY); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class Center : AJsonSerializable
		{
			public short _X;
			public short _Y;

			public override JObject? serialize()
			{
				JObject _center = new JObject();


				_center.Add(new JProperty("X", _X));


				_center.Add(new JProperty("Y", _Y));

				return _center;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_X = data["X"];
				if(data_X != null)
				{ _X = Convert.ToInt16(data_X); }
				else
				{ success = false; }

				var data_Y = data["Y"];
				if(data_Y != null)
				{ _Y = Convert.ToInt16(data_Y); }
				else
				{ success = false; }


				return success;
			}
		}

		public class TrackedObjectInfo : AJsonSerializable
		{
			public long _Id;
			public string? _Type;
			public string? _State;
			public double _Confidence;
			public short[]? _Coords;
			public Center? _Center;
			public DateTime _StartTime;

			public override JObject? serialize()
			{
				JObject _trackedObjectInfo = new JObject();


				_trackedObjectInfo.Add(new JProperty("Id", _Id));


				_trackedObjectInfo.Add(new JProperty("Type", _Type));


				_trackedObjectInfo.Add(new JProperty("State", _State));


				_trackedObjectInfo.Add(new JProperty("Confidence", _Confidence));

				if(_Coords != null)
				{ _trackedObjectInfo.Add("Coords",Serializers.serialize_Arrayint16(_Coords)); }
				if(_Center != null)
				{ _trackedObjectInfo.Add(new JProperty("Center", _Center.serialize())); }


				_trackedObjectInfo.Add(new JProperty("StartTime", DateTimeConverter.convertToTimeStamp(_StartTime)));

				return _trackedObjectInfo;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Id = data["Id"];
				if(data_Id != null)
				{ _Id = Convert.ToInt64(data_Id); }
				else
				{ success = false; }

				var data_Type = data["Type"];
				if(data_Type != null)
				{ _Type = Convert.ToString(data_Type); }
				else
				{ success = false; }

				var data_State = data["State"];
				if(data_State != null)
				{ _State = Convert.ToString(data_State); }
				else
				{ success = false; }

				var data_Confidence = data["Confidence"];
				if(data_Confidence != null)
				{ _Confidence = Convert.ToDouble(data_Confidence); }
				else
				{ success = false; }

				var data_Coords = (JArray?)data["Coords"];
				if(data_Coords != null)
				{ _Coords = Deserializers.deserialize_Arrayint16(data_Coords); }
				else
				{ success = false; }

				_Center = new Center();
				var data_Center = (JObject?)data["Center"];
				if(data_Center != null)
				{ success = success && _Center.deserialize(data_Center); }

				var data_StartTime = data["StartTime"];
				if(data_StartTime != null)
				{ _StartTime = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_StartTime)); }
				else
				{ success = false; }


				return success;
			}
		}

		public class RedStopViolationInfo : TrackedObjectInfo
		{
			public DateTime _OrangeTimestamp;
			public DateTime _RedTimestamp;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("OrangeTimestamp", DateTimeConverter.convertToTimeStamp(_OrangeTimestamp)));


					base_jobj.Add(new JProperty("RedTimestamp", DateTimeConverter.convertToTimeStamp(_RedTimestamp)));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_OrangeTimestamp = data["OrangeTimestamp"];
				if(data_OrangeTimestamp != null)
				{ _OrangeTimestamp = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_OrangeTimestamp)); }
				else
				{ success = false; }

				var data_RedTimestamp = data["RedTimestamp"];
				if(data_RedTimestamp != null)
				{ _RedTimestamp = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_RedTimestamp)); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class EventEmergencyLane : Event
		{
			public TrackedObjectInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new TrackedObjectInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class EventForbiddenZone : Event
		{
			public TrackedObjectInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new TrackedObjectInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class EventLane : Event
		{
			public TrackedObjectInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new TrackedObjectInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class EventRedStop : Event
		{
			public RedStopViolationInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new RedStopViolationInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class EventStoppedObject : Event
		{
			public TrackedObjectInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new TrackedObjectInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class EventStopViolation : Event
		{
			public TrackedObjectInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new TrackedObjectInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class EventTrafficLine : Event
		{
			public TrackedObjectInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new TrackedObjectInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class EventUTurn : Event
		{
			public TrackedObjectInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new TrackedObjectInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class EventWhiteLineViolation : Event
		{
			public TrackedObjectInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new TrackedObjectInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class EventWrongTurn : Event
		{
			public TrackedObjectInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new TrackedObjectInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

		public class EventWrongWay : Event
		{
			public TrackedObjectInfo? _EventInfo;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_EventInfo != null)
					{ base_jobj.Add(new JProperty("EventInfo", _EventInfo.serialize())); }

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_EventInfo = new TrackedObjectInfo();
				var data_EventInfo = (JObject?)data["EventInfo"];
				if(data_EventInfo != null)
				{ success = success && _EventInfo.deserialize(data_EventInfo); }

				base.deserialize(data);

				return success;
			}
		}

	}
}