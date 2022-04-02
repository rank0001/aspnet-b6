using StockData.Data;
namespace StockData.Layer.Entities
{
    public class Company : IEntity<int>
    {
        public int Id { get; set; }
        public string? TradeCode { get; set; }
        public List<StockPrice>? StockPrices { get; set; }
    }
}
