--01. Find Names of All Employees by First Name
SELECT FirstName, LastName
FROM Employees
WHERE LEFT(FirstName, 2) = 'SA';

--02. Find Names of All Employees by Last Name
--Alternative to CHARINDEX() is using the LIKE predicate.
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%';

--03. Find First Names of All Employess
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
AND (YEAR(HireDate) >= 1995 AND YEAR(HireDate) <= 2005);

--04. Find All Employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE NOT JobTitle LIKE '%engineer%';

--05. Find Towns with Name Length
SELECT Name
FROM Towns
WHERE LEN(Name) = 5 OR LEN(Name) = 6
ORDER BY Name;

--06. Find Towns Starting With
SELECT TownID, Name
FROM Towns
WHERE Name LIKE '[MKBE]%'
ORDER BY Name;

--07. Find Towns Not Starting With
SELECT TownID, Name
FROM Towns
WHERE Name LIKE '[^RBD]%'
ORDER BY Name;

--08. Create View Employees Hired After
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE YEAR(HireDate) > 2000;
--SELECT * FROM V_EmployeesHiredAfter2000;

--09. Length of Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5;

--10. Countries Holding 'A'
SELECT CountryName, IsoCode
FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'A', '')) >= 3
ORDER BY IsoCode;
--WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'A' COLLATE SQL_Latin1_General_CP1_CI_AS, '')) > 3

--11. Mix of Peak and River Names
SELECT PeakName, RiverName,
LOWER(LEFT(PeakName, LEN(PeakName) - 1) + RiverName) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix;

--12. Games From 2011 and 2012 Year
SELECT TOP 50 Name, CONVERT(char(10), Start, 126)
FROM Games
WHERE YEAR(Start) IN (2011, 2012)
ORDER BY Start;

--13. User Email Providers
SELECT Username, RIGHT(Email, LEN(Email) - CHARINDEX('@', Email, 1)) AS 'Email Provider'
FROM Users
ORDER BY 'Email Provider', Username;

--14. Get Users with IPAddress Like Pattern
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username;

--15. Show All Games with Duration and Part of the Day
SELECT
	Name,
	CASE
		WHEN CONVERT(varchar(2), Start, 108) >= 0 AND CONVERT(varchar(2), Start, 108) < 12 THEN 'Morning'
		WHEN CONVERT(varchar(2), Start, 108) >= 12 AND CONVERT(varchar(2), Start, 108) < 18 THEN 'Afternoon'
		WHEN CONVERT(varchar(2), Start, 108) >= 18 AND CONVERT(varchar(2), Start, 108) < 24 THEN 'Evening'
	END AS 'Part of the Day',
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END AS 'Duration'
FROM Games
	ORDER BY Name, 'Duration', 'Part of the Day';

--16. Orders Table
SELECT
	ProductName,
	OrderDate,
	DATEADD(DAY, 3, OrderDate) AS 'Pay Due',
	DATEADD(MONTH, 1, OrderDate) AS 'Deliver Due'
FROM Orders