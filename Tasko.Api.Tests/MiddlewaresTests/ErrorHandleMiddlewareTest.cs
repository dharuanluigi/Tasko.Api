using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using NSubstitute;
using NSubstitute.Extensions;

namespace Tasko.Api.Tests.MiddlewaresTests
{
  public class ErrorHandleMiddlewareTest
  {
    [Fact]
    public async Task Should_NOT_COMPLETE_request_when_operation_was_throws_an_exception()
    {
      Assert.False(true);
    }

    [Fact]
    public async Task Should_COMPLETE_request_when_operation_was_NOT_throws_an_exception()
    {
      Assert.False(true);
    }
  }
}