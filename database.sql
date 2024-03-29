USE [master]
GO
/****** Object:  Database [StoreManageDB]    Script Date: 12/22/2023 4:55:49 PM ******/
CREATE DATABASE [StoreManageDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoreManageDB', FILENAME = N'C:\Users\ahmed\StoreManageDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StoreManageDB_log', FILENAME = N'C:\Users\ahmed\StoreManageDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [StoreManageDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreManageDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreManageDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreManageDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreManageDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreManageDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreManageDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreManageDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StoreManageDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreManageDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreManageDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreManageDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreManageDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreManageDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreManageDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreManageDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreManageDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StoreManageDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreManageDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreManageDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreManageDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreManageDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreManageDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreManageDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreManageDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StoreManageDB] SET  MULTI_USER 
GO
ALTER DATABASE [StoreManageDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreManageDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreManageDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreManageDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StoreManageDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StoreManageDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [StoreManageDB] SET QUERY_STORE = OFF
GO
USE [StoreManageDB]
GO
/****** Object:  Table [dbo].[tbUser]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role] [varchar](50) NOT NULL,
	[fullname] [varchar](50) NOT NULL,
	[isactive] [bit] NOT NULL,
 CONSTRAINT [PK_tbUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_tbUser] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbStockIn]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbStockIn](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[refno] [varchar](50) NOT NULL,
	[pid] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[sdate] [date] NOT NULL,
	[stockinby] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[supplierid] [int] NOT NULL,
 CONSTRAINT [PK_tbStockIn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbProduct]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbProduct](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[barcode] [varchar](50) NULL,
	[product] [varchar](max) NOT NULL,
	[b_id] [int] NOT NULL,
	[c_id] [int] NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_tbProduct] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_tbProduct] UNIQUE NONCLUSTERED 
(
	[barcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbSupplier]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbSupplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supplier] [varchar](50) NOT NULL,
	[address] [varchar](max) NULL,
	[contactperson] [varchar](50) NULL,
	[phone] [varchar](15) NULL,
	[email] [varchar](50) NULL,
	[fax] [varchar](50) NULL,
 CONSTRAINT [PK_tbSupplier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_tbSupplier] UNIQUE NONCLUSTERED 
(
	[supplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vtStockIn]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vtStockIn]
AS
SELECT dbo.tbStockIn.id, dbo.tbStockIn.refno, dbo.tbProduct.product, dbo.tbStockIn.qty, dbo.tbStockIn.status, dbo.tbStockIn.stockinby, dbo.tbStockIn.sdate, dbo.tbUser.username, dbo.tbSupplier.supplier, dbo.tbStockIn.pid
FROM     dbo.tbProduct INNER JOIN
                  dbo.tbStockIn ON dbo.tbProduct.id = dbo.tbStockIn.pid INNER JOIN
                  dbo.tbSupplier ON dbo.tbStockIn.supplierid = dbo.tbSupplier.id INNER JOIN
                  dbo.tbUser ON dbo.tbStockIn.stockinby = dbo.tbUser.id
GO
/****** Object:  Table [dbo].[tbBrand]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbBrand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[brand] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbBrand] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbCar]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[transno] [varchar](50) NULL,
	[pid] [int] NULL,
	[qty] [int] NULL,
	[disc_percent] [decimal](18, 2) NULL,
	[sdate] [date] NULL,
	[status] [varchar](50) NULL,
	[cashier_id] [int] NULL,
 CONSTRAINT [PK_tbCar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbCategory]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbStoreInfo]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbStoreInfo](
	[StoreName] [varchar](50) NULL,
	[StoreAddress] [varchar](max) NULL,
	[tax] [decimal](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbCar] ADD  CONSTRAINT [DF_tbCar_qty]  DEFAULT ((0)) FOR [qty]
GO
ALTER TABLE [dbo].[tbCar] ADD  CONSTRAINT [DF_tbCar_disc_percent]  DEFAULT ((0)) FOR [disc_percent]
GO
ALTER TABLE [dbo].[tbCar] ADD  CONSTRAINT [DF_tbCar_status]  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[tbStockIn] ADD  CONSTRAINT [DF_tbStockIn_qty]  DEFAULT ((0)) FOR [qty]
GO
ALTER TABLE [dbo].[tbStockIn] ADD  CONSTRAINT [DF_tbStockIn_status]  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[tbUser] ADD  CONSTRAINT [DF_tbUser_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[tbCar]  WITH CHECK ADD  CONSTRAINT [FK_tbCar_tbProduct] FOREIGN KEY([pid])
REFERENCES [dbo].[tbProduct] ([id])
GO
ALTER TABLE [dbo].[tbCar] CHECK CONSTRAINT [FK_tbCar_tbProduct]
GO
ALTER TABLE [dbo].[tbCar]  WITH CHECK ADD  CONSTRAINT [FK_tbCar_tbUser] FOREIGN KEY([cashier_id])
REFERENCES [dbo].[tbUser] ([id])
GO
ALTER TABLE [dbo].[tbCar] CHECK CONSTRAINT [FK_tbCar_tbUser]
GO
ALTER TABLE [dbo].[tbProduct]  WITH CHECK ADD  CONSTRAINT [FK_tbProduct_tbBrand] FOREIGN KEY([b_id])
REFERENCES [dbo].[tbBrand] ([id])
GO
ALTER TABLE [dbo].[tbProduct] CHECK CONSTRAINT [FK_tbProduct_tbBrand]
GO
ALTER TABLE [dbo].[tbProduct]  WITH CHECK ADD  CONSTRAINT [FK_tbProduct_tbCategory] FOREIGN KEY([c_id])
REFERENCES [dbo].[tbCategory] ([id])
GO
ALTER TABLE [dbo].[tbProduct] CHECK CONSTRAINT [FK_tbProduct_tbCategory]
GO
ALTER TABLE [dbo].[tbStockIn]  WITH CHECK ADD  CONSTRAINT [FK_tbStockIn_tbProduct] FOREIGN KEY([pid])
REFERENCES [dbo].[tbProduct] ([id])
GO
ALTER TABLE [dbo].[tbStockIn] CHECK CONSTRAINT [FK_tbStockIn_tbProduct]
GO
ALTER TABLE [dbo].[tbStockIn]  WITH CHECK ADD  CONSTRAINT [FK_tbStockIn_tbSupplier] FOREIGN KEY([supplierid])
REFERENCES [dbo].[tbSupplier] ([id])
GO
ALTER TABLE [dbo].[tbStockIn] CHECK CONSTRAINT [FK_tbStockIn_tbSupplier]
GO
ALTER TABLE [dbo].[tbStockIn]  WITH CHECK ADD  CONSTRAINT [FK_tbStockIn_tbUser] FOREIGN KEY([stockinby])
REFERENCES [dbo].[tbUser] ([id])
GO
ALTER TABLE [dbo].[tbStockIn] CHECK CONSTRAINT [FK_tbStockIn_tbUser]
GO
/****** Object:  StoredProcedure [dbo].[AddDiscount]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddDiscount]
@id int,
@disc_percent decimal(18, 2)
as
UPDATE tbCar SET disc_percent = @disc_percent  WHERE id LIKE @id
GO
/****** Object:  StoredProcedure [dbo].[AddOneqty]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SELECT OBJECT_DEFINITION (OBJECT_ID(N'SelectProductForCasher'));  
create proc [dbo].[AddOneqty]
@id int
as
UPDATE tbCar set qty = qty + 1 where id = @id
GO
/****** Object:  StoredProcedure [dbo].[CancelOrder]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CancelOrder]
@id int
as
Update tbCar SET [status]='cancel' WHERE id like @id
GO
/****** Object:  StoredProcedure [dbo].[ChangeUserPassword]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ChangeUserPassword]
@username varchar(50),
@password varchar(50)
as
UPDATE tbUser SET [password] = @password WHERE username =@username
GO
/****** Object:  StoredProcedure [dbo].[CheckForTrans]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [dbo].[CheckForTrans]
@transno varchar(50)
as
SELECT TOP 1 transno FROM tbCar WHERE transno LIKE @transno+'%' ORDER BY id DESC

GO
/****** Object:  StoredProcedure [dbo].[CheckLoginData]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckLoginData]
@username varchar(50),
@password varchar(50)
as
Select * FROM tbUser Where username = @username and password = @password and isactive = 1
GO
/****** Object:  StoredProcedure [dbo].[CheckQty]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 CREATE PROC [dbo].[CheckQty]
 @pid int
 as
 SELECT 
    COALESCE(s.qty, 0) AS qty
FROM tbProduct p
LEFT JOIN (
    SELECT 
        si.pid, 
        SUM(DISTINCT si.qty) - COALESCE(SUM(CASE WHEN o.status = 'confirmed' THEN o.qty ELSE 0 END), 0) AS qty
    FROM tbStockIn si
    LEFT JOIN tbCar o ON si.pid = o.pid
    WHERE si.status = 'confirmed'
    GROUP BY si.pid
) s ON p.id = s.pid
WHERE p.id LIKE @pid
GO
/****** Object:  StoredProcedure [dbo].[ConfirmStockIn]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConfirmStockIn] 
@id int,
@qty int
as
UPDATE tbStockIn SET status = 'confirmed' , qty = @qty WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[ConfirmTrans]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ConfirmTrans]
@transno varchar(50)
as
UPDATE tbCar SET [status] = 'confirmed' WHERE transno =@transno
GO
/****** Object:  StoredProcedure [dbo].[DeleteBrand]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteBrand]
@id int
as
DELETE FROM tbBrand Where id = @id


exec SelectBrands
GO
/****** Object:  StoredProcedure [dbo].[DeleteOrder]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SELECT OBJECT_DEFINITION (OBJECT_ID(N'SelectProductForCasher'));  
CREATE proc [dbo].[DeleteOrder]
@id int
as
DELETE FROM tbCar WHERE id = @id;
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteProduct]
@id int
as
DELETE FROM tbProduct WHERE id LIKE @id


GO
/****** Object:  StoredProcedure [dbo].[DeleteSupplier]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteSupplier]
@id int
as
DELETE FROM tbSupplier WHERE id LIKE @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteTrans]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteTrans]
@transno varchar(50)
as
DELETE FROM tbCar WHERE transno like @transno;
GO
/****** Object:  StoredProcedure [dbo].[InsertBrand]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[InsertBrand]
@brand varchar(50)
as
INSERT INTO tbBrand(brand)VALUES(@brand)


GO
/****** Object:  StoredProcedure [dbo].[InsertCaregory]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertCaregory]
@category varchar(50)
as
INSERT INTO tbCategory(category)VALUES(@category)


GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







  CREATE proc [dbo].[InsertOrder]   @transno varchar(50),  @pid int,  @qty int,  @sdate date,  @cashier varchar(50)  as  IF EXISTS (SELECT * FROM tbCar WHERE transno = @transno AND pid = @pid)
BEGIN
  UPDATE tbCar SET qty = qty + @qty WHERE transno = @transno AND pid = @pid
END
ELSE
BEGIN
  INSERT INTO tbCar (transno, pid, qty, sdate, cashier_id)
  SELECT @transno, @pid, @qty, @sdate, c.id
  FROM tbUser c
  WHERE c.username = @cashier
END
GO
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertProduct]
@barcode varchar(50),
@product varchar(MAX),
@b_id int,
@c_id int,
@price decimal(18, 2)
as
INSERT INTO tbProduct(barcode,product,b_id,c_id,price) VALUES (@barcode,@product,@b_id,@c_id,@price)
GO
/****** Object:  StoredProcedure [dbo].[InsertStockin]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStockin]
    @refno varchar(50),
    @pid int,
    @sdate date,
    @stockinby_username varchar(50),
    @supplier_username varchar(50)
AS
BEGIN
    DECLARE @stockinby_id int, @supplier_id int;
    
    SELECT @stockinby_id = id
    FROM tbUser
    WHERE username = @stockinby_username;
    
    SELECT @supplier_id = id
    FROM tbSupplier
    WHERE supplier = @supplier_username;

    INSERT INTO tbStockIn(refno, pid, sdate, stockinby, supplierid)
    VALUES (@refno, @pid, @sdate, @stockinby_id, @supplier_id);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertSuplier]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertSuplier]
@supplier varchar(50),
@address varchar(MAX),
@contactperson varchar(50),
@phone varchar(15),
@email varchar(50),
@fax varchar(50)
as
INSERT INTO tbSupplier(supplier,address,contactperson,phone,email,fax)VALUES(@supplier,@address,@contactperson,@phone,@email,@fax)
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertUser]
@username varchar(50),@password varchar(50),@role varchar(50),@fullname varchar(50)
as
INSERT INTO tbUser(username,password,role,fullname)VALUES(@username,@password,@role,@fullname)
GO
/****** Object:  StoredProcedure [dbo].[RemoveOneqty]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SELECT OBJECT_DEFINITION (OBJECT_ID(N'SelectProductForCasher'));  
CREATE proc [dbo].[RemoveOneqty]
@id int
as
DELETE FROM tbCar WHERE id = @id AND qty = 1;
UPDATE tbCar SET qty = qty - 1 WHERE id = @id AND qty > 1;
GO
/****** Object:  StoredProcedure [dbo].[SelectBrands]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectBrands]
as
SELECT * FROM tbBrand ORDER BY brand
GO
/****** Object:  StoredProcedure [dbo].[SelectCanceledTrans]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROC [dbo].[SelectCanceledTrans]  @cahierid varchar(50),  @fromdate date,  @todate date  as  SELECT c.id, c.pid, p.product, p.barcode, p.price, c.qty, c.disc_percent, c.cashier_id,  (p.price * c.qty * c.disc_percent) AS dis,  (p.price * c.qty - (p.price * c.qty * c.disc_percent)) AS total  FROM tbCar c  JOIN tbProduct p ON c.pid = p.id  WHERE c.sdate >= @fromdate AND c.sdate <= @todate AND c.[status] LIKE 'cancel' AND c.cashier_id like @cahierid;  
GO
/****** Object:  StoredProcedure [dbo].[SelectCart]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SelectCart]
@transno varchar(50)
as
SELECT c.id, c.pid, p.product, p.barcode, p.price, c.qty, c.disc_percent, c.cashier_id,      (p.price * c.qty * c.disc_percent) AS dis,      (p.price * c.qty - (p.price * c.qty * c.disc_percent)) AS total  FROM tbCar c  JOIN tbProduct p ON c.pid = p.id  WHERE c.transno LIKE @transno AND c.[status] LIKE 'pending';
GO
/****** Object:  StoredProcedure [dbo].[SelectCashiers]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SelectCashiers]
as
SELECT id,username FROM tbUser WHERE [role] LIKE 'Cashier'
GO
/****** Object:  StoredProcedure [dbo].[SelectCategory]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectCategory]
as
SELECT * FROM tbCategory ORDER BY category


GO
/****** Object:  StoredProcedure [dbo].[SelectProduct]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SelectProduct]
@search varchar(50)
as
SELECT p.id,p.barcode,p.product,b.brand, c.category, p.price
FROM tbProduct AS p
INNER JOIN tbBrand as b ON b.id = p.b_id
INNER JOIN tbCategory as c ON c.id = p.c_id
WHERE CONCAT(p.barcode,p.product,b.brand, c.category) LIKE '%' + @search + '%' 
GO
/****** Object:  StoredProcedure [dbo].[SelectProductByBarcode]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectProductByBarcode]
@barcode varchar(50)
as
SELECT id FROM tbProduct WHERE barcode like @barcode
GO
/****** Object:  StoredProcedure [dbo].[SelectProductForCasher]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SelectProductForCasher]   @search varchar(50)  as   SELECT       p.id AS id,       COALESCE(s.qty, 0) AS qty,      p.barcode,       p.product,   b.brand,   c.category,   p.price  FROM tbProduct p  inner join tbBrand as b on b.id =p.b_id  inner join tbCategory as c on c.id =p.c_id  LEFT JOIN (      SELECT           si.pid,           SUM(DISTINCT si.qty) - COALESCE(SUM(CASE WHEN o.status = 'confirmed' THEN o.qty ELSE 0 END), 0) AS qty      FROM tbStockIn si      LEFT JOIN tbCar o ON si.pid = o.pid      WHERE si.status = 'confirmed'      GROUP BY si.pid  ) s ON p.id = s.pid  WHERE CONCAT(p.barcode, p.product) LIKE '%' + @search + '%';
GO
/****** Object:  StoredProcedure [dbo].[SelectProductForStockIn]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SELECT OBJECT_DEFINITION (OBJECT_ID(N'SelectProductForCasher'));  

CREATE proc [dbo].[SelectProductForStockIn] 
@search varchar(50)
as
 SELECT 
    p.id AS id, 
    COALESCE(s.p_qty, 0) AS p_qty,
    p.barcode, 
    p.product
FROM tbProduct p
inner join tbBrand as b on b.id =p.b_id
inner join tbCategory as c on c.id =p.c_id
LEFT JOIN (
    SELECT 
        si.pid, 
        SUM(DISTINCT si.qty) - COALESCE(SUM(CASE WHEN o.status = 'confirmed' THEN o.qty ELSE 0 END), 0) AS p_qty
    FROM tbStockIn si
    LEFT JOIN tbCar o ON si.pid = o.pid
    WHERE si.status = 'confirmed'
    GROUP BY si.pid
) s ON p.id = s.pid
WHERE CONCAT(p.barcode, p.product) LIKE '%' + @search + '%';
GO
/****** Object:  StoredProcedure [dbo].[SelectStockIn]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectStockIn] 
as
select * from vtStockIn where status like 'pending'
GO
/****** Object:  StoredProcedure [dbo].[SelectStockInRecord]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


  




CREATE PROCEDURE [dbo].[SelectStockInRecord]   as  select * from vtStockIn where status like 'confirmed'
GO
/****** Object:  StoredProcedure [dbo].[SelectStoreInfo]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [dbo].[SelectStoreInfo]
as
SELECT * FROM tbStoreInfo
GO
/****** Object:  StoredProcedure [dbo].[SelectStoreSetting]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROC [dbo].[SelectStoreSetting]
as
select * from tbStoreInfo


GO
/****** Object:  StoredProcedure [dbo].[SelectSuplierForStock]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[SelectSuplierForStock]

as
SELECT supplier from tbSupplier 
GO
/****** Object:  StoredProcedure [dbo].[SelectSupplier]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectSupplier]
as
SELECT * from tbSupplier ORDER BY supplier
GO
/****** Object:  StoredProcedure [dbo].[SelectSupplierInfo]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[SelectSupplierInfo]
@supplier varchar(50)
as
SELECT id,contactperson,[address] from tbSupplier WHERE supplier like @supplier
GO
/****** Object:  StoredProcedure [dbo].[SelectTrans]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SelectTrans]
@cahierid varchar(50),
@fromdate date,
@todate date
as
SELECT c.id, c.pid, p.product, p.barcode, p.price, c.qty, c.disc_percent, c.cashier_id,
(p.price * c.qty * c.disc_percent) AS dis,
(p.price * c.qty - (p.price * c.qty * c.disc_percent)) AS total
FROM tbCar c  JOIN tbProduct p ON c.pid = p.id
WHERE c.sdate >= @fromdate AND c.sdate <= @todate AND c.[status] LIKE 'confirmed' AND c.cashier_id like @cahierid;
GO
/****** Object:  StoredProcedure [dbo].[TotalDailyCancel]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[TotalDailyCancel]
as
SELECT COUNT(*) AS num_rows FROM tbCar WHERE [status] = 'cancel' AND CAST(sdate AS DATE) = CAST(GETDATE() AS DATE);


GO
/****** Object:  StoredProcedure [dbo].[TotalDailyOrders]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[TotalDailyOrders]
as
SELECT COUNT(*) AS num_rows FROM tbCar WHERE [status] = 'confirmed' AND CAST(sdate AS DATE) = CAST(GETDATE() AS DATE);


GO
/****** Object:  StoredProcedure [dbo].[TotalDailySales]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[TotalDailySales]
as
SELECT COALESCE(SUM(p.price * c.qty - (p.price * c.qty * c.disc_percent)), 0) AS totalDail
FROM tbCar c JOIN tbProduct p ON c.pid = p.id
WHERE c.[status] = 'confirmed' AND CAST(c.sdate AS DATE) = CAST(GETDATE() AS DATE);

GO
/****** Object:  StoredProcedure [dbo].[UpdateBrand]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateBrand]
@id int,
@brand varchar(50)
as
UPDATE tbBrand SET brand = @brand WHERE id LIKE @id


GO
/****** Object:  StoredProcedure [dbo].[UpdateCaregory]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateCaregory]
@id int,
@category varchar(50)
as
UPDATE tbCategory SET category = @category WHERE id LIKE @id


GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateProduct]
@id int,
@barcode varchar(50),
@product varchar(MAX),
@b_id int,
@c_id int,
@price decimal(18, 2)
as
UPDATE tbProduct SET barcode = @barcode , product = @product , b_id = @b_id , c_id = @c_id , price = @price   WHERE id LIKE @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateStoreSetting]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateStoreSetting]
@StoreName varchar(50),
@StoreAddress varchar(MAX),
@tax decimal(18, 2)
as
UPDATE tbStoreInfo Set StoreName = @StoreName , StoreAddress = @StoreAddress,tax =@tax
GO
/****** Object:  StoredProcedure [dbo].[UpdateSuplier]    Script Date: 12/22/2023 4:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateSuplier]
@id int,
@supplier varchar(50),
@address varchar(MAX),
@contactperson varchar(50),
@phone varchar(15),
@email varchar(50),
@fax varchar(50)
as
UPDATE tbSupplier SET supplier = @Supplier , address = @address , contactperson = @contactperson , phone = @phone,email = @email,fax = @fax  WHERE id LIKE @id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbProduct"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbStockIn"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 287
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbSupplier"
            Begin Extent = 
               Top = 7
               Left = 532
               Bottom = 260
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbUser"
            Begin Extent = 
               Top = 7
               Left = 774
               Bottom = 170
               Right = 968
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vtStockIn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vtStockIn'
GO
USE [master]
GO
ALTER DATABASE [StoreManageDB] SET  READ_WRITE 
GO
