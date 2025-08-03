using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shope.DAL.data.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "active",
                table: "categories",
                newName: "Statuse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Statuse",
                table: "categories",
                newName: "active");
        }
    }
}
