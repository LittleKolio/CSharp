CREATE TABLE Towns(
	Id int IDENTITY,
	Name varchar(50),
	Country varchar(50),
	CONSTRAINT PK_Towns
	PRIMARY KEY (Id)
)

CREATE TABLE Minions(
	Id int IDENTITY,
	Name varchar(50),
	Age int,
	TownId int,
	CONSTRAINT PK_Minions
	PRIMARY KEY (Id),
	CONSTRAINT FK_Minions_Towns
	FOREIGN KEY (TownId)
	REFERENCES Towns(Id),
)

CREATE TABLE Villains(
	Id int IDENTITY,
	Name varchar(50),
	Evilness varchar(15),
	CONSTRAINT PK_Villains
	PRIMARY KEY (Id),
	CONSTRAINT CH_Villains_Evilness
	CHECK(Evilness IN('good', 'bad', 'evil', 'super evil'))
)

CREATE TABLE MinionsVillains(
	MinionId int,
	VillainId int,
	CONSTRAINT PK_MinionsVillains
	PRIMARY KEY (MinionId, VillainId),
	CONSTRAINT FK_MinVil_Minions
	FOREIGN KEY (MinionId)
	REFERENCES Minions(Id),
	CONSTRAINT FK_MinVil_Villains
	FOREIGN KEY (VillainId)
	REFERENCES Villains(Id),
)