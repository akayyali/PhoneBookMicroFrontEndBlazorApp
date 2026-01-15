using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondDBupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "contacts",
                table: "Contacts",
                newName: "FirstNamee");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_FirstName",
                schema: "contacts",
                table: "Contacts",
                newName: "IX_Contacts_FirstNamee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstNamee",
                schema: "contacts",
                table: "Contacts",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_FirstNamee",
                schema: "contacts",
                table: "Contacts",
                newName: "IX_Contacts_FirstName");
        }
    }
}
