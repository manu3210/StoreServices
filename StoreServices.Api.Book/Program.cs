using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Application;
using StoreServices.Api.Book.Persistance;
using StoreServices.RabbitMQ.Bus.BusRabbit;
using StoreServices.RabbitMQ.Bus.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreateBook>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<BookContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BookDB")));
builder.Services.AddTransient<IRabbitEventBus, RabbitEventBus>();

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
