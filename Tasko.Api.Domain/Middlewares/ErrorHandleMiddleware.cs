using System.Net.Mime;
using Tasko.Api.Models.Responses;

namespace Tasko.Api.Domain.Middlewares
{
  public class ErrorHandleMiddleware : IHandleMiddleware
  {
    private const bool FAILED_REQUEST_RESULT = false;

    private readonly RequestDelegate _next;

    public ErrorHandleMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception exception)
      {
        await HandleExceptionAsync(context, exception);
      }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      context.Response.StatusCode = StatusCodes.Status500InternalServerError;
      context.Response.ContentType = MediaTypeNames.Application.Json;

      var response = string.Empty;

      switch (exception)
      {
        case ApplicationException ex:
          response = new ErrorResponse(FAILED_REQUEST_RESULT, ex.Message).ToString();
          break;
        default:
          response = new ErrorResponse(FAILED_REQUEST_RESULT, exception.Message).ToString();
          break;
      }

      await context.Response.WriteAsync(response);
    }
  }
}