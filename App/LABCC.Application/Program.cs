global using FastEndpoints;
global using FastEndpoints.Security; 
    
using FastEndpoints.Swagger;
using LABCC.Domain.Entities.Users;
using LABCC.Domain.Interfaces.Database;
using LABCC.Domain.Interfaces.Repositories;
using LABCC.Domain.Interfaces.Services;
using LABCC.Infrastructure.Configs;
using LABCC.Infrastructure.Database;
using LABCC.Infrastructure.Repositories;

var customConfig = CustomConfig.FromEnv();

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddFastEndpoints(options =>
    options
        .SourceGeneratorDiscoveredTypes = DiscoveredTypes.All);

builder.Services.AddJWTBearerAuth(customConfig["Jwt-Secret"]);
builder.Services.SwaggerDocument();

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new MsSqlConnectionFactory(customConfig["Connection-String"]));

builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints(c => c.Endpoints.RoutePrefix = "api/v1");
app.UseSwaggerGen();

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();