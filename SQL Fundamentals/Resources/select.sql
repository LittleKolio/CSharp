--DISTINCT
SELECT DISTINCT Salary FROM Employees

SELECT DISTINCT TOP 5 a.AirlineID, a.AirlineName, a.Nationality, a.Rating
FROM Airlines AS a
JOIN Flights AS f ON a.AirlineID = f.AirlineID
ORDER BY a.Rating DESC, a.AirlineID

--BETWEEN
WHERE Salary BETWEEN 20000 AND 30000

--IN()
WHERE Salary IN(25000, 14000, 12500, 23600)

--TOP()
--TOP WITH TIES
SELECT TOP(5) FirstName, LastName FROM Employees

--ISNULL(@something, if is it null)
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS 'Full Name'
FROM Employees

--CASE WHEN ... THEN ... END AS ...
SELECT
	CountryName,
	CountryCode,
	CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		WHEN ... THEN ...
		WHEN ... THEN ...
		ELSE 'Not Euro'
	END AS 'Currency'
FROM Countries
ORDER BY CountryName;

-- DENSE_RANK() OVER ([partition_by_clause] order_by_clause)  
-- NTILE (integer_expression) OVER ([partition_by_clause] order_by_clause)
-- RANK () OVER ([partition_by_clause] order_by_clause)
-- ROW_NUMBER and RANK are similar.
-- ROW_NUMBER numbers all rows sequentially (for example 1, 2, 3, 4, 5).
-- RANK provides the same numeric value for ties (for example 1, 2, 2, 4, 5).


CREATE TRIGGER columnName
ON tableName
INSTEAD OF INSERT
AS
BEGIN

END
GO


CREATE TRIGGER columnName
ON tableName
AFTER INSERT
AS
BEGIN

IF EXISTS() BEGIN

END

END
GO