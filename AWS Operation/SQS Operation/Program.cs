using SQS_Operation;

var body = "My name is zubayer";

QueueOperation queueOperation = new QueueOperation();

//for creating queue
//string url = await queueOperation.CreateQueueAsync("zubayerSQS");


var myUrl = "https://sqs.us-east-1.amazonaws.com/847888492411/zubayerSQS";

//for sending message in queue
//var messageId = await queueOperation.AddMessage(myUrl, body);
//for (int i = 0; i < 25; i++)
//{
//    await queueOperation.AddMessage(myUrl, body);

//}

//Console.WriteLine(messageId);



//for reading messages in queue;
//int numbers = 10;
//var messages = await queueOperation.ReadMessageAsync(myUrl,numbers);

//foreach(var message in messages)
//{
//    Console.WriteLine(message);
//}

//for deleting messages 
//await queueOperation.ReceiveAndDeleteMessage(myUrl);




