using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using Crowdin.Api.Fields;
using Crowdin.Api.Tests.Testing;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Fields;

public class FieldsApiTest
{
    private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
    
    [Fact]
    public async Task ListFields()
    {
        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        var url = "/fields";
        IDictionary<string, string> queryParams =
            new FieldsListParams(limit: 25, offset: 0, search: null, entity: FieldEntity.Task, type: FieldType.Select)
                .ToQueryParams();

        mockClient
            .Setup(client => client.SendGetRequest(url, queryParams))
            .ReturnsAsync(new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = JObject.Parse(Testing.Resources.Fields.ListFields_Response)
            });

        var executor = new FieldsApiExecutor(mockClient.Object);
        ResponseList<Field>? response = await executor.ListFields(null, FieldEntity.Task, FieldType.Select);

        Assert.NotNull(response);
        Assert.Equal(2, response.Data.Count);
        
        var field = response.Data[0];
        Assert.Equal("Custom field", field.Name);
        Assert.Equal(FieldType.Select, field.Type);
        Assert.Equal(FieldEntity.Task, field.Entities[0]);
        Assert.IsType<ListFieldConfig>(field.Config);
        ListFieldConfig listFieldConfig = (ListFieldConfig)field.Config;
        Assert.Equal("string", listFieldConfig.Options[0].Label);
        Assert.Equal(Place.ProjectCreateModal, listFieldConfig.Locations[0].Place);
        
        field = response.Data[1];
        Assert.Equal("Client company", field.Name);
        Assert.Equal(FieldType.Select, field.Type);
        Assert.Equal(FieldEntity.Task, field.Entities[0]);
        Assert.IsType<NumberFieldConfig>(field.Config);
        NumberFieldConfig numberFieldConfig = (NumberFieldConfig)field.Config;
        Assert.Equal(0, numberFieldConfig.Min);
        Assert.Equal(10, numberFieldConfig.Max);
        Assert.Equal(Place.ProjectCreateModal, numberFieldConfig.Locations[0].Place);
    }

    [Fact]
    public async Task AddField()
    {
        var url = "/fields";
        var request = new AddFieldRequest
        {
            Name = "Client Corp",
            Slug = "Client Corp",
            Type = FieldType.Select,
            Description = "Client corp field is appointed to store info about client corp",
            Entities = new[] { FieldEntity.Task },
            Config = new ListFieldConfig
            {
                Options = new[]
                {
                    new Option
                    {
                        Label = "str",
                        Value = "str"
                    }
                },
                Locations = new[]
                {
                    new Location
                    {
                        Place = Place.ProjectCreateModal
                    }
                }
            }
        };

        string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
        string expectedResultJson = TestUtils.CompactJson(Testing.Resources.Fields.AddField_Request);
        Assert.Equal(expectedResultJson, actualRequestJson);

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        mockClient
            .Setup(client => client.SendPostRequest(url, request, null))
            .ReturnsAsync(new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.Created,
                JsonObject = JObject.Parse(Testing.Resources.Fields.AddAndGetField_Response)
            });

        var executor = new FieldsApiExecutor(mockClient.Object);
        Field? response = await executor.AddField(request);
        
        Assert_AddAndGetField(response);
    }

    [Fact]
    public async Task GetField()
    {
        const int fieldId = 3;
        var url = $"/fields/{fieldId}";

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        mockClient
            .Setup(client => client.SendGetRequest(url, null))
            .ReturnsAsync(new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = JObject.Parse(Testing.Resources.Fields.AddAndGetField_Response)
            });

        var executor = new FieldsApiExecutor(mockClient.Object);
        Field? response = await executor.GetField(fieldId);
        
        Assert_AddAndGetField(response);
    }

    [Fact]
    public async Task DeleteField()
    {
        const int fieldId = 4;
        var url = $"/fields/{fieldId}";
        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        mockClient
            .Setup(client => client.SendDeleteRequest(url, null))
            .ReturnsAsync(HttpStatusCode.NoContent);

        var executor = new FieldsApiExecutor(mockClient.Object);
        await executor.DeleteField(fieldId);
    }

    [Fact]
    public async Task EditField()
    {
        const int fieldId = 2;
        var url = $"/fields/{fieldId}";

        var patches = new[]
        {
            new FieldPatch
            {
                Operation = PatchOperation.Replace,
                Path = FieldPatchPath.Name,
                Value = "UpdateClientCompanyName"
            },
            new FieldPatch
            {
                Operation = PatchOperation.Replace,
                Path = FieldPatchPath.Config,
                Value = new ListFieldConfig
                {
                    Options = new Option[]
                    {
                        new Option
                        {
                            Label = "UpdatedLabel",
                            Value = "UpdatedValue"
                        }
                    },
                    Locations = new Location[]
                    {
                        new Location
                        {
                            Place = Place.ProjectDetails
                        }
                    }
                }
            },
            new FieldPatch
            {
                Operation = PatchOperation.Replace,
                Path = FieldPatchPath.Entities,
                Value = new []
                {
                    FieldEntity.Project,
                    FieldEntity.Task
                }
            }
        };

        string actualRequestJSon = JsonConvert.SerializeObject(patches, DefaultSettings);
        string expectedRequestJSon = TestUtils.CompactJson(Testing.Resources.Fields.EditField_Request, DefaultSettings);
        Assert.Equal(expectedRequestJSon, actualRequestJSon);

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        mockClient
            .Setup(client => client.SendPatchRequest(url, patches, null))
            .ReturnsAsync(new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = JObject.Parse(Testing.Resources.Fields.EditField_Response)
            });

        var executor = new FieldsApiExecutor(mockClient.Object);
        Field? response = await executor.EditField(fieldId, patches);
        
        Assert.Equal("UpdateClientCompanyName", response.Name);
        Assert.IsType<ListFieldConfig>(response.Config);
        ListFieldConfig listFieldConfig = (ListFieldConfig)response.Config;
        Assert.Equal("UpdatedLabel", listFieldConfig.Options[0].Label);
        Assert.Equal("UpdatedValue", listFieldConfig.Options[0].Value);
        Assert.Equal(Place.ProjectDetails, listFieldConfig.Locations[0].Place);

        var entities = response.Entities;
        Assert.Equal(2, entities.Length);
        Assert.Equal(FieldEntity.Project, entities[0]);
        Assert.Equal(FieldEntity.Task, entities[1]);
    }

    private static void Assert_AddAndGetField(Field response)
    {
        Assert.Equal(3, response.Id);
        Assert.Equal("Client Corp", response.Name);
        Assert.IsType<ListFieldConfig>(response.Config);
        ListFieldConfig listFieldConfig = (ListFieldConfig)response.Config;
        Assert.Equal("str", listFieldConfig.Options[0].Label);
        Assert.Equal("str", listFieldConfig.Options[0].Value);
        Assert.Equal(Place.ProjectCreateModal, listFieldConfig.Locations[0].Place);
    }
    
}