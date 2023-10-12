// See https://aka.ms/new-console-template for more information
public class Program {
    public static void Main(string[] args) {
        RabbitMqConsumer consumer = new("srv.allanlf.com.br", "QueueTeste", "usertest", "2245678");
        consumer.StartListening();
    }
}