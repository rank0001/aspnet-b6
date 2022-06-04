using Bucket_Task;
BucketOperation bucketOperations = new BucketOperations();

string bucketName = "zubayersbucket";
string keyname1 = "design.txt";
string keyname2 = "planProject.txt";
//await bucketOperations.UplodFileAsync(bucketName, "planProject.txt", @"C:\Users\planProject.txt");

Console.WriteLine("file uploaded");



//var x = await bucketOperations.DownloadObjectDataAsync(bucketName, keyname1, @"D:\dev skill materials\planProjectDownload.txt");
Console.WriteLine("download completed");


bucketOperations.DeleteFile(bucketName, keyname2);



