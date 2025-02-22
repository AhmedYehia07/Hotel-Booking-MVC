using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelBranch_BranchId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_HotelBranch_BranchId",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_RoomTypes_RoomId",
                table: "HotelRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBranch",
                table: "HotelBranch");

            migrationBuilder.RenameTable(
                name: "HotelRoom",
                newName: "HotelRooms");

            migrationBuilder.RenameTable(
                name: "HotelBranch",
                newName: "HotelBranches");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_RoomId",
                table: "HotelRooms",
                newName: "IX_HotelRooms_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                columns: new[] { "BranchId", "RoomId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBranches",
                table: "HotelBranches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelBranches_BranchId",
                table: "Bookings",
                column: "BranchId",
                principalTable: "HotelBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_HotelBranches_BranchId",
                table: "HotelRooms",
                column: "BranchId",
                principalTable: "HotelBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_RoomTypes_RoomId",
                table: "HotelRooms",
                column: "RoomId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelBranches_BranchId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_HotelBranches_BranchId",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_RoomTypes_RoomId",
                table: "HotelRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBranches",
                table: "HotelBranches");

            migrationBuilder.RenameTable(
                name: "HotelRooms",
                newName: "HotelRoom");

            migrationBuilder.RenameTable(
                name: "HotelBranches",
                newName: "HotelBranch");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRooms_RoomId",
                table: "HotelRoom",
                newName: "IX_HotelRoom_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom",
                columns: new[] { "BranchId", "RoomId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBranch",
                table: "HotelBranch",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelBranch_BranchId",
                table: "Bookings",
                column: "BranchId",
                principalTable: "HotelBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_HotelBranch_BranchId",
                table: "HotelRoom",
                column: "BranchId",
                principalTable: "HotelBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_RoomTypes_RoomId",
                table: "HotelRoom",
                column: "RoomId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
