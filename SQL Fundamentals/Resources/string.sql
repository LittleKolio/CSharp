

-- SUBSTRING(@str, start, length)

-- LEFT() / RIGHT()
WHERE LEFT(@string, 2) = 'SA'
RIGHT(RTRIM(cr.Email), 5) = 'co.uk' = cr.Email LIKE '%co.uk'

-- LEN(@something)

-- Except Engineers
WHERE NOT JobTitle LIKE '%engineer%';

-- Starting With
WHERE Name LIKE '[MKBE]%'

-- Not Starting With
WHERE Name LIKE '[^RBD]%'

--13. User Email Providers
SELECT Username, RIGHT(Email, LEN(Email) - CHARINDEX('@', Email, 1)) AS 'Email Provider'
FROM Users
ORDER BY 'Email Provider', Username;

--14. Get Users with IPAddress Like Pattern
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username;

-- CAST ( expression AS data_type(length))
-- CONVERT (data_type(length), expression, style)