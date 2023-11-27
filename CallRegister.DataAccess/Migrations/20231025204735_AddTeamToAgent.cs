using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallRegisterWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamToAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Team",
                value: "Distribution");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Team",
                value: "Distribution");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Team",
                value: "Actuator");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                column: "Team",
                value: "Air and Fluid");

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Name", "Team" },
                values: new object[] { 5, "Kenny", "Electrical" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Team",
                table: "Agents");
        }
    }
}
