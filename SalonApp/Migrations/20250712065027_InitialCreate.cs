using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Month = table.Column<int>(type: "INTEGER", nullable: false),
                    Revenue = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClientCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialCosts = table.Column<decimal>(type: "TEXT", nullable: false),
                    RentCosts = table.Column<decimal>(type: "TEXT", nullable: false),
                    ServiceCosts = table.Column<decimal>(type: "TEXT", nullable: false),
                    Payroll = table.Column<decimal>(type: "TEXT", nullable: false),
                    OtherExpenses = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsClosed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyRecords", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyRecords_Year_Month",
                table: "MonthlyRecords",
                columns: new[] { "Year", "Month" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyRecords");
        }
    }
}
