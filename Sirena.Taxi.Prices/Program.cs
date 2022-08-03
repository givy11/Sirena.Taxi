using Microsoft.EntityFrameworkCore;
using Sirena.Taxi.Core.Abstractions.Repositories;
using Sirena.Taxi.Prices.Domain;
using Sirena.Taxi.Prices.Kafka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("SirenaDb"));
    x.UseSnakeCaseNamingConvention();
    x.UseLazyLoadingProxies();
});
builder.Services.AddScoped(typeof(DbContext), typeof(DataContext));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddSingleton(typeof(MessageProducer));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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