using Doomsday4.Api.Endpoints;
using Doomsday4.Api.Middlewares;
using Doomsday4.Api.Swagger;
using Doomsday4.Application;
using Doomsday4.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();



// var dataSourceBuilder = new NpgsqlDataSourceBuilder(
//     builder.Configuration.GetConnectionString("DBConnection")
// );
// dataSourceBuilder.EnableDynamicJson();
//
// var dataSource = dataSourceBuilder.Build();
//

builder.Services.AddDbContext<RentDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DBConnection"));
    //options.UseJsonNet();
    //options.UseNpgsql(dataSource);
});


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

// builder.Services.AddDbContext<RentDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DBConnection")));
// уже в Domain.Data

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