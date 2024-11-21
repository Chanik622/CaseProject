using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace NotificationService.Services
{
    public class NotificationService
    {
        private const string QueueName = "Emails";

        public void StartListening()
        {
            var factory = new ConnectionFactory() { HostName = "" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: QueueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var notificationMessage = System.Text.Json.JsonSerializer.Deserialize<NotificationMessage>(message);
                    if (notificationMessage != null)
                    {
                        SendEmail(notificationMessage.Email, notificationMessage.Subject, notificationMessage.Body);
                    }
                };

                channel.BasicConsume(queue: QueueName,
                                     autoAck: true,
                                     consumer: consumer);
            }
        }

        private void SendEmail(string to, string subject, string body)
        {
            //שליחת מייל
        }
    }

    public class NotificationMessage
    {
        public int CaseId { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

