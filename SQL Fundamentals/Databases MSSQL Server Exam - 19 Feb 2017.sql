-- 01. DDL
CREATE TABLE Products(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(25) UNIQUE,
	Description nvarchar(250),
	Recipe nvarchar(max),
	Price decimal(8, 2) CHECK(Price > 0),
)

CREATE TABLE Countries(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(50) UNIQUE
)

CREATE TABLE Distributors(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(25) UNIQUE,
	CountryId int,
	AddressText nvarchar(30),
	Summary nvarchar(200),
	CONSTRAINT FK_Distributors_Countries
	FOREIGN KEY (CountryId)
	REFERENCES Countries(Id)
)

CREATE TABLE Ingredients(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(30),
	OriginCountryId int,
	Description nvarchar(200),
	DistributorId int,
	CONSTRAINT FK_Ingredients_Countries
	FOREIGN KEY (OriginCountryId)
	REFERENCES Countries(Id),
	CONSTRAINT FK_Ingredients_Distributors
	FOREIGN KEY (DistributorId)
	REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients(
	ProductId int,
	IngredientId int,
	CONSTRAINT PK_ProductsIngredients
	PRIMARY KEY (ProductId, IngredientId),
	CONSTRAINT FK_ProductsIngredients_Products
	FOREIGN KEY (ProductId)
	REFERENCES Products(Id),
	CONSTRAINT FK_ProductsIngredients_Ingredients
	FOREIGN KEY (IngredientId)
	REFERENCES Ingredients(Id)
)

CREATE TABLE Customers(
	Id int PRIMARY KEY IDENTITY,
	FirstName nvarchar(25),
	LastName nvarchar(25),
	Age int,
	Gender char(1) CHECK(Gender IN ('M', 'F')),
	PhoneNumber char(10) CHECK(LEN(PhoneNumber) = 10),
	CountryId int,
	CONSTRAINT FK_Products_Countries
	FOREIGN KEY (CountryId)
	REFERENCES Countries(Id)
)

CREATE TABLE Feedbacks(
	Id int PRIMARY KEY IDENTITY,
	ProductId int,
	CustomerId int,
	Rate decimal(4, 2) CHECK(Rate BETWEEN 0 AND 10),
	Description nvarchar(255),
	CONSTRAINT FK_Feedbacks_Products
	FOREIGN KEY (ProductId)
	REFERENCES Products(Id),
	CONSTRAINT FK_Feedbacks_Customers
	FOREIGN KEY (CustomerId)
	REFERENCES Customers(Id)
)

--02. Insert
INSERT INTO Distributors
VALUES
	('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
	('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
	('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
	('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
	('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers
VALUES
	('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
	('Kendra', 'Loud',  22, 'F', '0063631526', 11),
	('Lourdes', 'Bauswell',  50, 'M', '0139037043', 8),
	('Hannah', 'Edmison',  18, 'F', '0043343686', 1),
	('Tom', 'Loeza',  31, 'M', '0144876096', 23),
	('Queenie', 'Kramarczyk',  30, 'F', '0064215793', 29),
	('Hiu', 'Portaro',  25, 'M', '0068277755', 16),
	('Josefa', 'Opitz',  43, 'F', '0197887645', 17)

--03. Update
UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--04. Delete
DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--05. Products By Price
SELECT Name, Price, Description
FROM Products
ORDER BY Price DESC, Name ASC

--06. Ingredients
SELECT Name, Description, OriginCountryId
FROM Ingredients
WHERE OriginCountryId IN (1, 10, 20)
ORDER BY Id

--07. Ingredients from Bulgaria and Greece
SELECT TOP 15 i.Name, i.Description, c.Name
FROM Ingredients AS i
JOIN Countries AS c ON c.Id = i.OriginCountryId
WHERE c.Name IN ('Bulgaria', 'Greece')
ORDER BY i.Name, c.Name

--08. Best Rated Products
SELECT TOP 10 p.Name, p.Description, f.AverageRate, f.FeedbacksAmount
FROM Products AS p
JOIN (
	SELECT ProductId, AVG(Rate) AS AverageRate,  COUNT(*) AS FeedbacksAmount
	FROM Feedbacks
	GROUP BY ProductId
) AS f ON f.ProductId = p.Id
ORDER BY f.AverageRate DESC, f.FeedbacksAmount DESC

--09. Negative Feedback
SELECT f.ProductId, f.Rate, f.Description, f.CustomerId, c.Age, c.Gender
FROM Feedbacks AS f
JOIN Customers AS c ON c.Id = f.CustomerId
WHERE f.Rate < 5.0
ORDER BY f.ProductId DESC, f.Rate ASC

--10. Customers without Feedback
/*
SELECT
	c.FirstName + ' ' + c.LastName AS CustomerName,
	c.PhoneNumber,
	c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f ON f.CustomerId = c.Id
WHERE f.Id IS NULL
ORDER BY c.Id
*/

SELECT
	CONCAT(FirstName, ' ', LastName) AS CustomerName,
	PhoneNumber,
	Gender
FROM Customers
WHERE Id NOT IN (SELECT CustomerId FROM Feedbacks)
ORDER BY Id ASC

--11. Honorable Mentions
SELECT
	f.ProductId,
	c.FirstName + ' ' + c.LastName AS CustomerName,
	f.Description AS FeedbackDescription
FROM Feedbacks AS f
JOIN Customers AS c ON c.Id = f.CustomerId
WHERE f.CustomerId IN (
	SELECT CustomerId
	FROM Feedbacks
	GROUP BY CustomerId
	HAVING COUNT(*) >= 3
)
ORDER BY f.ProductId, CustomerName, f.Id

--12. Customers by Criteria
SELECT cu.FirstName, cu.Age, cu.PhoneNumber
FROM Customers AS cu
JOIN Countries AS co ON co.Id = cu.CountryId
WHERE (
	Age >= 21
	AND (
		cu.FirstName LIKE 'an%'
		OR cu.FirstName LIKE '%an%'
		OR cu.FirstName LIKE '%an'
	)
) OR (
	RIGHT(cu.PhoneNumber, 2) = '38'
	AND co.Name <> 'Greece'
)
ORDER BY cu.FirstName, cu.Age DESC

--13. Middle Range Distributors
SELECT
	d.Name AS DistributorName,
	i.Name AS IngredientName,
	p.Name AS ProductName,
	f.Average AS AverageRate
FROM (
	SELECT ProductId, AVG(Rate) AS Average
	FROM Feedbacks
	GROUP BY ProductId
	HAVING AVG(Rate) BETWEEN 5 AND 8
) AS f 
JOIN Products AS p ON p.Id = f.ProductId
JOIN ProductsIngredients AS pin ON pin.ProductId = p.Id
JOIN Ingredients AS i ON i.Id = pin.IngredientId
JOIN Distributors AS d ON d.Id = i.DistributorId 
ORDER BY DistributorName, IngredientName, ProductName

--14. The Most Positive Country
SELECT TOP (1) WITH TIES
	co.Name AS CountryName,
	AVG(f.Rate) AS FeedbackRate
FROM Feedbacks AS f
JOIN Customers AS c ON c.Id = f.CustomerId
JOIN Countries AS co ON co.Id = c.CountryId
GROUP BY co.Name
ORDER BY FeedbackRate DESC

--15. Country Representative
SELECT xx.CountryName, xx.DisributorName
FROM (
	SELECT
		c.Name AS CountryName,
		d.Name AS DisributorName,
		i.Num,
		RANK() OVER (PARTITION BY c.Name ORDER BY i.Num DESC) AS HAHA
	FROM Countries AS c
	JOIN Distributors AS d ON d.CountryId = c.Id
	JOIN (
		SELECT DistributorId, COUNT(*) AS Num
		FROM Ingredients
		GROUP BY DistributorId
	) AS i ON i.DistributorId = d.Id
) AS xx
WHERE xx.HAHA = 1
ORDER BY xx.CountryName, xx.DisributorName

--16. Customers With Countries
CREATE VIEW v_UserWithCountries
AS
SELECT
	cu.FirstName + ' ' + cu.LastName AS CustomerName,
	cu.Age,
	cu.Gender,
	co.Name AS CountryName
FROM Customers AS cu
JOIN Countries AS co ON co.Id = cu.CountryId

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

--17. Feedback by Product Name
CREATE FUNCTION udf_GetRating(@Name nvarchar(25))
RETURNS char(10)
AS BEGIN

DECLARE @Result char(10) = 'No rating'

DECLARE @Rating float = (
	SELECT AVG(Rate)
	FROM Feedbacks
	WHERE ProductId = (
		SELECT Id
		FROM Products
		WHERE Name = @Name
	)
)

IF @Rating < 5 BEGIN
	SET @Result = 'Bad'
END ELSE IF @Rating BETWEEN 5 AND 8 BEGIN
	SET @Result = 'Average'
END ELSE IF @Rating > 8 BEGIN
	SET @Result = 'Good'
END

RETURN @Result

END



SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
  FROM Products
 ORDER BY Id

--18. Send Feedback
CREATE PROC usp_SendFeedback
	@CustomerId int,
	@ProductId int,
	@Rate decimal(4, 2),
	@Description nvarchar(255)
AS BEGIN TRAN

DECLARE @N int = (
	SELECT COUNT(*)
	FROM Feedbacks
	WHERE CustomerId = @CustomerId
)

IF @N >= 3 BEGIN
	ROLLBACK;
	RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)
	RETURN
END ELSE BEGIN

	INSERT INTO Feedbacks
	VALUES(@ProductId, @CustomerId, @Rate, @Description)
	COMMIT
END

BEGIN TRAN

EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience';
SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = 1 AND ProductId = 5;

ROLLBACK

--19. Delete Products
CREATE TRIGGER tr_HAHAHAHA ON Products INSTEAD OF DELETE
AS

DELETE FROM ProductsIngredients
WHERE ProductId IN (SELECT Id FROM deleted)

DELETE FROM Feedbacks
WHERE ProductId IN (SELECT Id FROM deleted)

DELETE FROM Products
WHERE Id IN (SELECT Id FROM deleted)


BEGIN TRAN

DELETE FROM Products WHERE Id = 7

ROLLBACK

--20. Products by One Distributor