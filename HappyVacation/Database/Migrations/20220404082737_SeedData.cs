using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "adventure tour" },
                    { 2, "artistic tour" },
                    { 3, "beach tour" },
                    { 4, "biking tour" },
                    { 5, "boating tour" },
                    { 6, "camping" },
                    { 7, "classic tour" },
                    { 8, "cooking tour" },
                    { 9, "craft tour" },
                    { 10, "cruises tour" },
                    { 11, "culinary tour" },
                    { 12, "cultural tour" },
                    { 13, "discovery tour" },
                    { 14, "fishing tour" },
                    { 15, "heritage tour" },
                    { 16, "historical tour" },
                    { 17, "homestay tour" },
                    { 18, "honeymoon  tour" },
                    { 19, "luxury tour" },
                    { 20, "'motorcycle  tour" },
                    { 21, "nature-based tour" },
                    { 23, "relaxing tour" },
                    { 24, "shopping tour" },
                    { 25, "snorkeling tour" },
                    { 26, "sports tour" },
                    { 27, "trekking  tour" },
                    { 28, "walking  tour" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "IsTop", "PlaceName", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, true, "Da Nang", "/storage/danang.jpg" },
                    { 2, true, "Hue", "/storage/hue.jpg" },
                    { 3, true, "Hoi An", "/storage/hoian.jpg" },
                    { 4, false, "Ha Long", "/storage/halong.jpg" },
                    { 5, true, "Ha Noi", "/storage/hanoi.jpg" },
                    { 6, true, "Ho Chi Minh", "/storage/hochiminh.jpg" },
                    { 7, false, "Da Lat", "/storage/dalat.jpg" },
                    { 8, true, "Nha Trang", "/storage/nhatrang.jpg" },
                    { 9, false, "Phu Quoc", "/storage/phuquoc.jpg" },
                    { 10, false, "Quy Nhon", "/storage/quynhon.jpg" },
                    { 11, false, "Sa Pa", "/storage/sapa.jpg" },
                    { 12, false, "Vung Tau", "/storage/vungtau.jpg" },
                    { 13, false, "Mui Ne", "/storage/muine.jpg" },
                    { 14, false, "Con Dao", "/storage/condao.jpg" },
                    { 15, false, "Trang An", "/storage/trangan.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Address", "DateCreated", "Description", "IsEnabled", "ProviderEmail", "ProviderName", "ProviderPhone", "ThumbnailUrl" },
                values: new object[] { 1, "32 Tien Giang St, Tan Binh District, Ho Chi Minh City, Viet Nam", new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Established in 2002, Hoi An Express is a company specializing in organizing professional tours for foreign visitors to Vietnam to visit tours, conferences, events combined with team building.", true, "info@hoianexpress.com.vn", "Hoi An Express", "0905123456", "/storage/hoianexpresslogo.jpg" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Provider" },
                    { 3, "Tourist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "FirstName", "IsEnabled", "LastName", "PasswordHash", "PasswordSalt", "Phone", "ProviderId", "Username" },
                values: new object[,]
                {
                    { 1, null, "ngoluuquocdat@gmail.com", "Quoc Dat", true, "Ngo Luu", new byte[] { 86, 216, 137, 100, 190, 7, 14, 106, 96, 116, 52, 37, 148, 152, 15, 17, 251, 8, 73, 40, 233, 149, 90, 141, 142, 42, 193, 131, 246, 206, 101, 245, 226, 101, 145, 221, 206, 223, 89, 193, 170, 6, 177, 228, 236, 101, 125, 247, 252, 116, 213, 43, 10, 201, 24, 165, 128, 23, 80, 108, 153, 71, 113, 69 }, new byte[] { 130, 191, 110, 108, 145, 189, 16, 233, 173, 115, 107, 196, 64, 42, 131, 61, 33, 0, 88, 34, 80, 50, 165, 95, 49, 29, 30, 55, 167, 109, 154, 61, 150, 237, 163, 133, 243, 106, 61, 19, 115, 244, 250, 43, 234, 6, 212, 159, 57, 31, 195, 202, 2, 239, 51, 17, 189, 64, 14, 252, 207, 252, 200, 27, 100, 235, 148, 138, 195, 21, 11, 242, 217, 254, 24, 29, 247, 57, 63, 118, 232, 215, 126, 35, 68, 221, 69, 237, 223, 38, 72, 111, 254, 122, 227, 69, 58, 175, 162, 223, 21, 240, 123, 157, 188, 35, 14, 106, 4, 146, 228, 126, 107, 93, 203, 170, 124, 63, 148, 255, 191, 119, 150, 174, 77, 199, 41, 223 }, "0905553859", null, "admin" },
                    { 3, "/storage/tai.jpg", "braddinh1952000@gmail.com", "Cong Tai", true, "Dinh", new byte[] { 86, 205, 52, 28, 97, 147, 118, 118, 21, 225, 14, 215, 225, 9, 140, 125, 187, 119, 255, 248, 164, 134, 190, 197, 113, 173, 28, 12, 176, 238, 21, 167, 73, 61, 201, 198, 247, 180, 76, 248, 97, 102, 29, 245, 130, 221, 184, 33, 123, 194, 27, 99, 204, 126, 37, 160, 154, 191, 4, 42, 129, 52, 144, 69 }, new byte[] { 130, 191, 110, 108, 145, 189, 16, 233, 173, 115, 107, 196, 64, 42, 131, 61, 33, 0, 88, 34, 80, 50, 165, 95, 49, 29, 30, 55, 167, 109, 154, 61, 150, 237, 163, 133, 243, 106, 61, 19, 115, 244, 250, 43, 234, 6, 212, 159, 57, 31, 195, 202, 2, 239, 51, 17, 189, 64, 14, 252, 207, 252, 200, 27, 100, 235, 148, 138, 195, 21, 11, 242, 217, 254, 24, 29, 247, 57, 63, 118, 232, 215, 126, 35, 68, 221, 69, 237, 223, 38, 72, 111, 254, 122, 227, 69, 58, 175, 162, 223, 21, 240, 123, 157, 188, 35, 14, 106, 4, 146, 228, 126, 107, 93, 203, 170, 124, 63, 148, 255, 191, 119, 150, 174, 77, 199, 41, 223 }, "0945501905", null, "congtai" },
                    { 4, "/storage/dat.jpg", "ngoluuquocdat@gmail.com", "Quoc Dat", true, "Ngo Luu", new byte[] { 179, 155, 118, 7, 140, 225, 210, 172, 95, 145, 239, 82, 176, 174, 6, 120, 167, 68, 12, 72, 138, 17, 109, 122, 194, 218, 46, 34, 81, 12, 196, 106, 250, 244, 46, 51, 70, 86, 147, 226, 0, 146, 205, 206, 43, 38, 213, 220, 225, 113, 244, 237, 147, 186, 8, 62, 38, 20, 144, 108, 160, 9, 127, 101 }, new byte[] { 130, 191, 110, 108, 145, 189, 16, 233, 173, 115, 107, 196, 64, 42, 131, 61, 33, 0, 88, 34, 80, 50, 165, 95, 49, 29, 30, 55, 167, 109, 154, 61, 150, 237, 163, 133, 243, 106, 61, 19, 115, 244, 250, 43, 234, 6, 212, 159, 57, 31, 195, 202, 2, 239, 51, 17, 189, 64, 14, 252, 207, 252, 200, 27, 100, 235, 148, 138, 195, 21, 11, 242, 217, 254, 24, 29, 247, 57, 63, 118, 232, 215, 126, 35, 68, 221, 69, 237, 223, 38, 72, 111, 254, 122, 227, 69, 58, 175, 162, 223, 21, 240, 123, 157, 188, 35, 14, 106, 4, 146, 228, 126, 107, 93, 203, 170, 124, 63, 148, 255, 191, 119, 150, 174, 77, 199, 41, 223 }, "0905553859", null, "quocdat" }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Destination", "Duration", "GroupSize", "IsAvailable", "IsPrivate", "Location", "MinAdults", "Overview", "PlaceId", "PricePerAdult", "PricePerChild", "ProviderId", "TourName", "ViewCount" },
                values: new object[,]
                {
                    { 1, "Cam Chau Ward, Hoi An City, Quang Nam Province", 0.5f, 15, true, false, "Minh An Ward, Hoi An City, Quang Nam Province", 2, "Take a journey through Hoi An’s culinary history; head out to the beautiful countryside by bicycle to experience some traditional local food favorites, including the most famous of Hoi An specialties; Cao Lau. Try the traditional Hoi An specialty, Cao Lau; intoxicating pork noodle broth, featuring sticky rice noodles that must be soaked in water from the oldest well in Hoi An, Ba Le Well.", 3, 89, 30, 1, "HALF-DAY FOODIE TOUR BY BICYCLE & VISIT TRA QUE VEGETABLE VILLAGE", 10 },
                    { 2, "Minh An Ward, Hoi An City, Quang Nam Province", 0.125f, 15, true, true, "Minh An Ward, Hoi An City, Quang Nam Province", 1, "Have a memorable end to your day in Hoi An with a tour of the ancient town after the sun goes down. See the centuries-old houses and monuments illuminated by local lanterns. Visit a traditional restaurant for dinner", 3, 180, 50, 1, "Private Tour: HOI AN MYSTERIOUS NIGHT TOUR WITH DINNER FROM HOI AN", 5 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "FirstName", "IsEnabled", "LastName", "PasswordHash", "PasswordSalt", "Phone", "ProviderId", "Username" },
                values: new object[] { 2, "/storage/tuan.jpg", "tuandang29042000@gmail.com", "Quoc Tuan", true, "Dang", new byte[] { 20, 148, 122, 177, 133, 0, 207, 136, 10, 79, 229, 85, 224, 129, 2, 211, 178, 246, 95, 34, 95, 106, 232, 201, 154, 93, 127, 57, 75, 176, 198, 108, 116, 172, 58, 15, 157, 45, 207, 165, 60, 224, 60, 204, 93, 71, 12, 117, 202, 40, 123, 53, 154, 84, 220, 106, 153, 29, 151, 243, 44, 77, 50, 20 }, new byte[] { 130, 191, 110, 108, 145, 189, 16, 233, 173, 115, 107, 196, 64, 42, 131, 61, 33, 0, 88, 34, 80, 50, 165, 95, 49, 29, 30, 55, 167, 109, 154, 61, 150, 237, 163, 133, 243, 106, 61, 19, 115, 244, 250, 43, 234, 6, 212, 159, 57, 31, 195, 202, 2, 239, 51, 17, 189, 64, 14, 252, 207, 252, 200, 27, 100, 235, 148, 138, 195, 21, 11, 242, 217, 254, 24, 29, 247, 57, 63, 118, 232, 215, 126, 35, 68, 221, 69, 237, 223, 38, 72, 111, 254, 122, 227, 69, 58, 175, 162, 223, 21, 240, 123, 157, 188, 35, 14, 106, 4, 146, 228, 126, 107, 93, 203, 170, 124, 63, 148, 255, 191, 119, 150, 174, 77, 199, 41, 223 }, "0921231220", 1, "quoctuan" });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Content", "IsIncluded", "TourId" },
                values: new object[,]
                {
                    { 1, "Hotel pickup and drop-off in Hoi An City Center", true, 1 },
                    { 2, "Transportation with air-conditioning", true, 1 },
                    { 3, "Bicycle", true, 1 },
                    { 4, "Entrance fees", true, 1 },
                    { 5, "Foods and Bottled drinking water", true, 1 },
                    { 6, "Tips and gratuities", false, 1 },
                    { 7, "Personal expenses such as: shopping, telephone, beverage, etc.", false, 1 },
                    { 8, "Hotel pickup and drop-off in Hoi An City Center", true, 2 },
                    { 9, "Transportation with air-conditioning", true, 2 },
                    { 10, "Boat", true, 2 },
                    { 11, "Entrance fees", true, 2 },
                    { 12, "Dinner", true, 2 },
                    { 13, "English-speaking tour guide", true, 2 },
                    { 14, "Tips and gratuities", false, 2 },
                    { 15, "Personal expenses such as: shopping, telephone, beverage, etc.", false, 2 }
                });

            migrationBuilder.InsertData(
                table: "Itineraries",
                columns: new[] { "Id", "Content", "Title", "TourId" },
                values: new object[,]
                {
                    { 1, "Discover Hoi An’s countryside and its local foods by bicycle. Local foods in Hoi An are known and enjoyed by the tourists once setting foot here. In Hoi An, these cuisines are very popular and sold everywhere in all streets. Moreover, these cuisines are considered as unique symbols for the culture and introduced to every tourist. We bike through the countryside to a Tra Que Village.", "Part 1", 1 },
                    { 2, "Vegetables from this village are distributed to most of the restaurants in town and specially make the Cao Lau to have a perfect taste. Go back to town and learn how to make special “white rose” dumpling cakes with a local family and taste your products.", "Part 2", 1 },
                    { 3, "Continue riding to Cam Nam to enjoy the Yin and Yang food such as: Banh Dap (“cracked or smashed rice pancake”), Che Bap (“corn and coconut sweet soup”). We then ride to a famous local restaurant for Hoi An specialty - Cao Lau. Cao Lau is a traditional Hoi An specialty composed of local noodles, pork, fresh vegetables and rice paper.", "Part 3", 1 },
                    { 4, "We will ride back to the company at the end of our trip.", "Part 4", 1 },
                    { 5, "We will visit the Japanese Covered Bridge - one of Vietnam's most iconic attraction and a beautiful historical piece of Japanese architecture. Walking in the ancient streets at night, you can perceive the ancient beauty of Hoi An City.", "Part 1", 2 },
                    { 6, "We will visit one of Hoi An Museums and an Ancient House which boast a remarkable architectural style and rest under the glistening lantern lights.", "Part 2", 2 },
                    { 7, "Enjoy Bai Choi performance by the bank of Hoai river. Bai Choi combines music, poetry, acting, painting and literature, has been recognized by UNESCO as an intangible heritage of humanity.", "Part 3", 2 },
                    { 8, "Have dinner at a restaurant with romantic river view then ake a 15-minute boat trip on Hoai River lighting and floating your own candle lit coloured paper lantern on the river with wishes and go shopping at Hoi An night market.", "Part 4", 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Adults", "CancelReason", "Children", "OrderDate", "ProviderId", "State", "TourId", "TouristEmail", "TouristName", "TouristPhone", "UserId" },
                values: new object[,]
                {
                    { 1, 2, null, 1, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Confirmed", 1, "braddinh1952000@gmail.com", "Dinh Cong Tai", "0945501905", 1 },
                    { 2, 2, null, 0, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Confirmed", 2, "braddinh1952000@gmail.com", "Dinh Cong Tai", "0945501905", 1 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "DateCreated", "DateModified", "Rating", "TourId", "UserId" },
                values: new object[,]
                {
                    { 1, "This is a good tour! A lot of interesting experiences.", new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 4f, 1, 1 },
                    { 2, "I love it! Had a really relaxing time.", new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4f, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "TourCategories",
                columns: new[] { "CategoryId", "TourId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 11, 1 },
                    { 11, 2 },
                    { 12, 2 }
                });

            migrationBuilder.InsertData(
                table: "TourImages",
                columns: new[] { "Id", "TourId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "/storage/tour11.jpg" },
                    { 2, 1, "/storage/tour12.jpg" },
                    { 3, 1, "/storage/tour13.jpg" },
                    { 4, 1, "/storage/tour14.jpg" },
                    { 5, 2, "/storage/tour21.jpg" },
                    { 6, 2, "/storage/tour22.jpg" },
                    { 7, 2, "/storage/tour23.jpg" },
                    { 8, 2, "/storage/tour24.jpg" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Itineraries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Itineraries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Itineraries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Itineraries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Itineraries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Itineraries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Itineraries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Itineraries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TourCategories",
                keyColumns: new[] { "CategoryId", "TourId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "TourCategories",
                keyColumns: new[] { "CategoryId", "TourId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "TourCategories",
                keyColumns: new[] { "CategoryId", "TourId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "TourCategories",
                keyColumns: new[] { "CategoryId", "TourId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "TourCategories",
                keyColumns: new[] { "CategoryId", "TourId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "TourCategories",
                keyColumns: new[] { "CategoryId", "TourId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "TourImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TourImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TourImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TourImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TourImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TourImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TourImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TourImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
