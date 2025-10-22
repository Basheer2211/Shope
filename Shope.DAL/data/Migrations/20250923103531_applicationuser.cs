using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shope.DAL.data.Migrations
{
    /// <inheritdoc />
    public partial class applicationuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryCode",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "codeResetPassword",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryCode",
                table: "User");

            migrationBuilder.DropColumn(
                name: "codeResetPassword",
                table: "User");
        }
    }
}
