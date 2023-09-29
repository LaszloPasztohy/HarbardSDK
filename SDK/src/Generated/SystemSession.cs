using Newtonsoft.Json.Linq;

namespace Harbard
{
	namespace Api
	{
		public class SystemSession : AApiSession
		{
			public SystemSession(Session parent) : base(parent) {}

			public SystemSettingsResponse GetDevice()
			{
				ApiResult ApiRes = session.executeCommand("System", "GetDevice");
				var response = new SystemSettingsResponse();

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

			public void GetDeviceAsync(Action<SystemSettingsResponse, ApiException?> callback)
			{
				session.executeCommandAsync("System", "GetDevice", (ApiResult ApiRes) =>
				{
					var response = new SystemSettingsResponse();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public SystemSettings SetDevice()
			{
				ApiResult ApiRes = session.executeCommand("System", "SetDevice");
				var response = new SystemSettings();

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

			public void SetDeviceAsync(Action<SystemSettings, ApiException?> callback)
			{
				session.executeCommandAsync("System", "SetDevice", (ApiResult ApiRes) =>
				{
					var response = new SystemSettings();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public GpioSettings GetGpioSettings()
			{
				ApiResult ApiRes = session.executeCommand("System", "GetGpioSettings");
				var response = new GpioSettings();

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

			public void GetGpioSettingsAsync(Action<GpioSettings, ApiException?> callback)
			{
				session.executeCommandAsync("System", "GetGpioSettings", (ApiResult ApiRes) =>
				{
					var response = new GpioSettings();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public GpioStates GetGpioStates()
			{
				ApiResult ApiRes = session.executeCommand("System", "GetGpioStates");
				var response = new GpioStates();

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

			public void GetGpioStatesAsync(Action<GpioStates, ApiException?> callback)
			{
				session.executeCommandAsync("System", "GetGpioStates", (ApiResult ApiRes) =>
				{
					var response = new GpioStates();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public ApiResult SetGpioInputSettings(GpioInputPort data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "SetGpioInputSettings", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void SetGpioInputSettingsAsync(GpioInputPort data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "SetGpioInputSettings", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult SetGpioOutputSettings(GpioOutputPort data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "SetGpioOutputSettings", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void SetGpioOutputSettingsAsync(GpioOutputPort data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "SetGpioOutputSettings", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult TriggerGpioOutput(GpioPortId data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "TriggerGpioOutput", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void TriggerGpioOutputAsync(GpioPortId data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "TriggerGpioOutput", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult SetGpioOutput(GpioOutputPortState data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "SetGpioOutput", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void SetGpioOutputAsync(GpioOutputPortState data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "SetGpioOutput", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult Reboot(RebootSettings data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "Reboot", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void RebootAsync(RebootSettings data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "Reboot", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult FactoryReset()
			{
				ApiResult ApiRes = Session.executeCommand("System", "FactoryReset");

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void FactoryResetAsync(Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "FactoryReset", (ApiResult ApiRes) => { callback(ApiRes); });
			}

			public TestOutput RunTest(TestInput data)
			{
				ApiResult ApiRes = session.executeCommand("System", "RunTest", data.serialize());
				var response = new TestOutput();

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

			public void RunTestAsync(TestInput data, Action<TestOutput, ApiException?> callback)
			{
				session.executeCommandAsync("System", "RunTest", (ApiResult ApiRes) =>
				{
					var response = new TestOutput();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				}, data.serialize());
			}

			public ApiVersion GetApiVersion()
			{
				ApiResult ApiRes = session.executeCommand("System", "GetApiVersion");
				var response = new ApiVersion();

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

			public void GetApiVersionAsync(Action<ApiVersion, ApiException?> callback)
			{
				session.executeCommandAsync("System", "GetApiVersion", (ApiResult ApiRes) =>
				{
					var response = new ApiVersion();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public SecuritySettings GetSecuritySettings()
			{
				ApiResult ApiRes = session.executeCommand("System", "GetSecuritySettings");
				var response = new SecuritySettings();

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

			public void GetSecuritySettingsAsync(Action<SecuritySettings, ApiException?> callback)
			{
				session.executeCommandAsync("System", "GetSecuritySettings", (ApiResult ApiRes) =>
				{
					var response = new SecuritySettings();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public ApiResult SetSecuritySettings(SecuritySettings data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "SetSecuritySettings", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void SetSecuritySettingsAsync(SecuritySettings data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "SetSecuritySettings", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult ClearSecurityHistory()
			{
				ApiResult ApiRes = Session.executeCommand("System", "ClearSecurityHistory");

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void ClearSecurityHistoryAsync(Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "ClearSecurityHistory", (ApiResult ApiRes) => { callback(ApiRes); });
			}

			public SecurityHistory GetSecurityHistory()
			{
				ApiResult ApiRes = session.executeCommand("System", "GetSecurityHistory");
				var response = new SecurityHistory();

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

			public void GetSecurityHistoryAsync(Action<SecurityHistory, ApiException?> callback)
			{
				session.executeCommandAsync("System", "GetSecurityHistory", (ApiResult ApiRes) =>
				{
					var response = new SecurityHistory();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public TimeSettings GetTime()
			{
				ApiResult ApiRes = session.executeCommand("System", "GetTime");
				var response = new TimeSettings();

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

			public void GetTimeAsync(Action<TimeSettings, ApiException?> callback)
			{
				session.executeCommandAsync("System", "GetTime", (ApiResult ApiRes) =>
				{
					var response = new TimeSettings();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public ApiResult SetTime(TimeSettings data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "SetTime", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void SetTimeAsync(TimeSettings data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "SetTime", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public NtpSettings GetNtpSettings()
			{
				ApiResult ApiRes = session.executeCommand("System", "GetNtpSettings");
				var response = new NtpSettings();

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

			public void GetNtpSettingsAsync(Action<NtpSettings, ApiException?> callback)
			{
				session.executeCommandAsync("System", "GetNtpSettings", (ApiResult ApiRes) =>
				{
					var response = new NtpSettings();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public ApiResult SetNtpSettings(NtpSettings data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "SetNtpSettings", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void SetNtpSettingsAsync(NtpSettings data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "SetNtpSettings", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public UserInfo GetCurrentUser()
			{
				ApiResult ApiRes = session.executeCommand("System", "GetCurrentUser");
				var response = new UserInfo();

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

			public void GetCurrentUserAsync(Action<UserInfo, ApiException?> callback)
			{
				session.executeCommandAsync("System", "GetCurrentUser", (ApiResult ApiRes) =>
				{
					var response = new UserInfo();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public Users GetUsers()
			{
				ApiResult ApiRes = session.executeCommand("System", "GetUsers");
				var response = new Users();

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

			public void GetUsersAsync(Action<Users, ApiException?> callback)
			{
				session.executeCommandAsync("System", "GetUsers", (ApiResult ApiRes) =>
				{
					var response = new Users();

					if(ApiRes.data != null)
					{
						response.deserialize(ApiRes.data);
					}

					callback(response, ApiRes.error);
				});
			}

			public ApiResult AddUser(User data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "AddUser", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void AddUserAsync(User data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "AddUser", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult ModifyUser(User data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "ModifyUser", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void ModifyUserAsync(User data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "ModifyUser", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

			public ApiResult DeleteUser(UserId data)
			{
				ApiResult ApiRes = Session.executeCommand("System", "DeleteUser", data.serialize());

				if(ApiRes.error != null)
				{ throw(ApiRes.error); };

				return ApiRes;
			}

			public void DeleteUserAsync(UserId data, Action<ApiResult> callback)
			{
				session.executeCommandAsync("System", "DeleteUser", (ApiResult ApiRes) => { callback(ApiRes); }, data.serialize());
			}

		}	}
}