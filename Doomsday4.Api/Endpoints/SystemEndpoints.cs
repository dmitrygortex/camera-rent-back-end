namespace Doomsday4.Api.Endpoints;

public static class SystemEndpoints
{
    public static WebApplication AddSystemEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/system");

        endpoints.MapGet("/are-you-okay", () =>
            Results.Ok("Test"));
        return app;
    }
}