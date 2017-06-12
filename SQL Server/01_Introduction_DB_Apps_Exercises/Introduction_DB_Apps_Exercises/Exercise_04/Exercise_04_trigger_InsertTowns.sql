CREATE TRIGGER tr_InsertTown
ON Towns
INSTEAD OF INSERT
AS BEGIN

DECLARE @TownName varchar(50) = (SELECT Name FROM inserted);
DECLARE @msg_Error varchar(50) = CONCAT('There is already town ', @TownName, ' in database.');

IF EXISTS(
	SELECT Name
	FROM Towns
	WHERE Name = @TownName
) BEGIN
	ROLLBACK;
	THROW 50002, @msg_Error, 1;
	RETURN;
END

INSERT INTO Towns
VALUES(@TownName, NULL)

END