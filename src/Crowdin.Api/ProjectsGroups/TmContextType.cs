
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum TmContextType
    {
        [Description("segmentContext")]
        SegmentContext,
        
        [Description("auto")]
        Auto,
        
        [Description("prevAndNextSegment")]
        PrevAndNextSegment
    }
}