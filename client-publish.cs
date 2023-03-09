using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

class Program
{
    static async Task Main(string[] args)
    {
        // Create a new MQTT client instance.
        var mqttClient = new MqttFactory().CreateMqttClient();

        // Define the MQTT client options.
        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("localhost", 1883)
            .WithClientId("test-client")
            .Build();

        // Connect the MQTT client to the server.
        await mqttClient.ConnectAsync(options);

        // Publish a message to a topic.
        var message = new MqttApplicationMessageBuilder()
            .WithTopic("test-topic")
            .WithPayload("Hello, world!")
            .WithExactlyOnceQoS()
            .Build();
        await mqttClient.PublishAsync(message);

        Console.WriteLine("Press any key to disconnect the client.");
        Console.ReadLine();

        // Disconnect the MQTT client from the server.
        await mqttClient.DisconnectAsync();
    }
}