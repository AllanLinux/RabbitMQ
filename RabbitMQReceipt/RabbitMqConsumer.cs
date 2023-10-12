using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

public class RabbitMqConsumer
{
    private readonly string _hostname;
    private readonly string _queueName;
    private readonly string _username;
    private readonly string _password;

    public RabbitMqConsumer(string hostname, string queueName, string username, string password)
    {
        _hostname = hostname;
        _queueName = queueName;
        _username = username;
        _password = password;
    }

    public void StartListening()
    {
        var factory = new ConnectionFactory()
        {
            HostName = _hostname,
            UserName = _username,
            Password = _password
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: _queueName,
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            using ApplicationDbContext _db = new();

            Produto? produto = JsonConvert.DeserializeObject<Produto>(message);

            if (produto != null)
            {
                _db.Produtos.Add(produto);
                _db.SaveChanges();
                Console.WriteLine($" [x] Recebido: {message}");
            }
            else
            {
                Console.WriteLine("Falha na deserialização do produto");
            }

        };

        channel.BasicConsume(queue: _queueName,
                             autoAck: true,
                             consumer: consumer);

        Console.WriteLine(" Pressione [enter] para sair.");
        Console.ReadLine();
    }
}
