using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace registrationform.Migrations
{
    /// <inheritdoc />
    public partial class amas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "AuditModel");

            migrationBuilder.DropColumn(
                name: "IsFirstLogin",
                table: "AuditModel");

            migrationBuilder.DropColumn(
                name: "LangId",
                table: "AuditModel");

            migrationBuilder.DropColumn(
                name: "LoggedInAt",
                table: "AuditModel");

            migrationBuilder.DropColumn(
                name: "LoggedInStatus",
                table: "AuditModel");

            migrationBuilder.DropColumn(
                name: "LoggedOutAt",
                table: "AuditModel");

            migrationBuilder.DropColumn(
                name: "PageAccessed",
                table: "AuditModel");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "AuditModel");

            migrationBuilder.DropColumn(
                name: "UrlRefferer",
                table: "AuditModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AuditModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "AuditModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IsFirstLogin",
                table: "AuditModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LangId",
                table: "AuditModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LoggedInAt",
                table: "AuditModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LoggedInStatus",
                table: "AuditModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LoggedOutAt",
                table: "AuditModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PageAccessed",
                table: "AuditModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "AuditModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UrlRefferer",
                table: "AuditModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AuditModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
