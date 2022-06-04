using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bucket_Task
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


        //Downloaing file
        public async Task<string> DownloadObjectDataAsync(string bucketName, string keyName, string newFileLocation)
        {
            MemoryStream ms = null;
            try
            {
                using (TransferUtility transferUtility = new Amazon.S3.Transfer.TransferUtility())
                {

                    TransferUtilityDownloadRequest downloadRequest = new TransferUtilityDownloadRequest
                    {
                        BucketName = bucketName,
                        Key = keyName,//filename or objectname which u want to downlaod from  bucket
                        FilePath = newFileLocation,
                    };
                    transferUtility.Download(downloadRequest);

                }
                //TransferUtility t 

                return "Success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteFile(string bucketName, string keyName)
        {
            DeleteObjectRequest request = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = keyName

            };
            var response =  _client.DeleteObjectAsync(request).Result;
            var IsDeleted =  response.DeleteMarker;
        }




    }
}

