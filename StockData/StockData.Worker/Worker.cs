using Autofac;
using AutoMapper;
using HtmlAgilityPack;
using StockData.Layer.BusinessObjects;
using StockData.Layer.Services;
using StockData.Worker.Models.Companies;
using System.Text.RegularExpressions;

namespace StockData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICompanyService _companyService;
        private IMapper _mapper;

        public Worker(ILogger<Worker> logger,ICompanyService companyService,
            IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _companyService = companyService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var html = @"https://dse.com.bd/latest_share_price_scroll_l.php";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            if (_companyService.GetCompanyCount() == 0)
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

            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
        static string ParsedValues(HtmlNode node, int index)
        {
            var id = node.SelectSingleNode($"td[{index}]") == null ? "" : node.SelectSingleNode($"td[{index}]").InnerText;
            return Regex.Replace(id, @"\s", "");

        }
    }
}