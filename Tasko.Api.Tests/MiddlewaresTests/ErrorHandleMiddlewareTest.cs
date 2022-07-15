using System.Text.Json;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Shouldly;
using Tasko.Api.Domain.Middlewares;
using Tasko.Api.Models.Responses;
using Xunit;

namespace Tasko.Api.Tests.MiddlewaresTests
{
  public class ErrorHandleMiddlewareTest
  {
    private const long STREAM_POINTER_START_POSITION = 0;
    private readonly RequestDelegate _next;
    private readonly DefaultHttpContext _context;

    public ErrorHandleMiddlewareTest()
    {
      _next = Substitute.For<RequestDelegate>();
      _context = new DefaultHttpContext();
      _context.Response.Body = new MemoryStream();
    }

    [Fact]
    public async Task Should_NOT_COMPLETE_request_when_operation_was_throws_an_exception()
    {
      _next.Invoke(_context).Returns(Task.FromException(new Exception()));
      var middleware = new ErrorHandleMiddleware(_next);
      await middleware.InvokeAsync(_context).ShouldNotThrowAsync();
      _context.Response.Body.Seek(STREAM_POINTER_START_POSITION, SeekOrigin.Begin);

      _context.Response.StatusCode.ShouldBe(StatusCodes.Status500InternalServerError);

      var body = _context.Response.Body;
      var jsonBody = JsonSerializer.Deserialize<ErrorResponse>(body);
      jsonBody.ShouldBeOfType<ErrorResponse>();
      jsonBody.IsSuccess.ShouldBeFalse();
    }

    [Fact]
    public async Task Should_COMPLETE_request_when_operation_was_NOT_throws_an_exception()
    {
      _context.Response.Body = new MemoryStream();

      _next.Invoke(_context).Returns(Task.CompletedTask);
      _context.Response.Body.Seek(STREAM_POINTER_START_POSITION, SeekOrigin.Begin);

      var middleware = new ErrorHandleMiddleware(_next);

      await middleware.InvokeAsync(_context).ShouldNotThrowAsync();
      Assert.True(_context.Response.StatusCode != StatusCodes.Status500InternalServerError);
    }
  }
}