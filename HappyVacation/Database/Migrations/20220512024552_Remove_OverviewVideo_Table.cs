﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class Remove_OverviewVideo_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceOverviewVideos");

            migrationBuilder.AddColumn<string>(
                name: "OverviewVideoUrl",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                column: "OverviewVideoUrl",
                value: "/storage/DaNang360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 4,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 5,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 6,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 7,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 8,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 9,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 10,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 11,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 12,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 13,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 14,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 15,
                column: "OverviewVideoUrl",
                value: "/storage/HoiAn360.mp4");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverviewVideoUrl",
                table: "Places");

            migrationBuilder.CreateTable(
                name: "PlaceOverviewVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 157, 89, 195, 169, 40, 146, 206, 77, 180, 104, 144, 190, 64, 201, 6, 150, 141, 173, 55, 42, 161, 200, 169, 143, 202, 207, 215, 22, 96, 117, 51, 247, 75, 93, 185, 111, 2, 106, 182, 138, 140, 255, 63, 136, 63, 99, 93, 97, 94, 23, 130, 132, 41, 245, 62, 58, 64, 114, 104, 101, 97, 56, 71, 143 }, new byte[] { 22, 163, 2, 218, 137, 239, 156, 128, 68, 184, 123, 201, 153, 48, 23, 38, 250, 163, 43, 96, 116, 254, 72, 176, 153, 44, 228, 194, 109, 134, 220, 249, 88, 71, 129, 12, 221, 191, 184, 215, 148, 39, 208, 12, 242, 165, 1, 248, 72, 10, 170, 100, 167, 213, 136, 233, 148, 251, 82, 136, 64, 157, 135, 229, 232, 55, 250, 39, 232, 156, 24, 119, 241, 185, 142, 44, 158, 153, 204, 61, 210, 77, 74, 175, 181, 132, 76, 229, 12, 0, 127, 221, 169, 85, 12, 139, 92, 211, 192, 197, 96, 233, 164, 221, 167, 155, 64, 165, 159, 195, 120, 75, 69, 194, 28, 40, 52, 200, 159, 173, 119, 252, 39, 69, 163, 24, 248, 82 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 49, 149, 144, 23, 192, 35, 56, 73, 152, 218, 196, 221, 190, 46, 152, 124, 141, 243, 1, 86, 182, 224, 173, 89, 78, 131, 76, 125, 204, 185, 74, 223, 139, 41, 26, 234, 72, 168, 215, 142, 58, 111, 150, 142, 151, 57, 157, 56, 218, 49, 54, 45, 48, 133, 63, 62, 103, 8, 145, 148, 68, 113, 121, 47 }, new byte[] { 22, 163, 2, 218, 137, 239, 156, 128, 68, 184, 123, 201, 153, 48, 23, 38, 250, 163, 43, 96, 116, 254, 72, 176, 153, 44, 228, 194, 109, 134, 220, 249, 88, 71, 129, 12, 221, 191, 184, 215, 148, 39, 208, 12, 242, 165, 1, 248, 72, 10, 170, 100, 167, 213, 136, 233, 148, 251, 82, 136, 64, 157, 135, 229, 232, 55, 250, 39, 232, 156, 24, 119, 241, 185, 142, 44, 158, 153, 204, 61, 210, 77, 74, 175, 181, 132, 76, 229, 12, 0, 127, 221, 169, 85, 12, 139, 92, 211, 192, 197, 96, 233, 164, 221, 167, 155, 64, 165, 159, 195, 120, 75, 69, 194, 28, 40, 52, 200, 159, 173, 119, 252, 39, 69, 163, 24, 248, 82 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 27, 56, 122, 26, 52, 244, 208, 151, 245, 75, 103, 104, 49, 162, 49, 51, 231, 134, 70, 11, 19, 211, 242, 200, 40, 46, 86, 35, 71, 56, 124, 95, 96, 138, 156, 213, 251, 186, 110, 141, 81, 67, 14, 219, 223, 70, 103, 209, 181, 243, 62, 172, 123, 16, 80, 46, 80, 184, 31, 217, 136, 117, 86, 209 }, new byte[] { 22, 163, 2, 218, 137, 239, 156, 128, 68, 184, 123, 201, 153, 48, 23, 38, 250, 163, 43, 96, 116, 254, 72, 176, 153, 44, 228, 194, 109, 134, 220, 249, 88, 71, 129, 12, 221, 191, 184, 215, 148, 39, 208, 12, 242, 165, 1, 248, 72, 10, 170, 100, 167, 213, 136, 233, 148, 251, 82, 136, 64, 157, 135, 229, 232, 55, 250, 39, 232, 156, 24, 119, 241, 185, 142, 44, 158, 153, 204, 61, 210, 77, 74, 175, 181, 132, 76, 229, 12, 0, 127, 221, 169, 85, 12, 139, 92, 211, 192, 197, 96, 233, 164, 221, 167, 155, 64, 165, 159, 195, 120, 75, 69, 194, 28, 40, 52, 200, 159, 173, 119, 252, 39, 69, 163, 24, 248, 82 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 236, 68, 174, 185, 135, 137, 20, 32, 3, 123, 41, 196, 25, 70, 104, 117, 85, 60, 157, 207, 166, 250, 245, 139, 239, 84, 221, 175, 248, 158, 29, 239, 55, 30, 210, 42, 82, 5, 152, 119, 152, 50, 1, 8, 120, 78, 57, 223, 133, 148, 121, 1, 174, 121, 20, 11, 225, 182, 147, 24, 203, 3, 181 }, new byte[] { 22, 163, 2, 218, 137, 239, 156, 128, 68, 184, 123, 201, 153, 48, 23, 38, 250, 163, 43, 96, 116, 254, 72, 176, 153, 44, 228, 194, 109, 134, 220, 249, 88, 71, 129, 12, 221, 191, 184, 215, 148, 39, 208, 12, 242, 165, 1, 248, 72, 10, 170, 100, 167, 213, 136, 233, 148, 251, 82, 136, 64, 157, 135, 229, 232, 55, 250, 39, 232, 156, 24, 119, 241, 185, 142, 44, 158, 153, 204, 61, 210, 77, 74, 175, 181, 132, 76, 229, 12, 0, 127, 221, 169, 85, 12, 139, 92, 211, 192, 197, 96, 233, 164, 221, 167, 155, 64, 165, 159, 195, 120, 75, 69, 194, 28, 40, 52, 200, 159, 173, 119, 252, 39, 69, 163, 24, 248, 82 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 1, 13, 81, 55, 0, 151, 246, 232, 34, 158, 211, 164, 52, 77, 237, 126, 2, 232, 25, 51, 247, 87, 173, 163, 67, 52, 162, 151, 70, 106, 179, 71, 31, 253, 135, 162, 52, 199, 129, 208, 83, 178, 0, 123, 218, 104, 137, 81, 79, 33, 74, 200, 232, 210, 107, 61, 118, 137, 207, 240, 170, 152, 247, 35 }, new byte[] { 22, 163, 2, 218, 137, 239, 156, 128, 68, 184, 123, 201, 153, 48, 23, 38, 250, 163, 43, 96, 116, 254, 72, 176, 153, 44, 228, 194, 109, 134, 220, 249, 88, 71, 129, 12, 221, 191, 184, 215, 148, 39, 208, 12, 242, 165, 1, 248, 72, 10, 170, 100, 167, 213, 136, 233, 148, 251, 82, 136, 64, 157, 135, 229, 232, 55, 250, 39, 232, 156, 24, 119, 241, 185, 142, 44, 158, 153, 204, 61, 210, 77, 74, 175, 181, 132, 76, 229, 12, 0, 127, 221, 169, 85, 12, 139, 92, 211, 192, 197, 96, 233, 164, 221, 167, 155, 64, 165, 159, 195, 120, 75, 69, 194, 28, 40, 52, 200, 159, 173, 119, 252, 39, 69, 163, 24, 248, 82 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 28, 166, 157, 236, 15, 1, 60, 248, 37, 96, 164, 198, 122, 59, 106, 56, 233, 137, 61, 64, 96, 124, 150, 149, 189, 170, 113, 146, 143, 64, 227, 43, 76, 182, 134, 15, 23, 86, 249, 136, 90, 81, 135, 176, 172, 62, 234, 140, 142, 217, 229, 140, 58, 74, 204, 190, 159, 250, 223, 135, 147, 126, 60, 233 }, new byte[] { 22, 163, 2, 218, 137, 239, 156, 128, 68, 184, 123, 201, 153, 48, 23, 38, 250, 163, 43, 96, 116, 254, 72, 176, 153, 44, 228, 194, 109, 134, 220, 249, 88, 71, 129, 12, 221, 191, 184, 215, 148, 39, 208, 12, 242, 165, 1, 248, 72, 10, 170, 100, 167, 213, 136, 233, 148, 251, 82, 136, 64, 157, 135, 229, 232, 55, 250, 39, 232, 156, 24, 119, 241, 185, 142, 44, 158, 153, 204, 61, 210, 77, 74, 175, 181, 132, 76, 229, 12, 0, 127, 221, 169, 85, 12, 139, 92, 211, 192, 197, 96, 233, 164, 221, 167, 155, 64, 165, 159, 195, 120, 75, 69, 194, 28, 40, 52, 200, 159, 173, 119, 252, 39, 69, 163, 24, 248, 82 } });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOverviewVideos_PlaceId",
                table: "PlaceOverviewVideos",
                column: "PlaceId");
        }
    }
}
