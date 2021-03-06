USE [master]
GO
/****** Object:  Database [PracticalTest]    Script Date: 4/22/2020 3:30:13 AM ******/
CREATE DATABASE [PracticalTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PracticalTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PracticalTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PracticalTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PracticalTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PracticalTest] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PracticalTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PracticalTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PracticalTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PracticalTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PracticalTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PracticalTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [PracticalTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PracticalTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PracticalTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PracticalTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PracticalTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PracticalTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PracticalTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PracticalTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PracticalTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PracticalTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PracticalTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PracticalTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PracticalTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PracticalTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PracticalTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PracticalTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PracticalTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PracticalTest] SET RECOVERY FULL 
GO
ALTER DATABASE [PracticalTest] SET  MULTI_USER 
GO
ALTER DATABASE [PracticalTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PracticalTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PracticalTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PracticalTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PracticalTest] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PracticalTest', N'ON'
GO
ALTER DATABASE [PracticalTest] SET QUERY_STORE = OFF
GO
USE [PracticalTest]
GO
/****** Object:  Table [dbo].[tbl_Doctor]    Script Date: 4/22/2020 3:30:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Doctor](
	[doctorId] [varchar](5) NOT NULL,
	[fullName] [nvarchar](50) NOT NULL,
	[specialization] [nvarchar](250) NOT NULL,
	[phoneNumber] [varchar](30) NOT NULL,
	[address] [nvarchar](250) NOT NULL,
	[password] [varchar](30) NULL,
	[leader] [bit] NULL,
 CONSTRAINT [PK_tbl_Doctor] PRIMARY KEY CLUSTERED 
(
	[doctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Scheduler]    Script Date: 4/22/2020 3:30:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Scheduler](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[shiftDate] [datetime] NOT NULL,
	[fromTime] [datetime] NOT NULL,
	[dateTime] [datetime] NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[doctorId] [varchar](5) NOT NULL,
 CONSTRAINT [PK_tbl_Scheduler] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Shoe]    Script Date: 4/22/2020 3:30:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Shoe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[price] [float] NOT NULL,
	[size] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Shoe] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 4/22/2020 3:30:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[userId] [varchar](20) NOT NULL,
	[password] [int] NOT NULL,
	[fullName] [varchar](50) NOT NULL,
	[boss] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Weapon]    Script Date: 4/22/2020 3:30:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Weapon](
	[amourId] [varchar](5) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[classification] [nvarchar](250) NOT NULL,
	[defense] [nvarchar](50) NOT NULL,
	[timeOfCreate] [datetime] NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Weapon] PRIMARY KEY CLUSTERED 
(
	[amourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_Doctor] ([doctorId], [fullName], [specialization], [phoneNumber], [address], [password], [leader]) VALUES (N'ADM', N'admin', N'test admin', N'0123456677', N'HCM', N'123456', 1)
INSERT [dbo].[tbl_Doctor] ([doctorId], [fullName], [specialization], [phoneNumber], [address], [password], [leader]) VALUES (N'MEM', N'member', N'test member', N'7812634918', N'HCM 123', N'123456', 0)
INSERT [dbo].[tbl_Doctor] ([doctorId], [fullName], [specialization], [phoneNumber], [address], [password], [leader]) VALUES (N'MEM2', N'member 2', N'test member 2', N'8723488761', N'HCM 1234', N'123456', 0)
INSERT [dbo].[tbl_Doctor] ([doctorId], [fullName], [specialization], [phoneNumber], [address], [password], [leader]) VALUES (N'NHT', N'Nguyen Huy Thuc', N'Đa Khoa', N'0916112110', N'Go Vap, HCM', N'123456', 1)
INSERT [dbo].[tbl_Doctor] ([doctorId], [fullName], [specialization], [phoneNumber], [address], [password], [leader]) VALUES (N'TDT', N'Tran Dai Thanh', N'Chuyên Khoa Nhi', N'0348251616', N'Di An, Binh Duong', N'123456', 1)
SET IDENTITY_INSERT [dbo].[tbl_Scheduler] ON 

INSERT [dbo].[tbl_Scheduler] ([id], [shiftDate], [fromTime], [dateTime], [description], [doctorId]) VALUES (3, CAST(N'2020-03-23T00:00:00.000' AS DateTime), CAST(N'2020-03-23T08:00:00.000' AS DateTime), CAST(N'2020-03-23T18:00:00.000' AS DateTime), N'admin', N'ADM')
INSERT [dbo].[tbl_Scheduler] ([id], [shiftDate], [fromTime], [dateTime], [description], [doctorId]) VALUES (4, CAST(N'2020-03-24T00:00:00.000' AS DateTime), CAST(N'2020-03-24T08:00:00.000' AS DateTime), CAST(N'2020-03-24T18:00:00.000' AS DateTime), N'member 1', N'MEM')
INSERT [dbo].[tbl_Scheduler] ([id], [shiftDate], [fromTime], [dateTime], [description], [doctorId]) VALUES (5, CAST(N'2020-03-24T00:00:00.000' AS DateTime), CAST(N'2020-03-24T08:00:00.000' AS DateTime), CAST(N'2020-03-24T12:00:00.000' AS DateTime), N'member 2', N'MEM2')
INSERT [dbo].[tbl_Scheduler] ([id], [shiftDate], [fromTime], [dateTime], [description], [doctorId]) VALUES (6, CAST(N'2020-03-24T00:00:00.000' AS DateTime), CAST(N'2020-03-24T13:00:00.000' AS DateTime), CAST(N'2020-03-24T17:00:00.000' AS DateTime), N'member 2.1', N'MEM2')
SET IDENTITY_INSERT [dbo].[tbl_Scheduler] OFF
SET IDENTITY_INSERT [dbo].[tbl_Shoe] ON 

INSERT [dbo].[tbl_Shoe] ([id], [name], [description], [price], [size], [quantity]) VALUES (1, N'Shoe 1', N's1', 1234, 40, 10)
INSERT [dbo].[tbl_Shoe] ([id], [name], [description], [price], [size], [quantity]) VALUES (2, N'Shoe 2', N's2', 1234, 40, 2)
INSERT [dbo].[tbl_Shoe] ([id], [name], [description], [price], [size], [quantity]) VALUES (3, N'Shoe 3 ', N's3', 1245, 41, 0)
INSERT [dbo].[tbl_Shoe] ([id], [name], [description], [price], [size], [quantity]) VALUES (4, N'Shoe 4 ', N's4', 1234, 42, 6)
SET IDENTITY_INSERT [dbo].[tbl_Shoe] OFF
INSERT [dbo].[tbl_User] ([userId], [password], [fullName], [boss]) VALUES (N'LoginBoss', 1, N'LoginBoss', 1)
INSERT [dbo].[tbl_User] ([userId], [password], [fullName], [boss]) VALUES (N'LoginNotBoss', 1, N'LoginNotBoss', 0)
INSERT [dbo].[tbl_User] ([userId], [password], [fullName], [boss]) VALUES (N'LoginSuccess', 1, N'LoginSuccess', 1)
INSERT [dbo].[tbl_User] ([userId], [password], [fullName], [boss]) VALUES (N'thanhtd', 123456, N'Tran Dai Thanh', 1)
USE [master]
GO
ALTER DATABASE [PracticalTest] SET  READ_WRITE 
GO
