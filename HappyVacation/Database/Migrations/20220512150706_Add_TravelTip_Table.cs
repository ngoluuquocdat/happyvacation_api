﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class Add_TravelTip_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelTips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelTips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelTips_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TravelTips",
                columns: new[] { "Id", "Content", "PlaceId", "Title" },
                values: new object[,]
                {
                    { 1, "You can visit Hoi An by taxi, motorbike, bicycle, cyclo, or walking. If you choose to use a motorbike, remember to know clearly about some streets where the motorbikes are crossing prohibited. In the evening, it will be great if you walk along the Thu Bon river to admire the stunning beauty of Hoi An at night. Another choice that you can go by cyclo but when walking you can save your expenses and enjoy street foods here.", 3, "Transportations in Hoi An" },
                    { 2, "Some hotels, restaurants, and shops may accept payment in USD, but you should always pay in VND. If something is priced in VND, then you should definitely pay for it in VND because using any other currency will lead to terrible exchange rates. As advised, the best place to get VND in Hoi An is at gold/jewelry shops and banks, or from ATMs.", 3, "Should pay in VND" },
                    { 3, "If you are visiting during the hot summer months, don’t forget to hydrate. In summer, the temperature can reach 34-37C. Made sure each of us had 2L bottle of water and drank all of it by the end of each day. The best time to visit Hoi An is from February to July, with low rainfall and amicable weather. The period from May to July can be extremely hot, but with the cool breeze from the ocean and the low intensity of buildings, Hoi An is just as nice to visit.", 3, "Weather in Hoi An" },
                    { 4, "T-shirts and shorts are okay almost anywhere, but it’s preferable to wear longer trousers and cover your shoulders if you’re visiting temples and other holy places. Likewise, bikinis and swim-shorts are fine on the beach, but refrain from dressing scantily in towns or on the street.", 3, "Dress sensibly" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 215, 124, 222, 93, 10, 241, 220, 4, 145, 11, 243, 138, 60, 205, 2, 81, 173, 111, 165, 31, 186, 226, 31, 216, 140, 98, 169, 202, 50, 145, 254, 20, 76, 195, 180, 99, 10, 249, 121, 168, 5, 77, 159, 158, 118, 204, 195, 110, 122, 90, 85, 63, 205, 205, 193, 249, 6, 227, 204, 184, 33, 129, 18, 116 }, new byte[] { 67, 255, 4, 127, 52, 44, 138, 34, 105, 201, 88, 18, 10, 130, 152, 42, 108, 246, 185, 5, 63, 236, 9, 212, 189, 182, 87, 188, 230, 187, 234, 87, 215, 237, 165, 253, 85, 105, 248, 208, 248, 190, 51, 12, 181, 243, 227, 231, 76, 180, 184, 130, 18, 160, 67, 17, 12, 102, 87, 196, 127, 61, 86, 90, 198, 240, 120, 207, 171, 37, 202, 32, 255, 14, 224, 87, 216, 189, 109, 218, 157, 115, 56, 217, 216, 228, 188, 54, 120, 89, 224, 125, 215, 215, 227, 224, 47, 134, 65, 162, 152, 47, 18, 153, 208, 187, 22, 46, 108, 229, 229, 148, 86, 218, 209, 195, 157, 194, 134, 69, 89, 126, 33, 203, 183, 104, 82, 77 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 168, 5, 32, 226, 207, 187, 15, 58, 169, 123, 7, 178, 79, 68, 127, 4, 32, 243, 74, 94, 68, 139, 97, 46, 137, 154, 74, 50, 7, 70, 87, 181, 137, 127, 146, 56, 36, 71, 87, 242, 42, 106, 148, 138, 18, 36, 178, 66, 123, 55, 150, 216, 20, 96, 122, 0, 40, 4, 229, 38, 32, 112, 59, 26 }, new byte[] { 67, 255, 4, 127, 52, 44, 138, 34, 105, 201, 88, 18, 10, 130, 152, 42, 108, 246, 185, 5, 63, 236, 9, 212, 189, 182, 87, 188, 230, 187, 234, 87, 215, 237, 165, 253, 85, 105, 248, 208, 248, 190, 51, 12, 181, 243, 227, 231, 76, 180, 184, 130, 18, 160, 67, 17, 12, 102, 87, 196, 127, 61, 86, 90, 198, 240, 120, 207, 171, 37, 202, 32, 255, 14, 224, 87, 216, 189, 109, 218, 157, 115, 56, 217, 216, 228, 188, 54, 120, 89, 224, 125, 215, 215, 227, 224, 47, 134, 65, 162, 152, 47, 18, 153, 208, 187, 22, 46, 108, 229, 229, 148, 86, 218, 209, 195, 157, 194, 134, 69, 89, 126, 33, 203, 183, 104, 82, 77 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 9, 14, 159, 98, 199, 55, 124, 134, 224, 191, 34, 44, 190, 216, 239, 185, 14, 63, 90, 16, 61, 247, 164, 240, 77, 78, 29, 250, 209, 242, 178, 85, 236, 210, 231, 92, 1, 58, 163, 72, 195, 63, 85, 251, 52, 220, 62, 198, 65, 37, 166, 177, 143, 201, 241, 158, 93, 198, 164, 82, 155, 194, 53, 169 }, new byte[] { 67, 255, 4, 127, 52, 44, 138, 34, 105, 201, 88, 18, 10, 130, 152, 42, 108, 246, 185, 5, 63, 236, 9, 212, 189, 182, 87, 188, 230, 187, 234, 87, 215, 237, 165, 253, 85, 105, 248, 208, 248, 190, 51, 12, 181, 243, 227, 231, 76, 180, 184, 130, 18, 160, 67, 17, 12, 102, 87, 196, 127, 61, 86, 90, 198, 240, 120, 207, 171, 37, 202, 32, 255, 14, 224, 87, 216, 189, 109, 218, 157, 115, 56, 217, 216, 228, 188, 54, 120, 89, 224, 125, 215, 215, 227, 224, 47, 134, 65, 162, 152, 47, 18, 153, 208, 187, 22, 46, 108, 229, 229, 148, 86, 218, 209, 195, 157, 194, 134, 69, 89, 126, 33, 203, 183, 104, 82, 77 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 219, 198, 134, 94, 194, 141, 163, 57, 109, 108, 76, 223, 12, 225, 125, 23, 55, 160, 193, 196, 154, 213, 55, 210, 18, 184, 68, 131, 41, 246, 66, 5, 185, 98, 97, 112, 251, 211, 8, 26, 114, 234, 93, 129, 255, 246, 113, 0, 231, 248, 48, 239, 5, 75, 5, 80, 74, 103, 26, 223, 222, 58, 15, 50 }, new byte[] { 67, 255, 4, 127, 52, 44, 138, 34, 105, 201, 88, 18, 10, 130, 152, 42, 108, 246, 185, 5, 63, 236, 9, 212, 189, 182, 87, 188, 230, 187, 234, 87, 215, 237, 165, 253, 85, 105, 248, 208, 248, 190, 51, 12, 181, 243, 227, 231, 76, 180, 184, 130, 18, 160, 67, 17, 12, 102, 87, 196, 127, 61, 86, 90, 198, 240, 120, 207, 171, 37, 202, 32, 255, 14, 224, 87, 216, 189, 109, 218, 157, 115, 56, 217, 216, 228, 188, 54, 120, 89, 224, 125, 215, 215, 227, 224, 47, 134, 65, 162, 152, 47, 18, 153, 208, 187, 22, 46, 108, 229, 229, 148, 86, 218, 209, 195, 157, 194, 134, 69, 89, 126, 33, 203, 183, 104, 82, 77 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 211, 1, 83, 179, 210, 214, 153, 93, 49, 41, 131, 168, 68, 29, 113, 62, 109, 171, 145, 16, 14, 58, 48, 38, 129, 51, 187, 54, 88, 155, 147, 166, 85, 175, 234, 249, 91, 40, 159, 24, 188, 120, 252, 107, 157, 88, 221, 42, 113, 174, 164, 24, 209, 10, 185, 51, 7, 239, 126, 138, 253, 204, 139, 121 }, new byte[] { 67, 255, 4, 127, 52, 44, 138, 34, 105, 201, 88, 18, 10, 130, 152, 42, 108, 246, 185, 5, 63, 236, 9, 212, 189, 182, 87, 188, 230, 187, 234, 87, 215, 237, 165, 253, 85, 105, 248, 208, 248, 190, 51, 12, 181, 243, 227, 231, 76, 180, 184, 130, 18, 160, 67, 17, 12, 102, 87, 196, 127, 61, 86, 90, 198, 240, 120, 207, 171, 37, 202, 32, 255, 14, 224, 87, 216, 189, 109, 218, 157, 115, 56, 217, 216, 228, 188, 54, 120, 89, 224, 125, 215, 215, 227, 224, 47, 134, 65, 162, 152, 47, 18, 153, 208, 187, 22, 46, 108, 229, 229, 148, 86, 218, 209, 195, 157, 194, 134, 69, 89, 126, 33, 203, 183, 104, 82, 77 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 217, 209, 193, 244, 28, 82, 242, 66, 230, 223, 174, 233, 215, 76, 48, 190, 82, 223, 105, 163, 134, 152, 246, 241, 141, 10, 55, 72, 14, 36, 216, 72, 86, 135, 185, 87, 196, 184, 158, 245, 233, 131, 106, 117, 209, 121, 36, 69, 245, 11, 41, 142, 40, 28, 162, 46, 190, 108, 53, 201, 89, 6, 207, 41 }, new byte[] { 67, 255, 4, 127, 52, 44, 138, 34, 105, 201, 88, 18, 10, 130, 152, 42, 108, 246, 185, 5, 63, 236, 9, 212, 189, 182, 87, 188, 230, 187, 234, 87, 215, 237, 165, 253, 85, 105, 248, 208, 248, 190, 51, 12, 181, 243, 227, 231, 76, 180, 184, 130, 18, 160, 67, 17, 12, 102, 87, 196, 127, 61, 86, 90, 198, 240, 120, 207, 171, 37, 202, 32, 255, 14, 224, 87, 216, 189, 109, 218, 157, 115, 56, 217, 216, 228, 188, 54, 120, 89, 224, 125, 215, 215, 227, 224, 47, 134, 65, 162, 152, 47, 18, 153, 208, 187, 22, 46, 108, 229, 229, 148, 86, 218, 209, 195, 157, 194, 134, 69, 89, 126, 33, 203, 183, 104, 82, 77 } });

            migrationBuilder.CreateIndex(
                name: "IX_TravelTips_PlaceId",
                table: "TravelTips",
                column: "PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelTips");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 170, 46, 183, 150, 212, 160, 205, 116, 54, 205, 140, 192, 190, 253, 17, 66, 150, 127, 49, 63, 222, 102, 233, 191, 154, 191, 112, 101, 70, 101, 72, 230, 215, 3, 188, 232, 154, 204, 157, 44, 173, 122, 212, 224, 186, 253, 5, 121, 182, 137, 14, 160, 78, 76, 127, 140, 184, 124, 169, 47, 129, 123, 78, 100 }, new byte[] { 140, 138, 36, 250, 243, 5, 237, 81, 232, 174, 16, 94, 251, 74, 7, 1, 31, 131, 227, 168, 74, 65, 22, 121, 134, 175, 12, 201, 200, 104, 235, 165, 232, 180, 174, 86, 48, 209, 88, 184, 48, 62, 202, 133, 10, 21, 24, 233, 136, 33, 16, 16, 12, 55, 58, 150, 24, 30, 234, 112, 163, 139, 146, 87, 246, 105, 61, 167, 8, 244, 80, 35, 16, 53, 156, 84, 199, 109, 174, 114, 238, 250, 222, 98, 45, 48, 54, 111, 220, 34, 228, 36, 236, 204, 80, 24, 76, 131, 101, 116, 20, 254, 41, 84, 57, 149, 133, 233, 234, 57, 95, 185, 4, 179, 86, 114, 160, 104, 153, 25, 131, 88, 210, 42, 131, 136, 97, 200 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 79, 242, 108, 121, 197, 33, 73, 107, 242, 47, 8, 28, 32, 14, 225, 171, 223, 204, 28, 96, 163, 230, 133, 195, 134, 64, 196, 44, 97, 135, 234, 139, 146, 43, 207, 91, 155, 177, 89, 230, 104, 1, 86, 105, 145, 143, 179, 254, 217, 52, 70, 133, 101, 153, 144, 227, 253, 184, 181, 154, 201, 145, 238, 96 }, new byte[] { 140, 138, 36, 250, 243, 5, 237, 81, 232, 174, 16, 94, 251, 74, 7, 1, 31, 131, 227, 168, 74, 65, 22, 121, 134, 175, 12, 201, 200, 104, 235, 165, 232, 180, 174, 86, 48, 209, 88, 184, 48, 62, 202, 133, 10, 21, 24, 233, 136, 33, 16, 16, 12, 55, 58, 150, 24, 30, 234, 112, 163, 139, 146, 87, 246, 105, 61, 167, 8, 244, 80, 35, 16, 53, 156, 84, 199, 109, 174, 114, 238, 250, 222, 98, 45, 48, 54, 111, 220, 34, 228, 36, 236, 204, 80, 24, 76, 131, 101, 116, 20, 254, 41, 84, 57, 149, 133, 233, 234, 57, 95, 185, 4, 179, 86, 114, 160, 104, 153, 25, 131, 88, 210, 42, 131, 136, 97, 200 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 218, 111, 73, 85, 212, 162, 46, 38, 114, 251, 97, 119, 178, 179, 50, 88, 47, 180, 2, 144, 152, 156, 103, 8, 202, 146, 110, 229, 15, 54, 158, 255, 104, 26, 234, 93, 37, 48, 49, 90, 221, 171, 233, 70, 29, 41, 222, 70, 92, 153, 6, 106, 37, 76, 113, 184, 39, 8, 101, 114, 186, 89, 146, 55 }, new byte[] { 140, 138, 36, 250, 243, 5, 237, 81, 232, 174, 16, 94, 251, 74, 7, 1, 31, 131, 227, 168, 74, 65, 22, 121, 134, 175, 12, 201, 200, 104, 235, 165, 232, 180, 174, 86, 48, 209, 88, 184, 48, 62, 202, 133, 10, 21, 24, 233, 136, 33, 16, 16, 12, 55, 58, 150, 24, 30, 234, 112, 163, 139, 146, 87, 246, 105, 61, 167, 8, 244, 80, 35, 16, 53, 156, 84, 199, 109, 174, 114, 238, 250, 222, 98, 45, 48, 54, 111, 220, 34, 228, 36, 236, 204, 80, 24, 76, 131, 101, 116, 20, 254, 41, 84, 57, 149, 133, 233, 234, 57, 95, 185, 4, 179, 86, 114, 160, 104, 153, 25, 131, 88, 210, 42, 131, 136, 97, 200 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 34, 203, 62, 187, 25, 87, 116, 215, 181, 149, 254, 236, 72, 213, 136, 3, 226, 68, 188, 129, 60, 243, 229, 43, 147, 73, 242, 193, 104, 23, 147, 61, 240, 242, 147, 184, 84, 255, 198, 72, 55, 113, 231, 137, 64, 85, 145, 121, 115, 241, 93, 43, 85, 28, 245, 166, 202, 14, 229, 125, 228, 166, 30, 51 }, new byte[] { 140, 138, 36, 250, 243, 5, 237, 81, 232, 174, 16, 94, 251, 74, 7, 1, 31, 131, 227, 168, 74, 65, 22, 121, 134, 175, 12, 201, 200, 104, 235, 165, 232, 180, 174, 86, 48, 209, 88, 184, 48, 62, 202, 133, 10, 21, 24, 233, 136, 33, 16, 16, 12, 55, 58, 150, 24, 30, 234, 112, 163, 139, 146, 87, 246, 105, 61, 167, 8, 244, 80, 35, 16, 53, 156, 84, 199, 109, 174, 114, 238, 250, 222, 98, 45, 48, 54, 111, 220, 34, 228, 36, 236, 204, 80, 24, 76, 131, 101, 116, 20, 254, 41, 84, 57, 149, 133, 233, 234, 57, 95, 185, 4, 179, 86, 114, 160, 104, 153, 25, 131, 88, 210, 42, 131, 136, 97, 200 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 219, 97, 58, 151, 250, 240, 36, 191, 132, 170, 99, 249, 92, 158, 233, 2, 101, 125, 58, 29, 254, 74, 28, 37, 163, 229, 211, 200, 101, 36, 72, 199, 117, 90, 57, 65, 81, 106, 232, 80, 164, 179, 180, 177, 67, 176, 88, 44, 119, 44, 45, 65, 96, 80, 224, 198, 111, 168, 67, 221, 95, 138, 228, 60 }, new byte[] { 140, 138, 36, 250, 243, 5, 237, 81, 232, 174, 16, 94, 251, 74, 7, 1, 31, 131, 227, 168, 74, 65, 22, 121, 134, 175, 12, 201, 200, 104, 235, 165, 232, 180, 174, 86, 48, 209, 88, 184, 48, 62, 202, 133, 10, 21, 24, 233, 136, 33, 16, 16, 12, 55, 58, 150, 24, 30, 234, 112, 163, 139, 146, 87, 246, 105, 61, 167, 8, 244, 80, 35, 16, 53, 156, 84, 199, 109, 174, 114, 238, 250, 222, 98, 45, 48, 54, 111, 220, 34, 228, 36, 236, 204, 80, 24, 76, 131, 101, 116, 20, 254, 41, 84, 57, 149, 133, 233, 234, 57, 95, 185, 4, 179, 86, 114, 160, 104, 153, 25, 131, 88, 210, 42, 131, 136, 97, 200 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 210, 57, 75, 70, 120, 64, 111, 154, 7, 222, 239, 12, 242, 170, 207, 178, 32, 58, 246, 46, 0, 245, 59, 233, 10, 208, 74, 41, 56, 190, 145, 63, 227, 48, 171, 252, 150, 51, 244, 46, 230, 203, 116, 133, 145, 77, 156, 8, 192, 48, 131, 100, 124, 241, 218, 114, 252, 226, 190, 222, 166, 105, 114, 124 }, new byte[] { 140, 138, 36, 250, 243, 5, 237, 81, 232, 174, 16, 94, 251, 74, 7, 1, 31, 131, 227, 168, 74, 65, 22, 121, 134, 175, 12, 201, 200, 104, 235, 165, 232, 180, 174, 86, 48, 209, 88, 184, 48, 62, 202, 133, 10, 21, 24, 233, 136, 33, 16, 16, 12, 55, 58, 150, 24, 30, 234, 112, 163, 139, 146, 87, 246, 105, 61, 167, 8, 244, 80, 35, 16, 53, 156, 84, 199, 109, 174, 114, 238, 250, 222, 98, 45, 48, 54, 111, 220, 34, 228, 36, 236, 204, 80, 24, 76, 131, 101, 116, 20, 254, 41, 84, 57, 149, 133, 233, 234, 57, 95, 185, 4, 179, 86, 114, 160, 104, 153, 25, 131, 88, 210, 42, 131, 136, 97, 200 } });
        }
    }
}
