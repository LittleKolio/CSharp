CREATE TRIGGER tr_InsertVillain
ON Villains
INSTEAD OF INSERT
AS BEGIN

DECLARE @VillainName varchar(50) = (SELECT Name FROM inserted);
DECLARE @msg_Error varchar(50) = CONCAT('There is already villain ', @VillainName, ' in database.');

IF EXISTS(
	SELECT Name
	FROM Villains
	WHERE Name = @VillainName
) BEGIN
	ROLLBACK;
	THROW 50003, @msg_Error, 1;
	RETURN;
END

INSERT INTO Villains
VALUES(@VillainName, 'evil')

END