var builder = WebApplication.CreateBuilder(args) ;
builder.Services.AddEndpointsApiExplorer () ;
builder.Services.AddSwaggerGen () ;
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!").WithOpenApi(operation => new(operation)
 { Summary = "This is a summary", Description = "This is a description" });
app.Run();