using Microsoft.EntityFrameworkCore.Migrations;

namespace EDennis.SampleApp.Migrations.Generated
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "seqRgb");

            migrationBuilder.CreateTable(
                name: "Rgb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR seqRgb"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Red = table.Column<int>(type: "int", nullable: false),
                    Green = table.Column<int>(type: "int", nullable: false),
                    Blue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rgb", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rgb");

            migrationBuilder.DropSequence(
                name: "seqRgb");
        }
    }
}
