
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
        Task<ResponseList<WorkflowStep>> ListWorkflowSteps(int projectId);

        Task<WorkflowStep> GetWorkflowStep(int projectId, int stepId);

        Task<ResponseList<SourceString>> ListStringsOnTheWorkflowStep(
            int projectId,
            int stepId,
            IEnumerable<string>? languageIds = null,
            IEnumerable<SortingRule>? orderBy = null,
            WorkflowStatus? status = null,
            int? limit = null,
            int? offset = null);

        Task<ResponseList<SourceString>> ListStringsOnTheWorkflowStep(
            int projectId,
            int stepId,
            StringsOnTheWorkflowStepListParams? @params = null);

        #region Templates

        Task<ResponseList<WorkflowTemplate>> ListWorkflowTemplates(int groupId, int limit = 25, int offset = 0);

        Task<WorkflowTemplate> GetWorkflowTemplate(int templateId);

        #endregion
    }
}