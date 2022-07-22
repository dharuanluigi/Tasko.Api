namespace Tasko.Api.Models.Responses
{
  public class ErrorResponse : ResponseBase
  {
    public ErrorResponse(bool isSuccess, string message) : base(isSuccess, message)
    {
    }
  }
}