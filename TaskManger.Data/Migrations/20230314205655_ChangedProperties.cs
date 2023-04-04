using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desctiption",
                table: "TaskList",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "TaskList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "TaskList");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TaskList",
                newName: "Desctiption");
        }
    }
}
