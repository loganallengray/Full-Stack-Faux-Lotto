CREATE TABLE `Users` (
  `Id` int PRIMARY KEY AUTO_INCREMENT,
  `FirebaseId` varchar(28) NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Imagelocation` varchar(255) NOT NULL,
  `Currency` int NOT NULL,
  `Wins` int NOT NULL,
  `Losses` int NOT NULL
);

CREATE TABLE `CoinGames` (
  `Id` int PRIMARY KEY AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `AmountBet` int NOT NULL,
  `NewAmount` int NOT NULL,
  `Choice` varchar(255) NOT NULL,
  `Outcome` varchar(255) NOT NULL,
  `Win` bit NOT NULL,
  `Featured` bit NOT NULL,
  `Date` datetime NOT NULL
);

CREATE TABLE `HorseGames` (
  `Id` int PRIMARY KEY AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `HorseBetId` int NOT NULL,
  `HorseWonId` int NOT NULL,
  `AmountBet` int NOT NULL,
  `NewAmount` int NOT NULL,
  `Win` bit NOT NULL,
  `Featured` bit NOT NULL,
  `Date` datetime NOT NULL
);

CREATE TABLE `Horses` (
  `Id` int PRIMARY KEY AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `Breed` varchar(255) NOT NULL,
  `Chances` int NOT NULL,
  `Odds` varchar(255) NOT NULL
);

CREATE TABLE `CardGames` (
  `Id` int PRIMARY KEY AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `AmountBet` int NOT NULL,
  `NewAmount` int NOT NULL,
  `Win` bit NOT NULL,
  `Featured` bit NOT NULL,
  `Date` datetime NOT NULL
);

CREATE TABLE `UserDeck` (
  `Id` int PRIMARY KEY AUTO_INCREMENT,
  `cardId` int NOT NULL,
  `cardGameId` int NOT NULL
);

CREATE TABLE `DealerDeck` (
  `Id` int PRIMARY KEY AUTO_INCREMENT,
  `cardId` int NOT NULL,
  `cardGameId` int NOT NULL
);

CREATE TABLE `Cards` (
  `Id` int PRIMARY KEY AUTO_INCREMENT,
  `House` varchar(255) NOT NULL,
  `Rank` varchar(255) NOT NULL
);

ALTER TABLE `CoinGames` ADD FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`);

ALTER TABLE `HorseGames` ADD FOREIGN KEY (`HorseWonId`) REFERENCES `Horses` (`Id`);

ALTER TABLE `HorseGames` ADD FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`);

ALTER TABLE `CardGames` ADD FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`);

ALTER TABLE `UserDeck` ADD FOREIGN KEY (`cardGameId`) REFERENCES `CardGames` (`Id`) ON DELETE CASCADE;

ALTER TABLE `DealerDeck` ADD FOREIGN KEY (`cardGameId`) REFERENCES `CardGames` (`Id`) ON DELETE CASCADE;

ALTER TABLE `UserDeck` ADD FOREIGN KEY (`cardId`) REFERENCES `Cards` (`Id`);

ALTER TABLE `DealerDeck` ADD FOREIGN KEY (`cardId`) REFERENCES `Cards` (`Id`);

ALTER TABLE `HorseGames` ADD FOREIGN KEY (`HorseBetId`) REFERENCES `Horses` (`Id`);
