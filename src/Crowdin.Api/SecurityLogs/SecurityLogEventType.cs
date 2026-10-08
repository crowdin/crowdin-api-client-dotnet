
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.SecurityLogs
{
    [PublicAPI]
    public enum SecurityLogEventType
    {
        [Description("login")]
        Login,
        
        [Description("password.set")]
        PasswordSet,
        
        [Description("password.change")]
        PasswordChange,
        
        [Description("email.change")]
        EmailChange,
        
        [Description("login.change")]
        LoginChange,
        
        [Description("personal_token.issued")]
        PersonalTokenIssued,
        
        [Description("personal_token.revoked")]
        PersonalTokenRevoked,
        
        [Description("mfa.enabled")]
        MfaEnabled,
        
        [Description("mfa.disabled")]
        MfaDisabled,
        
        [Description("session.revoke")]
        SessionRevoke,
        
        [Description("session.revoke_all")]
        SessionRevokeAll,
        
        [Description("sso.connect")]
        SsoConnect,
        
        [Description("sso.disconnect")]
        SsoDisconnect,

        [Description("user.remove")]
        UserRemove,
        
        [Description("application.connected")]
        ApplicationConnected,
        
        [Description("application.disconnected")]
        ApplicationDisconnected,
        
        [Description("webauthn.created")]
        WebAuthNCreated,
        
        [Description("webauthn.deleted")]
        WebAuthNDeleted,
        
        [Description("trusted_device.remove")]
        TrustedDeviceRemove,
        
        [Description("trusted_device.remove_all")]
        TrustedDeviceRemoveAll,
        
        [Description("device_verification.enabled")]
        DeviceVerificationEnabled,
        
        [Description("device_verification.disabled")]
        DeviceVerificationDisabled,

        [Description("user.force_removed")]
        UserForceRemoved,

        [Description("user.blocked")]
        UserBlocked,

        [Description("user.unblocked")]
        UserUnblocked,

        [Description("team.member.added")]
        TeamMemberAdded,

        [Description("team.member.removed")]
        TeamMemberRemoved,

        [Description("role.admin.granted")]
        RoleAdminGranted,

        [Description("role.admin.revoked")]
        RoleAdminRevoked,

        [Description("role.group_manager.granted")]
        RoleGroupManagerGranted,

        [Description("role.group_manager.revoked")]
        RoleGroupManagerRevoked,

        [Description("organization.settings.saml.changed")]
        OrganizationSettingsSamlChanged,

        [Description("organization.settings.invite_restrict.changed")]
        OrganizationSettingsInviteRestrictChanged,

        [Description("organization.settings.device_verification.changed")]
        OrganizationSettingsDeviceVerificationChanged,

        [Description("organization.settings.mfa.changed")]
        OrganizationSettingsMfaChanged,

        [Description("organization.settings.remember_me.changed")]
        OrganizationSettingsRememberMeChanged,

        [Description("organization.settings.sign_up.changed")]
        OrganizationSettingsSignUpChanged,

        [Description("organization.settings.token_creation.changed")]
        OrganizationSettingsTokenCreationChanged,

        [Description("organization.settings.token_expiration.changed")]
        OrganizationSettingsTokenExpirationChanged,

        [Description("sso.custom_app.configured")]
        SsoCustomAppConfigured,

        [Description("sso.custom_app.disabled")]
        SsoCustomAppDisabled,

        [Description("organization.auth_method.disabled")]
        OrganizationAuthMethodDisabled,

        [Description("organization.auth_method.enabled")]
        OrganizationAuthMethodEnabled,

        [Description("user.registered")]
        UserRegistered
    }
}
