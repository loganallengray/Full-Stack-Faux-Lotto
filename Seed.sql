INSERT INTO [User] (Id, FirebaseId, UserName, FirstName, LastName, Email, ImageLocation, Currency, Wins, Losses)
VALUES
    (1, 'abc123', 'john.doe', 'John', 'Doe', 'john.doe@example.com', 'https://example.com/john.jpg', 1000, 10, 5),
    (2, 'def456', 'jane.smith', 'Jane', 'Smith', 'jane.smith@example.com', 'https://example.com/jane.jpg', 500, 5, 2),
    (3, 'ghi789', 'alex.brown', 'Alex', 'Brown', 'alex.brown@example.com', 'https://example.com/alex.jpg', 750, 8, 4),
    (4, 'jkl012', 'emily.johnson', 'Emily', 'Johnson', 'emily.johnson@example.com', 'https://example.com/emily.jpg', 250, 3, 6),
    (5, 'mno345', 'michael.wilson', 'Michael', 'Wilson', 'michael.wilson@example.com', 'https://example.com/michael.jpg', 1500, 15, 3);

INSERT INTO CoinGames (Id, UserId, AmountBet, NewAmount, Choice, Outcome, Win, Featured, [Date])
VALUES
    (1, 1, 50, 100, 'Heads', 'Heads', 1, 0, '2023-01-01'),
    (2, 2, 25, 0, 'Tails', 'Heads', 0, 0, '2023-01-02'),
    (3, 3, 100, 200, 'Tails', 'Tails', 1, 1, '2023-01-03'),
    (4, 4, 10, 0, 'Heads', 'Tails', 0, 0, '2023-01-04'),
    (5, 1, 50, 0, 'Heads', 'Tails', 0, 0, '2023-01-05'),
    (6, 2, 100, 200, 'Tails', 'Tails', 1, 0, '2023-01-06'),
    (7, 3, 25, 0, 'Heads', 'Tails', 0, 0, '2023-01-07'),
    (8, 4, 50, 100, 'Heads', 'Heads', 1, 0, '2023-01-08'),
    (9, 1, 10, 0, 'Tails', 'Heads', 0, 0, '2023-01-09'),
    (10, 2, 50, 100, 'Tails', 'Tails', 1, 1, '2023-01-10');

INSERT INTO HorseGames (Id, UserId, HorseBetId, HorseWonId, AmountBet, NewAmount, Win, Featured, [Date])
VALUES
    (1, 1, 3, 3, 100, 200, 1, 0, '2023-01-01'),
    (2, 2, 2, 1, 50, 0, 0, 0, '2023-01-02'),
    (3, 3, 1, 2, 25, 50, 1, 1, '2023-01-03'),
    (4, 4, 4, 3, 10, 0, 0, 0, '2023-01-04'),
    (5, 1, 3, 2, 50, 0, 0, 0, '2023-01-05'),
    (6, 2, 1, 1, 100, 200, 1, 0, '2023-01-06'),
    (7, 3, 2, 4, 25, 0, 0, 0, '2023-01-07'),
    (8, 4, 4, 4, 50, 100, 1, 0, '2023-01-08'),
    (9, 1, 1, 3, 10, 0, 0, 0, '2023-01-09'),
    (10, 2, 3, 2, 50, 100, 1, 1, '2023-01-10');

-- NEED REAL DATA
-- INSERT INTO CardGames (Id, UserId, AmountBet, NewAmount, Win, Featured, [Date])
-- VALUES
--     (1, 1, 50, 100, 1, 0, '2023-01-01'),
--     (2, 2, 25, 0, 0, 0, '2023-01-02'),
--     (3, 3, 100, 200, 1, 1, '2023-01-03'),
--     (4, 4, 10, 0, 0, 0, '2023-01-04'),
--     (5, 1, 50, 0, 0, 0, '2023-01-05'),
--     (6, 2, 100, 200, 1, 0, '2023-01-06'),
--     (7, 3, 25, 0, 0, 0, '2023-01-07'),
--     (8, 4, 50, 100, 1, 0, '2023-01-08'),
--     (9, 1, 10, 0, 0, 0, '2023-01-09'),
--     (10, 2, 50, 100, 1, 1, '2023-01-10');

INSERT INTO Horses (Id, Name, Description, Breed, Chances, Odds)
VALUES
    (1, 'Thunderbolt', 'A powerful and swift horse', 'Thoroughbred', 5, '3.5'),
    (2, 'Midnight Star', 'A black beauty with a gentle temperament', 'Arabian', 4, '2.8'),
    (3, 'Silver Bullet', 'A gray horse known for its endurance', 'Mustang', 3, '4.2'),
    (4, 'Golden Blaze', 'A palomino horse with a fiery spirit', 'Quarter Horse', 2, '6.1'),
    (5, 'Dashing Dancer', 'A graceful horse with elegant movements', 'Andalusian', 4, '3.9');

INSERT INTO cards (Id, Rank, House)
VALUES
    (1, 'Ace', 'Hearts'),
    (2, 'Two', 'Hearts'),
    (3, 'Three', 'Hearts'),
    (4, 'Four', 'Hearts'),
    (5, 'Five', 'Hearts'),
    (6, 'Six', 'Hearts'),
    (7, 'Seven', 'Hearts'),
    (8, 'Eight', 'Hearts'),
    (9, 'Nine', 'Hearts'),
    (10, 'Ten', 'Hearts'),
    (11, 'Jack', 'Hearts'),
    (12, 'Queen', 'Hearts'),
    (13, 'King', 'Hearts'),
    (14, 'Ace', 'Diamonds'),
    (15, 'Two', 'Diamonds'),
    (16, 'Three', 'Diamonds'),
    (17, 'Four', 'Diamonds'),
    (18, 'Five', 'Diamonds'),
    (19, 'Six', 'Diamonds'),
    (20, 'Seven', 'Diamonds'),
    (21, 'Eight', 'Diamonds'),
    (22, 'Nine', 'Diamonds'),
    (23, 'Ten', 'Diamonds'),
    (24, 'Jack', 'Diamonds'),
    (25, 'Queen', 'Diamonds'),
    (26, 'King', 'Diamonds'),
    (27, 'Ace', 'Clubs'),
    (28, 'Two', 'Clubs'),
    (29, 'Three', 'Clubs'),
    (30, 'Four', 'Clubs'),
    (31, 'Five', 'Clubs'),
    (32, 'Six', 'Clubs'),
    (33, 'Seven', 'Clubs'),
    (34, 'Eight', 'Clubs'),
    (35, 'Nine', 'Clubs'),
    (36, 'Ten', 'Clubs'),
    (37, 'Jack', 'Clubs'),
    (38, 'Queen', 'Clubs'),
    (39, 'King', 'Clubs'),
    (40, 'Ace', 'Spades'),
    (41, 'Two', 'Spades'),
    (42, 'Three', 'Spades'),
    (43, 'Four', 'Spades'),
    (44, 'Five', 'Spades'),
    (45, 'Six', 'Spades'),
    (46, 'Seven', 'Spades'),
    (47, 'Eight', 'Spades'),
    (48, 'Nine', 'Spades'),
    (49, 'Ten', 'Spades'),
    (50, 'Jack', 'Spades'),
    (51, 'Queen', 'Spades'),
    (52, 'King', 'Spades');