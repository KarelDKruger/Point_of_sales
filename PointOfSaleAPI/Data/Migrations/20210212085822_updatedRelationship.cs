using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSaleAPI.Data.Migrations
{
    public partial class updatedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaptopBrand",
                table: "SalesItems");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "SalesItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaptopId",
                table: "SalesItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_ColorId",
                table: "SalesItems",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_HddId",
                table: "SalesItems",
                column: "HddId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_LaptopId",
                table: "SalesItems",
                column: "LaptopId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_RamId",
                table: "SalesItems",
                column: "RamId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_ColorSelections_ColorId",
                table: "SalesItems",
                column: "ColorId",
                principalTable: "ColorSelections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_HddItems_HddId",
                table: "SalesItems",
                column: "HddId",
                principalTable: "HddItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_LaptopItems_LaptopId",
                table: "SalesItems",
                column: "LaptopId",
                principalTable: "LaptopItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_RamItems_RamId",
                table: "SalesItems",
                column: "RamId",
                principalTable: "RamItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_ColorSelections_ColorId",
                table: "SalesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_HddItems_HddId",
                table: "SalesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_LaptopItems_LaptopId",
                table: "SalesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_RamItems_RamId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_ColorId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_HddId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_LaptopId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_RamId",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "LaptopId",
                table: "SalesItems");

            migrationBuilder.AlterColumn<string>(
                name: "ColorId",
                table: "SalesItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "LaptopBrand",
                table: "SalesItems",
                type: "TEXT",
                nullable: true);
        }
    }
}
