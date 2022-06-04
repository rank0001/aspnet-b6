using DynamoDBLibrary;

var dynamoDBOperations = new DynamoDbOperations();

var tableName = "zubayerTable";

#region CreatingStore

int i = 1;
while (i != 20)
{
    var store = new Store
    {
        Id = i.ToString(),
        Name = "Ecommerce Store",
        Location = "Dhaka",
        Products = new List<string> { "Shirt", "Pant", "Shoe", "Gown", "Punjabi", "Saree" }
    };


    await dynamoDBOperations.AddStore(store);
    Console.WriteLine("Adding store data of Id " + i);
    i++;
}
Console.WriteLine("All product are added to the store");


#endregion

#region GetStoreData

for (int j = 1; i <= 10; i++)
{
    var storeData = await dynamoDBOperations.GetStoreData(tableName, j.ToString());
    foreach (var store in storeData)
    {
        Console.WriteLine(store.Id + " " + store.Name + " " + store.Location);

        foreach (var storeItem in store.Products)
        {
            Console.WriteLine(storeItem);
        }
    }
}
#endregion

#region DeleteStoreData

dynamoDBOperations.Delete("36");
#endregion

