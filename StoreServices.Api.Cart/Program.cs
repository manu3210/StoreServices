using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Cart.Persistance;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
    //.AddJsonOptions(x =>
                //x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddDbContext<CartContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CartDB")));

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
