
/****** Object:  Database [RentACarDB]    Script Date: 1.03.2021 01:20:06 ******/
CREATE DATABASE [RentACarDB]

USE [RentACarDB]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 1.03.2021 01:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 1.03.2021 01:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[CarImageId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[ImagePath] [nvarchar](100) NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 1.03.2021 01:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[CarName] [nvarchar](50) NOT NULL,
	[BrandId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[ModelYear] [int] NULL,
	[DailyPrice] [decimal](18, 2) NULL,
	[Description] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 1.03.2021 01:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 1.03.2021 01:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CompanyName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 1.03.2021 01:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[RentalId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[CustomerId] [int] NULL,
	[RentDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1.03.2021 01:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1, N'Nissan')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2, N'Volvo')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (3, N'Kia')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (4, N'Mercedes')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (5, N'Renault')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (6, N'BMW')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (7, N'Fiat')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (8, N'Dacia')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1008, N'Toyota')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2008, N'Tofaş')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2009, N'Bugatti')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 

INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [Date]) VALUES (1002, 2, N'\Images\CarImages\4d35a94c-6853-46e5-99c8-adf9245a5c82.jpg', CAST(N'2021-02-28T23:33:26.303' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [Date]) VALUES (2002, 2, N'\Images\CarImages\df263d5f-6891-4d31-8176-81aa40c4abab.jpg', CAST(N'2021-03-01T00:47:14.247' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [Date]) VALUES (2003, 2, N'\Images\CarImages\f3d09e69-1f5a-4f4e-8146-85ab712fa5de.jpg', CAST(N'2021-03-01T00:47:17.663' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [Date]) VALUES (2004, 2, N'\Images\CarImages\8d318714-b8ce-420c-9d8f-137dfd079204.jpg', CAST(N'2021-03-01T00:47:18.893' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [Date]) VALUES (2005, 2, N'\Images\CarImages\25834d69-dcdb-4f9b-81bd-7776017078c2.jpg', CAST(N'2021-03-01T00:47:19.657' AS DateTime))
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (1, N'Güncellenen Araba', 1, 2, 2021, CAST(750.00 AS Decimal(18, 2)), N'Güncellendi')
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2, N'Günlük Aile Arabası', 4, 6, 2019, CAST(540.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3, N'3.Araba', 2, 2, 2013, CAST(432.00 AS Decimal(18, 2)), N'3.Araba Güncellendi')
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (4, N'4.Araba', 4, 6, 1996, CAST(165.00 AS Decimal(18, 2)), N'4.Araba Açıklaması')
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (7, N'EFAraba Denemesi', 3, 2, 2018, CAST(1500.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (1006, N'Favori Araba', 1, 7, 2016, CAST(670.00 AS Decimal(18, 2)), N'GTR R35')
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (1007, N'Seyahat Arabası', 3, 6, 2003, CAST(730.00 AS Decimal(18, 2)), N'Carnival 8 Kişilik')
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2006, N'a', 2, 4, 1999, CAST(400.00 AS Decimal(18, 2)), N'fdkmkdg')
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3007, N'asd', 5, 6, 1234, CAST(456.00 AS Decimal(18, 2)), N'kljbhkl')
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3008, N'kljkl', 6, 7, 1264, CAST(46.00 AS Decimal(18, 2)), N'kjb')
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (4009, N'asd', 5, 6, 1234, CAST(10.00 AS Decimal(18, 2)), N'kljbhkl')
INSERT [dbo].[Cars] ([CarId], [CarName], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (4010, N'a', 5, 6, 1234, CAST(10.00 AS Decimal(18, 2)), N'kljbhkl')
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1, N'Mavi')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2, N'Beyaz')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (3, N'Yeşil')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (4, N'Siyah')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (5, N'Kırmızı')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (6, N'Turuncu')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (7, N'Turkuaz')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (8, N'Pembe')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1008, N'Lila')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2008, N'Mor')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [UserID], [CompanyName]) VALUES (1, 1, N'Gümüş Bilgisayar')
INSERT [dbo].[Customers] ([CustomerId], [UserID], [CompanyName]) VALUES (2, 3, N'Denge Rulo')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1, 2, 1, CAST(N'2021-02-14T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (3, 1, 1, CAST(N'2021-02-14T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (1, N'Oğuzhan', N'Gümüş', N'oguzhangumus27@gmail.com', N'1234')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (2, N'Asiye Rana', N'Gümüş', N'asiyeranagumus@gmail.com', N'asiyerana')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (3, N'Ertuğrul Gazi', N'Gümüş', N'ertugrulgazigumus@gmail.com', N'12345689')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CarImages]  WITH CHECK ADD FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([BrandId])
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([ColorId])
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
USE [master]
GO
ALTER DATABASE [RentACarDB] SET  READ_WRITE 
GO
