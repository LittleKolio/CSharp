INSERT INTO MinionsVillains
VALUES((
	SELECT Id
	FROM Minions
	WHERE Name = @MinionName
), (
	SELECT Id
	FROM Villains
	WHERE Name = @VillainName
))