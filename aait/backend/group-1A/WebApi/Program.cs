using Application;
using Persistence;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.ConfigurePersistenceService(builder.Configuration);
builder.Services.ConfigureApplicationServices();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

// app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
