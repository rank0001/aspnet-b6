﻿namespace StockData.Layer.BusinessObjects
{
    public class Company
    {
        public int Id { get; set; }
        public string? TradeCode { get; set; }
        public List <StockPrice>? StockPrices { get; set; }
    }
}
