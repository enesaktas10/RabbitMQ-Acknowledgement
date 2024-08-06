using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//Create connection
ConnectionFactory factory = new();
factory.Uri = new Uri("amqps://ddmxhagm:7jYQOH-lm2u1Hm3-EoVlwQEsftiuIkLt@chimpanzee.rmq.cloudamqp.com/ddmxhagm");

//Activating the connection and opening a channel
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queuing
channel.QueueDeclare(queue: "example-queue", exclusive: false);

//Creating consumer
EventingBasicConsumer consumer = new(channel);

//Reading message from queue
channel.BasicConsume(queue: "example-queue", autoAck: false, consumer: consumer);
consumer.Received += (sender, e) =>
{
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
    channel.BasicAck(deliveryTag:e.DeliveryTag,multiple:false);
};


Console.Read();