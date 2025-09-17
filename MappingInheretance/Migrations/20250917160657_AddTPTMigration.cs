using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MappingInheritance.Migrations
{
    /// <inheritdoc />
    public partial class AddTPTMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "PartTimeEmployees");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "PartTimeEmployees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PartTimeEmployees");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "FullTimeEmployees");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "FullTimeEmployees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FullTimeEmployees");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PartTimeEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FullTimeEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FullTimeEmployees_Employees_Id",
                table: "FullTimeEmployees",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartTimeEmployees_Employees_Id",
                table: "PartTimeEmployees",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullTimeEmployees_Employees_Id",
                table: "FullTimeEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_PartTimeEmployees_Employees_Id",
                table: "PartTimeEmployees");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PartTimeEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PartTimeEmployees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "PartTimeEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PartTimeEmployees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FullTimeEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "FullTimeEmployees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "FullTimeEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FullTimeEmployees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
