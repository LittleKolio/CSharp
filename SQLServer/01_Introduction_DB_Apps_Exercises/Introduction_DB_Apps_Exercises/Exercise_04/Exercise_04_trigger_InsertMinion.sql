CREATE TRIGGER tr_InsertMinion
ON Minions
INSTEAD OF INSERT
AS BEGIN

DECLARE @MinionName varchar(50) = (SELECT Name FROM inserted);
DECLARE @msg_Error varchar(50) = CONCAT('There is already minion ', @MinionName, ' in database.');

IF EXISTS(
	SELECT *
	FROM Minions
	WHERE Name = @MinionName
) BEGIN
	ROLLBACK;
	THROW 50001, @msg_Error, 1;
	RETURN;
END

INSERT INTO Minions
SELECT Name, Age, TownId
FROM inserted;

END