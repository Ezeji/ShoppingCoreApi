USE [master]
GO
/****** Object:  Database [ShoppingDB]    Script Date: 11/21/2021 2:34:35 PM ******/
CREATE DATABASE [ShoppingDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShoppingDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShoppingDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShoppingDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShoppingDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShoppingDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShoppingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShoppingDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShoppingDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShoppingDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShoppingDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShoppingDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShoppingDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShoppingDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShoppingDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShoppingDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShoppingDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShoppingDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShoppingDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShoppingDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShoppingDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShoppingDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShoppingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShoppingDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShoppingDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShoppingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShoppingDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShoppingDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShoppingDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShoppingDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ShoppingDB] SET  MULTI_USER 
GO
ALTER DATABASE [ShoppingDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShoppingDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShoppingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShoppingDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShoppingDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShoppingDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShoppingDB', N'ON'
GO
ALTER DATABASE [ShoppingDB] SET QUERY_STORE = OFF
GO
USE [ShoppingDB]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 11/21/2021 2:34:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[ItemsSelected] [nvarchar](max) NULL,
	[ShoppingCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscountStore]    Script Date: 11/21/2021 2:34:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountStore](
	[DiscountStoreId] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](max) NULL,
	[Price] [nvarchar](max) NULL,
	[Discount] [nvarchar](max) NULL,
 CONSTRAINT [PK_DiscountStore] PRIMARY KEY CLUSTERED 
(
	[DiscountStoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([CartId], [ItemsSelected], [ShoppingCode]) VALUES (7, N'BIG MUG', N'C76F86E324')
INSERT [dbo].[Cart] ([CartId], [ItemsSelected], [ShoppingCode]) VALUES (8, N'VASE', N'C76F86E324')
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[DiscountStore] ON 

INSERT [dbo].[DiscountStore] ([DiscountStoreId], [SKU], [Price], [Discount]) VALUES (1, N'Vase', N'1.2 Euros', NULL)
INSERT [dbo].[DiscountStore] ([DiscountStoreId], [SKU], [Price], [Discount]) VALUES (2, N'Big mug', N'1 Euro', N'2 for 1.5 Euros')
INSERT [dbo].[DiscountStore] ([DiscountStoreId], [SKU], [Price], [Discount]) VALUES (3, N'Napkins pack', N'0.45 Euro', N'3 for 0.90 Euro')
SET IDENTITY_INSERT [dbo].[DiscountStore] OFF
GO
USE [master]
GO
ALTER DATABASE [ShoppingDB] SET  READ_WRITE 
GO
