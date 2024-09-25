
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Tests.Core.Resources;

namespace Crowdin.Api.Tests.AI
{
    public class AiPromptFineTuningDatasetsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task GenerateAiPromptFineTuningDataset()
        {
            const int userId = 1;
            const int aiPromptId = 2;

            var request = new GenerateAiPromptFineTuningDatasetRequest
            {
                ProjectIds = new[] { 1, 2, 3 },
                Purpose = AiDatasetPurpose.Training,
                DateFrom = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                DateTo = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                MaxFileSize = 100,
                MinExamplesCount = 10,
                MaxExamplesCount = 50
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_FineTuningDatasets.GenerateAiPromptFineTuningDataset_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/prompts/{aiPromptId}/fine-tuning/datasets";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FineTuningDatasets.CommonResponses_AiFineTuningDataset)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiFineTuningDataset? response = await executor.GenerateAiPromptFineTuningDataset(userId, aiPromptId, request);
            
            Assert_AiFineTuningDataset(response);
        }
        
        [Fact]
        public async Task GenerateAiPromptFineTuningDataset_Enterprise()
        {
            const int aiPromptId = 1;

            var request = new GenerateAiPromptFineTuningDatasetRequest
            {
                ProjectIds = new[]{ 1, 2, 3 },
                Purpose = AiDatasetPurpose.Training,
                DateFrom = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                DateTo = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                MaxFileSize = 100,
                MinExamplesCount = 10,
                MaxExamplesCount = 50
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_FineTuningDatasets.GenerateAiPromptFineTuningDataset_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/ai/prompts/{aiPromptId}/fine-tuning/datasets";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FineTuningDatasets.CommonResponses_AiFineTuningDataset)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiFineTuningDataset? response = await executor.GenerateAiPromptFineTuningDataset(userId: null, aiPromptId, request);
            
            Assert_AiFineTuningDataset(response);
        }

        [Fact]
        public async Task GetAiPromptFineTuningDatasetGenerationStatus()
        {
            const int userId = 1;
            const int aiPromptId = 2;
            const string jobIdentifier = "50fb3506-4127-4ba8-8296-f97dc7e3e0c3";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/prompts/{aiPromptId}/fine-tuning/datasets/{jobIdentifier}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FineTuningDatasets.CommonResponses_AiFineTuningDataset)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiFineTuningDataset? response = await executor.GetAiPromptFineTuningDatasetGenerationStatus(userId, aiPromptId, jobIdentifier);
            
            Assert_AiFineTuningDataset(response);
        }
        
        [Fact]
        public async Task GetAiPromptFineTuningDatasetGenerationStatus_Enterprise()
        {
            const int aiPromptId = 1;
            const string jobIdentifier = "50fb3506-4127-4ba8-8296-f97dc7e3e0c3";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/prompts/{aiPromptId}/fine-tuning/datasets/{jobIdentifier}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FineTuningDatasets.CommonResponses_AiFineTuningDataset)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiFineTuningDataset? response = await executor.GetAiPromptFineTuningDatasetGenerationStatus(userId: null, aiPromptId, jobIdentifier);
            
            Assert_AiFineTuningDataset(response);
        }

        [Fact]
        public async Task CreateAiPromptFineTuningJob()
        {
            const int userId = 1;
            const int aiPromptId = 2;

            var request = new CreateAiPromptFineTuningJobRequest
            {
                DryRun = true,
                HyperParameters = new AiHyperParameters
                {
                    BatchSize = 2,
                    LearningRateMultiplier = 0.2f,
                    NEpochs = 200
                },
                TrainingOptions = new AiTrainingOptions
                {
                    ProjectIds = new List<int> { 1, 2, 3 },
                    DateFrom = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                    DateTo = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                    MaxFileSize = 100,
                    MinExamplesCount = 10,
                    MaxExamplesCount = 50
                },
                ValidationOptions = new AiValidationOptions
                {
                    ProjectIds = new List<int> { 1, 2, 3 },
                    DateFrom = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                    DateTo = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                    MaxFileSize = 100,
                    MinExamplesCount = 10,
                    MaxExamplesCount = 50
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_FineTuningDatasets.CreateAiPromptFineTuningJob_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/prompts/{aiPromptId}/fine-tuning/jobs";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FineTuningDatasets.CommonResponses_AiFineTuningJob)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiFineTuningJob? response = await executor.CreateAiPromptFineTuningJob(userId, aiPromptId, request);
            
            Assert_AiFineTuningJob(response);
        }
        
        [Fact]
        public async Task CreateAiPromptFineTuningJob_Enterprise()
        {
            const int aiPromptId = 1;

            var request = new CreateAiPromptFineTuningJobRequest
            {
                DryRun = true,
                HyperParameters = new AiHyperParameters
                {
                    BatchSize = 2,
                    LearningRateMultiplier = 0.2f,
                    NEpochs = 200
                },
                TrainingOptions = new AiTrainingOptions
                {
                    ProjectIds = new List<int> { 1, 2, 3 },
                    DateFrom = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                    DateTo = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                    MaxFileSize = 100,
                    MinExamplesCount = 10,
                    MaxExamplesCount = 50
                },
                ValidationOptions = new AiValidationOptions
                {
                    ProjectIds = new List<int> { 1, 2, 3 },
                    DateFrom = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                    DateTo = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00").ToLocalTime(),
                    MaxFileSize = 100,
                    MinExamplesCount = 10,
                    MaxExamplesCount = 50
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_FineTuningDatasets.CreateAiPromptFineTuningJob_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/prompts/{aiPromptId}/fine-tuning/jobs";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FineTuningDatasets.CommonResponses_AiFineTuningJob)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiFineTuningJob? response = await executor.CreateAiPromptFineTuningJob(userId: null, aiPromptId, request);
            
            Assert_AiFineTuningJob(response);
        }

        [Fact]
        public async Task GetAiPromptFineTuningJobStatus()
        {
            const int userId = 1;
            const int aiPromptId = 2;
            const string jobIdentifier = "id";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/prompts/{aiPromptId}/fine-tuning/jobs/{jobIdentifier}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FineTuningDatasets.CommonResponses_AiFineTuningJob)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiFineTuningJob? response = await executor.GetAiPromptFineTuningJobStatus(userId, aiPromptId, jobIdentifier);
            
            Assert_AiFineTuningJob(response);
        }
        
        [Fact]
        public async Task GetAiPromptFineTuningJobStatus_Enterprise()
        {
            const int aiPromptId = 1;
            const string jobIdentifier = "id";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/prompts/{aiPromptId}/fine-tuning/jobs/{jobIdentifier}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FineTuningDatasets.CommonResponses_AiFineTuningJob)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiFineTuningJob? response = await executor.GetAiPromptFineTuningJobStatus(userId: null, aiPromptId, jobIdentifier);
            
            Assert_AiFineTuningJob(response);
        }

        [Fact]
        public async Task DownloadAiPromptFineTuningDataset()
        {
            const int userId = 1;
            const int aiPromptId = 2;
            const string jobIdentifier = "id";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/prompts/{aiPromptId}/fine-tuning/datasets/{jobIdentifier}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FineTuningDatasets.CommonResponses_DownloadLink)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            DownloadLink? response = await executor.DownloadAiPromptFineTuningDataset(userId, aiPromptId, jobIdentifier);
            
            Assert_DownloadLink(response);
        }
        
        [Fact]
        public async Task DownloadAiPromptFineTuningDataset_Enterprise()
        {
            const int aiPromptId = 1;
            const string jobIdentifier = "id";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/ai/prompts/{aiPromptId}/fine-tuning/datasets/{jobIdentifier}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FineTuningDatasets.CommonResponses_DownloadLink)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            DownloadLink? response = await executor.DownloadAiPromptFineTuningDataset(userId: null, aiPromptId, jobIdentifier);
            
            Assert_DownloadLink(response);
        }

        private static void Assert_AiFineTuningDataset(AiFineTuningDataset? dataset)
        {
            ArgumentNullException.ThrowIfNull(dataset);
            
            Assert.Equal("50fb3506-4127-4ba8-8296-f97dc7e3e0c3", dataset.Identifier);
            Assert.Equal(OperationStatus.Finished, dataset.Status);
            Assert.Equal(100, dataset.Progress);
            
            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");

            AiFineTuningDataset.AttributesObject? attributes = dataset.Attributes;
            ArgumentNullException.ThrowIfNull(attributes);
            Assert.Equal(new[] { 1, 2, 3 }, attributes.ProjectIds);
            Assert.Equal(AiDatasetPurpose.Validation, attributes.Purpose);
            Assert.Equal(date, attributes.DateFrom);
            Assert.Equal(date, attributes.DateTo);
            Assert.Equal(100, attributes.MaxFileSize);
            Assert.Equal(10, attributes.MinExamplesCount);
            Assert.Equal(50, attributes.MaxExamplesCount);
            
            Assert.Equal(date, dataset.CreatedAt);
            Assert.Equal(date, dataset.UpdatedAt);
            Assert.Equal(date, dataset.StartedAt);
            Assert.Equal(date, dataset.FinishedAt);
        }

        private static void Assert_AiFineTuningJob(AiFineTuningJob? job)
        {
            ArgumentNullException.ThrowIfNull(job);
            
            Assert.Equal("50fb3506-4127-4ba8-8296-f97dc7e3e0c3", job.Identifier);
            Assert.Equal(OperationStatus.Finished, job.Status);
            Assert.Equal(100, job.Progress);
            
            AiFineTuningJob.AttributesObject attributes = job.Attributes;
            ArgumentNullException.ThrowIfNull(attributes);
            Assert.True(attributes.DryRun);
            
            AiHyperParameters? hyperParameters = attributes.HyperParameters;
            ArgumentNullException.ThrowIfNull(hyperParameters);
            Assert.Equal(2, hyperParameters.BatchSize);
            Assert.Equal(0.2f, hyperParameters.LearningRateMultiplier);
            Assert.Equal(200, hyperParameters.NEpochs);
            
            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");

            AiTrainingOptions trainingOptions = attributes.TrainingOptions;
            ArgumentNullException.ThrowIfNull(trainingOptions);
            Assert.Equal(new[] { 1, 2, 3 }, trainingOptions.ProjectIds);
            Assert.Equal(date, trainingOptions.DateFrom);
            Assert.Equal(date, trainingOptions.DateTo);
            Assert.Equal(100, trainingOptions.MaxFileSize);
            Assert.Equal(10, trainingOptions.MinExamplesCount);
            Assert.Equal(50, trainingOptions.MaxExamplesCount);
            
            AiValidationOptions? validationOptions = attributes.ValidationOptions;
            ArgumentNullException.ThrowIfNull(validationOptions);
            Assert.Equal(new[] { 1, 2, 3 }, validationOptions.ProjectIds);
            Assert.Equal(date, validationOptions.DateFrom);
            Assert.Equal(date, validationOptions.DateTo);
            Assert.Equal(100, validationOptions.MaxFileSize);
            Assert.Equal(10, validationOptions.MinExamplesCount);
            Assert.Equal(50, validationOptions.MaxExamplesCount);
        }

        private static void Assert_DownloadLink(DownloadLink? link)
        {
            ArgumentNullException.ThrowIfNull(link);
            
            Assert.Equal("https://test.com", link.Url);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T10:31:21+00:00"), link.ExpireIn);
        }
    }
}