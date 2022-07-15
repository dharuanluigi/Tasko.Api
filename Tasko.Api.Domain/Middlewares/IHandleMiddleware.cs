namespace Tasko.Api.Domain.Middlewares
{
  /// <summary>
  /// Middlewares interface
  /// </summary>
  public interface IHandleMiddleware
  {
    Task InvokeAsync(HttpContext context);
  }
}