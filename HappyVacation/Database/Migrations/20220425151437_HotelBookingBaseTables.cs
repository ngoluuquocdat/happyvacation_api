using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class HotelBookingBaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(62)", maxLength: 62, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinChildAge = table.Column<int>(type: "int", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    HasParkingLot = table.Column<bool>(type: "bit", nullable: false),
                    HasBreakfast = table.Column<bool>(type: "bit", nullable: false),
                    PetAllowed = table.Column<bool>(type: "bit", nullable: false),
                    CreditCardRequired = table.Column<bool>(type: "bit", nullable: false),
                    PayInAdvance = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adults = table.Column<int>(type: "int", nullable: false),
                    Children = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(62)", maxLength: 62, nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAdults = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Views = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmokingAllowed = table.Column<bool>(type: "bit", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingDetails_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingDetails_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 13, 107, 194, 81, 27, 72, 231, 118, 175, 96, 129, 163, 158, 36, 77, 69, 31, 96, 1, 64, 13, 49, 245, 15, 30, 108, 193, 37, 224, 23, 204, 1, 217, 101, 124, 3, 82, 12, 157, 50, 58, 23, 186, 167, 198, 125, 102, 82, 89, 53, 116, 170, 90, 90, 181, 108, 175, 183, 98, 170, 27, 53, 185, 46 }, new byte[] { 158, 116, 178, 155, 29, 238, 182, 243, 101, 231, 114, 173, 110, 15, 40, 48, 115, 50, 78, 82, 67, 30, 205, 209, 29, 62, 93, 24, 25, 223, 162, 198, 130, 135, 250, 151, 206, 228, 202, 10, 9, 19, 128, 203, 50, 178, 155, 174, 168, 219, 186, 138, 253, 102, 65, 13, 212, 202, 18, 148, 196, 232, 86, 225, 119, 120, 232, 254, 228, 227, 252, 255, 182, 135, 2, 16, 37, 175, 236, 19, 99, 59, 123, 233, 46, 46, 10, 155, 135, 92, 212, 253, 225, 250, 231, 118, 99, 95, 90, 231, 248, 56, 145, 137, 22, 147, 35, 104, 127, 180, 130, 194, 124, 73, 207, 50, 153, 27, 61, 174, 203, 158, 221, 140, 174, 222, 5, 135 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 253, 110, 122, 231, 110, 93, 13, 123, 98, 154, 244, 73, 30, 230, 206, 78, 186, 226, 133, 215, 58, 16, 154, 113, 55, 235, 171, 152, 70, 86, 23, 145, 62, 68, 248, 45, 2, 48, 84, 164, 241, 180, 244, 31, 121, 252, 137, 85, 54, 22, 10, 131, 118, 98, 112, 189, 212, 98, 89, 226, 173, 215, 28, 113 }, new byte[] { 158, 116, 178, 155, 29, 238, 182, 243, 101, 231, 114, 173, 110, 15, 40, 48, 115, 50, 78, 82, 67, 30, 205, 209, 29, 62, 93, 24, 25, 223, 162, 198, 130, 135, 250, 151, 206, 228, 202, 10, 9, 19, 128, 203, 50, 178, 155, 174, 168, 219, 186, 138, 253, 102, 65, 13, 212, 202, 18, 148, 196, 232, 86, 225, 119, 120, 232, 254, 228, 227, 252, 255, 182, 135, 2, 16, 37, 175, 236, 19, 99, 59, 123, 233, 46, 46, 10, 155, 135, 92, 212, 253, 225, 250, 231, 118, 99, 95, 90, 231, 248, 56, 145, 137, 22, 147, 35, 104, 127, 180, 130, 194, 124, 73, 207, 50, 153, 27, 61, 174, 203, 158, 221, 140, 174, 222, 5, 135 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 53, 221, 129, 16, 234, 193, 226, 218, 69, 2, 83, 160, 166, 195, 168, 67, 186, 10, 203, 120, 71, 124, 138, 193, 166, 46, 190, 59, 23, 128, 92, 30, 229, 169, 251, 223, 88, 58, 253, 194, 50, 118, 216, 103, 54, 60, 246, 241, 249, 35, 10, 179, 215, 112, 228, 134, 126, 180, 65, 15, 36, 176, 238, 47 }, new byte[] { 158, 116, 178, 155, 29, 238, 182, 243, 101, 231, 114, 173, 110, 15, 40, 48, 115, 50, 78, 82, 67, 30, 205, 209, 29, 62, 93, 24, 25, 223, 162, 198, 130, 135, 250, 151, 206, 228, 202, 10, 9, 19, 128, 203, 50, 178, 155, 174, 168, 219, 186, 138, 253, 102, 65, 13, 212, 202, 18, 148, 196, 232, 86, 225, 119, 120, 232, 254, 228, 227, 252, 255, 182, 135, 2, 16, 37, 175, 236, 19, 99, 59, 123, 233, 46, 46, 10, 155, 135, 92, 212, 253, 225, 250, 231, 118, 99, 95, 90, 231, 248, 56, 145, 137, 22, 147, 35, 104, 127, 180, 130, 194, 124, 73, 207, 50, 153, 27, 61, 174, 203, 158, 221, 140, 174, 222, 5, 135 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 131, 223, 94, 225, 243, 96, 66, 251, 110, 180, 14, 99, 101, 54, 37, 204, 225, 2, 43, 69, 201, 215, 70, 210, 33, 194, 9, 192, 84, 91, 149, 98, 42, 3, 84, 244, 67, 159, 164, 104, 62, 61, 111, 28, 89, 246, 57, 148, 237, 221, 137, 4, 127, 173, 18, 108, 245, 62, 77, 1, 152, 101, 3, 60 }, new byte[] { 158, 116, 178, 155, 29, 238, 182, 243, 101, 231, 114, 173, 110, 15, 40, 48, 115, 50, 78, 82, 67, 30, 205, 209, 29, 62, 93, 24, 25, 223, 162, 198, 130, 135, 250, 151, 206, 228, 202, 10, 9, 19, 128, 203, 50, 178, 155, 174, 168, 219, 186, 138, 253, 102, 65, 13, 212, 202, 18, 148, 196, 232, 86, 225, 119, 120, 232, 254, 228, 227, 252, 255, 182, 135, 2, 16, 37, 175, 236, 19, 99, 59, 123, 233, 46, 46, 10, 155, 135, 92, 212, 253, 225, 250, 231, 118, 99, 95, 90, 231, 248, 56, 145, 137, 22, 147, 35, 104, 127, 180, 130, 194, 124, 73, 207, 50, 153, 27, 61, 174, 203, 158, 221, 140, 174, 222, 5, 135 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_HotelId",
                table: "Users",
                column: "HotelId",
                unique: true,
                filter: "[HotelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_BookingId",
                table: "BookingDetails",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_RoomId",
                table: "BookingDetails",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelId",
                table: "Bookings",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_PlaceId",
                table: "Hotels",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Hotels_HotelId",
                table: "Users",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Hotels_HotelId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Users_HotelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 32, 197, 139, 39, 149, 108, 151, 239, 80, 17, 63, 44, 248, 99, 30, 251, 25, 234, 211, 201, 147, 194, 116, 163, 149, 233, 67, 246, 220, 93, 239, 191, 90, 137, 10, 198, 35, 91, 116, 65, 184, 30, 76, 227, 54, 116, 124, 222, 89, 206, 205, 77, 172, 213, 225, 235, 113, 221, 163, 109, 129, 54, 165, 176 }, new byte[] { 243, 46, 255, 1, 96, 153, 106, 132, 76, 223, 64, 229, 24, 64, 89, 125, 142, 151, 162, 222, 42, 178, 180, 94, 172, 67, 39, 53, 3, 188, 59, 170, 40, 212, 88, 148, 226, 252, 254, 65, 62, 87, 74, 22, 245, 218, 81, 155, 68, 135, 4, 47, 194, 243, 155, 69, 72, 70, 27, 181, 88, 20, 240, 86, 138, 166, 186, 36, 10, 132, 119, 16, 6, 163, 174, 69, 160, 76, 254, 87, 39, 219, 129, 213, 243, 19, 79, 38, 47, 56, 88, 78, 182, 242, 70, 187, 68, 243, 2, 212, 22, 226, 142, 140, 196, 217, 195, 157, 43, 170, 211, 11, 50, 97, 14, 248, 137, 160, 26, 81, 117, 120, 213, 152, 189, 188, 226, 58 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 219, 64, 152, 183, 212, 241, 31, 151, 227, 215, 248, 230, 88, 106, 74, 45, 14, 229, 72, 178, 102, 57, 185, 218, 143, 202, 106, 189, 177, 58, 145, 245, 48, 95, 198, 190, 160, 114, 254, 92, 100, 242, 10, 252, 140, 164, 18, 32, 202, 46, 147, 212, 73, 240, 218, 52, 16, 206, 145, 4, 211, 128, 48, 36 }, new byte[] { 243, 46, 255, 1, 96, 153, 106, 132, 76, 223, 64, 229, 24, 64, 89, 125, 142, 151, 162, 222, 42, 178, 180, 94, 172, 67, 39, 53, 3, 188, 59, 170, 40, 212, 88, 148, 226, 252, 254, 65, 62, 87, 74, 22, 245, 218, 81, 155, 68, 135, 4, 47, 194, 243, 155, 69, 72, 70, 27, 181, 88, 20, 240, 86, 138, 166, 186, 36, 10, 132, 119, 16, 6, 163, 174, 69, 160, 76, 254, 87, 39, 219, 129, 213, 243, 19, 79, 38, 47, 56, 88, 78, 182, 242, 70, 187, 68, 243, 2, 212, 22, 226, 142, 140, 196, 217, 195, 157, 43, 170, 211, 11, 50, 97, 14, 248, 137, 160, 26, 81, 117, 120, 213, 152, 189, 188, 226, 58 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 173, 247, 236, 237, 53, 241, 143, 251, 131, 119, 114, 31, 1, 103, 175, 59, 72, 168, 197, 4, 181, 96, 184, 240, 111, 21, 44, 100, 126, 23, 198, 233, 43, 192, 27, 74, 36, 30, 2, 50, 151, 237, 140, 130, 211, 249, 218, 61, 88, 1, 179, 133, 172, 77, 146, 212, 90, 103, 80, 163, 230, 178, 18, 123 }, new byte[] { 243, 46, 255, 1, 96, 153, 106, 132, 76, 223, 64, 229, 24, 64, 89, 125, 142, 151, 162, 222, 42, 178, 180, 94, 172, 67, 39, 53, 3, 188, 59, 170, 40, 212, 88, 148, 226, 252, 254, 65, 62, 87, 74, 22, 245, 218, 81, 155, 68, 135, 4, 47, 194, 243, 155, 69, 72, 70, 27, 181, 88, 20, 240, 86, 138, 166, 186, 36, 10, 132, 119, 16, 6, 163, 174, 69, 160, 76, 254, 87, 39, 219, 129, 213, 243, 19, 79, 38, 47, 56, 88, 78, 182, 242, 70, 187, 68, 243, 2, 212, 22, 226, 142, 140, 196, 217, 195, 157, 43, 170, 211, 11, 50, 97, 14, 248, 137, 160, 26, 81, 117, 120, 213, 152, 189, 188, 226, 58 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 203, 222, 229, 0, 161, 212, 125, 156, 47, 36, 184, 221, 175, 3, 197, 170, 122, 236, 147, 226, 72, 76, 164, 97, 157, 16, 158, 78, 172, 8, 130, 63, 93, 101, 200, 88, 19, 112, 172, 87, 168, 247, 0, 184, 125, 12, 198, 42, 7, 94, 162, 104, 126, 116, 231, 187, 217, 138, 21, 215, 6, 80, 11 }, new byte[] { 243, 46, 255, 1, 96, 153, 106, 132, 76, 223, 64, 229, 24, 64, 89, 125, 142, 151, 162, 222, 42, 178, 180, 94, 172, 67, 39, 53, 3, 188, 59, 170, 40, 212, 88, 148, 226, 252, 254, 65, 62, 87, 74, 22, 245, 218, 81, 155, 68, 135, 4, 47, 194, 243, 155, 69, 72, 70, 27, 181, 88, 20, 240, 86, 138, 166, 186, 36, 10, 132, 119, 16, 6, 163, 174, 69, 160, 76, 254, 87, 39, 219, 129, 213, 243, 19, 79, 38, 47, 56, 88, 78, 182, 242, 70, 187, 68, 243, 2, 212, 22, 226, 142, 140, 196, 217, 195, 157, 43, 170, 211, 11, 50, 97, 14, 248, 137, 160, 26, 81, 117, 120, 213, 152, 189, 188, 226, 58 } });
        }
    }
}
