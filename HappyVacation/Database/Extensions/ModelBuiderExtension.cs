using HappyVacation.Database.Entities;
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
                    AvatarUrl = "/storage/dat.jpg",
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
                new UserRole { UserId = 4, RoleId = 3 }
            );
            // data seeding for Places
            modelBuilder.Entity<Place>().HasData(
                new Place { Id = 1, PlaceName = "Da Nang", IsTop = true, ThumbnailUrl = "/storage/danang.jpg"},
                new Place { Id = 2, PlaceName = "Hue", IsTop = true, ThumbnailUrl = "/storage/hue.jpg" },
                new Place { Id = 3, PlaceName = "Hoi An", IsTop = true, ThumbnailUrl = "/storage/hoian.jpg" },
                new Place { Id = 4, PlaceName = "Ha Long", IsTop = false, ThumbnailUrl = "/storage/halong.jpg" },
                new Place { Id = 5, PlaceName = "Ha Noi", IsTop = true, ThumbnailUrl = "/storage/hanoi.jpg" },
                new Place { Id = 6, PlaceName = "Ho Chi Minh", IsTop = true, ThumbnailUrl = "/storage/hochiminh.jpg" },
                new Place { Id = 7, PlaceName = "Da Lat", IsTop = false, ThumbnailUrl = "/storage/dalat.jpg" },
                new Place { Id = 8, PlaceName = "Nha Trang", IsTop = true, ThumbnailUrl = "/storage/nhatrang.jpg" },
                new Place { Id = 9, PlaceName = "Phu Quoc", IsTop = false, ThumbnailUrl = "/storage/phuquoc.jpg" },
                new Place { Id = 10, PlaceName = "Quy Nhon", IsTop = false, ThumbnailUrl = "/storage/quynhon.jpg" },
                new Place { Id = 11, PlaceName = "Sa Pa", IsTop = false, ThumbnailUrl = "/storage/sapa.jpg" },
                new Place { Id = 12, PlaceName = "Vung Tau", IsTop = false, ThumbnailUrl = "/storage/vungtau.jpg" },
                new Place { Id = 13, PlaceName = "Mui Ne", IsTop = false, ThumbnailUrl = "/storage/muine.jpg" },
                new Place { Id = 14, PlaceName = "Con Dao", IsTop = false, ThumbnailUrl = "/storage/condao.jpg" },
                new Place { Id = 15, PlaceName = "Trang An", IsTop = false, ThumbnailUrl = "/storage/trangan.jpg" }
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
                    Location = "Minh An Ward, Hoi An City, Quang Nam Province",
                    Destination = "Cam Chau Ward, Hoi An City, Quang Nam Province",
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
                    Location = "Minh An Ward, Hoi An City, Quang Nam Province",
                    Destination = "Minh An Ward, Hoi An City, Quang Nam Province",
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
                    Adults = 2,
                    Children = 1,
                    State = "Confirmed",
                    CancelReason = null,
                    TouristName = "Dinh Cong Tai",
                    TouristPhone = "0945501905",
                    TouristEmail = "braddinh1952000@gmail.com",
                    TourId = 1,
                    ProviderId = 1,
                    UserId = 1
                },
                new Order
                {
                    Id = 2,
                    OrderDate = new DateTime(2022, 03, 29),
                    Adults = 2,
                    Children = 0,
                    State = "Confirmed",
                    CancelReason = null,
                    TouristName = "Dinh Cong Tai",
                    TouristPhone = "0945501905",
                    TouristEmail = "braddinh1952000@gmail.com",
                    TourId = 2,
                    ProviderId = 1,
                    UserId = 1
                }
            );
        }
    }
}
