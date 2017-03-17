CREATE PROCEDURE TotalNumberOfBooks 
	@firstName varchar(100),
	@lastName varchar(100)
AS BEGIN
SELECT COUNT(*) AS NumberOfBooks
FROM Authors AS a
JOIN Books AS b
	ON b.AuthorId = a.Id
WHERE FirstName = @firstName
	AND LastName = @lastName
END

--EXEC TotalNumberOfBooks 'Amanda', 'Rice'