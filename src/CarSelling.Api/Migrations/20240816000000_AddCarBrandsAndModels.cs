using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSelling.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCarBrandsAndModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsLuxury = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CarBrandId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: false, defaultValue: 1990),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_CarBrands_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBrands_Country",
                table: "CarBrands",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_CarBrands_IsActive",
                table: "CarBrands",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CarBrands_IsLuxury",
                table: "CarBrands",
                column: "IsLuxury");

            migrationBuilder.CreateIndex(
                name: "IX_CarBrands_Name",
                table: "CarBrands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarBrandId",
                table: "CarModels",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarBrandId_Name",
                table: "CarModels",
                columns: new[] { "CarBrandId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_Category",
                table: "CarModels",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_EndYear",
                table: "CarModels",
                column: "EndYear");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_IsActive",
                table: "CarModels",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_Name",
                table: "CarModels",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_StartYear",
                table: "CarModels",
                column: "StartYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CarBrands");
        }
    }
}