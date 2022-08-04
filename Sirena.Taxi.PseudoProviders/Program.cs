using Sirena.Taxi.Core.Abstractions;
using Sirena.Taxi.Core.Kafka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var consumerClass = builder.Configuration.GetSection("Consumer").GetSection("Class").Value;
var consumerType = Type.GetType($"Sirena.Taxi.PseudoProviders.Service.{consumerClass}, Sirena.Taxi.PseudoProviders");
if (consumerType == null) throw new Exception("Некорректно указан тип слушателя");
builder.Services.AddSingleton(typeof(MessageProducer));
builder.Services.AddScoped(typeof(IEntityConsumerService), consumerType);
builder.Services.AddHostedService<TopicConsumer>();

var app = builder.Build();

app.Run();
