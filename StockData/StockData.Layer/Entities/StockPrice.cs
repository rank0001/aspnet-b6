using StockData.Data;
namespace StockData.Layer.Entities
{
    public class StockPrice:IEntity<int>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company? Company{ get; set; }
        public double LastTradingPrice { get; set; }
        public double HighestPrice { get; set; }
        public double LowestPrice { get; set; }
        public double ClosestPrice { get; set; }
        public double YesterdayClosingPrice { get; set; }
        public string? Change { get; set; }
        public double Trade { get; set; }
        public double Value { get; set; }
        public double Volume { get; set; }
    }
}
