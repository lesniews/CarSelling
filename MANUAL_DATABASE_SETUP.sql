-- Manual Database Setup for CarSelling
-- Run this script directly in SQL Server to test the database setup

USE master;
GO

-- Drop database if exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'CarSellingDb')
BEGIN
    ALTER DATABASE CarSellingDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CarSellingDb;
END
GO

-- Create database
CREATE DATABASE CarSellingDb;
GO

USE CarSellingDb;
GO

-- Create CarBrands table
CREATE TABLE CarBrands (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(50) NOT NULL,
    Country nvarchar(50) NULL,
    IsLuxury bit NOT NULL DEFAULT 0,
    IsActive bit NOT NULL DEFAULT 1
);

CREATE UNIQUE INDEX IX_CarBrands_Name ON CarBrands (Name);
GO

-- Create CarModels table
CREATE TABLE CarModels (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(100) NOT NULL,
    CarBrandId int NOT NULL,
    Category nvarchar(30) NULL,
    StartYear int NOT NULL DEFAULT 1990,
    EndYear int NULL,
    IsActive bit NOT NULL DEFAULT 1,
    FOREIGN KEY (CarBrandId) REFERENCES CarBrands(Id) ON DELETE CASCADE
);

CREATE INDEX IX_CarModels_CarBrandId ON CarModels (CarBrandId);
CREATE UNIQUE INDEX IX_CarModels_CarBrandId_Name ON CarModels (CarBrandId, Name);
GO

-- Insert test brands
INSERT INTO CarBrands (Name, Country, IsLuxury, IsActive) VALUES
('Toyota', 'Japan', 0, 1),
('Honda', 'Japan', 0, 1),
('Ford', 'USA', 0, 1),
('BMW', 'Germany', 1, 1),
('Tesla', 'USA', 1, 1);

-- Insert test models
INSERT INTO CarModels (Name, CarBrandId, Category, StartYear) VALUES
('Camry', 1, 'Sedan', 1982),
('Corolla', 1, 'Sedan', 1966),
('RAV4', 1, 'SUV', 1994),
('Accord', 2, 'Sedan', 1976),
('Civic', 2, 'Sedan', 1972),
('CR-V', 2, 'SUV', 1995),
('F-150', 3, 'Truck', 1948),
('Mustang', 3, 'Coupe', 1964),
('3 Series', 4, 'Sedan', 1975),
('X5', 4, 'SUV', 1999),
('Model S', 5, 'Sedan', 2012),
('Model 3', 5, 'Sedan', 2017);

-- Verify data
SELECT 'Brands Count' as TableName, COUNT(*) as RecordCount FROM CarBrands
UNION ALL
SELECT 'Models Count', COUNT(*) FROM CarModels;

-- Test the API queries
SELECT b.Name as Brand, COUNT(m.Id) as ModelCount 
FROM CarBrands b 
LEFT JOIN CarModels m ON b.Id = m.CarBrandId 
GROUP BY b.Name 
ORDER BY b.Name;

PRINT 'Database setup complete! You should see 5 brands and 12 models.';
GO