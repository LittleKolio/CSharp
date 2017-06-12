/*
--DFSGDFSGDSFGSD
CREATE FUNCTION ufn_Neznam(@something int) RETURNS nvarchar(10)
AS
BEGIN

DECLARE @haha varchar(10)

IF (@something < 30000) BEGIN
	SET @haha = 'Low'
END

ELSE IF (@something >= 30000 AND @something < 50000) BEGIN
	SET @haha = 'Average'
END

ELSE BEGIN
	SET @haha = 'High'
END

RETURN @haha

END

--TCVSADCTESRACT
DECLARE @something int = 10;
WHILE (@something > 0) BEGIN
	PRINT 'Current Value ' + CAST(@something AS varchar)
	SET @something -= 1
END


--DSFGDFGDFG
CREATE FUNCTION ufn_Neznam2 (@Age int) RETURNS nvarchar(10)
AS BEGIN

DECLARE @lower int;
DECLARE @uper int;

RETURN CONCAT('[', @lower, '-', @uper, ']')

END

*/


/*
IF EXISTS(
	SELECT * FROM TableName ...
) BEGIN

END
*/

--01. Employees with Salary Above 35000
CREATE PROC dbo.usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName AS 'First Name', LastName AS 'Last Name'
FROM Employees
WHERE Salary > 35000

--EXEC usp_GetEmployeesSalaryAbove35000
--DROP PROC usp_GetEmployeesSalaryAbove35000


--02. Employees with Salary Above Number
CREATE PROC dbo.usp_GetEmployeesSalaryAboveNumber(@param money)
AS
SELECT FirstName AS 'First Name', LastName AS 'Last Name'
FROM Employees
WHERE Salary >= @param

--EXEC usp_GetEmployeesSalaryAboveNumber 20000
--DROP PROC usp_GetEmployeesSalaryAboveNumber

--03. Town Names Starting With
CREATE PROC dbo.usp_GetTownsStartingWith(@param varchar(max))
AS
SELECT Name
FROM Towns
WHERE CHARINDEX(@param, Name) = 1

--EXEC usp_GetTownsStartingWith 'b'
--DROP PROC usp_GetTownsStartingWith

--04. Employees from Town
CREATE PROC dbo.usp_GetEmployeesFromTown(@param varchar(max))
AS
SELECT e.FirstName AS 'First Name', e.LastName AS 'Last Name'
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE t.Name = @param

--EXEC usp_GetEmployeesFromTown 'Sofia'
--DROP PROC usp_GetEmployeesFromTown

--05. Salary Level Function
CREATE FUNCTION dbo.ufn_GetSalaryLevel (@salary money)
RETURNS varchar(10)
AS BEGIN

DECLARE @result varchar(10);

IF @salary < 30000 BEGIN
	SET @result = 'Low'
END
ELSE IF @salary >= 30000 AND @salary <= 50000 BEGIN
	SET @result = 'Average'
END
ELSE IF @salary > 50000 BEGIN
	SET @result = 'High'
END

RETURN @result

END

--SELECT Salary, dbo.ufn_GetSalaryLevel (Salary) AS 'Salary Level'
--FROM Employees

--06. Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel(@param varchar(max))
AS BEGIN

SELECT FirstName AS 'First Name', LastName AS 'Last Name'
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @param

END

--EXEC dbo.usp_EmployeesBySalaryLevel 'Low'
--DROP PROC usp_EmployeesBySalaryLevel

--07. Define Function
CREATE FUNCTION dbo.ufn_IsWordComprised(@setOfLetters varchar(max), @word varchar(max)) 
RETURNS bit
AS BEGIN

DECLARE @result bit = 1

DECLARE @char char
DECLARE @length int = 1

WHILE @length <= LEN(@word) BEGIN

	SET @char = SUBSTRING(@word, @length, 1)
	IF CHARINDEX(@char, @setOfLetters) = 0 BEGIN
		SET @result = 0
	END
	SET @length += 1

END

RETURN @result

END

--SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')

--08. Delete Employees and Departments
CREATE VIEW view_Employees
AS
	SELECT e.EmployeeID 
	FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Production ', 'Production Control');
GO

ALTER TABLE Departments
ALTER COLUMN ManagerID int NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT EmployeeID FROM view_Employees)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM view_Employees)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM view_Employees)

DELETE FROM Employees
WHERE EmployeeID IN (SELECT EmployeeID FROM view_Employees)

DELETE FROM Departments
WHERE Name IN ('Production ', 'Production Control')

--09. Employees with Three Projects
CREATE PROC usp_AssignProject(@emloyeeId int , @projectID int)
AS BEGIN
BEGIN TRAN

INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
VALUES (@emloyeeId, @projectID)

DECLARE @c int = (
	SELECT COUNT(*)
	FROM EmployeesProjects
	WHERE EmployeeID = @emloyeeId
)

IF @c > 3 BEGIN
	RAISERROR('The employee has too many projects!', 16, 1)
	ROLLBACK
END
ELSE COMMIT

END

--10. Find Full Name
CREATE PROC usp_GetHoldersFullName
AS BEGIN
	SELECT FirstName + ' ' + LastName AS 'Full Name'
	FROM AccountHolders
END

--EXEC usp_GetHoldersFullName
--DROP PROC usp_GetHoldersFullName

--11. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@param money)
AS BEGIN 
SELECT FirstName, LastName
FROM AccountHolders AS c
INNER JOIN (
	SELECT AccountHolderId, SUM(Balance) AS SumBalance
	FROM Accounts
	GROUP BY AccountHolderId
	HAVING SUM(Balance) > @param
) AS f ON f.AccountHolderId = c.Id
END

--EXEC usp_GetHoldersWithBalanceHigherThan 30000
--DROP PROC usp_GetHoldersWithBalanceHigherThan

--12. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@sum money, @rate float, @years int)
RETURNS money
AS BEGIN
RETURN @sum * POWER(1 + @rate, @years)
END

--SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--13. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount(@id int, @rate float)
AS BEGIN

SELECT
	ah.Id AS 'Account Id',
	ah.FirstName AS 'First Name',
	ah.LastName AS 'Last Name',
	a.Balance AS 'Current Balance',
	dbo.ufn_CalculateFutureValue(a.Balance, @rate, 5) AS 'Balance in 5 years'
FROM AccountHolders AS ah
JOIN Accounts AS a ON a.AccountHolderId = ah.Id
WHERE a.Id = @id

END

--EXEC usp_CalculateFutureValueForAccount 1, 0.1
--DROP PROC usp_CalculateFutureValueForAccount

--14. Deposit Money Procedure
CREATE PROC usp_DepositMoney (@id int, @money money)
AS BEGIN

BEGIN TRAN
UPDATE Accounts
SET Balance += @money
WHERE Id = @id
IF @@ROWCOUNT <> 1 BEGIN
	ROLLBACK
	RAISERROR('Invalid account!', 16, 1)
	RETURN
END
COMMIT

END

--EXEC usp_DepositMoney 1, -10
--DROP PROC usp_DepositMoney

--15. Withdraw Money Procedure
CREATE PROC usp_WithdrawMoney (@id int, @money money)
AS BEGIN

BEGIN TRAN
UPDATE Accounts
SET Balance -= @money
WHERE Id = @id
IF @@ROWCOUNT <> 1 BEGIN
	ROLLBACK
	RAISERROR('Invalid account!', 16, 1)
	RETURN
END
COMMIT

END

--16. Money Transfer
CREATE PROC usp_TransferMoney(@senderId int, @receiverId int, @amount money)
AS BEGIN

BEGIN TRAN
EXEC usp_WithdrawMoney @senderId, @amount
EXEC usp_DepositMoney @receiverId, @amount

IF @amount < 0 BEGIN
	ROLLBACK
	RAISERROR('Invalid amount of money!', 16, 1)
	RETURN
END
COMMIT

END

--17. Create Table Logs
CREATE TABLE Logs (
	LogId int PRIMARY KEY IDENTITY(1, 1),
	AccountId int,
	OldSum money,
	NewSum money,
	CONSTRAINT FK_AccountId
	FOREIGN KEY (AccountId)
	REFERENCES Accounts(Id)
)

CREATE TRIGGER tr_UpdateLogs ON Accounts AFTER UPDATE
AS BEGIN

INSERT INTO Logs (AccountId, OldSum, NewSum)
SELECT i.Id, i.Balance, d.Balance
FROM inserted AS i
JOIN deleted AS d ON d.Id = i.Id

END

SELECT * FROM Accounts
WHERE Id = 1

UPDATE Accounts
SET Balance += 10
WHERE Id = 1

SELECT * FROM Logs

--18. Create Table Emails
CREATE TABLE NotificationEmails(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Recipient int,
	Subject varchar(50),
	Body varchar(100)
)

CREATE TRIGGER tr_Logs_NotificationEmails ON Logs AFTER INSERT
AS BEGIN

INSERT INTO NotificationEmails (Recipient, Subject, Body)
SELECT
	AccountId,
	CONCAT('Balance change for account: ', AccountId),
	CONCAT('On ', GETDATE(), ' your balance was changed from ', OldSum, ' to ', NewSum, '.')
FROM inserted

END

--TRUNCATE TABLE Logs

--19. *Cash in User Games Odd Rows

--20. Trigger
CREATE TRIGGER tr_InsertItem ON UserGameItems FOR INSERT
AS BEGIN
DECLARE @userLevel int = (
	SELECT ug.Level
	FROM inserted AS i
	JOIN UsersGames AS ug ON ug.Id = i.UserGameId
)
DECLARE @itemLevel int = (
	SELECT it.MinLevel
	FROM inserted AS i
	JOIN Items AS it ON it.Id = i.ItemId
)
IF @userLevel < @itemLevel BEGIN
	RAISERROR('Item level to hight.', 16, 1)
	ROLLBACK TRAN
	RETURN
END

END

UPDATE UsersGames
SET Cash += 50000
WHERE UserId IN (
	SELECT Id
	FROM Users
	WHERE Username IN (
		'baleremuda',
		'loosenoise',
		'inguinalself',
		'buildingdeltoid',
		'monoxidecos'
	) AND
	GameId = (
		SELECT Id
		FROM Games
		WHERE Name = 'Bali'
	)
)


CREATE PROC usp_WithdrawCash (@user int, @game varchar(50), @cash money)
AS BEGIN

BEGIN TRAN

UPDATE ug
SET Cash -= @cash
FROM UsersGames AS ug
JOIN Games AS g ON g.Id = ug.GameId
WHERE g.Name = @game AND ug.UserId = @user

IF @@ROWCOUNT <> 1 BEGIN
	ROLLBACK
	RAISERROR('Invalid ... beeee de da znam', 16, 1)
	RETURN
END
COMMIT

END

SELECT *
FROM UsersGames AS ug
JOIN Games AS g ON g.Id = ug.GameId
RIGHT JOIN (
	SELECT u.Id, SUM(i.Price) AS SumPrice
	FROM Users AS u
	CROSS JOIN Items AS i
	WHERE u.Username IN (
		'baleremuda',
		'loosenoise',
		'inguinalself',
		'buildingdeltoid',
		'monoxidecos'
	) AND (
		i.Id BETWEEN 251 AND 299 OR i.Id BETWEEN 501 AND 539
	)
	GROUP BY u.Id
) AS p ON p.Id = ug.UserId
WHERE g.Name = 'Bali'


UPDATE ug
SET Cash -= p.SumPrice
FROM UsersGames AS ug
JOIN Games AS g ON g.Id = ug.GameId
RIGHT JOIN (
	SELECT u.Id, SUM(i.Price) AS SumPrice
	FROM Users AS u
	CROSS JOIN Items AS i
	WHERE u.Username IN (
		'baleremuda',
		'loosenoise',
		'inguinalself',
		'buildingdeltoid',
		'monoxidecos'
	) AND (
		i.Id BETWEEN 251 AND 299 OR i.Id BETWEEN 501 AND 539
	)
	GROUP BY u.Id
) AS p ON p.Id = ug.UserId
WHERE g.Name = 'Bali'

--21. *Massive Shopping

--22. Number of Users for Email Provider
SELECT
	RIGHT(Email, LEN(Email) - CHARINDEX('@', Email, 1)) AS 'Email Provider',
	COUNT(*) AS 'Number Of Users'
FROM Users
GROUP BY RIGHT(Email, LEN(Email) - CHARINDEX('@', Email, 1))
ORDER BY
	COUNT(*) DESC,
	RIGHT(Email, LEN(Email) - CHARINDEX('@', Email, 1))

--23. All Users in Games
SELECT
	g.Name AS Game,
	gt.Name AS 'Game Type',
	u.Username,
	ug.Level,
	ug.Cash,
	c.Name AS Character
FROM Games AS g
JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
JOIN UsersGames AS ug ON ug.GameId = g.Id
JOIN Users AS u ON u.Id = ug.UserId
JOIN Characters AS c ON c.Id = ug.CharacterId
ORDER BY ug.Level DESC, u.Username, g.Name

--24. Users in Games with Their Items
--25. * User in Games with Their Statistics
--26. All Items with Greater than Average Statistics
--27. Display All Items about Forbidden Game Type
--28. Buy Items for User in Game
--29. Peaks and Mountains
--30. Peaks with Mountain, Country and Continent
--31. Rivers by Country
--32. Count of Countries by Currency
--33. Population and Area by Continent
--34. Monasteries by Country
--35. Monasteries by Continents and Countries


