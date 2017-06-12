
SELECT ug.Cash
FROM Users AS u
JOIN UsersGames AS ug
	ON ug.UserId = u.Id AND u.Username = 'Stamat'
JOIN Games AS g
	ON g.Id = ug.GameId AND g.Name = 'Safflower'


SELECT i.Id, x.Id
FROM Items AS i
CROSS JOIN (
	SELECT ug.Id
	FROM UsersGames AS ug
	JOIN Games AS g ON g.Id = ug.GameId AND g.Name = 'Safflower'
) AS x
WHERE i.MinLevel IN (11, 12)

SELECT SUM(Price)
FROM Items
WHERE MinLevel IN (11, 12)

SELECT i.Name
FROM Items AS i
JOIN UserGameItems AS ugi ON ugi.ItemId = i.Id
JOIN UsersGames AS ug ON ug.Id = ugi.UserGameId
JOIN Games AS g ON g.Id = ug.GameId AND g.Name = 'Safflower'
ORDER BY i.Name

/*
CREATE FUNCTION udf_Items()
RETURNS TABLE
AS RETURN (
	SELECT i.Name
	FROM Items AS i
	JOIN UserGameItems AS ugi ON ugi.ItemId = i.Id
	JOIN UsersGames AS ug ON ug.Id = ugi.UserGameId
	JOIN Games AS g ON g.Id = ug.GameId AND g.Name = 'Safflower'
)
*/

DECLARE @itemPrice money;
DECLARE @userCash money;

BEGIN TRAN tr_Shopping_11_12

SET @itemPrice = (
	SELECT SUM(Price)
	FROM Items
	WHERE MinLevel IN (11, 12)
);

SET @userCash = (
	SELECT ug.Cash
	FROM Users AS u
	JOIN UsersGames AS ug
		ON ug.UserId = u.Id AND u.Username = 'Stamat'
	JOIN Games AS g
		ON g.Id = ug.GameId AND g.Name = 'Safflower'
);

IF @itemPrice > @userCash BEGIN
	ROLLBACK TRAN tr_Shopping_11_12;
	
	SELECT i.Name AS 'Item Name'
	FROM Items AS i
	JOIN UserGameItems AS ugi ON ugi.ItemId = i.Id
	JOIN UsersGames AS ug ON ug.Id = ugi.UserGameId
	JOIN Games AS g ON g.Id = ug.GameId AND g.Name = 'Safflower'
	ORDER BY i.Name

	RETURN;

END

ELSE BEGIN

UPDATE ug
SET ug.Cash -= @itemPrice
FROM Users AS u
JOIN UsersGames AS ug
	ON ug.UserId = u.Id AND u.Username = 'Stamat'
JOIN Games AS g
	ON g.Id = ug.GameId AND g.Name = 'Safflower'

INSERT INTO UserGameItems
SELECT i.Id, x.Id
FROM Items AS i
CROSS JOIN (
	SELECT ug.Id
	FROM UsersGames AS ug
	JOIN Games AS g ON g.Id = ug.GameId AND g.Name = 'Safflower'
) AS x
WHERE i.MinLevel  IN (11, 12)

COMMIT TRAN tr_Shopping_11_12

END

BEGIN TRAN tr_Shopping_19_21

SET @itemPrice = (
	SELECT SUM(Price)
	FROM Items
	WHERE MinLevel IN (19, 20, 21)
);

SET @userCash = (
	SELECT ug.Cash
	FROM Users AS u
	JOIN UsersGames AS ug
		ON ug.UserId = u.Id AND u.Username = 'Stamat'
	JOIN Games AS g
		ON g.Id = ug.GameId AND g.Name = 'Safflower'
);

IF @itemPrice > @userCash BEGIN
	ROLLBACK TRAN tr_Shopping_19_21;
	
	SELECT i.Name AS 'Item Name'
	FROM Items AS i
	JOIN UserGameItems AS ugi ON ugi.ItemId = i.Id
	JOIN UsersGames AS ug ON ug.Id = ugi.UserGameId
	JOIN Games AS g ON g.Id = ug.GameId AND g.Name = 'Safflower'
	ORDER BY i.Name

	RETURN;

END

ELSE BEGIN

UPDATE ug
SET ug.Cash -= @itemPrice
FROM Users AS u
JOIN UsersGames AS ug
	ON ug.UserId = u.Id AND u.Username = 'Stamat'
JOIN Games AS g
	ON g.Id = ug.GameId AND g.Name = 'Safflower'

INSERT INTO UserGameItems
SELECT i.Id, x.Id
FROM Items AS i
CROSS JOIN (
	SELECT ug.Id
	FROM UsersGames AS ug
	JOIN Games AS g ON g.Id = ug.GameId AND g.Name = 'Safflower'
) AS x
WHERE i.MinLevel IN (19, 20, 21)

COMMIT TRAN tr_Shopping_19_21

END