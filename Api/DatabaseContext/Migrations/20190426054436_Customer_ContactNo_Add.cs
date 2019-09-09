using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloCoreMVCApp.Migrations
{
    public partial class Customer_ContactNo_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "Customers");
        }
    }
}
