using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class itemres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Minibar_Reservations_Minibars_MinibarId",
                table: "Minibar_Reservations");

            migrationBuilder.RenameColumn(
                name: "MinibarId",
                table: "Minibar_Reservations",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Minibar_Reservations_MinibarId",
                table: "Minibar_Reservations",
                newName: "IX_Minibar_Reservations_ItemId");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Minibar_Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Minibar_Reservations_Items_ItemId",
                table: "Minibar_Reservations",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Minibar_Reservations_Items_ItemId",
                table: "Minibar_Reservations");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Minibar_Reservations");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Minibar_Reservations",
                newName: "MinibarId");

            migrationBuilder.RenameIndex(
                name: "IX_Minibar_Reservations_ItemId",
                table: "Minibar_Reservations",
                newName: "IX_Minibar_Reservations_MinibarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Minibar_Reservations_Minibars_MinibarId",
                table: "Minibar_Reservations",
                column: "MinibarId",
                principalTable: "Minibars",
                principalColumn: "Id");
        }
    }
}
