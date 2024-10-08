using Doomsday4.Api.Endpoints;
using Doomsday4.Api.Middlewares;
using Doomsday4.Api.Swagger;
using Doomsday4.Application;
using Doomsday4.Domain.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHealthChecks();

builder.Services.AddCors();

builder.SetupSwagger();

builder.Services.Configure<RouteOptions>(
    options =>
    {
        options.LowercaseUrls = true;
        options.LowercaseQueryStrings = true;
    }
);


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHealthChecks("/health");

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

//Endpoints
app.AddSystemEndpoints();
app.AddUserEndpoints();
app.AddEquipmentEndpoints();
app.AddOrderEndpoints();

app.Run();