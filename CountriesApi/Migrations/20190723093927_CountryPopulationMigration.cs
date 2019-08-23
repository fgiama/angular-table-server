using Microsoft.EntityFrameworkCore.Migrations;

namespace CountriesApi.Migrations
{
    public partial class CountryPopulationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Population",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Population",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
