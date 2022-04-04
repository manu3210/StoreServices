using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Author.Persistance;
using StoreServices.Api.Author.RabbitHandler;
using StoreServices.RabbitMQ.Bus.BusRabbit;
using StoreServices.RabbitMQ.Bus.EventQueue;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreateAuthor>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<AuthorContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDB")));
builder.Services.AddTransient<IEventHandler<EmailEventQueue>, EmailHandler>();


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
