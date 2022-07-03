using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class firstMiWedding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Users_UserID",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Weddings_WeddingID",
                table: "Associations");

            migrationBuilder.DropTable(
                name: "UserWedding");

            migrationBuilder.AddColumn<int>(
                name: "Owner",
                table: "Weddings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WeddingID",
                table: "Associations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Associations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Users_UserID",
                table: "Associations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Weddings_WeddingID",
                table: "Associations",
                column: "WeddingID",
                principalTable: "Weddings",
                principalColumn: "WeddingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Users_UserID",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Weddings_WeddingID",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Weddings");

            migrationBuilder.AlterColumn<int>(
                name: "WeddingID",
                table: "Associations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Associations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserWedding",
                columns: table => new
                {
                    UsersUserID = table.Column<int>(type: "int", nullable: false),
                    WeddingsWeddingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWedding", x => new { x.UsersUserID, x.WeddingsWeddingID });
                    table.ForeignKey(
                        name: "FK_UserWedding_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWedding_Weddings_WeddingsWeddingID",
                        column: x => x.WeddingsWeddingID,
                        principalTable: "Weddings",
                        principalColumn: "WeddingID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserWedding_WeddingsWeddingID",
                table: "UserWedding",
                column: "WeddingsWeddingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Users_UserID",
                table: "Associations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Weddings_WeddingID",
                table: "Associations",
                column: "WeddingID",
                principalTable: "Weddings",
                principalColumn: "WeddingID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
