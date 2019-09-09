using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloCoreMVCApp.Migrations
{
    public partial class VW_OrderInfor_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW VW_OrderInfo
AS
SELECT	o.Id, 
		o.OrderNo, 
		o.OrderDate, 
		c.CustomerName, 
		SUM(ISNULL(od.Qty,0)*ISNULL(od.UnitPrice,0)) as TotalPrice 
		
		FROM Orders o 
		LEFT OUTER JOIN Customers c ON o.CustomerId = c.Id
		LEFT OUTER JOIN OrderDetails od ON od.OrderId = o.Id

		GROUP BY o.Id, o.OrderNo, c.CustomerName, o.OrderDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS dbo.VW_OrderInfo");
        }
    }
}
