using System;
using System.Configuration;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace KafkaSample.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new KafkaOptions(new Uri(ConfigurationManager.AppSettings["KafkaServer"]));
            var router = new BrokerRouter(options);
            var client = new KafkaNet.Producer(router);

            while (true)
            {
                string text = Console.ReadLine();
                if (text.ToLower() == "exit")
                {
                    break;
                }

                client.SendMessageAsync("test", new[] { new Message(text) }).Wait();
            }
        }
    }
}
