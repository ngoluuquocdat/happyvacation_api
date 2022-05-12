using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class SeedData_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlaceImages",
                columns: new[] { "Id", "PlaceId", "Url" },
                values: new object[,]
                {
                    { 1, 3, "/storage/hoian.jpg" },
                    { 2, 3, "/storage/hoian2.jpg" },
                    { 3, 3, "/storage/hoian3.jpg" },
                    { 4, 3, "/storage/hoian4.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Possibly the most beautiful town in Vietnam and definitely the most atmospheric heritage town, Hoi An (which means ‘peaceful place’ in Vietnamese) has the perfect combination of old-world charm and modern-day comforts and luxuries. This historical town is gloriously devoid of high-rises and ugly concrete buildings thanks to its Unesco World Heritage Site status. Chinese merchant shop fronts dating as far back as the 15th Century encase shops, restaurants, art galleries, museums and especially tailors, ensuring Hoi An has something to suit all tastes.&What really makes Hoi An live up to its ‘peaceful place’ name is the blissful ban on motorbikes and scooters in the old town during certain parts of the day and most of the evening.&The Venice of Vietnam.&One of the biggest factors in creating the rich cultural history that brings such a special ambience to Hoi An, is the river that it’s built around. The ‘Thu Bon’ river has been responsible for bringing in foreign traders and settlers from far-flung places for hundreds of years and brings a beautiful, romantic, ‘Venice of Vietnam’ quality to the town.");

            migrationBuilder.InsertData(
                table: "SubTouristSites",
                columns: new[] { "Id", "Address", "Description", "District", "HighLights", "Latitude", "Longitude", "OpenCloseTime", "PlaceId", "Province", "SiteName", "Ward" },
                values: new object[,]
                {
                    { 1, "", "Tra Que Vegetable Village is a land formed from the 17th to 18th centuries, located in Tra Que village, Cam Ha commune, about 2.5km north of the center of Hoi An ancient town.The village is famous for many aromatic products with strong flavors grown by traditional intensive farming methods, fertilized with seaweed from Tra Que lagoon, so it has turned the green vegetables here green and fragrant.&Coming to Tra Que vegetable village, visitors will enjoy the rustic and peaceful natural picture of a vast vegetable-growing area, participate in farmer experience tours with farm work: hoeing. soil, fertilizing weeds, watering dandruff, manually processing and enjoying delicious rustic dishes made from green vegetables.", "Hoi An", "highlights", 15.9024202m, 108.3375933m, "8:00 AM - 6:00 PM", 3, "Quang Nam", "Tra Que Vegetable Village", "Cam Ha" },
                    { 2, "", "Thanh Ha Pottery Village is located on the banks of the Thu Bon River, about 3 km west of Hoi An center. This is a stopover for tourists on their travel journey connecting Hoi An Ancient Town to My Son Temples. The village was formed at the end of the 15th century, associated with the migration process from Thanh Hoa, Hai Duong and Nam Dinh localities, bringing with them the traditional pottery craft from the ancestral homeland. Thanks to favorable terrain and rich clay raw materials, the first inhabitants of Thanh Ha village gave birth to pottery making here.&Today, coming to Thanh Ha Pottery Village, visitors can visit a traditional Vietnamese village space that is preserved in its original state in terms of landscape with banyan trees, water wharf, communal courtyard, religious monuments, children tiled alleys… and admire first-hand the talented and skillful hands of the inhabitants of the pottery village who are hard at work creating valuable, characteristic products of the craft village. You will find here gifts that are rustic but attractive.", "Hoi An", "highlights", 15.8768065m, 108.2989103m, "8:00 AM - 6:00 PM", 3, "Quang Nam", "Thanh Ha Pottery Village", "Thanh Ha" },
                    { 3, "", "Formed and developed from the sixteenth to seventeenth centuries, the ancient town of Hoi An used to be one of the busiest international trading ports in Southeast Asia. This place is considered as the center of goods exchange of Eurasian traders from China, Japan, Siam, India or the Netherlands, Spain, England, France... organized by form of international fairs from 4 to 6 consecutive months per year according to the monsoon regime. Therefore, Hoi An is considered a land of convergence, interference and acculturation of many East - West cultures.&Experiencing many ups and downs of history, the flow of time covers Hoi An with a peaceful and contemplative beauty. Hoi An impresses visitors with mossy yin-yang tiled houses, ancient dusty walls and colorful lanterns. Walking around the old town, visitors will have the opportunity to visit relics dating back hundreds of years, immerse themselves in the festive atmosphere of \"Old Town Night\" with folk games, listen to chants and sing songs. huts, ho drills... or simply, stop at a small roadside shop to enjoy the specialties of Hoi An.&", "Hoi An", "highlights", 15.878223m, 108.3282151m, "8:00 AM - 10:00 PM", 3, "Quang Nam", "Hoi An Ancient Town", "Minh An" },
                    { 4, "10B Tran Hung Dao", "Hoi An Museum of History - Culture is a large-scale work, located at 10B Tran Hung Dao, Hoi An city, where displays more than 800 original artifacts and valuable documents in ceramics, porcelain, bronze. iron, paper, wood...reflecting the development stages of the urban - commercial port of Hoi An from the period of Sa Huynh culture (from the 2nd century AD) to the period of Champa culture (from the 1st century AD) II to 15th century) to the period of Dai Viet and Dai Nam cultures (from the 15th to the 19th century), as well as the history of the city's people's revolutionary struggle (since the French colonialists invaded to invade Vietnam). 1858 to the great victory in the spring of 1975).&Hoi An Museum of History - Culture will help visitors get an overview of the historical process as well as the cultural thickness of the land of Hoi An. The museum is currently open every day of the week, and is closed on the 25th of every month to carry out professional work.", "Hoi An", "highlights", 15.88036m, 108.32951m, "8:00 AM - 6:00 PM", 3, "Quang Nam", "Hoi An Museum of History and Culture", "Minh An" }
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

            migrationBuilder.InsertData(
                table: "TouristSiteImages",
                columns: new[] { "Id", "SubTouristSiteId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "/storage/traque1.jpg" },
                    { 2, 1, "/storage/traque2.jpg" },
                    { 3, 1, "/storage/traque3.jpg" },
                    { 4, 1, "/storage/traque4.jpg" },
                    { 5, 2, "/storage/thanhha1.jpg" },
                    { 6, 2, "/storage/thanhha2.jpg" },
                    { 7, 2, "/storage/thanhha3.jpg" },
                    { 8, 2, "/storage/thanhha4.jpg" },
                    { 9, 3, "/storage/phocoha1.jpg" },
                    { 10, 3, "/storage/phocoha2.jpg" },
                    { 11, 3, "/storage/phocoha3.jpg" },
                    { 12, 3, "/storage/phocoha4.jpg" },
                    { 13, 4, "/storage/baotangha1.jpg" },
                    { 14, 4, "/storage/baotangha2.jpg" },
                    { 15, 4, "/storage/baotangha3.jpg" },
                    { 16, 4, "/storage/baotangha4.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlaceImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaceImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlaceImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlaceImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TouristSiteImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: null);

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
        }
    }
}
