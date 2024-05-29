
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.SecurityLogs
{
    [PublicAPI]
    public enum SecurityLogEventType
    {
        [SerializedValue("login")]
        Login,
        
        [SerializedValue("password.set")]
        PasswordSet,
        
        [SerializedValue("password.change")]
        PasswordChange,
        
        [SerializedValue("email.change")]
        EmailChange,
        
        [SerializedValue("login.change")]
        LoginChange,
        
        [SerializedValue("personal_token.issued")]
        PersonalTokenIssued,
        
        [SerializedValue("personal_token.revoked")]
        PersonalTokenRevoked,
        
        [SerializedValue("mfa.enabled")]
        MfaEnabled,
        
        [SerializedValue("mfa.disabled")]
        MfaDisabled,
        
        [SerializedValue("session.revoke")]
        SessionRevoke,
        
        [SerializedValue("session.revoke_all")]
        SessionRevokeAll,
        
        [SerializedValue("sso.connect")]
        SsoConnect,
        
        [SerializedValue("sso.disconnect")]
        SsoDisconnect,
        
        [SerializedValue("user.remove")]
        UserRemove,
        
        [SerializedValue("application.connected")]
        ApplicationConnected,
        
        [SerializedValue("application.disconnected")]
        ApplicationDisconnected,
        
        [SerializedValue("webauthn.created")]
        WebAuthNCreated,
        
        [SerializedValue("webauthn.deleted")]
        WebAuthNDeleted,
        
        [SerializedValue("trusted_device.remove")]
        TrustedDeviceRemove,
        
        [SerializedValue("trusted_device.remove_all")]
        TrustedDeviceRemoveAll,
        
        [SerializedValue("device_verification.enabled")]
        DeviceVerificationEnabled,
        
        [SerializedValue("device_verification.disabled")]
        DeviceVerificationDisabled
    }
}