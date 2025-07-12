using Avalonia.Controls;
using Avalonia.Interactivity;
using SalonApp.Services;
using System;

namespace SalonGui.Views;

public partial class AddEntryWindow : Window
{
    private SalonService _service = null!;

    public AddEntryWindow()
    {
        InitializeComponent();
    }

    public AddEntryWindow(SalonService service) : this()
    {
        _service = service;
    }

    private void Save(object? sender, RoutedEventArgs e)
    {
        int year = int.Parse(YearBox.Text ?? "0");
        int month = int.Parse(MonthBox.Text ?? "1");
        decimal revenue = decimal.Parse(RevenueBox.Text ?? "0");
        int clients = int.Parse(ClientsBox.Text ?? "0");
        decimal materials = decimal.Parse(MaterialsBox.Text ?? "0");
        decimal rent = decimal.Parse(RentBox.Text ?? "0");
        decimal service = decimal.Parse(ServiceBox.Text ?? "0");
        decimal payroll = decimal.Parse(PayrollBox.Text ?? "0");
        decimal other = decimal.Parse(OtherBox.Text ?? "0");
        _service.AddEntry(year, month, revenue, clients, materials, rent, service, payroll, other);
        Close();
    }
}
