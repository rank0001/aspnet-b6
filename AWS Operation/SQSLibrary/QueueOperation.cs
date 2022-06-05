using Amazon.SQS;
using Amazon.SQS.Model;


namespace SQSLibrary
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
        public async Task<IList<string>> ReadMessageAsync(string url, int number)
        {
            List<string> messages = new List<string>();
            var request = new ReceiveMessageRequest(url);
            request.MaxNumberOfMessages = number;
            ReceiveMessageResponse response;
            do
            {
                response = await _client.ReceiveMessageAsync(request);
            } while (response.Messages.Count != number);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                foreach (Message message in response.Messages)
                {
                    messages.Add(message.Body);    
                }
            }
            return messages;

        }

        public async Task ReceiveAndDeleteMessages(string url,int numberofMessages)
        {
            var request = new ReceiveMessageRequest
            {
                MaxNumberOfMessages = numberofMessages,
                QueueUrl = url,
            };
            ReceiveMessageResponse response;
            do
            {
                response = await _client.ReceiveMessageAsync(request);
            } while (response.Messages.Count != numberofMessages);

            for (int i = 0; i < numberofMessages; i++)
            {
                var deleteMessageRequest = new DeleteMessageRequest
                {
                    QueueUrl = url,
                    ReceiptHandle = response.Messages[i].ReceiptHandle
                };

                await _client.DeleteMessageAsync(deleteMessageRequest);
            }

        }



    }
}
