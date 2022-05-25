﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class Add_Column_TransactionId_Order_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMembers_Orders_OrderId",
                table: "OrderMembers");

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactionId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TransactionId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 107, 17, 238, 77, 123, 51, 156, 101, 95, 178, 154, 169, 224, 108, 108, 185, 100, 181, 117, 127, 94, 129, 35, 9, 174, 204, 194, 185, 159, 139, 119, 158, 113, 21, 240, 4, 16, 36, 4, 110, 129, 192, 179, 128, 247, 218, 52, 64, 3, 248, 15, 145, 207, 21, 6, 36, 107, 133, 240, 163, 179, 206, 246, 174 }, new byte[] { 80, 10, 180, 202, 196, 179, 226, 16, 162, 224, 199, 57, 131, 45, 212, 46, 242, 73, 168, 77, 201, 244, 228, 101, 137, 243, 115, 141, 89, 0, 87, 225, 92, 164, 144, 182, 213, 207, 90, 9, 107, 221, 95, 22, 147, 59, 27, 144, 220, 36, 228, 156, 203, 72, 11, 241, 166, 146, 33, 196, 198, 146, 144, 54, 64, 142, 180, 195, 221, 39, 18, 98, 88, 177, 100, 88, 71, 230, 221, 54, 197, 228, 35, 183, 116, 102, 125, 95, 15, 58, 133, 75, 214, 19, 182, 197, 212, 132, 205, 77, 68, 160, 168, 14, 39, 252, 78, 39, 94, 50, 155, 61, 23, 197, 8, 222, 218, 251, 53, 98, 108, 1, 53, 134, 156, 71, 240, 135 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 111, 166, 176, 35, 208, 178, 107, 57, 126, 18, 247, 115, 97, 46, 155, 88, 112, 208, 49, 173, 187, 103, 194, 72, 236, 151, 234, 35, 92, 74, 87, 192, 0, 67, 231, 30, 103, 217, 185, 90, 19, 252, 227, 102, 59, 112, 151, 64, 121, 142, 244, 72, 171, 189, 174, 200, 66, 36, 218, 235, 78, 126, 136, 13 }, new byte[] { 80, 10, 180, 202, 196, 179, 226, 16, 162, 224, 199, 57, 131, 45, 212, 46, 242, 73, 168, 77, 201, 244, 228, 101, 137, 243, 115, 141, 89, 0, 87, 225, 92, 164, 144, 182, 213, 207, 90, 9, 107, 221, 95, 22, 147, 59, 27, 144, 220, 36, 228, 156, 203, 72, 11, 241, 166, 146, 33, 196, 198, 146, 144, 54, 64, 142, 180, 195, 221, 39, 18, 98, 88, 177, 100, 88, 71, 230, 221, 54, 197, 228, 35, 183, 116, 102, 125, 95, 15, 58, 133, 75, 214, 19, 182, 197, 212, 132, 205, 77, 68, 160, 168, 14, 39, 252, 78, 39, 94, 50, 155, 61, 23, 197, 8, 222, 218, 251, 53, 98, 108, 1, 53, 134, 156, 71, 240, 135 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 24, 1, 193, 117, 193, 160, 222, 93, 162, 24, 2, 201, 2, 75, 192, 213, 236, 214, 99, 70, 135, 55, 211, 124, 184, 144, 27, 198, 221, 76, 88, 28, 146, 219, 234, 126, 75, 43, 2, 87, 77, 75, 81, 145, 112, 48, 123, 31, 159, 106, 82, 175, 28, 167, 181, 34, 183, 25, 29, 48, 159, 213, 33, 206 }, new byte[] { 80, 10, 180, 202, 196, 179, 226, 16, 162, 224, 199, 57, 131, 45, 212, 46, 242, 73, 168, 77, 201, 244, 228, 101, 137, 243, 115, 141, 89, 0, 87, 225, 92, 164, 144, 182, 213, 207, 90, 9, 107, 221, 95, 22, 147, 59, 27, 144, 220, 36, 228, 156, 203, 72, 11, 241, 166, 146, 33, 196, 198, 146, 144, 54, 64, 142, 180, 195, 221, 39, 18, 98, 88, 177, 100, 88, 71, 230, 221, 54, 197, 228, 35, 183, 116, 102, 125, 95, 15, 58, 133, 75, 214, 19, 182, 197, 212, 132, 205, 77, 68, 160, 168, 14, 39, 252, 78, 39, 94, 50, 155, 61, 23, 197, 8, 222, 218, 251, 53, 98, 108, 1, 53, 134, 156, 71, 240, 135 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 216, 245, 17, 166, 147, 49, 142, 207, 56, 35, 106, 90, 106, 42, 80, 188, 224, 16, 45, 86, 50, 209, 141, 127, 35, 241, 182, 124, 147, 243, 203, 45, 199, 238, 111, 220, 179, 70, 163, 107, 248, 31, 156, 153, 198, 25, 203, 42, 32, 108, 140, 109, 205, 182, 125, 224, 243, 105, 41, 39, 198, 205, 139, 79 }, new byte[] { 80, 10, 180, 202, 196, 179, 226, 16, 162, 224, 199, 57, 131, 45, 212, 46, 242, 73, 168, 77, 201, 244, 228, 101, 137, 243, 115, 141, 89, 0, 87, 225, 92, 164, 144, 182, 213, 207, 90, 9, 107, 221, 95, 22, 147, 59, 27, 144, 220, 36, 228, 156, 203, 72, 11, 241, 166, 146, 33, 196, 198, 146, 144, 54, 64, 142, 180, 195, 221, 39, 18, 98, 88, 177, 100, 88, 71, 230, 221, 54, 197, 228, 35, 183, 116, 102, 125, 95, 15, 58, 133, 75, 214, 19, 182, 197, 212, 132, 205, 77, 68, 160, 168, 14, 39, 252, 78, 39, 94, 50, 155, 61, 23, 197, 8, 222, 218, 251, 53, 98, 108, 1, 53, 134, 156, 71, 240, 135 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 199, 7, 93, 99, 157, 180, 125, 197, 2, 118, 198, 90, 160, 230, 155, 53, 211, 165, 121, 165, 224, 48, 158, 92, 90, 26, 209, 20, 103, 150, 252, 182, 10, 192, 42, 1, 51, 9, 225, 171, 1, 172, 249, 111, 163, 248, 0, 223, 49, 84, 235, 95, 34, 149, 33, 251, 131, 183, 35, 163, 209, 172, 26, 133 }, new byte[] { 80, 10, 180, 202, 196, 179, 226, 16, 162, 224, 199, 57, 131, 45, 212, 46, 242, 73, 168, 77, 201, 244, 228, 101, 137, 243, 115, 141, 89, 0, 87, 225, 92, 164, 144, 182, 213, 207, 90, 9, 107, 221, 95, 22, 147, 59, 27, 144, 220, 36, 228, 156, 203, 72, 11, 241, 166, 146, 33, 196, 198, 146, 144, 54, 64, 142, 180, 195, 221, 39, 18, 98, 88, 177, 100, 88, 71, 230, 221, 54, 197, 228, 35, 183, 116, 102, 125, 95, 15, 58, 133, 75, 214, 19, 182, 197, 212, 132, 205, 77, 68, 160, 168, 14, 39, 252, 78, 39, 94, 50, 155, 61, 23, 197, 8, 222, 218, 251, 53, 98, 108, 1, 53, 134, 156, 71, 240, 135 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 130, 169, 165, 145, 130, 66, 175, 143, 27, 237, 206, 231, 4, 28, 57, 251, 40, 118, 244, 236, 217, 204, 197, 69, 73, 93, 217, 52, 26, 129, 250, 151, 91, 193, 94, 40, 97, 61, 105, 68, 65, 83, 105, 121, 123, 225, 37, 82, 128, 165, 238, 238, 102, 46, 26, 142, 55, 106, 56, 227, 33, 175, 132, 20 }, new byte[] { 80, 10, 180, 202, 196, 179, 226, 16, 162, 224, 199, 57, 131, 45, 212, 46, 242, 73, 168, 77, 201, 244, 228, 101, 137, 243, 115, 141, 89, 0, 87, 225, 92, 164, 144, 182, 213, 207, 90, 9, 107, 221, 95, 22, 147, 59, 27, 144, 220, 36, 228, 156, 203, 72, 11, 241, 166, 146, 33, 196, 198, 146, 144, 54, 64, 142, 180, 195, 221, 39, 18, 98, 88, 177, 100, 88, 71, 230, 221, 54, 197, 228, 35, 183, 116, 102, 125, 95, 15, 58, 133, 75, 214, 19, 182, 197, 212, 132, 205, 77, 68, 160, 168, 14, 39, 252, 78, 39, 94, 50, 155, 61, 23, 197, 8, 222, 218, 251, 53, 98, 108, 1, 53, 134, 156, 71, 240, 135 } });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMembers_Orders_OrderId",
                table: "OrderMembers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMembers_Orders_OrderId",
                table: "OrderMembers");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 203, 212, 140, 110, 138, 147, 251, 79, 153, 150, 12, 250, 151, 192, 198, 34, 45, 255, 107, 90, 164, 130, 200, 152, 39, 150, 56, 210, 141, 93, 215, 76, 81, 11, 184, 200, 145, 130, 93, 58, 119, 0, 240, 199, 203, 113, 42, 253, 57, 182, 89, 41, 35, 65, 30, 6, 73, 95, 46, 89, 192, 82, 225, 19 }, new byte[] { 222, 119, 119, 100, 136, 212, 75, 209, 215, 100, 153, 23, 49, 186, 172, 252, 34, 198, 131, 38, 137, 71, 184, 233, 93, 149, 72, 143, 200, 16, 253, 28, 252, 38, 30, 122, 1, 132, 241, 173, 225, 117, 64, 67, 76, 92, 133, 217, 20, 14, 155, 39, 190, 97, 251, 133, 242, 126, 176, 3, 226, 224, 123, 115, 100, 42, 174, 250, 145, 215, 127, 169, 106, 255, 71, 120, 153, 246, 6, 228, 168, 69, 136, 254, 208, 108, 111, 39, 195, 37, 217, 221, 166, 238, 234, 103, 128, 13, 26, 54, 224, 182, 97, 202, 145, 186, 161, 50, 183, 9, 196, 249, 203, 196, 224, 131, 93, 127, 154, 144, 31, 235, 102, 56, 29, 28, 216, 237 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 8, 168, 216, 76, 16, 174, 173, 88, 212, 237, 39, 16, 200, 29, 200, 102, 97, 55, 211, 35, 141, 168, 83, 180, 222, 219, 87, 22, 181, 179, 141, 25, 134, 64, 214, 103, 251, 47, 64, 57, 143, 175, 105, 11, 160, 218, 192, 17, 184, 14, 101, 169, 155, 102, 237, 229, 211, 107, 225, 72, 177, 230, 26, 83 }, new byte[] { 222, 119, 119, 100, 136, 212, 75, 209, 215, 100, 153, 23, 49, 186, 172, 252, 34, 198, 131, 38, 137, 71, 184, 233, 93, 149, 72, 143, 200, 16, 253, 28, 252, 38, 30, 122, 1, 132, 241, 173, 225, 117, 64, 67, 76, 92, 133, 217, 20, 14, 155, 39, 190, 97, 251, 133, 242, 126, 176, 3, 226, 224, 123, 115, 100, 42, 174, 250, 145, 215, 127, 169, 106, 255, 71, 120, 153, 246, 6, 228, 168, 69, 136, 254, 208, 108, 111, 39, 195, 37, 217, 221, 166, 238, 234, 103, 128, 13, 26, 54, 224, 182, 97, 202, 145, 186, 161, 50, 183, 9, 196, 249, 203, 196, 224, 131, 93, 127, 154, 144, 31, 235, 102, 56, 29, 28, 216, 237 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 245, 10, 77, 242, 235, 32, 205, 204, 166, 125, 117, 186, 131, 80, 252, 28, 131, 208, 164, 52, 206, 87, 161, 107, 100, 88, 199, 72, 90, 13, 182, 15, 35, 45, 92, 97, 155, 70, 107, 241, 100, 6, 168, 204, 37, 98, 252, 227, 25, 237, 6, 74, 62, 103, 91, 238, 48, 165, 19, 173, 110, 241, 13, 153 }, new byte[] { 222, 119, 119, 100, 136, 212, 75, 209, 215, 100, 153, 23, 49, 186, 172, 252, 34, 198, 131, 38, 137, 71, 184, 233, 93, 149, 72, 143, 200, 16, 253, 28, 252, 38, 30, 122, 1, 132, 241, 173, 225, 117, 64, 67, 76, 92, 133, 217, 20, 14, 155, 39, 190, 97, 251, 133, 242, 126, 176, 3, 226, 224, 123, 115, 100, 42, 174, 250, 145, 215, 127, 169, 106, 255, 71, 120, 153, 246, 6, 228, 168, 69, 136, 254, 208, 108, 111, 39, 195, 37, 217, 221, 166, 238, 234, 103, 128, 13, 26, 54, 224, 182, 97, 202, 145, 186, 161, 50, 183, 9, 196, 249, 203, 196, 224, 131, 93, 127, 154, 144, 31, 235, 102, 56, 29, 28, 216, 237 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 155, 184, 123, 140, 112, 119, 240, 229, 24, 169, 34, 151, 146, 157, 144, 193, 168, 174, 248, 0, 160, 254, 253, 53, 190, 254, 146, 114, 239, 74, 217, 120, 186, 124, 246, 162, 50, 124, 175, 127, 60, 110, 242, 138, 193, 240, 79, 237, 179, 127, 223, 28, 235, 180, 126, 185, 243, 3, 30, 26, 41, 10, 25, 242 }, new byte[] { 222, 119, 119, 100, 136, 212, 75, 209, 215, 100, 153, 23, 49, 186, 172, 252, 34, 198, 131, 38, 137, 71, 184, 233, 93, 149, 72, 143, 200, 16, 253, 28, 252, 38, 30, 122, 1, 132, 241, 173, 225, 117, 64, 67, 76, 92, 133, 217, 20, 14, 155, 39, 190, 97, 251, 133, 242, 126, 176, 3, 226, 224, 123, 115, 100, 42, 174, 250, 145, 215, 127, 169, 106, 255, 71, 120, 153, 246, 6, 228, 168, 69, 136, 254, 208, 108, 111, 39, 195, 37, 217, 221, 166, 238, 234, 103, 128, 13, 26, 54, 224, 182, 97, 202, 145, 186, 161, 50, 183, 9, 196, 249, 203, 196, 224, 131, 93, 127, 154, 144, 31, 235, 102, 56, 29, 28, 216, 237 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 201, 13, 25, 216, 109, 183, 204, 27, 236, 84, 111, 100, 105, 162, 218, 179, 36, 218, 211, 1, 163, 103, 234, 120, 122, 183, 29, 224, 70, 205, 211, 207, 163, 197, 64, 59, 144, 57, 68, 35, 172, 1, 204, 15, 233, 16, 77, 42, 87, 73, 9, 70, 42, 42, 37, 201, 123, 125, 166, 255, 189, 99, 183, 171 }, new byte[] { 222, 119, 119, 100, 136, 212, 75, 209, 215, 100, 153, 23, 49, 186, 172, 252, 34, 198, 131, 38, 137, 71, 184, 233, 93, 149, 72, 143, 200, 16, 253, 28, 252, 38, 30, 122, 1, 132, 241, 173, 225, 117, 64, 67, 76, 92, 133, 217, 20, 14, 155, 39, 190, 97, 251, 133, 242, 126, 176, 3, 226, 224, 123, 115, 100, 42, 174, 250, 145, 215, 127, 169, 106, 255, 71, 120, 153, 246, 6, 228, 168, 69, 136, 254, 208, 108, 111, 39, 195, 37, 217, 221, 166, 238, 234, 103, 128, 13, 26, 54, 224, 182, 97, 202, 145, 186, 161, 50, 183, 9, 196, 249, 203, 196, 224, 131, 93, 127, 154, 144, 31, 235, 102, 56, 29, 28, 216, 237 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 130, 203, 59, 17, 138, 111, 23, 102, 161, 245, 8, 66, 40, 115, 225, 133, 143, 232, 225, 127, 165, 77, 220, 136, 197, 199, 13, 80, 167, 216, 155, 121, 27, 134, 13, 76, 63, 134, 108, 243, 254, 232, 118, 111, 44, 20, 31, 209, 233, 46, 3, 181, 114, 219, 255, 118, 101, 16, 184, 24, 177, 139, 94, 71 }, new byte[] { 222, 119, 119, 100, 136, 212, 75, 209, 215, 100, 153, 23, 49, 186, 172, 252, 34, 198, 131, 38, 137, 71, 184, 233, 93, 149, 72, 143, 200, 16, 253, 28, 252, 38, 30, 122, 1, 132, 241, 173, 225, 117, 64, 67, 76, 92, 133, 217, 20, 14, 155, 39, 190, 97, 251, 133, 242, 126, 176, 3, 226, 224, 123, 115, 100, 42, 174, 250, 145, 215, 127, 169, 106, 255, 71, 120, 153, 246, 6, 228, 168, 69, 136, 254, 208, 108, 111, 39, 195, 37, 217, 221, 166, 238, 234, 103, 128, 13, 26, 54, 224, 182, 97, 202, 145, 186, 161, 50, 183, 9, 196, 249, 203, 196, 224, 131, 93, 127, 154, 144, 31, 235, 102, 56, 29, 28, 216, 237 } });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMembers_Orders_OrderId",
                table: "OrderMembers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}