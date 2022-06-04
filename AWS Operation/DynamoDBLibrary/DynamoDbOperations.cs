using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;


namespace DynamoDBLibrary
{
    public class DynamoDbOperations
    {
        private static AmazonDynamoDBClient? _amazonDBclient;
        private DynamoDBContext _dbContext;

        public DynamoDbOperations()
        {
            _amazonDBclient = new AmazonDynamoDBClient();
            _dbContext = new DynamoDBContext(_amazonDBclient);
        }

        // Saving a Store
        public async Task AddStore(Store Store)
        {

            await _dbContext.SaveAsync(Store);
        }

        //Getting Store data 
        public async Task<IList<Store>> GetStoreData(string tableName, string storeId)
        {

            var store = new List<Store>();
            store.Add(await _dbContext.LoadAsync<Store>(storeId));
            return store;
        }

        //deleting one row that matches with the key
        public async Task Delete(string key)
        {
            await _dbContext.DeleteAsync<Store>(key);
        }
    }
}
