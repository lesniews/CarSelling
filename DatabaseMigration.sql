-- Database Migration Script for CarSelling
-- Run this script to update existing database schema without losing data

-- Step 1: Add UserType column if it doesn't exist
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'UserType')
BEGIN
    ALTER TABLE Users 
    ADD UserType NVARCHAR(20) NOT NULL DEFAULT 'Individual';
    PRINT 'UserType column added to Users table successfully.';
END

-- Step 2: Add any other missing columns that exist in Entity Framework model
-- Add CreatedAt to Users if missing
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'CreatedAt')
BEGIN
    ALTER TABLE Users 
    ADD CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE();
    PRINT 'CreatedAt column added to Users table.';
END

-- Add UpdatedAt to Users if missing
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'UpdatedAt')
BEGIN
    ALTER TABLE Users 
    ADD UpdatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE();
    PRINT 'UpdatedAt column added to Users table.';
END

-- Add IsActive to Users if missing
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'IsActive')
BEGIN
    ALTER TABLE Users 
    ADD IsActive BIT NOT NULL DEFAULT 1;
    PRINT 'IsActive column added to Users table.';
END

-- Add other User columns from Entity Framework model
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'PreferredLocation')
BEGIN
    ALTER TABLE Users 
    ADD PreferredLocation NVARCHAR(100) NULL;
    PRINT 'PreferredLocation column added to Users table.';
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'CompanyName')
BEGIN
    ALTER TABLE Users 
    ADD CompanyName NVARCHAR(100) NULL;
    PRINT 'CompanyName column added to Users table.';
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'LicenseNumber')
BEGIN
    ALTER TABLE Users 
    ADD LicenseNumber NVARCHAR(50) NULL;
    PRINT 'LicenseNumber column added to Users table.';
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'AverageRating')
BEGIN
    ALTER TABLE Users 
    ADD AverageRating DECIMAL(3,2) NOT NULL DEFAULT 0;
    PRINT 'AverageRating column added to Users table.';
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'TotalListings')
BEGIN
    ALTER TABLE Users 
    ADD TotalListings INT NOT NULL DEFAULT 0;
    PRINT 'TotalListings column added to Users table.';
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'SoldCars')
BEGIN
    ALTER TABLE Users 
    ADD SoldCars INT NOT NULL DEFAULT 0;
    PRINT 'SoldCars column added to Users table.';
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'ReviewCount')
BEGIN
    ALTER TABLE Users 
    ADD ReviewCount INT NOT NULL DEFAULT 0;
    PRINT 'ReviewCount column added to Users table.';
END

-- Step 3: Verify schema matches Entity Framework model
PRINT 'Database migration completed. Verifying schema...';

SELECT 'Users Table Schema:' as Info;
SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE, COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Users' 
ORDER BY ORDINAL_POSITION;

PRINT 'Migration script completed successfully.';