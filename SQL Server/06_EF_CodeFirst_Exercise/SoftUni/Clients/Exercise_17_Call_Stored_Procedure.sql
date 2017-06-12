CREATE PROCEDURE AllProjects 
	@firstName varchar(50),
	@lastName varchar(50)
AS BEGIN
SELECT 
	p.Description, 
	p.EndDate, 
	p.Name, 
	p.ProjectID, 
	p.StartDate
FROM Employees AS e
JOIN EmployeesProjects AS ep
	ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p
	ON p.ProjectID = ep.ProjectID
WHERE e.FirstName = @firstName
	AND e.LastName = @lastName
END

--EXEC AllProjects 'Ruth', 'Ellerbrock'