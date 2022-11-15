using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDEMO.Migrations
{
    public partial class AddTbSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MSSV",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Infor",
                columns: table => new
                {
                    MSSV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SchoolName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Major = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infor", x => x.MSSV);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_User_MSSV",
                table: "User",
                column: "MSSV");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Infor_MSSV",
                table: "User",
                column: "MSSV",
                principalTable: "Infor",
                principalColumn: "MSSV",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Infor_MSSV",
                table: "User");

            migrationBuilder.DropTable(
                name: "Infor");

            migrationBuilder.DropIndex(
                name: "IX_User_MSSV",
                table: "User");

            migrationBuilder.DropColumn(
                name: "MSSV",
                table: "User");
        }
    }
}
