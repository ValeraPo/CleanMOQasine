using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanMOQasine.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CleaningAddition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time(2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningAddition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CleaningType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<double>(type: "float", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CleaningAdditionCleaningType",
                columns: table => new
                {
                    CleaningAdditionsId = table.Column<int>(type: "int", nullable: false),
                    CleaningTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningAdditionCleaningType", x => new { x.CleaningAdditionsId, x.CleaningTypesId });
                    table.ForeignKey(
                        name: "FK_CleaningAdditionCleaningType_CleaningAddition_CleaningAdditionsId",
                        column: x => x.CleaningAdditionsId,
                        principalTable: "CleaningAddition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CleaningAdditionCleaningType_CleaningType_CleaningTypesId",
                        column: x => x.CleaningTypesId,
                        principalTable: "CleaningType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CleaningAdditionUser",
                columns: table => new
                {
                    CleaningAdditionsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningAdditionUser", x => new { x.CleaningAdditionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CleaningAdditionUser_CleaningAddition_CleaningAdditionsId",
                        column: x => x.CleaningAdditionsId,
                        principalTable: "CleaningAddition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CleaningAdditionUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CleaningTypeId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_CleaningType_CleaningTypeId",
                        column: x => x.CleaningTypeId,
                        principalTable: "CleaningType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_ClientId",
                        column: x => x.ClientId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkingTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingTime_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CleaningAdditionOrder",
                columns: table => new
                {
                    CleaningAdditionsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningAdditionOrder", x => new { x.CleaningAdditionsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_CleaningAdditionOrder_CleaningAddition_CleaningAdditionsId",
                        column: x => x.CleaningAdditionsId,
                        principalTable: "CleaningAddition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CleaningAdditionOrder_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderCleaner",
                columns: table => new
                {
                    CleanerOrdersId = table.Column<int>(type: "int", nullable: false),
                    CleanersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCleaner", x => new { x.CleanerOrdersId, x.CleanersId });
                    table.ForeignKey(
                        name: "FK_OrderCleaner_Order_CleanerOrdersId",
                        column: x => x.CleanerOrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderCleaner_User_CleanersId",
                        column: x => x.CleanersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderRoom",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    RoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRoom", x => new { x.OrdersId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_OrderRoom_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderRoom_Room_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CleaningAddition",
                columns: new[] { "Id", "Duration", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 30, 0, 0), false, "Помыть пол", 500m },
                    { 2, new TimeSpan(0, 0, 30, 0, 0), false, "Почистить ковёр", 700m },
                    { 3, new TimeSpan(0, 1, 0, 0, 0), false, "Почистить мебель", 900m },
                    { 4, new TimeSpan(0, 0, 40, 0, 0), false, "Протереть пыль", 500m },
                    { 5, new TimeSpan(0, 0, 20, 0, 0), false, "Помыть зеркала", 400m },
                    { 6, new TimeSpan(0, 0, 15, 0, 0), false, "Застелить постель", 200m },
                    { 7, new TimeSpan(0, 0, 30, 0, 0), false, "Сложить вещи", 400m },
                    { 8, new TimeSpan(0, 0, 15, 0, 0), false, "Вынести мусор", 200m },
                    { 9, new TimeSpan(0, 0, 20, 0, 0), false, "Помыть люстру", 600m },
                    { 10, new TimeSpan(0, 0, 20, 0, 0), false, "Дезинфекция", 500m },
                    { 11, new TimeSpan(0, 0, 30, 0, 0), false, "Убраться в гардеробной", 600m },
                    { 12, new TimeSpan(0, 0, 15, 0, 0), false, "Помыть окно изнутри", 400m },
                    { 13, new TimeSpan(0, 0, 45, 0, 0), false, "Помыть окна на балконе изнутри", 700m },
                    { 14, new TimeSpan(0, 0, 35, 0, 0), false, "Убрать балкон", 600m },
                    { 15, new TimeSpan(0, 1, 0, 0, 0), false, "Погладить вещи", 600m },
                    { 16, new TimeSpan(0, 0, 40, 0, 0), false, "Доставить ключи", 300m },
                    { 17, new TimeSpan(0, 0, 40, 0, 0), false, "Забрать ключи", 300m },
                    { 18, new TimeSpan(0, 0, 15, 0, 0), false, "Помыть раковину", 400m },
                    { 19, new TimeSpan(0, 0, 15, 0, 0), false, "Помыть столешницу", 200m },
                    { 20, new TimeSpan(0, 0, 25, 0, 0), false, "Помыть плиту", 600m },
                    { 21, new TimeSpan(0, 0, 30, 0, 0), false, "Помыть обеденный стол", 500m },
                    { 22, new TimeSpan(0, 0, 50, 0, 0), false, "Помыть посуду", 600m },
                    { 23, new TimeSpan(0, 0, 40, 0, 0), false, "Помыть холодильник", 500m },
                    { 24, new TimeSpan(0, 0, 30, 0, 0), false, "Помыть духовку", 400m },
                    { 25, new TimeSpan(0, 0, 20, 0, 0), false, "Помыть микроволновку", 300m },
                    { 26, new TimeSpan(0, 1, 0, 0, 0), false, "Помыть шкафы на кухне", 800m },
                    { 27, new TimeSpan(0, 0, 40, 0, 0), false, "Помыть ванну или душевую", 800m },
                    { 28, new TimeSpan(0, 0, 25, 0, 0), false, "Помыть унитаз", 500m },
                    { 29, new TimeSpan(0, 0, 20, 0, 0), false, "Помыть биде", 300m },
                    { 30, new TimeSpan(0, 0, 10, 0, 0), false, "Помыть лоток", 200m },
                    { 31, new TimeSpan(0, 0, 30, 0, 0), false, "Убрать что-то ещё", 400m },
                    { 32, new TimeSpan(0, 1, 0, 0, 0), false, "Ебануть дробью", 0m }
                });

            migrationBuilder.InsertData(
                table: "CleaningType",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, "Поддерживающая", 3000m },
                    { 2, false, "Генеральная", 6000m },
                    { 3, false, "После ремонта", 8000m },
                    { 4, false, "Мытье окон", 2000m }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, "Жилая комната", 1100m },
                    { 2, false, "Гостиная", 1300m },
                    { 3, false, "Кухня", 1300m },
                    { 4, false, "Санузел", 800m },
                    { 5, false, "Гараж", 1700m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleaningAdditionCleaningType_CleaningTypesId",
                table: "CleaningAdditionCleaningType",
                column: "CleaningTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningAdditionOrder_OrdersId",
                table: "CleaningAdditionOrder",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningAdditionUser_UsersId",
                table: "CleaningAdditionUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_OrderId",
                table: "Grade",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CleaningTypeId",
                table: "Order",
                column: "CleaningTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCleaner_CleanersId",
                table: "OrderCleaner",
                column: "CleanersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRoom_RoomsId",
                table: "OrderRoom",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTime_UserId",
                table: "WorkingTime",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleaningAdditionCleaningType");

            migrationBuilder.DropTable(
                name: "CleaningAdditionOrder");

            migrationBuilder.DropTable(
                name: "CleaningAdditionUser");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "OrderCleaner");

            migrationBuilder.DropTable(
                name: "OrderRoom");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "WorkingTime");

            migrationBuilder.DropTable(
                name: "CleaningAddition");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "CleaningType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
