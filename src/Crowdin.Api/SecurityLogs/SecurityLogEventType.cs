
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
        DeviceVerificationDisabled
    }
}