﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class StartTime_StartPoint_EndPoint_TourTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Tours",
                newName: "StartPoint");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Tours",
                newName: "EndPoint");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndPoint", "StartPoint", "StartTime" },
                values: new object[] { "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province", "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province", "8:00 AM" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndPoint", "StartPoint", "StartTime" },
                values: new object[] { "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province", "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province", "5:00 PM" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 149, 75, 5, 218, 102, 157, 101, 247, 181, 64, 126, 49, 230, 38, 234, 148, 229, 122, 225, 163, 224, 236, 144, 148, 206, 96, 195, 45, 192, 168, 67, 170, 185, 50, 130, 157, 91, 147, 167, 24, 250, 220, 89, 231, 240, 5, 141, 76, 70, 1, 49, 228, 161, 0, 102, 11, 115, 216, 255, 227, 200, 107, 214, 251 }, new byte[] { 44, 217, 68, 201, 178, 178, 253, 94, 159, 138, 43, 12, 223, 177, 226, 103, 52, 50, 32, 87, 174, 214, 210, 77, 203, 211, 53, 201, 75, 249, 74, 226, 82, 154, 147, 58, 47, 228, 52, 56, 2, 153, 57, 27, 212, 222, 127, 100, 3, 31, 14, 52, 91, 134, 120, 18, 69, 203, 162, 141, 190, 55, 191, 217, 78, 31, 29, 168, 103, 88, 79, 13, 252, 87, 159, 130, 242, 180, 134, 14, 43, 110, 163, 222, 252, 112, 14, 116, 17, 208, 64, 9, 218, 51, 102, 158, 221, 231, 142, 117, 23, 227, 231, 124, 126, 38, 119, 39, 66, 2, 59, 248, 118, 61, 212, 15, 237, 235, 123, 164, 67, 240, 84, 70, 87, 162, 226, 96 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 74, 227, 196, 125, 180, 178, 71, 91, 186, 2, 3, 224, 151, 59, 248, 176, 121, 246, 40, 106, 244, 151, 119, 126, 39, 192, 165, 158, 43, 17, 100, 166, 84, 66, 239, 20, 68, 85, 80, 68, 12, 123, 238, 71, 189, 238, 183, 234, 32, 97, 58, 204, 162, 110, 130, 121, 213, 4, 84, 178, 59, 55, 198, 92 }, new byte[] { 44, 217, 68, 201, 178, 178, 253, 94, 159, 138, 43, 12, 223, 177, 226, 103, 52, 50, 32, 87, 174, 214, 210, 77, 203, 211, 53, 201, 75, 249, 74, 226, 82, 154, 147, 58, 47, 228, 52, 56, 2, 153, 57, 27, 212, 222, 127, 100, 3, 31, 14, 52, 91, 134, 120, 18, 69, 203, 162, 141, 190, 55, 191, 217, 78, 31, 29, 168, 103, 88, 79, 13, 252, 87, 159, 130, 242, 180, 134, 14, 43, 110, 163, 222, 252, 112, 14, 116, 17, 208, 64, 9, 218, 51, 102, 158, 221, 231, 142, 117, 23, 227, 231, 124, 126, 38, 119, 39, 66, 2, 59, 248, 118, 61, 212, 15, 237, 235, 123, 164, 67, 240, 84, 70, 87, 162, 226, 96 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 77, 3, 36, 199, 131, 24, 207, 10, 22, 207, 208, 30, 29, 208, 179, 181, 173, 231, 250, 51, 193, 65, 70, 68, 213, 215, 115, 66, 0, 232, 111, 20, 240, 227, 166, 5, 250, 48, 203, 246, 171, 23, 31, 245, 233, 119, 86, 45, 87, 149, 237, 89, 241, 177, 10, 35, 253, 23, 91, 132, 104, 75, 64, 9 }, new byte[] { 44, 217, 68, 201, 178, 178, 253, 94, 159, 138, 43, 12, 223, 177, 226, 103, 52, 50, 32, 87, 174, 214, 210, 77, 203, 211, 53, 201, 75, 249, 74, 226, 82, 154, 147, 58, 47, 228, 52, 56, 2, 153, 57, 27, 212, 222, 127, 100, 3, 31, 14, 52, 91, 134, 120, 18, 69, 203, 162, 141, 190, 55, 191, 217, 78, 31, 29, 168, 103, 88, 79, 13, 252, 87, 159, 130, 242, 180, 134, 14, 43, 110, 163, 222, 252, 112, 14, 116, 17, 208, 64, 9, 218, 51, 102, 158, 221, 231, 142, 117, 23, 227, 231, 124, 126, 38, 119, 39, 66, 2, 59, 248, 118, 61, 212, 15, 237, 235, 123, 164, 67, 240, 84, 70, 87, 162, 226, 96 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 132, 144, 142, 120, 89, 183, 28, 146, 211, 231, 175, 88, 81, 30, 161, 185, 250, 85, 68, 224, 131, 162, 143, 66, 0, 249, 187, 234, 180, 91, 235, 155, 157, 140, 221, 202, 205, 129, 55, 157, 97, 12, 172, 40, 112, 49, 234, 75, 173, 61, 229, 163, 73, 150, 118, 20, 166, 202, 18, 5, 165, 101, 189 }, new byte[] { 44, 217, 68, 201, 178, 178, 253, 94, 159, 138, 43, 12, 223, 177, 226, 103, 52, 50, 32, 87, 174, 214, 210, 77, 203, 211, 53, 201, 75, 249, 74, 226, 82, 154, 147, 58, 47, 228, 52, 56, 2, 153, 57, 27, 212, 222, 127, 100, 3, 31, 14, 52, 91, 134, 120, 18, 69, 203, 162, 141, 190, 55, 191, 217, 78, 31, 29, 168, 103, 88, 79, 13, 252, 87, 159, 130, 242, 180, 134, 14, 43, 110, 163, 222, 252, 112, 14, 116, 17, 208, 64, 9, 218, 51, 102, 158, 221, 231, 142, 117, 23, 227, 231, 124, 126, 38, 119, 39, 66, 2, 59, 248, 118, 61, 212, 15, 237, 235, 123, 164, 67, 240, 84, 70, 87, 162, 226, 96 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 114, 163, 146, 219, 31, 200, 227, 219, 31, 101, 33, 48, 101, 226, 92, 37, 41, 186, 15, 209, 228, 57, 105, 19, 18, 142, 126, 210, 155, 94, 135, 70, 81, 155, 88, 84, 58, 228, 162, 98, 32, 1, 114, 241, 187, 23, 245, 127, 79, 237, 231, 120, 182, 98, 149, 152, 188, 36, 103, 201, 66, 246, 248, 5 }, new byte[] { 44, 217, 68, 201, 178, 178, 253, 94, 159, 138, 43, 12, 223, 177, 226, 103, 52, 50, 32, 87, 174, 214, 210, 77, 203, 211, 53, 201, 75, 249, 74, 226, 82, 154, 147, 58, 47, 228, 52, 56, 2, 153, 57, 27, 212, 222, 127, 100, 3, 31, 14, 52, 91, 134, 120, 18, 69, 203, 162, 141, 190, 55, 191, 217, 78, 31, 29, 168, 103, 88, 79, 13, 252, 87, 159, 130, 242, 180, 134, 14, 43, 110, 163, 222, 252, 112, 14, 116, 17, 208, 64, 9, 218, 51, 102, 158, 221, 231, 142, 117, 23, 227, 231, 124, 126, 38, 119, 39, 66, 2, 59, 248, 118, 61, 212, 15, 237, 235, 123, 164, 67, 240, 84, 70, 87, 162, 226, 96 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 225, 1, 76, 115, 99, 12, 86, 210, 160, 14, 168, 32, 125, 85, 85, 251, 220, 30, 217, 83, 244, 137, 104, 97, 195, 120, 27, 43, 195, 188, 116, 87, 16, 156, 248, 146, 221, 245, 237, 228, 183, 29, 30, 226, 128, 87, 95, 187, 146, 14, 113, 255, 229, 224, 141, 247, 122, 67, 39, 149, 226, 146, 34 }, new byte[] { 44, 217, 68, 201, 178, 178, 253, 94, 159, 138, 43, 12, 223, 177, 226, 103, 52, 50, 32, 87, 174, 214, 210, 77, 203, 211, 53, 201, 75, 249, 74, 226, 82, 154, 147, 58, 47, 228, 52, 56, 2, 153, 57, 27, 212, 222, 127, 100, 3, 31, 14, 52, 91, 134, 120, 18, 69, 203, 162, 141, 190, 55, 191, 217, 78, 31, 29, 168, 103, 88, 79, 13, 252, 87, 159, 130, 242, 180, 134, 14, 43, 110, 163, 222, 252, 112, 14, 116, 17, 208, 64, 9, 218, 51, 102, 158, 221, 231, 142, 117, 23, 227, 231, 124, 126, 38, 119, 39, 66, 2, 59, 248, 118, 61, 212, 15, 237, 235, 123, 164, 67, 240, 84, 70, 87, 162, 226, 96 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "StartPoint",
                table: "Tours",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "EndPoint",
                table: "Tours",
                newName: "Destination");

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Destination", "Location" },
                values: new object[] { "Cam Chau Ward, Hoi An City, Quang Nam Province", "Minh An Ward, Hoi An City, Quang Nam Province" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Destination", "Location" },
                values: new object[] { "Minh An Ward, Hoi An City, Quang Nam Province", "Minh An Ward, Hoi An City, Quang Nam Province" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 188, 113, 182, 69, 220, 103, 230, 66, 110, 151, 140, 159, 223, 105, 193, 207, 161, 241, 161, 16, 239, 242, 174, 72, 116, 148, 74, 66, 211, 205, 97, 95, 177, 33, 183, 108, 96, 227, 22, 213, 13, 73, 35, 16, 208, 210, 69, 42, 218, 116, 244, 161, 181, 145, 4, 182, 177, 194, 23, 99, 48, 231, 4, 141 }, new byte[] { 16, 1, 80, 89, 75, 174, 85, 243, 21, 169, 230, 192, 75, 193, 63, 36, 5, 104, 120, 122, 81, 201, 246, 195, 118, 212, 227, 128, 32, 116, 147, 31, 202, 129, 155, 10, 86, 204, 48, 44, 57, 46, 14, 240, 206, 71, 236, 70, 12, 21, 53, 126, 188, 209, 215, 236, 233, 65, 137, 144, 185, 165, 223, 42, 116, 244, 170, 127, 126, 203, 178, 92, 229, 165, 110, 200, 93, 57, 254, 62, 23, 207, 156, 143, 3, 179, 13, 9, 250, 67, 234, 68, 169, 153, 34, 236, 218, 50, 72, 12, 161, 81, 215, 41, 193, 195, 175, 207, 220, 80, 10, 136, 239, 22, 218, 76, 147, 173, 28, 251, 21, 46, 215, 57, 69, 173, 161, 124 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 74, 3, 216, 249, 188, 52, 29, 37, 67, 95, 110, 19, 134, 154, 218, 141, 37, 70, 107, 117, 69, 213, 138, 229, 50, 162, 127, 50, 127, 242, 7, 187, 231, 135, 21, 9, 149, 47, 220, 92, 154, 158, 194, 138, 89, 204, 136, 62, 228, 153, 187, 77, 219, 54, 195, 148, 103, 150, 141, 166, 45, 132, 163, 108 }, new byte[] { 16, 1, 80, 89, 75, 174, 85, 243, 21, 169, 230, 192, 75, 193, 63, 36, 5, 104, 120, 122, 81, 201, 246, 195, 118, 212, 227, 128, 32, 116, 147, 31, 202, 129, 155, 10, 86, 204, 48, 44, 57, 46, 14, 240, 206, 71, 236, 70, 12, 21, 53, 126, 188, 209, 215, 236, 233, 65, 137, 144, 185, 165, 223, 42, 116, 244, 170, 127, 126, 203, 178, 92, 229, 165, 110, 200, 93, 57, 254, 62, 23, 207, 156, 143, 3, 179, 13, 9, 250, 67, 234, 68, 169, 153, 34, 236, 218, 50, 72, 12, 161, 81, 215, 41, 193, 195, 175, 207, 220, 80, 10, 136, 239, 22, 218, 76, 147, 173, 28, 251, 21, 46, 215, 57, 69, 173, 161, 124 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 31, 46, 160, 27, 19, 56, 234, 149, 87, 43, 60, 236, 24, 103, 88, 36, 93, 68, 123, 174, 0, 245, 20, 80, 87, 34, 40, 28, 19, 64, 116, 100, 70, 65, 12, 42, 171, 217, 126, 165, 239, 19, 195, 143, 208, 242, 164, 5, 131, 245, 10, 126, 94, 73, 133, 6, 150, 5, 89, 70, 133, 54, 232, 114 }, new byte[] { 16, 1, 80, 89, 75, 174, 85, 243, 21, 169, 230, 192, 75, 193, 63, 36, 5, 104, 120, 122, 81, 201, 246, 195, 118, 212, 227, 128, 32, 116, 147, 31, 202, 129, 155, 10, 86, 204, 48, 44, 57, 46, 14, 240, 206, 71, 236, 70, 12, 21, 53, 126, 188, 209, 215, 236, 233, 65, 137, 144, 185, 165, 223, 42, 116, 244, 170, 127, 126, 203, 178, 92, 229, 165, 110, 200, 93, 57, 254, 62, 23, 207, 156, 143, 3, 179, 13, 9, 250, 67, 234, 68, 169, 153, 34, 236, 218, 50, 72, 12, 161, 81, 215, 41, 193, 195, 175, 207, 220, 80, 10, 136, 239, 22, 218, 76, 147, 173, 28, 251, 21, 46, 215, 57, 69, 173, 161, 124 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 171, 115, 19, 28, 56, 222, 23, 72, 56, 90, 198, 94, 74, 167, 211, 35, 204, 208, 55, 72, 86, 64, 197, 202, 97, 164, 172, 237, 94, 197, 169, 99, 10, 73, 151, 255, 139, 130, 232, 127, 51, 14, 120, 250, 127, 70, 244, 195, 239, 176, 232, 226, 24, 17, 196, 121, 147, 134, 129, 56, 15, 58, 145, 69 }, new byte[] { 16, 1, 80, 89, 75, 174, 85, 243, 21, 169, 230, 192, 75, 193, 63, 36, 5, 104, 120, 122, 81, 201, 246, 195, 118, 212, 227, 128, 32, 116, 147, 31, 202, 129, 155, 10, 86, 204, 48, 44, 57, 46, 14, 240, 206, 71, 236, 70, 12, 21, 53, 126, 188, 209, 215, 236, 233, 65, 137, 144, 185, 165, 223, 42, 116, 244, 170, 127, 126, 203, 178, 92, 229, 165, 110, 200, 93, 57, 254, 62, 23, 207, 156, 143, 3, 179, 13, 9, 250, 67, 234, 68, 169, 153, 34, 236, 218, 50, 72, 12, 161, 81, 215, 41, 193, 195, 175, 207, 220, 80, 10, 136, 239, 22, 218, 76, 147, 173, 28, 251, 21, 46, 215, 57, 69, 173, 161, 124 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 54, 66, 81, 228, 254, 4, 242, 80, 96, 171, 12, 135, 146, 50, 114, 26, 186, 153, 42, 247, 175, 128, 197, 28, 83, 18, 166, 175, 74, 250, 208, 177, 221, 170, 196, 167, 24, 136, 167, 202, 99, 77, 230, 253, 16, 13, 117, 225, 203, 43, 149, 49, 13, 23, 202, 248, 116, 114, 204, 59, 246, 40, 220, 243 }, new byte[] { 16, 1, 80, 89, 75, 174, 85, 243, 21, 169, 230, 192, 75, 193, 63, 36, 5, 104, 120, 122, 81, 201, 246, 195, 118, 212, 227, 128, 32, 116, 147, 31, 202, 129, 155, 10, 86, 204, 48, 44, 57, 46, 14, 240, 206, 71, 236, 70, 12, 21, 53, 126, 188, 209, 215, 236, 233, 65, 137, 144, 185, 165, 223, 42, 116, 244, 170, 127, 126, 203, 178, 92, 229, 165, 110, 200, 93, 57, 254, 62, 23, 207, 156, 143, 3, 179, 13, 9, 250, 67, 234, 68, 169, 153, 34, 236, 218, 50, 72, 12, 161, 81, 215, 41, 193, 195, 175, 207, 220, 80, 10, 136, 239, 22, 218, 76, 147, 173, 28, 251, 21, 46, 215, 57, 69, 173, 161, 124 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 224, 241, 21, 23, 159, 142, 122, 30, 43, 48, 20, 192, 181, 170, 249, 27, 116, 199, 213, 215, 208, 175, 244, 224, 235, 172, 41, 145, 47, 82, 79, 125, 21, 212, 196, 23, 17, 172, 171, 49, 146, 47, 19, 248, 35, 61, 81, 217, 196, 184, 211, 132, 218, 241, 104, 113, 199, 208, 44, 186, 237, 69, 145, 123 }, new byte[] { 16, 1, 80, 89, 75, 174, 85, 243, 21, 169, 230, 192, 75, 193, 63, 36, 5, 104, 120, 122, 81, 201, 246, 195, 118, 212, 227, 128, 32, 116, 147, 31, 202, 129, 155, 10, 86, 204, 48, 44, 57, 46, 14, 240, 206, 71, 236, 70, 12, 21, 53, 126, 188, 209, 215, 236, 233, 65, 137, 144, 185, 165, 223, 42, 116, 244, 170, 127, 126, 203, 178, 92, 229, 165, 110, 200, 93, 57, 254, 62, 23, 207, 156, 143, 3, 179, 13, 9, 250, 67, 234, 68, 169, 153, 34, 236, 218, 50, 72, 12, 161, 81, 215, 41, 193, 195, 175, 207, 220, 80, 10, 136, 239, 22, 218, 76, 147, 173, 28, 251, 21, 46, 215, 57, 69, 173, 161, 124 } });
        }
    }
}
