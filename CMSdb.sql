USE [master]
GO
/****** Object:  Database [CMS]    Script Date: 1/3/2024 11:28:05 AM ******/
CREATE DATABASE [CMS]
 CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'CMS', FILENAME = N'C:\Users\mohN1080P\CMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'CMS_log', FILENAME = N'C:\Users\mohN1080P\CMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CMS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [CMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CMS] SET  MULTI_USER 
GO
ALTER DATABASE [CMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CMS] SET QUERY_STORE = OFF
GO
USE [CMS]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/3/2024 11:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 1/3/2024 11:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[ImageData] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 1/3/2024 11:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[itemName] [nvarchar](50) NOT NULL,
	[itemDescription] [nvarchar](100) NULL,
	[Price] [float] NOT NULL,
	[ImageID] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderCarts]    Script Date: 1/3/2024 11:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderCarts](
	[OrderCartID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderCart] PRIMARY KEY CLUSTERED 
(
	[OrderCartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 1/3/2024 11:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Subtotal] [float] NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 1/3/2024 11:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[TableNumber] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TotalAmount] [float] NOT NULL,
	[IsOccupied] [tinyint] NULL,
	[isPaid] [tinyint] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/3/2024 11:28:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Office] [nvarchar](50) NULL,
	[Number] [nvarchar](50) NULL,
	[Role] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Category]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Images] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Images] ([ImageID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Images]
GO
ALTER TABLE [dbo].[OrderCarts]  WITH CHECK ADD  CONSTRAINT [FK_OrderCart_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ItemID])
GO
ALTER TABLE [dbo].[OrderCarts] CHECK CONSTRAINT [FK_OrderCart_Items]
GO
ALTER TABLE [dbo].[OrderCarts]  WITH CHECK ADD  CONSTRAINT [FK_OrderCart_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[OrderCarts] CHECK CONSTRAINT [FK_OrderCart_Users]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ItemID])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Items]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
USE [master]
GO
ALTER DATABASE [CMS] SET  READ_WRITE 
GO
