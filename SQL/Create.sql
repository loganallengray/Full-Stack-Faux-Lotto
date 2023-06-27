USE [master]

IF db_id('FauxLotto') IS NULl
  CREATE DATABASE [FauxLotto]
GO

USE [FauxLotto]
GO

DROP TABLE IF EXISTS [Users];
DROP TABLE IF EXISTS [CoinGames];
DROP TABLE IF EXISTS [HorseGames];
DROP TABLE IF EXISTS [Horses];
DROP TABLE IF EXISTS [CardGames];
DROP TABLE IF EXISTS [UserDeck];
DROP TABLE IF EXISTS [DealerDeck];
DROP TABLE IF EXISTS [Cards];
GO

CREATE TABLE [Users] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FirebaseId] varchar(28) NOT NULL,
  [UserName] varchar(50) NOT NULL,
  [FirstName] varchar(50) NOT NULL,
  [LastName] varchar(50) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [ImageLocation] nvarchar(255) NOT NULL,
  [Currency] int NOT NULL,
  [Wins] int NOT NULL,
  [Losses] int NOT NULL
)
GO

CREATE TABLE [CoinGames] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [AmountBet] int NOT NULL,
  [NewAmount] int NOT NULL,
  [Choice] nvarchar(255) NOT NULL,
  [Outcome] nvarchar(255) NOT NULL,
  [Win] bit NOT NULL,
  [Featured] bit NOT NULL,
  [Date] datetime NOT NULL
)
GO

CREATE TABLE [HorseGames] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [HorseBetId] int NOT NULL,
  [HorseWonId] int NOT NULL,
  [AmountBet] int NOT NULL,
  [NewAmount] int NOT NULL,
  [Win] bit NOT NULL,
  [Featured] bit NOT NULL,
  [Date] datetime NOT NULL
)
GO

CREATE TABLE [Horses] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [Description] nvarchar(255) NOT NULL,
  [Breed] nvarchar(255) NOT NULL,
  [Chances] int NOT NULL,
  [Odds] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [CardGames] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [AmountBet] int NOT NULL,
  [NewAmount] int NOT NULL,
  [Win] bit NOT NULL,
  [Featured] bit NOT NULL,
  [Date] datetime NOT NULL
)
GO

CREATE TABLE [UserDeck] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [cardId] int NOT NULL,
  [cardGameId] int NOT NULL
)
GO

CREATE TABLE [DealerDeck] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [cardId] int NOT NULL,
  [cardGameId] int NOT NULL
)
GO

CREATE TABLE [Cards] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [House] nvarchar(255) NOT NULL,
  [Rank] nvarchar(255) NOT NULL
)
GO

ALTER TABLE [CoinGames] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [HorseGames] ADD FOREIGN KEY ([HorseWonId]) REFERENCES [Horses] ([Id])
GO

ALTER TABLE [HorseGames] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [CardGames] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [UserDeck] ADD FOREIGN KEY ([cardGameId]) REFERENCES [CardGames] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [DealerDeck] ADD FOREIGN KEY ([cardGameId]) REFERENCES [CardGames] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [UserDeck] ADD FOREIGN KEY ([cardId]) REFERENCES [Cards] ([Id])
GO

ALTER TABLE [DealerDeck] ADD FOREIGN KEY ([cardId]) REFERENCES [Cards] ([Id])
GO

ALTER TABLE [HorseGames] ADD FOREIGN KEY ([HorseBetId]) REFERENCES [Horses] ([Id])
GO
