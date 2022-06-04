using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQS_Operation
{
    public class QueueOperation
    {
        private readonly AmazonSQSClient _client;
        public QueueOperation()
        {
            _client = new AmazonSQSClient();
        }

        public async Task<string> CreateQueueAsync(string queueName)
        {
            CreateQueueRequest request = new CreateQueueRequest(queueName);
            CreateQueueResponse response = await _client.CreateQueueAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return response.QueueUrl;
            else
                return null;
        }

        public async Task<string> AddMessage(string url, string body)
        {
            SendMessageRequest request = new SendMessageRequest(url, body);
            var response = await _client.SendMessageAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return response.MessageId;
            else
                return null;
        }
        public async Task<IList<string>> ReadMessageAsync(string url,int number)
        {
            List<string> messages = new List<string>();
            var request = new ReceiveMessageRequest(url);
            request.MaxNumberOfMessages = number;
            var count = 0;

            var response = await _client.ReceiveMessageAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                
                foreach (Message message in response.Messages)
                {
                    messages.Add(message.Body);
                    Console.WriteLine(message.Body);
                    count++;
                   
                }

            }
            return messages;

        }

        public async Task ReceiveAndDeleteMessage(string url)
        {
            var receiveMessageRequest = new ReceiveMessageRequest
            {
                MaxNumberOfMessages = 1,
                QueueUrl = url,
            };

            var receiveMessageResponse = await _client.ReceiveMessageAsync(receiveMessageRequest);

            var deleteMessageRequest = new DeleteMessageRequest
            {
                QueueUrl = url,
                ReceiptHandle = receiveMessageResponse.Messages[0].ReceiptHandle
            };

            await _client.DeleteMessageAsync(deleteMessageRequest);
        }



    }
}
