using System.ComponentModel.DataAnnotations;

namespace SalonApp.Models;

public class MonthlyRecord
{
    [Key]
    public int Id { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal Revenue { get; set; }
    public int ClientCount { get; set; }
    public decimal MaterialCosts { get; set; }
    public decimal RentCosts { get; set; }
    public decimal ServiceCosts { get; set; }
    public decimal Payroll { get; set; }
    public decimal OtherExpenses { get; set; }
    public bool IsClosed { get; set; }

    public decimal TotalCosts => MaterialCosts + RentCosts + ServiceCosts + Payroll + OtherExpenses;
    public decimal Profit => Revenue - TotalCosts;
    public string MonthKey => $"{Year:D4}-{Month:D2}";
}
