--Section 1: DDL 1. Database Design
CREATE TABLE Chats (
	Id int IDENTITY,
	Title varchar(32),
	StartDate date,
	IsActive bit,
	CONSTRAINT PK_Chats
	PRIMARY KEY (Id)
)

CREATE TABLE Locations (
	Id int IDENTITY,
	Latitude float,
	Longitude float,
	CONSTRAINT PK_Locations
	PRIMARY KEY (Id)
)

CREATE TABLE Credentials (
	Id int IDENTITY,
	Email varchar(30),
	Password varchar(20),
	CONSTRAINT PK_Credentials
	PRIMARY KEY (Id)
)

CREATE TABLE Users (
	Id int IDENTITY,
	Nickname varchar(25),
	Gender char,
	Age int,
	LocationId int,
	CredentialId int UNIQUE,
	CONSTRAINT PK_Users
	PRIMARY KEY (Id),
	CONSTRAINT FK_Users_Locations
	FOREIGN KEY (LocationId)
	REFERENCES Locations(Id),
	CONSTRAINT FK_Users_Credentials
	FOREIGN KEY (CredentialId)
	REFERENCES Credentials(Id)
)

CREATE TABLE Messages (
	Id int IDENTITY,
	Content varchar(200),
	ChatId int,
	UserId int,
	SentOn date,
	CONSTRAINT PK_Messages
	PRIMARY KEY (Id),
	CONSTRAINT FK_Messages_Chats
	FOREIGN KEY (ChatId)
	REFERENCES Chats(Id),
	CONSTRAINT FK_Messages_Users
	FOREIGN KEY (UserId)
	REFERENCES Users(Id)
)

CREATE TABLE UsersChats (
	UserId int,
	ChatId int,

	CONSTRAINT PK_UserId_ChatId
	PRIMARY KEY (ChatId, UserId),

	CONSTRAINT FK_UsersChats_Users
	FOREIGN KEY (UserId)
	REFERENCES Users(Id),
	CONSTRAINT FK_UsersChats_Chats
	FOREIGN KEY (ChatId)
	REFERENCES Chats(Id)
)

--Section 2. DML 2. Insert
INSERT INTO Messages (Content, SentOn, ChatId, UserId)
SELECT
	CONCAT(u.Age, '-', u.Gender, '-', l.Latitude, '-', l.Longitude),
	CONVERT(date, GETDATE()),
	CASE
		WHEN u.Gender = 'F' THEN CEILING(SQRT(u.Age * 2))
		WHEN u.Gender = 'M' THEN CEILING(POWER(u.Age / 18, 3))
	END,
	u.Id
FROM Users AS u
JOIN Locations AS l ON l.Id = u.LocationId
WHERE u.Id BETWEEN 10 AND 20

--Section 2. DML 3. Update
UPDATE c
SET c.StartDate = m.FirstMessDate
FROM Chats AS c
JOIN (
	SELECT c.Id, MIN(m.SentOn) AS FirstMessDate
	FROM Chats AS c
	JOIN Messages AS m ON m.ChatId = c.Id
	GROUP BY c.Id, c.StartDate
	HAVING MIN(m.SentOn) < c.StartDate
) AS m ON m.Id = c.Id

--Section 2. DML 4. Delete
DELETE FROM Locations
WHERE Id IN (
	SELECT l.Id
	FROM Users AS u
	RIGHT JOIN Locations AS l ON l.Id = u.LocationId
	WHERE u.LocationId IS NULL
)

--Section 3: Querying - 5. Age Range
SELECT Nickname, Gender, Age
FROM Users
WHERE Age BETWEEN 22 AND 37

--Section 3: Querying - 6. Messages
SELECT Content, SentOn
FROM Messages
WHERE SentOn > '2014/05/12' AND (
	Content LIKE 'just%' OR
	Content LIKE '%just%' OR
	Content LIKE '%just'
)
ORDER BY Id DESC

--Section 3: Querying - 7. Chats
SELECT Title, IsActive
FROM Chats
WHERE
	IsActive = 0 AND
	LEN(Title) < 5 OR
	--(CHARINDEX('t', Title, 3) = 3 AND CHARINDEX('l', Title, 4) = 4)
	Title LIKE '__tl%'
ORDER BY Title DESC

--Section 3: Querying - 8. Chat Messages
SELECT c.Id, c.Title, m.Id
FROM Messages AS m
JOIN Chats AS c ON c.Id = m.ChatId
	AND m.SentOn < '2012.03.26'
	AND c.Title LIKE '%x'
ORDER BY c.Id, m.Id

--Section 3: Querying - 9. Message Count
SELECT TOP 5 x.ChatId AS Id, COUNT(x.MessId) AS TotalMessages
FROM (
	SELECT c.Id AS ChatId, m.Id AS MessId
	FROM Chats AS c
	LEFT JOIN Messages AS m ON m.ChatId = c.Id
	WHERE m.Id IS NOT NULL AND m.Id < 90
) AS x
GROUP BY x.ChatId
ORDER BY TotalMessages DESC, Id ASC

--Section 3: Querying - 10. Credentials
SELECT u.Nickname, cr.Email, cr.Password
FROM Users AS u
JOIN Credentials AS cr ON cr.Id = u.CredentialId
WHERE RIGHT(RTRIM(cr.Email), 5) = 'co.uk' --PEDERASI
ORDER BY cr.Email

--Section 3: Querying - 11. Locations
SELECT Id, Nickname, Age
FROM Users
WHERE LocationId IS NULL

--Section 3: Querying - 12. Left Users --PEDERASIIII AAAAAAAAAAAAAA
SELECT m.Id, m.ChatId, m.UserId
FROM Messages AS m
JOIN UsersChats AS uc ON uc.ChatId = m.ChatId
WHERE m.ChatId = 17 AND uc.UserId <> m.UserId
ORDER BY m.Id DESC

--Section 3: Querying - 13. Users in Bulgaria
SELECT u.Nickname, c.Title, l.Latitude, l.Longitude
FROM Locations AS l
JOIN Users AS u ON u.LocationId = l.Id
JOIN UsersChats AS uc ON uc.UserId = u.Id
JOIN Chats AS c ON c.Id = uc.ChatId
WHERE
	(l.Latitude BETWEEN 41.14 AND 44.13)
	AND (l.Longitude BETWEEN 22.21 AND 28.36)
--WHERE (l.Latitude BETWEEN 41.13999 AND 44.12999) AND (l.Longitude BETWEEN 22.209999 AND 28.35999)
ORDER BY c.Title

--Section 3: Querying - 14. Last Chat
SELECT TOP 1 c.Title, m.Content
FROM Chats AS c
LEFT JOIN Messages AS m ON m.ChatId = c.Id
ORDER BY c.StartDate DESC

--Section 4: Programmability - 15. Radians
CREATE FUNCTION udf_GetRadians(@deg float)
RETURNS float
AS BEGIN

DECLARE @rad float = @deg * PI() / 180
RETURN @rad

END

--SELECT dbo.udf_GetRadians(22.12) AS Radians

--Section 4: Programmability - 16. Change Password
CREATE PROC udp_ChangePassword
	@email varchar(30) = NULL,
	@pass varchar(20)
AS
/*
BEGIN TRAN

IF @email IS NULL BEGIN
	ROLLBACK;
	RAISERROR('The email does''t exist', 16, 1);
	RETURN;
END ELSE BEGIN

UPDATE Credentials
SET Password = @pass
WHERE Email = @email

COMMIT

END
*/

BEGIN
	BEGIN TRANSACTION

	UPDATE Credentials
	SET Password = @pass
	WHERE Email = @email

	IF(@@ROWCOUNT <> 1)
	BEGIN
		ROLLBACK;
		RAISERROR('The email does''t exist!', 16, 1)
	END
	ELSE
	BEGIN
		COMMIT
	END
END

EXEC udp_ChangePassword 'abarnes0@sogou.com', 'new_pass'

--Section 4: Programmability - 17. Send Message
CREATE PROC udp_SendMessage
	@UserId int,
	@ChatId int,
	@Content varchar(200)
AS BEGIN TRAN

IF NOT EXISTS(
	SELECT *
	FROM UsersChats
	WHERE UserId = @UserId AND ChatId = @ChatId
) BEGIN

	ROLLBACK;
	RAISERROR('There is no chat with that user!', 16, 1)
	RETURN

END

INSERT INTO Messages
VALUES (@Content, CONVERT(date, GETDATE()), @ChatId, @UserId)
COMMIT

/*
BEGIN TRAN

EXEC dbo.udp_SendMessage 19, 100, 'Awesome'
SELECT * FROM Messages

ROLLBACK
*/

--Section 4: Programmability - 18. Log Messages
CREATE TABLE MessageLogs (
	Id int PRIMARY KEY,
	Content	varchar(200),
	ChatId int,
	UserId int,
	SentOn date
)

CREATE TRIGGER tr_MessageLogs ON Messages AFTER DELETE
AS INSERT INTO MessageLogs
SELECT * FROM deleted

ALTER TABLE MessageLogs
ALTER COLUMN Id int

/*
DROP TABLE MessageLogs

BEGIN TRAN

DELETE FROM Messages
WHERE Id = 3

SELECT * FROM MessageLogs

ROLLBACK
*/

--Section 5: Bonus - 19. Delete users
CREATE TRIGGER tr_User ON Users INSTEAD OF DELETE
AS

UPDATE Users
SET CredentialId = NULL
WHERE Id IN (SELECT Id FROM deleted)

DELETE Credentials
WHERE Id IN (SELECT CredentialId FROM deleted)

DELETE UsersChats
WHERE UserId IN (SELECT Id FROM deleted)

UPDATE Messages
SET UserId = NULL
WHERE UserId IN (SELECT Id FROM deleted)

DELETE Users
WHERE Id IN (SELECT Id FROM deleted)