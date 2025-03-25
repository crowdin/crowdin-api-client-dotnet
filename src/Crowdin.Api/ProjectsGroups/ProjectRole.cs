
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    // TODO: leave here in ProjectsGroups or move to Teams (closer to the only usage)
    [PublicAPI]
    public enum ProjectRole
    {
        [Description("manager")]
        Manager,
        
        [Description("developer")]
        Developer,
        
        [Description("translator")]
        Translator,
        
        [Description("proofreader")]
        Proofreader,
        
        [Description("language_coordinator")]
        LanguageCoordinator,
        
        [Description("member")]
        Member
    }
}