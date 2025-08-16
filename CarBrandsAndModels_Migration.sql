-- Migration to add CarBrands and CarModels tables with comprehensive data
-- Run this script in your database to enable the dynamic car models functionality

-- Create CarBrands table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CarBrands' and xtype='U')
BEGIN
    CREATE TABLE CarBrands (
        Id int IDENTITY(1,1) PRIMARY KEY,
        Name nvarchar(50) NOT NULL,
        Country nvarchar(50) NULL,
        IsLuxury bit NOT NULL DEFAULT 0,
        IsActive bit NOT NULL DEFAULT 1
    );
    
    CREATE UNIQUE INDEX IX_CarBrands_Name ON CarBrands (Name);
    CREATE INDEX IX_CarBrands_Country ON CarBrands (Country);
    CREATE INDEX IX_CarBrands_IsLuxury ON CarBrands (IsLuxury);
    CREATE INDEX IX_CarBrands_IsActive ON CarBrands (IsActive);
END

-- Create CarModels table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CarModels' and xtype='U')
BEGIN
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
    
    CREATE INDEX IX_CarModels_Name ON CarModels (Name);
    CREATE INDEX IX_CarModels_CarBrandId ON CarModels (CarBrandId);
    CREATE INDEX IX_CarModels_Category ON CarModels (Category);
    CREATE INDEX IX_CarModels_StartYear ON CarModels (StartYear);
    CREATE INDEX IX_CarModels_EndYear ON CarModels (EndYear);
    CREATE INDEX IX_CarModels_IsActive ON CarModels (IsActive);
    CREATE UNIQUE INDEX IX_CarModels_CarBrandId_Name ON CarModels (CarBrandId, Name);
END

-- Clear existing data if any
DELETE FROM CarModels;
DELETE FROM CarBrands;

-- Insert Car Brands
SET IDENTITY_INSERT CarBrands ON;

INSERT INTO CarBrands (Id, Name, Country, IsLuxury, IsActive) VALUES
(1, 'Audi', 'Germany', 1, 1),
(2, 'BMW', 'Germany', 1, 1),
(3, 'Mercedes-Benz', 'Germany', 1, 1),
(4, 'Porsche', 'Germany', 1, 1),
(5, 'Volkswagen', 'Germany', 0, 1),
(6, 'Opel', 'Germany', 0, 1),
(7, 'Smart', 'Germany', 0, 1),
(8, 'Maybach', 'Germany', 1, 1),
(9, 'Ford', 'USA', 0, 1),
(10, 'Chevrolet', 'USA', 0, 1),
(11, 'Cadillac', 'USA', 1, 1),
(12, 'Buick', 'USA', 0, 1),
(13, 'GMC', 'USA', 0, 1),
(14, 'Chrysler', 'USA', 0, 1),
(15, 'Dodge', 'USA', 0, 1),
(16, 'Jeep', 'USA', 0, 1),
(17, 'Ram', 'USA', 0, 1),
(18, 'Lincoln', 'USA', 1, 1),
(19, 'Tesla', 'USA', 1, 1),
(20, 'Toyota', 'Japan', 0, 1),
(21, 'Honda', 'Japan', 0, 1),
(22, 'Nissan', 'Japan', 0, 1),
(23, 'Mazda', 'Japan', 0, 1),
(24, 'Subaru', 'Japan', 0, 1),
(25, 'Mitsubishi', 'Japan', 0, 1),
(26, 'Suzuki', 'Japan', 0, 1),
(27, 'Lexus', 'Japan', 1, 1),
(28, 'Acura', 'Japan', 1, 1),
(29, 'Infiniti', 'Japan', 1, 1),
(30, 'Hyundai', 'South Korea', 0, 1),
(31, 'Kia', 'South Korea', 0, 1),
(32, 'Genesis', 'South Korea', 1, 1),
(33, 'Jaguar', 'UK', 1, 1),
(34, 'Land Rover', 'UK', 1, 1),
(35, 'Bentley', 'UK', 1, 1),
(36, 'Rolls-Royce', 'UK', 1, 1),
(37, 'Aston Martin', 'UK', 1, 1),
(38, 'McLaren', 'UK', 1, 1),
(39, 'Lotus', 'UK', 1, 1),
(40, 'Mini', 'UK', 0, 1),
(41, 'Ferrari', 'Italy', 1, 1),
(42, 'Lamborghini', 'Italy', 1, 1),
(43, 'Maserati', 'Italy', 1, 1),
(44, 'Alfa Romeo', 'Italy', 1, 1),
(45, 'Fiat', 'Italy', 0, 1),
(46, 'Lancia', 'Italy', 0, 1),
(47, 'Pagani', 'Italy', 1, 1),
(48, 'Peugeot', 'France', 0, 1),
(49, 'Renault', 'France', 0, 1),
(50, 'Citroën', 'France', 0, 1),
(51, 'Bugatti', 'France', 1, 1),
(52, 'Alpine', 'France', 1, 1),
(53, 'Volvo', 'Sweden', 0, 1),
(54, 'Saab', 'Sweden', 0, 1),
(55, 'Polestar', 'Sweden', 1, 1),
(56, 'Koenigsegg', 'Sweden', 1, 1),
(57, 'Škoda', 'Czech Republic', 0, 1),
(58, 'SEAT', 'Spain', 0, 1),
(59, 'Cupra', 'Spain', 0, 1),
(60, 'BYD', 'China', 0, 1),
(61, 'Geely', 'China', 0, 1),
(62, 'Great Wall', 'China', 0, 1),
(63, 'Chery', 'China', 0, 1),
(64, 'NIO', 'China', 1, 1),
(65, 'Xpeng', 'China', 0, 1),
(66, 'Li Auto', 'China', 0, 1),
(67, 'Dacia', 'Romania', 0, 1),
(68, 'Lada', 'Russia', 0, 1),
(69, 'Tata', 'India', 0, 1),
(70, 'Mahindra', 'India', 0, 1),
(71, 'Proton', 'Malaysia', 0, 1),
(72, 'Perodua', 'Malaysia', 0, 1),
(73, 'Rivian', 'USA', 1, 1),
(74, 'Lucid', 'USA', 1, 1),
(75, 'Fisker', 'USA', 1, 1),
(76, 'Pontiac', 'USA', 0, 0),
(77, 'Saturn', 'USA', 0, 0),
(78, 'Oldsmobile', 'USA', 0, 0),
(79, 'Plymouth', 'USA', 0, 0),
(80, 'Mercury', 'USA', 0, 0),
(81, 'Hummer', 'USA', 0, 0),
(82, 'Scion', 'Japan', 0, 0),
(83, 'Morgan', 'UK', 1, 1),
(84, 'Caterham', 'UK', 1, 1),
(85, 'TVR', 'UK', 1, 1),
(86, 'Noble', 'UK', 1, 1),
(87, 'Spyker', 'Netherlands', 1, 1),
(88, 'Zenvo', 'Denmark', 1, 1),
(89, 'Rimac', 'Croatia', 1, 1);

SET IDENTITY_INSERT CarBrands OFF;

-- Insert Car Models
SET IDENTITY_INSERT CarModels ON;

INSERT INTO CarModels (Id, Name, CarBrandId, Category, StartYear, EndYear, IsActive) VALUES
-- Toyota Models (Brand ID: 20)
(1, 'Camry', 20, 'Sedan', 1982, NULL, 1),
(2, 'Corolla', 20, 'Sedan', 1966, NULL, 1),
(3, 'Prius', 20, 'Hybrid', 1997, NULL, 1),
(4, 'RAV4', 20, 'SUV', 1994, NULL, 1),
(5, 'Highlander', 20, 'SUV', 2000, NULL, 1),
(6, '4Runner', 20, 'SUV', 1984, NULL, 1),
(7, 'Tacoma', 20, 'Truck', 1995, NULL, 1),
(8, 'Tundra', 20, 'Truck', 1999, NULL, 1),
(9, 'Sienna', 20, 'Van', 1997, NULL, 1),
(10, 'Avalon', 20, 'Sedan', 1994, NULL, 1),
(11, 'Venza', 20, 'SUV', 2008, NULL, 1),

-- Honda Models (Brand ID: 21)
(12, 'Accord', 21, 'Sedan', 1976, NULL, 1),
(13, 'Civic', 21, 'Sedan', 1972, NULL, 1),
(14, 'CR-V', 21, 'SUV', 1995, NULL, 1),
(15, 'Pilot', 21, 'SUV', 2002, NULL, 1),
(16, 'Passport', 21, 'SUV', 1993, NULL, 1),
(17, 'Ridgeline', 21, 'Truck', 2005, NULL, 1),
(18, 'Odyssey', 21, 'Van', 1994, NULL, 1),
(19, 'HR-V', 21, 'SUV', 2014, NULL, 1),
(20, 'Insight', 21, 'Hybrid', 1999, NULL, 1),
(21, 'Fit', 21, 'Hatchback', 2006, 2020, 1),

-- Ford Models (Brand ID: 9)
(22, 'F-150', 9, 'Truck', 1948, NULL, 1),
(23, 'Mustang', 9, 'Coupe', 1964, NULL, 1),
(24, 'Explorer', 9, 'SUV', 1990, NULL, 1),
(25, 'Edge', 9, 'SUV', 2006, NULL, 1),
(26, 'Escape', 9, 'SUV', 2000, NULL, 1),
(27, 'Expedition', 9, 'SUV', 1996, NULL, 1),
(28, 'Bronco', 9, 'SUV', 1965, NULL, 1),
(29, 'Ranger', 9, 'Truck', 1982, NULL, 1),
(30, 'Fusion', 9, 'Sedan', 2005, 2020, 1),
(31, 'Focus', 9, 'Hatchback', 1998, 2018, 1),

-- Chevrolet Models (Brand ID: 10)
(32, 'Silverado', 10, 'Truck', 1998, NULL, 1),
(33, 'Equinox', 10, 'SUV', 2004, NULL, 1),
(34, 'Tahoe', 10, 'SUV', 1994, NULL, 1),
(35, 'Suburban', 10, 'SUV', 1934, NULL, 1),
(36, 'Traverse', 10, 'SUV', 2008, NULL, 1),
(37, 'Camaro', 10, 'Coupe', 1966, NULL, 1),
(38, 'Corvette', 10, 'Coupe', 1953, NULL, 1),
(39, 'Malibu', 10, 'Sedan', 1964, NULL, 1),
(40, 'Impala', 10, 'Sedan', 1958, 2020, 1),
(41, 'Blazer', 10, 'SUV', 1969, NULL, 1),

-- BMW Models (Brand ID: 2)
(42, '3 Series', 2, 'Sedan', 1975, NULL, 1),
(43, '5 Series', 2, 'Sedan', 1972, NULL, 1),
(44, '7 Series', 2, 'Sedan', 1977, NULL, 1),
(45, 'X3', 2, 'SUV', 2003, NULL, 1),
(46, 'X5', 2, 'SUV', 1999, NULL, 1),
(47, 'X7', 2, 'SUV', 2018, NULL, 1),
(48, '4 Series', 2, 'Coupe', 2013, NULL, 1),
(49, 'M3', 2, 'Sedan', 1985, NULL, 1),
(50, 'M5', 2, 'Sedan', 1984, NULL, 1),
(51, 'X1', 2, 'SUV', 2009, NULL, 1),

-- Mercedes-Benz Models (Brand ID: 3)
(52, 'C-Class', 3, 'Sedan', 1993, NULL, 1),
(53, 'E-Class', 3, 'Sedan', 1993, NULL, 1),
(54, 'S-Class', 3, 'Sedan', 1972, NULL, 1),
(55, 'GLE', 3, 'SUV', 2015, NULL, 1),
(56, 'GLC', 3, 'SUV', 2015, NULL, 1),
(57, 'G-Class', 3, 'SUV', 1979, NULL, 1),
(58, 'A-Class', 3, 'Hatchback', 1997, NULL, 1),
(59, 'CLA', 3, 'Sedan', 2013, NULL, 1),
(60, 'GLS', 3, 'SUV', 2015, NULL, 1),
(61, 'AMG GT', 3, 'Coupe', 2014, NULL, 1),

-- Audi Models (Brand ID: 1)
(62, 'A3', 1, 'Sedan', 1996, NULL, 1),
(63, 'A4', 1, 'Sedan', 1994, NULL, 1),
(64, 'A6', 1, 'Sedan', 1994, NULL, 1),
(65, 'A8', 1, 'Sedan', 1994, NULL, 1),
(66, 'Q3', 1, 'SUV', 2011, NULL, 1),
(67, 'Q5', 1, 'SUV', 2008, NULL, 1),
(68, 'Q7', 1, 'SUV', 2005, NULL, 1),
(69, 'Q8', 1, 'SUV', 2018, NULL, 1),
(70, 'TT', 1, 'Coupe', 1998, NULL, 1),
(71, 'R8', 1, 'Coupe', 2006, NULL, 1),

-- Tesla Models (Brand ID: 19)
(72, 'Model S', 19, 'Sedan', 2012, NULL, 1),
(73, 'Model 3', 19, 'Sedan', 2017, NULL, 1),
(74, 'Model X', 19, 'SUV', 2015, NULL, 1),
(75, 'Model Y', 19, 'SUV', 2020, NULL, 1),
(76, 'Cybertruck', 19, 'Truck', 2024, NULL, 1),
(77, 'Roadster', 19, 'Coupe', 2008, 2012, 1),

-- Nissan Models (Brand ID: 22)
(78, 'Altima', 22, 'Sedan', 1992, NULL, 1),
(79, 'Sentra', 22, 'Sedan', 1982, NULL, 1),
(80, 'Rogue', 22, 'SUV', 2007, NULL, 1),
(81, 'Murano', 22, 'SUV', 2002, NULL, 1),
(82, 'Pathfinder', 22, 'SUV', 1985, NULL, 1),
(83, 'Armada', 22, 'SUV', 2003, NULL, 1),
(84, 'Frontier', 22, 'Truck', 1997, NULL, 1),
(85, 'Titan', 22, 'Truck', 2003, NULL, 1),
(86, '370Z', 22, 'Coupe', 2008, NULL, 1),
(87, 'GT-R', 22, 'Coupe', 2007, NULL, 1),

-- Hyundai Models (Brand ID: 30)
(88, 'Elantra', 30, 'Sedan', 1990, NULL, 1),
(89, 'Sonata', 30, 'Sedan', 1985, NULL, 1),
(90, 'Tucson', 30, 'SUV', 2004, NULL, 1),
(91, 'Santa Fe', 30, 'SUV', 2000, NULL, 1),
(92, 'Palisade', 30, 'SUV', 2018, NULL, 1),
(93, 'Accent', 30, 'Sedan', 1994, NULL, 1),
(94, 'Veloster', 30, 'Hatchback', 2011, NULL, 1),
(95, 'Ioniq', 30, 'Hybrid', 2016, NULL, 1),

-- Kia Models (Brand ID: 31)
(96, 'Forte', 31, 'Sedan', 2008, NULL, 1),
(97, 'Optima', 31, 'Sedan', 2000, 2020, 1),
(98, 'K5', 31, 'Sedan', 2020, NULL, 1),
(99, 'Sorento', 31, 'SUV', 2002, NULL, 1),
(100, 'Sportage', 31, 'SUV', 1993, NULL, 1),
(101, 'Telluride', 31, 'SUV', 2019, NULL, 1),
(102, 'Soul', 31, 'Hatchback', 2008, NULL, 1),
(103, 'Stinger', 31, 'Sedan', 2017, NULL, 1),

-- Mazda Models (Brand ID: 23)
(104, 'Mazda3', 23, 'Sedan', 2003, NULL, 1),
(105, 'Mazda6', 23, 'Sedan', 2002, NULL, 1),
(106, 'CX-3', 23, 'SUV', 2015, NULL, 1),
(107, 'CX-5', 23, 'SUV', 2012, NULL, 1),
(108, 'CX-9', 23, 'SUV', 2006, NULL, 1),
(109, 'MX-5 Miata', 23, 'Convertible', 1989, NULL, 1),
(110, 'CX-30', 23, 'SUV', 2019, NULL, 1),

-- Subaru Models (Brand ID: 24)
(111, 'Outback', 24, 'SUV', 1994, NULL, 1),
(112, 'Forester', 24, 'SUV', 1997, NULL, 1),
(113, 'Impreza', 24, 'Sedan', 1992, NULL, 1),
(114, 'Legacy', 24, 'Sedan', 1989, NULL, 1),
(115, 'Ascent', 24, 'SUV', 2018, NULL, 1),
(116, 'Crosstrek', 24, 'SUV', 2012, NULL, 1),
(117, 'WRX', 24, 'Sedan', 2001, NULL, 1),
(118, 'BRZ', 24, 'Coupe', 2012, NULL, 1),

-- Volkswagen Models (Brand ID: 5)
(119, 'Jetta', 5, 'Sedan', 1979, NULL, 1),
(120, 'Passat', 5, 'Sedan', 1973, NULL, 1),
(121, 'Golf', 5, 'Hatchback', 1974, NULL, 1),
(122, 'Tiguan', 5, 'SUV', 2007, NULL, 1),
(123, 'Atlas', 5, 'SUV', 2017, NULL, 1),
(124, 'Arteon', 5, 'Sedan', 2017, NULL, 1),
(125, 'Beetle', 5, 'Hatchback', 1938, 2019, 1),
(126, 'ID.4', 5, 'SUV', 2020, NULL, 1),

-- Lexus Models (Brand ID: 27)
(127, 'ES', 27, 'Sedan', 1989, NULL, 1),
(128, 'IS', 27, 'Sedan', 1999, NULL, 1),
(129, 'GS', 27, 'Sedan', 1991, 2020, 1),
(130, 'LS', 27, 'Sedan', 1989, NULL, 1),
(131, 'RX', 27, 'SUV', 1997, NULL, 1),
(132, 'GX', 27, 'SUV', 2002, NULL, 1),
(133, 'LX', 27, 'SUV', 1995, NULL, 1),
(134, 'NX', 27, 'SUV', 2014, NULL, 1),
(135, 'UX', 27, 'SUV', 2018, NULL, 1),

-- Jeep Models (Brand ID: 16)
(136, 'Wrangler', 16, 'SUV', 1986, NULL, 1),
(137, 'Grand Cherokee', 16, 'SUV', 1992, NULL, 1),
(138, 'Cherokee', 16, 'SUV', 1974, NULL, 1),
(139, 'Compass', 16, 'SUV', 2006, NULL, 1),
(140, 'Renegade', 16, 'SUV', 2014, NULL, 1),
(141, 'Gladiator', 16, 'Truck', 2019, NULL, 1),
(142, 'Grand Wagoneer', 16, 'SUV', 2021, NULL, 1),

-- Porsche Models (Brand ID: 4)
(143, '911', 4, 'Coupe', 1963, NULL, 1),
(144, 'Cayenne', 4, 'SUV', 2002, NULL, 1),
(145, 'Macan', 4, 'SUV', 2014, NULL, 1),
(146, 'Panamera', 4, 'Sedan', 2009, NULL, 1),
(147, '718 Boxster', 4, 'Convertible', 1996, NULL, 1),
(148, '718 Cayman', 4, 'Coupe', 2005, NULL, 1),
(149, 'Taycan', 4, 'Sedan', 2019, NULL, 1);

SET IDENTITY_INSERT CarModels OFF;

PRINT 'Car Brands and Models tables created and populated successfully!';
PRINT 'Total Brands: 89';
PRINT 'Total Models: 149';