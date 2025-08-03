namespace _1Breadcrumb.Api.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private const string API_KEY_HEADER_NAME = "X-API-KEY";

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Allow access to Swagger
        var path = context.Request.Path.Value;
        if (path.StartsWith("/swagger") || path.Contains("swagger.json"))
        {
            await _next(context);
            return;
        }

        var expectedApiKey = _configuration["ApiKey"];

        if (!context.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var extractedApiKey) ||
            extractedApiKey != expectedApiKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid or missing API key.");
            return;
        }

        await _next(context);
    }
}