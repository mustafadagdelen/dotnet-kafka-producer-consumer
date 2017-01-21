using System;
using System.Configuration;
using System.Text;
using KafkaNet;
using KafkaNet.Model;

namespace KafkaSample.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new KafkaOptions(new Uri(ConfigurationManager.AppSettings["KafkaServer"]));
            var router = new BrokerRouter(options);
            var consumer = new KafkaNet.Consumer(new ConsumerOptions("test", router));

            //Consume returns a blocking IEnumerable (ie: never ending stream)
            foreach (var message in consumer.Consume())
            {
                string messageText = Encoding.UTF8.GetString(message.Value);
                Console.WriteLine(messageText);
            }
        }
    }
}
