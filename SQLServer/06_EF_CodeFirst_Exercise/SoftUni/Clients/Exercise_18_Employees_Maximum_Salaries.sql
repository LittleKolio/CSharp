SELECT r.Name, r.Salary, r.Num
FROM (
	SELECT 
		d.DepartmentID,
		d.Name, 
		e.Salary, 
		RANK() OVER (PARTITION BY d.DepartmentID ORDER BY e.Salary DESC) AS Num
	FROM Employees AS e
	JOIN Departments AS d
		ON d.DepartmentID = e.DepartmentID
) AS r
WHERE NOT r.Salary BETWEEN @lowSalary AND @highSalary
	AND r.Num = 1