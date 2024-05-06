using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace registrationform.Migrations
{
    /// <inheritdoc />
    public partial class aud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditModel",
                table: "AuditModel");

            migrationBuilder.RenameTable(
                name: "AuditModel",
                newName: "Audit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audit",
                table: "Audit",
                column: "AuditId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Audit",
                table: "Audit");

            migrationBuilder.RenameTable(
                name: "Audit",
                newName: "AuditModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditModel",
                table: "AuditModel",
                column: "AuditId");
        }
    }
}
