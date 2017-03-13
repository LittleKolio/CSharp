SELECT v.Name AS VillainName, m.Name AS MinionName, m.Age AS MinionAge
FROM Villains AS v
LEFT JOIN MinionsVillains AS mv
	ON mv.VillainId = v.Id
LEFT JOIN Minions AS m
	ON m.Id = mv.MinionId
WHERE v.Id = @VillainId