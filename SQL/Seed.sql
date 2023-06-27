INSERT INTO Users (FirebaseId, UserName, FirstName, LastName, Email, ImageLocation, Currency, Wins, Losses)
VALUES
    ('abc123', 'john.doe', 'John', 'Doe', 'john.doe@example.com', 'https://example.com/john.jpg', 1000, 10, 5),
    ('def456', 'jane.smith', 'Jane', 'Smith', 'jane.smith@example.com', 'https://example.com/jane.jpg', 500, 5, 2),
    ('ghi789', 'alex.brown', 'Alex', 'Brown', 'alex.brown@example.com', 'https://example.com/alex.jpg', 750, 8, 4),
    ('jkl012', 'emily.johnson', 'Emily', 'Johnson', 'emily.johnson@example.com', 'https://example.com/emily.jpg', 250, 3, 6),
    ('mno345', 'michael.wilson', 'Michael', 'Wilson', 'michael.wilson@example.com', 'https://example.com/michael.jpg', 1500, 15, 3);

INSERT INTO CoinGames (UserId, AmountBet, NewAmount, Choice, Outcome, Win, Featured, [Date])
VALUES
    (1, 50, 100, 'Heads', 'Heads', 1, 0, '2023-01-01'),
    (2, 25, 0, 'Tails', 'Heads', 0, 0, '2023-01-02'),
    (3, 100, 200, 'Tails', 'Tails', 1, 1, '2023-01-03'),
    (4, 10, 0, 'Heads', 'Tails', 0, 0, '2023-01-04'),
    (1, 50, 0, 'Heads', 'Tails', 0, 0, '2023-01-05'),
    (2, 100, 200, 'Tails', 'Tails', 1, 0, '2023-01-06'),
    (3, 25, 0, 'Heads', 'Tails', 0, 0, '2023-01-07'),
    (4, 50, 100, 'Heads', 'Heads', 1, 0, '2023-01-08'),
    (1, 10, 0, 'Tails', 'Heads', 0, 0, '2023-01-09'),
    (2, 50, 100, 'Tails', 'Tails', 1, 1, '2023-01-10');

INSERT INTO Horses ([Name], [Description], Breed, Chances, Odds)
VALUES
    ('Thunderbolt', 'A powerful and swift horse', 'Thoroughbred', 5, '3.5'),
    ('Midnight Star', 'A black beauty with a gentle temperament', 'Arabian', 4, '2.8'),
    ('Silver Bullet', 'A gray horse known for its endurance', 'Mustang', 3, '4.2'),
    ('Golden Blaze', 'A palomino horse with a fiery spirit', 'Quarter Horse', 2, '6.1'),
    ('Dashing Dancer', 'A graceful horse with elegant movements', 'Andalusian', 4, '3.9');

INSERT INTO HorseGames (UserId, HorseBetId, HorseWonId, AmountBet, NewAmount, Win, Featured, [Date])
VALUES
    (1, 3, 3, 100, 200, 1, 0, '2023-01-01'),
    (2, 2, 1, 50, 0, 0, 0, '2023-01-02'),
    (3, 1, 2, 25, 50, 1, 1, '2023-01-03'),
    (4, 4, 3, 10, 0, 0, 0, '2023-01-04'),
    (1, 3, 2, 50, 0, 0, 0, '2023-01-05'),
    (2, 1, 1, 100, 200, 1, 0, '2023-01-06'),
    (3, 2, 4, 25, 0, 0, 0, '2023-01-07'),
    (4, 4, 4, 50, 100, 1, 0, '2023-01-08'),
    (1, 1, 3, 10, 0, 0, 0, '2023-01-09'),
    (2, 3, 2, 50, 100, 1, 1, '2023-01-10');

INSERT INTO Cards ([Rank], House)
VALUES
    ('Ace', 'Hearts'),
    ('Two', 'Hearts'),
    ('Three', 'Hearts'),
    ('Four', 'Hearts'),
    ('Five', 'Hearts'),
    ('Six', 'Hearts'),
    ('Seven', 'Hearts'),
    ('Eight', 'Hearts'),
    ('Nine', 'Hearts'),
    ('Ten', 'Hearts'),
    ('Jack', 'Hearts'),
    ('Queen', 'Hearts'),
    ('King', 'Hearts'),
    ('Ace', 'Diamonds'),
    ('Two', 'Diamonds'),
    ('Three', 'Diamonds'),
    ('Four', 'Diamonds'),
    ('Five', 'Diamonds'),
    ('Six', 'Diamonds'),
    ('Seven', 'Diamonds'),
    ('Eight', 'Diamonds'),
    ('Nine', 'Diamonds'),
    ('Ten', 'Diamonds'),
    ('Jack', 'Diamonds'),
    ('Queen', 'Diamonds'),
    ('King', 'Diamonds'),
    ('Ace', 'Clubs'),
    ('Two', 'Clubs'),
    ('Three', 'Clubs'),
    ('Four', 'Clubs'),
    ('Five', 'Clubs'),
    ('Six', 'Clubs'),
    ('Seven', 'Clubs'),
    ('Eight', 'Clubs'),
    ('Nine', 'Clubs'),
    ('Ten', 'Clubs'),
    ('Jack', 'Clubs'),
    ('Queen', 'Clubs'),
    ('King', 'Clubs'),
    ('Ace', 'Spades'),
    ('Two', 'Spades'),
    ('Three', 'Spades'),
    ('Four', 'Spades'),
    ('Five', 'Spades'),
    ('Six', 'Spades'),
    ('Seven', 'Spades'),
    ('Eight', 'Spades'),
    ('Nine', 'Spades'),
    ('Ten', 'Spades'),
    ('Jack', 'Spades'),
    ('Queen', 'Spades'),
    ('King', 'Spades');

-- NEED REAL DATA
-- INSERT INTO CardGames (UserId, AmountBet, NewAmount, Win, Featured, [Date])
-- VALUES
--     (1, 50, 100, 1, 0, '2023-01-01'),
--     (2, 25, 0, 0, 0, '2023-01-02'),
--     (3, 100, 200, 1, 1, '2023-01-03'),
--     (4, 10, 0, 0, 0, '2023-01-04'),
--     (1, 50, 0, 0, 0, '2023-01-05'),
--     (2, 100, 200, 1, 0, '2023-01-06'),
--     (3, 25, 0, 0, 0, '2023-01-07'),
--     (4, 50, 100, 1, 0, '2023-01-08'),
--     (1, 10, 0, 0, 0, '2023-01-09'),
--     (2, 50, 100, 1, 1, '2023-01-10');