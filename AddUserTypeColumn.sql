-- Migration Script: Add UserType column to Users table
-- This script adds the missing UserType column to support Individual vs Dealer users

-- Check if UserType column already exists before adding it
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'UserType')
BEGIN
    -- Add UserType column with default value
    ALTER TABLE Users 
    ADD UserType NVARCHAR(20) NOT NULL DEFAULT 'Individual';
    
    PRINT 'UserType column added to Users table successfully.';
END
ELSE
BEGIN
    PRINT 'UserType column already exists in Users table.';
END

-- Verify the column was added
SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE, COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Users' 
ORDER BY ORDINAL_POSITION;