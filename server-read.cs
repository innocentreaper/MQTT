using System;
using MQTTnet;
using MQTTnet.Server;

class Program
{
    static async Task Main(string[] args)
    {
        // Create a new MQTT server instance.
        var mqttServer = new MqttFactory().CreateMqttServer();

        // Handle client connection events.
        mqttServer.ClientConnectedHandler = new MqttServerClientConnectedHandlerDelegate(e =>
        {
            Console.WriteLine($"Client '{e.ClientId}' connected.");
        });

        // Handle client disconnection events.
        mqttServer.ClientDisconnectedHandler = new MqttServerClientDisconnectedHandlerDelegate(e =>
        {
            Console.WriteLine($"Client '{e.ClientId}' disconnected.");
        });

        // Start the MQTT server.
        await mqttServer.StartAsync(new MqttServerOptionsBuilder().Build());

        Console.WriteLine("Press any key to stop the server.");
        Console.ReadLine();

        // Stop the MQTT server.
        await mqttServer.StopAsync();
    }
}