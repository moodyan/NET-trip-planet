USE [TripPlanet]
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'b0ecb1fc-a22d-44a5-8677-c22e125782e0', N'fdc3965a-1af9-4d75-b6f5-26f657aeeae0', N'user', N'USER')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'c4586875-40b4-4c7d-818e-a16771dde31f', N'25412584-4280-4fba-8591-30f65b284809', N'admin', N'ADMIN')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'09d7805a-dda6-4c70-ad2c-0409c9c2597d', 0, N'15e4b05f-8127-499e-9035-290809dc1973', N'alyssa', 0, 1, NULL, N'ALYSSA', N'ALYSSA', N'AQAAAAEAACcQAAAAEBw4xcoxJhLciHUqnWv+mkeWeZRkkbIWvb27ZMvCXy9esyvDW9t7xPbthlgwP11/1A==', NULL, 0, N'a3d2e1cd-e91f-4783-ac3c-6db31c16829c', 0, N'alyssa')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'2ebd6d56-3d96-46f9-bd14-c9b69d30f945', 0, N'18428821-991a-49f3-ad98-5f193415d69e', N'test', 0, 1, NULL, N'TEST', N'TEST', N'AQAAAAEAACcQAAAAEEhfno9AWRV0ieaF3PN8OoelJ4Y/Fevrxx6i3/QQziw1IuAXhWeEJycDGL7J9lfkpg==', NULL, 0, N'b61111f8-3fea-45ba-910c-4cf4726c7718', 0, N'test')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'bd45fc81-aff0-4fc2-bac9-bb4531404a57', 0, N'33223ede-5bc1-415c-a5cf-5b7d7538d350', N'tesstttt', 0, 1, NULL, N'TESSTTTT', N'TESSTTTT', N'AQAAAAEAACcQAAAAEKlwvMloNHO0S4Ivje5r2QTFFBk9MaLykEZrAY5msG8IgDOOZ6E/URb7pduhVyUckw==', NULL, 0, N'cb2f89a8-3129-4fc6-bca1-06724b8dd2fe', 0, N'tesstttt')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2ebd6d56-3d96-46f9-bd14-c9b69d30f945', N'b0ecb1fc-a22d-44a5-8677-c22e125782e0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'09d7805a-dda6-4c70-ad2c-0409c9c2597d', N'c4586875-40b4-4c7d-818e-a16771dde31f')
SET IDENTITY_INSERT [dbo].[Planners] ON 

INSERT [dbo].[Planners] ([PlannerId], [Birthdate], [FirstName], [Hometown], [Image], [LastName], [UserId], [UserName]) VALUES (3, CAST(N'1990-08-19T00:00:00.0000000' AS DateTime2), N'Alyssa', N'Portland', 0, N'Moody', N'09d7805a-dda6-4c70-ad2c-0409c9c2597d', N'alyssa')
INSERT [dbo].[Planners] ([PlannerId], [Birthdate], [FirstName], [Hometown], [Image], [LastName], [UserId], [UserName]) VALUES (4, CAST(N'2017-08-22T00:00:00.0000000' AS DateTime2), N'Testing', N'Portland', 0, N'Tests', N'2ebd6d56-3d96-46f9-bd14-c9b69d30f945', N'test')
INSERT [dbo].[Planners] ([PlannerId], [Birthdate], [FirstName], [Hometown], [Image], [LastName], [UserId], [UserName]) VALUES (6, CAST(N'2017-09-05T00:00:00.0000000' AS DateTime2), N'Alyssa', N'Portland', 0, N'Mooooo', N'bd45fc81-aff0-4fc2-bac9-bb4531404a57', N'tesstttt')
SET IDENTITY_INSERT [dbo].[Planners] OFF
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
SET IDENTITY_INSERT [dbo].[Transportations] ON 

INSERT [dbo].[Transportations] ([TransportationId], [Booked], [Confirmation], [Cost], [DepartureDate], [Mode], [ArrivalCityId], [CityId], [TripId]) VALUES (11, 1, N'E4f28', CAST(50.00 AS Decimal(18, 2)), CAST(N'2017-08-29T00:00:00.0000000' AS DateTime2), N'flight', 1044, 1043, 11)
SET IDENTITY_INSERT [dbo].[Transportations] OFF
SET IDENTITY_INSERT [dbo].[Trips] ON 

INSERT [dbo].[Trips] ([TripId], [BeginDate], [Budget], [EndDate], [Members], [Name], [Public], [StartCity], [TripLength], [PlannerId]) VALUES (11, CAST(N'2017-10-23T00:00:00.0000000' AS DateTime2), CAST(2000.00 AS Decimal(18, 2)), CAST(N'2017-11-20T00:00:00.0000000' AS DateTime2), N'Alyssa', N'Europe 2017', 0, N'Portland, OR', 28, 3)
INSERT [dbo].[Trips] ([TripId], [BeginDate], [Budget], [EndDate], [Members], [Name], [Public], [StartCity], [TripLength], [PlannerId]) VALUES (21, CAST(N'2018-01-01T00:00:00.0000000' AS DateTime2), CAST(1500.00 AS Decimal(18, 2)), CAST(N'2018-01-31T00:00:00.0000000' AS DateTime2), NULL, N'US Road Trip', 0, N'Portland, OR, United States', 30, 3)
SET IDENTITY_INSERT [dbo].[Trips] OFF
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
SET IDENTITY_INSERT [dbo].[Activities] ON 

INSERT [dbo].[Activities] ([ActivityId], [Address], [Cost], [Date], [Name], [TimeSpent], [Type], [CityId], [Latitude], [Longitude]) VALUES (14, N'08013 Barcelona, Spain', CAST(12.00 AS Decimal(18, 2)), CAST(N'2017-08-30T00:00:00.0000000' AS DateTime2), N'Sagrada Família, Barcelona, Spain', CAST(1.00 AS Decimal(18, 2)), N'Sightseeing', 1043, 41.4031163, 2.181871)
INSERT [dbo].[Activities] ([ActivityId], [Address], [Cost], [Date], [Name], [TimeSpent], [Type], [CityId], [Latitude], [Longitude]) VALUES (16, N'Hackescher Markt, 10178 Berlin, Germany', CAST(40.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Hackescher Markt, Berlin, Germany', CAST(0.00 AS Decimal(18, 2)), NULL, 1054, 52.5236903, 13.4023149)
SET IDENTITY_INSERT [dbo].[Activities] OFF
SET IDENTITY_INSERT [dbo].[Lodgings] ON 

INSERT [dbo].[Lodgings] ([LodgingId], [Address], [ArrivalDate], [Booked], [Confirmation], [Cost], [DepartureDate], [Name], [CityId]) VALUES (5, N'Av. de la Catedral, 7, 08002 Barcelona, Spain', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, NULL, CAST(126.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Hotel Colón Barcelona, Avinguda de la Catedral, Barcelona, Spain', 1043)
INSERT [dbo].[Lodgings] ([LodgingId], [Address], [ArrivalDate], [Booked], [Confirmation], [Cost], [DepartureDate], [Name], [CityId]) VALUES (6, N'Via Vittorio Veneto, 62a/b, 00187 Roma RM, Italy', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, NULL, CAST(250.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Hard Rock Cafe, Rome, Metropolitan City of Rome, Italy', 1044)
SET IDENTITY_INSERT [dbo].[Lodgings] OFF
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
