using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using Crowdin.Api.StringCorrections;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.StringCorrections;

public class StringCorrectionsApiTests
{
    private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

    [Fact]
    public async Task ListCorrections_ShouldReturnCorrections()
    {
        const int projectId = 1;
        const int stringId = 2;
        const int limit = 25;
        const int offset = 0;

        var corrections = new[]
        {
            new Correction
            {
                Id = 1,
                Text = "This string has been corrected",
                PluralCategoryName = "few",
                User = new CorrectionUser
                {
                    Id = 5,
                    Username = "john_doe",
                    FullName = "John Doe",
                    AvatarUrl = "https://example.com/avatar.png"
                },
                CreatedAt = DateTimeOffset.Parse("2023-10-01T12:00:00Z"),
            }
        };

        JObject responseObject = JObject.FromObject(new
        {
            data = corrections,
            pagination = new { offset, limit }
        }, JsonSerializer.Create(DefaultSettings));

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        mockClient
            .Setup(client =>
                client.SendGetRequest($"/projects/{projectId}/corrections", It.IsAny<IDictionary<string, string>>()))
            .ReturnsAsync(new CrowdinApiResult { JsonObject = responseObject });

        var executor = new StringCorrectionsApiExecutor(mockClient.Object);

        ResponseList<Correction> response = await executor.ListCorrections(projectId, stringId, limit: limit, offset: offset);

        Assert.NotNull(response);
        mockClient.Verify(client => client.SendGetRequest($"/projects/{projectId}/corrections",
            It.Is<IDictionary<string, string>>(d =>
                d["stringId"] == stringId.ToString() &&
                d["limit"] == limit.ToString() &&
                d["offset"] == offset.ToString())), Times.Once);
    }

    [Fact]
    public async Task AddCorrection_ShouldReturnCreatedCorrection()
    {
        const int projectId = 1;
        var request = new AddCorrectionRequest
        {
            StringId = "2",
            PluralCategoryName  = "few",
            Text = "This string has been corrected",
        };

        var createdCorrection = new Correction
        {
            Id = 10,
            Text = "This string has been corrected",
            PluralCategoryName = "few",
            User = new CorrectionUser()
            {
                AvatarUrl = "",
                FullName = "John Doe",
                Username = "john_doe",
                Id = 5
            },
            CreatedAt = DateTimeOffset.Parse("2023-10-01T12:00:00Z"),
        };

        JObject responseObject =
            JObject.FromObject(new { data = createdCorrection }, JsonSerializer.Create(DefaultSettings));

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        mockClient
            .Setup(client => client.SendPostRequest($"/projects/{projectId}/corrections", request, null))
            .ReturnsAsync(new CrowdinApiResult { JsonObject = responseObject });

        var executor = new StringCorrectionsApiExecutor(mockClient.Object);

        Correction response = await executor.AddCorrection(projectId, request);

        Assert.NotNull(response);
        Assert.Equal(createdCorrection.Id, response.Id);
        
        mockClient.Verify(client => client.SendPostRequest($"/projects/{projectId}/corrections", request, null), Times.Once);
    }

    [Fact]
    public async Task DeleteCorrection_ShouldCallDeleteEndpoint()
    {
        const int projectId = 1;
        const int correctionId = 10;

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
        var mockResponse = HttpStatusCode.NoContent;
            
        mockClient
            .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/corrections/{correctionId}", null))
            .ReturnsAsync(mockResponse);

        var executor = new StringCorrectionsApiExecutor(mockClient.Object);

        await executor.DeleteCorrection(projectId, correctionId);

        mockClient.Verify(client => client.SendDeleteRequest($"/projects/{projectId}/corrections/{correctionId}", null), Times.Once);
    }
    
    [Fact]
    public async Task DeleteCorrection_ShouldThrowOnNon204Status()
    {
        const int projectId = 1;
        const int correctionId = 10;

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
        mockClient
            .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/corrections/{correctionId}", null))
            .ReturnsAsync(HttpStatusCode.NotFound);

        var executor = new StringCorrectionsApiExecutor(mockClient.Object);

        var exception = await Assert.ThrowsAsync<CrowdinApiException>(
            () => executor.DeleteCorrection(projectId, correctionId));
            
        Assert.Contains($"Correction {correctionId} removal failed", exception.Message);
            
        mockClient.Verify(client => client.SendDeleteRequest($"/projects/{projectId}/corrections/{correctionId}", null), Times.Once);
    }
    
    [Fact]
    public async Task DeleteCorrections_ShouldCallDeleteEndpoint()
    {
        const int projectId = 1;
        const int stringId = 10;

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
        var mockResponse = HttpStatusCode.NoContent;
            
        mockClient
            .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/corrections", null))
            .ReturnsAsync(mockResponse);

        var executor = new StringCorrectionsApiExecutor(mockClient.Object);

        await executor.DeleteCorrections(projectId, stringId);

        mockClient.Verify(client => client.SendDeleteRequest($"/projects/{projectId}/corrections", null), Times.Once);
    }
    
    [Fact]
    public async Task GetCorrection_ShouldReturnCorrection()
    {
        const int projectId = 1;
        const int correctionId = 10;

        var correction = new Correction
        {
            Id = 1,
            Text = "This string has been corrected",
            PluralCategoryName = "few",
            User = new CorrectionUser
            {
                Id = 5,
                Username = "john_doe",
                FullName = "John Doe",
                AvatarUrl = "https://example.com/avatar.png"
            },
            CreatedAt = DateTimeOffset.Parse("2023-10-01T12:00:00Z"),
        };

        JObject responseObject = JObject.FromObject(new { data = correction }, JsonSerializer.Create(DefaultSettings));

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        mockClient
            .Setup(client => client.SendGetRequest($"/projects/{projectId}/corrections/{correctionId}", null))
            .ReturnsAsync(new CrowdinApiResult { JsonObject = responseObject });

        var executor = new StringCorrectionsApiExecutor(mockClient.Object);

        Correction response = await executor.GetCorrection(projectId, correctionId);

        Assert.NotNull(response);
        Assert.Equal(correction.Id, response.Id);

        mockClient.Verify(client => client.SendGetRequest($"/projects/{projectId}/corrections/{correctionId}", null), Times.Once);
    }

    [Fact]
    public async Task RestoreCorrection_ShouldReturnRestoredCorrection()
    {
        // Arrange
        const int projectId = 1;
        const int correctionId = 10;

        var restoredCorrection = new Correction
        {
            Id = correctionId,
            Text = "Restored correction text",
            PluralCategoryName = "few",
            User = new CorrectionUser
            {
                Id = 5,
                Username = "john_doe",
                FullName = "John Doe",
                AvatarUrl = "https://example.com/avatar.png"
            },
            CreatedAt = DateTimeOffset.Parse("2023-10-01T12:00:00Z"),
        };

        JObject responseObject =
            JObject.FromObject(new { data = restoredCorrection }, JsonSerializer.Create(DefaultSettings));

        Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        mockClient
            .Setup(client => client.SendPutRequest($"/projects/{projectId}/corrections/{correctionId}", null))
            .ReturnsAsync(new CrowdinApiResult { JsonObject = responseObject });

        var executor = new StringCorrectionsApiExecutor(mockClient.Object);

        Correction response = await executor.RestoreCorrection(projectId, correctionId);

        Assert.NotNull(response);
        Assert.Equal(restoredCorrection.Id, response.Id);
        Assert.Equal(restoredCorrection.User.Username, response.User.Username);

        mockClient.Verify(client => client.SendPutRequest($"/projects/{projectId}/corrections/{correctionId}", null),
            Times.Once);
    }
}