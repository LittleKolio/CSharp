--01. One-To-One Relationship
DROP DATABASE Test

CREATE DATABASE Test
GO
USE Test

CREATE TABLE Passports(
	PassportID int PRIMARY KEY NOT NULL,
	PassportNumber char(8) UNIQUE NOT NULL
)

CREATE TABLE Persons(
	PersonID int PRIMARY KEY IDENTITY(1, 1),
	FirstName varchar(50) NOT NULL,
	Salary decimal(8, 2) DEFAULT 0,
	PassportID int UNIQUE,
	CONSTRAINT FK_Passport
	FOREIGN KEY (PassportID)
	REFERENCES Passports(PassportID)
)

INSERT INTO Passports
VALUES
	(101, 'N34FG21B'),
	(102, 'K65LO4R7'),
	(103, 'ZE657QP2')

INSERT INTO Persons
VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)

/*
ALTER TABLE Persons
ALTER COLUMN Salary decimal(7, 2)

ALTER TABLE Persons
ADD CONSTRAINT DF_Salary
DEFAULT 0 FOR Salary
*/

--02. One-To-Many Relationship
CREATE TABLE Manufacturers(
	ManufacturerID int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(50) NOT NULL,
	EstablishedOn date
)

CREATE TABLE Models(
	ModelID int PRIMARY KEY IDENTITY(101, 1),
	Name varchar(50) NOT NULL,
	ManufacturerID int,
	CONSTRAINT FK_Manufacturer
	FOREIGN KEY (ManufacturerID)
	REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers
VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

INSERT INTO Models
VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)

--03. Many-To-Many Relationship
CREATE TABLE Students(
	StudentID int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(50) NOT NULL
)

CREATE TABLE Exams(
	ExamID int PRIMARY KEY IDENTITY(101, 1),
	Name varchar(50) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID int NOT NULL,
	ExamID int NOT NULL,
	CONSTRAINT PK_StudentID_ExamID
	PRIMARY KEY (StudentID, ExamID),
	CONSTRAINT FK_StudentID
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),
	CONSTRAINT FK_ExamID
	FOREIGN KEY (ExamID)
	REFERENCES Exams(ExamID)
)

INSERT INTO Students
VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO Exams
VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO StudentsExams
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

--04. Self-Referencing
CREATE TABLE Teachers(
	TeacherID int PRIMARY KEY IDENTITY(101, 1),
	Name varchar(50) NOT NULL,
	ManagerID int,
	CONSTRAINT FK_TeacherID
	FOREIGN KEY (ManagerID)
	REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

--05. Online Store Database
CREATE TABLE Cities(
	CityID int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(50) NOT NULL
)

CREATE TABLE Customers(
	CustomerID int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(50) NOT NULL,
	Birthday date NOT NULL,
	CityID int,
	CONSTRAINT FK_CityID
	FOREIGN KEY (CityID)
	REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
	OrderID int PRIMARY KEY IDENTITY(1, 1),
	CustomerID int,
	CONSTRAINT FK_CustomerID
	FOREIGN KEY (CustomerID)
	REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
	ItemTypeID int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(50) NOT NULL
)

CREATE TABLE Items(
	ItemID int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(50) NOT NULL,
	ItemTypeID int,
	CONSTRAINT FK_ItemTypeID
	FOREIGN KEY (ItemTypeID)
	REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
	OrderID int NOT NULL,
	ItemID int NOT NULL,
	CONSTRAINT PK_OrderID_ItemID
	PRIMARY KEY (OrderID, ItemID),
	CONSTRAINT FK_OrderID
	FOREIGN KEY (OrderID)
	REFERENCES Orders(OrderID),
	CONSTRAINT FK_ItemID
	FOREIGN KEY (ItemID)
	REFERENCES Items(ItemID)
)

--06. University Database
CREATE TABLE Majors(
	MajorID int PRIMARY KEY IDENTITY(1, 1),
	Name varchar(50) NOT NULL
)

CREATE TABLE Students(
	StudentID int PRIMARY KEY IDENTITY(1, 1),
	StudentNumber int NOT NULL,
	StudentName varchar(50) NOT NULL,
	MajorID int,
	CONSTRAINT FK_MajorID_Students
	FOREIGN KEY (MajorID)
	REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
	PaymentID int PRIMARY KEY IDENTITY(1, 1),
	PaymentDate date NOT NULL,
	PaymentAmount decimal(8, 2) NOT NULL,
	StudentID int UNIQUE,
	CONSTRAINT FK_StudentID_Payments
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID)
)

CREATE TABLE Subjects(
	SubjectID int PRIMARY KEY IDENTITY(1, 1),
	SubjectName varchar(50) NOT NULL
)

CREATE TABLE Agenda(
	StudentID int NOT NULL,
	SubjectID int NOT NULL,
	CONSTRAINT PK_StudentID_SubjectID
	PRIMARY KEY (StudentID, SubjectID),
	CONSTRAINT FK_StudentID_Agenda
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),
	CONSTRAINT FK_SubjectID_Agenda
	FOREIGN KEY (SubjectID)
	REFERENCES Subjects(SubjectID)
)

--09. Peaks in Rila
SELECT MountainRange, PeakName, Elevation
FROM Mountains JOIN Peaks
ON Peaks.MountainId = Mountains.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC;