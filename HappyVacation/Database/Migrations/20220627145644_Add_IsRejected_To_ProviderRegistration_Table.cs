﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class Add_IsRejected_To_ProviderRegistration_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderRegistrations_Users_UserId",
                table: "ProviderRegistrations");

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "ProviderRegistrations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 192, 196, 10, 66, 68, 60, 152, 246, 12, 207, 194, 3, 35, 91, 96, 104, 5, 84, 59, 168, 16, 106, 167, 27, 1, 59, 27, 247, 151, 137, 249, 242, 136, 134, 147, 171, 206, 36, 91, 121, 156, 248, 1, 62, 63, 175, 157, 18, 211, 172, 71, 231, 89, 156, 22, 20, 17, 47, 24, 130, 31, 235, 197, 170 }, new byte[] { 12, 104, 71, 0, 205, 206, 96, 71, 240, 175, 183, 151, 131, 244, 206, 148, 78, 43, 181, 146, 248, 2, 216, 61, 16, 143, 204, 188, 174, 219, 111, 141, 136, 153, 168, 133, 150, 243, 163, 117, 168, 146, 184, 187, 184, 98, 162, 45, 145, 100, 212, 65, 9, 19, 61, 40, 58, 133, 195, 67, 99, 101, 95, 225, 65, 244, 129, 212, 206, 122, 116, 229, 208, 103, 234, 85, 221, 92, 208, 139, 178, 224, 3, 94, 53, 79, 222, 68, 10, 84, 111, 28, 220, 81, 80, 15, 46, 87, 192, 68, 162, 30, 248, 36, 170, 98, 128, 64, 244, 246, 119, 108, 94, 48, 101, 254, 149, 210, 16, 14, 23, 3, 76, 133, 76, 196, 125, 216 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 185, 111, 187, 16, 120, 205, 101, 27, 129, 52, 100, 98, 227, 40, 71, 17, 196, 247, 255, 137, 182, 1, 114, 127, 131, 233, 43, 8, 48, 204, 78, 173, 192, 12, 180, 99, 233, 75, 31, 213, 127, 191, 23, 158, 107, 168, 213, 48, 118, 255, 170, 212, 198, 214, 164, 53, 195, 58, 220, 36, 4, 131, 114, 169 }, new byte[] { 12, 104, 71, 0, 205, 206, 96, 71, 240, 175, 183, 151, 131, 244, 206, 148, 78, 43, 181, 146, 248, 2, 216, 61, 16, 143, 204, 188, 174, 219, 111, 141, 136, 153, 168, 133, 150, 243, 163, 117, 168, 146, 184, 187, 184, 98, 162, 45, 145, 100, 212, 65, 9, 19, 61, 40, 58, 133, 195, 67, 99, 101, 95, 225, 65, 244, 129, 212, 206, 122, 116, 229, 208, 103, 234, 85, 221, 92, 208, 139, 178, 224, 3, 94, 53, 79, 222, 68, 10, 84, 111, 28, 220, 81, 80, 15, 46, 87, 192, 68, 162, 30, 248, 36, 170, 98, 128, 64, 244, 246, 119, 108, 94, 48, 101, 254, 149, 210, 16, 14, 23, 3, 76, 133, 76, 196, 125, 216 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 35, 43, 36, 10, 155, 125, 167, 22, 142, 125, 44, 220, 75, 161, 93, 96, 39, 193, 162, 100, 155, 228, 11, 185, 1, 31, 36, 75, 99, 28, 19, 133, 148, 48, 212, 107, 83, 67, 235, 158, 220, 13, 108, 250, 75, 204, 62, 176, 49, 183, 226, 77, 172, 110, 140, 94, 69, 22, 217, 34, 104, 125, 253, 242 }, new byte[] { 12, 104, 71, 0, 205, 206, 96, 71, 240, 175, 183, 151, 131, 244, 206, 148, 78, 43, 181, 146, 248, 2, 216, 61, 16, 143, 204, 188, 174, 219, 111, 141, 136, 153, 168, 133, 150, 243, 163, 117, 168, 146, 184, 187, 184, 98, 162, 45, 145, 100, 212, 65, 9, 19, 61, 40, 58, 133, 195, 67, 99, 101, 95, 225, 65, 244, 129, 212, 206, 122, 116, 229, 208, 103, 234, 85, 221, 92, 208, 139, 178, 224, 3, 94, 53, 79, 222, 68, 10, 84, 111, 28, 220, 81, 80, 15, 46, 87, 192, 68, 162, 30, 248, 36, 170, 98, 128, 64, 244, 246, 119, 108, 94, 48, 101, 254, 149, 210, 16, 14, 23, 3, 76, 133, 76, 196, 125, 216 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 249, 136, 153, 213, 9, 129, 18, 11, 30, 230, 123, 126, 210, 54, 111, 227, 191, 97, 13, 74, 72, 213, 228, 118, 250, 47, 59, 115, 93, 202, 81, 247, 92, 225, 16, 52, 47, 32, 205, 48, 192, 222, 37, 63, 181, 161, 131, 140, 82, 241, 253, 19, 4, 245, 99, 85, 5, 224, 42, 32, 20, 93, 80, 200 }, new byte[] { 12, 104, 71, 0, 205, 206, 96, 71, 240, 175, 183, 151, 131, 244, 206, 148, 78, 43, 181, 146, 248, 2, 216, 61, 16, 143, 204, 188, 174, 219, 111, 141, 136, 153, 168, 133, 150, 243, 163, 117, 168, 146, 184, 187, 184, 98, 162, 45, 145, 100, 212, 65, 9, 19, 61, 40, 58, 133, 195, 67, 99, 101, 95, 225, 65, 244, 129, 212, 206, 122, 116, 229, 208, 103, 234, 85, 221, 92, 208, 139, 178, 224, 3, 94, 53, 79, 222, 68, 10, 84, 111, 28, 220, 81, 80, 15, 46, 87, 192, 68, 162, 30, 248, 36, 170, 98, 128, 64, 244, 246, 119, 108, 94, 48, 101, 254, 149, 210, 16, 14, 23, 3, 76, 133, 76, 196, 125, 216 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 145, 29, 206, 20, 68, 132, 135, 71, 131, 174, 38, 89, 124, 40, 50, 147, 215, 238, 25, 35, 142, 235, 216, 27, 243, 41, 142, 237, 45, 84, 56, 129, 245, 64, 166, 238, 94, 66, 99, 141, 137, 80, 30, 150, 218, 12, 111, 201, 244, 41, 96, 56, 39, 246, 178, 18, 2, 112, 15, 140, 12, 34, 107 }, new byte[] { 12, 104, 71, 0, 205, 206, 96, 71, 240, 175, 183, 151, 131, 244, 206, 148, 78, 43, 181, 146, 248, 2, 216, 61, 16, 143, 204, 188, 174, 219, 111, 141, 136, 153, 168, 133, 150, 243, 163, 117, 168, 146, 184, 187, 184, 98, 162, 45, 145, 100, 212, 65, 9, 19, 61, 40, 58, 133, 195, 67, 99, 101, 95, 225, 65, 244, 129, 212, 206, 122, 116, 229, 208, 103, 234, 85, 221, 92, 208, 139, 178, 224, 3, 94, 53, 79, 222, 68, 10, 84, 111, 28, 220, 81, 80, 15, 46, 87, 192, 68, 162, 30, 248, 36, 170, 98, 128, 64, 244, 246, 119, 108, 94, 48, 101, 254, 149, 210, 16, 14, 23, 3, 76, 133, 76, 196, 125, 216 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 197, 209, 236, 124, 90, 58, 65, 239, 44, 150, 130, 20, 37, 239, 220, 117, 77, 222, 190, 144, 7, 170, 182, 118, 111, 85, 93, 74, 174, 215, 243, 239, 19, 58, 155, 251, 169, 151, 240, 91, 236, 166, 208, 201, 3, 63, 70, 80, 116, 135, 163, 138, 70, 15, 158, 46, 174, 129, 183, 44, 115, 146, 73, 45 }, new byte[] { 12, 104, 71, 0, 205, 206, 96, 71, 240, 175, 183, 151, 131, 244, 206, 148, 78, 43, 181, 146, 248, 2, 216, 61, 16, 143, 204, 188, 174, 219, 111, 141, 136, 153, 168, 133, 150, 243, 163, 117, 168, 146, 184, 187, 184, 98, 162, 45, 145, 100, 212, 65, 9, 19, 61, 40, 58, 133, 195, 67, 99, 101, 95, 225, 65, 244, 129, 212, 206, 122, 116, 229, 208, 103, 234, 85, 221, 92, 208, 139, 178, 224, 3, 94, 53, 79, 222, 68, 10, 84, 111, 28, 220, 81, 80, 15, 46, 87, 192, 68, 162, 30, 248, 36, 170, 98, 128, 64, 244, 246, 119, 108, 94, 48, 101, 254, 149, 210, 16, 14, 23, 3, 76, 133, 76, 196, 125, 216 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderRegistrations_Users_UserId",
                table: "ProviderRegistrations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderRegistrations_Users_UserId",
                table: "ProviderRegistrations");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "ProviderRegistrations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 149, 3, 115, 205, 111, 46, 223, 159, 39, 254, 6, 229, 160, 38, 227, 63, 226, 95, 172, 130, 58, 25, 18, 35, 103, 12, 209, 156, 19, 187, 10, 89, 205, 50, 95, 63, 98, 182, 200, 113, 141, 30, 219, 149, 238, 36, 85, 147, 29, 37, 121, 236, 45, 225, 5, 227, 34, 62, 112, 203, 57, 108, 109, 190 }, new byte[] { 180, 241, 209, 105, 88, 253, 205, 121, 75, 102, 143, 7, 239, 126, 3, 176, 100, 146, 106, 93, 15, 69, 204, 137, 128, 210, 165, 196, 254, 181, 101, 102, 150, 203, 41, 204, 144, 75, 49, 21, 249, 247, 223, 51, 203, 1, 153, 47, 223, 170, 49, 129, 208, 124, 22, 245, 104, 147, 123, 187, 124, 188, 41, 235, 78, 243, 3, 203, 110, 60, 162, 117, 135, 215, 188, 22, 238, 1, 77, 206, 102, 229, 185, 98, 210, 230, 71, 89, 64, 234, 232, 131, 174, 110, 69, 40, 88, 76, 114, 207, 48, 22, 150, 72, 92, 201, 7, 155, 227, 169, 127, 195, 84, 221, 92, 138, 110, 202, 249, 133, 248, 51, 27, 40, 170, 157, 76, 14 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 166, 72, 202, 65, 93, 128, 14, 253, 174, 89, 55, 134, 16, 17, 128, 58, 195, 80, 107, 24, 200, 243, 232, 233, 94, 100, 247, 135, 63, 9, 211, 125, 10, 238, 10, 55, 108, 88, 38, 255, 89, 23, 229, 186, 241, 217, 98, 84, 209, 169, 77, 95, 165, 63, 117, 94, 251, 113, 150, 182, 29, 24, 239, 159 }, new byte[] { 180, 241, 209, 105, 88, 253, 205, 121, 75, 102, 143, 7, 239, 126, 3, 176, 100, 146, 106, 93, 15, 69, 204, 137, 128, 210, 165, 196, 254, 181, 101, 102, 150, 203, 41, 204, 144, 75, 49, 21, 249, 247, 223, 51, 203, 1, 153, 47, 223, 170, 49, 129, 208, 124, 22, 245, 104, 147, 123, 187, 124, 188, 41, 235, 78, 243, 3, 203, 110, 60, 162, 117, 135, 215, 188, 22, 238, 1, 77, 206, 102, 229, 185, 98, 210, 230, 71, 89, 64, 234, 232, 131, 174, 110, 69, 40, 88, 76, 114, 207, 48, 22, 150, 72, 92, 201, 7, 155, 227, 169, 127, 195, 84, 221, 92, 138, 110, 202, 249, 133, 248, 51, 27, 40, 170, 157, 76, 14 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 48, 0, 104, 164, 81, 31, 4, 56, 1, 166, 130, 93, 12, 183, 10, 121, 201, 3, 124, 218, 90, 70, 141, 40, 119, 40, 200, 94, 114, 137, 86, 136, 146, 156, 74, 138, 114, 2, 50, 165, 205, 220, 162, 2, 112, 164, 135, 224, 164, 50, 238, 125, 73, 126, 182, 139, 12, 160, 90, 253, 204, 200, 13, 178 }, new byte[] { 180, 241, 209, 105, 88, 253, 205, 121, 75, 102, 143, 7, 239, 126, 3, 176, 100, 146, 106, 93, 15, 69, 204, 137, 128, 210, 165, 196, 254, 181, 101, 102, 150, 203, 41, 204, 144, 75, 49, 21, 249, 247, 223, 51, 203, 1, 153, 47, 223, 170, 49, 129, 208, 124, 22, 245, 104, 147, 123, 187, 124, 188, 41, 235, 78, 243, 3, 203, 110, 60, 162, 117, 135, 215, 188, 22, 238, 1, 77, 206, 102, 229, 185, 98, 210, 230, 71, 89, 64, 234, 232, 131, 174, 110, 69, 40, 88, 76, 114, 207, 48, 22, 150, 72, 92, 201, 7, 155, 227, 169, 127, 195, 84, 221, 92, 138, 110, 202, 249, 133, 248, 51, 27, 40, 170, 157, 76, 14 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 67, 152, 8, 234, 70, 211, 132, 222, 76, 229, 118, 147, 28, 45, 6, 217, 41, 103, 187, 71, 27, 104, 156, 5, 46, 147, 82, 162, 151, 158, 246, 123, 104, 3, 14, 189, 220, 237, 130, 122, 234, 234, 32, 65, 172, 65, 210, 140, 92, 195, 201, 82, 58, 24, 152, 6, 101, 135, 60, 72, 238, 38, 165, 203 }, new byte[] { 180, 241, 209, 105, 88, 253, 205, 121, 75, 102, 143, 7, 239, 126, 3, 176, 100, 146, 106, 93, 15, 69, 204, 137, 128, 210, 165, 196, 254, 181, 101, 102, 150, 203, 41, 204, 144, 75, 49, 21, 249, 247, 223, 51, 203, 1, 153, 47, 223, 170, 49, 129, 208, 124, 22, 245, 104, 147, 123, 187, 124, 188, 41, 235, 78, 243, 3, 203, 110, 60, 162, 117, 135, 215, 188, 22, 238, 1, 77, 206, 102, 229, 185, 98, 210, 230, 71, 89, 64, 234, 232, 131, 174, 110, 69, 40, 88, 76, 114, 207, 48, 22, 150, 72, 92, 201, 7, 155, 227, 169, 127, 195, 84, 221, 92, 138, 110, 202, 249, 133, 248, 51, 27, 40, 170, 157, 76, 14 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 44, 41, 12, 119, 123, 240, 66, 70, 207, 94, 167, 246, 170, 60, 196, 126, 135, 164, 223, 164, 97, 124, 235, 118, 187, 186, 108, 18, 98, 65, 14, 114, 111, 62, 238, 47, 18, 6, 68, 68, 3, 46, 127, 160, 245, 115, 96, 48, 224, 228, 232, 96, 209, 223, 81, 159, 112, 169, 46, 231, 191, 25, 213, 95 }, new byte[] { 180, 241, 209, 105, 88, 253, 205, 121, 75, 102, 143, 7, 239, 126, 3, 176, 100, 146, 106, 93, 15, 69, 204, 137, 128, 210, 165, 196, 254, 181, 101, 102, 150, 203, 41, 204, 144, 75, 49, 21, 249, 247, 223, 51, 203, 1, 153, 47, 223, 170, 49, 129, 208, 124, 22, 245, 104, 147, 123, 187, 124, 188, 41, 235, 78, 243, 3, 203, 110, 60, 162, 117, 135, 215, 188, 22, 238, 1, 77, 206, 102, 229, 185, 98, 210, 230, 71, 89, 64, 234, 232, 131, 174, 110, 69, 40, 88, 76, 114, 207, 48, 22, 150, 72, 92, 201, 7, 155, 227, 169, 127, 195, 84, 221, 92, 138, 110, 202, 249, 133, 248, 51, 27, 40, 170, 157, 76, 14 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 198, 176, 153, 229, 72, 180, 96, 3, 203, 29, 38, 182, 201, 39, 181, 155, 155, 65, 221, 250, 226, 250, 46, 153, 221, 81, 119, 10, 250, 97, 45, 139, 171, 236, 49, 30, 117, 141, 29, 1, 17, 132, 89, 236, 78, 169, 67, 93, 132, 64, 115, 82, 160, 141, 240, 136, 209, 65, 212, 96, 118, 31, 249, 69 }, new byte[] { 180, 241, 209, 105, 88, 253, 205, 121, 75, 102, 143, 7, 239, 126, 3, 176, 100, 146, 106, 93, 15, 69, 204, 137, 128, 210, 165, 196, 254, 181, 101, 102, 150, 203, 41, 204, 144, 75, 49, 21, 249, 247, 223, 51, 203, 1, 153, 47, 223, 170, 49, 129, 208, 124, 22, 245, 104, 147, 123, 187, 124, 188, 41, 235, 78, 243, 3, 203, 110, 60, 162, 117, 135, 215, 188, 22, 238, 1, 77, 206, 102, 229, 185, 98, 210, 230, 71, 89, 64, 234, 232, 131, 174, 110, 69, 40, 88, 76, 114, 207, 48, 22, 150, 72, 92, 201, 7, 155, 227, 169, 127, 195, 84, 221, 92, 138, 110, 202, 249, 133, 248, 51, 27, 40, 170, 157, 76, 14 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderRegistrations_Users_UserId",
                table: "ProviderRegistrations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}