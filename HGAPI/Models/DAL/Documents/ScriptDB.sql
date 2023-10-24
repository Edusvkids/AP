CREATE DATABASE HappyGamesDB
GO
USE HappyGamesDB
GO

CREATE TABLE UserPlayerEN(
  Id int IDENTITY (1,1) PRIMARY KEY,
  NamePlayer VARCHAR(50) NOT NULL,
  GmailPlayer VARCHAR(50) NOT NULL,
  PasswordPlayer VARCHAR(30) NOT NULL,
);
GO

CREATE TABLE ProductGames(
   Id int IDENTITY (1,1) PRIMARY KEY,
   IdUserPlayer int,
   NameProduct VARCHAR(50) NOT NULL,
   DescriptionProduct VARCHAR(100) NOT NULL,
   PriceProduct int NOT NULL,
   TypeProduct VARCHAR(20) NOT NULL,
   bought int NOT NULL,
   foreign key (IdUserPlayer) references UserPlayerEN(Id)
);
GO

CREATE TABLE PurchaseOrder(
   Id int IDENTITY (1,1) PRIMARY KEY,
   IdUserPlayer int,
   NameOrder VARCHAR(50) NOT NULL,
   DateOrder DATE NOT NULL,
   Headline VARCHAR(30) NOT NULL,
   SubTotal int NOT NULL,
   Total int NOT NULL,
   foreign key (IdUserPlayer) references UserPlayerEN(Id)
);
GO