using SQSLibrary;

var body = "My name is zubayer";

QueueOperation queueOperation = new QueueOperation();

var myUrl = "https://sqs.us-east-1.amazonaws.com/847888492411/zubayerSQS";

#region creating queue
//for creating queue
//string url = await queueOperation.CreateQueueAsync("zubayerSQS");
#endregion


#region Adding Message to a queue
//int j = 0;
//do
//{
//    var messageId = await queueOperation.AddMessage(myUrl, body);
//    j++;
//    Console.WriteLine(messageId);
//} while (j!= 10);
#endregion

#region For reading  messages in queue;
//int numbers = 10;
//var messages = await queueOperation.ReadMessageAsync(myUrl, numbers);

//foreach (var message in messages)
//{
//    Console.WriteLine(message);
//}
#endregion

#region for reading and deleting messages
//int messageNumber = 5;
//await queueOperation.ReceiveAndDeleteMessages(myUrl,messageNumber);
#endregion



