using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tasko.Api.Repository;

namespace Tasko.Api.Domain.Extensions
{
  public static class WebApplicationBuilderExtension
  {
    private const string SQL_CONNECTION_STRING_SECTION = "SqlServerConnection";

    public static WebApplicationBuilder LoadConfigurationData(this WebApplicationBuilder builder)
    {
      return builder;
    }

    /// <summary>
    /// This method load some configurations into WebApplicationBuilder. Like: MVC and others
    /// </summary>
    /// <returns>WebApplicationBuilder with configurations</returns>
    public static WebApplicationBuilder ConfigureMvc(this WebApplicationBuilder builder)
    {
      builder.Services.AddControllers();
      return builder;
    }

    public static WebApplicationBuilder AddDependencyInjection(this WebApplicationBuilder builder)
    {
      var connectionString = builder.Configuration.GetConnectionString(SQL_CONNECTION_STRING_SECTION);
      builder.Services.AddDbContext<ApplicationDataContext>(options => options.UseSqlServer(connectionString));
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