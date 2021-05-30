using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GlomilAssesment.Migrations
{
    public partial class glomil2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BornYear",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "mathEntity",
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
                    table.PrimaryKey("PK_mathEntity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRegisterVM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    BornYear = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegisterVM", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mathEntity");

            migrationBuilder.DropTable(
                name: "UserRegisterVM");

            migrationBuilder.DropColumn(
                name: "BornYear",
                table: "Users");
        }
    }
}
