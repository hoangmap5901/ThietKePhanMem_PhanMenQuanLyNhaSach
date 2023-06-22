USE [master]
GO
/****** Object:  Database [MyShopDB]    Script Date: 6/22/2023 11:25:14 PM ******/
CREATE DATABASE [MyShopDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyShopDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MyShopDB.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyShopDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MyShopDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MyShopDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyShopDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyShopDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyShopDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyShopDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyShopDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyShopDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyShopDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyShopDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyShopDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyShopDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyShopDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyShopDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyShopDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyShopDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyShopDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyShopDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyShopDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyShopDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyShopDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyShopDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyShopDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyShopDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyShopDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyShopDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyShopDB] SET  MULTI_USER 
GO
ALTER DATABASE [MyShopDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyShopDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyShopDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyShopDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyShopDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyShopDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyShopDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [MyShopDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MyShopDB]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 6/22/2023 11:25:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[ChiTietDonHangID] [int] IDENTITY(1,1) NOT NULL,
	[DonHang_ID] [int] NULL,
	[Sach_ID] [int] NULL,
	[Gia] [int] NULL,
	[SoLuong] [int] NULL,
	[Tong] [int] NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[ChiTietDonHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 6/22/2023 11:25:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[DonHangID] [int] IDENTITY(1,1) NOT NULL,
	[KhachHang_ID] [int] NULL,
	[TrangThaiDonHang_ID] [int] NULL,
	[Tong] [int] NULL,
	[NgayTao] [date] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[DonHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/22/2023 11:25:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[KhachHangID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](200) NULL,
	[SoDienThoai] [nvarchar](200) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[Email] [nvarchar](200) NULL,
	[ImagePath] [nvarchar](200) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[KhachHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 6/22/2023 11:25:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[SachID] [int] IDENTITY(1,1) NOT NULL,
	[TheLoai_ID] [int] NULL,
	[Ten] [nvarchar](200) NULL,
	[SoLuong] [int] NULL,
	[Gia] [int] NULL,
	[TacGia] [nvarchar](200) NULL,
	[ImagePath] [nvarchar](200) NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[SachID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/22/2023 11:25:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TaiKhoanID] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](200) NULL,
	[MatKhau] [nvarchar](200) NULL,
	[VaiTro] [nvarchar](200) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TaiKhoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThamSo]    Script Date: 6/22/2023 11:25:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThamSo](
	[MaThamSo] [int] IDENTITY(1,1) NOT NULL,
	[SoLuongSachNhapToiThieu] [int] NULL,
	[SoLuongSachTonToiDaDeNhapSach] [int] NULL,
	[SoLuongSachTonToiThieuSauKhiBan] [int] NULL,
 CONSTRAINT [PK_ThamSo] PRIMARY KEY CLUSTERED 
(
	[MaThamSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 6/22/2023 11:25:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[TheLoaiID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](200) NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[TheLoaiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThaiDonHang]    Script Date: 6/22/2023 11:25:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThaiDonHang](
	[TrangThaiDonHangID] [int] IDENTITY(1,1) NOT NULL,
	[TrangThai] [nvarchar](200) NULL,
	[MoTa] [nvarchar](200) NULL,
	[ChuHienThi] [nvarchar](200) NULL,
 CONSTRAINT [PK_TrangThaiDonHang] PRIMARY KEY CLUSTERED 
(
	[TrangThaiDonHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([DonHang_ID])
REFERENCES [dbo].[DonHang] ([DonHangID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_Sach] FOREIGN KEY([Sach_ID])
REFERENCES [dbo].[Sach] ([SachID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_Sach]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang] FOREIGN KEY([KhachHang_ID])
REFERENCES [dbo].[KhachHang] ([KhachHangID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhachHang]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_TrangThaiDonHang] FOREIGN KEY([TrangThaiDonHang_ID])
REFERENCES [dbo].[TrangThaiDonHang] ([TrangThaiDonHangID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_TrangThaiDonHang]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_Sach] FOREIGN KEY([TheLoai_ID])
REFERENCES [dbo].[TheLoai] ([TheLoaiID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_Sach]
GO
USE [master]
GO
ALTER DATABASE [MyShopDB] SET  READ_WRITE 
GO
