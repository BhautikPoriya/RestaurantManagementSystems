------------- <BHAUTIK PORIYA> - 09/08/2025 --------------

-- CREATE TABLE ROLES -- [GO] --
CREATE TABLE t_sys_roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL UNIQUE,
    Description VARCHAR(255) NULL
);

-- INSRET DEFAULT ROLES -- [GO] --
INSERT INTO t_sys_roles (Name, Description) VALUES 
('Administrator', 'Has full access to system management.'),
('Manager', 'Manages restaurant operations.'),
('Chef', 'Responsible for kitchen and food preparation.'),
('Waiter', 'Serves customers.'),
('Worker', 'General support in the restaurant'),
('Cashier', 'Handles customer billing and transactions.');

-- CREATE TABLE USERS -- [GO] --
CREATE TABLE t_sys_users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    DateOfBirth DATE NULL,
    Gender VARCHAR(10) NULL,
    Phone VARCHAR(20) NULL,
	Address VARCHAR(255) NULL,
	AffiliateId INT NULL, 
    IsActive BIT DEFAULT 1
);

-- CREATE TABLE STAFF -- [GO] --
CREATE TABLE t_sys_staff (
    StaffId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Gender VARCHAR(10) NULL,        
    Shift VARCHAR(50) NOT NULL,
    IsActive BIT DEFAULT 1
);

-- CREATE TABLE CATEGORY -- [GO] --
CREATE TABLE t_sys_category (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    PictureId INT NULL,        
	ParentCategoryId INT NULL,
    CategoryType VARCHAR(10) NOT NULL,
    IsActive BIT DEFAULT 1
);

-- CREATE TABLE DISHES -- [GO] --
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

------------- <BHAUTIK PORIYA> - 09/08/2025 --------------