using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSaleAPI.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    HexCode = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorSelections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HddItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    HddSize = table.Column<string>(type: "TEXT", nullable: true),
                    SideNotation = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HddItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RamItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    RamSize = table.Column<string>(type: "TEXT", nullable: true),
                    RamGeneration = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LaptopBrand = table.Column<string>(type: "TEXT", nullable: true),
                    RamId = table.Column<int>(type: "INTEGER", nullable: false),
                    HddId = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorId = table.Column<string>(type: "TEXT", nullable: true),
                    CostExcVat = table.Column<decimal>(type: "TEXT", nullable: false),
                    CostIncVat = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesItems", x => x.Id);
                });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorSelections");

            migrationBuilder.DropTable(
                name: "HddItems");

            migrationBuilder.DropTable(
                name: "RamItems");

            migrationBuilder.DropTable(
                name: "SalesItems");
        }
    }
}
