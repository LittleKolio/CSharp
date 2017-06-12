--01. Employee Address
SELECT TOP 5 EmployeeID, JobTitle, a.AddressID, AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID;

--02. Addresses with Towns
SELECT TOP 50 FirstName, LastName, t.Name AS Town, AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY FirstName, LastName;

--03. Sales Employees
SELECT EmployeeID, FirstName, LastName, d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID;

--04. Employee Departments
SELECT TOP 5 EmployeeID, FirstName, Salary, d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID;

--05. Employees Without Projects
SELECT TOP 3 e.EmployeeID, FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS p
ON e.EmployeeID = p.EmployeeID
WHERE p.EmployeeID IS NULL
ORDER BY e.EmployeeID

--06. Employees Hired After
SELECT FirstName, LastName, HireDate, d.Name AS DeptName
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1999/1/1' AND d.Name IN ('Sales', 'Finance')

--07. Employees With Project
SELECT TOP 5 e.EmployeeID, FirstName, p.Name AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002/08/13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--08. Employee 24
SELECT e.EmployeeID, FirstName,
CASE
WHEN YEAR(p.StartDate) >= 2005 THEN NULL
ELSE p.Name
END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--09. Employee Manager
SELECT e1.EmployeeID, e1.FirstName , e1.ManagerID, e2.FirstName AS ManagerName
FROM Employees AS e1
JOIN Employees AS e2
ON e1.ManagerID = e2.EmployeeID
WHERE e1.ManagerID IN (3, 7)
ORDER BY e1.EmployeeID

--10. Employees Summary
SELECT TOP 50
	e1.EmployeeID,
	e1.FirstName + ' ' + e1.LastName,
	e2.FirstName + ' ' + e2.LastName AS ManagerName,
	d.Name AS DepartmentName
FROM Employees AS e1
JOIN Employees AS e2
ON e1.ManagerID = e2.EmployeeID
JOIN Departments AS d
ON e1.DepartmentID = d.DepartmentID
ORDER BY e1.EmployeeID

--11. Min Average Salary
SELECT MIN(s.MinSalary) AS MinAverageSalary
FROM (
	SELECT AVG(Salary) AS MinSalary
	FROM Employees
	GROUP BY DepartmentID
) AS s;

/*
SELECT AVG(Salary) AS MinSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY AVG(Salary)
OFFSET 2 ROWS
FETCH NEXT 1 ROW ONLY
*/



-- Ranking Functions (Transact-SQL)
/*
SELECT * FROM (
	SELECT
		DepartmentID,
		AVG(Salary) AS MinSalary,
		DENSE_RANK() OVER (ORDER BY AVG(Salary)) AS Ranking
	FROM Employees
	GROUP BY DepartmentID
) AS c
WHERE c.Ranking = 3
*/

/*
SELECT * FROM (
	SELECT
		DepartmentID,
		AVG(Salary) AS MinSalary,
		ROW_NUMBER() OVER (ORDER BY AVG(Salary)) AS Ranking
	FROM Employees
	GROUP BY DepartmentID
) AS c
*/

/*
SELECT * FROM (
	SELECT
		DepartmentID,
		AVG(Salary) AS MinSalary,
		NTILE(4) OVER (ORDER BY AVG(Salary)) AS Ranking
	FROM Employees
	GROUP BY DepartmentID
) AS c
*/

-- PARTITION BY DepartmentID = GROUP BY DepartmentID

/*
SELECT
	DepartmentID,
	ManagerID,
	Salary,
	ROW_NUMBER() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Ranking
FROM Employees
*/





--12. Highest Peaks in Bulgaria
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON m.Id = p.MountainId
WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13. Count Mountain Ranges
SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode

--14. Countries With or Without Rivers
SELECT TOP 5 c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
JOIN Continents AS con ON c.ContinentCode = con.ContinentCode
WHERE con.ContinentName = 'Africa'
ORDER BY c.CountryName

--15. Continents and Currencies
/*
SELECT
	a.ContinentCode,
	a.CurrencyCode,
	a.CurrencyUsage
FROM(
	SELECT
		ContinentCode,
		CurrencyCode,
		COUNT(*) AS CurrencyUsage,
		ROW_NUMBER() OVER (PARTITION BY ContinentCode ORDER BY COUNT(*) DESC) AS Rank
	FROM Countries
	GROUP BY ContinentCode, CurrencyCode
	HAVING COUNT(*) > 1
) AS a
WHERE a.Rank = 1
*/

/*
WITH com (ContinentCode, CurrencyCode, CurrencyUsage)
AS (
	SELECT ContinentCode, CurrencyCode, COUNT(*)
	FROM Countries
	GROUP BY ContinentCode, CurrencyCode
)
*/

SELECT b.ContinentCode, a.CurrencyCode, b.CurrUs
	FROM (
		SELECT ContinentCode, CurrencyCode, COUNT(*) AS CurrUs
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode
		HAVING COUNT(*) > 1
	) AS a
JOIN (
	SELECT c.ContinentCode, MAX(c.CurrUs) AS CurrUs
	FROM (
		SELECT ContinentCode, CurrencyCode, COUNT(*) AS CurrUs
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode
	) AS c
	GROUP BY ContinentCode
) AS b ON b.ContinentCode = a.ContinentCode AND b.CurrUs = a.CurrUs

--16. Countries Without any Mountains
SELECT COUNT(*) AS CountryCode
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE m.Id IS NULL

--17. Highest Peak and Longest River by Country
SELECT TOP 5 c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.Length) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Peaks AS p ON p.MountainId = mc.MountainId
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC, MAX(r.Length) DESC, c.CountryName

--18. Highest Peak Name and Elevation by Country

WITH bah (Country, HighestPeakName, HighestPeakElevation, Mountain)
AS (
	SELECT
		c.CountryName,
		CASE WHEN p.PeakName IS NULL THEN '(no highest peak)'
		ELSE p.PeakName END,
		CASE WHEN p.Elevation IS NULL THEN 0
		ELSE p.Elevation END,
		CASE WHEN m.MountainRange IS NULL THEN '(no mountain)'
		ELSE m.MountainRange END
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p ON p.MountainId = m.Id
)
--SELECT * FROM bah ORDER BY Country

SELECT TOP 5 a.Country, c.HighestPeakName AS HighestPeakName, a.HighestPeakElevation AS HighestPeakElevation, c.Mountain AS Mountain
FROM (
	SELECT Country, MAX(HighestPeakElevation) AS HighestPeakElevation
	FROM bah
	GROUP BY Country
) AS a
JOIN (
	SELECT * FROM bah
) AS c ON a.Country = c.Country
ORDER BY a.Country, c.HighestPeakName