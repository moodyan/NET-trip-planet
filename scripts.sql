USE [master]
GO
/****** Object:  Database [TripPlanet]    Script Date: 10/6/17 11:17:31 AM ******/
CREATE DATABASE [TripPlanet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TripPlanet', FILENAME = N'C:\Users\alyssamoody\TripPlanet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TripPlanet_log', FILENAME = N'C:\Users\alyssamoody\TripPlanet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TripPlanet] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TripPlanet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TripPlanet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TripPlanet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TripPlanet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TripPlanet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TripPlanet] SET ARITHABORT OFF 
GO
ALTER DATABASE [TripPlanet] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TripPlanet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TripPlanet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TripPlanet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TripPlanet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TripPlanet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TripPlanet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TripPlanet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TripPlanet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TripPlanet] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TripPlanet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TripPlanet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TripPlanet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TripPlanet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TripPlanet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TripPlanet] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TripPlanet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TripPlanet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TripPlanet] SET  MULTI_USER 
GO
ALTER DATABASE [TripPlanet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TripPlanet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TripPlanet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TripPlanet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TripPlanet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TripPlanet] SET QUERY_STORE = OFF
GO
USE [TripPlanet]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [TripPlanet]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/6/17 11:17:32 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Activities]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[ActivityId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Cost] [decimal](18, 2) NULL,
	[Date] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[TimeSpent] [decimal](18, 2) NULL,
	[Type] [nvarchar](max) NULL,
	[CityId] [int] NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
 CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED 
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[ArrivalDate] [datetime2](7) NULL,
	[DepartureDate] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[Duration] [int] NULL,
	[TripId] [int] NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [tinyint] NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lodgings]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lodgings](
	[LodgingId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[ArrivalDate] [datetime2](7) NULL,
	[Booked] [bit] NULL,
	[Confirmation] [nvarchar](max) NULL,
	[Cost] [decimal](18, 2) NULL,
	[DepartureDate] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[CityId] [int] NULL,
 CONSTRAINT [PK_Lodgings] PRIMARY KEY CLUSTERED 
(
	[LodgingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planners]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planners](
	[PlannerId] [int] IDENTITY(1,1) NOT NULL,
	[Birthdate] [datetime2](7) NULL,
	[FirstName] [nvarchar](max) NULL,
	[Hometown] [nvarchar](max) NULL,
	[Image] [tinyint] NULL,
	[LastName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Planners] PRIMARY KEY CLUSTERED 
(
	[PlannerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transportations]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transportations](
	[TransportationId] [int] IDENTITY(1,1) NOT NULL,
	[Booked] [bit] NULL,
	[Confirmation] [nvarchar](max) NULL,
	[Cost] [decimal](18, 2) NULL,
	[DepartureDate] [datetime2](7) NULL,
	[Mode] [nvarchar](max) NULL,
	[ArrivalCityId] [int] NULL,
	[CityId] [int] NULL,
	[TripId] [int] NULL,
 CONSTRAINT [PK_Transportations] PRIMARY KEY CLUSTERED 
(
	[TransportationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TripCities]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripCities](
	[TripId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_TripCities] PRIMARY KEY CLUSTERED 
(
	[TripId] ASC,
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trips]    Script Date: 10/6/17 11:17:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trips](
	[TripId] [int] IDENTITY(1,1) NOT NULL,
	[BeginDate] [datetime2](7) NULL,
	[Budget] [decimal](18, 2) NULL,
	[EndDate] [datetime2](7) NULL,
	[Members] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Public] [bit] NULL,
	[StartCity] [nvarchar](max) NULL,
	[TripLength] [int] NULL,
	[PlannerId] [int] NOT NULL,
 CONSTRAINT [PK_Trips] PRIMARY KEY CLUSTERED 
(
	[TripId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170816194844_Initial', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170816213213_AddManyToManyTripCity', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170816220409_OnePlannerToManyTrips', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170816221920_OneCityToManyActivitiesLodgings', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170816223256_AddManyToManyCityTransportations', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170824200304_AddLatLongColumns', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170827022256_AddUserNameColumn', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170828154743_ChangeLatLongToDouble', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170828171625_AddDurationColToCityTbl', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170828231605_AddLatLongColsToActivitiesTbl', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170829010646_AddTripIdColToCityTbl', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170829231331_AddTripIdColToTransportTbl', N'1.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170830021459_RefactorCityTransportationTblRelationship', N'1.1.2')
SET IDENTITY_INSERT [dbo].[Activities] ON 

INSERT [dbo].[Activities] ([ActivityId], [Address], [Cost], [Date], [Name], [TimeSpent], [Type], [CityId], [Latitude], [Longitude]) VALUES (14, N'08013 Barcelona, Spain', CAST(12.00 AS Decimal(18, 2)), CAST(N'2017-08-30T00:00:00.0000000' AS DateTime2), N'Sagrada Família, Barcelona, Spain', CAST(1.00 AS Decimal(18, 2)), N'Sightseeing', 1043, 41.4031163, 2.181871)
INSERT [dbo].[Activities] ([ActivityId], [Address], [Cost], [Date], [Name], [TimeSpent], [Type], [CityId], [Latitude], [Longitude]) VALUES (16, N'Hackescher Markt, 10178 Berlin, Germany', CAST(40.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Hackescher Markt, Berlin, Germany', CAST(0.00 AS Decimal(18, 2)), NULL, 1054, 52.5236903, 13.4023149)
SET IDENTITY_INSERT [dbo].[Activities] OFF
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'b0ecb1fc-a22d-44a5-8677-c22e125782e0', N'fdc3965a-1af9-4d75-b6f5-26f657aeeae0', N'user', N'USER')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'c4586875-40b4-4c7d-818e-a16771dde31f', N'25412584-4280-4fba-8591-30f65b284809', N'admin', N'ADMIN')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2ebd6d56-3d96-46f9-bd14-c9b69d30f945', N'b0ecb1fc-a22d-44a5-8677-c22e125782e0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'09d7805a-dda6-4c70-ad2c-0409c9c2597d', N'c4586875-40b4-4c7d-818e-a16771dde31f')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'09d7805a-dda6-4c70-ad2c-0409c9c2597d', 0, N'15e4b05f-8127-499e-9035-290809dc1973', N'alyssa', 0, 1, NULL, N'ALYSSA', N'ALYSSA', N'AQAAAAEAACcQAAAAEBw4xcoxJhLciHUqnWv+mkeWeZRkkbIWvb27ZMvCXy9esyvDW9t7xPbthlgwP11/1A==', NULL, 0, N'a3d2e1cd-e91f-4783-ac3c-6db31c16829c', 0, N'alyssa')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'2ebd6d56-3d96-46f9-bd14-c9b69d30f945', 0, N'18428821-991a-49f3-ad98-5f193415d69e', N'test', 0, 1, NULL, N'TEST', N'TEST', N'AQAAAAEAACcQAAAAEEhfno9AWRV0ieaF3PN8OoelJ4Y/Fevrxx6i3/QQziw1IuAXhWeEJycDGL7J9lfkpg==', NULL, 0, N'b61111f8-3fea-45ba-910c-4cf4726c7718', 0, N'test')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'bd45fc81-aff0-4fc2-bac9-bb4531404a57', 0, N'33223ede-5bc1-415c-a5cf-5b7d7538d350', N'tesstttt', 0, 1, NULL, N'TESSTTTT', N'TESSTTTT', N'AQAAAAEAACcQAAAAEKlwvMloNHO0S4Ivje5r2QTFFBk9MaLykEZrAY5msG8IgDOOZ6E/URb7pduhVyUckw==', NULL, 0, N'cb2f89a8-3129-4fc6-bca1-06724b8dd2fe', 0, N'tesstttt')
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1043, CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2), CAST(N'2017-11-02T00:00:00.0000000' AS DateTime2), N'Barcelona, Spain', 41.3850639, 2.1734035, 0, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1044, CAST(N'2017-11-02T00:00:00.0000000' AS DateTime2), CAST(N'2017-11-04T00:00:00.0000000' AS DateTime2), N'Rome, Metropolitan City of Rome, Italy', 41.9027835, 12.4963655, 0, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1046, CAST(N'2017-11-16T00:00:00.0000000' AS DateTime2), CAST(N'2017-11-18T00:00:00.0000000' AS DateTime2), N'Stockholm, Sweden', 59.3293235, 18.0685808, 0, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1051, CAST(N'2017-10-24T00:00:00.0000000' AS DateTime2), CAST(N'2017-10-26T00:00:00.0000000' AS DateTime2), N'London, United Kingdom', 51.5073509, -0.1277583, 2, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1052, CAST(N'2017-10-28T00:00:00.0000000' AS DateTime2), CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2), N'Dublin, Ireland', 53.3498053, -6.2603097, 2, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1053, CAST(N'2017-11-04T00:00:00.0000000' AS DateTime2), CAST(N'2017-11-08T00:00:00.0000000' AS DateTime2), N'Budapest, Hungary', 47.497912, 19.040235, 4, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1054, CAST(N'2017-11-08T00:00:00.0000000' AS DateTime2), CAST(N'2017-11-11T00:00:00.0000000' AS DateTime2), N'Berlin, Germany', 52.5200066, 13.404954, 3, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1055, CAST(N'2017-11-11T00:00:00.0000000' AS DateTime2), CAST(N'2017-11-13T00:00:00.0000000' AS DateTime2), N'Copenhagen, Denmark', 55.6760968, 12.5683372, 2, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1056, CAST(N'2017-11-13T00:00:00.0000000' AS DateTime2), CAST(N'2017-11-15T00:00:00.0000000' AS DateTime2), N'Bergen, Norway', 60.3912628, 5.3220544, 2, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1057, CAST(N'2017-11-15T00:00:00.0000000' AS DateTime2), CAST(N'2017-11-16T00:00:00.0000000' AS DateTime2), N'Oslo, Norway', 59.9138688, 10.7522454, 1, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1058, CAST(N'2017-11-18T00:00:00.0000000' AS DateTime2), CAST(N'2017-11-20T00:00:00.0000000' AS DateTime2), N'Helsinki, Finland', 60.1698557, 24.9383791, 2, 11)
SET IDENTITY_INSERT [dbo].[Cities] OFF
SET IDENTITY_INSERT [dbo].[Lodgings] ON 

INSERT [dbo].[Lodgings] ([LodgingId], [Address], [ArrivalDate], [Booked], [Confirmation], [Cost], [DepartureDate], [Name], [CityId]) VALUES (5, N'Av. de la Catedral, 7, 08002 Barcelona, Spain', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, NULL, CAST(126.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Hotel Colón Barcelona, Avinguda de la Catedral, Barcelona, Spain', 1043)
INSERT [dbo].[Lodgings] ([LodgingId], [Address], [ArrivalDate], [Booked], [Confirmation], [Cost], [DepartureDate], [Name], [CityId]) VALUES (6, N'Via Vittorio Veneto, 62a/b, 00187 Roma RM, Italy', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, NULL, CAST(250.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Hard Rock Cafe, Rome, Metropolitan City of Rome, Italy', 1044)
SET IDENTITY_INSERT [dbo].[Lodgings] OFF
SET IDENTITY_INSERT [dbo].[Planners] ON 

INSERT [dbo].[Planners] ([PlannerId], [Birthdate], [FirstName], [Hometown], [Image], [LastName], [UserId], [UserName]) VALUES (3, CAST(N'1990-08-19T00:00:00.0000000' AS DateTime2), N'Alyssa', N'Portland', 0, N'Moody', N'09d7805a-dda6-4c70-ad2c-0409c9c2597d', N'alyssa')
INSERT [dbo].[Planners] ([PlannerId], [Birthdate], [FirstName], [Hometown], [Image], [LastName], [UserId], [UserName]) VALUES (4, CAST(N'2017-08-22T00:00:00.0000000' AS DateTime2), N'Testing', N'Portland', 0, N'Tests', N'2ebd6d56-3d96-46f9-bd14-c9b69d30f945', N'test')
INSERT [dbo].[Planners] ([PlannerId], [Birthdate], [FirstName], [Hometown], [Image], [LastName], [UserId], [UserName]) VALUES (6, CAST(N'2017-09-05T00:00:00.0000000' AS DateTime2), N'Alyssa', N'Portland', 0, N'Mooooo', N'bd45fc81-aff0-4fc2-bac9-bb4531404a57', N'tesstttt')
SET IDENTITY_INSERT [dbo].[Planners] OFF
SET IDENTITY_INSERT [dbo].[Transportations] ON 

INSERT [dbo].[Transportations] ([TransportationId], [Booked], [Confirmation], [Cost], [DepartureDate], [Mode], [ArrivalCityId], [CityId], [TripId]) VALUES (11, 1, N'E4f28', CAST(50.00 AS Decimal(18, 2)), CAST(N'2017-08-29T00:00:00.0000000' AS DateTime2), N'flight', 1044, 1043, 11)
SET IDENTITY_INSERT [dbo].[Transportations] OFF
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1043)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1044)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1046)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1051)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1052)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1053)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1054)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1055)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1056)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1057)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1058)
SET IDENTITY_INSERT [dbo].[Trips] ON 

INSERT [dbo].[Trips] ([TripId], [BeginDate], [Budget], [EndDate], [Members], [Name], [Public], [StartCity], [TripLength], [PlannerId]) VALUES (11, CAST(N'2017-10-23T00:00:00.0000000' AS DateTime2), CAST(2000.00 AS Decimal(18, 2)), CAST(N'2017-11-20T00:00:00.0000000' AS DateTime2), N'Alyssa', N'Europe 2017', 0, N'Portland, OR', 28, 3)
INSERT [dbo].[Trips] ([TripId], [BeginDate], [Budget], [EndDate], [Members], [Name], [Public], [StartCity], [TripLength], [PlannerId]) VALUES (21, CAST(N'2018-01-01T00:00:00.0000000' AS DateTime2), CAST(1500.00 AS Decimal(18, 2)), CAST(N'2018-01-31T00:00:00.0000000' AS DateTime2), NULL, N'US Road Trip', 0, N'Portland, OR, United States', 30, 3)
SET IDENTITY_INSERT [dbo].[Trips] OFF
/****** Object:  Index [IX_Activities_CityId]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Activities_CityId] ON [dbo].[Activities]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Lodgings_CityId]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Lodgings_CityId] ON [dbo].[Lodgings]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Planners_UserId]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Planners_UserId] ON [dbo].[Planners]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transportations_CityId]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Transportations_CityId] ON [dbo].[Transportations]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TripCities_CityId]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_TripCities_CityId] ON [dbo].[TripCities]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Trips_PlannerId]    Script Date: 10/6/17 11:17:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Trips_PlannerId] ON [dbo].[Trips]
(
	[PlannerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT ((0)) FOR [CityId]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Latitude]
GO
ALTER TABLE [dbo].[Activities] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Longitude]
GO
ALTER TABLE [dbo].[Cities] ADD  DEFAULT ((0)) FOR [Duration]
GO
ALTER TABLE [dbo].[Cities] ADD  DEFAULT ((0)) FOR [TripId]
GO
ALTER TABLE [dbo].[Lodgings] ADD  DEFAULT ((0)) FOR [CityId]
GO
ALTER TABLE [dbo].[Transportations] ADD  CONSTRAINT [DF__Transport__Arriv__01142BA1]  DEFAULT ((0)) FOR [ArrivalCityId]
GO
ALTER TABLE [dbo].[Transportations] ADD  CONSTRAINT [DF__Transport__Depar__02084FDA]  DEFAULT ((0)) FOR [CityId]
GO
ALTER TABLE [dbo].[Transportations] ADD  CONSTRAINT [DF__Transport__TripI__4D5F7D71]  DEFAULT ((0)) FOR [TripId]
GO
ALTER TABLE [dbo].[Trips] ADD  DEFAULT ((0)) FOR [PlannerId]
GO
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_Cities_CityId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Lodgings]  WITH CHECK ADD  CONSTRAINT [FK_Lodgings_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lodgings] CHECK CONSTRAINT [FK_Lodgings_Cities_CityId]
GO
ALTER TABLE [dbo].[Planners]  WITH CHECK ADD  CONSTRAINT [FK_Planners_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Planners] CHECK CONSTRAINT [FK_Planners_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Transportations]  WITH CHECK ADD  CONSTRAINT [FK_Transportations_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transportations] CHECK CONSTRAINT [FK_Transportations_Cities_CityId]
GO
ALTER TABLE [dbo].[TripCities]  WITH CHECK ADD  CONSTRAINT [FK_TripCities_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TripCities] CHECK CONSTRAINT [FK_TripCities_Cities_CityId]
GO
ALTER TABLE [dbo].[TripCities]  WITH CHECK ADD  CONSTRAINT [FK_TripCities_Trips_TripId] FOREIGN KEY([TripId])
REFERENCES [dbo].[Trips] ([TripId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TripCities] CHECK CONSTRAINT [FK_TripCities_Trips_TripId]
GO
ALTER TABLE [dbo].[Trips]  WITH CHECK ADD  CONSTRAINT [FK_Trips_Planners_PlannerId] FOREIGN KEY([PlannerId])
REFERENCES [dbo].[Planners] ([PlannerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Trips] CHECK CONSTRAINT [FK_Trips_Planners_PlannerId]
GO
USE [master]
GO
ALTER DATABASE [TripPlanet] SET  READ_WRITE 
GO
