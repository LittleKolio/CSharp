CREATE FUNCTION ufn_CashInUsersGames(@gameName nvarchar(50))
RETURNS TABLE
AS RETURN (
	SELECT LEFT(SUM(r.Cash), LEN(SUM(r.Cash)) - 5) + '**.**' AS SumCash
	FROM (
		SELECT ug.Cash, ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RankCash
		FROM Games AS g
		JOIN UsersGames AS ug ON ug.GameId = g.Id
		AND g.Name = @gameName
	) AS r
	WHERE r.RankCash = 1 OR r.RankCash % 3 = 0
)


SELECT *
FROM dbo.ufn_CashInUsersGames('Love in a mist')



SELECT
	ug.Cash
	--ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RankCash
FROM Games AS g
JOIN UsersGames AS ug ON ug.GameId = g.Id
AND g.Name = 'Lily Stargazer'





CREATE FUNCTION ufn_CashInUsersGames(@gameName nvarchar(50))
RETURNS TABLE
AS RETURN (
	SELECT SUM(r.Cash) AS SumCash
	FROM (
		SELECT ug.Cash, ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RankCash
		FROM Games AS g
		JOIN UsersGames AS ug
		ON ug.GameId = g.Id AND g.Name = @gameName
	) AS r
	WHERE r.RankCash % 2 <> 0
)

SELECT *
FROM dbo.ufn_CashInUsersGames('Lily Stargazer')

DROP FUNCTION dbo.ufn_CashInUsersGames