using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tasko.Api.Models.Constants;
using Tasko.Api.Models.Responses;

namespace Tasko.Api.Domain.Attributes
{
  [AttributeUsage(validOn: AttributeTargets.Class)]
  public class ApiKeyAttribute : Attribute, IAsyncActionFilter
  {
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      var apiSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
      var keyName = apiSettings.GetValue<string>("ApiKeyName");
      var keyValue = apiSettings.GetValue<string>("ApiKey");

      if (context.HttpContext.Request.Headers.TryGetValue(keyName, out var keyValueRetrived)
            && keyValue.Equals(keyValueRetrived))
      {
        await next();
      }

      context.Result = new ContentResult()
      {
        StatusCode = StatusCodes.Status401Unauthorized,
        ContentType = MediaTypeNames.Application.Json,
        Content = new ErrorResponse(ResponseProcess.FAILED_RESPONSE, ResponseProcess.UNAUTHORIZED_MESSAGE).ToString()
      };
    }
  }
}