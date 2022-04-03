using HtmlAgilityPack;
using StockData.Layer.BusinessObjects;
using StockData.Layer.Services;
using System.Text.RegularExpressions;


namespace StockData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICompanyService _companyService;
        private readonly IStockService _stockService;
        private string _url;

        public Worker(ILogger<Worker> logger, ICompanyService companyService,
            IStockService stockService)

        {
            _logger = logger;
            _companyService = companyService;
            _stockService = stockService;
            _url = @"https://dse.com.bd/latest_share_price_scroll_l.php";
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("here we are!");
            if (_companyService.GetCompanyCount() == 0)
            {
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(_url);
                if (htmlDoc != null)
                {
                    HtmlNode tables = htmlDoc.DocumentNode.SelectSingleNode("//table");

                    foreach (HtmlNode node in tables.SelectNodes("//tr"))
                    {
                        string tradingCode = ParsedValues(node, 2);
                        string latestPrice = ParsedValues(node, 3);

                        if (latestPrice.Length >= 1 && latestPrice.Length <= 8)
                        {
                            var company = new Company
                            {
                                TradeCode = tradingCode
                            };

                            _companyService.CreateCompany(company);
                        }
                    }
                }
            }

            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker runnnnning at: " +
                        "{time}", DateTimeOffset.Now);

                           
                    HtmlWeb web = new HtmlWeb();
                    var htmlDoc = web.Load(_url);
                    if (htmlDoc!=null)
                    {
                        _logger.LogInformation("inside doc");
                        var nodes = htmlDoc.DocumentNode.
                        SelectSingleNode("//*[text()[contains(.,'Market Status')]]")
                            .InnerText;
                        var values = nodes.Split(":")[1];
                        string marketStatus = Regex.Replace(values, @"\s", "");

                        if (marketStatus == "Closed")
                        {
                            HtmlNode tables = htmlDoc.DocumentNode
                                .SelectSingleNode("//table");

                            foreach (HtmlNode node in tables.SelectNodes("//tr"))
                            {
                                string id = ParsedValues(node, 1);
                                string latestPrice = ParsedValues(node, 3);
                                string highestPrice = ParsedValues(node, 4);
                                string lowestPrice = ParsedValues(node, 5);
                                string closingPrice = ParsedValues(node, 6);
                                string yesterdayPrice = ParsedValues(node, 7);
                                string change = ParsedValues(node, 8);
                                string trade = ParsedValues(node, 9);
                                string value = ParsedValues(node, 10);
                                string volume = ParsedValues(node, 11);

                                if (latestPrice.Length >= 1 &&
                                    latestPrice.Length <= 8)
                                {
                                    int idStock = Int32.Parse(id);
                                    double latestPriceStock = Double.Parse(latestPrice);
                                    double highestPriceStock = Double.Parse(highestPrice);
                                    double lowestPriceStock = Double.Parse(lowestPrice);
                                    double closingStock = Double.Parse(closingPrice);
                                    double yesterdayStock = Double.Parse(yesterdayPrice);
                                    double tradeStock = Double.Parse(trade);
                                    double valueStock = Double.Parse(value);
                                    double volumeStock = Double.Parse(volume);

                                    var stocks = new StockPrice
                                    {
                                        CompanyId = idStock,
                                        LastTradingPrice = latestPriceStock,
                                        HighestPrice = highestPriceStock,
                                        LowestPrice = lowestPriceStock,
                                        ClosestPrice = closingStock,
                                        YesterdayClosingPrice = yesterdayStock,
                                        Change = change,
                                        Trade = tradeStock,
                                        Value = valueStock,
                                        Volume = volumeStock
                                    };
                                    _stockService.CreateStocks(stocks);
                                }
                            }

                            _logger.LogInformation("Stock price inserted at:" +
                                " {time}", DateTimeOffset.Now);
                        }

                    }
                    else
                    {
                        _logger.LogInformation("not inside doc!");
                    }
                    await Task.Delay(60000, stoppingToken);
                }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service has been stopped!");
            return base.StopAsync(cancellationToken);
        }

        private static string ParsedValues(HtmlNode node, int index)
        {
            var id = node.SelectSingleNode($"td[{index}]") ==
                null ? "" : node.SelectSingleNode($"td[{index}]").InnerText;
            return Regex.Replace(id, @"\s", "");

        }
    }
}