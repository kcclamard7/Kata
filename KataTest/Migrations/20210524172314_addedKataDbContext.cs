using Microsoft.EntityFrameworkCore.Migrations;

namespace KataTest.Migrations
{
    public partial class addedKataDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "calculations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FristNumber = table.Column<decimal>(nullable: false),
                    SecondNumer = table.Column<decimal>(nullable: false),
                    Result = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calculations", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calculations");
        }
    }
}
