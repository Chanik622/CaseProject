using CasesService.Interfaces;
using CasesService.Models;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace CasesService.Services
{
    public class CaseService : ICaseService
    {
        private const string QueueName = "Emails";

        List<CaseDetail> caseDetailsList = new List<CaseDetail>
        {
            new CaseDetail
            {
                CaseId = 101,
                CaseName = "תיק 1",
                OpeningDate = new DateTime(2024, 1, 15),
                Status = (Enums.enums.CaseStatus)2,
                AssignedTo = "דוד בנימיני",
                CaseType = "ערר חרבות ברזל",
                JudgeId = 315534280
            },
            new CaseDetail
            {
                CaseId = 102,
                CaseName = "תיק 2",
                OpeningDate = new DateTime(2024, 1, 16),
                Status = (Enums.enums.CaseStatus)2,
                AssignedTo = "אברהם יעקב",
                CaseType = "ערר חרבות ברזל",
                JudgeId = 315534280

            },
            new CaseDetail
            {
                CaseId = 103,
                CaseName = "תיק 3",
                OpeningDate = new DateTime(2024, 1, 17),
                Status = (Enums.enums.CaseStatus)1,
                AssignedTo = "אהרן שלום",
                CaseType = "ערר חרבות ברזל",
                JudgeId = 31553455

            }
        };
        public CaseService() { }

        public async Task<List<CaseDetail>> GetCaseDetails(filterCase filterCase)
        {
            var res = new List<CaseDetail>();
            res = caseDetailsList;
            if (filterCase.filterOptions.Contains(2)) // תיקים שלי
                res = res.Where(x => x.JudgeId == 315534280).ToList();
            if (filterCase.filterOptions.Contains(3)) // תיקים פתוחים
                res = res.Where(x => x.Status == Enums.enums.CaseStatus.OpendCase).ToList();
            if (filterCase.filterOptions.Contains(4)) // תיקים סגורים
                res = res.Where(x => x.Status == Enums.enums.CaseStatus.closedCase).ToList();
            return await Task.Run(() => res);
        }
        public async Task<int> CreateCaseDetails(CaseDetail caseDetail)
        {
            caseDetailsList.Add(caseDetail);
            SendNotification(caseDetail.CaseId,"ccc@nmnm");
            return 0;
        }

        private async void SendNotification(int caseId, string email)
        {
            var notificationMessage = new
            {
                CaseId = caseId,
                Email = email,
                Subject = "תיק חדש נפתח",
                Body = $"תיק חדש נפתח עם מזהה {caseId}"
            };
            var factory = new ConnectionFactory() { HostName = "" };
            using (var connection =  factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: QueueName,durable: false,exclusive: false,autoDelete: false,arguments: null);
                var messageBody = System.Text.Json.JsonSerializer.Serialize(notificationMessage);

                var body = Encoding.UTF8.GetBytes(messageBody);
                channel.BasicPublish(exchange: "",
                                     routingKey: QueueName,
                                     basicProperties: null,
                                     body: body);
            }
        }
     
    }
}
