INSERT INTO Minions
VALUES (@MinionName, @Age, (
	SELECT Id
	FROM Towns
	WHERE Name = @TownName
));