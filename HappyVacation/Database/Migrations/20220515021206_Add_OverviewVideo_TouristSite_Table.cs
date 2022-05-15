using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyVacation.Database.Migrations
{
    public partial class Add_OverviewVideo_TouristSite_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OverviewVideoUrl",
                table: "SubTouristSites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Da Nang’s fast reinventing itself as Vietnam’s most hip and modern city and is building an impressive collection of superlatives; one of the best beaches in the world (as voted for by Forbes Magazine); the longest cable car in the world at Ba Na Hill Station; some of the rarest monkeys in the world atop Monkey Mountain; one of the tallest Lady Buddha statues in Vietnam; one of the highest wheels in the world-The Sun Wheel , plus the highest Sky Bar in Vietnam, on the 35th floor of the gleaming Novatel Da Nang Han River Hotel.&The Fire-breathing Dragon.&Vietnam’s third biggest city is home to no less than 8 modern bridges, the most impressive of which is The Dragon Bridge (Cau Rong), who guards the city and breathes fire at weekends. The city’s clean, coconut-tree-fringed, river-side boulevard is lined with ultra-modern hotels, apartments and restaurants.&Beaches, Buddhas, Monkeys and Mountains.&Over the eastside of the city is where the stunning My Khe Beach stretches around 40kms from the foot of Monkey Mountain to the ancient town of Hoi An. To the north is Monkey Mountain, home to some of the rarest monkeys in the world; and Vietnam’s version of Rio’s ‘Christ the Redeemer’, a Lady Buddha statue that stands at nearly 70 meters tall. To the south are the five Marble Mountains and a smattering of luxurious, beachside 5 star hotels. All the way in between is a sublime stretch of coastline, gloriously devoid of tourists, with a wide selection of seafood restaurants located close to the sea.");

            migrationBuilder.UpdateData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 1,
                column: "OverviewVideoUrl",
                value: "/storage/ChuaCau360p.mp4");

            migrationBuilder.UpdateData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Description", "Latitude", "Longitude", "OpenCloseTime", "OverviewVideoUrl", "SiteName", "Ward" },
                values: new object[] { "Tran Phu St", "Covered Bridge, located adjacent to Nguyen Thi Minh Khai Street and Tran Phu Street - Hoi An, also known as Japanese Bridge, is a work built by Japanese merchants who came to Hoi An to trade in the early seventeenth century. More than 400 years ago. Experiencing the ups and downs of time, the building still retains great values of architecture, culture and history, showing the connection between Vietnamese-Japanese communities-- Flowers at the ancient trading port of Hoi An are invaluable assets of generations of Hoi An people and have been officially chosen as the symbol of the city.&The bridge has a roof with a rather unique architecture, in the middle is a rainbow-style passageway, on both sides there is a narrow corridor, used as a place for trade and relaxation. The main side of the pagoda faces the poetic Hoai River. It's called the pagoda, but the residents worship the Bac De god Tran Vo - the god associated with the water treatment function, bringing a peaceful life, favorable rain and wind for the residents. resident community. The pagoda and bridge are made of wood, painted with lipstick and carved with elaborate and harmonious motifs. The two ends of the bridge have two pairs of wooden statues, one end is a dog statue, one end is a monkey statue with many unique interpretations of local residents. In 1719, on a weekly tour to Hoi An, Lord Nguyen Phuc Chu bestowed three words \"Lai Vien Kieu\" with the meaning of welcoming guests from afar, which is still solemnly placed at the entrance of the temple today.&Covered Bridge relic was recognized as a national historical - cultural relic in 1990. Currently, Covered Bridge is an indispensable attraction of any visitor when coming to Hoi An ancient town. The image of the project was also selected to be printed on the VND 20,000 banknote issued by the State Bank of Vietnam in 2006.", 15.87719m, 108.309301m, "8:00 AM - 9:30 PM", "/storage/ChuaCau360.mp4", "Japanese Covered Bridge", "Minh An" });

            migrationBuilder.UpdateData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "OverviewVideoUrl" },
                values: new object[] { "Formed and developed from the sixteenth to seventeenth centuries, the ancient town of Hoi An used to be one of the busiest international trading ports in Southeast Asia. This place is considered as the center of goods exchange of Eurasian traders from China, Japan, Siam, India or the Netherlands, Spain, England, France... organized by form of international fairs from 4 to 6 consecutive months per year according to the monsoon regime. Therefore, Hoi An is considered a land of convergence, interference and acculturation of many East - West cultures.&Hoi An ancient town is famous for its typical architecture of the traditional trading port of Asia, which is preserved almost intact. According to statistics, Hoi An currently preserves 1,360 relics relatively intact, including many types: houses, clan churches, communal houses, pagodas, temples, assembly halls, ancient wells, harbors, markets.&Experiencing many ups and downs of history, the flow of time covers Hoi An with a peaceful and contemplative beauty. Hoi An impresses visitors with mossy yin-yang tiled houses, ancient dusty walls and colorful lanterns. Walking around the old town, visitors will have the opportunity to visit relics dating back hundreds of years, immerse themselves in the festive atmosphere of \"Old Town Night\" with folk games, listen to chants and sing songs. huts, ho drills... or simply, stop at a small roadside shop to enjoy the specialties of Hoi An.&On December 4, 1999, Hoi An Ancient Town was registered by UNESCO in the list of world cultural heritages. Up to now, Hoi An has become a famous destination in the journey of discovering Vietnam and the Central region of domestic and foreign tourists.", "/storage/PhoCo360.mp4" });

            migrationBuilder.UpdateData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 4,
                column: "OverviewVideoUrl",
                value: "/storage/ChuaCau360.mp4");

            migrationBuilder.InsertData(
                table: "SubTouristSites",
                columns: new[] { "Id", "Address", "Description", "District", "HighLights", "Latitude", "Longitude", "OpenCloseTime", "OverviewVideoUrl", "PlaceId", "Province", "SiteName", "Ward" },
                values: new object[] { 5, "", "Thanh Ha Pottery Village is located on the banks of the Thu Bon River, about 3 km west of Hoi An center. This is a stopover for tourists on their travel journey connecting Hoi An Ancient Town to My Son Temples. The village was formed at the end of the 15th century, associated with the migration process from Thanh Hoa, Hai Duong and Nam Dinh localities, bringing with them the traditional pottery craft from the ancestral homeland. Thanks to favorable terrain and rich clay raw materials, the first inhabitants of Thanh Ha village gave birth to pottery making here.&Today, coming to Thanh Ha Pottery Village, visitors can visit a traditional Vietnamese village space that is preserved in its original state in terms of landscape with banyan trees, water wharf, communal courtyard, religious monuments, children tiled alleys… and admire first-hand the talented and skillful hands of the inhabitants of the pottery village who are hard at work creating valuable, characteristic products of the craft village. You will find here gifts that are rustic but attractive.", "Hoi An", "highlights", 15.8768065m, 108.2989103m, "8:00 AM - 6:00 PM", "/storage/ChuaCau360p.mp4", 3, "Quang Nam", "Thanh Ha Pottery Village", "Thanh Ha" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 247, 48, 227, 132, 135, 15, 20, 229, 186, 241, 171, 117, 7, 145, 49, 245, 193, 160, 212, 215, 220, 186, 219, 227, 140, 248, 145, 60, 67, 153, 9, 119, 77, 126, 148, 34, 106, 244, 14, 116, 77, 207, 14, 93, 180, 143, 50, 33, 29, 114, 68, 12, 66, 135, 243, 26, 235, 148, 228, 183, 203, 150, 255, 187 }, new byte[] { 79, 234, 248, 255, 92, 176, 149, 117, 15, 81, 105, 198, 124, 43, 232, 63, 10, 30, 54, 53, 178, 101, 212, 130, 54, 159, 113, 228, 198, 60, 2, 194, 221, 234, 101, 240, 63, 30, 214, 109, 184, 23, 239, 2, 89, 241, 85, 160, 252, 132, 19, 149, 136, 88, 191, 138, 132, 1, 131, 2, 255, 122, 210, 146, 220, 22, 55, 251, 127, 103, 231, 231, 152, 220, 164, 6, 75, 239, 239, 117, 184, 14, 237, 116, 97, 219, 95, 188, 71, 125, 150, 253, 20, 207, 153, 19, 130, 93, 15, 243, 73, 86, 160, 159, 5, 147, 138, 149, 165, 205, 228, 72, 181, 160, 187, 205, 187, 233, 225, 15, 43, 234, 100, 148, 227, 107, 140, 225 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 4, 110, 214, 149, 93, 0, 27, 88, 56, 63, 75, 51, 154, 174, 136, 210, 20, 57, 163, 78, 175, 131, 180, 176, 178, 239, 195, 47, 240, 221, 80, 95, 79, 60, 193, 7, 22, 41, 29, 245, 59, 59, 154, 190, 245, 52, 5, 226, 156, 14, 131, 154, 228, 172, 245, 164, 155, 66, 33, 136, 161, 219, 192, 98 }, new byte[] { 79, 234, 248, 255, 92, 176, 149, 117, 15, 81, 105, 198, 124, 43, 232, 63, 10, 30, 54, 53, 178, 101, 212, 130, 54, 159, 113, 228, 198, 60, 2, 194, 221, 234, 101, 240, 63, 30, 214, 109, 184, 23, 239, 2, 89, 241, 85, 160, 252, 132, 19, 149, 136, 88, 191, 138, 132, 1, 131, 2, 255, 122, 210, 146, 220, 22, 55, 251, 127, 103, 231, 231, 152, 220, 164, 6, 75, 239, 239, 117, 184, 14, 237, 116, 97, 219, 95, 188, 71, 125, 150, 253, 20, 207, 153, 19, 130, 93, 15, 243, 73, 86, 160, 159, 5, 147, 138, 149, 165, 205, 228, 72, 181, 160, 187, 205, 187, 233, 225, 15, 43, 234, 100, 148, 227, 107, 140, 225 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 234, 112, 253, 254, 100, 46, 187, 156, 96, 120, 113, 71, 145, 122, 57, 125, 189, 67, 247, 30, 123, 56, 207, 188, 97, 149, 67, 127, 128, 89, 104, 200, 133, 86, 30, 113, 162, 63, 142, 146, 169, 66, 133, 225, 0, 61, 41, 159, 44, 72, 101, 23, 232, 104, 199, 180, 159, 31, 247, 8, 83, 69, 95, 169 }, new byte[] { 79, 234, 248, 255, 92, 176, 149, 117, 15, 81, 105, 198, 124, 43, 232, 63, 10, 30, 54, 53, 178, 101, 212, 130, 54, 159, 113, 228, 198, 60, 2, 194, 221, 234, 101, 240, 63, 30, 214, 109, 184, 23, 239, 2, 89, 241, 85, 160, 252, 132, 19, 149, 136, 88, 191, 138, 132, 1, 131, 2, 255, 122, 210, 146, 220, 22, 55, 251, 127, 103, 231, 231, 152, 220, 164, 6, 75, 239, 239, 117, 184, 14, 237, 116, 97, 219, 95, 188, 71, 125, 150, 253, 20, 207, 153, 19, 130, 93, 15, 243, 73, 86, 160, 159, 5, 147, 138, 149, 165, 205, 228, 72, 181, 160, 187, 205, 187, 233, 225, 15, 43, 234, 100, 148, 227, 107, 140, 225 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 37, 62, 63, 98, 50, 199, 222, 237, 253, 41, 130, 168, 66, 132, 182, 38, 232, 103, 60, 14, 161, 0, 87, 39, 167, 95, 167, 227, 17, 232, 145, 118, 253, 251, 55, 154, 59, 3, 228, 208, 75, 40, 165, 215, 28, 28, 182, 106, 161, 137, 189, 236, 181, 205, 105, 50, 19, 252, 231, 10, 197, 241, 34, 186 }, new byte[] { 79, 234, 248, 255, 92, 176, 149, 117, 15, 81, 105, 198, 124, 43, 232, 63, 10, 30, 54, 53, 178, 101, 212, 130, 54, 159, 113, 228, 198, 60, 2, 194, 221, 234, 101, 240, 63, 30, 214, 109, 184, 23, 239, 2, 89, 241, 85, 160, 252, 132, 19, 149, 136, 88, 191, 138, 132, 1, 131, 2, 255, 122, 210, 146, 220, 22, 55, 251, 127, 103, 231, 231, 152, 220, 164, 6, 75, 239, 239, 117, 184, 14, 237, 116, 97, 219, 95, 188, 71, 125, 150, 253, 20, 207, 153, 19, 130, 93, 15, 243, 73, 86, 160, 159, 5, 147, 138, 149, 165, 205, 228, 72, 181, 160, 187, 205, 187, 233, 225, 15, 43, 234, 100, 148, 227, 107, 140, 225 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 4, 114, 108, 113, 183, 98, 128, 112, 159, 50, 255, 2, 79, 6, 61, 162, 225, 149, 4, 76, 216, 182, 28, 61, 248, 97, 46, 242, 213, 55, 145, 213, 228, 189, 5, 210, 75, 139, 99, 60, 245, 83, 63, 242, 119, 158, 155, 193, 204, 91, 125, 243, 220, 222, 85, 99, 219, 23, 139, 252, 164, 13, 65, 91 }, new byte[] { 79, 234, 248, 255, 92, 176, 149, 117, 15, 81, 105, 198, 124, 43, 232, 63, 10, 30, 54, 53, 178, 101, 212, 130, 54, 159, 113, 228, 198, 60, 2, 194, 221, 234, 101, 240, 63, 30, 214, 109, 184, 23, 239, 2, 89, 241, 85, 160, 252, 132, 19, 149, 136, 88, 191, 138, 132, 1, 131, 2, 255, 122, 210, 146, 220, 22, 55, 251, 127, 103, 231, 231, 152, 220, 164, 6, 75, 239, 239, 117, 184, 14, 237, 116, 97, 219, 95, 188, 71, 125, 150, 253, 20, 207, 153, 19, 130, 93, 15, 243, 73, 86, 160, 159, 5, 147, 138, 149, 165, 205, 228, 72, 181, 160, 187, 205, 187, 233, 225, 15, 43, 234, 100, 148, 227, 107, 140, 225 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 57, 176, 132, 104, 229, 45, 218, 116, 60, 102, 215, 210, 218, 94, 189, 41, 72, 217, 39, 80, 125, 73, 58, 42, 115, 179, 151, 92, 206, 128, 65, 132, 180, 145, 195, 198, 30, 47, 244, 241, 189, 26, 75, 167, 67, 135, 170, 172, 13, 8, 53, 214, 187, 181, 62, 46, 102, 112, 7, 1, 178, 18, 123, 52 }, new byte[] { 79, 234, 248, 255, 92, 176, 149, 117, 15, 81, 105, 198, 124, 43, 232, 63, 10, 30, 54, 53, 178, 101, 212, 130, 54, 159, 113, 228, 198, 60, 2, 194, 221, 234, 101, 240, 63, 30, 214, 109, 184, 23, 239, 2, 89, 241, 85, 160, 252, 132, 19, 149, 136, 88, 191, 138, 132, 1, 131, 2, 255, 122, 210, 146, 220, 22, 55, 251, 127, 103, 231, 231, 152, 220, 164, 6, 75, 239, 239, 117, 184, 14, 237, 116, 97, 219, 95, 188, 71, 125, 150, 253, 20, 207, 153, 19, 130, 93, 15, 243, 73, 86, 160, 159, 5, 147, 138, 149, 165, 205, 228, 72, 181, 160, 187, 205, 187, 233, 225, 15, 43, 234, 100, 148, 227, 107, 140, 225 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "OverviewVideoUrl",
                table: "SubTouristSites");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Description", "Latitude", "Longitude", "OpenCloseTime", "SiteName", "Ward" },
                values: new object[] { "", "Thanh Ha Pottery Village is located on the banks of the Thu Bon River, about 3 km west of Hoi An center. This is a stopover for tourists on their travel journey connecting Hoi An Ancient Town to My Son Temples. The village was formed at the end of the 15th century, associated with the migration process from Thanh Hoa, Hai Duong and Nam Dinh localities, bringing with them the traditional pottery craft from the ancestral homeland. Thanks to favorable terrain and rich clay raw materials, the first inhabitants of Thanh Ha village gave birth to pottery making here.&Today, coming to Thanh Ha Pottery Village, visitors can visit a traditional Vietnamese village space that is preserved in its original state in terms of landscape with banyan trees, water wharf, communal courtyard, religious monuments, children tiled alleys… and admire first-hand the talented and skillful hands of the inhabitants of the pottery village who are hard at work creating valuable, characteristic products of the craft village. You will find here gifts that are rustic but attractive.", 15.8768065m, 108.2989103m, "8:00 AM - 6:00 PM", "Thanh Ha Pottery Village", "Thanh Ha" });

            migrationBuilder.UpdateData(
                table: "SubTouristSites",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Formed and developed from the sixteenth to seventeenth centuries, the ancient town of Hoi An used to be one of the busiest international trading ports in Southeast Asia. This place is considered as the center of goods exchange of Eurasian traders from China, Japan, Siam, India or the Netherlands, Spain, England, France... organized by form of international fairs from 4 to 6 consecutive months per year according to the monsoon regime. Therefore, Hoi An is considered a land of convergence, interference and acculturation of many East - West cultures.&Experiencing many ups and downs of history, the flow of time covers Hoi An with a peaceful and contemplative beauty. Hoi An impresses visitors with mossy yin-yang tiled houses, ancient dusty walls and colorful lanterns. Walking around the old town, visitors will have the opportunity to visit relics dating back hundreds of years, immerse themselves in the festive atmosphere of \"Old Town Night\" with folk games, listen to chants and sing songs. huts, ho drills... or simply, stop at a small roadside shop to enjoy the specialties of Hoi An.&");

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
        }
    }
}
