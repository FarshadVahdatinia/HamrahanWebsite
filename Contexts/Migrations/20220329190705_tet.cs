using Microsoft.EntityFrameworkCore.Migrations;

namespace HamrahanTemplate.persistence.Migrations
{
    public partial class tet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(101)",
                maxLength: 101,
                nullable: false,
                computedColumnSql: "(([FirstName]+'')+[Lastname])",
                stored: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(101)",
                oldMaxLength: 101,
                oldComputedColumnSql: "(([FirstName]+'')+[Lastname])");
        }
    }
}
