using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class Place_SubTouristSite_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTop",
                table: "Places");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Places",
                type: "decimal(18,9)",
                precision: 18,
                scale: 9,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Places",
                type: "decimal(18,9)",
                precision: 18,
                scale: 9,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PlaceImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceImages_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceOverviewVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOverviewVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceOverviewVideos_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTouristSites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HighLights = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenCloseTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTouristSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTouristSites_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TouristSiteImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTouristSiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSiteImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristSiteImages_SubTouristSites_SubTouristSiteId",
                        column: x => x.SubTouristSiteId,
                        principalTable: "SubTouristSites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 16.047079m, 108.206230m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 16.463713m, 107.590866m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 15.87944m, 108.335m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 20.959902m, 107.042542m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 21.028511m, 105.804817m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 10.762622m, 106.660172m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 11.940419m, 108.458313m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 12.24507m, 109.19432m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 10.289879m, 103.98402m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 13.759660m, 109.206123m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 22.356464m, 103.873802m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 10.541740m, 107.242998m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 10.933211m, 108.287184m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 8.68327m, 106.606m });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 20.256667m, 105.896389m });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 153, 97, 90, 36, 1, 236, 177, 161, 180, 221, 193, 170, 53, 246, 183, 194, 12, 182, 71, 29, 76, 112, 78, 67, 58, 152, 111, 107, 138, 142, 192, 183, 85, 23, 228, 141, 197, 22, 215, 138, 88, 78, 99, 65, 202, 92, 197, 22, 123, 5, 45, 141, 114, 222, 49, 59, 33, 154, 155, 172, 118, 193, 207, 135 }, new byte[] { 99, 82, 52, 82, 166, 185, 206, 69, 103, 97, 222, 192, 105, 51, 96, 184, 202, 26, 173, 152, 6, 17, 188, 243, 14, 5, 21, 188, 236, 127, 15, 205, 11, 93, 108, 125, 57, 134, 219, 212, 227, 237, 83, 26, 72, 125, 231, 196, 16, 80, 163, 177, 226, 22, 42, 59, 252, 157, 84, 237, 244, 19, 119, 144, 80, 214, 202, 59, 141, 4, 211, 172, 217, 122, 6, 17, 65, 169, 239, 95, 21, 69, 99, 97, 157, 175, 102, 52, 92, 209, 112, 212, 94, 187, 196, 84, 89, 19, 69, 94, 228, 85, 26, 89, 24, 58, 169, 119, 7, 170, 88, 105, 88, 122, 65, 200, 28, 183, 202, 35, 23, 180, 80, 89, 127, 183, 43, 78 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 29, 134, 41, 79, 113, 138, 114, 51, 143, 11, 146, 251, 92, 22, 24, 8, 90, 50, 136, 203, 198, 177, 179, 130, 169, 32, 86, 105, 198, 96, 139, 32, 63, 58, 18, 99, 130, 239, 32, 101, 14, 115, 246, 180, 41, 205, 178, 160, 135, 211, 250, 89, 148, 123, 35, 76, 12, 254, 39, 156, 117, 214, 149, 16 }, new byte[] { 99, 82, 52, 82, 166, 185, 206, 69, 103, 97, 222, 192, 105, 51, 96, 184, 202, 26, 173, 152, 6, 17, 188, 243, 14, 5, 21, 188, 236, 127, 15, 205, 11, 93, 108, 125, 57, 134, 219, 212, 227, 237, 83, 26, 72, 125, 231, 196, 16, 80, 163, 177, 226, 22, 42, 59, 252, 157, 84, 237, 244, 19, 119, 144, 80, 214, 202, 59, 141, 4, 211, 172, 217, 122, 6, 17, 65, 169, 239, 95, 21, 69, 99, 97, 157, 175, 102, 52, 92, 209, 112, 212, 94, 187, 196, 84, 89, 19, 69, 94, 228, 85, 26, 89, 24, 58, 169, 119, 7, 170, 88, 105, 88, 122, 65, 200, 28, 183, 202, 35, 23, 180, 80, 89, 127, 183, 43, 78 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 216, 202, 101, 19, 195, 143, 152, 152, 146, 114, 70, 63, 33, 112, 137, 103, 75, 6, 56, 115, 220, 48, 64, 45, 92, 98, 157, 202, 165, 239, 9, 234, 254, 167, 138, 88, 255, 108, 242, 159, 91, 80, 58, 158, 227, 0, 193, 152, 78, 171, 242, 189, 61, 101, 63, 140, 222, 237, 140, 18, 208, 50, 197, 49 }, new byte[] { 99, 82, 52, 82, 166, 185, 206, 69, 103, 97, 222, 192, 105, 51, 96, 184, 202, 26, 173, 152, 6, 17, 188, 243, 14, 5, 21, 188, 236, 127, 15, 205, 11, 93, 108, 125, 57, 134, 219, 212, 227, 237, 83, 26, 72, 125, 231, 196, 16, 80, 163, 177, 226, 22, 42, 59, 252, 157, 84, 237, 244, 19, 119, 144, 80, 214, 202, 59, 141, 4, 211, 172, 217, 122, 6, 17, 65, 169, 239, 95, 21, 69, 99, 97, 157, 175, 102, 52, 92, 209, 112, 212, 94, 187, 196, 84, 89, 19, 69, 94, 228, 85, 26, 89, 24, 58, 169, 119, 7, 170, 88, 105, 88, 122, 65, 200, 28, 183, 202, 35, 23, 180, 80, 89, 127, 183, 43, 78 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 47, 145, 166, 140, 162, 3, 237, 239, 32, 27, 244, 119, 94, 80, 113, 3, 41, 170, 4, 121, 235, 32, 109, 72, 1, 52, 23, 87, 250, 148, 229, 230, 37, 159, 118, 213, 213, 109, 186, 192, 38, 90, 149, 55, 138, 182, 93, 94, 19, 207, 224, 168, 228, 212, 215, 101, 20, 91, 44, 176, 239, 170, 134, 150 }, new byte[] { 99, 82, 52, 82, 166, 185, 206, 69, 103, 97, 222, 192, 105, 51, 96, 184, 202, 26, 173, 152, 6, 17, 188, 243, 14, 5, 21, 188, 236, 127, 15, 205, 11, 93, 108, 125, 57, 134, 219, 212, 227, 237, 83, 26, 72, 125, 231, 196, 16, 80, 163, 177, 226, 22, 42, 59, 252, 157, 84, 237, 244, 19, 119, 144, 80, 214, 202, 59, 141, 4, 211, 172, 217, 122, 6, 17, 65, 169, 239, 95, 21, 69, 99, 97, 157, 175, 102, 52, 92, 209, 112, 212, 94, 187, 196, 84, 89, 19, 69, 94, 228, 85, 26, 89, 24, 58, 169, 119, 7, 170, 88, 105, 88, 122, 65, 200, 28, 183, 202, 35, 23, 180, 80, 89, 127, 183, 43, 78 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 21, 247, 218, 27, 25, 3, 44, 103, 113, 4, 172, 4, 181, 246, 205, 20, 12, 177, 152, 7, 255, 252, 189, 178, 145, 241, 55, 189, 175, 202, 80, 122, 119, 67, 174, 159, 136, 58, 61, 99, 81, 213, 185, 26, 118, 193, 184, 41, 34, 172, 5, 231, 107, 110, 116, 17, 140, 228, 177, 183, 238, 160, 203, 86 }, new byte[] { 99, 82, 52, 82, 166, 185, 206, 69, 103, 97, 222, 192, 105, 51, 96, 184, 202, 26, 173, 152, 6, 17, 188, 243, 14, 5, 21, 188, 236, 127, 15, 205, 11, 93, 108, 125, 57, 134, 219, 212, 227, 237, 83, 26, 72, 125, 231, 196, 16, 80, 163, 177, 226, 22, 42, 59, 252, 157, 84, 237, 244, 19, 119, 144, 80, 214, 202, 59, 141, 4, 211, 172, 217, 122, 6, 17, 65, 169, 239, 95, 21, 69, 99, 97, 157, 175, 102, 52, 92, 209, 112, 212, 94, 187, 196, 84, 89, 19, 69, 94, 228, 85, 26, 89, 24, 58, 169, 119, 7, 170, 88, 105, 88, 122, 65, 200, 28, 183, 202, 35, 23, 180, 80, 89, 127, 183, 43, 78 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 91, 85, 194, 99, 48, 165, 199, 176, 42, 176, 86, 136, 194, 245, 54, 68, 94, 22, 202, 26, 235, 156, 158, 85, 42, 110, 228, 40, 118, 138, 178, 32, 224, 154, 113, 250, 147, 116, 77, 32, 148, 70, 93, 215, 223, 194, 163, 211, 96, 44, 66, 157, 74, 230, 105, 234, 246, 23, 35, 37, 110, 110, 198, 185 }, new byte[] { 99, 82, 52, 82, 166, 185, 206, 69, 103, 97, 222, 192, 105, 51, 96, 184, 202, 26, 173, 152, 6, 17, 188, 243, 14, 5, 21, 188, 236, 127, 15, 205, 11, 93, 108, 125, 57, 134, 219, 212, 227, 237, 83, 26, 72, 125, 231, 196, 16, 80, 163, 177, 226, 22, 42, 59, 252, 157, 84, 237, 244, 19, 119, 144, 80, 214, 202, 59, 141, 4, 211, 172, 217, 122, 6, 17, 65, 169, 239, 95, 21, 69, 99, 97, 157, 175, 102, 52, 92, 209, 112, 212, 94, 187, 196, 84, 89, 19, 69, 94, 228, 85, 26, 89, 24, 58, 169, 119, 7, 170, 88, 105, 88, 122, 65, 200, 28, 183, 202, 35, 23, 180, 80, 89, 127, 183, 43, 78 } });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceImages_PlaceId",
                table: "PlaceImages",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOverviewVideos_PlaceId",
                table: "PlaceOverviewVideos",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTouristSites_PlaceId",
                table: "SubTouristSites",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristSiteImages_SubTouristSiteId",
                table: "TouristSiteImages",
                column: "SubTouristSiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceImages");

            migrationBuilder.DropTable(
                name: "PlaceOverviewVideos");

            migrationBuilder.DropTable(
                name: "TouristSiteImages");

            migrationBuilder.DropTable(
                name: "SubTouristSites");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Places");

            migrationBuilder.AddColumn<bool>(
                name: "IsTop",
                table: "Places",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsTop",
                value: true);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsTop",
                value: true);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsTop",
                value: true);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsTop",
                value: true);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsTop",
                value: true);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsTop",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 71, 196, 112, 236, 71, 244, 124, 139, 9, 154, 178, 134, 175, 5, 166, 179, 100, 24, 148, 161, 249, 118, 166, 250, 145, 7, 2, 147, 37, 141, 55, 215, 250, 222, 14, 193, 50, 9, 167, 168, 121, 237, 88, 93, 114, 75, 18, 77, 200, 34, 69, 95, 229, 125, 90, 113, 61, 173, 171, 40, 229, 252, 124 }, new byte[] { 96, 46, 33, 235, 31, 36, 22, 240, 229, 215, 169, 88, 77, 1, 133, 111, 183, 255, 37, 177, 220, 190, 201, 43, 164, 160, 217, 192, 64, 12, 37, 152, 124, 119, 51, 6, 38, 113, 93, 9, 18, 239, 185, 3, 61, 111, 152, 87, 173, 63, 179, 148, 166, 178, 232, 65, 165, 68, 149, 195, 235, 216, 221, 86, 80, 238, 58, 103, 243, 25, 108, 6, 230, 122, 9, 141, 68, 125, 166, 124, 44, 82, 46, 68, 177, 67, 147, 201, 55, 6, 147, 122, 133, 109, 208, 133, 12, 107, 178, 234, 19, 208, 69, 145, 106, 146, 190, 206, 66, 80, 164, 11, 70, 154, 141, 125, 34, 216, 145, 226, 127, 218, 15, 134, 183, 148, 28, 250 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 219, 245, 78, 213, 144, 77, 234, 88, 25, 238, 252, 64, 95, 219, 105, 28, 108, 208, 35, 4, 180, 203, 113, 76, 218, 100, 180, 46, 171, 13, 124, 4, 26, 52, 222, 215, 152, 50, 193, 138, 251, 3, 203, 198, 122, 42, 46, 154, 158, 205, 161, 243, 81, 131, 228, 59, 201, 143, 35, 136, 17, 30, 62, 94 }, new byte[] { 96, 46, 33, 235, 31, 36, 22, 240, 229, 215, 169, 88, 77, 1, 133, 111, 183, 255, 37, 177, 220, 190, 201, 43, 164, 160, 217, 192, 64, 12, 37, 152, 124, 119, 51, 6, 38, 113, 93, 9, 18, 239, 185, 3, 61, 111, 152, 87, 173, 63, 179, 148, 166, 178, 232, 65, 165, 68, 149, 195, 235, 216, 221, 86, 80, 238, 58, 103, 243, 25, 108, 6, 230, 122, 9, 141, 68, 125, 166, 124, 44, 82, 46, 68, 177, 67, 147, 201, 55, 6, 147, 122, 133, 109, 208, 133, 12, 107, 178, 234, 19, 208, 69, 145, 106, 146, 190, 206, 66, 80, 164, 11, 70, 154, 141, 125, 34, 216, 145, 226, 127, 218, 15, 134, 183, 148, 28, 250 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 180, 42, 193, 25, 43, 118, 228, 6, 238, 48, 151, 8, 240, 92, 4, 175, 246, 197, 65, 140, 79, 234, 32, 77, 31, 97, 92, 15, 116, 35, 224, 7, 64, 223, 177, 178, 247, 137, 4, 3, 197, 19, 197, 31, 23, 155, 158, 65, 27, 91, 77, 130, 179, 146, 110, 247, 9, 123, 210, 118, 44, 13, 39, 151 }, new byte[] { 96, 46, 33, 235, 31, 36, 22, 240, 229, 215, 169, 88, 77, 1, 133, 111, 183, 255, 37, 177, 220, 190, 201, 43, 164, 160, 217, 192, 64, 12, 37, 152, 124, 119, 51, 6, 38, 113, 93, 9, 18, 239, 185, 3, 61, 111, 152, 87, 173, 63, 179, 148, 166, 178, 232, 65, 165, 68, 149, 195, 235, 216, 221, 86, 80, 238, 58, 103, 243, 25, 108, 6, 230, 122, 9, 141, 68, 125, 166, 124, 44, 82, 46, 68, 177, 67, 147, 201, 55, 6, 147, 122, 133, 109, 208, 133, 12, 107, 178, 234, 19, 208, 69, 145, 106, 146, 190, 206, 66, 80, 164, 11, 70, 154, 141, 125, 34, 216, 145, 226, 127, 218, 15, 134, 183, 148, 28, 250 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 138, 74, 3, 35, 17, 164, 234, 211, 7, 178, 58, 137, 104, 247, 160, 149, 180, 234, 204, 128, 115, 29, 204, 233, 214, 254, 160, 68, 79, 187, 50, 69, 2, 163, 238, 92, 17, 109, 198, 165, 182, 187, 185, 40, 73, 101, 203, 159, 223, 34, 190, 53, 197, 71, 190, 199, 110, 126, 152, 197, 14, 47, 194, 146 }, new byte[] { 96, 46, 33, 235, 31, 36, 22, 240, 229, 215, 169, 88, 77, 1, 133, 111, 183, 255, 37, 177, 220, 190, 201, 43, 164, 160, 217, 192, 64, 12, 37, 152, 124, 119, 51, 6, 38, 113, 93, 9, 18, 239, 185, 3, 61, 111, 152, 87, 173, 63, 179, 148, 166, 178, 232, 65, 165, 68, 149, 195, 235, 216, 221, 86, 80, 238, 58, 103, 243, 25, 108, 6, 230, 122, 9, 141, 68, 125, 166, 124, 44, 82, 46, 68, 177, 67, 147, 201, 55, 6, 147, 122, 133, 109, 208, 133, 12, 107, 178, 234, 19, 208, 69, 145, 106, 146, 190, 206, 66, 80, 164, 11, 70, 154, 141, 125, 34, 216, 145, 226, 127, 218, 15, 134, 183, 148, 28, 250 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 28, 76, 206, 33, 141, 107, 154, 132, 77, 27, 163, 31, 222, 104, 218, 194, 88, 203, 236, 86, 24, 141, 154, 6, 234, 222, 146, 48, 165, 16, 174, 69, 84, 227, 104, 49, 127, 231, 23, 117, 70, 138, 212, 234, 163, 205, 246, 248, 123, 22, 116, 78, 94, 69, 192, 96, 13, 214, 132, 42, 226, 53, 225, 243 }, new byte[] { 96, 46, 33, 235, 31, 36, 22, 240, 229, 215, 169, 88, 77, 1, 133, 111, 183, 255, 37, 177, 220, 190, 201, 43, 164, 160, 217, 192, 64, 12, 37, 152, 124, 119, 51, 6, 38, 113, 93, 9, 18, 239, 185, 3, 61, 111, 152, 87, 173, 63, 179, 148, 166, 178, 232, 65, 165, 68, 149, 195, 235, 216, 221, 86, 80, 238, 58, 103, 243, 25, 108, 6, 230, 122, 9, 141, 68, 125, 166, 124, 44, 82, 46, 68, 177, 67, 147, 201, 55, 6, 147, 122, 133, 109, 208, 133, 12, 107, 178, 234, 19, 208, 69, 145, 106, 146, 190, 206, 66, 80, 164, 11, 70, 154, 141, 125, 34, 216, 145, 226, 127, 218, 15, 134, 183, 148, 28, 250 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 218, 109, 166, 29, 64, 218, 246, 42, 142, 112, 36, 250, 165, 14, 128, 72, 244, 207, 174, 119, 102, 92, 227, 82, 68, 139, 32, 189, 5, 0, 105, 71, 139, 37, 31, 130, 59, 192, 77, 240, 93, 227, 62, 103, 40, 129, 95, 150, 134, 178, 157, 216, 17, 101, 3, 95, 82, 106, 222, 199, 231, 247, 1, 171 }, new byte[] { 96, 46, 33, 235, 31, 36, 22, 240, 229, 215, 169, 88, 77, 1, 133, 111, 183, 255, 37, 177, 220, 190, 201, 43, 164, 160, 217, 192, 64, 12, 37, 152, 124, 119, 51, 6, 38, 113, 93, 9, 18, 239, 185, 3, 61, 111, 152, 87, 173, 63, 179, 148, 166, 178, 232, 65, 165, 68, 149, 195, 235, 216, 221, 86, 80, 238, 58, 103, 243, 25, 108, 6, 230, 122, 9, 141, 68, 125, 166, 124, 44, 82, 46, 68, 177, 67, 147, 201, 55, 6, 147, 122, 133, 109, 208, 133, 12, 107, 178, 234, 19, 208, 69, 145, 106, 146, 190, 206, 66, 80, 164, 11, 70, 154, 141, 125, 34, 216, 145, 226, 127, 218, 15, 134, 183, 148, 28, 250 } });
        }
    }
}
