
using System.Threading.Tasks;
using JetBrains.Annotations;
using Crowdin.Api.Workflows;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IWorkflowsApiExecutor
    {
        Task<ResponseList<WorkflowStep>> ListWorkflowSteps(int projectId);

        Task<WorkflowStep> GetWorkflowStep(int projectId, int stepId);

        #region Templates

        Task<ResponseList<WorkflowTemplate>> ListWorkflowTemplates(int groupId, int limit = 25, int offset = 0);

        Task<WorkflowTemplate> GetWorkflowTemplate(int templateId);

        #endregion
    }
}