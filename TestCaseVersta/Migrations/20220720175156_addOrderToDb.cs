using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCaseVersta.Migrations
{
    public partial class addOrderToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendersCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendersAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientsCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientsAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoWeight = table.Column<double>(type: "float", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
