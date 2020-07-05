using Microsoft.EntityFrameworkCore.Migrations;

namespace DeployBothSystem.Dal.Migrations.DeployBothSystem
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boths",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Property = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boths", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boths");
        }
    }
}
