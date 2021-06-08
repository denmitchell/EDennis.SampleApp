using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using System.Linq;

namespace EDennis.SampleApp {
    public partial class TestDataMigration : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {

            string MAIN_FOLDER = "TestDataMigration";
            //string TESTJSON_FOLDER = "TestDataMigration\\TestJson";

            migrationBuilder.Sql(File.ReadAllText($"{MAIN_FOLDER}\\BaseData.sql"));

            /*
            migrationBuilder.Sql("DELETE FROM _.TestJson;");
            void ExecFolder(string folder) {
                string[] files =
                    Directory.GetFiles(folder, "*.sql", SearchOption.AllDirectories)
                    .Union(Directory.GetFiles(folder, "*.Sql", SearchOption.AllDirectories))
                    .Union(Directory.GetFiles(folder, "*.SQL", SearchOption.AllDirectories))
                    .ToArray();
                foreach (string file in files)
                    migrationBuilder.Sql(File.ReadAllText(file));
            }
            ExecFolder(TESTJSON_FOLDER);
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            //migrationBuilder.Sql("DELETE FROM _.TestJson;");
        }
    }
}
