namespace Tasko.Api.Domain.Middlewares.Interfaces
{
  /// <summary>
  /// Middlewares interface
  /// </summary>
  public interface IHandleMiddleware
  {
    Task InvokeAsync(HttpContext context);
  }
}