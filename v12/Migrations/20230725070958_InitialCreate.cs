using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace v12.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customUsers",
                columns: table => new
                {
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    surname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customUsers", x => x.name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customUsers");
        }
    }
}
