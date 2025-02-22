using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "HotelBranches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HotelBranches",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/Images/Branches/Cairo.jpg");

            migrationBuilder.UpdateData(
                table: "HotelBranches",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "~/Images/Branches/Aswan.jpg");

            migrationBuilder.UpdateData(
                table: "HotelBranches",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "~/Images/Branches/Sharm.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "HotelBranches");
        }
    }
}
