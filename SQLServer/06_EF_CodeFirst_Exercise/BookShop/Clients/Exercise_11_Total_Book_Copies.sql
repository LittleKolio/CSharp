SELECT
	CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
	SUM(b.Copies) AS Copies
FROM Books AS b
JOIN Authors AS a
	ON a.Id = b.AuthorId
GROUP BY CONCAT(a.FirstName, ' ', a.LastName)
ORDER BY Copies DESC;
