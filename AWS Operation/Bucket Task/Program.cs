using BucketLibrary;

BucketOperation bucketOperations = new BucketOperation();

string bucketName = "zubayersbucket";

string fileName1 = "design.txt";

string fileName2 = "planProject.txt";

string fileName3 = "test.txt";

string filepath1 = @"C:\Users\planProject.txt";

string filepath2 = @"C:\Users\design.txt";

string filepath3 = @"C:\Users\test.txt";

string downloadLocation = @"D:\dev skill materials\planProjectDownload.txt";

#region UploadFile
//await bucketOperations.UplodFileAsync(bucketName, fileName3, filepath3);

#endregion

#region Download File
//bucketOperations.DownloadObject(bucketName, fileName1, @"D:\dev skill materials\planProjectDownload.txt");
#endregion

#region Deleting a file from bucket 
//bucketOperations.DeleteObject(bucketName, fileName1);
#endregion



