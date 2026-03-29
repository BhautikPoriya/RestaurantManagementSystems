------------- <BHAUTIK PORIYA> - 09/08/2025 --------------

-- CREATE TABLE ROLES -- [GO] --
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 't_sys_roles')
BEGIN
	CREATE TABLE t_sys_roles (
		RoleId INT IDENTITY(1,1) PRIMARY KEY,
		Name VARCHAR(50) NOT NULL UNIQUE,
		Description VARCHAR(255) NULL
	);
END
GO

-- INSRET DEFAULT ROLES -- [GO] --
IF NOT EXISTS (SELECT 1 FROM t_sys_roles WHERE Name = 'Administrator')
INSERT INTO t_sys_roles (Name, Description)
VALUES ('Administrator', 'Has full access to system management.');

IF NOT EXISTS (SELECT 1 FROM t_sys_roles WHERE Name = 'Customer')
INSERT INTO t_sys_roles (Name, Description)
VALUES ('Customer', 'Regular customer.');

IF NOT EXISTS (SELECT 1 FROM t_sys_roles WHERE Name = 'Manager')
INSERT INTO t_sys_roles (Name, Description)
VALUES ('Manager', 'Manages restaurant operations.');

IF NOT EXISTS (SELECT 1 FROM t_sys_roles WHERE Name = 'Chef')
INSERT INTO t_sys_roles (Name, Description)
VALUES ('Chef', 'Responsible for kitchen and food preparation.');

IF NOT EXISTS (SELECT 1 FROM t_sys_roles WHERE Name = 'Waiter')
INSERT INTO t_sys_roles (Name, Description)
VALUES ('Waiter', 'Serves customers.');

IF NOT EXISTS (SELECT 1 FROM t_sys_roles WHERE Name = 'Worker')
INSERT INTO t_sys_roles (Name, Description)
VALUES ('Worker', 'General support in the restaurant');

IF NOT EXISTS (SELECT 1 FROM t_sys_roles WHERE Name = 'Cashier')
INSERT INTO t_sys_roles (Name, Description)
VALUES ('Cashier', 'Handles customer billing and transactions.');


-- CREATE TABLE USERS -- [GO] --
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 't_sys_users')
BEGIN
	CREATE TABLE t_sys_users (
		UserId INT IDENTITY(1,1) PRIMARY KEY,
		UserName VARCHAR(50) NOT NULL,
		FirstName VARCHAR(50) NOT NULL,
		LastName VARCHAR(50) NOT NULL,
		Password VARCHAR(255) NOT NULL,
		Email VARCHAR(100) NOT NULL UNIQUE,
		DateOfBirth DATE NULL,
		Gender VARCHAR(10) NULL,
		Phone VARCHAR(20) NULL,
		Address VARCHAR(255) NULL,
		AffiliateId INT NULL, 
		RoleId INT NOT NULL,
		IsActive BIT DEFAULT 1
	);
END
GO

-- INSERT DEFAULT SYSTEM ADMIN USER -- [GO] --
IF NOT EXISTS (SELECT 1 FROM t_sys_users WHERE UserName = 'SystemAdmin')
BEGIN
	INSERT INTO t_sys_users (UserName,FirstName,LastName,Email,RoleId,IsActive,Password) 
	VALUES ('SystemAdmin', 'System','Admin', 'systemadmin@rajdhani.in',1,1,'N2KGmLYReYPCd2g5CiVXEw==');
END

-- CREATE TABLE STAFF -- [GO] --
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 't_sys_staff')
BEGIN
	CREATE TABLE t_sys_staff (
		StaffId INT IDENTITY(1,1) PRIMARY KEY,
		FirstName VARCHAR(50) NOT NULL,
		LastName VARCHAR(50) NOT NULL,
		Phone VARCHAR(20) NOT NULL,
		Gender VARCHAR(10) NULL,        
        Shift VARCHAR(50) NOT NULL,
		RoleId INT NOT NULL,
        IsActive BIT DEFAULT 1
    );
END
GO    

-- CREATE TABLE CATEGORY -- [GO] --
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 't_sys_category')
BEGIN
	CREATE TABLE t_sys_category (
		CategoryId INT IDENTITY(1,1) PRIMARY KEY,
		Name VARCHAR(100) NOT NULL,
		PictureId INT NULL,        
		ParentCategoryId INT NULL,
		CategoryType VARCHAR(10) NOT NULL,
        IsActive BIT DEFAULT 1
    );
END
GO

-- CREATE TABLE DISHES -- [GO] --
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 't_sys_dishes')
BEGIN
	CREATE TABLE t_sys_dishes (
		DishId INT IDENTITY(1,1) PRIMARY KEY,
		Name VARCHAR(100) NOT NULL,
		PictureId INT NULL,                              
		Price DECIMAL(10,2) NOT NULL,
		OldPrice DECIMAL(10,2) NULL,
        MarkAsNew BIT DEFAULT 0,
        DishType VARCHAR(10) NOT NULL,
        CategoryId INT NOT NULL,
        IsActive BIT DEFAULT 1,
    );
END
GO

------------- <BHAUTIK PORIYA> - 09/08/2025 --------------