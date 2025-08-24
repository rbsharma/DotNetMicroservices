using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlatformService.Data;
using PlatformService.SyncServices.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options =>
{
	options.UseInMemoryDatabase("PlatformDb");
});

// Register Repositories for specific entities
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlatformService", Version = "v1" });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformService v1"));
}

app.UseHttpsRedirection();
app.MapControllers();

await PrepData.PrepPopulationAsync(app);

Console.WriteLine($"CommandService Endpoint: {builder.Configuration["CommandServiceEndpoint"]}");

app.Run();