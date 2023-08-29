CREATE DATABASE Krølls_bank;

USE Krølls_bank;


CREATE TABLE Client_Account (
Client_Account_ID INT NOT NULL PRIMARY KEY,
Client_ID INT NOT NULL /*FOREIGN KEY REFERENCES Clients(Client_ID) */,
Account_ID INT NOT NULL /*FOREIGN KEY REFERENCES Accounts(Account_ID) */
);

CREATE TABLE Clients (
Client_ID INT NOT NULL PRIMARY KEY,
Client_name varchar(50) NOT NULL,
Balance DECIMAL NOT NULL
);

CREATE TABLE Accounts(
Account_ID INT NOT NULL PRIMARY KEY,
Card_ID INT NOT NULL /*FOREIGN KEY REFERENCES Cards(Card_ID) */
);

CREATE TABLE Cards(
Card_ID INT NOT NULL PRIMARY KEY,
Card_nr VARCHAR(16) NOT NULL,
Expire_Date DATE NOT NULL,
CVV SMALLINT NOT NULL,
Client_name VARCHAR(50) NOT NULL,
Pin SMALLINT NOT NULL
);

CREATE TABLE CPRs(
CPR_nr VARCHAR(10) NOT NULL PRIMARY KEY, 
Client_ID INT NOT NULL /* FOREIGN KEY REFERENCES Clients(Client_ID) */,
);

CREATE TABLE Employees (
Employee_ID INT NOT NULL PRIMARY KEY, 
CPR_nr VARCHAR(10) NOT NULL /*FOREIGN KEY REFERENCES CPRs(CPR_nr) */,
Position varchar(30) NOT NULL
);

CREATE TABLE Addresses(
Address_ID INT NOT NULL PRIMARY KEY,
Post_nr SMALLINT NOT NULL,
City VARCHAR(30) NOT NULL,
Street VARCHAR(40) NOT NULL,
House_nr SMALLINT NOT NULL
);

CREATE TABLE Loans (
Loan_ID INT NOT NULL PRIMARY KEY, 
Client_ID INT NOT NULL /*FOREIGN KEY REFERENCES Clients(Client_ID)*/,
APR TINYINT NOT NULL, 
Amount INT NOT NULL
);

CREATE TABLE Client_job(
Client_job_ID INT PRIMARY KEY,
Job_ID INT NOT NULL /* FOREIGN KEY REFERENCES Job(Job_ID)*/,
Client_ID INT NOT NULL /*FOREIGN KEY REFERENCES Clients(Client_ID) */
);

CREATE TABLE Job(
Job_ID INT NOT NULL PRIMARY KEY,
Income INT NOT NULL, 
Job_name VARCHAR(30) NOT NULL
);

CREATE TABLE CPR_Address(
CPR_Address_ID INT NOT NULL PRIMARY KEY,
Address_ID INT NOT NULL /*FOREIGN KEY REFERENCES Addresses(Address_ID)*/,
CPR_nr VARCHAR(10) NOT NULL /*FOREIGN KEY REFERENCES CPRs(CPR_nr) */
);

INSERT INTO clients (Client_id, Client_name, Balance)
VALUES
    (1, 'Emre', 69420),
    (2, 'Janick', 392986),
    (3, 'Jonas Offersen', 85930),
    (4, 'Jonas Steinmejer', 420),
    (5, 'Kris', 85493649),
    (6, 'Kristoffer', 39547332),
    (7, 'Lucas', 32506),
    (8, 'Magnus', 69),
    (9, 'Marcus', 95043),
    (10, 'Matias', 56542),
    (11, 'Mikkel Christensen', 214544),
    (12, 'Mikkel Smidt', 56343),
    (13, 'Nicklas', 645435),
    (14, 'Niklas', 735768),
    (15, 'Rasmus', 865389),
    (16, 'Robert', 85624),
    (17, 'Rune', 654268),
    (18, 'Shazil', 99999999),
    (19, 'Tian', 534563),
    (20, 'Yordan', 234625),
    (21, 'Zakarias', 12354);
	
INSERT INTO CPRs (CPR_nr, Client_ID)
VALUES
    ('0306011234', 1),
    ('1308072345', 2),
    ('2203053456', 3),
    ('0710124567', 4),
    ('1911115678', 5),
    ('2602016789', 6),
    ('1004197890', 7),
    ('0810248901', 8),
    ('2106329012', 9),
    ('1109110123', 10),
    ('1807031234', 11),
    ('1401232345', 12),
    ('2206013456', 13),
    ('3008124567', 14),
    ('0411155678', 15),
    ('2206196789', 16),
    ('3108197890', 17),
    ('0910248901', 18),
    ('2405129012', 19),
    ('0807010123', 20),
    ('1201231234', 21);

INSERT INTO Loans (Loan_ID, Client_ID, APR, Amount)
VALUES
    (1, 1, 10, 15000),
    (2, 3, 8, 8000),
    (3, 6, 12, 25000),
    (4, 7, 15, 35000),
    (5, 10, 18, 50000),
    (6, 13, 9, 12000),
    (7, 14, 7, 18000),
    (8, 15, 14, 42000),
    (9, 17, 11, 29000),
    (10, 21, 16, 47000);

INSERT INTO Employees (Employee_ID, CPR_nr, Position)
VALUES
    (1, '0710124567', 'Security'),  			-- Jonas
    (2, '0810248901', 'Janitor'),   			-- Magnus
    (3, '0807010123', 'Clerk'),   				-- Yordan
    (4, '0910248901', 'Cyber security expert'),  -- Shazil
	(5, '1807031234', 'Manager');				-- Krøll
	
INSERT INTO Job (Job_ID, Income, Job_name)
VALUES
    (1, 25435, 'McDonalds'),         -- Nicklas
    (2, 22657, 'McDonalds'),         -- Robert
    (3, 18323, 'McDonalds'),         -- Marcus
    (4, 21876, 'McDonalds'),         -- Emre
    (5, 23654, 'McDonalds'),         -- Zakarias
    (6, 19765, 'McDonalds'),         -- Lucas
    (7, 18875, 'McDonalds'),         -- Janick
    (8, 17234, 'McDonalds'),         -- Mikkel Smidt
    (9, 25765, 'McDonalds'),         -- Rasmus
    (10, 30258, 'McDonalds'),        -- Rune
    (11, 21765, 'McDonalds'),        -- Niklas
    (12, 20356, 'McDonalds'),        -- Matias
    (13, 30927, 'Krøll bank Janitor'),       -- Magnus
    (14, 28326, 'Krøll bank Manager'),       -- Mikkel Christensen
    (15, 25678, 'Krøll bank Clerk'),       -- Yordan
    (16, 35234, 'Krøll bank Security'),       -- Jonas Steinmejer
    (17, 27087, 'Krøll bank Cyber security'),       -- Shazil
    (18, 22349, 'Bakery'),           -- Tian
    (19, 23574, 'Bakery'),           -- Jonas Offersen
    (20, 5835793, 'Fashion designer'), -- Kris
    (21, 0, 'Jobless');                  -- Kristoffer
	
INSERT INTO Cards (Card_ID, Card_nr, Expire_Date, CVV, Client_name, Pin)
VALUES
    (1, '1234567890123456', '2024-12-31', 123, 'Nicklas', 9876),
    (2, '2345678901234567', '2025-01-15', 234, 'Robert', 8765),
    (3, '3456789012345678', '2023-11-30', 345, 'Marcus', 7654),
    (4, '4567890123456789', '2023-08-25', 456, 'Emre', 6543),
    (5, '5678901234567890', '2024-06-10', 567, 'Zakarias', 5432),
    (6, '6789012345678901', '2025-02-28', 678, 'Lucas', 4321),
    (7, '7890123456789012', '2023-09-18', 789, 'Janick', 3210),
    (8, '8901234567890123', '2024-03-22', 890, 'Mikkel Smidt', 2109),
    (9, '9012345678901234', '2023-07-05', 901, 'Rasmus', 1098),
    (10, '0123456789012345', '2025-05-20', 012, 'Rune', 0987),
    (11, '1234567890123456', '2024-12-31', 123, 'Niklas', 9876),
    (12, '2345678901234567', '2025-01-15', 234, 'Mikkel Christensen', 8765),
    (13, '3456789012345678', '2023-11-30', 345, 'Yordan', 7654),
    (14, '4567890123456789', '2023-08-25', 456, 'Jonas Steinmejer', 6543),
    (15, '5678901234567890', '2024-06-10', 567, 'Shazil', 5432),
    (16, '6789012345678901', '2025-02-28', 678, 'Kristoffer', 4321),
    (17, '7890123456789012', '2023-09-18', 789, 'Kristoffer', 3210),
    (18, '8901234567890123', '2024-03-22', 890, 'Kristoffer', 2109),
    (19, '9012345678901234', '2023-07-05', 901, 'Kris', 1098),
    (20, '0123456789012345', '2025-05-20', 012, 'Kris', 0987),
    (21, '1234567890123456', '2024-12-31', 123, 'Mikkel Christensen', 9876),
	(22, '7593987593859392', '2026-04-05', 853, 'Magnus', 8302),
	(23, '7534842859402346', '2025-09-03', 830, 'Matias', 7239),
	(24, '7502363549057326', '2024-04-12', 730, 'Tian', 5424),
	(25, '4628506375068940', '2025-05-05', 341, 'Jonas Offersen', 9999);  -- Updated Pin value
	
INSERT INTO Accounts (Account_ID, Card_ID)
VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 4),
    (5, 5),
    (6, 6),
    (7, 7),
    (8, 8),
    (9, 9),
    (10, 10),
    (11, 11),
    (12, 12),
    (13, 13),
    (14, 14),
    (15, 15),
    (16, 16),
    (17, 17),
    (18, 18),
    (19, 19),
    (20, 20),
    (21, 21),
    (22, 22),
    (23, 23),
    (24, 24),
    (25, 25);

INSERT INTO Client_Account (Client_Account_ID, Client_ID, Account_ID)
VALUES
    (1, 1, 1),
    (2, 2, 2),
    (3, 3, 3),
    (4, 4, 4),
    (5, 5, 5),
    (6, 6, 6),
    (7, 7, 7),
    (8, 8, 8),
    (9, 9, 9),
    (10, 10, 10),
    (11, 11, 11),
    (12, 12, 12),
    (13, 13, 13),
    (14, 14, 14),
    (15, 15, 15),
    (16, 16, 16),
    (17, 17, 17),
    (18, 18, 18),
    (19, 19, 19),
    (20, 20, 20),
    (21, 21, 21),
    (22, 21, 22),
    (23, 21, 23),
    (24, 18, 24),
    (25, 14, 25);
	
INSERT INTO Client_Job (Client_Job_ID, Job_ID, Client_ID)
VALUES
    (1, 1, 1),     -- Nicklas
    (2, 2, 2),     -- Robert
    (3, 3, 3),     -- Marcus
    (4, 4, 4),     -- Emre
    (5, 5, 6),     -- Lucas
    (6, 6, 7),     -- Janick
    (7, 7, 8),     -- Mikkel Smidt
    (8, 8, 9),     -- Rasmus
    (9, 9, 10),    -- Rune
    (10, 11, 11),  -- Niklas
    (11, 12, 12),  -- Matias
    (12, 13, 13),  -- Magnus
    (13, 14, 14),  -- Mikkel Christensen
    (14, 15, 15),  -- Yordan
    (15, 16, 16),  -- Jonas Steinmejer
    (16, 17, 17),  -- Shazil
    (17, 18, 18),  -- Tian
    (18, 19, 19),  -- Jonas Offersen
    (19, 20, 20),  -- Kris
    (20, 21, 21);  -- Kristoffer

INSERT INTO Addresses (Address_ID, Post_nr, City, Street, House_nr)
VALUES
    (1, 1234, 'Copenhagen', 'Main Street', 10),
    (2, 5678, 'Aarhus', 'Park Avenue', 25),
    (3, 9101, 'Odense', 'Grove Street', 7),
    (4, 2345, 'Aalborg', 'Lake Road', 15),
    (5, 6789, 'Esbjerg', 'River Street', 30),
    (6, 1011, 'Roskilde', 'Hillside Avenue', 12),
    (7, 3456, 'Horsens', 'Sunset Boulevard', 8),
    (8, 7890, 'Vejle', 'Meadow Lane', 22),
    (9, 1112, 'Helsingør', 'Ocean View', 18),
    (10, 1314, 'Randers', 'Forest Drive', 17),
    (11, 1516, 'Kolding', 'Valley Road', 11),
    (12, 1718, 'Silkeborg', 'Skyline Drive', 9),
    (13, 1920, 'Naestved', 'Mountain Street', 14),
    (14, 2122, 'Fredericia', 'Harbor Avenue', 20),
    (15, 2324, 'Frederikshavn', 'Boulevard', 6),
    (16, 2526, 'Viborg', 'Ridge Road', 13),
    (17, 2728, 'Holstebro', 'Lake Avenue', 16),
    (18, 2930, 'Taastrup', 'Spring Street', 23),
    (19, 3132, 'Albertslund', 'Creek Road', 21),
    (20, 3334, 'Esbjerg', 'Hillside Court', 5),
    (21, 3536, 'Roskilde', 'River Road', 19),
    (22, 3738, 'Holbæk', 'Crescent Street', 26);

INSERT INTO CPR_Address (CPR_Address_ID, Address_ID, CPR_nr)
values
    (1, 1, '0306011234'),
    (2, 2, '1308072345'),
    (3, 3, '2203053456'),
    (4, 4, '0710124567'),
    (5, 5, '1911115678'),
    (6, 6, '2602016789'),
    (7, 7, '1004197890'),
    (8, 8, '0810248901'),
    (9, 9, '2106329012'),
    (10, 10, '1109110123'),
    (11, 11, '1807031234'),
    (12, 12, '1401232345'),
    (13, 13, '2206013456'),
    (14, 14, '3008124567'),
    (15, 15, '0411155678'),
    (16, 16, '2206196789'),
    (17, 17, '3108197890'),
    (18, 18, '0910248901'),
    (19, 19, '2405129012'),
    (20, 20, '0807010123'),
    (21, 21, '1201231234'),
    (22, 22, '1911115678'); 

ALTER TABLE Client_Account ADD FOREIGN KEY(Account_ID) REFERENCES Accounts (Account_ID);
ALTER TABLE Client_Account ADD FOREIGN KEY(Client_ID) REFERENCES Clients (Client_ID);
ALTER TABLE Accounts ADD FOREIGN KEY(Card_ID) REFERENCES Cards (Card_ID);
ALTER TABLE CPRs ADD FOREIGN KEY(Client_ID) REFERENCES Clients (Client_ID);
ALTER TABLE Employees ADD FOREIGN KEY(CPR_nr) REFERENCES CPRs (CPR_nr);
ALTER TABLE Loans ADD FOREIGN KEY(Client_ID) REFERENCES Clients (Client_ID);
ALTER TABLE Client_job ADD FOREIGN KEY(Job_ID) REFERENCES Job (Job_ID);
ALTER TABLE Client_job ADD FOREIGN KEY(Client_ID) REFERENCES Clients (Client_ID);
ALTER TABLE CPR_Address ADD FOREIGN KEY(Address_ID) REFERENCES Addresses (Address_ID);
ALTER TABLE CPR_Address ADD FOREIGN KEY(CPR_nr) REFERENCES CPRs (CPR_nr);