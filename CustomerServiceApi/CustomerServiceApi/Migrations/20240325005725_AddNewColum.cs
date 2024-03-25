using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerServiceApi.Migrations
{
    public partial class AddNewColum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Forms_FormId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "FormId",
                table: "Purchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Forms_FormId",
                table: "Purchases",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Forms_FormId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "FormId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Forms_FormId",
                table: "Purchases",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
