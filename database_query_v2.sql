USE [master]
GO
/****** Object:  Database [ciberdb]    Script Date: 4/1/2022 12:48:25 AM ******/
CREATE DATABASE [ciberdb]

USE [ciberdb]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/1/2022 12:48:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/1/2022 12:48:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 4/1/2022 12:48:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Amount] [int] NULL,
	[OrderDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/1/2022 12:48:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[CategoryID] [int] NOT NULL,
	[Price] [float] NULL,
	[Description] [nvarchar](255) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/1/2022 12:48:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/1/2022 12:48:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (1, N'Cat1', N'Cat1')
GO
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (2, N'Cat2', N'Cat2')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (1, N'Cus1', N'no')
GO
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (2, N'Cus2', N'no')
GO
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (3, N'Cus3', N'no')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 
GO
INSERT [dbo].[Order] ([Id], [CustomerID], [ProductID], [Amount], [OrderDate]) VALUES (1, 1, 1, 100, CAST(N'2022-03-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [CustomerID], [ProductID], [Amount], [OrderDate]) VALUES (2, 1, 2, 100, CAST(N'2022-03-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [CustomerID], [ProductID], [Amount], [OrderDate]) VALUES (3, 2, 1, 100, CAST(N'2022-03-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [CustomerID], [ProductID], [Amount], [OrderDate]) VALUES (4, 2, 1, 123, CAST(N'2022-03-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [CustomerID], [ProductID], [Amount], [OrderDate]) VALUES (5, 1, 2, 200, CAST(N'2022-03-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [CustomerID], [ProductID], [Amount], [OrderDate]) VALUES (6, 2, 2, 50, CAST(N'2022-03-30T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [Name], [CategoryID], [Price], [Description], [Quantity]) VALUES (1, N'prod1', 1, 1000, N'no', 877)
GO
INSERT [dbo].[Product] ([Id], [Name], [CategoryID], [Price], [Description], [Quantity]) VALUES (2, N'prod2', 2, 2000, N'no', 1800)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([ID], [Role]) VALUES (1, N'admin')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([ID], [Username], [Password], [RoleID]) VALUES (1, N'admin', N'AQAAAAEAACcQAAAAEOXc0IKWtXGtuEyAqvu5Nkve8rONORUmx830Rm0JjefMlAgUKxq2MKk3VEpQx+NKoA==', 1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
USE [master]
GO
ALTER DATABASE [ciberdb] SET  READ_WRITE 
GO
