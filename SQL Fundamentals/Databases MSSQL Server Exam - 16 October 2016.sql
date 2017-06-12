
--Section 1: DDL
CREATE TABLE Tickets (
	TicketID int PRIMARY KEY NOT NULL,
	Price decimal(8, 2) NOT NULL,
	Class char(6),
	Seat char(5),
	CustomerID int,
	FlightID int,
	CHECK(Class IN('First', 'Second', 'Third'))
)

CREATE TABLE Flights (
	FlightID int PRIMARY KEY NOT NULL,
	DepartureTime datetime NOT NULL,
	ArrivalTime datetime NOT NULL,
	Status char(9),
	OriginAirportID int,
	DestinationAirportID int,
	AirlineID int,
	CHECK(Status IN('Departing', 'Delayed', 'Arrived', 'Cancelled'))
)

ALTER TABLE Tickets 
ADD
	CONSTRAINT FK_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
	CONSTRAINT FK_FlightID FOREIGN KEY (FlightID) REFERENCES Flights(FlightID)

ALTER TABLE Flights
ADD
	CONSTRAINT FK_OriginAirportID FOREIGN KEY (OriginAirportID) REFERENCES Airports(AirportID),
	CONSTRAINT FK_DestinationAirportID FOREIGN KEY (DestinationAirportID) REFERENCES Airports(AirportID),
	CONSTRAINT FK_AirlineID FOREIGN KEY (AirlineID) REFERENCES Airlines(AirlineID)

--Section 2: DML - 01. Data Insertion
INSERT INTO Flights
VALUES (1, '2016-10-13 06:00 AM', '2016-10-13 10:00 AM', 'Delayed', 1, 4, 1),
(2, '2016-10-12 12:00 PM', '2016-10-12 12:01 PM', 'Departing', 1, 3, 2),
(3, '2016-10-14 03:00 PM', '2016-10-20 04:00 AM', 'Delayed', 4, 2, 4),
(4, '2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 'Departing', 3, 1, 3),
(5, '2016-10-12 08:11 AM', '2016-10-12 11:22 PM', 'Departing', 4, 1, 1),
(6, '1995-06-21 12:30 PM', '1995-06-22 08:30 PM', 'Arrived', 2, 3, 5),
(7, '2016-10-12 11:34 PM', '2016-10-13 03:00 AM', 'Departing', 2, 4, 2),
(8, '2016-11-11 01:00 PM', '2016-11-12 10:00 PM', 'Delayed', 4, 3, 1),
(9, '2015-10-01 12:00 PM', '2015-12-01 01:00 AM', 'Arrived', 1, 2, 1),
(10, '2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 'Departing', 2, 1, 7)

INSERT INTO Tickets
VALUES
(1, 3000.00, 'First', '233-A', 3, 8),
(2, 1799.90, 'Second', '123-D', 1, 1),
(3, 1200.50, 'Second', '12-Z', 2, 5),
(4, 410.68, 'Third', '45-Q', 2, 8),
(5, 560.00, 'Third', '201-R', 4, 6),
(6, 2100.00, 'Second', '13-T', 1, 9),
(7, 5500.00, 'First', '98-O', 2, 7)

--Section 2: DML - 02. Update Flights
UPDATE Flights
SET AirlineID = 1
WHERE Status = 'Arrived'

--TRUNCATE TABLE Flights

--Section 2: DML - 03. Update Tickets
UPDATE Tickets
SET Price *= 1.5
WHERE FlightID IN (
	SELECT FlightID
	FROM Flights
	WHERE AirlineID = (
		SELECT TOP 1 AirlineID
		FROM Airlines
		ORDER BY Rating DESC
	)
)

--Section 2: DML - 04. Table Creation
CREATE TABLE CustomerReviews (
	ReviewID int PRIMARY KEY NOT NULL,
	ReviewContent varchar(255) NOT NULL,
	ReviewGrade tinyint,
	AirlineID int,
	CustomerID int,
	CHECK(ReviewGrade BETWEEN 0 AND 10),
	CONSTRAINT FK_AirlineID_Reviews
	FOREIGN KEY (AirlineID) REFERENCES Airlines(AirlineID),
	CONSTRAINT FK_CustomerID_Reviews
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerBankAccounts (
	AccountID int PRIMARY KEY NOT NULL,
	AccountNumber char(10) UNIQUE NOT NULL,
	Balance decimal(10, 2) NOT NULL,
	CustomerID int FOREIGN KEY REFERENCES Customers(CustomerID)
)

--Section 2: DML - 05. Fillin New Tables
INSERT INTO CustomerReviews
VALUES
	(1, 'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
	(2, 'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
	(3, 'Meh...', 5, 4, 3),
	(4, 'Well Ive seen better, but Ive certainly seen a lot worse...', 7, 3, 5)

INSERT INTO CustomerBankAccounts
VALUES
	(1, '123456790', 2569.23, 1),
	(2, '18ABC23672', 14004568.23, 2),
	(3, 'F0RG0100N3', 19345.20, 5)

--Section 3: Querying - 01. Extract All Tickets
SELECT TicketID, Price, Class, Seat
FROM Tickets
ORDER BY TicketID

--Section 3: Querying - 02. Extract All Customers
SELECT CustomerID, FirstName + ' ' + LastName AS FullName, Gender
FROM Customers
ORDER BY FullName, CustomerID

--Section 3: Querying - 03. Extract Delayed Flights
SELECT FlightID, DepartureTime, ArrivalTime
FROM Flights
WHERE Status = 'Delayed'
ORDER BY FlightID

--Section 3: Querying - 04. Top 5 Airlines
SELECT DISTINCT TOP 5 a.AirlineID, a.AirlineName, a.Nationality, a.Rating
FROM Airlines AS a
JOIN Flights AS f ON a.AirlineID = f.AirlineID
ORDER BY a.Rating DESC, a.AirlineID

--Section 3: Querying - 05. All Tickets Below 5000
SELECT t.TicketID, a.AirportName AS Destination, CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName
FROM Tickets AS t
JOIN Flights AS f ON f.FlightID = t.FlightID
JOIN Airports AS a ON a.AirportID = f.DestinationAirportID
JOIN Customers AS c ON c.CustomerID = t.CustomerID
WHERE t.Price < 5000 AND t.Class = 'First'
ORDER BY t.TicketID

--Section 3: Querying - 06. Customers From Home
SELECT c.CustomerID, CONCAT(c.FirstName, ' ', c.LastName) AS FullName, t.TownName AS HomeTown
FROM Customers AS c
JOIN Towns AS t ON t.TownID = c.HomeTownID
JOIN Tickets AS ti ON ti.CustomerID = c.CustomerID
JOIN Flights AS f ON f.FlightID = ti.FlightID
JOIN Airports AS a ON a.AirportID = f.OriginAirportID
WHERE a.TownID = t.TownID AND f.Status = 'Departing'
ORDER BY c.CustomerID

--Section 3: Querying - 07. Customers who will fly
SELECT DISTINCT
	c.CustomerID,
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	DATEDIFF(YEAR, c.DateOfBirth, '2016/01/01') AS Age
FROM Tickets AS t
JOIN Customers AS c ON c.CustomerID = t.CustomerID
JOIN Flights AS f ON f.FlightID = t.FlightID AND f.Status = 'Departing'
ORDER BY Age, c.CustomerID

--Section 3: Querying - 08. Top 3 Customers Delayed
SELECT TOP 3
	c.CustomerID,
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	t.Price,
	a.AirportName AS Destination
FROM Customers AS c
JOIN Tickets AS t ON t.CustomerID = c.CustomerID
JOIN Flights AS f ON f.FlightID = t.FlightID AND f.Status = 'Delayed'
JOIN Airports AS a ON a.AirportID = f.DestinationAirportID
ORDER BY t.Price DESC, c.CustomerID

--Section 3: Querying - 09. Last 5 Departing Flights
SELECT
	f.FlightID,
	f.DepartureTime,
	f.ArrivalTime,
	ao.AirportName AS Origin,
	ad.AirportName AS Destination
FROM (
	SELECT TOP 5 *
	FROM Flights
	WHERE Status = 'Departing'
	ORDER BY DepartureTime DESC
) AS f
JOIN Airports AS ao ON ao.AirportID = f.OriginAirportID
JOIN Airports AS ad ON ad.AirportID = f.DestinationAirportID
ORDER BY f.DepartureTime ASC

--Section 3: Querying - 10. Customers Below 21
SELECT DISTINCT
	c.CustomerID,
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	DATEDIFF(YEAR, c.DateOfBirth, '2016/01/01') AS Age
FROM Customers AS c
JOIN Tickets AS t ON t.CustomerID = c.CustomerID
JOIN Flights AS f ON f.FlightID = t.FlightID AND f.Status = 'Arrived'
WHERE DATEDIFF(YEAR, c.DateOfBirth, '2016/01/01') < 21
ORDER BY Age DESC, c.CustomerID

--Section 3: Querying - 11. AIrports and Passengers
SELECT a.AirportID, a.AirportName, COUNT(*) AS Passengers
FROM Airports AS a
JOIN Flights AS f ON f.OriginAirportID = a.AirportID AND f.Status = 'Departing'
JOIN Tickets AS t ON t.FlightID = f.FlightID
GROUP BY a.AirportID, a.AirportName

--Section 4: Programmibility - 01. Submit Review
CREATE PROC usp_SubmitReview
	@CustomerID int,
	@ReviewContent varchar(255),
	@ReviewGrade tinyint,
	@AirlineName varchar(30)

AS BEGIN TRAN

DECLARE @ReviewID int = ISNULL(
	(SELECT MAX(ReviewID) FROM CustomerReviews), 0
) + 1

DECLARE @AirlineID int = (
	SELECT AirlineID
	FROM Airlines
	WHERE AirlineName = @AirlineName
)

INSERT INTO CustomerReviews
VALUES (@ReviewID, @ReviewContent, @ReviewGrade, @AirlineID, @CustomerID)

IF NOT EXISTS (
	SELECT *
	FROM Airlines
	WHERE AirlineName = @AirlineName
) BEGIN
	ROLLBACK;
	THROW 50001, 'Airline does not exist.', 1;
	RETURN;
END

COMMIT

DROP PROC usp_SubmitReview

--Section 4: Programmibility - 02. Ticket Purchase
CREATE PROC usp_PurchaseTicket
	@CustomerID int,
	@FlightID int,
	@TicketPrice decimal(8, 2),
	@Class varchar(6),
	@Seat varchar(5)

AS BEGIN TRAN

UPDATE CustomerBankAccounts
SET Balance -= @TicketPrice
WHERE CustomerID = @CustomerID

DECLARE @Balance decimal(10, 2) = (
	SELECT Balance
	FROM CustomerBankAccounts
	WHERE CustomerID = @CustomerID
)

--IF @@ROWCOUNT <> 1 / @Balance IS NULL

IF @Balance < 0 OR @Balance IS NULL
BEGIN
	ROLLBACK;
	--RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1)
	THROW 50001, 'Insufficient bank account balance for ticket purchase.', 1;
	RETURN
END

DECLARE @TicketID int = ISNULL((SELECT MAX(TicketID) FROM Tickets), 0)  + 1

INSERT INTO Tickets
VALUES (@TicketID, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

COMMIT

--BONUS Section 5: Update Trigger
CREATE TABLE ArrivedFlights (
	FlightID int PRIMARY KEY NOT NULL,
	ArrivalTime datetime NOT NULL,
	Origin varchar(50) NOT NULL,
	Destination varchar(50) NOT NULL,
	Passengers int
)

CREATE TRIGGER tr_UpdateFlights ON Flights FOR UPDATE
AS
INSERT INTO ArrivedFlights
SELECT
	FlightID,
	ArrivalTime,
	ao.AirportName AS Origin,
	ad.AirportName AS Destination,
	(SELECT COUNT(*) FROM Tickets WHERE FlightID = i.FlightID) AS Passengers
FROM inserted AS i
JOIN Airports AS ao ON ao.AirportID = i.OriginAirportID
JOIN Airports AS ad ON ad.AirportID = i.DestinationAirportID
WHERE Status = 'Arrived'

