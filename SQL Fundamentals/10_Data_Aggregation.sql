--01. Records’ Count
SELECT COUNT(Id) AS Count
FROM WizzardDeposits;

--02. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits;

--03. Longest Magic Wand per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup;

--04. Smallest Deposit Group per Magic Wand Size
/*
SELECT DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
HAVING AVG(MagicWandSize) = (
	SELECT MIN(t.minn)
	FROM (
		SELECT DepositGroup, AVG(MagicWandSize) AS minn
		FROM WizzardDeposits
		GROUP BY DepositGroup
	) AS t
)
*/

SELECT TOP 1 WITH TIES DepositGroup, AVG(MagicWandSize)
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize);

--05. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup;

--06. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup;

--07. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC;

--08. Deposit Charge
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup ASC;

--09. Age Groups
SELECT a.AgeGroup, COUNT(*) AS WizardCount FROM 
(SELECT
CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	WHEN Age >= 61 THEN '[61+]'
END AS AgeGroup
FROM WizzardDeposits) AS a
GROUP BY a.AgeGroup

--10. First Letter
SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)

--11. Average Interest
SELECT DepositGroup, IsDepositExpired,
	CASE
	WHEN IsDepositExpired = 0 THEN AVG(DepositInterest)
	WHEN IsDepositExpired = 1 THEN AVG(DepositInterest) / 2
	END AS AverageInterest
FROM WizzardDeposits
WHERE DATEDIFF(DAY, '01/01/1985', DepositStartDate) > 0
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired;

--12. Rich Wizard, Poor Wizard
/*
SELECT SUM(d.SumDifference) FROM
(SELECT (DepositAmount - (
			SELECT DepositAmount
			FROM WizzardDeposits
			WHERE Id = w1.Id + 1)
	) AS SumDifference
FROM WizzardDeposits AS w1
WHERE NOT (DepositAmount - (
			SELECT DepositAmount
			FROM WizzardDeposits
			WHERE Id = w1.Id + 1)
	) IS NULL
) AS d
*/

/*
DECLARE @CurrDep decimal(8, 2)
DECLARE @PrevDep decimal(8, 2)
DECLARE @TotalSum decimal(8, 2) = 0
DECLARE WizzDep CURSOR FOR SELECT DepositAmount FROM WizzardDeposits
OPEN WizzDep
FETCH NEXT FROM WizzDep INTO @CurrDep

WHILE @@FETCH_STATUS = 0
BEGIN
	IF (@PrevDep IS NOT NULL)
	BEGIN
		SET @TotalSum += (@PrevDep - @CurrDep)
	END
	SET @PrevDep = @CurrDep
	FETCH NEXT FROM WizzDep INTO @CurrDep
END

CLOSE WizzDep
DEALLOCATE WizzDep
SELECT @TotalSum
*/

SELECT SUM(w.DepositAmount - w.NexDep) FROM
(SELECT DepositAmount, LEAD(DepositAmount) OVER(ORDER BY Id) AS NexDep
FROM WizzardDeposits) AS w
-- LEAD / LAG


--13. Departments Total Salaries
SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID;

--14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND DATEDIFF(DAY, '01/01/2000', HireDate) > 0
GROUP BY DepartmentID;

--15. Employees Average Salaries
SELECT * INTO dbo.NewTable FROM Employees WHERE Salary > 30000;
DELETE FROM NewTable WHERE ManagerID = 42;
UPDATE NewTable SET Salary += 5000;
SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM NewTable GROUP BY DepartmentID;

--16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING NOT MAX(Salary) BETWEEN 30000 AND 70000

--17. Employees Count Salaries
SELECT COUNT(Salary) AS Count
FROM Employees
WHERE ManagerID IS NULL

--18. 3rd Highest Salary
SELECT t.DepartmentID, t.Salary AS ThirdHighestSalary
FROM (
SELECT DepartmentID, Salary,
DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
FROM Employees
GROUP BY DepartmentID, Salary
) AS t
WHERE t.Rank = 3

--19. Salary Challenge
SELECT FirstName, LastName, DepartmentID
FROM Employees AS e
WHERE e.Salary > (
	SELECT AVG(t.Salary)
	FROM Employees AS t
	WHERE e.DepartmentID = t.DepartmentID
	GROUP BY t.DepartmentID
)