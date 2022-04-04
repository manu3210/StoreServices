using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Persistance;
using StoreServices.Api.ShoppingCart.RemoteInterface;
using StoreServices.Api.ShoppingCart.RemoteServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("Book", config => config.BaseAddress = new Uri(builder.Configuration["Services:Book"]));
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddDbContext<CartContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CartDB")));

builder.Services.AddScoped<IBookService, BookService>();

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

app.Run();
