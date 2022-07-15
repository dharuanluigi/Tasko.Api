using Tasko.Api.Domain.Extensions;
using Tasko.Api.Domain.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureMvc();
builder.ConfigureResources();

var app = builder.Build();

app.UseMiddleware<ErrorHandleMiddleware>();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();