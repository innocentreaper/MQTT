using System;
using MQTTnet;
using MQTTnet.Server;

class Program
{
    static async Task Main(string[] args)
    {
        // Create a new MQTT server instance.
        var mqttServer = new MqttFactory().CreateMqttServer();

        // Start the MQTT server.
        await mqttServer.StartAsync(new MqttServerOptionsBuilder().Build());

        // Publish a message to a topic.
        var message = new MqttApplicationMessageBuilder()
            .WithTopic("test-topic")
            .WithPayload("Hello, world!")
            .WithExactlyOnceQoS()
            .Build();
        await mqttServer.PublishAsync(message);

        Console.WriteLine("Press any key to stop the server.");
        Console.ReadLine();

        // Stop the MQTT server.
        await mqttServer.StopAsync();
    }
}