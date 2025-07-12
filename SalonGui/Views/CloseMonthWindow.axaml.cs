using Avalonia.Controls;
using Avalonia.Interactivity;
using SalonApp.Services;

namespace SalonGui.Views;

public partial class CloseMonthWindow : Window
{
    private SalonService _service = null!;

    public CloseMonthWindow()
    {
        InitializeComponent();
    }

    public CloseMonthWindow(SalonService service) : this()
    {
        _service = service;
    }

    private void CloseClick(object? sender, RoutedEventArgs e)
    {
        int year = int.Parse(YearBox.Text ?? "0");
        int month = int.Parse(MonthBox.Text ?? "1");
        _service.CloseMonth(year, month);
        Close();
    }
}
