using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace BucketLibrary
{
    public class BucketOperation
    {
        private readonly AmazonS3Client _client;
        public BucketOperation()
        {
            _client = new AmazonS3Client();
        }

        public async Task UplodFileAsync(string bucketName, string fileName, string filePath)
        {
            var putRequest2 = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = fileName,
                FilePath = filePath,
                ContentType = "text/plain"
            };

            putRequest2.Metadata.Add("x-amz-meta-title", "someTitle");
            PutObjectResponse response2 = await _client.PutObjectAsync(putRequest2);
        }


        public void DownloadObject(string bucketName, string keyName, string newFileLocation)
        {

            using (TransferUtility transferUtility = new TransferUtility())
            {

                TransferUtilityDownloadRequest downloadRequest = new TransferUtilityDownloadRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    FilePath = newFileLocation,
                };
                transferUtility.Download(downloadRequest);
            }
             
        }

        public void DeleteObject(string bucketName, string keyName)
        {
            DeleteObjectRequest request = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = keyName

            };
             _client.DeleteObjectAsync(request);
           
        }
    }

}
