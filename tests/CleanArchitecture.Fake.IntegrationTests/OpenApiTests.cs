using CleanArchitecture.Api;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Readers;

using Xunit.Abstractions;

namespace CleanArchitecture.Fake.IntegrationTests;

public class OpenApiTests : IClassFixture<WebApplicationFactory<WebMarker>>
{
    private readonly HttpClient _httpClient;
    private readonly ITestOutputHelper _output;

    public OpenApiTests(WebApplicationFactory<WebMarker> factory, ITestOutputHelper output)
    {
        _httpClient = factory.CreateDefaultClient();
        _output = output;
    }

    [Fact]
    public async Task GetOpenApi_Ok()
    {
        var response = await _httpClient.GetAsync($"/swagger/{ApiInfo.Version}/swagger.json");

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetOpenApi_ResurnsOpenApiSpecification()
    {
        var stream = await _httpClient.GetStreamAsync($"/swagger/{ApiInfo.Version}/swagger.json");

        var openApiDocument = new OpenApiStreamReader().Read(stream, out var _);

        var outputString = openApiDocument.Serialize(OpenApiSpecVersion.OpenApi3_0, OpenApiFormat.Json);
        _output.WriteLine(outputString);

    }
}