using System.Text;
using RabbitMQ.Client;

//Create connection
ConnectionFactory factory = new();
factory.Uri = new Uri("amqps://ddmxhagm:7jYQOH-lm2u1Hm3-EoVlwQEsftiuIkLt@chimpanzee.rmq.cloudamqp.com/ddmxhagm");

//Activating the connection and opening a channel
using IConnection connection =factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queuing
channel.QueueDeclare(queue: "example-queue",exclusive:false);



//Send a message to the queue
for (int i = 0; i < 100; i++)
{
    await Task.Delay(200);
    byte[] message = Encoding.UTF8.GetBytes("Hello World" + i);
    channel.BasicPublish(exchange:"",routingKey:"example-queue",body:message);
}

Console.Read();