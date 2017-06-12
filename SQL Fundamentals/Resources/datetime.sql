SELECT   
   '2006-04-25T15:50:59.997' AS UnconvertedText,  
   CAST('2006-04-25T15:50:59.997' AS datetime) AS UsingCast,  
   CONVERT(datetime, '2006-04-25T15:50:59.997', 126) AS UsingConvertFrom_ISO8601 ;  
GO

-- DATEADD (year/minute/... , duration , date )

-- DATEDIFF(DAY, '01/01/2000', HireDate) > 0

-- CONVERT (data_type(length), expression, style)

--CONVERT(date, GETDATE())