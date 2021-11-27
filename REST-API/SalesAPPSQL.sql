CREATE DATABASE salesApp;
USE salesApp;

CREATE TABLE TblRole(
RoleId INT IDENTITY(1,1) PRIMARY KEY,
RoleName VARCHAR(50) NOT NULL);

INSERT INTO TblRole(RoleName)
VALUES ('Admin'),('SalesCoordinator');

select * from TblRole;


CREATE TABLE TblUser(
UserId INT IDENTITY(1,1) PRIMARY KEY,
UserName VARCHAR(20),
UserPassword VARCHAR(20),
RoleId INT CONSTRAINT FK_LOGIN FOREIGN KEY(RoleId) REFERENCES TblRole(RoleId));

INSERT INTO TBLUSER(UserName,UserPassword,RoleId)
VALUES  ('Vincy','vincy123',1),
		('Mary','mary123',2),
		('Saurav','saurav123',1),
		('Devaraj','devaraj123',2);

select * from TblUser;


CREATE TABLE EmployeeRegistration(
emp_id INT IDENTITY(1,1) PRIMARY KEY,
FirstName VARCHAR(30),
LastName VARCHAR(30),
Age INT,
Gender VARCHAR(30),
Address VARCHAR(30),
PhoneNumber NUMERIC,
UserId INT FOREIGN KEY REFERENCES TblUser(UserId));


CREATE TABLE VisitTbale(
Visit_id INT IDENTITY(1,1) PRIMARY KEY,
Cust_Name VARCHAR(100),
Contact_Person VARCHAR(100),
Contact_No NUMERIC,
Interest_Product VARCHAR(100),
Visit_Subject VARCHAR(100),
Description VARCHAR(100),
Visit_datetime DATETIME,
Is_Disabled BIT,
Is_Deleted BIT,
emp_id INT FOREIGN KEY REFERENCES EmployeeRegistration(emp_id));

select * from EmployeeRegistration;
