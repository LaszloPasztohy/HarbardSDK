using Newtonsoft.Json.Linq;

namespace Harbard
{
	namespace Api
	{
		public class SystemSettingsResponse : SystemSettings
		{
			public SystemSettingsDevice? _Device;
			public Dictionary<string, SystemSettingsModule>? _Modules;
			public string? _InstanceId;
			public DateTime _Uptime;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{
					if(_Device != null)
					{ base_jobj.Add(new JProperty("Device", _Device.serialize())); }

					if(_Modules != null)
					{ base_jobj.Add("Modules",Serializers.serialize_MapSystemSettingsModule(_Modules)); }

					base_jobj.Add(new JProperty("InstanceId", _InstanceId));


					base_jobj.Add(new JProperty("Uptime", DateTimeConverter.convertToTimeStamp(_Uptime)));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				_Device = new SystemSettingsDevice();
				var data_Device = (JObject?)data["Device"];
				if(data_Device != null)
				{ success = success && _Device.deserialize(data_Device); }

				var data_Modules = (JObject?)data["Modules"];
				if(data_Modules != null)
				{ _Modules = Deserializers.deserialize_MapSystemSettingsModule(data_Modules); }
				else
				{ success = false; }

				var data_InstanceId = data["InstanceId"];
				if(data_InstanceId != null)
				{ _InstanceId = Convert.ToString(data_InstanceId); }
				else
				{ success = false; }

				var data_Uptime = data["Uptime"];
				if(data_Uptime != null)
				{ _Uptime = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_Uptime)); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class SystemSettings : AJsonSerializable
		{
			public string? _Name;
			public string? _Description;
			public LocationSettings? _Location;

			public override JObject? serialize()
			{
				JObject _systemSettings = new JObject();


				_systemSettings.Add(new JProperty("Name", _Name));


				_systemSettings.Add(new JProperty("Description", _Description));

				if(_Location != null)
				{ _systemSettings.Add(new JProperty("Location", _Location.serialize())); }

				return _systemSettings;
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

				_Location = new LocationSettings();
				var data_Location = (JObject?)data["Location"];
				if(data_Location != null)
				{ success = success && _Location.deserialize(data_Location); }


				return success;
			}
		}

		public class GpioPortId : AJsonSerializable
		{
			public string? _Port;

			public override JObject? serialize()
			{
				JObject _gpioPortId = new JObject();


				_gpioPortId.Add(new JProperty("Port", _Port));

				return _gpioPortId;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Port = data["Port"];
				if(data_Port != null)
				{ _Port = Convert.ToString(data_Port); }
				else
				{ success = false; }


				return success;
			}
		}

		public class GpioOutputPortState : GpioPortId
		{
			public bool _Active;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Active", _Active));

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

				base.deserialize(data);

				return success;
			}
		}

		public class GpioInputPort : GpioPort
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

		public class GpioOutputPort : GpioPort
		{
			public int _ActiveTime;
			public List<string>? _DetectorList;
			public string? _OutputMode;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("ActiveTime", _ActiveTime));

					if(_DetectorList != null)
					{ base_jobj.Add("DetectorList",Serializers.serialize_Listguid(_DetectorList)); }

					base_jobj.Add(new JProperty("OutputMode", _OutputMode));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_ActiveTime = data["ActiveTime"];
				if(data_ActiveTime != null)
				{ _ActiveTime = Convert.ToInt32(data_ActiveTime); }
				else
				{ success = false; }

				var data_DetectorList = (JObject?)data["DetectorList"];
				if(data_DetectorList != null)
				{ _DetectorList = Deserializers.deserialize_Listguid(data_DetectorList); }
				else
				{ success = false; }

				var data_OutputMode = data["OutputMode"];
				if(data_OutputMode != null)
				{ _OutputMode = Convert.ToString(data_OutputMode); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class GpioSettings : AJsonSerializable
		{
			public Dictionary<string, GpioInputPort>? _Inputs;
			public Dictionary<string, GpioOutputPort>? _Outputs;

			public override JObject? serialize()
			{
				JObject _gpioSettings = new JObject();

				if(_Inputs != null)
				{ _gpioSettings.Add("Inputs",Serializers.serialize_MapGpioInputPort(_Inputs)); }
				if(_Outputs != null)
				{ _gpioSettings.Add("Outputs",Serializers.serialize_MapGpioOutputPort(_Outputs)); }

				return _gpioSettings;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Inputs = (JObject?)data["Inputs"];
				if(data_Inputs != null)
				{ _Inputs = Deserializers.deserialize_MapGpioInputPort(data_Inputs); }
				else
				{ success = false; }

				var data_Outputs = (JObject?)data["Outputs"];
				if(data_Outputs != null)
				{ _Outputs = Deserializers.deserialize_MapGpioOutputPort(data_Outputs); }
				else
				{ success = false; }


				return success;
			}
		}

		public class GpioStates : AJsonSerializable
		{
			public Dictionary<string, GpioPortState>? _Inputs;
			public Dictionary<string, GpioPortState>? _Outputs;

			public override JObject? serialize()
			{
				JObject _gpioStates = new JObject();

				if(_Inputs != null)
				{ _gpioStates.Add("Inputs",Serializers.serialize_MapGpioPortState(_Inputs)); }
				if(_Outputs != null)
				{ _gpioStates.Add("Outputs",Serializers.serialize_MapGpioPortState(_Outputs)); }

				return _gpioStates;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Inputs = (JObject?)data["Inputs"];
				if(data_Inputs != null)
				{ _Inputs = Deserializers.deserialize_MapGpioPortState(data_Inputs); }
				else
				{ success = false; }

				var data_Outputs = (JObject?)data["Outputs"];
				if(data_Outputs != null)
				{ _Outputs = Deserializers.deserialize_MapGpioPortState(data_Outputs); }
				else
				{ success = false; }


				return success;
			}
		}

		public class RebootSettings : AJsonSerializable
		{
			public string? _Message;

			public override JObject? serialize()
			{
				JObject _rebootSettings = new JObject();


				_rebootSettings.Add(new JProperty("Message", _Message));

				return _rebootSettings;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Message = data["Message"];
				if(data_Message != null)
				{ _Message = Convert.ToString(data_Message); }
				else
				{ success = false; }


				return success;
			}
		}

		public class TestInput : AJsonSerializable
		{
			public string? _Text;
			public bool _ThrowException;

			public override JObject? serialize()
			{
				JObject _testInput = new JObject();


				_testInput.Add(new JProperty("Text", _Text));


				_testInput.Add(new JProperty("ThrowException", _ThrowException));

				return _testInput;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Text = data["Text"];
				if(data_Text != null)
				{ _Text = Convert.ToString(data_Text); }
				else
				{ success = false; }

				var data_ThrowException = data["ThrowException"];
				if(data_ThrowException != null)
				{ _ThrowException = Convert.ToBoolean(data_ThrowException); }
				else
				{ success = false; }


				return success;
			}
		}

		public class TestOutput : AJsonSerializable
		{
			public string? _Text;
			public int _Size;
			public string? _User;

			public override JObject? serialize()
			{
				JObject _testOutput = new JObject();


				_testOutput.Add(new JProperty("Text", _Text));


				_testOutput.Add(new JProperty("Size", _Size));


				_testOutput.Add(new JProperty("User", _User));

				return _testOutput;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Text = data["Text"];
				if(data_Text != null)
				{ _Text = Convert.ToString(data_Text); }
				else
				{ success = false; }

				var data_Size = data["Size"];
				if(data_Size != null)
				{ _Size = Convert.ToInt32(data_Size); }
				else
				{ success = false; }

				var data_User = data["User"];
				if(data_User != null)
				{ _User = Convert.ToString(data_User); }
				else
				{ success = false; }


				return success;
			}
		}

		public class ApiVersion : AJsonSerializable
		{
			public int _Version;

			public override JObject? serialize()
			{
				JObject _apiVersion = new JObject();


				_apiVersion.Add(new JProperty("Version", _Version));

				return _apiVersion;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Version = data["Version"];
				if(data_Version != null)
				{ _Version = Convert.ToInt32(data_Version); }
				else
				{ success = false; }


				return success;
			}
		}

		public class SecuritySettings : AJsonSerializable
		{
			public int _AuthenticationAttemptLimit;
			public long _SourceBlockDuration;

			public override JObject? serialize()
			{
				JObject _securitySettings = new JObject();


				_securitySettings.Add(new JProperty("AuthenticationAttemptLimit", _AuthenticationAttemptLimit));


				_securitySettings.Add(new JProperty("SourceBlockDuration", _SourceBlockDuration));

				return _securitySettings;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_AuthenticationAttemptLimit = data["AuthenticationAttemptLimit"];
				if(data_AuthenticationAttemptLimit != null)
				{ _AuthenticationAttemptLimit = Convert.ToInt32(data_AuthenticationAttemptLimit); }
				else
				{ success = false; }

				var data_SourceBlockDuration = data["SourceBlockDuration"];
				if(data_SourceBlockDuration != null)
				{ _SourceBlockDuration = Convert.ToInt64(data_SourceBlockDuration); }
				else
				{ success = false; }


				return success;
			}
		}

		public class SecurityHistory : AJsonSerializable
		{
			public Dictionary<string, long>? _BlockedSources;
			public List<ActiveSession>? _Sessions;

			public override JObject? serialize()
			{
				JObject _securityHistory = new JObject();

				if(_BlockedSources != null)
				{ _securityHistory.Add("BlockedSources",Serializers.serialize_Mapint64(_BlockedSources)); }
				if(_Sessions != null)
				{ _securityHistory.Add("Sessions",Serializers.serialize_ListActiveSession(_Sessions)); }

				return _securityHistory;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_BlockedSources = (JObject?)data["BlockedSources"];
				if(data_BlockedSources != null)
				{ _BlockedSources = Deserializers.deserialize_Mapint64(data_BlockedSources); }
				else
				{ success = false; }

				var data_Sessions = (JObject?)data["Sessions"];
				if(data_Sessions != null)
				{ _Sessions = Deserializers.deserialize_ListActiveSession(data_Sessions); }
				else
				{ success = false; }


				return success;
			}
		}

		public class TimeSettings : AJsonSerializable
		{
			public DateTime _Timestamp;

			public override JObject? serialize()
			{
				JObject _timeSettings = new JObject();


				_timeSettings.Add(new JProperty("Timestamp", DateTimeConverter.convertToTimeStamp(_Timestamp)));

				return _timeSettings;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Timestamp = data["Timestamp"];
				if(data_Timestamp != null)
				{ _Timestamp = DateTimeConverter.convertToDateTime(Convert.ToInt64(data_Timestamp)); }
				else
				{ success = false; }


				return success;
			}
		}

		public class NtpSettings : AJsonSerializable
		{
			public bool _Enabled;
			public List<string>? _Servers;

			public override JObject? serialize()
			{
				JObject _ntpSettings = new JObject();


				_ntpSettings.Add(new JProperty("Enabled", _Enabled));

				if(_Servers != null)
				{ _ntpSettings.Add("Servers",Serializers.serialize_Liststring(_Servers)); }

				return _ntpSettings;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Enabled = data["Enabled"];
				if(data_Enabled != null)
				{ _Enabled = Convert.ToBoolean(data_Enabled); }
				else
				{ success = false; }

				var data_Servers = (JObject?)data["Servers"];
				if(data_Servers != null)
				{ _Servers = Deserializers.deserialize_Liststring(data_Servers); }
				else
				{ success = false; }


				return success;
			}
		}

		public class UserId : AJsonSerializable
		{
			public string? _Name;

			public override JObject? serialize()
			{
				JObject _userId = new JObject();


				_userId.Add(new JProperty("Name", _Name));

				return _userId;
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

		public class UserInfo : UserId
		{
			public string? _Role;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Role", _Role));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Role = data["Role"];
				if(data_Role != null)
				{ _Role = Convert.ToString(data_Role); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class User : UserInfo
		{
			public string? _Password;

			public override JObject? serialize()
			{
				var base_jobj = base.serialize();
				if(base_jobj != null)
				{

					base_jobj.Add(new JProperty("Password", _Password));

				}
				return base_jobj;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Password = data["Password"];
				if(data_Password != null)
				{ _Password = Convert.ToString(data_Password); }
				else
				{ success = false; }

				base.deserialize(data);

				return success;
			}
		}

		public class Users : AJsonSerializable
		{
			public List<User>? _Users;

			public override JObject? serialize()
			{
				JObject _users = new JObject();

				if(_Users != null)
				{ _users.Add("Users",Serializers.serialize_ListUser(_Users)); }

				return _users;
			}

			public override bool deserialize(JObject data)
			{
				bool success = true;

				var data_Users = (JObject?)data["Users"];
				if(data_Users != null)
				{ _Users = Deserializers.deserialize_ListUser(data_Users); }
				else
				{ success = false; }


				return success;
			}
		}

	}
}