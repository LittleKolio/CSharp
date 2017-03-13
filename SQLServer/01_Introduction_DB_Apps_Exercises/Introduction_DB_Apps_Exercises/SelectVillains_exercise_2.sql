SELECT v.Name, mv.MinionsCount
FROM Villains AS v
JOIN (
	SELECT VillainId, COUNT(*) AS MinionsCount
	FROM MinionsVillains
	GROUP BY VillainId
) AS mv ON mv.VillainId = v.Id
WHERE mv.MinionsCount > 3
ORDER BY mv.MinionsCount DESC;