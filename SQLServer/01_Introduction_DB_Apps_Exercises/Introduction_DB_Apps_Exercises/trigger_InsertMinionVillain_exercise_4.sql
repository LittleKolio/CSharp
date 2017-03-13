CREATE TRIGGER tr_InsertMinionVillan
ON MinionsVillains
INSTEAD OF INSERT
AS BEGIN

DECLARE @MinionId int = (SELECT MinionId FROM inserted);
DECLARE @VillainId int = (SELECT VillainId FROM inserted);

DECLARE @MinionName varchar(50) = (SELECT Name FROM Minions WHERE Id = @MinionId);
DECLARE @VillainName varchar(50) = (SELECT Name FROM Villains WHERE Id = @VillainId);
DECLARE @msg_Error varchar(50) = CONCAT('Minion ', @MinionName, ' alredy serve ', @VillainName, '.');

IF EXISTS(
	SELECT *
	FROM MinionsVillains
	WHERE MinionId = @MinionId
		AND VillainId = @VillainId
) BEGIN
	ROLLBACK;
	THROW 50004, @msg_Error, 1;
	RETURN;
END

INSERT INTO MinionsVillains
VALUES(@MinionId, @VillainId);

END