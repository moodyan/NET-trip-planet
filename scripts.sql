USE [TripPlanet]
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'b0ecb1fc-a22d-44a5-8677-c22e125782e0', N'fdc3965a-1af9-4d75-b6f5-26f657aeeae0', N'user', N'USER')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'c4586875-40b4-4c7d-818e-a16771dde31f', N'25412584-4280-4fba-8591-30f65b284809', N'admin', N'ADMIN')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'09d7805a-dda6-4c70-ad2c-0409c9c2597d', 0, N'15e4b05f-8127-499e-9035-290809dc1973', N'alyssa', 0, 1, NULL, N'ALYSSA', N'ALYSSA', N'AQAAAAEAACcQAAAAEBw4xcoxJhLciHUqnWv+mkeWeZRkkbIWvb27ZMvCXy9esyvDW9t7xPbthlgwP11/1A==', NULL, 0, N'a3d2e1cd-e91f-4783-ac3c-6db31c16829c', 0, N'alyssa')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'2ebd6d56-3d96-46f9-bd14-c9b69d30f945', 0, N'18428821-991a-49f3-ad98-5f193415d69e', N'test', 0, 1, NULL, N'TEST', N'TEST', N'AQAAAAEAACcQAAAAEEhfno9AWRV0ieaF3PN8OoelJ4Y/Fevrxx6i3/QQziw1IuAXhWeEJycDGL7J9lfkpg==', NULL, 0, N'b61111f8-3fea-45ba-910c-4cf4726c7718', 0, N'test')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2ebd6d56-3d96-46f9-bd14-c9b69d30f945', N'b0ecb1fc-a22d-44a5-8677-c22e125782e0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'09d7805a-dda6-4c70-ad2c-0409c9c2597d', N'c4586875-40b4-4c7d-818e-a16771dde31f')
SET IDENTITY_INSERT [dbo].[Planners] ON 

INSERT [dbo].[Planners] ([PlannerId], [Birthdate], [FirstName], [Hometown], [Image], [LastName], [UserId], [UserName]) VALUES (3, CAST(N'1990-08-19T00:00:00.0000000' AS DateTime2), N'Alyssa', N'Portland', 0, N'Moody', N'09d7805a-dda6-4c70-ad2c-0409c9c2597d', N'alyssa')
INSERT [dbo].[Planners] ([PlannerId], [Birthdate], [FirstName], [Hometown], [Image], [LastName], [UserId], [UserName]) VALUES (4, CAST(N'2017-08-22T00:00:00.0000000' AS DateTime2), N'Testing', N'Portland', 0, N'Tests', N'2ebd6d56-3d96-46f9-bd14-c9b69d30f945', N'test')
SET IDENTITY_INSERT [dbo].[Planners] OFF
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1043, CAST(N'2017-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2017-10-25T00:00:00.0000000' AS DateTime2), N'Barcelona, Spain', 41.3850639, 2.1734035, 2, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1044, CAST(N'2017-10-25T00:00:00.0000000' AS DateTime2), CAST(N'2017-10-27T00:00:00.0000000' AS DateTime2), N'Rome, Metropolitan City of Rome, Italy', 41.9027835, 12.4963655, 2, 11)
INSERT [dbo].[Cities] ([CityId], [ArrivalDate], [DepartureDate], [Name], [Latitude], [Longitude], [Duration], [TripId]) VALUES (1045, CAST(N'2017-08-31T00:00:00.0000000' AS DateTime2), CAST(N'2017-09-02T00:00:00.0000000' AS DateTime2), N'Budapest, Hungary', 47.497912, 19.040235, 2, 11)
SET IDENTITY_INSERT [dbo].[Cities] OFF
SET IDENTITY_INSERT [dbo].[Transportations] ON 

INSERT [dbo].[Transportations] ([TransportationId], [Booked], [Confirmation], [Cost], [DepartureDate], [Mode], [ArrivalCityId], [CityId], [TripId]) VALUES (11, 1, N'E4f28', CAST(50.00 AS Decimal(18, 2)), CAST(N'2017-08-29T00:00:00.0000000' AS DateTime2), N'flight', 1044, 1043, 11)
SET IDENTITY_INSERT [dbo].[Transportations] OFF
SET IDENTITY_INSERT [dbo].[Trips] ON 

INSERT [dbo].[Trips] ([TripId], [BeginDate], [Budget], [EndDate], [Members], [Name], [Public], [StartCity], [TripLength], [PlannerId]) VALUES (11, CAST(N'2017-10-23T00:00:00.0000000' AS DateTime2), CAST(2000.00 AS Decimal(18, 2)), CAST(N'2017-11-20T00:00:00.0000000' AS DateTime2), N'Alyssa', N'Europe 2017', 0, N'London, United Kingdom', 0, 3)
SET IDENTITY_INSERT [dbo].[Trips] OFF
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1043)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1044)
INSERT [dbo].[TripCities] ([TripId], [CityId]) VALUES (11, 1045)
SET IDENTITY_INSERT [dbo].[Activities] ON 

INSERT [dbo].[Activities] ([ActivityId], [Address], [Cost], [Date], [Name], [TimeSpent], [Type], [CityId], [Latitude], [Longitude]) VALUES (14, N'08013 Barcelona, Spain', CAST(12.00 AS Decimal(18, 2)), CAST(N'2017-08-30T00:00:00.0000000' AS DateTime2), N'Sagrada Família, Barcelona, Spain', CAST(1.00 AS Decimal(18, 2)), N'Sightseeing', 1043, 41.4031163, 2.181871)
SET IDENTITY_INSERT [dbo].[Activities] OFF
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
