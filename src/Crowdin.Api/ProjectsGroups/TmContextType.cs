
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public enum TmContextType
    {
        [SerializedValue("segmentContext")]
        SegmentContext,
        
        [SerializedValue("auto")]
        Auto,
        
        [SerializedValue("prevAndNextSegment")]
        PrevAndNextSegment
    }
}