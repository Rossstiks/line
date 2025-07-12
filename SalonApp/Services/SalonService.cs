using Microsoft.EntityFrameworkCore;
using SalonApp.Models;

namespace SalonApp.Services;

public class SalonService
{
    private readonly SalonContext _context;

    public SalonService(SalonContext context)
    {
        _context = context;
        _context.Database.Migrate();
    }

    public MonthlyRecord GetOrCreateMonth(int year, int month)
    {
        var record = _context.MonthlyRecords.FirstOrDefault(r => r.Year == year && r.Month == month);
        if (record == null)
        {
            record = new MonthlyRecord
            {
                Year = year,
                Month = month
            };
            _context.MonthlyRecords.Add(record);
            _context.SaveChanges();
        }
        return record;
    }

    public void AddEntry(int year, int month, decimal revenue, int clients, decimal materials, decimal rent, decimal service, decimal payroll, decimal other)
    {
        var record = GetOrCreateMonth(year, month);
        if (record.IsClosed)
        {
            Console.WriteLine("Month already closed. Use adjust to modify.");
            return;
        }
        record.Revenue += revenue;
        record.ClientCount += clients;
        record.MaterialCosts += materials;
        record.RentCosts += rent;
        record.ServiceCosts += service;
        record.Payroll += payroll;
        record.OtherExpenses += other;
        _context.SaveChanges();
    }

    public void CloseMonth(int year, int month)
    {
        var record = GetOrCreateMonth(year, month);
        record.IsClosed = true;
        _context.SaveChanges();
    }

    public void AdjustMonth(int year, int month, Action<MonthlyRecord> adjust)
    {
        var record = GetOrCreateMonth(year, month);
        adjust(record);
        _context.SaveChanges();
    }

    public IEnumerable<MonthlyRecord> GetRecords(DateTime from, DateTime to)
    {
        return _context.MonthlyRecords
            .Where(r => new DateTime(r.Year, r.Month, 1) >= from.Date && new DateTime(r.Year, r.Month, 1) <= to.Date)
            .OrderBy(r => r.Year).ThenBy(r => r.Month)
            .ToList();
    }
}
