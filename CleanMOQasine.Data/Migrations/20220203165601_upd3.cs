using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanMOQasine.Data.Migrations
{
    public partial class upd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Grade_GradeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_GradeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Grade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Grade_OrderId",
                table: "Grade",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Order_OrderId",
                table: "Grade",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Order_OrderId",
                table: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Grade_OrderId",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Grade");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_GradeId",
                table: "Order",
                column: "GradeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Grade_GradeId",
                table: "Order",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
