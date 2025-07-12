using Avalonia.Controls;
using Avalonia.Interactivity;
using SalonApp.Services;
using System;
using System.Linq;

namespace SalonGui.Views;

public partial class ReportWindow : Window
{
    private SalonService _service = null!;

    public ReportWindow()
    {
        InitializeComponent();
    }

    public ReportWindow(SalonService service) : this()
    {
        _service = service;
    }

    private void Generate(object? sender, RoutedEventArgs e)
    {
        int year = int.Parse(YearBox.Text ?? "0");
        DateTime from, to;
        switch (PeriodType.SelectedIndex)
        {
            case 0:
                int month = int.Parse(MonthOrQuarterBox.Text ?? "1");
                from = new DateTime(year, month, 1);
                to = from.AddMonths(1).AddDays(-1);
                break;
            case 1:
                int q = int.Parse(MonthOrQuarterBox.Text ?? "1");
                from = new DateTime(year, (q - 1) * 3 + 1, 1);
                to = from.AddMonths(3).AddDays(-1);
                break;
            default:
                from = new DateTime(year, 1, 1);
                to = from.AddYears(1).AddDays(-1);
                break;
        }
        var records = _service.GetRecords(from, to).ToList();
        decimal revenue = records.Sum(r => r.Revenue);
        decimal costs = records.Sum(r => r.TotalCosts);
        int clients = records.Sum(r => r.ClientCount);
        Output.Text = $"Revenue: {revenue}\nClients: {clients}\nCosts: {costs}\nProfit: {revenue - costs}";
    }
}
