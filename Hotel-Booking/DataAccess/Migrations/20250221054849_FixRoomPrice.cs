using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixRoomPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PricePerNight",
                table: "HotelRooms",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 1, 1 },
                column: "PricePerNight",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 1, 2 },
                column: "PricePerNight",
                value: 175.0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 1, 3 },
                column: "PricePerNight",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 2, 1 },
                column: "PricePerNight",
                value: 120.0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 2, 2 },
                column: "PricePerNight",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 2, 3 },
                column: "PricePerNight",
                value: 320.0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 3, 1 },
                column: "PricePerNight",
                value: 175.0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 3, 2 },
                column: "PricePerNight",
                value: 230.0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 3, 3 },
                column: "PricePerNight",
                value: 400.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PricePerNight",
                table: "HotelRooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 1, 1 },
                column: "PricePerNight",
                value: 100);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 1, 2 },
                column: "PricePerNight",
                value: 175);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 1, 3 },
                column: "PricePerNight",
                value: 250);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 2, 1 },
                column: "PricePerNight",
                value: 120);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 2, 2 },
                column: "PricePerNight",
                value: 200);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 2, 3 },
                column: "PricePerNight",
                value: 320);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 3, 1 },
                column: "PricePerNight",
                value: 175);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 3, 2 },
                column: "PricePerNight",
                value: 230);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "BranchId", "RoomId" },
                keyValues: new object[] { 3, 3 },
                column: "PricePerNight",
                value: 400);
        }
    }
}
