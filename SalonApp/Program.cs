using SalonApp;
using SalonApp.Models;
using SalonApp.Services;

var context = new SalonContext();
var service = new SalonService(context);

while (true)
{
    Console.WriteLine("\nBeauty Salon Management");
    Console.WriteLine("1. Add entry");
    Console.WriteLine("2. Close month");
    Console.WriteLine("3. Adjust month");
    Console.WriteLine("4. Generate report");
    Console.WriteLine("5. Exit");
    Console.Write("Choose option: ");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            AddEntry();
            break;
        case "2":
            CloseMonth();
            break;
        case "3":
            AdjustMonth();
            break;
        case "4":
            GenerateReport();
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}

void AddEntry()
{
    var (year, month) = PromptMonth();
    Console.Write("Revenue: ");
    decimal revenue = decimal.Parse(Console.ReadLine() ?? "0");
    Console.Write("Clients: ");
    int clients = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Material costs: ");
    decimal materials = decimal.Parse(Console.ReadLine() ?? "0");
    Console.Write("Rent costs: ");
    decimal rent = decimal.Parse(Console.ReadLine() ?? "0");
    Console.Write("Service costs: ");
    decimal serviceCost = decimal.Parse(Console.ReadLine() ?? "0");
    Console.Write("Payroll: ");
    decimal payroll = decimal.Parse(Console.ReadLine() ?? "0");
    Console.Write("Other expenses: ");
    decimal other = decimal.Parse(Console.ReadLine() ?? "0");

    service.AddEntry(year, month, revenue, clients, materials, rent, serviceCost, payroll, other);
}

void CloseMonth()
{
    var (year, month) = PromptMonth();
    service.CloseMonth(year, month);
    Console.WriteLine("Month closed.");
}

void AdjustMonth()
{
    var (year, month) = PromptMonth();
    var record = service.GetOrCreateMonth(year, month);
    Console.WriteLine($"Current data: Revenue {record.Revenue}, Clients {record.ClientCount}, Costs {record.TotalCosts}");
    Console.Write("New Revenue (blank to keep): ");
    var input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) record.Revenue = decimal.Parse(input);
    Console.Write("New Clients (blank to keep): ");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) record.ClientCount = int.Parse(input);
    Console.Write("New Material costs (blank to keep): ");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) record.MaterialCosts = decimal.Parse(input);
    Console.Write("New Rent costs (blank to keep): ");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) record.RentCosts = decimal.Parse(input);
    Console.Write("New Service costs (blank to keep): ");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) record.ServiceCosts = decimal.Parse(input);
    Console.Write("New Payroll (blank to keep): ");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) record.Payroll = decimal.Parse(input);
    Console.Write("New Other expenses (blank to keep): ");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) record.OtherExpenses = decimal.Parse(input);
    service.AdjustMonth(year, month, r => { });
    Console.WriteLine("Month adjusted.");
}

void GenerateReport()
{
    Console.WriteLine("Choose period type: 1-Month 2-Quarter 3-Year");
    var periodType = Console.ReadLine();
    DateTime from, to;
    switch (periodType)
    {
        case "1":
            var (year, month) = PromptMonth();
            from = new DateTime(year, month, 1);
            to = from.AddMonths(1).AddDays(-1);
            break;
        case "2":
            Console.Write("Year: ");
            year = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Quarter (1-4): ");
            int q = int.Parse(Console.ReadLine() ?? "1");
            from = new DateTime(year, (q - 1) * 3 + 1, 1);
            to = from.AddMonths(3).AddDays(-1);
            break;
        case "3":
            Console.Write("Year: ");
            year = int.Parse(Console.ReadLine() ?? "0");
            from = new DateTime(year, 1, 1);
            to = from.AddYears(1).AddDays(-1);
            break;
        default:
            Console.WriteLine("Invalid");
            return;
    }

    var records = service.GetRecords(from, to).ToList();
    decimal totalRevenue = records.Sum(r => r.Revenue);
    int totalClients = records.Sum(r => r.ClientCount);
    decimal totalCosts = records.Sum(r => r.TotalCosts);
    decimal profit = totalRevenue - totalCosts;
    decimal avgRevenuePerClient = totalClients > 0 ? totalRevenue / totalClients : 0;

    Console.WriteLine($"\nReport {from:yyyy-MM-dd} to {to:yyyy-MM-dd}");
    Console.WriteLine($"Total revenue: {totalRevenue}");
    Console.WriteLine($"Total clients: {totalClients}");
    Console.WriteLine($"Total costs: {totalCosts}");
    Console.WriteLine($"Profit: {profit}");
    Console.WriteLine($"Average revenue per client: {avgRevenuePerClient:F2}");
}

(int Year, int Month) PromptMonth()
{
    Console.Write("Year (yyyy): ");
    int year = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Month (1-12): ");
    int month = int.Parse(Console.ReadLine() ?? "1");
    return (year, month);
}
