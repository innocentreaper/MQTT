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

        // Subscribe to the test-topic topic.
        await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("test-topic").Build());

        // Handle received messages.
        mqttClient.UseApplicationMessageReceivedHandler(e =>
        {
            Console.WriteLine($"Received message '{e.ApplicationMessage.Payload}' on topic '{e.ApplicationMessage.Topic}'.");
        });

        Console.WriteLine("Press any key to disconnect the client.");
        Console.ReadLine();

        // Disconnect the MQTT client from the server.
        await mqttClient.DisconnectAsync();
    }
}