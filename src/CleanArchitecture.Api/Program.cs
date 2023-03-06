using CleanArchitecture.Api;
using CleanArchitecture.Application;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
    builder.Services.AddEndpointsApiExplorer();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint($"/swagger/{ApiInfo.Version}/swagger.json", ApiInfo.Version);
            options.RoutePrefix = string.Empty;
        });
    }

    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    // app.UseEndpoints(endpoint =>
    // {
    //     endpoint.MapHealthChecks("/health/live", new HealthCheckOptions
    //     {
    //         AllowCachingResponses = false,
    //         Predicate = _ => false
    //     })
    // });

    app.MapControllers();
    app.Run();
}