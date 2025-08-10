using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using Crowdin.Api.StringCorrections;
using Crowdin.Api.StringTranslations;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.StringCorrections;

public class StringCorrectionsApiTests
{
    private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

    [Fact]
    public async Task ListCorrections()
    {
        const int projectId = 1;
        const int stringId = 10;
        const int limit = 25;
        const int offset = 0;

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        mockClient
            .Setup(client => client.SendGetRequest($"/projects/{projectId}/corrections", It.IsAny<IDictionary<string, string>>()))
            .ReturnsAsync(new CrowdinApiResult
            {
                JsonObject = JObject.Parse(Resources.StringCorrections.ListCorrections_Response)
            });

        var executor = new StringCorrectionsApiExecutor(mockClient.Object);

        ResponseList<Correction> response = await executor.ListCorrections(projectId, stringId, limit: limit, offset: offset);

        Assert.NotNull(response);
        Assert.NotEmpty(response.Data);
            
        Correction firstCorrection = response.Data[0];
        Assert.NotNull(firstCorrection.User);
        Assert.Equal("john_doe", firstCorrection.User.Username);

        mockClient.Verify(client => client.SendGetRequest($"/projects/{projectId}/corrections", 
            It.Is<IDictionary<string, string>>(d => 
                d["stringId"] == stringId.ToString() &&
                d["limit"] == limit.ToString() &&
                d["offset"] == offset.ToString() &&
                d["denormalizePlaceholders"] == "0")), Times.Once);
    }

    [Fact]
    public async Task AddCorrection()
    {
        const int projectId = 1;  
  
        var request = new AddCorrectionRequest  
        {  
           StringId  = "10",
           PluralCategoryName = "few",  
           Text = "This string has been corrected"  
        }; 
       
        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();  
  
        var url = $"/projects/{projectId}/corrections";  
  
        mockClient  
            .Setup(client => client.SendPostRequest(url, request, null))  
            .ReturnsAsync(new CrowdinApiResult  
            {  
                StatusCode = HttpStatusCode.Created,  
                JsonObject = JObject.Parse(Resources.StringCorrections.AddCorrection_Response)  
            });  
  
        var executor = new StringCorrectionsApiExecutor(mockClient.Object);  
        Correction response = await executor.AddCorrection(projectId, request);  
  
        Assert.NotNull(response);  
        Assert.Equal(10, response.Id);  
    }

    [Fact]
    public async Task DeleteCorrection()
    {
        const int projectId = 1;  
        const int correctionId = 10;  
  
        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();  
  
        var url = $"/projects/{projectId}/corrections/{correctionId}";  
  
        mockClient  
            .Setup(client => client.SendDeleteRequest(url, null))  
            .ReturnsAsync(HttpStatusCode.NoContent);  
  
        var executor = new StringCorrectionsApiExecutor(mockClient.Object);  
        await executor.DeleteCorrection(projectId, correctionId);
        mockClient.Verify(client => client.SendDeleteRequest($"/projects/{projectId}/corrections/{correctionId}", null), Times.Once);
    }
    
    [Fact]  
    public async Task DeleteCorrection_Throw()  
    {  
        const int projectId = 1;  
        const int correctionId = 10;  
  
        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();  
  
        var url = $"/projects/{projectId}/corrections/{correctionId}";  
  
        mockClient  
            .Setup(client => client.SendDeleteRequest(url, null))  
            .ReturnsAsync(HttpStatusCode.NotFound);  
  
        var executor = new StringCorrectionsApiExecutor(mockClient.Object);  
  
        await Assert.ThrowsAsync<CrowdinApiException>(async () => await executor.DeleteCorrection(projectId, correctionId));  
    }

    [Fact]
    public async Task DeleteCorrections()
    {
        const int projectId = 1;
        const int stringId = 10;

        var queryParams = new Dictionary<string, string>  
        {  
            ["stringId"] = stringId.ToString()  
        };  
        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
        mockClient
            .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/corrections", queryParams))
            .ReturnsAsync(HttpStatusCode.NoContent);

        var executor = new StringCorrectionsApiExecutor(mockClient.Object);

        await executor.DeleteCorrections(projectId, stringId);

        mockClient.Verify(client => client.SendDeleteRequest($"/projects/{projectId}/corrections", 
            It.Is<IDictionary<string, string>>(d => d["stringId"] == stringId.ToString())), Times.Once);
    }

    [Fact]
    public async Task GetCorrection()
    {
        const int projectId = 1;  
        const int correctionId = 10;  
  
        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();  
  
        var url = $"/projects/{projectId}/corrections/{correctionId}";  
  
        mockClient  
            .Setup(client => client.SendGetRequest(url, null))  
            .ReturnsAsync(new CrowdinApiResult  
            {  
                StatusCode = HttpStatusCode.OK,  
                JsonObject = JObject.Parse(Resources.StringCorrections.GetCorrection_Response)  
            });  
  
        var executor = new StringCorrectionsApiExecutor(mockClient.Object);  
        Correction response = await executor.GetCorrection(projectId, correctionId);  
  
        Assert.NotNull(response);  
        Assert.Equal(correctionId, response.Id);
        
        mockClient.Verify(client => client.SendGetRequest($"/projects/{projectId}/corrections/{correctionId}", null), Times.Once);
    }

    [Fact]
    public async Task RestoreCorrection()
    {
        const int projectId = 1;
        const int correctionId = 10;

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        mockClient
            .Setup(client => client.SendPutRequest($"/projects/{projectId}/corrections/{correctionId}", null))
            .ReturnsAsync(new CrowdinApiResult
            {
                JsonObject = JObject.Parse(Resources.StringCorrections.RestoreCorrection_Response)
            });

        var executor = new StringCorrectionsApiExecutor(mockClient.Object);

        Correction response = await executor.RestoreCorrection(projectId, correctionId);

        Assert.NotNull(response);
        Assert.Equal(10, response.Id);
      
        mockClient.Verify(client => client.SendPutRequest($"/projects/{projectId}/corrections/{correctionId}",null ), Times.Once);
    }
}