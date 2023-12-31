﻿CREATE DATABASE HappyGamesDB
GO
USE HappyGamesDB
GO

CREATE TABLE UserPlayerEN(
  Id int IDENTITY (1,1) PRIMARY KEY,
  NamePlayer VARCHAR(50) NOT NULL,
  GmailPlayer VARCHAR(50) NOT NULL,
  PasswordPlayer VARCHAR(30) NOT NULL,
  LevelPlayer INT DEFAULT 1 not null
);
GO

CREATE TABLE ProductGames(
   Id int IDENTITY (1,1) PRIMARY KEY,
   NameProduct VARCHAR(50) NOT NULL,
   DescriptionProduct VARCHAR(100) NOT NULL,
   PriceProduct int NOT NULL,
   TypeProduct VARCHAR(20) NOT NULL,
);
GO

CREATE TABLE PurchaseOrder(
   Id int IDENTITY (1,1) PRIMARY KEY,
   IdUserPlayer int,
   IdProductGames int,
   NameOrder VARCHAR(50) NOT NULL,
   DateOrder DATE NOT NULL,
   Headline VARCHAR(30) NOT NULL,
   StateOrder varchar(50) default ('pending'),
   Total int NOT NULL,
   foreign key (IdUserPlayer) references UserPlayerEN(Id),
   foreign key (IdProductGames) references ProductGames(Id)
);
GO
SET IDENTITY_INSERT ProductGames ON;
INSERT INTO ProductGames (Id, NameProduct, DescriptionProduct, PriceProduct, TypeProduct)
VALUES (100, 'Aumento de vida 200', 'Aumento de vida 200', 2, 'Vida');
SET IDENTITY_INSERT ProductGames OFF;
