using DapperSample.Api.Data;
using DapperSample.Api.Interfaces;
using DapperSample.Api.Models;
using DapperSample.Api.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<FruitContext>(options =>
// {
//     options.UseNpgsql(builder
//         .Configuration
//         .GetConnectionString("Fruits"));
// });

builder.Services.AddSingleton<IConnectionStringOption, ConnectionStringOption>(_ =>
{
    return new ConnectionStringOption
    {
        ConnectionString = builder.Configuration.GetValue<string>(ConnectionStringOption.Name)
    };
});
builder.Services.AddSingleton<IDbContext, FruitContext>();
builder.Services.AddScoped<IRepository<Fruit>, FruitRepository>();



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
