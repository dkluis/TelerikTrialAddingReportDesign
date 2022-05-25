using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using TelerikBlazorApp2.Data;
using TelerikBlazorApp2.Models.Sales;

namespace TelerikBlazorApp2.Pages
{
    public partial class PerformanceAndSales
    {
        public PerformanceAndSales()
        {

        }
        TelerikChart PieChartRef { get; set; }
        TelerikChart EuropeChartRef { get; set; }
        TelerikChart WorldChartRef { get; set; }
        TelerikChart ColumnChartRef { get; set; }
        TelerikChart AreaChartRef { get; set; }
        TelerikCircularGauge UserFirstCirclGauge { get; set; }
        TelerikCircularGauge UserSecondCirclGaugeRef { get; set; }
        TelerikCircularGauge UserThirdCirclGaugeRef { get; set; }
        TelerikCircularGauge UserFourthCirclGaugeRef { get; set; }
        private List<SalesByDateViewModel> sales = new List<SalesByDateViewModel>();
        private List<SalesByDateViewModel> salesPerformance = new List<SalesByDateViewModel>();
        public string[] xAxisItems = new string[] { "Q1", "Q2", "Q3", "Q4" };
        public string[] xAxisItemsBarFirst = new string[] { "Sofia, Bulgaria", "Berlin, Germany", "Paris, France", "Madrid, Spain" };
        public string[] xAxisItemsBarSecond = new string[] { "Moscow, Russia", "Beijing, China", "Dubai, UAE", "Tokyo, Japan" };
        public object[] AxisCrossingValue = new object[] { -10 };

        protected override async Task OnInitializedAsync()
        {
            sales = _dataService.GetSales().Where(sale => sale.TransactionDate > new DateTime(2019, 12, 30) && sale.TransactionDate < new DateTime(2019, 12, 31))
                .Select(s => new SalesByDateViewModel
                {
                    Sum = s.Amount,
                    SumOne = s.Amount + 100,
                    SumTwo = s.Amount + 200,
                    SumThree = s.Amount + 300,
                    X = s.Id + 500,
                    Y = (int)s.Amount + 250,
                    Size = (int)s.Amount + 600,
                })
                .ToList();

            salesPerformance = _dataService.GetSales().Where(sale => sale.TransactionDate > new DateTime(2019, 12, 30) && sale.TransactionDate < new DateTime(2019, 12, 31))
                .Select(s => new SalesByDateViewModel
                {
                    Sum = s.Amount,
                    SumOne = s.Amount + 100,
                    SumTwo = s.Amount + 200,
                    SumThree = s.Amount + 300,
                    SegmentValue = s.Amount,
                    SegmentValueOne = s.Amount + 1,
                    SegmentValueTwo = s.Amount + 2,
                    SegmentValueThree = s.Amount + 3,
                    Cost = "Product Region- " + s.Region + $" {s.Id}"
                })
                .ToList();
            salesPerformance.RemoveRange(3, 10);
        }

        void ItemResize()
        {
            PieChartRef.Refresh();
            EuropeChartRef.Refresh();
            WorldChartRef.Refresh();
            ColumnChartRef.Refresh();
            AreaChartRef.Refresh();
            UserFirstCirclGauge.Refresh();
            UserSecondCirclGaugeRef.Refresh();
            UserThirdCirclGaugeRef.Refresh();
            UserFourthCirclGaugeRef.Refresh();
        }
    }
}
