
using System;

using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.SecurityLogs;
using Crowdin.Api.Tests.Core;

namespace Crowdin.Api.Tests.SecurityLogs
{
    public class SecurityLogEnumsTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void EventTypes()
        {
            SerializeAndAssert(SecurityLogEventType.Login, "login");
            SerializeAndAssert(SecurityLogEventType.PasswordSet, "password.set");
            SerializeAndAssert(SecurityLogEventType.PasswordChange, "password.change");
            SerializeAndAssert(SecurityLogEventType.EmailChange, "email.change");
            SerializeAndAssert(SecurityLogEventType.LoginChange, "login.change");
            SerializeAndAssert(SecurityLogEventType.PersonalTokenIssued, "personal_token.issued");
            SerializeAndAssert(SecurityLogEventType.PersonalTokenRevoked, "personal_token.revoked");
            SerializeAndAssert(SecurityLogEventType.MfaEnabled, "mfa.enabled");
            SerializeAndAssert(SecurityLogEventType.MfaDisabled, "mfa.disabled");
            SerializeAndAssert(SecurityLogEventType.SessionRevoke, "session.revoke");
            SerializeAndAssert(SecurityLogEventType.SessionRevokeAll, "session.revoke_all");
            SerializeAndAssert(SecurityLogEventType.SsoConnect, "sso.connect");
            SerializeAndAssert(SecurityLogEventType.SsoDisconnect, "sso.disconnect");
            SerializeAndAssert(SecurityLogEventType.UserRemove, "user.remove");
            SerializeAndAssert(SecurityLogEventType.ApplicationConnected, "application.connected");
            SerializeAndAssert(SecurityLogEventType.ApplicationDisconnected, "application.disconnected");
            SerializeAndAssert(SecurityLogEventType.WebAuthNCreated, "webauthn.created");
            SerializeAndAssert(SecurityLogEventType.WebAuthNDeleted, "webauthn.deleted");
            SerializeAndAssert(SecurityLogEventType.TrustedDeviceRemove, "trusted_device.remove");
            SerializeAndAssert(SecurityLogEventType.TrustedDeviceRemoveAll, "trusted_device.remove_all");
            SerializeAndAssert(SecurityLogEventType.DeviceVerificationEnabled, "device_verification.enabled");
            SerializeAndAssert(SecurityLogEventType.DeviceVerificationDisabled, "device_verification.disabled");
        }
        
        private static void SerializeAndAssert(Enum enumValue, string expectedValueString)
        {
            string actualValueString = TestUtils.SerializeValue(enumValue, JsonSettings);
            Assert.Equal(expectedValueString, actualValueString);
        }
    }
}