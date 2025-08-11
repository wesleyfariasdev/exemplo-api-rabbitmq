using MassTransit;

namespace ExemploRabbitMQ.Api.Extensions;

public static class AppExtensions
{
    public static void AddRabbitMQService(this IServiceCollection services, IConfiguration config)
    {
        var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? config["RabbitMQHost:Host"] ?? "my-rabbit";
        var port = Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? config["RabbitMQHost:Port"] ?? "5672";
        var username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? config["RabbitMQHost:Username"] ?? "guest";
        var password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? config["RabbitMQHost:Password"] ?? "guest";

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri($"amqp://{host}:{port}"), h =>
                {
                    h.Username(username);
                    h.Password(password);
                });

                cfg.ConfigureEndpoints(context);
                cfg.UseMessageRetry(r => r.Exponential(10, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(5)));
            });
        });
    }
}