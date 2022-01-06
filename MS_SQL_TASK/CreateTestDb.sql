CREATE DATABASE TestDb;
GO
USE TestDb;

CREATE TABLE [dbo].[Categories] (
    [Id]   INT        IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Products] (
    [Id]   INT        IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ProductCategory] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ProductId]  INT NULL,
    [CategoryId] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([Id], [Name]) VALUES 
(1,'Lenovo Legion 5 Pro 16ACH6H'),
(2,'Lenovo IdeaPad Gaming 3 15ACH6'),
(3,'Acer Nitro 5 AN515-57'),
(4,'MSI Sword 15 A11UE'),
(5,'HP Victus 16-e0000'),
(6,'Lenovo IdeaPad 5 Pro 16ACH6'),
(7,'Honor MagicBook 14 2021'),
(8,'Asus ZenBook 13 UX325EA'),
(9,'Xiaomi Redmibook Pro 14 Ryzen Edition'),
(10,'Lenovo ThinkBook 15 G3 ACL'),
(11,'Asus TUF Gaming F15 FX506HCB'),
(12,'MSI Modern 15 A10M'),
(13,'Lenovo ThinkBook 15 G2 ARE'),
(14,'HP ProBook 455 G8')
SET IDENTITY_INSERT [dbo].[Products] OFF

SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES 
(1,'Work'),(2,'Games'),(3,'Graphics'),(4,'Video Editing'),
(5,'Lightweight'),(6,'Long autonomy'),(7,'Shockproof')
SET IDENTITY_INSERT [dbo].[Categories] OFF

SET IDENTITY_INSERT [dbo].[ProductCategory] ON
INSERT INTO [dbo].[ProductCategory] ([Id], [ProductId], [CategoryId]) VALUES
(1, 1, 2),(2, 1, 1),(3, 1, 4),(4, 1, 2),(5, 1, 2),(6, 3, 6),(7, 5, 4),(8, 13, 6),
(9, 7, 3),(10, 7, 2),(11, 7, 7),(12, 9, 5),(13, 9, 1),(14, 12, 1),(15, 12, 7),
(16, 4, 4),(17, 4, 4),(18, 4, 4),(19, 3, 5),(20, 3, 7),(21, 3, 7),(22, 5, 4)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
