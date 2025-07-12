using Avalonia.Controls;
using System;
using SalonApp;
using SalonApp.Services;

namespace SalonGui.Views;

public partial class MainWindow : Window
{
    private readonly SalonService _service;

    public MainWindow()
    {
        InitializeComponent();
        var context = new SalonContext();
        _service = new SalonService(context);
    }

    private async void AddEntry(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var dialog = new AddEntryWindow(_service);
        await dialog.ShowDialog(this);
    }

    private void CloseMonth(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var dialog = new CloseMonthWindow(_service);
        dialog.ShowDialog(this);
    }

    private async void AdjustMonth(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var dialog = new AdjustMonthWindow(_service);
        await dialog.ShowDialog(this);
    }

    private async void GenerateReport(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var dialog = new ReportWindow(_service);
        await dialog.ShowDialog(this);
    }
}
