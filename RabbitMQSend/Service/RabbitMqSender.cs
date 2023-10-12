using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;

public class RabbitMqSender
{
    private readonly string _hostname = "srv.allanlf.com.br";
    private readonly string _queueName = "QueueTeste";
    private readonly string _username = "usertest";
    private readonly string _password = "2245678";

    public void SendMessage(string message)
    {
        ConnectionFactory factory = NewMethod();
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(
            queue: _queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
            );
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);
    }    

    public void SendProduct(Produto produto) 
    {

        ConnectionFactory factory = NewMethod();

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = JsonConvert.SerializeObject(produto);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);
    }

    private ConnectionFactory NewMethod()
    {
        return new ConnectionFactory()
        {
            HostName = _hostname,
            UserName = _username,
            Password = _password
        };
    }
    
}