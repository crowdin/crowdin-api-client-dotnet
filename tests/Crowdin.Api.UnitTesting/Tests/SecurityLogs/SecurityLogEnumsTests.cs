
using System;

using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.SecurityLogs;

namespace Crowdin.Api.UnitTesting.Tests.SecurityLogs
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
            SerializeAndAssert(SecurityLogEventType.UserForceRemoved, "user.force_removed");
            SerializeAndAssert(SecurityLogEventType.UserBlocked, "user.blocked");
            SerializeAndAssert(SecurityLogEventType.UserUnblocked, "user.unblocked");
            SerializeAndAssert(SecurityLogEventType.TeamMemberAdded, "team.member.added");
            SerializeAndAssert(SecurityLogEventType.TeamMemberRemoved, "team.member.removed");
            SerializeAndAssert(SecurityLogEventType.RoleAdminGranted, "role.admin.granted");
            SerializeAndAssert(SecurityLogEventType.RoleAdminRevoked, "role.admin.revoked");
            SerializeAndAssert(SecurityLogEventType.RoleGroupManagerGranted, "role.group_manager.granted");
            SerializeAndAssert(SecurityLogEventType.RoleGroupManagerRevoked, "role.group_manager.revoked");
            SerializeAndAssert(SecurityLogEventType.OrganizationSettingsSamlChanged, "organization.settings.saml.changed");
            SerializeAndAssert(SecurityLogEventType.OrganizationSettingsInviteRestrictChanged, "organization.settings.invite_restrict.changed");
            SerializeAndAssert(SecurityLogEventType.OrganizationSettingsDeviceVerificationChanged, "organization.settings.device_verification.changed");
            SerializeAndAssert(SecurityLogEventType.OrganizationSettingsMfaChanged, "organization.settings.mfa.changed");
            SerializeAndAssert(SecurityLogEventType.OrganizationSettingsRememberMeChanged, "organization.settings.remember_me.changed");
            SerializeAndAssert(SecurityLogEventType.OrganizationSettingsSignUpChanged, "organization.settings.sign_up.changed");
            SerializeAndAssert(SecurityLogEventType.OrganizationSettingsTokenCreationChanged, "organization.settings.token_creation.changed");
            SerializeAndAssert(SecurityLogEventType.OrganizationSettingsTokenExpirationChanged, "organization.settings.token_expiration.changed");
            SerializeAndAssert(SecurityLogEventType.SsoCustomAppConfigured, "sso.custom_app.configured");
            SerializeAndAssert(SecurityLogEventType.SsoCustomAppDisabled, "sso.custom_app.disabled");
            SerializeAndAssert(SecurityLogEventType.OrganizationAuthMethodDisabled, "organization.auth_method.disabled");
            SerializeAndAssert(SecurityLogEventType.OrganizationAuthMethodEnabled, "organization.auth_method.enabled");
            SerializeAndAssert(SecurityLogEventType.UserRegistered, "user.registered");
        }

        private static void SerializeAndAssert(Enum enumValue, string expectedValueString)
        {
            string actualValueString = TestUtils.SerializeValue(enumValue, JsonSettings);
            Assert.Equal(expectedValueString, actualValueString);
        }
    }
}
