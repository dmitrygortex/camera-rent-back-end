namespace Doomsday4.Endpoints;

public static class SystemEndpoints
{
    public static WebApplication AddSystemEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/system");

        endpoints.MapGet("/are-you-okay", () =>
            Task.FromResult(Results.Ok("I'm okay!)")));
        return app;
    }
}