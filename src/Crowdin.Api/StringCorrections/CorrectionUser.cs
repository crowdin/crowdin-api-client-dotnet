using System.ComponentModel;

namespace Crowdin.Api.StringCorrections
{
    public class CorrectionUser
    {
        [Description("id")]
        public int Id { get; set; }

        [Description("username")]
        public string Username { get; set; }

        [Description("fullName")]
        public string FullName { get; set; }

        [Description("avatarUrl")]
        public string AvatarUrl { get; set; }
    }
}