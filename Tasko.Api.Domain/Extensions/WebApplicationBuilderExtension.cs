namespace Tasko.Api.Domain.Extensions
{
  public static class WebApplicationBuilderExtension
  {
    /// <summary>
    /// This method load some configurations into WebApplicationBuilder. Like: MVC and others
    /// </summary>
    /// <returns>WebApplicationBuilder with configurations</returns>
    public static WebApplicationBuilder ConfigureMvc(this WebApplicationBuilder builder)
    {
      builder.Services.AddControllers();
      return builder;
    }

    /// <summary>
    /// This method configure resources into application. Like: swagger docs, cache, compression...
    /// </summary>
    /// <returns>WebApplication with some resources</returns>
    public static WebApplicationBuilder ConfigureResources(this WebApplicationBuilder builder)
    {
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();
      return builder;
    }
  }
}