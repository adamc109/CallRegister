using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallRegisterWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team",
                table: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamsId",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TeamId", "TeamsId" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TeamId", "TeamsId" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TeamId", "TeamsId" },
                values: new object[] { 3, null });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TeamId", "TeamsId" },
                values: new object[] { 3, null });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "TeamId", "TeamsId" },
                values: new object[] { 4, null });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_TeamsId",
                table: "Agents",
                column: "TeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Teams_TeamsId",
                table: "Agents",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Teams_TeamsId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_TeamsId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "TeamsId",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Agents",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                column: "Team",
                value: "Electrical");
        }
    }
}
