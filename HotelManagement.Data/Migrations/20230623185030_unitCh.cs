using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class unitCh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccommodationUnits_Characteristics_CharacteristicsId",
                table: "AccommodationUnits");

            migrationBuilder.DropIndex(
                name: "IX_AccommodationUnits_CharacteristicsId",
                table: "AccommodationUnits");

            migrationBuilder.DropColumn(
                name: "CharacteristicsId",
                table: "AccommodationUnits");

            migrationBuilder.CreateTable(
                name: "AUnit_Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccommodationUnitId = table.Column<int>(type: "int", nullable: false),
                    CharacteristicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUnit_Characteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AUnit_Characteristics_AccommodationUnits_AccommodationUnitId",
                        column: x => x.AccommodationUnitId,
                        principalTable: "AccommodationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AUnit_Characteristics_Characteristics_CharacteristicsId",
                        column: x => x.CharacteristicsId,
                        principalTable: "Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUnit_Characteristics_AccommodationUnitId",
                table: "AUnit_Characteristics",
                column: "AccommodationUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AUnit_Characteristics_CharacteristicsId",
                table: "AUnit_Characteristics",
                column: "CharacteristicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUnit_Characteristics");

            migrationBuilder.AddColumn<int>(
                name: "CharacteristicsId",
                table: "AccommodationUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationUnits_CharacteristicsId",
                table: "AccommodationUnits",
                column: "CharacteristicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccommodationUnits_Characteristics_CharacteristicsId",
                table: "AccommodationUnits",
                column: "CharacteristicsId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
