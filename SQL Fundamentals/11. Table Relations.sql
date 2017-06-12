CREATE DATABASE Test;
USE Test;

-- test1
CREATE TABLE Mountains(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(50) NOT NULL
)

CREATE TABLE Peaks(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(50) NOT NULL,
	MountainsId int NOT NULL,
	CONSTRAINT FK_Mountains
	FOREIGN KEY (MountainsId)
	REFERENCES Mountains(Id)
)

-- test2
CREATE TABLE Employees(
	Id int PRIMARY KEY IDENTITY(1, 1),
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Salary money,
)

CREATE TABLE Projects(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(255) NOT NULL,
	Description varchar(max),
	StartDate date DEFAULT GETDATE(),
	EndDate date
)

CREATE TABLE EmpToProj(
	EmployeesId int	FOREIGN KEY REFERENCES Employees(Id),
	ProjectsId int FOREIGN KEY REFERENCES Projects(Id),
	CONSTRAINT PK_EmployeesId_ProjectsId
	PRIMARY KEY (EmployeesId, ProjectsId)
)

-- test3
CREATE TABLE Cars(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Model varchar(50) NOT NULL
)

CREATE TABLE Drivers(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(255) NOT NULL,
	CarId int UNIQUE FOREIGN KEY
	REFERENCES Cars(Id)
)

-- Football Manager
CREATE TABLE Menagers(
	Id int PRIMARY KEY IDENTITY(1, 1),
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Salary decimal(8, 2) DEFAULT 0,
)

CREATE TABLE Teams(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(255) NOT NULL,
	MenagerId int UNIQUE,
	CONSTRAINT FK_Menager
	FOREIGN KEY (MenagerId)
	REFERENCES Menagers(Id)
)

CREATE TABLE Leagues(
	Id int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(255) NOT NULL
)

CREATE TABLE TeamsLeagues(
	TeamId int,
	LeagueId int,
	CONSTRAINT PK_TeamId_LeagueId
	PRIMARY KEY (TeamId, LeagueId),
	CONSTRAINT FK_TeamId
	FOREIGN KEY (TeamId)
	REFERENCES Teams(Id),
	CONSTRAINT FK_LeagueId
	FOREIGN KEY (LeagueId)
	REFERENCES Leagues(Id)
)

CREATE TABLE Players(
	Id int PRIMARY KEY IDENTITY(1, 1),
	PlayerNumber int,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Salary decimal(8, 2) DEFAULT 0,
	TeamId int,
	CONSTRAINT FK_Team
	FOREIGN KEY (TeamId)
	REFERENCES Teams(Id)
)


