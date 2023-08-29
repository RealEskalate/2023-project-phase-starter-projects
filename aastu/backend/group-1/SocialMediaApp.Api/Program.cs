using SocialMediaApp.Persistence;
using SocialMediaApp.Application;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

using SocialMediaApp.Infrastructure;
using Microsoft.Extensions.Hosting;
using SocialMediaApp.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Hosting;
using SocialMediaApp.Domain;
using SocialMediaApp.Api.Middleware;
using SocialMediaApp.Api.Filters;
using SocialMediaApp.Api;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);




AddSwaggerDoc(builder.Services);


// Add services to the container.
//options => options.Filters.Add<ErrorHandlingFilterAttribute>()
builder.Services.AddControllers();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
//builder.Services.ConfigureInfrastructureServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services

    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void AddSwaggerDoc(IServiceCollection services)
{
    services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Social Media Api",
        });
    });
}

public partial class Program { }