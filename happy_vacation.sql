USE [HappyVacation]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_BookingDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingDate] [datetime2](7) NOT NULL,
	[CheckIn] [datetime2](7) NOT NULL,
	[CheckOut] [datetime2](7) NOT NULL,
	[State] [nvarchar](10) NOT NULL,
	[CancelReason] [nvarchar](max) NULL,
	[Adults] [int] NOT NULL,
	[Children] [int] NOT NULL,
	[CustomerName] [nvarchar](60) NOT NULL,
	[CustomerPhone] [nvarchar](15) NOT NULL,
	[CustomerEmail] [nvarchar](62) NOT NULL,
	[HotelId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[IsIncluded] [bit] NOT NULL,
	[TourId] [int] NOT NULL,
 CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](62) NOT NULL,
	[Province] [nvarchar](max) NOT NULL,
	[District] [nvarchar](max) NOT NULL,
	[Ward] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[MinChildAge] [int] NOT NULL,
	[Stars] [int] NOT NULL,
	[HasParkingLot] [bit] NOT NULL,
	[HasBreakfast] [bit] NOT NULL,
	[PetAllowed] [bit] NOT NULL,
	[CreditCardRequired] [bit] NOT NULL,
	[PayInAdvance] [bit] NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[PlaceId] [int] NOT NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Itineraries]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Itineraries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[TourId] [int] NOT NULL,
 CONSTRAINT [PK_Itineraries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [nvarchar](max) NOT NULL,
	[ReceiverId] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderMembers]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderMembers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityNum] [nvarchar](15) NOT NULL,
	[FullName] [nvarchar](60) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[IsChild] [bit] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_OrderMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[Adults] [int] NOT NULL,
	[Children] [int] NOT NULL,
	[State] [nvarchar](10) NOT NULL,
	[CancelReason] [nvarchar](max) NULL,
	[TouristName] [nvarchar](60) NOT NULL,
	[TouristPhone] [nvarchar](15) NOT NULL,
	[TouristEmail] [nvarchar](62) NOT NULL,
	[TourId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DepartureDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[EndPoint] [nvarchar](max) NOT NULL,
	[StartPoint] [nvarchar](max) NOT NULL,
	[TouristIdentityNum] [nvarchar](max) NULL,
	[TransactionId] [nvarchar](max) NOT NULL,
	[PricePerAdult] [int] NOT NULL,
	[PricePerChild] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaceImages]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[PlaceId] [int] NOT NULL,
 CONSTRAINT [PK_PlaceImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Places]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Places](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlaceName] [nvarchar](30) NOT NULL,
	[ThumbnailUrl] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Latitude] [decimal](18, 9) NOT NULL,
	[Longitude] [decimal](18, 9) NOT NULL,
	[OverviewVideoUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProviderRegistrations]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProviderRegistrations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProviderName] [nvarchar](max) NOT NULL,
	[ContactPersonName] [nvarchar](max) NOT NULL,
	[ProviderEmail] [nvarchar](max) NOT NULL,
	[ProviderPhone] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[IsRejected] [bit] NOT NULL,
 CONSTRAINT [PK_ProviderRegistrations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Providers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProviderName] [nvarchar](100) NOT NULL,
	[ProviderPhone] [nvarchar](15) NOT NULL,
	[ProviderEmail] [nvarchar](62) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[AvatarUrl] [nvarchar](max) NOT NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_Providers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[Rating] [real] NOT NULL,
	[UserId] [int] NOT NULL,
	[TourId] [int] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[MaxAdults] [int] NOT NULL,
	[Area] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Views] [nvarchar](max) NOT NULL,
	[SmokingAllowed] [bit] NOT NULL,
	[HotelId] [int] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubTouristSites]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubTouristSites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SiteName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[HighLights] [nvarchar](max) NOT NULL,
	[Province] [nvarchar](max) NOT NULL,
	[District] [nvarchar](max) NOT NULL,
	[Ward] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[OpenCloseTime] [nvarchar](max) NOT NULL,
	[Longitude] [decimal](18, 9) NOT NULL,
	[Latitude] [decimal](18, 9) NOT NULL,
	[PlaceId] [int] NOT NULL,
	[OverviewVideoUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SubTouristSites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourCategories]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourCategories](
	[TourId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_TourCategories] PRIMARY KEY CLUSTERED 
(
	[TourId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourImages]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[TourId] [int] NOT NULL,
 CONSTRAINT [PK_TourImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouristSiteImages]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouristSiteImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[SubTouristSiteId] [int] NOT NULL,
 CONSTRAINT [PK_TouristSiteImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourPlaces]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourPlaces](
	[TourId] [int] NOT NULL,
	[PlaceId] [int] NOT NULL,
 CONSTRAINT [PK_TourPlaces] PRIMARY KEY CLUSTERED 
(
	[TourId] ASC,
	[PlaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tours]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TourName] [nvarchar](200) NOT NULL,
	[Overview] [nvarchar](max) NOT NULL,
	[Duration] [real] NOT NULL,
	[GroupSize] [int] NOT NULL,
	[MinAdults] [int] NOT NULL,
	[StartPoint] [nvarchar](100) NOT NULL,
	[EndPoint] [nvarchar](100) NOT NULL,
	[PricePerAdult] [int] NOT NULL,
	[PricePerChild] [int] NOT NULL,
	[IsPrivate] [bit] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[ViewCount] [int] NOT NULL,
	[ProviderId] [int] NOT NULL,
	[StartTime] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TravelTips]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TravelTips](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[PlaceId] [int] NOT NULL,
 CONSTRAINT [PK_TravelTips] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](62) NOT NULL,
	[AvatarUrl] [nvarchar](max) NULL,
	[ProviderId] [int] NULL,
	[IsEnabled] [bit] NOT NULL,
	[HotelId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WishItems]    Script Date: 7/25/2022 7:00:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WishItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TourId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_WishItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220404082421_InitialDb', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220404082737_SeedData', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220407034340_TourPlaceTable', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220412132557_UpdateOrderTable', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220412134915_ModifiedDateOrder', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220413140455_RemoveProviderId_OrderTable', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220425151437_HotelBookingBaseTables', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220426051450_SeedData_02', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220504073626_StartTime_StartPoint_EndPoint_TourTable', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220504080601_StartPoint_EndPoint_Order_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220510023214_Place_SubTouristSite_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220510065413_SeedData_03', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220512024552_Remove_OverviewVideo_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220512150706_Add_TravelTip_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220515021206_Add_OverviewVideo_TouristSite_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220516041011_Add_OrderMember_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220519045235_Add_Column_TransactionId_Order_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220528125902_Add_ProviderRegistration_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220528131415_Add_ProviderRegistration_Table2', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220604132713_Add_WishItems_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220606141737_Add_Messages_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220613020949_Price_in_Order_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220617075752_Add_ImageUrl_Message_Table', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220627145644_Add_IsRejected_To_ProviderRegistration_Table', N'6.0.3')
GO
SET IDENTITY_INSERT [dbo].[BookingDetails] ON 

INSERT [dbo].[BookingDetails] ([Id], [BookingId], [RoomId], [Quantity]) VALUES (1, 1, 1, 2)
INSERT [dbo].[BookingDetails] ([Id], [BookingId], [RoomId], [Quantity]) VALUES (2, 1, 2, 2)
INSERT [dbo].[BookingDetails] ([Id], [BookingId], [RoomId], [Quantity]) VALUES (3, 2, 3, 2)
SET IDENTITY_INSERT [dbo].[BookingDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([Id], [BookingDate], [CheckIn], [CheckOut], [State], [CancelReason], [Adults], [Children], [CustomerName], [CustomerPhone], [CustomerEmail], [HotelId], [UserId]) VALUES (1, CAST(N'2022-04-26T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), N'confirmed', NULL, 8, 0, N'Cong Tai Dinh', N'0945501905', N'braddinh1952000@gmail.com', 1, 3)
INSERT [dbo].[Bookings] ([Id], [BookingDate], [CheckIn], [CheckOut], [State], [CancelReason], [Adults], [Children], [CustomerName], [CustomerPhone], [CustomerEmail], [HotelId], [UserId]) VALUES (2, CAST(N'2022-04-26T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-28T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-02T00:00:00.0000000' AS DateTime2), N'confirmed', NULL, 4, 0, N'Quoc Dat Ngo Luu', N'0905553859', N'ngoluuquocdat@gmail.com', 2, 4)
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (1, N'adventure tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (2, N'artistic tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (3, N'beach tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (4, N'biking tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (5, N'boating tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (6, N'camping')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (7, N'classic tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (8, N'cooking tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (9, N'craft tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (10, N'cruises tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (11, N'culinary tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (12, N'cultural tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (13, N'discovery tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (14, N'fishing tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (15, N'heritage tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (16, N'historical tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (17, N'homestay tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (18, N'honeymoon  tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (19, N'luxury tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (20, N'motorcycle  tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (21, N'nature-based tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (23, N'relaxing tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (24, N'shopping tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (25, N'snorkeling tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (26, N'sports tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (27, N'trekking  tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (28, N'walking  tour')
INSERT [dbo].[Categories] ([Id], [CategoryName]) VALUES (29, N'photography')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Expenses] ON 

INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1, N'Hotel pickup and drop-off in Hoi An City Center', 1, 1)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (2, N'Transportation with air-conditioning', 1, 1)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (3, N'Bicycle', 1, 1)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (4, N'Entrance fees', 1, 1)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (5, N'Foods and Bottled drinking water', 1, 1)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (6, N'Tips and gratuities', 0, 1)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (7, N'Personal expenses such as: shopping, telephone, beverage, etc.', 0, 1)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (8, N'Hotel pickup and drop-off in Hoi An City Center', 1, 2)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (9, N'Transportation with air-conditioning', 1, 2)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (10, N'Boat', 1, 2)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (11, N'Entrance fees', 1, 2)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (12, N'Dinner', 1, 2)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (13, N'English-speaking tour guide', 1, 2)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (14, N'Tips and gratuities', 0, 2)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (15, N'Personal expenses such as: shopping, telephone, beverage, etc.', 0, 2)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (19, N'Hotel pickup and drop-off in Hoi An City Center', 1, 4)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (20, N'Transportation with air-conditioning', 1, 4)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (21, N'Entrance fees', 1, 4)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (22, N'Drinks (water, soft drink, coffee, juice, local beer)', 1, 4)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (23, N'Local bread', 1, 4)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (24, N'English speaking guide', 1, 4)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (25, N'Travel insurance', 1, 4)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (26, N'Tips and gratuities', 0, 4)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (27, N'Personal expenses such as: shopping, telephone, beverage, etc.', 0, 4)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (28, N'Choice of self-drive or chauffeur-driven without surcharge', 1, 4)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (39, N'Hotel pickup and drop-off in Hoi An City Center', 1, 6)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (40, N'Transportation with air-conditioning', 1, 6)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (41, N'Entrance fees', 1, 6)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (42, N'Boat', 1, 6)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (43, N'Accommodation twin/double/triple sharing - 1 night in hotel', 1, 6)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (44, N'Bottled drinking water and meals as specified in the itinerary (1 breakfast, 2 lunches, 1 dinner)', 1, 6)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (45, N'English speaking guides (other languages available upon request with surcharge)', 1, 6)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (46, N'Travel insurance', 1, 6)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (47, N'Personal expenses such as: shopping, telephone, beverage, etc.', 0, 6)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (48, N'Tips and gratuities', 0, 6)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (74, N'Hotel transfers for arrival and departure', 1, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (75, N'Transportation with air-conditioning', 1, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (76, N'Entrance fees', 1, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (77, N'Accommodation twin/double/triple sharing; Check-in time: 14:00, Check-out time: 12:00 - 6 nights in hotel, 1 night on cruise', 1, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (78, N'Mineral water and meals as specified in the itinerary (7 breakfasts, 4 lunches, 1 dinner)', 1, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (79, N'English speaking guides (other languages available upon request with surcharge)', 1, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (80, N'Domestic Flight tickets (Ha Noi - Da Nang ), 20 kg checked baggage, 7 kg hand baggage', 1, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (81, N'Visa fees', 0, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (82, N'Travel insurance', 0, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (83, N'Compulsory dinner on 24 Dec and 31 Dec surcharge (depending on hotel policy)', 0, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (84, N'Tips and gratuities', 0, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (85, N'Personal expenses such as: shopping, telephone, beverage, etc.', 0, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (86, N'International or domestic air tickets not mentioned above', 0, 7)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (99, N'Food', 1, 3)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (100, N'Drink: water and beer', 1, 3)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (101, N'Medical expense', 0, 3)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (102, N'Room', 1, 3)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (231, N'Hotel pickup and drop-off in Nha Trang City Center', 1, 8)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (232, N'Transportation with air-conditioning', 1, 8)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (233, N'Entrance fees', 1, 8)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (234, N'Bottled drinking water', 1, 8)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (235, N'English speaking guide', 1, 8)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (236, N'Travel insurance', 1, 8)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (237, N'Tipping for local guides', 0, 8)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (238, N'Personal expenses such as: shopping, telephone, beverage, etc.', 0, 8)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1249, N'Hotel pickup and drop-off in Hue City Center', 1, 11)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1250, N'Transportation with air-conditioning', 1, 11)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1251, N'Entrance fees, Boat', 1, 11)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1252, N'Bottled drinking water', 1, 11)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1253, N'Lunch', 1, 11)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1254, N'English-speaking tour guide', 1, 11)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1255, N'Travel insurance', 1, 11)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1256, N'Tips and gratuities', 0, 11)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1257, N'Personal expenses such as: shopping, telephone, beverage, etc.', 0, 11)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1258, N'Hotel pickup and drop-off in Da Nang City Center', 1, 12)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1259, N'Transportation with air-conditioning', 1, 12)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1260, N'Entrance fees', 1, 12)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1261, N'Bottled drinking water', 1, 12)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1262, N'Snack, lunch', 1, 12)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1263, N'Travel insurance', 1, 12)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1264, N'Tips and gratuities', 0, 12)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1265, N'Personal expenses', 0, 12)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1304, N'Hotel pickup and drop-off in Hue City Center', 1, 13)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1305, N'Transportation with air-conditioning', 1, 13)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1306, N'Bottled drinking water', 1, 13)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1307, N'Local food as mentioned', 1, 13)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1308, N'Travel insurance', 1, 13)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1309, N'English speaking guides ', 1, 13)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1310, N'Tips and gratuities', 0, 13)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1311, N'Personal expenses', 0, 13)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1312, N'Hotel pickup and drop-off in Hue City Center', 1, 16)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1313, N'Food and bottled drinking water', 1, 16)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1314, N'Boat fee', 1, 16)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1315, N'Travel insurance', 1, 16)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1316, N'Tips and gratuities', 0, 16)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1317, N'Personal expenses', 0, 16)
INSERT [dbo].[Expenses] ([Id], [Content], [IsIncluded], [TourId]) VALUES (1322, N'Dinner', 1, 17)
SET IDENTITY_INSERT [dbo].[Expenses] OFF
GO
SET IDENTITY_INSERT [dbo].[Hotels] ON 

INSERT [dbo].[Hotels] ([Id], [Name], [Description], [Phone], [Email], [Province], [District], [Ward], [Address], [MinChildAge], [Stars], [HasParkingLot], [HasBreakfast], [PetAllowed], [CreditCardRequired], [PayInAdvance], [Note], [PlaceId]) VALUES (1, N'Hai Yen Hotel', N'Featuring a free-form outdoor pool and free private parking, Hai Yen Hotel offers budget accommodations with free Wi-Fi and flat-screen TVs. It is centrally located in Hoi An Ancient Town.&Hotel Hai Yen is 2.4 km from well-known Cua Dai Beach.&Large air conditioned rooms at Hai Yen are equipped with a private balcony and seating areas.They are equipped with a safe, electric teakettle and satellite TV.Private bathrooms have a bathtub, toiletries and a hairdryer.&The staff is available at the front desk 24 hours a day and can help with travel arrangements.Guests can purchase gifts at the souvenir shop. Hai Yen Hotel provides shuttle service and currency exchange.&Local dishes, snacks and beverages are offered at Hai Yen’s restaurant.', N'02033969555', N'sales@haiyenhotel.com.vn', N'Quang Nam', N'Hoi An', N'Cam Chau', N'568 Cua Dai', 13, 2, 1, 1, 0, 0, 0, N'Please inform Hai Yen Hotel of your expected arrival time in advance. You can use the Special Requests box when booking, or contact the property directly using the contact details in your confirmation.&Guests are required to show a photo ID and credit card upon check-in. Please note that all Special Requests are subject to availability and additional charges may apply.&In the event of an early departure, the property will charge you the full amount for your stay.&Parking is subject to availability due to limited spaces.&', 3)
INSERT [dbo].[Hotels] ([Id], [Name], [Description], [Phone], [Email], [Province], [District], [Ward], [Address], [MinChildAge], [Stars], [HasParkingLot], [HasBreakfast], [PetAllowed], [CreditCardRequired], [PayInAdvance], [Note], [PlaceId]) VALUES (2, N'Hoi An Beach Resort ', N'This property is 1 minute walk from the beach. Nestled between Cua Dai Beach and De Vong River, Hoi An Beach Resort features 2 outdoor pools. It provides free Wi-Fi and two-way shuttle services to Hoi An Ancient Town.&Rooms at Resort Hoi An come with private balconies overlooking the garden, river or sea. Each room is equipped with a TV, safety deposit box and tea/coffee making facilities..&Local cooking classes begin with a guided boat trip to Hoi An Market. Waterlily Spa offers Vietnamese massage therapies. Other recreational activities include a game of billiards or a workout in the fitness center..&At River Breeze Restaurant, guests can eat indoors or on the balcony overlooking the river. Snacks and refreshments can be enjoyed at the Sunshine Bar and the beachfront Sands Bar..&Hoi An Beach Resort is a 45-minute drive from Danang International Airport and 2.5 mi from Hoi An’s town center. An airport shuttle is available at extra charge.', N'02353927011', N'reservation@hoianbeachresort.com.vn', N'Quang Nam', N'Hoi An', N'Cua Dai', N'01 Cua Dai', 6, 4, 1, 1, 0, 1, 0, N'', 3)
SET IDENTITY_INSERT [dbo].[Hotels] OFF
GO
SET IDENTITY_INSERT [dbo].[Itineraries] ON 

INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (1, N'Part 1', N'Discover Hoi An’s countryside and its local foods by bicycle. Local foods in Hoi An are known and enjoyed by the tourists once setting foot here. In Hoi An, these cuisines are very popular and sold everywhere in all streets. Moreover, these cuisines are considered as unique symbols for the culture and introduced to every tourist. We bike through the countryside to a Tra Que Village.', 1)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (2, N'Part 2', N'Vegetables from this village are distributed to most of the restaurants in town and specially make the Cao Lau to have a perfect taste. Go back to town and learn how to make special “white rose” dumpling cakes with a local family and taste your products.', 1)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (3, N'Part 3', N'Continue riding to Cam Nam to enjoy the Yin and Yang food such as: Banh Dap (“cracked or smashed rice pancake”), Che Bap (“corn and coconut sweet soup”). We then ride to a famous local restaurant for Hoi An specialty - Cao Lau. Cao Lau is a traditional Hoi An specialty composed of local noodles, pork, fresh vegetables and rice paper.', 1)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (4, N'Part 4', N'We will ride back to the company at the end of our trip.', 1)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (5, N'Part 1', N'We will visit the Japanese Covered Bridge - one of Vietnam''s most iconic attraction and a beautiful historical piece of Japanese architecture. Walking in the ancient streets at night, you can perceive the ancient beauty of Hoi An City.', 2)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (6, N'Part 2', N'We will visit one of Hoi An Museums and an Ancient House which boast a remarkable architectural style and rest under the glistening lantern lights.', 2)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (7, N'Part 3', N'Enjoy Bai Choi performance by the bank of Hoai river. Bai Choi combines music, poetry, acting, painting and literature, has been recognized by UNESCO as an intangible heritage of humanity.', 2)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (8, N'Part 4', N'Have dinner at a restaurant with romantic river view then ake a 15-minute boat trip on Hoai River lighting and floating your own candle lit coloured paper lantern on the river with wishes and go shopping at Hoi An night market.', 2)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (13, N'Part 1 - Depart 8:30', N'The tour kicks off in style with coffee in local style then hop on your scooter to start exploring Hoi An’s hidden gems and charismatic locals. Take a drive to Cam Nam Island to visit some local houses and places where people live and work traditional lives. Visit a ship repair yard to experience the hard work involved in maintaining a local fishing boat. ', 4)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (14, N'Part 2', N'A short drive through a local village and beautiful countryside includes a stop at an ancestor''s house where guests can learn more about the belief system in Vietnam. We will visit the local shoe-making shop to learn about the ancient tradition of tailoring and shoe-making in Hoi An.', 4)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (15, N'Part 3', N'Before having a short break at a stall overlooking Hoi An Ancient Town and Thu Bon River, we visit a rice cracker place to observe the traditional cracker making process as well as have a taste of the yummy end-product.
Afterward, on our drive through the countryside, you will experience the resplendent beauty of the rice paddies, grazing buffalo and monkey bridges, all of which you can take photos of.', 4)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (16, N'Part 4', N' We will ride to Tra Que Village, a beautiful herb and vegetable garden which supplies vegetables for the restaurants in the ancient town. At the end of the tour, guests can unwind at a stunning beach lounge overlooking one of the best beaches in Vietnam, An Bang Beach, with a refreshing drink.', 4)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (19, N'Day 1: Hoi An - Hue', N'We will visit the Citadel, Hue’s most prime attraction containing the Imperial City, the Forbidden Purple City, and the Emperor''s Private Residence. After spending time at the Citadel, we will have lunch before checking into a hotel. In the afternoon, we will visit Thien Mu Pagoda, Khai Dinh Royal Tomb and go shopping at Dong Ba Riverside Market. Overnight in Hue.', 6)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (20, N'Day 2: Hue - DMZ - Hoi An', N'Start with an early morning to visit the DMZ (Demilitarized Zone). DMZ is set in the rugged, jungle-shrouded mountains along the Vietnam - Laos border of South Vietnam. We will visit Quang Tri Citadel, Hien Luong Bridge and the Seventeenth Parallel - the former borderline between North and South Vietnam during the Vietnam War. Continue with a trip to Vinh Moc Tunnels, which were used to shelter people from the intense bombings during the Vietnam War and Con Tien Firebase area.', 6)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (42, N'Day 1: Ha Noi - Arrival', N'Pick-up at Noi Bai International airport. Transfer to your hotel. Overnight in Ha Noi.', 7)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (43, N'Day 2: Ha Noi - Ha Long Bay', N'The wondrous Ha Long Bay is truly one of Vietnam’s most impressive sights. Heading out of town, we will embark by boat for an exploration of legendary Ha Long Bay. Ha Long Bay is home to some 3000 limestone islands that rise out of the clear emerald water. The limestone karsts formations are littered with beaches, grottoes and beautiful caves. Along the way, we will anchor for a leisurely swim in a secluded cove and enjoy a visit to one of the many hidden grottoes beneath towering cliffs. Overnight on the cruise.', 7)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (44, N'Day 3: Ha Long Bay - Ha Noi', N'After breakfast, swimming and sunbathing. After lunch, return to Ha Noi. Overnight in Ha Noi.', 7)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (45, N'Day 4: Ha Noi - Da Nang - Hoi An', N'After breakfast at the hotel, transfer to Noi Bai International airport to go to Hoi An. Upon arrival at Da Nang airport, pick up and transfer to the hotel. Check in and relax. Overnight in Hoi An.', 7)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (46, N'Day 5: Ba Na Hills and Golden Bridge', N'Ba Na is one of the most interesting areas in the region as often one can feel the four distinct seasons within a single day: morning - spring, noon - summer, afternoon - autumn and evening - winter. You will have a chance to visit Golden Bridge which is a 150-meter long pedestrian bridge with two giant stone hands supporting the structure. It is designed to connect the cable car station with the gardens and to provide a scenic overlook and tourist attraction. We can enjoy the view of the beautiful landscape of nature comfortably and smoothly. Past the Golden Bridge, and into the center of a charming (and very Epcot-like) French village, complete with French Gothic-style cathedral, French restaurants, cobblestoned streets and impressive French gardens. There are many more places in Ba Na Hills to explore including Linh Ung Ba Na Pagoda, Le Jardin Garden and a complex of ancient villas. Linh Ung Ba Na Pagoda with an exquisite architectural design was built in 2004 and is symbolized by a 30-meter high Buddha statue that is exposed amidst an immense space of clouds and mountains. We will continue our trip discovering Tinh Tam Garden, Nghinh Phong Peak and Vong Nguyet Hill where we can enjoy the panoramic views the areas have to offer. Overnight in Hoi An.', 7)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (47, N'Day 6: Hoi An Foodie Tour in the morning', N'Discover Hoi An’s countryside and its local foods by bicycle. Local foods in Hoi An are known and enjoyed by the tourists once setting foot here. In Hoi An, these cuisines are very popular and sold everywhere in all streets. Moreover, these cuisines are considered as unique symbols for the culture and introduced to every tourist. We will ride to a local restaurant for Hoi An specialty - Cao Lau. Cao Lau is a traditional Hoi An specialty composed of local noodles, pork, fresh vegetables and rice paper. The noodles are made with local sticky rice soaked in the water that must be taken from Ba Le Well: the oldest well in Hoi An, believed to have the best water anywhere. We then bike through the countryside to a Tra Que Village. Vegetables from this village are distributed to most of the restaurants in town and specially make the Cao Lau to have a perfect taste. You will also learn how to make special “white rose” dumpling cakes with a local family and taste your products. Continue riding to Cam Nam to enjoy the Yin and Yang food such as: Banh Dap (“cracked or smashed rice pancake”), Che Bap (“corn and coconut sweet soup”). Have free time in the afternoon. Overnight in Hoi An.', 7)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (48, N'Day 7: Hoi An - Free day', N'Free time all day to explore Hoi An on your own or take optional tour with Hoi An Express. Overnight in Hoi An.', 7)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (49, N'Day 8: Hoi An - Da Nang - Departure', N'Have breakfast at the hotel and relax until the time of transfer to Da Nang International airport for your departure flight.

END TOUR.', 7)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (62, N'Part 1', N'Go to Hoa Tien market to buy food and drink.', 3)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (63, N'Part 2', N'Roll to Tuan''s kitchen to cook anything you want.', 3)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (64, N'Part 3', N'Party till dead. Eat & drink like you only have one day left.', 3)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (65, N'Part 4', N'Sleep at Tuan''s house.', 3)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (114, N'Part 1', N'The tour will begin with a trip to XQ Hand Embroidery Factory, where you can watch how wonderfully intricate, hand-woven fabrics are carefully crafted; the perfect place to purchase souvenirs that portray beautiful scenes of Vietnamese culture.', 8)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (115, N'Part 2', N'The next stop is Long Son Pagoda, which was founded in the 19th century and is a beautiful example of classic Buddhist architecture. The 14-meter-high Buddha statue that sits atop this site is visible from afar as one enters the city, and has great views of the city and surrounding countryside.', 8)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (116, N'Part 3', N'The final leg of our tour will take you to view some ancient Cham architecture at the Cham Ponagar temple complex. Locally referred to as Thap Ba, this set of ancient Cham temples is beautifully located on a hill just outside the city and is reached by crossing the Cai River. Learn about the fascinating ancient civilization of the Hindu-worshipping Cham people as you wander around the lovely temple grounds.', 8)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (1142, N'FULL-DAY HAI VAN PASS, LANG CO BEACH & TRUOI VILLAGE FROM HUE CITY', N'We will depart for Truoi Village, which is located on both sides of the Truoi River. People in the village live mainly on cultivation and animal husbandry. Take a romantic and poetic trip with the cool lake scene on Truoi Lake to visit Truc Lam Bach Ma Monastery. The Monastery looks like a jewel among the vast forests and mountains, attracting many Buddhists and visitors to meditate and enjoy the landscape. We then depart for Lang Co fishing village. Lang Co fishing village is picturesque with a white sand beach stretching for tens of kilometers, and a clear blue sea. After lunch, the trip will continue to Lap An Lagoon. Lap An Lagoon is a large brackish lagoon in Hue and covers an area of about 800 hectares. Lap An Lagoon is surrounded by the magnificent Bach Ma mountain range; Lang Co bay is clear, smooth, and the small road along the foot of the mountain winds around the lagoon-like a soft and shiny silk strip. We will continue moving over Hai Van Pass, the longest and highest mountain pass road in Vietnam with a length of 21 kilometers. It is like a giant dragon, lying on highway-01 on the geographical boundary between Da Nang and Thua Thien-Hue Province.', 11)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (1143, N'Part 1', N'Start hiking along the path through the forest to the summit trail, which takes you a few kilometers past the Bach Ma Morin at the terminus of the park road. The trail continues to a pavilion with 360-degree views of the surrounding area, usually mist-shrouded and above the clouds.', 12)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (1144, N'Part 2', N'Back to Do Quyen Waterfall for trekking along a path through the dense jungle (1.5 kilometers). Trekkers in luck can see birds at close range along the foot trails where we will enjoy a picnic lunch.', 12)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (1145, N'Part 3', N'After an exciting day in Bach Ma, we will depart for Lang Co Beach and have a seafood lunch there. With its gradually sloping, white sand beach, an average depth of less than 1 meter, and the average temperature in the bathing season of 25oC, Lang Co is an ideal beach for tourists.
', 12)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (1157, N'Part 1', N'We will firstly taste Hue Specialty - "Banh Khoai" - Hue crispy pancake. People said that this is a "happy cake" because it resembles a big smile when it is folded like a "Taco". Go around to view the nightlife in Hue via not too busy streets to come to another restaurant for "Bun Bo Hue" - Hue beef vermicelli soup ​​of which name is to recognize the original region dish but you can find that elsewhere in Vietnam recent years because of its fame.', 13)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (1158, N'Part 2', N'We then go to a small private family restaurant for a series of specialties including "Banh Bot Loc" - filtered tapioca dumplings, "Banh Beo" - literally water fern cake, "Banh Nam" - steamed shrimp rice cake, "Banh Ram It" - Sticky rice dumplings on a fried dumpling and drink iced green tea giving you a very authentic experience.', 13)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (1159, N'Part 3', N'After tasting most of Hue''s famous specialties, we will take a walk at the walking area for sightseeing, walking, shopping or enjoying countless Hue specialties.', 13)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (1160, N'HALF-DAY TAM GIANG LAGOON FROM HUE CITY', N'Tam Giang lagoon has various biological diversity of aquatic resources and fauna both underwater and on land. Every day a number of fish; shrimps, oysters, etc caught in the lagoon sold in local fish markets or sold to wholesalers or used for the raw material for traditional fish sauce making villages. Get on boat (sampan) and cruise on the lagoon weaving amidst the Fishing nets, Oyster Cages, Fish spawning areas, seeing how these fishermen live with their families right in these small houses on stilts right smack in the Lagoon, the mangrove eco system. These are the wonderful moments to take your photos. Floating on the water, you will have time to see the changes of time and life as well as the local life of the fishing village. An interesting to visit "Cho house" - a hut is typically five square meters in size and built of bamboo and fishermen live in them . You have a chance to take part in the game “Be a fisherman on the lagoon” (with the group up to 10 people). Back to the huts to taste some kind of local seafood.', 16)
INSERT [dbo].[Itineraries] ([Id], [Title], [Content], [TourId]) VALUES (1165, N'HALF-DAY FOODIE TEST TEST TEST 3', N'HALF-DAY FOODIE TEST TEST TEST ', 17)
SET IDENTITY_INSERT [dbo].[Itineraries] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (9, N'6', N'provider1', N'hello Hoi An Express!', CAST(N'2022-06-07T09:40:11.5811863' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (10, N'6', N'provider1', N'I have some question', CAST(N'2022-06-07T09:40:26.1620974' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (11, N'provider1', N'6', N'We are pleased to answer!', CAST(N'2022-06-07T09:41:26.1620974' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (15, N'6', N'provider1', N'about private tour: hoi an mysterious night tour with dinner from hoi an
', CAST(N'2022-06-07T10:23:41.1777009' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (16, N'6', N'provider1', N'we can choose our pick up place, right?', CAST(N'2022-06-07T10:32:29.1313516' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (18, N'provider1', N'6', N'Yes, you can.', CAST(N'2022-06-07T10:33:29.1313516' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (20, N'provider1', N'6', N'And remember that you can only choose location in place which we provided', CAST(N'2022-06-07T10:32:30.1313516' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (22, N'provider1', N'6', N'For example, it''s Hoi An for this tour', CAST(N'2022-06-07T10:32:31.1313516' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (23, N'6', N'provider1', N'I got it! Thank you', CAST(N'2022-06-07T10:32:32.1313516' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (24, N'provider1', N'6', N'You''re welcome!', CAST(N'2022-06-07T10:33:29.1313516' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (25, N'provider1', N'6', N'hi', CAST(N'2022-06-07T14:48:21.4361622' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (26, N'provider1', N'6', N'are you there ?', CAST(N'2022-06-07T14:50:07.6613386' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (27, N'6', N'provider1', N'yeah ?', CAST(N'2022-06-07T14:51:25.9973144' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (28, N'provider1', N'6', N'can you provide us your phone number?', CAST(N'2022-06-07T14:55:35.7434145' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (29, N'6', N'provider1', N'ok but, what''s for ?', CAST(N'2022-06-07T14:56:51.3294736' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (30, N'provider1', N'6', N'so we can contact to show you more about our program', CAST(N'2022-06-07T14:58:25.8972783' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (31, N'provider1', N'6', N'soon we will have a discount program', CAST(N'2022-06-07T15:00:02.7497855' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (32, N'provider1', N'6', N'for the summer', CAST(N'2022-06-07T15:00:12.1953164' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (33, N'6', N'provider1', N'oh, that''s sound interesting', CAST(N'2022-06-07T15:00:23.1555935' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (34, N'6', N'provider1', N'here''s my phone num: 0914333222', CAST(N'2022-06-07T15:35:02.7001473' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (35, N'6', N'provider1', N'call me on weekends please', CAST(N'2022-06-07T15:35:32.4886047' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (36, N'provider1', N'6', N'understood, thank you!', CAST(N'2022-06-07T15:35:48.4200726' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (37, N'6', N'provider1', N'ur welcome!', CAST(N'2022-06-07T15:35:57.4042515' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (71, N'YrETbo3Z3k62YvxgeYwFtw==', N'provider1', N'hi provider, you still good huh?', CAST(N'2022-06-09T14:57:02.0709647' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (72, N'nkK1LmmHYUmM1NM0DjAQ==', N'provider1', N'hi, new anonymous one!', CAST(N'2022-06-09T15:21:55.5244758' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (73, N'provider1', N'nkK1LmmHYUmM1NM0DjAQ==', N'hi there!', CAST(N'2022-06-09T15:22:07.7546634' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (74, N'provider1', N'6', N'try taynguyensound''s stuffstry taynguyensound''s stuffstry taynguyensound''s stuffstry taynguyensound''s stuffstry taynguyensound''s stuffstry taynguyensound''s stuffs', CAST(N'2022-06-10T13:34:11.2783403' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (77, N'0Q50TxN0UiFYZVANjaLQ==', N'provider1', N'hi! nice to meet you!', CAST(N'2022-06-10T16:24:54.9506430' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (78, N'6', N'provider1', N'nice!', CAST(N'2022-06-10T16:27:34.1106466' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (79, N'provider1', N'0Q50TxN0UiFYZVANjaLQ==', N'hi 0Q50T, nice to meet you too!', CAST(N'2022-06-10T16:28:32.3622327' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (80, N'provider1', N'0Q50TxN0UiFYZVANjaLQ==', N'can I help you ?', CAST(N'2022-06-17T09:58:22.3178491' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (81, N'0Q50TxN0UiFYZVANjaLQ==', N'provider1', N'I want to ask about your half day nha trang city tour
', CAST(N'2022-06-17T10:09:34.6061911' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (83, N'provider1', N'0Q50TxN0UiFYZVANjaLQ==', N'I will send you an image', CAST(N'2022-06-17T16:20:27.3696766' AS DateTime2), N'')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (84, N'provider1', N'0Q50TxN0UiFYZVANjaLQ==', N'', CAST(N'2022-06-17T16:20:49.2984526' AS DateTime2), N'/message/a89b3b8d-c8fa-4881-b5e8-0600ce61a775.jpg')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (85, N'provider1', N'0Q50TxN0UiFYZVANjaLQ==', N'message with content and image', CAST(N'2022-06-17T16:28:45.7015974' AS DateTime2), N'/message/3572f5af-b8e2-4f28-8ced-95b200660715.jpg')
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [DateTime], [ImageUrl]) VALUES (86, N'provider1', N'0Q50TxN0UiFYZVANjaLQ==', N'', CAST(N'2022-06-17T16:39:34.7944905' AS DateTime2), N'/message/7d52c8ee-30ce-46bc-bdeb-094defb61921.jpg')
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderMembers] ON 

INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1, N'201788301', N'Dinh Cong Tai', CAST(N'2000-05-19T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (2, N'201877103', N'Ho Thao Khanh', CAST(N'2000-06-20T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (3, N'', N'Dinh Cong Khoi', CAST(N'2015-07-21T00:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (4, N'201788301', N'Dinh Cong Tai', CAST(N'2000-05-19T00:00:00.0000000' AS DateTime2), 0, 2)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (5, N'201877103', N'Ho Thao Khanh', CAST(N'2000-06-20T00:00:00.0000000' AS DateTime2), 0, 2)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (6, N'201788301', N'Dinh Cong Tai', CAST(N'2000-05-19T00:00:00.0000000' AS DateTime2), 0, 5)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (7, N'201877103', N'Ho Thao Khanh', CAST(N'2000-06-20T00:00:00.0000000' AS DateTime2), 0, 5)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (8, N'206286537', N'Ngo Quoc Dat', CAST(N'2000-10-19T00:00:00.0000000' AS DateTime2), 0, 5)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (9, N'', N'Dinh Cong Khoi', CAST(N'2015-07-21T00:00:00.0000000' AS DateTime2), 1, 5)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (10, N'201788301', N'Dinh Cong Tai', CAST(N'2000-05-19T00:00:00.0000000' AS DateTime2), 0, 6)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (11, N'201877103', N'Ho Thao Khanh', CAST(N'2000-06-20T00:00:00.0000000' AS DateTime2), 0, 6)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (12, N'203676201', N'Ho Van An', CAST(N'2000-09-10T00:00:00.0000000' AS DateTime2), 0, 10)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (13, N'203979301', N'Nguyen Van Bao', CAST(N'2000-08-20T00:00:00.0000000' AS DateTime2), 0, 10)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (14, N'206286537', N'Ngo Quoc Dat', CAST(N'2000-10-19T00:00:00.0000000' AS DateTime2), 0, 10)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (15, N'', N'Ho Van Thanh', CAST(N'2016-07-21T00:00:00.0000000' AS DateTime2), 1, 10)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (16, N'203676201', N'Ho Van An', CAST(N'2000-09-10T00:00:00.0000000' AS DateTime2), 0, 11)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (17, N'203979301', N'Nguyen Van Bao', CAST(N'2000-08-20T00:00:00.0000000' AS DateTime2), 0, 11)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (18, N'', N'Ho Van Thanh', CAST(N'2016-07-21T00:00:00.0000000' AS DateTime2), 1, 11)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (19, N'203676201', N'Ho Van An', CAST(N'2000-09-10T00:00:00.0000000' AS DateTime2), 0, 12)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (20, N'203979301', N'Nguyen Van Bao', CAST(N'2000-08-20T00:00:00.0000000' AS DateTime2), 0, 12)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (21, N'', N'Ho Van Thanh', CAST(N'2016-07-21T00:00:00.0000000' AS DateTime2), 1, 12)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (22, N'203979301', N'Anh Tai Ngo Dien', CAST(N'2000-02-01T00:00:00.0000000' AS DateTime2), 0, 16)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (23, N'203979301', N'Quang Bao Pham', CAST(N'2000-03-30T00:00:00.0000000' AS DateTime2), 0, 17)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (24, N'203979301', N'Quang Bao Pham', CAST(N'2000-03-30T00:00:00.0000000' AS DateTime2), 0, 20)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (25, N'204797102', N'Phuong Nguyen Thi', CAST(N'2002-04-28T00:00:00.0000000' AS DateTime2), 0, 20)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (26, N'203979301', N'Quang Bao Pham', CAST(N'2000-03-30T00:00:00.0000000' AS DateTime2), 0, 62)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (27, N'204797102', N'Phuong Nguyen Thi', CAST(N'2002-04-28T00:00:00.0000000' AS DateTime2), 0, 62)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (28, N'', N'Quang Minh Pham', CAST(N'2015-04-28T00:00:00.0000000' AS DateTime2), 1, 62)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (29, N'203979301', N'Quang Bao Pham', CAST(N'2000-03-30T00:00:00.0000000' AS DateTime2), 0, 63)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (30, N'204797102', N'Phuong Nguyen Thi', CAST(N'2002-04-28T00:00:00.0000000' AS DateTime2), 0, 63)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (31, N'', N'Quang Minh Pham', CAST(N'2015-04-28T00:00:00.0000000' AS DateTime2), 1, 63)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (32, N'206282345', N'Quoc Dat Ngo Luu', CAST(N'2000-10-18T00:00:00.0000000' AS DateTime2), 0, 64)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (33, N'204362562', N'Xuan Toan Mai', CAST(N'2000-09-08T00:00:00.0000000' AS DateTime2), 0, 64)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (34, N'', N'Quang Minh Pham', CAST(N'2015-04-28T00:00:00.0000000' AS DateTime2), 1, 64)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (35, N'', N'Xuan Khai Mai', CAST(N'2015-05-10T00:00:00.0000000' AS DateTime2), 1, 64)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (36, N'206282345', N'Quoc Dat Ngo Luu', CAST(N'2000-10-18T00:00:00.0000000' AS DateTime2), 0, 69)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (37, N'201234765', N'Cong Tai Dinh', CAST(N'2000-05-19T00:00:00.0000000' AS DateTime2), 0, 69)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (38, N'201234765', N'Cong Khoi Dinh', CAST(N'2016-04-30T00:00:00.0000000' AS DateTime2), 1, 69)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (39, N'206282345', N'Quoc Dat Ngo Luu', CAST(N'2000-10-18T00:00:00.0000000' AS DateTime2), 0, 70)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (40, N'204363563', N'An Nguyen', CAST(N'2000-09-10T00:00:00.0000000' AS DateTime2), 0, 70)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (41, N'204363444', N'Bao Pham', CAST(N'2011-07-06T00:00:00.0000000' AS DateTime2), 1, 70)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (42, N'123456789', N'Tuan Dang', CAST(N'2011-04-29T00:00:00.0000000' AS DateTime2), 1, 70)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (59, N'123', N'Dat NGO', CAST(N'1998-05-05T00:00:00.0000000' AS DateTime2), 0, 87)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (60, N'123', N'Dat NGO', CAST(N'1994-05-04T00:00:00.0000000' AS DateTime2), 0, 87)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (61, N'123', N'Dat NGO', CAST(N'2012-05-08T00:00:00.0000000' AS DateTime2), 1, 87)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (78, N'123321', N'Dat NGO', CAST(N'2000-10-18T00:00:00.0000000' AS DateTime2), 0, 104)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (79, N'345543', N'Khoi Luu', CAST(N'2006-11-11T00:00:00.0000000' AS DateTime2), 1, 104)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (80, N'123', N'Quốc Đạt Ngo Lưu', CAST(N'2000-10-18T00:00:00.0000000' AS DateTime2), 0, 105)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (82, N'205383060', N'Quang Bao Pham', CAST(N'2000-03-30T00:00:00.0000000' AS DateTime2), 0, 107)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (83, N'250363285', N'Van An Ho', CAST(N'2000-09-10T00:00:00.0000000' AS DateTime2), 0, 107)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (84, N'206283562', N'Anh Tai Ngo Dien', CAST(N'2000-02-01T00:00:00.0000000' AS DateTime2), 0, 108)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (85, N'206287247', N'Duy Lam', CAST(N'2000-06-26T00:00:00.0000000' AS DateTime2), 0, 108)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (86, N'206284321', N'Nghia Vo', CAST(N'2000-06-29T00:00:00.0000000' AS DateTime2), 0, 108)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (87, N'206285362', N'Nguyen Tran', CAST(N'2000-05-25T00:00:00.0000000' AS DateTime2), 0, 108)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (88, N'206263560', N'Thong Huynh', CAST(N'2000-10-20T00:00:00.0000000' AS DateTime2), 0, 108)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (89, N'208287593', N'Vien Lam', CAST(N'2002-11-15T00:00:00.0000000' AS DateTime2), 0, 108)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (90, N'206283345', N'Cong Tai Dinh', CAST(N'2000-05-19T00:00:00.0000000' AS DateTime2), 0, 109)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (91, N'206282265', N'Bao Pham', CAST(N'2000-03-30T00:00:00.0000000' AS DateTime2), 0, 109)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (92, N'206285360', N'An Ho', CAST(N'2000-09-10T00:00:00.0000000' AS DateTime2), 0, 109)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (93, N'206282562', N'Dat Ngo', CAST(N'2000-11-17T00:00:00.0000000' AS DateTime2), 0, 109)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (94, N'123', N'Duy Lam', CAST(N'2000-06-29T00:00:00.0000000' AS DateTime2), 0, 110)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (95, N'321', N'Ngan Nguyen', CAST(N'2000-06-14T00:00:00.0000000' AS DateTime2), 0, 110)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (96, N'789987', N'Xuan Toan Mai', CAST(N'1999-06-10T00:00:00.0000000' AS DateTime2), 0, 111)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (97, N'201456789', N'Cong Tai Dinh', CAST(N'2000-06-08T00:00:00.0000000' AS DateTime2), 0, 112)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (98, N'201789456', N'Quoc Tuan Dang', CAST(N'1990-06-09T00:00:00.0000000' AS DateTime2), 0, 112)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1110, N'C1739097', N'Quang Bao Pham', CAST(N'2000-07-19T00:00:00.0000000' AS DateTime2), 0, 1124)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1111, N'206282345', N'Dat NGO', CAST(N'2000-10-18T00:00:00.0000000' AS DateTime2), 0, 1124)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1112, N'C1739097', N'Quang Bao TEST Pham', CAST(N'1999-07-13T00:00:00.0000000' AS DateTime2), 0, 1125)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1113, N'E3832842C', N'Quang Bao Pham', CAST(N'2000-09-19T00:00:00.0000000' AS DateTime2), 0, 1126)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1114, N'E3832842C', N'Quang Bao  Pham', CAST(N'1996-10-10T00:00:00.0000000' AS DateTime2), 0, 1127)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1115, N'AA6342205', N'Quoc Dat Ngo Luu', CAST(N'2000-10-18T00:00:00.0000000' AS DateTime2), 0, 1128)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1116, N'C1739097', N'Thai Duy Lam', CAST(N'2000-10-19T00:00:00.0000000' AS DateTime2), 0, 1129)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1117, N'C1739097', N'Thai Duy Lam', CAST(N'2000-05-11T00:00:00.0000000' AS DateTime2), 0, 1130)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1118, N'AA4250546', N'Thai Duy Lam', CAST(N'2000-08-15T00:00:00.0000000' AS DateTime2), 0, 1131)
INSERT [dbo].[OrderMembers] ([Id], [IdentityNum], [FullName], [DateOfBirth], [IsChild], [OrderId]) VALUES (1119, N'AA6474058', N'Xuan Toan Mai', CAST(N'2000-08-11T00:00:00.0000000' AS DateTime2), 0, 1132)
SET IDENTITY_INSERT [dbo].[OrderMembers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (1, CAST(N'2022-03-29T00:00:00.0000000' AS DateTime2), 2, 1, N'confirmed', NULL, N'Dinh Cong Tai', N'0945501905', N'braddinh1952000@gmail.com', 1, 3, CAST(N'2022-03-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-29T00:00:00.0000000' AS DateTime2), N'123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', N'123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 89, 30)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (2, CAST(N'2022-03-29T00:00:00.0000000' AS DateTime2), 2, 0, N'confirmed', NULL, N'Dinh Cong Tai', N'0945501905', N'braddinh1952000@gmail.com', 2, 3, CAST(N'2022-03-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-04T16:13:18.1318865' AS DateTime2), N'123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', N'CustomerPoint&160 Tran Nhat Duat, Cam Chau, Hoi An&Hoi An', NULL, N'', 180, 50)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (5, CAST(N'2022-03-31T00:00:00.0000000' AS DateTime2), 3, 1, N'confirmed', NULL, N'Dinh Cong Tai', N'0945501905', N'bradding1952000@gmail.com', 3, 3, CAST(N'2022-04-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-31T00:00:00.0000000' AS DateTime2), N'123 DT605, Hoa Tien Ward, Hoa Vang District, Da Nang City', N'56 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 500, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (6, CAST(N'2022-04-01T00:00:00.0000000' AS DateTime2), 2, 0, N'canceled', NULL, N'Dinh Cong Tai', N'0945501905', N'braddinh1952000@gmail.com', 4, 3, CAST(N'2022-04-02T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-01T00:00:00.0000000' AS DateTime2), N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 62, 20)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (10, CAST(N'2022-04-13T21:52:43.8242020' AS DateTime2), 3, 1, N'confirmed', NULL, N'Van An Ho', N'0914666555', N'hovanan10092000@gmail.com', 6, 7, CAST(N'2022-04-14T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-14T17:09:17.6917114' AS DateTime2), N'56 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', N'56 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 280, 100)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (11, CAST(N'2022-04-13T22:18:35.9047553' AS DateTime2), 2, 1, N'canceled', NULL, N'Van An Ho', N'0914666555', N'hovanan10092000@gmail.com', 4, 7, CAST(N'2022-04-16T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-14T17:09:14.0579897' AS DateTime2), N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 62, 20)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (12, CAST(N'2022-04-13T22:20:03.4424228' AS DateTime2), 2, 1, N'canceled', NULL, N'Van An Ho', N'0914666555', N'hovanan10092000@gmail.com', 1, 7, CAST(N'2022-04-16T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-14T17:05:22.9352631' AS DateTime2), N'123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', N'123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 89, 30)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (16, CAST(N'2022-04-16T14:26:19.8480184' AS DateTime2), 1, 0, N'confirmed', NULL, N'Anh Tai Ngo Dien', N'0778725981', N'anhtaiha12@gmail.com', 2, 6, CAST(N'2022-04-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-05T16:32:40.7928845' AS DateTime2), N'123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', N'CustomerPoint&160 Tran Nhat Duat, Cam Chau, Hoi An&Hoi An', NULL, N'', 180, 50)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (17, CAST(N'2022-04-16T16:51:20.6399229' AS DateTime2), 1, 0, N'pending', NULL, N'Quang Bao Pham', N'0905123321', N'bao2032000@gmail.com', 6, 5, CAST(N'2022-04-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-09T14:00:52.6104465' AS DateTime2), N'56 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', N'56 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 280, 100)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (20, CAST(N'2022-04-18T21:48:51.9145978' AS DateTime2), 2, 0, N'pending', NULL, N'Quang Bao Pham', N'0905123321', N'bao2032000@gmail.com', 3, 5, CAST(N'2022-04-18T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-22T10:04:22.6569611' AS DateTime2), N'123 DT605, Hoa Tien Ward, Hoa Vang District, Da Nang City', N'56 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 500, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (62, CAST(N'2022-04-22T16:10:50.3312166' AS DateTime2), 2, 1, N'confirmed', NULL, N'Quang Bao Pham', N'0905123321', N'bao2032000@gmail.com', 4, 5, CAST(N'2022-04-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-04T17:08:20.1487405' AS DateTime2), N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 62, 20)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (63, CAST(N'2022-04-22T16:11:01.9333394' AS DateTime2), 2, 1, N'confirmed', NULL, N'Quang Bao Pham', N'0905123321', N'bao2032000@gmail.com', 4, 5, CAST(N'2022-04-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-04T17:21:11.8203024' AS DateTime2), N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 62, 20)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (64, CAST(N'2022-05-04T21:14:54.5088060' AS DateTime2), 2, 2, N'canceled', NULL, N'Quoc Dat Ngo Luu', N'0905553859', N'ngoluuquocdat@gmail.com', 1, 4, CAST(N'2022-05-07T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-04T21:16:54.3639575' AS DateTime2), N'123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', N'123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', NULL, N'', 89, 30)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (69, CAST(N'2022-05-16T16:21:16.8926063' AS DateTime2), 2, 1, N'confirmed', NULL, N'Quoc Dat Ngo Luu', N'0905553859', N'ngoluuquocdat@gmail.com', 2, 4, CAST(N'2022-05-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T22:07:17.0353736' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An &Hoi An', N'CustomerPoint&2/20 Le Loi, Minh An &Hoi An', NULL, N'', 180, 50)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (70, CAST(N'2022-05-17T15:57:34.7502510' AS DateTime2), 2, 2, N'pending', NULL, N'Quoc Dat Ngo Luu', N'0905553859', N'ngoluuquocdat@gmail.com', 2, 4, CAST(N'2022-05-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-17T15:57:34.7502532' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An &Hoi An', N'CustomerPoint&2/20 Le Loi, Minh An &Hoi An', NULL, N'', 180, 50)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (87, CAST(N'2022-05-18T15:07:50.2379351' AS DateTime2), 2, 1, N'confirmed', NULL, N'Quoc Dat Ngo Luu', N'0905553859', N'ngoluuquocdat@gmail.com', 2, 4, CAST(N'2022-06-02T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-18T15:13:58.2277615' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An &Hoi An', N'CustomerPoint&2/20 Le Loi, Minh An &Hoi An', NULL, N'', 180, 50)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (104, CAST(N'2022-05-19T23:01:27.4720987' AS DateTime2), 1, 1, N'canceled', NULL, N'Quoc Dat Ngo Luu', N'0905553859', N'ngoluuquocdat@gmail.com', 4, 4, CAST(N'2022-05-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-19T23:04:06.8984922' AS DateTime2), N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', N'123321', N'3V026608GH432503D - REFUNDED', 62, 20)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (105, CAST(N'2022-05-20T08:29:00.3177761' AS DateTime2), 1, 0, N'canceled', NULL, N'Quoc Dat Ngo Luu', N'0905553859', N'ngoluuquocdat@gmail.com', 8, 4, CAST(N'2022-06-07T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T22:16:45.2720083' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An &Nha Trang', N'CustomerPoint&2/20 Le Loi, Minh An &Nha Trang', N'123321', N'2N1484231C968241W - REFUNDED', 38, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (107, CAST(N'2022-05-26T14:28:09.6223744' AS DateTime2), 2, 0, N'confirmed', NULL, N'Quang Bao Pham', N'0905123321', N'bao2032000@gmail.com', 8, 5, CAST(N'2022-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-26T14:28:09.6223790' AS DateTime2), N'CustomerPoint&60 Quang Trung, Minh An &Nha Trang', N'CustomerPoint&60 Quang Trung, Minh An &Nha Trang', N'205383060', N'4D429039ML721171U', 38, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (108, CAST(N'2022-06-06T10:53:20.2006813' AS DateTime2), 6, 0, N'confirmed', NULL, N'Anh Tai Ngo Dien', N'0778725981', N'anhtaiha12@gmail.com', 8, 6, CAST(N'2022-06-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-06T10:53:20.2006967' AS DateTime2), N'CustomerPoint&60 Quang Trung, Minh An &Nha Trang', N'CustomerPoint&60 Quang Trung, Minh An &Nha Trang', N'206283562', N'4HL28134NF555122P', 38, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (109, CAST(N'2022-06-06T11:02:41.8894267' AS DateTime2), 4, 0, N'confirmed', NULL, N'Cong Tai Dinh', N'0945501905', N'braddinh1952000@gmail.com', 8, 3, CAST(N'2022-06-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-06T11:02:41.8894280' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An &Nha Trang', N'CustomerPoint&2/20 Le Loi, Minh An &Nha Trang', N'206283345', N'4H980686PD9506422', 38, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (110, CAST(N'2022-06-13T09:56:42.0973221' AS DateTime2), 2, 0, N'canceled', NULL, N'Thai Duy Lam', N'0764132745', N'duylam2906@gmail.com', 8, 8, CAST(N'2022-06-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-13T10:00:47.7733320' AS DateTime2), N'CustomerPoint&69 Quang Trung, Minh An &Nha Trang', N'CustomerPoint&69 Quang Trung, Minh An &Nha Trang', N'123', N'5RW22797L4761735F - REFUNDED', 40, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (111, CAST(N'2022-06-16T15:34:21.3096651' AS DateTime2), 1, 0, N'confirmed', NULL, N'Xuan Toan Mai', N'0783803087', N'xuantoan2401@gmail.com', 2, 9, CAST(N'2022-06-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-16T15:34:21.3096679' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An &Hoi An', N'CustomerPoint&2/20 Le Loi, Minh An &Hoi An', N'789987', N'8KX64768K14504549', 180, 50)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (112, CAST(N'2022-06-16T16:07:12.3228339' AS DateTime2), 2, 0, N'confirmed', NULL, N'Cong Tai Dinh', N'0945501905', N'braddinh1952000@gmail.com', 4, 3, CAST(N'2022-06-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-16T16:07:12.3228372' AS DateTime2), N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', N'201456789', N'8E613131E9036313N', 62, 20)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (1124, CAST(N'2022-07-03T11:02:36.6642768' AS DateTime2), 2, 0, N'confirmed', NULL, N'Quang Bao Pham', N'0905123321', N'bao2032000@gmail.com', 16, 5, CAST(N'2022-07-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-03T11:02:36.6642799' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An &Hue', N'CustomerPoint&2/20 Le Loi, Minh An &Hue', N'C1739097', N'153876545U978900H', 47, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (1125, CAST(N'2022-07-03T11:28:39.9872651' AS DateTime2), 1, 0, N'canceled', NULL, N'Quang Bao TEST Pham', N'0905123321', N'bao2032000@gmail.com', 16, 5, CAST(N'2022-07-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-03T11:31:42.5525186' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An &Hue', N'CustomerPoint&2/20 Le Loi, Minh An &Hue', N'C1739097', N'1M03376781266550M - REFUNDED', 47, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (1126, CAST(N'2022-07-06T09:26:27.5047664' AS DateTime2), 1, 0, N'canceled', NULL, N'Quang Bao Pham', N'0905123321', N'bao2032000@gmail.com', 12, 5, CAST(N'2022-07-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-06T09:28:38.2452501' AS DateTime2), N'CustomerPoint&30 Cua Dai, Cam Chau&Da Nang', N'CustomerPoint&30 Cua Dai, Cam Chau&Da Nang', N'E3832842C', N'16W68527N5279711R - REFUNDED', 106, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (1127, CAST(N'2022-07-06T09:30:31.5175370' AS DateTime2), 1, 0, N'confirmed', NULL, N'Quang Bao Pham', N'0905123321', N'bao2032000@gmail.com', 11, 5, CAST(N'2022-07-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-06T09:30:31.5175390' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An &Hue', N'CustomerPoint&2/20 Le Loi, Minh An &Hue', N'E3832842C', N'6SD5934958949960Y', 89, 40)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (1128, CAST(N'2022-07-06T09:35:15.4419562' AS DateTime2), 1, 0, N'confirmed', NULL, N'Quoc Dat Ngo Luu', N'0905553859', N'ngoluuquocdat@gmail.com', 13, 4, CAST(N'2022-07-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-06T09:35:15.4419591' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An&Hue', N'CustomerPoint&2/20 Le Loi, Minh An&Hue', N'AA6342205', N'4SS76228AV7428243', 63, 30)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (1129, CAST(N'2022-07-06T09:43:13.1706329' AS DateTime2), 1, 0, N'confirmed', NULL, N'Thai Duy Lam', N'0764132745', N'duylam2906@gmail.com', 13, 8, CAST(N'2022-07-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-06T09:43:13.1706345' AS DateTime2), N'CustomerPoint&30 Cua Dai, Cam Chau&Hue', N'CustomerPoint&30 Cua Dai, Cam Chau&Hue', N'C1739097', N'7P340889VD2776319', 63, 30)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (1130, CAST(N'2022-07-06T09:47:06.5892693' AS DateTime2), 1, 0, N'confirmed', NULL, N'Thai Duy Lam', N'0764132745', N'duylam2906@gmail.com', 16, 8, CAST(N'2022-07-31T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-06T09:47:06.5892706' AS DateTime2), N'CustomerPoint&2/20 Le Loi, Minh An &Hue', N'CustomerPoint&2/20 Le Loi, Minh An &Hue', N'C1739097', N'2VP69580JB2437052', 47, -1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (1131, CAST(N'2022-07-06T09:58:09.7680434' AS DateTime2), 1, 0, N'confirmed', NULL, N'Thai Duy Lam', N'0764132745', N'duylam2906@gmail.com', 11, 8, CAST(N'2022-07-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-06T09:58:09.7680475' AS DateTime2), N'CustomerPoint&69 Quang Trung, Minh An&Hue', N'CustomerPoint&69 Quang Trung, Minh An&Hue', N'AA4250546', N'1XE33984HE766330V', 89, 40)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Adults], [Children], [State], [CancelReason], [TouristName], [TouristPhone], [TouristEmail], [TourId], [UserId], [DepartureDate], [ModifiedDate], [EndPoint], [StartPoint], [TouristIdentityNum], [TransactionId], [PricePerAdult], [PricePerChild]) VALUES (1132, CAST(N'2022-07-06T10:01:25.8024366' AS DateTime2), 1, 0, N'confirmed', NULL, N'Xuan Toan Mai', N'0783803087', N'xuantoan2401@gmail.com', 11, 9, CAST(N'2022-07-30T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-06T10:01:25.8024386' AS DateTime2), N'CustomerPoint&69 Quang Trung, Minh An &Hue', N'CustomerPoint&69 Quang Trung, Minh An &Hue', N'AA6474058', N'31R42608VA373942V', 89, 40)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[PlaceImages] ON 

INSERT [dbo].[PlaceImages] ([Id], [Url], [PlaceId]) VALUES (1, N'/storage/hoian.jpg', 3)
INSERT [dbo].[PlaceImages] ([Id], [Url], [PlaceId]) VALUES (2, N'/storage/hoian2.jpg', 3)
INSERT [dbo].[PlaceImages] ([Id], [Url], [PlaceId]) VALUES (3, N'/storage/hoian3.jpg', 3)
INSERT [dbo].[PlaceImages] ([Id], [Url], [PlaceId]) VALUES (4, N'/storage/hoian4.jpg', 3)
SET IDENTITY_INSERT [dbo].[PlaceImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Places] ON 

INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (1, N'Da Nang', N'/storage/danang.jpg', N'Da Nang’s fast reinventing itself as Vietnam’s most hip and modern city and is building an impressive collection of superlatives; one of the best beaches in the world (as voted for by Forbes Magazine); the longest cable car in the world at Ba Na Hill Station; some of the rarest monkeys in the world atop Monkey Mountain; one of the tallest Lady Buddha statues in Vietnam; one of the highest wheels in the world-The Sun Wheel , plus the highest Sky Bar in Vietnam, on the 35th floor of the gleaming Novatel Da Nang Han River Hotel.&The Fire-breathing Dragon.&Vietnam’s third biggest city is home to no less than 8 modern bridges, the most impressive of which is The Dragon Bridge (Cau Rong), who guards the city and breathes fire at weekends. The city’s clean, coconut-tree-fringed, river-side boulevard is lined with ultra-modern hotels, apartments and restaurants.&Beaches, Buddhas, Monkeys and Mountains.&Over the eastside of the city is where the stunning My Khe Beach stretches around 40kms from the foot of Monkey Mountain to the ancient town of Hoi An. To the north is Monkey Mountain, home to some of the rarest monkeys in the world; and Vietnam’s version of Rio’s ‘Christ the Redeemer’, a Lady Buddha statue that stands at nearly 70 meters tall. To the south are the five Marble Mountains and a smattering of luxurious, beachside 5 star hotels. All the way in between is a sublime stretch of coastline, gloriously devoid of tourists, with a wide selection of seafood restaurants located close to the sea.', CAST(16.047079000 AS Decimal(18, 9)), CAST(108.206230000 AS Decimal(18, 9)), N'/storage/DaNang360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (2, N'Hue', N'/storage/hue.jpg', N'Hue: Palaces, Pagodas, Tombs & Temples.&Vietnam’s ancient imperial capital is another of the nation’s Unesco World Heritage sites and was home to Nguyen emperors and royalty who left behind a treasure-trove of palaces, pagodas, tombs and temples dating back to the 1800’s.&Despite the ravages of time and war (Hue was badly battered during the Vietnam/ American War) there is still plenty of beauty to behold, highlights include the fortified Citadel, surrounded by moats, 2m thick, 10km long walls which encase the Imperial Enclosure, the Forbidden Purple City and the Emperor’s Private Residence; the opulent Royal Tombs where the former emperors of the Nguyen Dynasty are buried; the seven-storey hilltop-located Thien Mu Pagoda, an active Buddhist monastery, infamous for the monk who drove from here to Sai Gon and set himself alight as a political protest against cruel treatment of Buddhist monks and their followers (the car he drove is displayed here); and a boat-trip along the pretty Perfume River.&Fantastic food thanks to a Fussy Emperor.&Hue is also renowned for its high quality and varied food which is attributed to its famously fussy eater Emperor Tu Duc. Local delicacies include Royal Rice Cakes (Banh Khoai) and the spicy noodle dish, Bun Bo Hue. These specialties as well as national dishes, French favourites, and a variety of western food are can be found in the many eateries of the city ranging from upmarket French-style Villas to casual cafes and of course, street food stalls favoured by locals and tourists alike.', CAST(16.463713000 AS Decimal(18, 9)), CAST(107.590866000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (3, N'Hoi An', N'/storage/hoian.jpg', N'Possibly the most beautiful town in Vietnam and definitely the most atmospheric heritage town, Hoi An (which means ‘peaceful place’ in Vietnamese) has the perfect combination of old-world charm and modern-day comforts and luxuries. This historical town is gloriously devoid of high-rises and ugly concrete buildings thanks to its Unesco World Heritage Site status. Chinese merchant shop fronts dating as far back as the 15th Century encase shops, restaurants, art galleries, museums and especially tailors, ensuring Hoi An has something to suit all tastes.&What really makes Hoi An live up to its ‘peaceful place’ name is the blissful ban on motorbikes and scooters in the old town during certain parts of the day and most of the evening.&The Venice of Vietnam.&One of the biggest factors in creating the rich cultural history that brings such a special ambience to Hoi An, is the river that it’s built around. The ‘Thu Bon’ river has been responsible for bringing in foreign traders and settlers from far-flung places for hundreds of years and brings a beautiful, romantic, ‘Venice of Vietnam’ quality to the town.&A Culinary Mecca & Shopper’s Paradise.&Several centuries of foreign trade has influenced the local cuisine as well as the architecture, earning Hoi An the reputation as a culinary mecca. Hoi An’s narrow streets offer a dazzling array of eateries ranging from traditional local cuisine to regional favourites, western fare and just about everything in between.&Hoi An is also a heaven for shopaholics; talented tailors can whip up bespoke suits, dresses, skirts and shirts for a fraction of the price they’d cost back home.', CAST(15.879440000 AS Decimal(18, 9)), CAST(108.335000000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (4, N'Ha Long', N'/storage/halong.jpg', N'', CAST(20.959902000 AS Decimal(18, 9)), CAST(107.042542000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (5, N'Ha Noi', N'/storage/hanoi.jpg', N'', CAST(21.028511000 AS Decimal(18, 9)), CAST(105.804817000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (6, N'Ho Chi Minh', N'/storage/hochiminh.jpg', N'', CAST(10.762622000 AS Decimal(18, 9)), CAST(106.660172000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (7, N'Da Lat', N'/storage/dalat.jpg', N'', CAST(11.940419000 AS Decimal(18, 9)), CAST(108.458313000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (8, N'Nha Trang', N'/storage/nhatrang.jpg', N'', CAST(12.245070000 AS Decimal(18, 9)), CAST(109.194320000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (9, N'Phu Quoc', N'/storage/phuquoc.jpg', N'', CAST(10.289879000 AS Decimal(18, 9)), CAST(103.984020000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (10, N'Quy Nhon', N'/storage/quynhon.jpg', N'', CAST(13.759660000 AS Decimal(18, 9)), CAST(109.206123000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (11, N'Sa Pa', N'/storage/sapa.jpg', N'', CAST(22.356464000 AS Decimal(18, 9)), CAST(103.873802000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (12, N'Vung Tau', N'/storage/vungtau.jpg', N'', CAST(10.541740000 AS Decimal(18, 9)), CAST(107.242998000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (13, N'Mui Ne', N'/storage/muine.jpg', N'', CAST(10.933211000 AS Decimal(18, 9)), CAST(108.287184000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (14, N'Con Dao', N'/storage/condao.jpg', N'', CAST(8.683270000 AS Decimal(18, 9)), CAST(106.606000000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
INSERT [dbo].[Places] ([Id], [PlaceName], [ThumbnailUrl], [Description], [Latitude], [Longitude], [OverviewVideoUrl]) VALUES (15, N'Trang An', N'/storage/trangan.jpg', N'', CAST(20.256667000 AS Decimal(18, 9)), CAST(105.896389000 AS Decimal(18, 9)), N'/storage/HoiAn360.mp4')
SET IDENTITY_INSERT [dbo].[Places] OFF
GO
SET IDENTITY_INSERT [dbo].[ProviderRegistrations] ON 

INSERT [dbo].[ProviderRegistrations] ([Id], [UserId], [ProviderName], [ContactPersonName], [ProviderEmail], [ProviderPhone], [DateCreated], [IsApproved], [IsRejected]) VALUES (1, 4, N'Quoc Dat Travel', N'Dat Ngo', N'ngoluuquocdat@gmail.com', N'+10905553859', CAST(N'2022-05-30T09:42:41.9449932' AS DateTime2), 0, 0)
INSERT [dbo].[ProviderRegistrations] ([Id], [UserId], [ProviderName], [ContactPersonName], [ProviderEmail], [ProviderPhone], [DateCreated], [IsApproved], [IsRejected]) VALUES (2, 7, N'Green Travel Viet', N'Ho Van An', N'anvanho1009@gmail.com', N'0914625981', CAST(N'2022-05-30T15:41:36.3738076' AS DateTime2), 1, 0)
INSERT [dbo].[ProviderRegistrations] ([Id], [UserId], [ProviderName], [ContactPersonName], [ProviderEmail], [ProviderPhone], [DateCreated], [IsApproved], [IsRejected]) VALUES (3, 3, N'Cong Tai Tourism', N'Dinh Cong Tai', N'congtaidinh@gmail.com', N'0914613822', CAST(N'2022-06-16T14:32:55.5062059' AS DateTime2), 0, 0)
INSERT [dbo].[ProviderRegistrations] ([Id], [UserId], [ProviderName], [ContactPersonName], [ProviderEmail], [ProviderPhone], [DateCreated], [IsApproved], [IsRejected]) VALUES (5, 5, N'Quang Bao Travel', N'Pham Quang Bao', N'quangbaowork@gmail.com', N'0938982319', CAST(N'2022-06-28T14:27:24.8322432' AS DateTime2), 0, 0)
SET IDENTITY_INSERT [dbo].[ProviderRegistrations] OFF
GO
SET IDENTITY_INSERT [dbo].[Providers] ON 

INSERT [dbo].[Providers] ([Id], [ProviderName], [ProviderPhone], [ProviderEmail], [DateCreated], [Address], [Description], [AvatarUrl], [IsEnabled]) VALUES (1, N'Hoi An Express', N'0905123456', N'info@hoianexpress.com.vn', CAST(N'2022-03-28T00:00:00.0000000' AS DateTime2), N'32 Tien Giang St, 08 Ward, Tan Binh District, Ho Chi Minh City', N'Established in 2002, Hoi An Express is a company specializing in organizing professional tours for foreign visitors to Vietnam to visit tours, conferences, events combined with team building.', N'/storage/b645561c-9ad5-4887-8709-cccbb39d4534.jpg', 1)
INSERT [dbo].[Providers] ([Id], [ProviderName], [ProviderPhone], [ProviderEmail], [DateCreated], [Address], [Description], [AvatarUrl], [IsEnabled]) VALUES (5, N'Green Travel Viet', N'0914625981', N'anvanho1009@gmail.com', CAST(N'2022-05-30T15:44:03.4181872' AS DateTime2), N'44 Hoang Quoc Viet Str, An Dong Ward, Hue City, Thua Thien Hue Province', N'Green Travel Viet is one of the leading tourist companies in Vietnam - has been granted the International Travel License No: 46 - 010/2014/TCDL – GPLHQT by the Vietnam National Administration of Tourism. Green Travel Viet with an experience in inbound, domestic travel. Specialized in organizing all kinds of quality tours for individuals and groups throughout Vietnam as well as in the other countries of Asia such as Laos, Thailand, Malaysia, Singapore, and etc.', N'/storage/ccc2282e-36cc-4dfb-9d7f-68b8af0fa4f0.jpg', 1)
SET IDENTITY_INSERT [dbo].[Providers] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (1, N'This is a good tour! A lot of interesting experiences.', CAST(N'2022-03-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-29T00:00:00.0000000' AS DateTime2), 4, 3, 1)
INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (2, N'I love it! Had a really relaxing time.', CAST(N'2022-04-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-01T00:00:00.0000000' AS DateTime2), 4, 3, 2)
INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (3, N'Great experience, especially for the young! ', CAST(N'2022-04-08T15:20:22.4165357' AS DateTime2), CAST(N'2022-04-08T15:28:27.7221661' AS DateTime2), 5, 4, 1)
INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (4, N'The itinerary is not good.', CAST(N'2022-04-12T13:03:45.4614233' AS DateTime2), CAST(N'2022-04-12T13:03:45.4614260' AS DateTime2), 2, 3, 6)
INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (5, N'Nice!', CAST(N'2022-04-12T13:08:08.2951600' AS DateTime2), CAST(N'2022-04-12T13:10:49.6158519' AS DateTime2), 3, 4, 6)
INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (6, N'Nice!', CAST(N'2022-04-12T13:17:25.9698628' AS DateTime2), CAST(N'2022-04-12T13:17:25.9698652' AS DateTime2), 4, 3, 7)
INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (7, N'Pretty good!', CAST(N'2022-04-12T15:40:40.0535947' AS DateTime2), CAST(N'2022-04-19T11:35:25.2802282' AS DateTime2), 3, 5, 6)
INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (8, N'I drank very much!', CAST(N'2022-04-13T16:22:59.9577203' AS DateTime2), CAST(N'2022-04-13T16:23:18.1980786' AS DateTime2), 4, 3, 3)
INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (9, N'I love it.', CAST(N'2022-04-22T16:09:02.3629148' AS DateTime2), CAST(N'2022-04-22T16:09:45.3047748' AS DateTime2), 5, 5, 4)
INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (10, N'I love Hue!', CAST(N'2022-06-01T14:39:14.5850277' AS DateTime2), CAST(N'2022-06-01T14:39:14.5850302' AS DateTime2), 4, 6, 6)
INSERT [dbo].[Reviews] ([Id], [Content], [DateCreated], [DateModified], [Rating], [UserId], [TourId]) VALUES (11, N'I love Nha Trang!', CAST(N'2022-06-27T20:27:04.8941816' AS DateTime2), CAST(N'2022-06-27T20:27:04.8941828' AS DateTime2), 4, 5, 8)
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (2, N'Provider')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (3, N'Tourist')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (4, N'Hotel_Owner')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [Name], [Description], [MaxAdults], [Area], [Stock], [Price], [Views], [SmokingAllowed], [HotelId]) VALUES (1, N'Standard Double or Twin Room', N'This double room features a electric kettle, air conditioning and tile/marble floor.&', 2, 25, 4, 50, N'None', 0, 1)
INSERT [dbo].[Rooms] ([Id], [Name], [Description], [MaxAdults], [Area], [Stock], [Price], [Views], [SmokingAllowed], [HotelId]) VALUES (2, N'Superior Double or Twin Room', N'This twin room features a minibar, tile/marble floor and electric kettle.&', 3, 25, 4, 54, N'None', 0, 1)
INSERT [dbo].[Rooms] ([Id], [Name], [Description], [MaxAdults], [Area], [Stock], [Price], [Views], [SmokingAllowed], [HotelId]) VALUES (3, N'Grand Deluxe', N'Located on the ground floor, air-conditioned rooms feature Eastern designs and traditional Vietnamese lanterns. There is a private balcony that leads to the garden. En suite bathroom comes with a bathtub and separate shower facility.&', 2, 55, 8, 144, N'Garden View', 0, 2)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[SubTouristSites] ON 

INSERT [dbo].[SubTouristSites] ([Id], [SiteName], [Description], [HighLights], [Province], [District], [Ward], [Address], [OpenCloseTime], [Longitude], [Latitude], [PlaceId], [OverviewVideoUrl]) VALUES (1, N'Tra Que Vegetable Village', N'Tra Que Vegetable Village is a land formed from the 17th to 18th centuries, located in Tra Que village, Cam Ha commune, about 2.5km north of the center of Hoi An ancient town.The village is famous for many aromatic products with strong flavors grown by traditional intensive farming methods, fertilized with seaweed from Tra Que lagoon, so it has turned the green vegetables here green and fragrant.&Coming to Tra Que vegetable village, visitors will enjoy the rustic and peaceful natural picture of a vast vegetable-growing area, participate in farmer experience tours with farm work: hoeing. soil, fertilizing weeds, watering dandruff, manually processing and enjoying delicious rustic dishes made from green vegetables.', N'Aside from visiting the Japanese Bridge Hoi An, visitors can participate in folk games and watch street performances from 7:00 p.m. to 8:30 p.m. every day in Old Town.&The best time to visit the monument is from 9:00 a.m. – 3:00 p.m., when it is less crowded.&Tourists should hire a tour guide to maximize their experience. The tour guides will tell you the exact location of the bridge, explain the history and the special architecture of the bridge specifically.&Visitors should experience a cruise trip on a bamboo boat along the canal at night. With beautiful lights, vibrant and nostalgic atmosphere, you can feel every subtle feature of Old Town.', N'Quang Nam', N'Hoi An', N'Cam Ha', N'', N'8:00 AM - 6:00 PM', CAST(108.337593300 AS Decimal(18, 9)), CAST(15.902420200 AS Decimal(18, 9)), 3, N'/storage/ChuaCau360p.mp4')
INSERT [dbo].[SubTouristSites] ([Id], [SiteName], [Description], [HighLights], [Province], [District], [Ward], [Address], [OpenCloseTime], [Longitude], [Latitude], [PlaceId], [OverviewVideoUrl]) VALUES (2, N'Japanese Covered Bridge', N'Covered Bridge, located adjacent to Nguyen Thi Minh Khai Street and Tran Phu Street - Hoi An, also known as Japanese Bridge, is a work built by Japanese merchants who came to Hoi An to trade in the early seventeenth century. More than 400 years ago. Experiencing the ups and downs of time, the building still retains great values of architecture, culture and history, showing the connection between Vietnamese-Japanese communities-- Flowers at the ancient trading port of Hoi An are invaluable assets of generations of Hoi An people and have been officially chosen as the symbol of the city.&The bridge has a roof with a rather unique architecture, in the middle is a rainbow-style passageway, on both sides there is a narrow corridor, used as a place for trade and relaxation. The main side of the pagoda faces the poetic Hoai River. It''s called the pagoda, but the residents worship the Bac De god Tran Vo - the god associated with the water treatment function, bringing a peaceful life, favorable rain and wind for the residents. resident community. The pagoda and bridge are made of wood, painted with lipstick and carved with elaborate and harmonious motifs. The two ends of the bridge have two pairs of wooden statues, one end is a dog statue, one end is a monkey statue with many unique interpretations of local residents. In 1719, on a weekly tour to Hoi An, Lord Nguyen Phuc Chu bestowed three words "Lai Vien Kieu" with the meaning of welcoming guests from afar, which is still solemnly placed at the entrance of the temple today.&Covered Bridge relic was recognized as a national historical - cultural relic in 1990. Currently, Covered Bridge is an indispensable attraction of any visitor when coming to Hoi An ancient town. The image of the project was also selected to be printed on the VND 20,000 banknote issued by the State Bank of Vietnam in 2006.', N'Aside from visiting the Japanese Bridge Hoi An, visitors can participate in folk games and watch street performances from 7:00 p.m. to 8:30 p.m. every day in Old Town.&The best time to visit the monument is from 9:00 a.m. – 3:00 p.m., when it is less crowded.&Tourists should hire a tour guide to maximize their experience. The tour guides will tell you the exact location of the bridge, explain the history and the special architecture of the bridge specifically.&Visitors should experience a cruise trip on a bamboo boat along the canal at night. With beautiful lights, vibrant and nostalgic atmosphere, you can feel every subtle feature of Old Town.', N'Quang Nam', N'Hoi An', N'Minh An', N'Tran Phu St', N'8:00 AM - 9:30 PM', CAST(108.309301000 AS Decimal(18, 9)), CAST(15.877190000 AS Decimal(18, 9)), 3, N'/storage/ChuaCau360.mp4')
INSERT [dbo].[SubTouristSites] ([Id], [SiteName], [Description], [HighLights], [Province], [District], [Ward], [Address], [OpenCloseTime], [Longitude], [Latitude], [PlaceId], [OverviewVideoUrl]) VALUES (3, N'Hoi An Ancient Town', N'Formed and developed from the sixteenth to seventeenth centuries, the ancient town of Hoi An used to be one of the busiest international trading ports in Southeast Asia. This place is considered as the center of goods exchange of Eurasian traders from China, Japan, Siam, India or the Netherlands, Spain, England, France... organized by form of international fairs from 4 to 6 consecutive months per year according to the monsoon regime. Therefore, Hoi An is considered a land of convergence, interference and acculturation of many East - West cultures.&Hoi An ancient town is famous for its typical architecture of the traditional trading port of Asia, which is preserved almost intact. According to statistics, Hoi An currently preserves 1,360 relics relatively intact, including many types: houses, clan churches, communal houses, pagodas, temples, assembly halls, ancient wells, harbors, markets.&Experiencing many ups and downs of history, the flow of time covers Hoi An with a peaceful and contemplative beauty. Hoi An impresses visitors with mossy yin-yang tiled houses, ancient dusty walls and colorful lanterns. Walking around the old town, visitors will have the opportunity to visit relics dating back hundreds of years, immerse themselves in the festive atmosphere of "Old Town Night" with folk games, listen to chants and sing songs. huts, ho drills... or simply, stop at a small roadside shop to enjoy the specialties of Hoi An.&On December 4, 1999, Hoi An Ancient Town was registered by UNESCO in the list of world cultural heritages. Up to now, Hoi An has become a famous destination in the journey of discovering Vietnam and the Central region of domestic and foreign tourists.', N'Aside from visiting the Japanese Bridge Hoi An, visitors can participate in folk games and watch street performances from 7:00 p.m. to 8:30 p.m. every day in Old Town.&The best time to visit the monument is from 9:00 a.m. – 3:00 p.m., when it is less crowded.&Tourists should hire a tour guide to maximize their experience. The tour guides will tell you the exact location of the bridge, explain the history and the special architecture of the bridge specifically.&Visitors should experience a cruise trip on a bamboo boat along the canal at night. With beautiful lights, vibrant and nostalgic atmosphere, you can feel every subtle feature of Old Town.', N'Quang Nam', N'Hoi An', N'Minh An', N'', N'8:00 AM - 10:00 PM', CAST(108.328215100 AS Decimal(18, 9)), CAST(15.878223000 AS Decimal(18, 9)), 3, N'/storage/PhoCo360.mp4')
INSERT [dbo].[SubTouristSites] ([Id], [SiteName], [Description], [HighLights], [Province], [District], [Ward], [Address], [OpenCloseTime], [Longitude], [Latitude], [PlaceId], [OverviewVideoUrl]) VALUES (4, N'Hoi An Museum of History and Culture', N'Hoi An Museum of History - Culture is a large-scale work, located at 10B Tran Hung Dao, Hoi An city, where displays more than 800 original artifacts and valuable documents in ceramics, porcelain, bronze. iron, paper, wood...reflecting the development stages of the urban - commercial port of Hoi An from the period of Sa Huynh culture (from the 2nd century AD) to the period of Champa culture (from the 1st century AD) II to 15th century) to the period of Dai Viet and Dai Nam cultures (from the 15th to the 19th century), as well as the history of the city''s people''s revolutionary struggle (since the French colonialists invaded to invade Vietnam). 1858 to the great victory in the spring of 1975).&Hoi An Museum of History - Culture will help visitors get an overview of the historical process as well as the cultural thickness of the land of Hoi An. The museum is currently open every day of the week, and is closed on the 25th of every month to carry out professional work.', N'Aside from visiting the Japanese Bridge Hoi An, visitors can participate in folk games and watch street performances from 7:00 p.m. to 8:30 p.m. every day in Old Town.&The museum is closed on the 25th of every month to carry out professional work.&They have an old canon, two thousand year old pottery from the Sa Huynh period, and artifacts that date back to the 9th century Champa Kingdom.', N'Quang Nam', N'Hoi An', N'Minh An', N'10B Tran Hung Dao', N'8:00 AM - 6:00 PM', CAST(108.329510000 AS Decimal(18, 9)), CAST(15.880360000 AS Decimal(18, 9)), 3, N'/storage/ChuaCau360.mp4')
INSERT [dbo].[SubTouristSites] ([Id], [SiteName], [Description], [HighLights], [Province], [District], [Ward], [Address], [OpenCloseTime], [Longitude], [Latitude], [PlaceId], [OverviewVideoUrl]) VALUES (5, N'Thanh Ha Pottery Village', N'Thanh Ha Pottery Village is located on the banks of the Thu Bon River, about 3 km west of Hoi An center. This is a stopover for tourists on their travel journey connecting Hoi An Ancient Town to My Son Temples. The village was formed at the end of the 15th century, associated with the migration process from Thanh Hoa, Hai Duong and Nam Dinh localities, bringing with them the traditional pottery craft from the ancestral homeland. Thanks to favorable terrain and rich clay raw materials, the first inhabitants of Thanh Ha village gave birth to pottery making here.&Today, coming to Thanh Ha Pottery Village, visitors can visit a traditional Vietnamese village space that is preserved in its original state in terms of landscape with banyan trees, water wharf, communal courtyard, religious monuments, children tiled alleys… and admire first-hand the talented and skillful hands of the inhabitants of the pottery village who are hard at work creating valuable, characteristic products of the craft village. You will find here gifts that are rustic but attractive.', N'Aside from visiting the Japanese Bridge Hoi An, visitors can participate in folk games and watch street performances from 7:00 p.m. to 8:30 p.m. every day in Old Town.&The best time to visit the monument is from 9:00 a.m. – 3:00 p.m., when it is less crowded.&Tourists should hire a tour guide to maximize their experience. The tour guides will tell you the exact location of the bridge, explain the history and the special architecture of the bridge specifically.&Visitors should experience a cruise trip on a bamboo boat along the canal at night. With beautiful lights, vibrant and nostalgic atmosphere, you can feel every subtle feature of Old Town.', N'Quang Nam', N'Hoi An', N'Thanh Ha', N'', N'8:00 AM - 6:00 PM', CAST(108.298910300 AS Decimal(18, 9)), CAST(15.876806500 AS Decimal(18, 9)), 3, N'/storage/ChuaCau360p.mp4')
SET IDENTITY_INSERT [dbo].[SubTouristSites] OFF
GO
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (3, 1)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (4, 1)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (11, 1)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (12, 1)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (3, 2)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (11, 3)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (1, 4)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (17, 4)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (16, 5)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (1, 7)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (1, 8)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (3, 8)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (17, 8)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (1, 11)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (2, 11)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (7, 11)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (13, 11)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (2, 12)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (4, 12)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (7, 12)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (8, 12)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (13, 12)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (4, 13)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (6, 13)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (7, 13)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (8, 13)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (11, 13)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (12, 13)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (6, 15)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (7, 15)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (6, 16)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (7, 19)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (3, 20)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (4, 20)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (12, 21)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (7, 23)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (12, 27)
INSERT [dbo].[TourCategories] ([TourId], [CategoryId]) VALUES (16, 29)
GO
SET IDENTITY_INSERT [dbo].[TourImages] ON 

INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1, N'/storage/tour11.jpg', 1)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (2, N'/storage/tour12.jpg', 1)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (3, N'/storage/tour13.jpg', 1)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (4, N'/storage/tour14.jpg', 1)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (5, N'/storage/tour21.jpg', 2)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (6, N'/storage/tour22.jpg', 2)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (7, N'/storage/tour23.jpg', 2)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (8, N'/storage/tour24.jpg', 2)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (9, N'/storage/b1a3663a-4c3e-4bc7-b500-f277e97b1e2c.jpg', 3)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (10, N'/storage/036140bf-a118-4a43-b265-aaa54bb548ab.jpg', 3)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (11, N'/storage/5e21c5c3-38da-4f8f-a1c3-a488247496ec.jpg', 3)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (12, N'/storage/670c8775-cded-48f1-881a-599151fc7cc6.jpg', 3)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (13, N'/storage/c90b8a20-6f9e-466a-8920-01719975f788.jpg', 4)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (14, N'/storage/56aeae35-d456-4e72-8070-63117f5ad473.jpg', 4)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (15, N'/storage/5f9e7568-7f6f-40e9-85a9-440fcea342d3.jpg', 4)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (16, N'/storage/a7f3de50-9f67-4081-a638-338d6610bf4f.jpg', 4)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (17, N'/storage/945ca310-ae9b-44fb-a22e-f5e40b19e91b.jpg', 4)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (18, N'/storage/9a20b9fb-86b5-4681-b254-af9272eef8c3.jpg', 4)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (24, N'/storage/d7247b4a-9ce3-45e1-8ccd-8bd8f16c13ac.jpg', 6)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (25, N'/storage/95e35e9d-ea33-45b1-863d-4e77a82de50f.jpg', 6)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (26, N'/storage/86b89c70-c724-44ec-b95d-245dc1bad64f.jpg', 6)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (27, N'/storage/26c335f7-6039-4e6e-ba5c-a4c14d010b2a.jpg', 6)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (28, N'/storage/ccb377ce-d10f-4d05-b41d-1d5ab95a0096.jpg', 6)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (29, N'/storage/3b33248b-d615-4456-bd27-095588b69c0e.jpg', 7)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (30, N'/storage/197a75a7-0aca-4943-933d-59bd42426111.jpg', 7)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (31, N'/storage/07ba29d6-64e0-4efe-8cb3-01b53faa695b.jpg', 7)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (32, N'/storage/359264d9-a155-4d65-98d1-e4450ea7bc8c.jpg', 7)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (33, N'/storage/48a5d4b7-9312-42ad-81a6-d175508bf0ae.jpg', 7)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (34, N'/storage/3ecb1c7e-2aab-477c-acb8-aabb0986f94d.jpg', 7)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (35, N'/storage/e9c8fed3-005e-4a0d-b350-d620bc96ebf7.jpg', 3)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (36, N'/storage/fcaafe97-37ab-48d0-8c46-360a0b8975f6.jpg', 8)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (37, N'/storage/70331ace-428b-46ef-9c4a-19d7b7745859.jpg', 8)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (38, N'/storage/3ba7d7b8-59ca-463c-b657-7088848aa7d2.jpg', 8)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (39, N'/storage/a6894ad7-3c57-4683-a859-17c96d556aae.jpg', 8)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1042, N'/storage/8a64e2c0-fede-4d4d-ac9a-63c6a7ee3ddd.jpg', 11)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1043, N'/storage/e0eaccca-56c4-4d7e-9ccf-93301a2c6680.jpg', 11)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1044, N'/storage/d9b113ad-8c89-490a-9aea-bfdd42a8348b.jpg', 11)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1045, N'/storage/14dfd806-8333-4870-8fbe-95eab6358f89.jpg', 11)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1046, N'/storage/d8a78191-f98a-4b11-a5f4-deb0c6dec86e.jpg', 12)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1047, N'/storage/79a799b1-ce6b-4513-96d7-27c169d41079.jpg', 12)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1048, N'/storage/d992bc3d-4bb2-48e5-949b-2f8932457a17.jpg', 12)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1049, N'/storage/f17d729c-a575-4dbd-bea7-e913287263b6.jpg', 13)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1050, N'/storage/256ef5b9-7dd9-4b3b-b7d6-99e55c7ab82f.jpg', 13)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1051, N'/storage/4b2a7bea-5a5f-4cfb-aa0c-96d2aa6a7a7d.jpg', 13)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1052, N'/storage/014e4fd1-66b6-4e61-bb73-3b9af991b947.jpg', 13)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1057, N'/storage/09a132a6-a564-48e6-b253-d3fa9e540172.jpg', 16)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1058, N'/storage/7d9e3d1e-9d47-4cb9-a940-76511e801475.jpg', 16)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1059, N'/storage/df9dfb71-7457-4808-bcdc-392e31be9f85.jpg', 17)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1060, N'/storage/7de33461-9464-4e87-9795-f67c5f002bcf.jpg', 17)
INSERT [dbo].[TourImages] ([Id], [Url], [TourId]) VALUES (1061, N'/storage/e248cd54-3d1d-478a-836e-48314d6d40c5.jpg', 17)
SET IDENTITY_INSERT [dbo].[TourImages] OFF
GO
SET IDENTITY_INSERT [dbo].[TouristSiteImages] ON 

INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (1, N'/storage/traque1.jpg', 1)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (2, N'/storage/traque2.jpg', 1)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (3, N'/storage/traque3.jpg', 1)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (4, N'/storage/traque4.jpg', 1)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (5, N'/storage/chuacau1.jpg', 2)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (6, N'/storage/chuacau2.jpg', 2)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (7, N'/storage/chuacau3.jpg', 2)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (8, N'/storage/chuacau4.jpg', 2)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (9, N'/storage/phocoha1.jpg', 3)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (10, N'/storage/phocoha2.jpg', 3)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (11, N'/storage/phocoha3.jpg', 3)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (12, N'/storage/phocoha4.jpg', 3)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (13, N'/storage/baotangha1.jpg', 4)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (14, N'/storage/baotangha2.jpg', 4)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (15, N'/storage/baotangha3.jpg', 4)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (16, N'/storage/baotangha4.jpg', 4)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (18, N'/storage/thanhha1.jpg', 5)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (19, N'/storage/thanhha2.jpg', 5)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (20, N'/storage/thanhha3.jpg', 5)
INSERT [dbo].[TouristSiteImages] ([Id], [Url], [SubTouristSiteId]) VALUES (21, N'/storage/thanhha4.jpg', 5)
SET IDENTITY_INSERT [dbo].[TouristSiteImages] OFF
GO
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (3, 1)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (7, 1)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (12, 1)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (6, 2)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (11, 2)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (12, 2)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (13, 2)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (16, 2)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (1, 3)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (2, 3)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (3, 3)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (4, 3)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (6, 3)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (7, 3)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (17, 3)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (7, 4)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (7, 5)
INSERT [dbo].[TourPlaces] ([TourId], [PlaceId]) VALUES (8, 8)
GO
SET IDENTITY_INSERT [dbo].[Tours] ON 

INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (1, N'HALF-DAY FOODIE TOUR BY BICYCLE & VISIT TRA QUE VEGETABLE VILLAGE', N'Take a journey through Hoi An’s culinary history; head out to the beautiful countryside by bicycle to experience some traditional local food favorites, including the most famous of Hoi An specialties; Cao Lau. Try the traditional Hoi An specialty, Cao Lau; intoxicating pork noodle broth, featuring sticky rice noodles that must be soaked in water from the oldest well in Hoi An, Ba Le Well.', 0.5, 15, 2, N'123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', N'123 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', 89, 30, 0, 1, 10, 1, N'8:00 AM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (2, N'Private Tour: HOI AN MYSTERIOUS NIGHT TOUR WITH DINNER FROM HOI AN', N'Have a memorable end to your day in Hoi An with a tour of the ancient town after the sun goes down. See the centuries-old houses and monuments illuminated by local lanterns. Visit a traditional restaurant for dinner', 0.125, 15, 1, N'CustomerPoint&3&Hoi An', N'CustomerPoint&3&Hoi An', 180, 50, 1, 1, 5, 1, N'5:00 PM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (3, N'Overnight Party at Tuan''s house', N'Party overnight at Tuan''s house. You can eat as you have never eaten before, drink as you have never drunk before, and have fun like an insane person. 
You will forget about your life, your problems,... Just enjoy the fun.', 0.333333343, 5, 1, N'56 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', N'123 DT605, Hoa Tien Ward, Hoa Vang District, Da Nang City', 500, -1, 1, 1, 0, 1, N'8:00 AM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (4, N'HALF-DAY HOI AN COUNTRYSIDE ADVENTURE BY ELECTRIC SCOOTER', N'A unique eco-tour experience exploring Hoi An’s captivating countryside on a comfortable electric scooter. Discover some of Hoi An’s most beautiful hidden spots, meet locals and learn first-hand about their daily routines. This is the only scooter tour in Vietnam where clients can legally drive themselves!', 0.5, 15, 1, N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', N'56 Le Loi Minh An Ward, Hoi An City, Quang Nam Province', 62, 20, 0, 1, 0, 1, N'8:00 AM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (6, N'TWO-DAY HUE HERITAGE  FROM HOI AN', N'This is one history lesson you will not want to miss! A two-day journey through Vietnam’s eventful past that starts in the fascinating imperial era and ends in the infamous war-time history of Vietnam.', 2, 15, 1, N'56 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', N'56 Le Loi, Minh An Ward, Hoi An City, Quang Nam Province', 280, 100, 0, 1, 0, 1, N'8:00 AM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (7, N'8 DAYS NORTH TO CENTRAL OF VIETNAM', N'Discover all the incredible sights of Vietnam on a comprehensive eight-day tour from North to Central of Vietnam! Discover must see Golden Bridge, Hoi An Old City, Ha Noi and Ha Long Bay overnight and more.

This option is 3*Hotel twin/shared room. If  you can upgarde to 4-5* Hotel or single room please enquire for pricing.', 8, 15, 1, N'Noi Bai International Airport, Phu Minh Ward, Soc Son District, Ha Noi City', N'Hoa Thuan Tay Ward, Hai Chau District, Da Nang City', 559, 250, 0, 1, 0, 1, N'8:00 AM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (8, N'HALF-DAY NHA TRANG CITY TOUR', N'A half-day tour that gives you insight into some of Nha Trang’s most important architectural, cultural and historical sites. Gain insight into Vietnamese culture as you watch intricate hand-woven embroidery created before your eyes at XQ Hand Embroidery Factory. View the city from its best angle at Long Son Pagoda, home to a huge Buddha statue and some stunning views of the city and its surrounds. Gain insight into the fascinating ancient civilization of the Hindu-worshipping Cham as you wander around Cham Ponagar Temple Complex.', 0.5, 15, 1, N'CustomerPoint&8&Nha Trang', N'CustomerPoint&8&Nha Trang', 38, -1, 0, 1, 0, 1, N'8:00 AM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (11, N'FULL-DAY HAI VAN PASS, LANG CO BEACH & TRUOI VILLAGE FROM HUE CITY', N'Take a trip to discover one of the most beautiful areas of Vietnam; from the charming Truc Lam Bach Ma to the iconic Hai Van Pass and to the pristine beautiful Lang Co Beach. Visiting the green Truoi Lake and charming Truc Lam Bach Ma Zen Monastery. Stop at the stunning Lang Co Beach, with its gradually sloping, white sand beach and warm shallow water. Drive through the lush landscape of the highest mountain pass road in the country, the iconic Hai Van Pass. Enjoy Lap An Lagoon''s beauty - the fairy realm in the ancient capital of Hue.', 1, 15, 1, N'CustomerPoint&2&Hue', N'CustomerPoint&2&Hue', 89, 40, 0, 1, 0, 5, N'8:00 AM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (12, N'FULL-DAY BACH MA NATIONAL PARK TREKKING TOUR FROM DA NANG', N'A one-day trekking adventure through the lush depths of Bach Ma National Park; past lakes and lagoons, streams and waterfalls, exotic flora and fauna, jungle, cliff, and mountain; including a short beach retreat at stunning Lang Co. Bach Ma National Park has a diversity of flora and fauna as well as naturally beautiful landscapes to explore. Another interesting sight is the old villas that remain in the jungle despite being damaged in the American War and reclaimed by nature. Bach Ma is a great place for panoramic views of natural wonders including Cau Hai Lagoon and Chan May Port.', 1, 15, 1, N'CustomerPoint&1&Da Nang', N'CustomerPoint&1&Da Nang', 106, -1, 0, 1, 0, 5, N'7:30 AM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (13, N'FOOD TOUR IN HUE CITY', N'The destination is the famous specialty dishes of Hue. You will also have the opportunity to see the Hue streets, the daily life of the Vietnamese people and more specifically the opportunity to own beautiful images. You can taste Hue''s local food, and learn about the culinary and culture of Hue.', 0.125, 10, 1, N'CustomerPoint&2&Hue', N'CustomerPoint&2&Hue', 63, 30, 0, 1, 0, 5, N'6:00 PM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (16, N'HALF-DAY TAM GIANG LAGOON FROM HUE CITY', N'This tour is for travelers who like exploring and hunting for amazing photos. This trip will bring you new experiences such as learning about fisherman’s life, enjoy at local food, a boat trip on Tam Giang Lagoon, and exploring the Hue countryside. Deep into the immense blue water of Tam Giang Lagoon exists not only the world of aquatic creatures but also mysterious stories of the spiritual life of the local people in the Tam Giang Lagoon area. You will be overwhelmed by the image of the shrine worshipping the water nymph and the branches of red plan trees swinging at dusk on the bank of Tam Giang Lagoon.', 1, 15, 1, N'CustomerPoint&2&Hue', N'CustomerPoint&2&Hue', 47, -1, 0, 1, 0, 5, N'8:30 AM')
INSERT [dbo].[Tours] ([Id], [TourName], [Overview], [Duration], [GroupSize], [MinAdults], [StartPoint], [EndPoint], [PricePerAdult], [PricePerChild], [IsPrivate], [IsAvailable], [ViewCount], [ProviderId], [StartTime]) VALUES (17, N'HALF-DAY FOODIE TEST TEST TEST', N'HALF-DAY FOODIE TEST TEST TESTHALF-DAY FOODIE TEST TEST TEST', 0.166666672, 10, 1, N'CustomerPoint&3&Hoi An', N'CustomerPoint&3&Hoi An', 100, -1, 0, 1, 0, 1, N'8:00 AM')
SET IDENTITY_INSERT [dbo].[Tours] OFF
GO
SET IDENTITY_INSERT [dbo].[TravelTips] ON 

INSERT [dbo].[TravelTips] ([Id], [Title], [Content], [PlaceId]) VALUES (1, N'Transportations in Hoi An', N'You can visit Hoi An by taxi, motorbike, bicycle, cyclo, or walking. If you choose to use a motorbike, remember to know clearly about some streets where the motorbikes are crossing prohibited. In the evening, it will be great if you walk along the Thu Bon river to admire the stunning beauty of Hoi An at night. Another choice that you can go by cyclo but when walking you can save your expenses and enjoy street foods here.', 3)
INSERT [dbo].[TravelTips] ([Id], [Title], [Content], [PlaceId]) VALUES (2, N'Should pay in VND', N'Some hotels, restaurants, and shops may accept payment in USD, but you should always pay in VND. If something is priced in VND, then you should definitely pay for it in VND because using any other currency will lead to terrible exchange rates. As advised, the best place to get VND in Hoi An is at gold/jewelry shops and banks, or from ATMs.', 3)
INSERT [dbo].[TravelTips] ([Id], [Title], [Content], [PlaceId]) VALUES (3, N'Weather in Hoi An', N'If you are visiting during the hot summer months, don’t forget to hydrate. In summer, the temperature can reach 34-37C. Made sure each of us had 2L bottle of water and drank all of it by the end of each day. The best time to visit Hoi An is from February to July, with low rainfall and amicable weather. The period from May to July can be extremely hot, but with the cool breeze from the ocean and the low intensity of buildings, Hoi An is just as nice to visit.', 3)
INSERT [dbo].[TravelTips] ([Id], [Title], [Content], [PlaceId]) VALUES (4, N'Dress sensibly', N'T-shirts and shorts are okay almost anywhere, but it’s preferable to wear longer trousers and cover your shoulders if you’re visiting temples and other holy places. Likewise, bikinis and swim-shorts are fine on the beach, but refrain from dressing scantily in towns or on the street.', 3)
INSERT [dbo].[TravelTips] ([Id], [Title], [Content], [PlaceId]) VALUES (5, N'Weather in Da Nang', N'Da Nang is a great destination year-round. However, the best months to visit are from March to May and September to October, when the weather is warm. June to August sees little rain and the sea is clear and calm. The rainy season from November to February brings long rains and moody weather.', 1)
INSERT [dbo].[TravelTips] ([Id], [Title], [Content], [PlaceId]) VALUES (6, N'Transportations', N'The Da Nang International Airport has several daily connections to major cities in Vietnam. There are also a growing number of international connecting flights. Trains and buses pass through Da Nang, making it a convenient travel hub to explore the central region. In town, taxis are abundant, as well as ride-hailing apps.', 1)
INSERT [dbo].[TravelTips] ([Id], [Title], [Content], [PlaceId]) VALUES (8, N'Where to stay', N'If you want to stay close to the downtown area, you can choose hotels along the Han River. Most are hotels with reasonable prices, modern facilities, safety and reputation. Here, you only take about 5 minutes to walk to the Han River. If you want to stay in a 5-star luxury resort, there are many choices for you such as: Furama Resort, Olalany, Alacate, Muong Thanh Hotel...', 1)
INSERT [dbo].[TravelTips] ([Id], [Title], [Content], [PlaceId]) VALUES (9, N'Best time to visit', N'Unlike northern Vietnam that has four seasons, central Vietnam only has two – wet (Sept-Jan) and dry (Feb-Aug). Hue has a similar climate to Hoi An and Da Nang so the best time to visit, in terms of the weather, is from February till April. Another factor to consider when planning a trip to Hue is the Tet holiday or Vietnamese New Year celebration. This is held sometime between the end of January and early February. Many businesses will be shuttered during this time and hotel rates will be at their highest.', 2)
INSERT [dbo].[TravelTips] ([Id], [Title], [Content], [PlaceId]) VALUES (10, N'Best areas to stay', N'The best hotels you can find in Hue gather along three main streets: Nguyen Hue, Le Loi, and especially Hung Vuong. If you’re not on a budget and you’re aiming to enjoy your trip to the fullest, then feel free to pick any accommodation you like along the street of Le Loi, right along the bank of the Perfume River. Otherwise, a look around some lodges near the Hue Walking Street or Trang Tien Bridge gives you some more fine options too. If you prefer history, then it’s a good idea to stay in the Citadel. If you prefer food, then it’s best to stay across the river in the Vinh Ninh/Phu Hoi areas.', 2)
INSERT [dbo].[TravelTips] ([Id], [Title], [Content], [PlaceId]) VALUES (11, N'What to pack', N'It would be a mistake to travel in the area without either a travel umbrella or rain poncho handy. Also, a fleece jacket or windbreaker should be in your backpack as the nights can be cooler. As the weather in Hue can be very hot and humid, it is important to stay hydrated. Therefore a water bottle, sunscreen, and a hat are the must-haves.', 2)
SET IDENTITY_INSERT [dbo].[TravelTips] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 2)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 2)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (7, 2)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (3, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (4, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (5, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (6, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (7, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (8, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (9, 3)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (8, 4)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (9, 4)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [PasswordSalt], [FirstName], [LastName], [Phone], [Email], [AvatarUrl], [ProviderId], [IsEnabled], [HotelId]) VALUES (1, N'admin', 0xC0C40A42443C98F60CCFC203235B606805543BA8106AA71B013B1BF79789F9F2888693ABCE245B799CF8013E3FAF9D12D3AC47E7599C1614112F18821FEBC5AA, 0x0C684700CDCE6047F0AFB79783F4CE944E2BB592F802D83D108FCCBCAEDB6F8D8899A88596F3A375A892B8BBB862A22D9164D44109133D283A85C34363655FE141F481D4CE7A74E5D067EA55DD5CD08BB2E0035E354FDE440A546F1CDC51500F2E57C044A21EF824AA628040F4F6776C5E3065FE95D2100E17034C854CC47DD8, N'Quoc Dat', N'Ngo Luu', N'0905553859', N'ngoluuquocdat@gmail.com', NULL, NULL, 1, NULL)
INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [PasswordSalt], [FirstName], [LastName], [Phone], [Email], [AvatarUrl], [ProviderId], [IsEnabled], [HotelId]) VALUES (2, N'quoctuan', 0xB96FBB1078CD651B81346462E3284711C4F7FF89B601727F83E92B0830CC4EADC00CB463E94B1FD57FBF179E6BA8D53076FFAAD4C6D6A435C33ADC24048372A9, 0x0C684700CDCE6047F0AFB79783F4CE944E2BB592F802D83D108FCCBCAEDB6F8D8899A88596F3A375A892B8BBB862A22D9164D44109133D283A85C34363655FE141F481D4CE7A74E5D067EA55DD5CD08BB2E0035E354FDE440A546F1CDC51500F2E57C044A21EF824AA628040F4F6776C5E3065FE95D2100E17034C854CC47DD8, N'Quoc Tuan', N'Dang', N'0921231220', N'tuandang29042000@gmail.com', N'/storage/tuan.jpg', 1, 1, NULL)
INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [PasswordSalt], [FirstName], [LastName], [Phone], [Email], [AvatarUrl], [ProviderId], [IsEnabled], [HotelId]) VALUES (3, N'congtai', 0x232B240A9B7DA7168E7D2CDC4BA15D6027C1A2649BE40BB9011F244B631C13859430D46B5343EB9EDC0D6CFA4BCC3EB031B7E24DAC6E8C5E4516D922687DFDF2, 0x0C684700CDCE6047F0AFB79783F4CE944E2BB592F802D83D108FCCBCAEDB6F8D8899A88596F3A375A892B8BBB862A22D9164D44109133D283A85C34363655FE141F481D4CE7A74E5D067EA55DD5CD08BB2E0035E354FDE440A546F1CDC51500F2E57C044A21EF824AA628040F4F6776C5E3065FE95D2100E17034C854CC47DD8, N'Cong Tai', N'Dinh', N'0945501905', N'braddinh1952000@gmail.com', N'/storage/tai.jpg', NULL, 0, NULL)
INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [PasswordSalt], [FirstName], [LastName], [Phone], [Email], [AvatarUrl], [ProviderId], [IsEnabled], [HotelId]) VALUES (4, N'quocdat', 0xF98899D50981120B1EE67B7ED2366FE3BF610D4A48D5E476FA2F3B735DCA51F75CE110342F20CD30C0DE253FB5A1838C52F1FD1304F5635505E02A20145D50C8, 0x0C684700CDCE6047F0AFB79783F4CE944E2BB592F802D83D108FCCBCAEDB6F8D8899A88596F3A375A892B8BBB862A22D9164D44109133D283A85C34363655FE141F481D4CE7A74E5D067EA55DD5CD08BB2E0035E354FDE440A546F1CDC51500F2E57C044A21EF824AA628040F4F6776C5E3065FE95D2100E17034C854CC47DD8, N'Quoc Dat', N'Ngo Luu', N'0905553859', N'ngoluuquocdat@gmail.com', N'/storage/dat.jpg', NULL, 1, NULL)
INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [PasswordSalt], [FirstName], [LastName], [Phone], [Email], [AvatarUrl], [ProviderId], [IsEnabled], [HotelId]) VALUES (5, N'quangbao', 0x9A906AF8B6179EC46E3C01C40B3EA4D8785ED2CAFB72C144B14427F564578F5E4655A8E484CAB91F865791A1E5E06E2190BD356684924ACCCFBC9CD3E65D0CE9, 0xDB9E356C61F9E359EB785A530900AE00FBA218B63364F5149F9DAAD73911BB2F008C85DD390D98C4252A95155E4E7C10922EFFB77129921E37541343F5DBBBF2FB8C10A10353578A4985615562DDF8FCCD8A4CAA43B6D0EF119EDB14633236C21FD6F9237F981DB9C97C5F1DDE6BB03E0CCC0DA1491F63FECBA43D7381DD1B0E, N'Quang Bao', N'Pham', N'0905123321', N'bao2032000@gmail.com', N'/storage/blank_avatar.png', NULL, 1, NULL)
INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [PasswordSalt], [FirstName], [LastName], [Phone], [Email], [AvatarUrl], [ProviderId], [IsEnabled], [HotelId]) VALUES (6, N'anhtai', 0xF036EF3A578B5F928B273AF95533DF142F02BA50FF597520B8B088D7EC853F338B8A68F8387AF7719E91E426E95E5E60F75FC6D084C73EC1A3A05E5586D2BD6A, 0xADA0C445BA2A205ED8129FCD3D150A71B56ADF20AB747CEB6C3BDB16E1B5F50960BB784874C63F6F1ADFCC045883E5C2FB7332396647B91BD48A50E6E193AB7BE1701B0917660F2B159F109B86607A22515A9823D0A649E3CFFE91D5D2A522E5AE8ADE8BF99CFF0BDF2737F84CEE842F979DE07BBC470DDC02E21C72B07545D5, N'Anh Tai', N'Ngo Dien', N'0778725981', N'anhtaiha12@gmail.com', N'/storage/ae0d4f76-a0ac-4671-b4fc-8e14f01a0a9f.png', NULL, 0, NULL)
INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [PasswordSalt], [FirstName], [LastName], [Phone], [Email], [AvatarUrl], [ProviderId], [IsEnabled], [HotelId]) VALUES (7, N'vanan', 0x3F052C5730C725F4C046417418A6035F4F8301B85731C174EA7C403CD64F2C5A6D4653639106DB3BFB9C6CA7FEA859FCBEE3EAB1FC381C9F15242C6653BB1E2B, 0xE34853B4475BDA600A9BD66C4F27F32915027976A238A8FFE0F7D2ED2DE9E2A1F89F77002DDEE14FB2165883F188017CFB20D74572342445E73CDAA321C33B6E8FD0B8EC09924E4D34BE35EE44CA5215281905EE1C1B0CB51FDFD69CC3D406715721840551D5537B74031D7EDFD224FEA1A134290EC4440D097DCDB64854A8A4, N'Van An', N'Ho', N'0914666555', N'hovanan10092000@gmail.com', N'/storage/9285018e-ce93-4e63-bcd6-0c9049fe4415.jpg', 5, 1, NULL)
INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [PasswordSalt], [FirstName], [LastName], [Phone], [Email], [AvatarUrl], [ProviderId], [IsEnabled], [HotelId]) VALUES (8, N'thaiduy', 0x77911DCE144484874783AE26597C283293D7EE19238EEBD81BF3298EED2D543881F540A6EE5E42638D89501E96DA0C6FC9F429603827F6B21202700F8C0C226B, 0x0C684700CDCE6047F0AFB79783F4CE944E2BB592F802D83D108FCCBCAEDB6F8D8899A88596F3A375A892B8BBB862A22D9164D44109133D283A85C34363655FE141F481D4CE7A74E5D067EA55DD5CD08BB2E0035E354FDE440A546F1CDC51500F2E57C044A21EF824AA628040F4F6776C5E3065FE95D2100E17034C854CC47DD8, N'Thai Duy', N'Lam', N'0764132745', N'duylam2906@gmail.com', N'/storage/duy.jpg', NULL, 1, 1)
INSERT [dbo].[Users] ([Id], [Username], [PasswordHash], [PasswordSalt], [FirstName], [LastName], [Phone], [Email], [AvatarUrl], [ProviderId], [IsEnabled], [HotelId]) VALUES (9, N'xuantoan', 0xC5D1EC7C5A3A41EF2C96821425EFDC754DDEBE9007AAB6766F555D4AAED7F3EF133A9BFBA997F05BECA6D0C9033F46507487A38A460F9E2EAE81B72C7392492D, 0x0C684700CDCE6047F0AFB79783F4CE944E2BB592F802D83D108FCCBCAEDB6F8D8899A88596F3A375A892B8BBB862A22D9164D44109133D283A85C34363655FE141F481D4CE7A74E5D067EA55DD5CD08BB2E0035E354FDE440A546F1CDC51500F2E57C044A21EF824AA628040F4F6776C5E3065FE95D2100E17034C854CC47DD8, N'Xuan Toan', N'Mai', N'0783803087', N'xuantoan2401@gmail.com', N'/storage/toan.jpg', NULL, 1, 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WishItems] ON 

INSERT [dbo].[WishItems] ([Id], [UserId], [TourId], [Date]) VALUES (1, 4, 8, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[WishItems] ([Id], [UserId], [TourId], [Date]) VALUES (7, 4, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[WishItems] ([Id], [UserId], [TourId], [Date]) VALUES (8, 4, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[WishItems] ([Id], [UserId], [TourId], [Date]) VALUES (11, 6, 8, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[WishItems] ([Id], [UserId], [TourId], [Date]) VALUES (15, 9, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[WishItems] ([Id], [UserId], [TourId], [Date]) VALUES (16, 9, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[WishItems] OFF
GO
ALTER TABLE [dbo].[Messages] ADD  DEFAULT (N'') FOR [ImageUrl]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DepartureDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [EndPoint]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [StartPoint]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [TransactionId]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [PricePerAdult]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [PricePerChild]
GO
ALTER TABLE [dbo].[Places] ADD  DEFAULT ((0.0)) FOR [Latitude]
GO
ALTER TABLE [dbo].[Places] ADD  DEFAULT ((0.0)) FOR [Longitude]
GO
ALTER TABLE [dbo].[Places] ADD  DEFAULT (N'') FOR [OverviewVideoUrl]
GO
ALTER TABLE [dbo].[ProviderRegistrations] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsRejected]
GO
ALTER TABLE [dbo].[SubTouristSites] ADD  DEFAULT (N'') FOR [OverviewVideoUrl]
GO
ALTER TABLE [dbo].[Tours] ADD  DEFAULT (N'') FOR [StartTime]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetails_Bookings_BookingId] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Bookings] ([Id])
GO
ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_BookingDetails_Bookings_BookingId]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetails_Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_BookingDetails_Rooms_RoomId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Hotels_HotelId] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Hotels_HotelId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Users_UserId]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_Tours_TourId]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK_Hotels_Places_PlaceId] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Places] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK_Hotels_Places_PlaceId]
GO
ALTER TABLE [dbo].[Itineraries]  WITH CHECK ADD  CONSTRAINT [FK_Itineraries_Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Itineraries] CHECK CONSTRAINT [FK_Itineraries_Tours_TourId]
GO
ALTER TABLE [dbo].[OrderMembers]  WITH CHECK ADD  CONSTRAINT [FK_OrderMembers_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderMembers] CHECK CONSTRAINT [FK_OrderMembers_Orders_OrderId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Tours_TourId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_UserId]
GO
ALTER TABLE [dbo].[PlaceImages]  WITH CHECK ADD  CONSTRAINT [FK_PlaceImages_Places_PlaceId] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Places] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaceImages] CHECK CONSTRAINT [FK_PlaceImages_Places_PlaceId]
GO
ALTER TABLE [dbo].[ProviderRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_ProviderRegistrations_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ProviderRegistrations] CHECK CONSTRAINT [FK_ProviderRegistrations_Users_UserId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Tours_TourId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users_UserId]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Hotels_HotelId] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Hotels_HotelId]
GO
ALTER TABLE [dbo].[SubTouristSites]  WITH CHECK ADD  CONSTRAINT [FK_SubTouristSites_Places_PlaceId] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Places] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubTouristSites] CHECK CONSTRAINT [FK_SubTouristSites_Places_PlaceId]
GO
ALTER TABLE [dbo].[TourCategories]  WITH CHECK ADD  CONSTRAINT [FK_TourCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TourCategories] CHECK CONSTRAINT [FK_TourCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[TourCategories]  WITH CHECK ADD  CONSTRAINT [FK_TourCategories_Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TourCategories] CHECK CONSTRAINT [FK_TourCategories_Tours_TourId]
GO
ALTER TABLE [dbo].[TourImages]  WITH CHECK ADD  CONSTRAINT [FK_TourImages_Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TourImages] CHECK CONSTRAINT [FK_TourImages_Tours_TourId]
GO
ALTER TABLE [dbo].[TouristSiteImages]  WITH CHECK ADD  CONSTRAINT [FK_TouristSiteImages_SubTouristSites_SubTouristSiteId] FOREIGN KEY([SubTouristSiteId])
REFERENCES [dbo].[SubTouristSites] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TouristSiteImages] CHECK CONSTRAINT [FK_TouristSiteImages_SubTouristSites_SubTouristSiteId]
GO
ALTER TABLE [dbo].[TourPlaces]  WITH CHECK ADD  CONSTRAINT [FK_TourPlaces_Places_PlaceId] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Places] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TourPlaces] CHECK CONSTRAINT [FK_TourPlaces_Places_PlaceId]
GO
ALTER TABLE [dbo].[TourPlaces]  WITH CHECK ADD  CONSTRAINT [FK_TourPlaces_Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TourPlaces] CHECK CONSTRAINT [FK_TourPlaces_Tours_TourId]
GO
ALTER TABLE [dbo].[Tours]  WITH CHECK ADD  CONSTRAINT [FK_Tours_Providers_ProviderId] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Providers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tours] CHECK CONSTRAINT [FK_Tours_Providers_ProviderId]
GO
ALTER TABLE [dbo].[TravelTips]  WITH CHECK ADD  CONSTRAINT [FK_TravelTips_Places_PlaceId] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Places] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TravelTips] CHECK CONSTRAINT [FK_TravelTips_Places_PlaceId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Hotels_HotelId] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Hotels_HotelId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Providers_ProviderId] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Providers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Providers_ProviderId]
GO
ALTER TABLE [dbo].[WishItems]  WITH CHECK ADD  CONSTRAINT [FK_WishItems_Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WishItems] CHECK CONSTRAINT [FK_WishItems_Tours_TourId]
GO
ALTER TABLE [dbo].[WishItems]  WITH CHECK ADD  CONSTRAINT [FK_WishItems_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[WishItems] CHECK CONSTRAINT [FK_WishItems_Users_UserId]
GO
