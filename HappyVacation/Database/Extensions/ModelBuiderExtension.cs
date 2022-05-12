﻿using HappyVacation.Database.Entities;
using HappyVacation.Database.Entities.HotelBooking;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HappyVacation.Database.Extensions
{
    public static class ModelBuiderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // data seeding for Providers
            modelBuilder.Entity<Provider>().HasData(
                new Provider
                {
                    Id = 1,
                    ProviderName = "Hoi An Express",
                    ProviderPhone = "0905123456",
                    ProviderEmail = "info@hoianexpress.com.vn",
                    Address = "32 Tien Giang St, Tan Binh District, Ho Chi Minh City, Viet Nam",
                    DateCreated = new DateTime(2022, 03, 28),
                    Description = "Established in 2002, Hoi An Express is a company specializing in organizing professional tours for foreign visitors to Vietnam to visit tours, conferences, events combined with team building.",
                    AvatarUrl = "/storage/hoianexpresslogo.jpg",
                    IsEnabled = true
                }
            );
            // data seeding for Users
            using var hmac = new HMACSHA512();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username =  "admin",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Admin123!")),
                    PasswordSalt = hmac.Key,
                    FirstName = "Quoc Dat",
                    LastName =  "Ngo Luu",
                    Phone = "0905553859",
                    Email = "ngoluuquocdat@gmail.com",
                    AvatarUrl = null,
                    ProviderId = null,
                    HotelId = null,
                    IsEnabled = true
                },
                new User
                {
                    Id = 2,
                    Username = "quoctuan",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Quoctuan123!")),
                    PasswordSalt = hmac.Key,
                    FirstName = "Quoc Tuan",
                    LastName = "Dang",
                    Phone = "0921231220",
                    Email = "tuandang29042000@gmail.com",
                    ProviderId = 1,
                    HotelId = null,
                    AvatarUrl = "/storage/tuan.jpg",
                    IsEnabled = true
                },
                new User
                {
                    Id = 3,
                    Username = "congtai",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Congtai123!")),
                    PasswordSalt = hmac.Key,
                    FirstName = "Cong Tai",
                    LastName = "Dinh",
                    Phone = "0945501905",
                    Email = "braddinh1952000@gmail.com",
                    ProviderId = null,
                    HotelId = null,
                    AvatarUrl = "/storage/tai.jpg",
                    IsEnabled = true
                },
                new User
                {
                    Id = 4,
                    Username = "quocdat",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Quocdat123!")),
                    PasswordSalt = hmac.Key,
                    FirstName = "Quoc Dat",
                    LastName = "Ngo Luu",
                    Phone = "0905553859",
                    Email = "ngoluuquocdat@gmail.com",
                    ProviderId = null,
                    HotelId = null,
                    AvatarUrl = "/storage/dat.jpg",
                    IsEnabled = true
                },
                new User
                {
                    Id = 8,
                    Username = "thaiduy",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Thaiduy123!")),
                    PasswordSalt = hmac.Key,
                    FirstName = "Thai Duy",
                    LastName = "Lam",
                    Phone = "0764132745",
                    Email = "duylam2906@gmail.com",
                    ProviderId = null,
                    HotelId = 1,
                    AvatarUrl = "/storage/duy.jpg",
                    IsEnabled = true
                },
                new User
                {
                    Id = 9,
                    Username = "xuantoan",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Xuantoan123!")),
                    PasswordSalt = hmac.Key,
                    FirstName = "Xuan Toan",
                    LastName = "Mai",
                    Phone = "0783803087",
                    Email = "xuantoan2401@gmail.com",
                    ProviderId = null,
                    HotelId = 2,
                    AvatarUrl = "/storage/toan.jpg",
                    IsEnabled = true
                }
            );
            // data seeding for Roles
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "Admin"
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Provider"
                },
                new Role
                {
                    Id = 3,
                    RoleName = "Tourist"
                },
                new Role
                {
                    Id = 4,
                    RoleName = "Hotel_Owner"
                }
            );
            // data seeding for UserRoles
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserId = 1, RoleId = 1},
                new UserRole { UserId = 1, RoleId = 2 },
                new UserRole { UserId = 1, RoleId = 3 },
                new UserRole { UserId = 2, RoleId = 2 },
                new UserRole { UserId = 2, RoleId = 3 },
                new UserRole { UserId = 3, RoleId = 3 },
                new UserRole { UserId = 4, RoleId = 3 },
                new UserRole { UserId = 8, RoleId = 3 },
                new UserRole { UserId = 8, RoleId = 4 },
                new UserRole { UserId = 9, RoleId = 3 },
                new UserRole { UserId = 9, RoleId = 4 }
            );
            // data seeding for Places
            modelBuilder.Entity<Place>().HasData(
                new Place { 
                    Id = 1, 
                    PlaceName = "Da Nang", 
                    ThumbnailUrl = "/storage/danang.jpg",
                    Latitude = 16.047079M,
                    Longitude = 108.206230M,
                    OverviewVideoUrl = "/storage/DaNang360.mp4"
                },
                new Place { 
                    Id = 2, 
                    PlaceName = "Hue", 
                    ThumbnailUrl = "/storage/hue.jpg",
                    Latitude = 16.463713M,
                    Longitude = 107.590866M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 3, 
                    PlaceName = "Hoi An", 
                    ThumbnailUrl = "/storage/hoian.jpg",
                    Description = "Possibly the most beautiful town in Vietnam and definitely the most atmospheric heritage town, Hoi An (which means ‘peaceful place’ in Vietnamese) has the perfect combination of old-world charm and modern-day comforts and luxuries. This historical town is gloriously devoid of high-rises and ugly concrete buildings thanks to its Unesco World Heritage Site status. Chinese merchant shop fronts dating as far back as the 15th Century encase shops, restaurants, art galleries, museums and especially tailors, ensuring Hoi An has something to suit all tastes.&" +
                    "What really makes Hoi An live up to its ‘peaceful place’ name is the blissful ban on motorbikes and scooters in the old town during certain parts of the day and most of the evening.&" +
                    "The Venice of Vietnam.&" + "One of the biggest factors in creating the rich cultural history that brings such a special ambience to Hoi An, is the river that it’s built around. The ‘Thu Bon’ river has been responsible for bringing in foreign traders and settlers from far-flung places for hundreds of years and brings a beautiful, romantic, ‘Venice of Vietnam’ quality to the town.",
                    Latitude = 15.87944M,
                    Longitude = 108.335M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 4, 
                    PlaceName = "Ha Long", 
                    ThumbnailUrl = "/storage/halong.jpg",
                    Latitude = 20.959902M,
                    Longitude = 107.042542M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 5, 
                    PlaceName = "Ha Noi", 
                    ThumbnailUrl = "/storage/hanoi.jpg",
                    Latitude = 21.028511M,
                    Longitude = 105.804817M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 6, 
                    PlaceName = "Ho Chi Minh", 
                    ThumbnailUrl = "/storage/hochiminh.jpg",
                    Latitude = 10.762622M,
                    Longitude = 106.660172M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 7, 
                    PlaceName = "Da Lat", 
                    ThumbnailUrl = "/storage/dalat.jpg",
                    Latitude = 11.940419M,
                    Longitude = 108.458313M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 8, 
                    PlaceName = "Nha Trang", 
                    ThumbnailUrl = "/storage/nhatrang.jpg",
                    Latitude = 12.24507M,
                    Longitude = 109.19432M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 9, 
                    PlaceName = "Phu Quoc", 
                    ThumbnailUrl = "/storage/phuquoc.jpg",
                    Latitude = 10.289879M,
                    Longitude = 103.98402M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 10, 
                    PlaceName = "Quy Nhon", 
                    ThumbnailUrl = "/storage/quynhon.jpg",
                    Latitude = 13.759660M,
                    Longitude = 109.206123M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 11, 
                    PlaceName = "Sa Pa", 
                    ThumbnailUrl = "/storage/sapa.jpg",
                    Latitude = 22.356464M,
                    Longitude = 103.873802M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 12, 
                    PlaceName = "Vung Tau", 
                    ThumbnailUrl = "/storage/vungtau.jpg",
                    Latitude = 10.541740M,
                    Longitude = 107.242998M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 13, 
                    PlaceName = "Mui Ne", 
                    ThumbnailUrl = "/storage/muine.jpg",
                    Latitude = 10.933211M,
                    Longitude = 108.287184M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 14, 
                    PlaceName = "Con Dao", 
                    ThumbnailUrl = "/storage/condao.jpg",
                    Latitude = 8.68327M,
                    Longitude = 106.606M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                },
                new Place { 
                    Id = 15, 
                    PlaceName = "Trang An", 
                    ThumbnailUrl = "/storage/trangan.jpg",
                    Latitude = 20.256667M,
                    Longitude = 105.896389M,
                    OverviewVideoUrl = "/storage/HoiAn360.mp4"
                }
            );
            // data seeding for Place Images
            modelBuilder.Entity<PlaceImage>().HasData(
                new PlaceImage { Id = 1, Url = "/storage/hoian.jpg", PlaceId = 3 },
                new PlaceImage { Id = 2, Url = "/storage/hoian2.jpg", PlaceId = 3 },
                new PlaceImage { Id = 3, Url = "/storage/hoian3.jpg", PlaceId = 3 },
                new PlaceImage { Id = 4, Url = "/storage/hoian4.jpg", PlaceId = 3 }
            );
            // data seeding for Tourist Sites
            modelBuilder.Entity<SubTouristSite>().HasData(
                new SubTouristSite 
                { 
                    Id = 1,
                    PlaceId = 3,
                    SiteName = "Tra Que Vegetable Village",
                    Description = "Tra Que Vegetable Village is a land formed from the 17th to 18th centuries, located in Tra Que village, Cam Ha commune, about 2.5km north of the center of Hoi An ancient town." +
                    "The village is famous for many aromatic products with strong flavors grown by traditional intensive farming methods, fertilized with seaweed from Tra Que lagoon, so it has turned the green vegetables here green and fragrant.&" +
                    "Coming to Tra Que vegetable village, visitors will enjoy the rustic and peaceful natural picture of a vast vegetable-growing area, participate in farmer experience tours with farm work: hoeing. soil, fertilizing weeds, watering dandruff, manually processing and enjoying delicious rustic dishes made from green vegetables.",
                    HighLights = "highlights",
                    Province = "Quang Nam",
                    District = "Hoi An",
                    Ward = "Cam Ha",
                    Address = "",
                    OpenCloseTime = "8:00 AM - 6:00 PM",
                    Latitude = 15.9024202M,
                    Longitude = 108.3375933M
                },
                new SubTouristSite
                {
                    Id = 2,
                    PlaceId = 3,
                    SiteName = "Thanh Ha Pottery Village",
                    Description = "Thanh Ha Pottery Village is located on the banks of the Thu Bon River, about 3 km west of Hoi An center. This is a stopover for tourists on their travel journey connecting Hoi An Ancient Town to My Son Temples. The village was formed at the end of the 15th century, associated with the migration process from Thanh Hoa, Hai Duong and Nam Dinh localities, bringing with them the traditional pottery craft from the ancestral homeland. Thanks to favorable terrain and rich clay raw materials, the first inhabitants of Thanh Ha village gave birth to pottery making here.&" +
                    "Today, coming to Thanh Ha Pottery Village, visitors can visit a traditional Vietnamese village space that is preserved in its original state in terms of landscape with banyan trees, water wharf, communal courtyard, religious monuments, children tiled alleys… and admire first-hand the talented and skillful hands of the inhabitants of the pottery village who are hard at work creating valuable, characteristic products of the craft village. You will find here gifts that are rustic but attractive.",
                    HighLights = "highlights",
                    Province = "Quang Nam",
                    District = "Hoi An",
                    Ward = "Thanh Ha",
                    Address = "",
                    OpenCloseTime = "8:00 AM - 6:00 PM",
                    Latitude = 15.8768065M,
                    Longitude = 108.2989103M
                },
                new SubTouristSite
                {
                    Id = 3,
                    PlaceId = 3,
                    SiteName = "Hoi An Ancient Town",
                    Description = "Formed and developed from the sixteenth to seventeenth centuries, the ancient town of Hoi An used to be one of the busiest international trading ports in Southeast Asia. This place is considered as the center of goods exchange of Eurasian traders from China, Japan, Siam, India or the Netherlands, Spain, England, France... organized by form of international fairs from 4 to 6 consecutive months per year according to the monsoon regime. Therefore, Hoi An is considered a land of convergence, interference and acculturation of many East - West cultures.&" +
                    "Experiencing many ups and downs of history, the flow of time covers Hoi An with a peaceful and contemplative beauty. Hoi An impresses visitors with mossy yin-yang tiled houses, ancient dusty walls and colorful lanterns. Walking around the old town, visitors will have the opportunity to visit relics dating back hundreds of years, immerse themselves in the festive atmosphere of \"Old Town Night\" with folk games, listen to chants and sing songs. huts, ho drills... or simply, stop at a small roadside shop to enjoy the specialties of Hoi An.&",
                    HighLights = "highlights",
                    Province = "Quang Nam",
                    District = "Hoi An",
                    Ward = "Minh An",
                    Address = "",
                    OpenCloseTime = "8:00 AM - 10:00 PM",
                    Latitude = 15.878223M,
                    Longitude = 108.3282151M
                },
                new SubTouristSite
                {
                    Id = 4,
                    PlaceId = 3,
                    SiteName = "Hoi An Museum of History and Culture",
                    Description = "Hoi An Museum of History - Culture is a large-scale work, located at 10B Tran Hung Dao, Hoi An city, where displays more than 800 original artifacts and valuable documents in ceramics, porcelain, bronze. iron, paper, wood...reflecting the development stages of the urban - commercial port of Hoi An from the period of Sa Huynh culture (from the 2nd century AD) to the period of Champa culture (from the 1st century AD) II to 15th century) to the period of Dai Viet and Dai Nam cultures (from the 15th to the 19th century), as well as the history of the city's people's revolutionary struggle (since the French colonialists invaded to invade Vietnam). 1858 to the great victory in the spring of 1975).&" +
                    "Hoi An Museum of History - Culture will help visitors get an overview of the historical process as well as the cultural thickness of the land of Hoi An. The museum is currently open every day of the week, and is closed on the 25th of every month to carry out professional work.",
                    HighLights = "highlights",
                    Province = "Quang Nam",
                    District = "Hoi An",
                    Ward = "Minh An",
                    Address = "10B Tran Hung Dao",
                    OpenCloseTime = "8:00 AM - 6:00 PM",
                    Latitude = 15.88036M,
                    Longitude = 108.32951M
                }
            );
            // data seeding for Tourist Sites Images
            modelBuilder.Entity<SubTouristSiteImage>().HasData(
                new SubTouristSiteImage { Id = 1, Url = "/storage/traque1.jpg", SubTouristSiteId = 1 },
                new SubTouristSiteImage { Id = 2, Url = "/storage/traque2.jpg", SubTouristSiteId = 1 },
                new SubTouristSiteImage { Id = 3, Url = "/storage/traque3.jpg", SubTouristSiteId = 1 },
                new SubTouristSiteImage { Id = 4, Url = "/storage/traque4.jpg", SubTouristSiteId = 1 },
                new SubTouristSiteImage { Id = 5, Url = "/storage/thanhha1.jpg", SubTouristSiteId = 2 },
                new SubTouristSiteImage { Id = 6, Url = "/storage/thanhha2.jpg", SubTouristSiteId = 2 },
                new SubTouristSiteImage { Id = 7, Url = "/storage/thanhha3.jpg", SubTouristSiteId = 2 },
                new SubTouristSiteImage { Id = 8, Url = "/storage/thanhha4.jpg", SubTouristSiteId = 2 },
                new SubTouristSiteImage { Id = 9, Url = "/storage/phocoha1.jpg", SubTouristSiteId = 3 },
                new SubTouristSiteImage { Id = 10, Url = "/storage/phocoha2.jpg", SubTouristSiteId = 3 },
                new SubTouristSiteImage { Id = 11, Url = "/storage/phocoha3.jpg", SubTouristSiteId = 3 },
                new SubTouristSiteImage { Id = 12, Url = "/storage/phocoha4.jpg", SubTouristSiteId = 3 },
                new SubTouristSiteImage { Id = 13, Url = "/storage/baotangha1.jpg", SubTouristSiteId = 4 },
                new SubTouristSiteImage { Id = 14, Url = "/storage/baotangha2.jpg", SubTouristSiteId = 4 },
                new SubTouristSiteImage { Id = 15, Url = "/storage/baotangha3.jpg", SubTouristSiteId = 4 },
                new SubTouristSiteImage { Id = 16, Url = "/storage/baotangha4.jpg", SubTouristSiteId = 4 }
            );
            // data seeding for Tours
            modelBuilder.Entity<Tour>().HasData(
                new Tour
                {
                    Id = 1,
                    TourName = "HALF-DAY FOODIE TOUR BY BICYCLE & VISIT TRA QUE VEGETABLE VILLAGE",
                    Overview = "Take a journey through Hoi An’s culinary history; head out to the beautiful countryside by bicycle to experience some traditional local food favorites, including the most famous of Hoi An specialties; Cao Lau. Try the traditional Hoi An specialty, Cao Lau; " +
                                "intoxicating pork noodle broth, featuring sticky rice noodles that must be soaked in water from the oldest well in Hoi An, Ba Le Well.",
                    Duration = 0.5F,
                    GroupSize = 15,
                    MinAdults = 2,
                    PricePerAdult = 89,
                    PricePerChild = 30,
                    ProviderId = 1,
                    StartTime = "8:00 AM",
                    StartPoint = "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province",
                    EndPoint = "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province",
                    IsPrivate = false,
                    ViewCount = 10,
                    IsAvailable = true,
                },
                new Tour
                {
                    Id = 2,
                    TourName = "Private Tour: HOI AN MYSTERIOUS NIGHT TOUR WITH DINNER FROM HOI AN",
                    Overview = "Have a memorable end to your day in Hoi An with a tour of the ancient town after the sun goes down. " +
                                "See the centuries-old houses and monuments illuminated by local lanterns. Visit a traditional restaurant for dinner",
                    Duration = 0.125F,
                    GroupSize = 15,
                    MinAdults = 1,
                    PricePerAdult = 180,
                    PricePerChild = 50,
                    ProviderId = 1,
                    StartTime = "5:00 PM",
                    StartPoint = "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province",
                    EndPoint = "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province",
                    IsPrivate = true,
                    ViewCount = 5,
                    IsAvailable = true,
                }
            );
            // data seeding for TourPlaces
            modelBuilder.Entity<TourPlace>().HasData(
                new TourPlace { TourId = 1, PlaceId = 3 },
                new TourPlace { TourId = 2, PlaceId = 3 }
            );
            // data seeding for Itineraries
            modelBuilder.Entity<Itinerary>().HasData(
                new Itinerary
                {
                    Id = 1,
                    Title = "Part 1",
                    Content = "Discover Hoi An’s countryside and its local foods by bicycle. Local foods in Hoi An are known and enjoyed by the tourists once setting foot here. " +
                                "In Hoi An, these cuisines are very popular and sold everywhere in all streets. Moreover, these cuisines are considered as unique symbols for the culture and introduced to every tourist. We bike through the countryside to a Tra Que Village.",
                    TourId = 1
                },
                new Itinerary
                {
                    Id = 2,
                    Title = "Part 2",
                    Content = "Vegetables from this village are distributed to most of the restaurants in town and specially make the Cao Lau to have a perfect taste. Go back to town and learn how to make special “white rose” dumpling cakes with a local family and taste your products.",
                    TourId = 1
                },
                new Itinerary
                {
                    Id = 3,
                    Title = "Part 3",
                    Content = "Continue riding to Cam Nam to enjoy the Yin and Yang food such as: Banh Dap (“cracked or smashed rice pancake”), Che Bap (“corn and coconut sweet soup”). " +
                                "We then ride to a famous local restaurant for Hoi An specialty - Cao Lau. Cao Lau is a traditional Hoi An specialty composed of local noodles, pork, fresh vegetables and rice paper.",
                    TourId = 1
                },
                new Itinerary
                {
                    Id = 4,
                    Title = "Part 4",
                    Content = "We will ride back to the company at the end of our trip.",
                    TourId = 1
                },
                new Itinerary
                {
                    Id = 5,
                    Title = "Part 1",
                    Content = "We will visit the Japanese Covered Bridge - one of Vietnam's most iconic attraction and a beautiful historical piece of Japanese architecture. Walking in the ancient streets at night, you can perceive the ancient beauty of Hoi An City.",
                    TourId = 2
                },
                new Itinerary
                {
                    Id = 6,
                    Title = "Part 2",
                    Content = "We will visit one of Hoi An Museums and an Ancient House which boast a remarkable architectural style and rest under the glistening lantern lights.",
                    TourId = 2
                },
                new Itinerary
                {
                    Id = 7,
                    Title = "Part 3",
                    Content = "Enjoy Bai Choi performance by the bank of Hoai river. Bai Choi combines music, poetry, acting, painting and literature, has been recognized by UNESCO as an intangible heritage of humanity.",
                    TourId = 2
                },
                new Itinerary
                {
                    Id = 8,
                    Title = "Part 4",
                    Content = "Have dinner at a restaurant with romantic river view then ake a 15-minute boat trip on Hoai River lighting and floating your own candle lit coloured paper lantern on the river with wishes and go shopping at Hoi An night market.",
                    TourId = 2
                }
            );
            // data seeding for Expenses
            modelBuilder.Entity<Expense>().HasData(
                new Expense { Id = 1, Content = "Hotel pickup and drop-off in Hoi An City Center", IsIncluded = true, TourId = 1 },
                new Expense { Id = 2, Content = "Transportation with air-conditioning", IsIncluded = true, TourId = 1 },
                new Expense { Id = 3, Content = "Bicycle", IsIncluded = true, TourId = 1 },
                new Expense { Id = 4, Content = "Entrance fees", IsIncluded = true, TourId = 1 },
                new Expense { Id = 5, Content = "Foods and Bottled drinking water", IsIncluded = true, TourId = 1 },
                new Expense { Id = 6, Content = "Tips and gratuities", IsIncluded = false, TourId = 1 },
                new Expense { Id = 7, Content = "Personal expenses such as: shopping, telephone, beverage, etc.", IsIncluded = false, TourId = 1 },

                new Expense { Id = 8, Content = "Hotel pickup and drop-off in Hoi An City Center", IsIncluded = true, TourId = 2 },
                new Expense { Id = 9, Content = "Transportation with air-conditioning", IsIncluded = true, TourId = 2 },
                new Expense { Id = 10, Content = "Boat", IsIncluded = true, TourId = 2 },
                new Expense { Id = 11, Content = "Entrance fees", IsIncluded = true, TourId = 2 },
                new Expense { Id = 12, Content = "Dinner", IsIncluded = true, TourId = 2 },
                new Expense { Id = 13, Content = "English-speaking tour guide", IsIncluded = true, TourId = 2 },
                new Expense { Id = 14, Content = "Tips and gratuities", IsIncluded = false, TourId = 2 },
                new Expense { Id = 15, Content = "Personal expenses such as: shopping, telephone, beverage, etc.", IsIncluded = false, TourId = 2 }
            );
            // data seeding for Tour images
            modelBuilder.Entity<TourImage>().HasData(
               new TourImage { Id = 1, Url = "/storage/tour11.jpg", TourId = 1},
               new TourImage { Id = 2, Url = "/storage/tour12.jpg", TourId = 1 },
               new TourImage { Id = 3, Url = "/storage/tour13.jpg", TourId = 1 },
               new TourImage { Id = 4, Url = "/storage/tour14.jpg", TourId = 1 },

               new TourImage { Id = 5, Url = "/storage/tour21.jpg", TourId = 2 },
               new TourImage { Id = 6, Url = "/storage/tour22.jpg", TourId = 2 },
               new TourImage { Id = 7, Url = "/storage/tour23.jpg", TourId = 2 },
               new TourImage { Id = 8, Url = "/storage/tour24.jpg", TourId = 2 }
            );
            // data seeding for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "adventure tour" },
                new Category { Id = 2, CategoryName = "artistic tour" },
                new Category { Id = 3, CategoryName = "beach tour" },
                new Category { Id = 4, CategoryName = "biking tour" },
                new Category { Id = 5, CategoryName = "boating tour" },
                new Category { Id = 6, CategoryName = "camping" },
                new Category { Id = 7, CategoryName = "classic tour" },
                new Category { Id = 8, CategoryName = "cooking tour" },
                new Category { Id = 9, CategoryName = "craft tour" },
                new Category { Id = 10, CategoryName = "cruises tour" },
                new Category { Id = 11, CategoryName = "culinary tour" },
                new Category { Id = 12, CategoryName = "cultural tour" },
                new Category { Id = 13, CategoryName = "discovery tour" },
                new Category { Id = 14, CategoryName = "fishing tour" },
                new Category { Id = 15, CategoryName = "heritage tour" },
                new Category { Id = 16, CategoryName = "historical tour" },
                new Category { Id = 17, CategoryName = "homestay tour" },
                new Category { Id = 18, CategoryName = "honeymoon  tour" },
                new Category { Id = 19, CategoryName = "luxury tour" },
                new Category { Id = 20, CategoryName = "'motorcycle  tour" },
                new Category { Id = 21, CategoryName = "nature-based tour" },
                new Category { Id = 23, CategoryName = "relaxing tour" },
                new Category { Id = 24, CategoryName = "shopping tour" },
                new Category { Id = 25, CategoryName = "snorkeling tour" },
                new Category { Id = 26, CategoryName = "sports tour" },
                new Category { Id = 27, CategoryName = "trekking  tour" },
                new Category { Id = 28, CategoryName = "walking  tour" }
            );
            // data seeding for TourCategories
            modelBuilder.Entity<TourCategory>().HasData(
                new TourCategory { TourId = 1, CategoryId = 4 },
                new TourCategory { TourId = 1, CategoryId = 7 },
                new TourCategory { TourId = 1, CategoryId = 8 },
                new TourCategory { TourId = 1, CategoryId = 11 },

                new TourCategory { TourId = 2, CategoryId = 11 },
                new TourCategory { TourId = 2, CategoryId = 12 }
            );
            // data seeding for Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review 
                { 
                    Id = 1, 
                    DateCreated = new DateTime(2022, 03, 29),
                    DateModified = new DateTime(2022, 03, 29),
                    Content = "This is a good tour! A lot of interesting experiences.", 
                    Rating = 4,
                    TourId = 1, 
                    UserId = 1
                },
                new Review
                {
                    Id = 2,
                    DateCreated = new DateTime(2022, 04, 01),
                    DateModified = new DateTime(2022, 04, 01),
                    Content = "I love it! Had a really relaxing time.",
                    Rating = 4,
                    TourId = 1,
                    UserId = 1
                }
            );
            // data seeding for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderDate = new DateTime(2022, 03, 29),
                    DepartureDate = new DateTime(2022, 03, 30),
                    StartPoint = "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province",
                    EndPoint = "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province",
                    Adults = 2,
                    Children = 1,
                    State = "Confirmed",
                    CancelReason = null,
                    TouristName = "Dinh Cong Tai",
                    TouristPhone = "0945501905",
                    TouristEmail = "braddinh1952000@gmail.com",
                    TourId = 1,
                    UserId = 3
                },
                new Order
                {
                    Id = 2,
                    OrderDate = new DateTime(2022, 03, 29),
                    DepartureDate = new DateTime(2022, 03, 30),
                    StartPoint = "160 Tran Nhat Duat, Cam Chau, Hoi An&Customer Point",
                    EndPoint = "123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province",
                    Adults = 2,
                    Children = 0,
                    State = "Confirmed",
                    CancelReason = null,
                    TouristName = "Dinh Cong Tai",
                    TouristPhone = "0945501905",
                    TouristEmail = "braddinh1952000@gmail.com",
                    TourId = 2,
                    UserId = 3
                }
            );
            // data seeding for Hotels
            modelBuilder.Entity<Hotel>().HasData(
               new Hotel
               {
                   Id = 1,
                   Name = "Hai Yen Hotel",
                   Description = "Featuring a free-form outdoor pool and free private parking, Hai Yen Hotel offers budget accommodations with free Wi-Fi and flat-screen TVs. It is centrally located in Hoi An Ancient Town.&" +
                            "Hotel Hai Yen is 2.4 km from well-known Cua Dai Beach.&Large air conditioned rooms at Hai Yen are equipped with a private balcony and seating areas.They are equipped with a safe, electric teakettle and satellite TV.Private bathrooms have a bathtub, toiletries and a hairdryer.&" +
                            "The staff is available at the front desk 24 hours a day and can help with travel arrangements.Guests can purchase gifts at the souvenir shop. Hai Yen Hotel provides shuttle service and currency exchange.&"+
                            "Local dishes, snacks and beverages are offered at Hai Yen’s restaurant.",
                   Phone = "02033969555",
                   Email = "sales@haiyenhotel.com.vn",
                   Province = "Quang Nam",
                   District = "Hoi An",
                   Ward = "Cam Chau",
                   Address = "568 Cua Dai",
                   MinChildAge = 13,
                   Stars = 2,
                   HasParkingLot = true,
                   HasBreakfast = true,
                   PetAllowed = false,
                   CreditCardRequired = false,
                   PayInAdvance = false,
                   Note = "Please inform Hai Yen Hotel of your expected arrival time in advance. You can use the Special Requests box when booking, or contact the property directly using the contact details in your confirmation.&" +
                         "Guests are required to show a photo ID and credit card upon check-in. Please note that all Special Requests are subject to availability and additional charges may apply.&" +
                         "In the event of an early departure, the property will charge you the full amount for your stay.&" +
                         "Parking is subject to availability due to limited spaces.&",
                   PlaceId = 3
               },
               new Hotel
               {
                   Id = 2,
                   Name = "Hoi An Beach Resort ",
                   Description = "This property is 1 minute walk from the beach. Nestled between Cua Dai Beach and De Vong River, Hoi An Beach Resort features 2 outdoor pools. It provides free Wi-Fi and two-way shuttle services to Hoi An Ancient Town.&" +
                         "Rooms at Resort Hoi An come with private balconies overlooking the garden, river or sea. Each room is equipped with a TV, safety deposit box and tea/coffee making facilities..&" +
                         "Local cooking classes begin with a guided boat trip to Hoi An Market. Waterlily Spa offers Vietnamese massage therapies. Other recreational activities include a game of billiards or a workout in the fitness center..&" +
                         "At River Breeze Restaurant, guests can eat indoors or on the balcony overlooking the river. Snacks and refreshments can be enjoyed at the Sunshine Bar and the beachfront Sands Bar..&" +
                         "Hoi An Beach Resort is a 45-minute drive from Danang International Airport and 2.5 mi from Hoi An’s town center. An airport shuttle is available at extra charge.",
                   Phone = "02353927011",
                   Email = "reservation@hoianbeachresort.com.vn",
                   Province = "Quang Nam",
                   District = "Hoi An",
                   Ward = "Cua Dai",
                   Address = "01 Cua Dai",
                   MinChildAge = 6,
                   Stars = 4,
                   HasParkingLot = true,
                   HasBreakfast = true,
                   PetAllowed = false,
                   CreditCardRequired = true,
                   PayInAdvance = false,
                   Note = "",
                   PlaceId = 3
               }
           );
            // data seeding for Rooms
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    HotelId = 1,
                    Name = "Standard Double or Twin Room",
                    Description = "This double room features a electric kettle, air conditioning and tile/marble floor.&",
                    MaxAdults = 2,
                    Area = 25,
                    Price = 50,
                    Stock = 4,
                    Views = "None",
                    SmokingAllowed = false
                },
                new Room
                {
                    Id = 2,
                    HotelId = 1,
                    Name = "Superior Double or Twin Room",
                    Description = "This twin room features a minibar, tile/marble floor and electric kettle.&",
                    MaxAdults = 3,
                    Area = 25,
                    Price = 54,
                    Stock = 4,
                    Views = "None",
                    SmokingAllowed = false
                },
                new Room
                {
                    Id = 3,
                    HotelId = 2,
                    Name = "Grand Deluxe",
                    Description = "Located on the ground floor, air-conditioned rooms feature Eastern designs and traditional Vietnamese lanterns. There is a private balcony that leads to the garden. En suite bathroom comes with a bathtub and separate shower facility.&",
                    MaxAdults = 2,
                    Area = 55,
                    Price = 144,
                    Stock = 8,
                    Views = "Garden View",
                    SmokingAllowed = false                  
                }
            );
            // data seeding for Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    BookingDate = new DateTime(2022, 04, 26),
                    CheckIn = new DateTime(2022, 04, 30),
                    CheckOut = new DateTime(2022, 05, 01),
                    State = "confirmed",
                    CancelReason = null,
                    Adults = 8,
                    Children = 0,
                    CustomerName = "Cong Tai Dinh",
                    CustomerPhone = "0945501905",
                    CustomerEmail = "braddinh1952000@gmail.com",
                    HotelId = 1,
                    UserId = 3
                },
                new Booking
                {
                    Id = 2,
                    BookingDate = new DateTime(2022, 04, 26),
                    CheckIn = new DateTime(2022, 04, 28),
                    CheckOut = new DateTime(2022, 05, 02),
                    State = "confirmed",
                    CancelReason = null,
                    Adults = 4,
                    Children = 0,
                    CustomerName = "Quoc Dat Ngo Luu",
                    CustomerPhone = "0905553859",
                    CustomerEmail = "ngoluuquocdat@gmail.com",
                    HotelId = 2,
                    UserId = 4
                }
            );
            // data seeding for BookingDetails
            modelBuilder.Entity<BookingDetail>().HasData(
                // booking id = 1
                new BookingDetail
                {
                    Id = 1,
                    BookingId = 1,
                    RoomId = 1,
                    Quantity = 2
                },
                new BookingDetail
                {
                    Id = 2,
                    BookingId = 1,
                    RoomId = 2,
                    Quantity = 2
                },
                // booking id = 2
                new BookingDetail
                {
                    Id = 3,
                    BookingId = 2,
                    RoomId = 3,
                    Quantity = 2
                }
            );
        }
    }
}
