using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallRegisterWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Emails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDue",
                table: "Emails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCompleted",
                table: "Emails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AllocatedDate",
                table: "Emails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<bool>(
                name: "Complete",
                table: "Emails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Emails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ProductsId",
                table: "Emails",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Products_ProductsId",
                table: "Emails",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Products_ProductsId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_ProductsId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "Complete",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Emails");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateDue",
                table: "Emails",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateCompleted",
                table: "Emails",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "AllocatedDate",
                table: "Emails",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
