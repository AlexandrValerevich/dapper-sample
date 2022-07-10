using DapperSample.Api.Data;
using DapperSample.Api.Interfaces;
using DapperSample.Api.Models;
using DapperSample.Api.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
