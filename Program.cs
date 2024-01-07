using blog_bakend.DTOs.ResponseDTOs;
using blog_bakend.Models;
using blog_bakend.Service.Mongo;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using System.Net;
using blog_bakend.Mappings;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Add Service Configuration
builder.Services.Configure<MongoDBSetting>(builder.Configuration.GetSection("MongoDBSetting"));
builder.Services.AddSingleton<MongoDBService>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddEndpointsApiExplorer();

// Add some swagger config
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    { Title = "Blog_Backend",
      Version = "v1"    
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<IExceptionHandlerFeature>();
        if (error != null)
        {

            var ex = error.Error;

            var errorDto = new ErrorDto()
            {
                ErrorCode = (int)HttpStatusCode.InternalServerError,
                Type = error.GetType().Name,
                Message = ex.Message,
                Trace = ""
            };

            var errorJson = JsonConvert.SerializeObject(errorDto); // Serialize ErrorDto to JSON

            await context.Response.WriteAsync(errorJson, System.Text.Encoding.UTF8);
        }
    });
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
