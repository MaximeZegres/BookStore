using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Persistence.Migrations
{
    public partial class orderItemObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Orders_OrderId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_OrderId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Books");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderDate",
                table: "Orders",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_OrderId",
                table: "Books",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Orders_OrderId",
                table: "Books",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
