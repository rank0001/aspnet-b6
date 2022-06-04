using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDBLibrary
{
    [DynamoDBTable("zubayerTable")]
    public class Store
    {
        [DynamoDBHashKey] //Partition key
        public string? Id
        {
            get; set;
        }
        [DynamoDBProperty]
        public string? Name
        {
            get; set;
        }
        [DynamoDBProperty]
        public string? Location
        {
            get; set;
        }
        [DynamoDBProperty("AllProducts")]
        public List<string>? Products
        {
            get; set;
        }
    }
}
