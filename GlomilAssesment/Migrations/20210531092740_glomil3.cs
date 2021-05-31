using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GlomilAssesment.Migrations
{
    public partial class glomil3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserName",
                table: "mathEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "mathDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    input1 = table.Column<double>(type: "double precision", nullable: false),
                    input2 = table.Column<double>(type: "double precision", nullable: false),
                    sonuc1 = table.Column<double>(type: "double precision", nullable: false),
                    sonuc2 = table.Column<double>(type: "double precision", nullable: false),
                    sonuc3 = table.Column<double>(type: "double precision", nullable: false),
                    sonuc4 = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mathDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MathVM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    input1 = table.Column<double>(type: "double precision", nullable: false),
                    input2 = table.Column<double>(type: "double precision", nullable: false),
                    sonuc1 = table.Column<double>(type: "double precision", nullable: false),
                    sonuc2 = table.Column<double>(type: "double precision", nullable: false),
                    sonuc3 = table.Column<double>(type: "double precision", nullable: false),
                    sonuc4 = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MathVM", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mathEntity_UserName",
                table: "mathEntity",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_mathEntity_Users_UserName",
                table: "mathEntity",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mathEntity_Users_UserName",
                table: "mathEntity");

            migrationBuilder.DropTable(
                name: "mathDetails");

            migrationBuilder.DropTable(
                name: "MathVM");

            migrationBuilder.DropIndex(
                name: "IX_mathEntity_UserName",
                table: "mathEntity");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "mathEntity");
        }
    }
}
