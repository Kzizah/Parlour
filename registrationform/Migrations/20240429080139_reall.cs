using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace registrationform.Migrations
{
    /// <inheritdoc />
    public partial class reall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "Discriminator",
               table: "AspNetUsers",
               type: "varchar(21)",
               maxLength: 21,
               nullable: false,
               defaultValue: "")
               .Annotation("MySql:CharSet", "utf8mb4");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
