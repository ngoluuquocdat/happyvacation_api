using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class SeedData_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CreditCardRequired", "Description", "District", "Email", "HasBreakfast", "HasParkingLot", "MinChildAge", "Name", "Note", "PayInAdvance", "PetAllowed", "Phone", "PlaceId", "Province", "Stars", "Ward" },
                values: new object[,]
                {
                    { 1, "568 Cua Dai", false, "Featuring a free-form outdoor pool and free private parking, Hai Yen Hotel offers budget accommodations with free Wi-Fi and flat-screen TVs. It is centrally located in Hoi An Ancient Town.&Hotel Hai Yen is 2.4 km from well-known Cua Dai Beach.&Large air conditioned rooms at Hai Yen are equipped with a private balcony and seating areas.They are equipped with a safe, electric teakettle and satellite TV.Private bathrooms have a bathtub, toiletries and a hairdryer.&The staff is available at the front desk 24 hours a day and can help with travel arrangements.Guests can purchase gifts at the souvenir shop. Hai Yen Hotel provides shuttle service and currency exchange.&Local dishes, snacks and beverages are offered at Hai Yen’s restaurant.", "Hoi An", "sales@haiyenhotel.com.vn", true, true, 13, "Hai Yen Hotel", "Please inform Hai Yen Hotel of your expected arrival time in advance. You can use the Special Requests box when booking, or contact the property directly using the contact details in your confirmation.&Guests are required to show a photo ID and credit card upon check-in. Please note that all Special Requests are subject to availability and additional charges may apply.&In the event of an early departure, the property will charge you the full amount for your stay.&Parking is subject to availability due to limited spaces.&", false, false, "02033969555", 3, "Quang Nam", 2, "Cam Chau" },
                    { 2, "01 Cua Dai", true, "This property is 1 minute walk from the beach. Nestled between Cua Dai Beach and De Vong River, Hoi An Beach Resort features 2 outdoor pools. It provides free Wi-Fi and two-way shuttle services to Hoi An Ancient Town.&Rooms at Resort Hoi An come with private balconies overlooking the garden, river or sea. Each room is equipped with a TV, safety deposit box and tea/coffee making facilities..&Local cooking classes begin with a guided boat trip to Hoi An Market. Waterlily Spa offers Vietnamese massage therapies. Other recreational activities include a game of billiards or a workout in the fitness center..&At River Breeze Restaurant, guests can eat indoors or on the balcony overlooking the river. Snacks and refreshments can be enjoyed at the Sunshine Bar and the beachfront Sands Bar..&Hoi An Beach Resort is a 45-minute drive from Danang International Airport and 2.5 mi from Hoi An’s town center. An airport shuttle is available at extra charge.", "Hoi An", "reservation@hoianbeachresort.com.vn", true, true, 6, "Hoi An Beach Resort ", "", false, false, "02353927011", 3, "Quang Nam", 4, "Cua Dai" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 4, "Hotel_Owner" });

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

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Adults", "BookingDate", "CancelReason", "CheckIn", "CheckOut", "Children", "CustomerEmail", "CustomerName", "CustomerPhone", "HotelId", "State", "UserId" },
                values: new object[,]
                {
                    { 1, 8, new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "braddinh1952000@gmail.com", "Cong Tai Dinh", "0945501905", 1, "confirmed", 3 },
                    { 2, 4, new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "ngoluuquocdat@gmail.com", "Quoc Dat Ngo Luu", "0905553859", 2, "confirmed", 4 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Area", "Description", "HotelId", "MaxAdults", "Name", "Price", "SmokingAllowed", "Stock", "Views" },
                values: new object[,]
                {
                    { 1, 25, "This double room features a electric kettle, air conditioning and tile/marble floor.&", 1, 2, "Standard Double or Twin Room", 50, false, 4, "None" },
                    { 2, 25, "This twin room features a minibar, tile/marble floor and electric kettle.&", 1, 3, "Superior Double or Twin Room", 54, false, 4, "None" },
                    { 3, 55, "Located on the ground floor, air-conditioned rooms feature Eastern designs and traditional Vietnamese lanterns. There is a private balcony that leads to the garden. En suite bathroom comes with a bathtub and separate shower facility.&", 2, 2, "Grand Deluxe", 144, false, 8, "Garden View" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "FirstName", "HotelId", "IsEnabled", "LastName", "PasswordHash", "PasswordSalt", "Phone", "ProviderId", "Username" },
                values: new object[,]
                {
                    { 8, "/storage/duy.jpg", "duylam2906@gmail.com", "Thai Duy", 1, true, "Lam", new byte[] { 54, 66, 81, 228, 254, 4, 242, 80, 96, 171, 12, 135, 146, 50, 114, 26, 186, 153, 42, 247, 175, 128, 197, 28, 83, 18, 166, 175, 74, 250, 208, 177, 221, 170, 196, 167, 24, 136, 167, 202, 99, 77, 230, 253, 16, 13, 117, 225, 203, 43, 149, 49, 13, 23, 202, 248, 116, 114, 204, 59, 246, 40, 220, 243 }, new byte[] { 16, 1, 80, 89, 75, 174, 85, 243, 21, 169, 230, 192, 75, 193, 63, 36, 5, 104, 120, 122, 81, 201, 246, 195, 118, 212, 227, 128, 32, 116, 147, 31, 202, 129, 155, 10, 86, 204, 48, 44, 57, 46, 14, 240, 206, 71, 236, 70, 12, 21, 53, 126, 188, 209, 215, 236, 233, 65, 137, 144, 185, 165, 223, 42, 116, 244, 170, 127, 126, 203, 178, 92, 229, 165, 110, 200, 93, 57, 254, 62, 23, 207, 156, 143, 3, 179, 13, 9, 250, 67, 234, 68, 169, 153, 34, 236, 218, 50, 72, 12, 161, 81, 215, 41, 193, 195, 175, 207, 220, 80, 10, 136, 239, 22, 218, 76, 147, 173, 28, 251, 21, 46, 215, 57, 69, 173, 161, 124 }, "0764132745", null, "thaiduy" },
                    { 9, "/storage/toan.jpg", "xuantoan2401@gmail.com", "Xuan Toan", 2, true, "Mai", new byte[] { 224, 241, 21, 23, 159, 142, 122, 30, 43, 48, 20, 192, 181, 170, 249, 27, 116, 199, 213, 215, 208, 175, 244, 224, 235, 172, 41, 145, 47, 82, 79, 125, 21, 212, 196, 23, 17, 172, 171, 49, 146, 47, 19, 248, 35, 61, 81, 217, 196, 184, 211, 132, 218, 241, 104, 113, 199, 208, 44, 186, 237, 69, 145, 123 }, new byte[] { 16, 1, 80, 89, 75, 174, 85, 243, 21, 169, 230, 192, 75, 193, 63, 36, 5, 104, 120, 122, 81, 201, 246, 195, 118, 212, 227, 128, 32, 116, 147, 31, 202, 129, 155, 10, 86, 204, 48, 44, 57, 46, 14, 240, 206, 71, 236, 70, 12, 21, 53, 126, 188, 209, 215, 236, 233, 65, 137, 144, 185, 165, 223, 42, 116, 244, 170, 127, 126, 203, 178, 92, 229, 165, 110, 200, 93, 57, 254, 62, 23, 207, 156, 143, 3, 179, 13, 9, 250, 67, 234, 68, 169, 153, 34, 236, 218, 50, 72, 12, 161, 81, 215, 41, 193, 195, 175, 207, 220, 80, 10, 136, 239, 22, 218, 76, 147, 173, 28, 251, 21, 46, 215, 57, 69, 173, 161, 124 }, "0783803087", null, "xuantoan" }
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "Id", "BookingId", "Quantity", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, 2, 1 },
                    { 2, 1, 2, 2 },
                    { 3, 2, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 8 },
                    { 4, 8 },
                    { 3, 9 },
                    { 4, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookingDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

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
        }
    }
}
