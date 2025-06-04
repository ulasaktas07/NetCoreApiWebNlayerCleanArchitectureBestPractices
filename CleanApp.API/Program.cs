using App.Aplication.Extensions;
using App.Persistence.Extensions;
using CleanApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithFiltersExt().AddSwaggerExt().AddExceptionHandlerExt().AddCachingExt(); // Custom extension method to add controllers with filters

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddRepositories(builder.Configuration).AddServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCustomPipelineeExt(); // Custom extension method to use custom pipeline

app.MapControllers();

app.Run();
