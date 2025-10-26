using Scalar.AspNetCore;
using System.Text.Json.Serialization;
using ZenBlog.API.CustomMiddlewares;
using ZenBlog.API.EndpointRegistration;
using ZenBlog.Application.Extensions;
using ZenBlog.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(cfg =>
    {
        cfg.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddControllers();
//1.Yontem Ignore Cycle JsonSerializer Options --> controller kullanmadýðýmýz için bunu yöntemi kullanýyoruz. Alltaki configurehttpjson yerine addjsonOptions kullanýrdýk ve serializeroptions parametresi yerine jsonserializeroptions kullanýrdýk.
//builder.Services.AddControllers().AddJsonOptions(config =>
//{
//    config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//});


//2.Yöntem Minimal Api kullanýmýnda Ignore Cycle Yöntemi

builder.Services.ConfigureHttpJsonOptions(config =>
{
    config.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<CustomExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGroup("/api")
    .RegisterEndpoints();

app.Run();
