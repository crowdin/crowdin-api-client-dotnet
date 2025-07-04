
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.SourceStrings;

#nullable enable

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public interface IWorkflowsApiExecutor
    {
        Task<ResponseList<WorkflowStep>> ListWorkflowSteps(long projectId);

        Task<WorkflowStep> GetWorkflowStep(long projectId, long stepId);

        Task<ResponseList<SourceString>> ListStringsOnTheWorkflowStep(
            long projectId,
            long stepId,
            IEnumerable<string>? languageIds = null,
            IEnumerable<SortingRule>? orderBy = null,
            WorkflowStatus? status = null,
            int? limit = null,
            int? offset = null);

        Task<ResponseList<SourceString>> ListStringsOnTheWorkflowStep(
            long projectId,
            long stepId,
            StringsOnTheWorkflowStepListParams? @params = null);

        #region Templates

        Task<ResponseList<WorkflowTemplate>> ListWorkflowTemplates(long groupId, int limit = 25, int offset = 0);

        Task<WorkflowTemplate> GetWorkflowTemplate(long templateId);

        #endregion
    }
}