using Avalonia.Controls;
using Avalonia.Interactivity;
using SalonApp.Services;

namespace SalonGui.Views;

public partial class AdjustMonthWindow : Window
{
    private SalonService _service = null!;

    public AdjustMonthWindow()
    {
        InitializeComponent();
    }

    public AdjustMonthWindow(SalonService service) : this()
    {
        _service = service;
    }

    private void Save(object? sender, RoutedEventArgs e)
    {
        int year = int.Parse(YearBox.Text ?? "0");
        int month = int.Parse(MonthBox.Text ?? "1");
        decimal? revenue = string.IsNullOrWhiteSpace(RevenueBox.Text) ? null : decimal.Parse(RevenueBox.Text!);
        int? clients = string.IsNullOrWhiteSpace(ClientsBox.Text) ? null : int.Parse(ClientsBox.Text!);

        _service.AdjustMonth(year, month, r =>
        {
            if (revenue.HasValue) r.Revenue = revenue.Value;
            if (clients.HasValue) r.ClientCount = clients.Value;
        });
        Close();
    }
}
