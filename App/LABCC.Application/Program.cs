global using FastEndpoints;
global using FastEndpoints.Security; 
using FastEndpoints.Swagger;
    
var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
    
builder.Services.AddFastEndpoints();
builder.Services.AddJWTBearerAuth(config.GetValue<string>("Jwt:Token")!);
builder.Services.SwaggerDocument();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();