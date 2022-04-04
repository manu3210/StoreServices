using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using StoreServices.Api.Gateway.ImplementRemote;
using StoreServices.Api.Gateway.MessageHandler;
using StoreServices.Api.Gateway.RemoteInterface;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"ocelot.json");
});

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddOcelot().AddDelegatingHandler<BookHandler>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("AuthorService", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Author"]);
});

var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetService<ILogger<RemoteAuthor>>();

builder.Services.AddSingleton(typeof(ILogger), logger);

builder.Services.AddSingleton<IAutorRemote, RemoteAuthor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();


app.Run();
