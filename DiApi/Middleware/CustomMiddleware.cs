using DiApi.Utility;

namespace DiApi.Middleware;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IOperationSingleton _singleton;
    private readonly IOperationTransient _transient;
    
    public CustomMiddleware(RequestDelegate next, IOperationTransient transient, IOperationSingleton singleton)
    {
        _next = next;
        _transient = transient;
        _singleton = singleton;
    }

    public async Task InvokeAsync(HttpContext context, IOperationScoped scoped)
    {
        Console.WriteLine(
            $"Middleware; TransientId: {_transient.OperationId} ScopedId: {scoped.OperationId} SingletonId: {_singleton.OperationId}");
        await _next(context);
    }
    
}

public static class CustomMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleware>();
    }
}