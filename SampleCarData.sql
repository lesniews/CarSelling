-- Sample Car Data for CarSelling Database
-- This script inserts sample users and 15 car listings with all required fields
-- Based on actual database schema and service implementation
-- Includes proper user references and all necessary fields

-- Clear existing data (optional - uncomment if needed)
-- DELETE FROM CarListings;
-- DELETE FROM Users;

-- First, insert sample users that will own the car listings
INSERT INTO Users (
    Id, Name, Email, Phone,
    PreferredLocation, UserType, CompanyName, LicenseNumber,
    TotalListings, SoldCars, AverageRating, ReviewCount
) VALUES
-- Individual Users
('user1', 'John Smith', 'john.smith@email.com', '+1-555-0101', 'San Francisco, CA', 'Individual', '', '', 0, 0, 0.0, 0),
('user2', 'Sarah Wilson', 'sarah.wilson@email.com', '+1-555-0103', 'Seattle, WA', 'Individual', '', '', 0, 0, 0.0, 0),
('user3', 'Mercedes Owner', 'mercedes.owner@email.com', '+1-555-0105', 'Miami, FL', 'Individual', '', '', 0, 0, 0.0, 0),
('user4', 'Truck Owner', 'truck.owner@email.com', '+1-555-0107', 'Houston, TX', 'Individual', '', '', 0, 0, 0.0, 0),
('user5', 'Outdoor Lover', 'outdoor.lover@email.com', '+1-555-0109', 'Portland, OR', 'Individual', '', '', 0, 0, 0.0, 0),
('user6', 'Jeep Enthusiast', 'jeep.enthusiast@email.com', '+1-555-0111', 'Salt Lake City, UT', 'Individual', '', '', 0, 0, 0.0, 0),
('user7', 'VW Owner', 'vw.owner@email.com', '+1-555-0113', 'Chicago, IL', 'Individual', '', '', 0, 0, 0.0, 0),
('user8', 'Porsche Collector', 'porsche.collector@email.com', '+1-555-0115', 'Beverly Hills, CA', 'Individual', '', '', 0, 0, 0.0, 0),

-- Dealer Users
('dealer1', 'Acme Auto Sales', 'dealer@acmeauto.com', '+1-555-0102', 'Los Angeles, CA', 'Dealer', 'Acme Auto Sales', 'DL12345', 0, 0, 4.6, 0),
('dealer2', 'Luxury BMW Dealer', 'bmw.dealer@luxury.com', '+1-555-0104', 'Austin, TX', 'Dealer', 'Luxury Motors BMW', 'DL23456', 0, 0, 4.7, 0),
('dealer3', 'Premium Audi', 'audi.sales@premium.com', '+1-555-0106', 'Denver, CO', 'Dealer', 'Premium Audi Denver', 'DL34567', 0, 0, 4.8, 0),
('dealer4', 'Chevy Auto', 'chevy.dealer@auto.com', '+1-555-0108', 'Phoenix, AZ', 'Dealer', 'Phoenix Chevrolet', 'DL45678', 0, 0, 4.4, 0),
('dealer5', 'Mazda Sales', 'mazda.sales@dealer.com', '+1-555-0110', 'Atlanta, GA', 'Dealer', 'Atlanta Mazda', 'DL56789', 0, 0, 4.7, 0),
('dealer6', 'Hyundai Auto', 'hyundai.dealer@auto.com', '+1-555-0112', 'Las Vegas, NV', 'Dealer', 'Vegas Hyundai', 'DL67890', 0, 0, 4.5, 0),
('dealer7', 'Lexus Sales', 'lexus.sales@luxury.com', '+1-555-0114', 'San Diego, CA', 'Dealer', 'San Diego Lexus', 'DL78901', 0, 0, 4.9, 0);

-- Now insert 15 sample car listings
INSERT INTO CarListings (
    Title, Make, Model, Year, Price, Mileage,
    FuelType, Transmission, Description,
    Images, ContactEmail, ContactPhone, Location,
    CreatedAt, UpdatedAt, IsActive, UserId
) VALUES
-- Car 1: Toyota Camry
(
    '2022 Toyota Camry LE - Excellent Condition',
    'Toyota', 'Camry', 2022, 28500.00, 15000,
    'Gasoline', 'Automatic',
    'Well-maintained 2022 Toyota Camry with low mileage. Single owner, garage kept, all maintenance records available. Perfect family sedan with excellent fuel economy.',
    'https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=800',
    'john.smith@email.com', '+1-555-0101', 'San Francisco, CA',
    GETUTCDATE(), GETUTCDATE(), 1, 'user1'
),

-- Car 2: Honda Accord Sport
(
    '2020 Honda Accord Sport - Manual Transmission',
    'Honda', 'Accord', 2020, 26900.00, 32000,
    'Gasoline', 'Manual',
    'Sporty Honda Accord with rare manual transmission. Well maintained with minor cosmetic damage on rear bumper. Great for driving enthusiasts.',
    'https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800;https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800',
    'dealer@acmeauto.com', '+1-555-0102', 'Los Angeles, CA',
    GETUTCDATE(), GETUTCDATE(), 1, 'dealer1'
),

-- Car 3: Tesla Model 3
(
    '2023 Tesla Model 3 Standard Range Plus',
    'Tesla', 'Model 3', 2023, 42000.00, 8000,
    'Electric', 'Automatic',
    'Like-new Tesla Model 3 with latest software updates. Includes Enhanced Autopilot and free Supercharging. Perfect electric vehicle for daily commuting.',
    'https://images.unsplash.com/photo-1617788138017-80ad40651399?w=800;https://images.unsplash.com/photo-1617788138017-80ad40651399?w=800',
    'sarah.wilson@email.com', '+1-555-0103', 'Seattle, WA',
    GETUTCDATE(), GETUTCDATE(), 1, 'user2'
),

-- Car 4: BMW 3 Series
(
    '2021 BMW 330i xDrive - Luxury Package',
    'BMW', '3 Series', 2021, 35900.00, 24000,
    'Gasoline', 'Automatic',
    'Premium BMW 3 Series with xDrive all-wheel drive. Loaded with luxury features including heated seats, premium sound system, and advanced driver assistance.',
    'https://images.unsplash.com/photo-1555215695-3004980ad54e?w=800;https://images.unsplash.com/photo-1555215695-3004980ad54e?w=800',
    'bmw.dealer@luxury.com', '+1-555-0104', 'Austin, TX',
    GETUTCDATE(), GETUTCDATE(), 1, 'dealer2'
),

-- Car 5: Mercedes-Benz C-Class
(
    '2019 Mercedes-Benz C300 4MATIC',
    'Mercedes', 'C-Class', 2019, 31500.00, 45000,
    'Gasoline', 'Automatic',
    'Elegant Mercedes-Benz C300 with 4MATIC all-wheel drive. Well-maintained with complete service history. Perfect luxury sedan for daily driving.',
    'https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=800;https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=800',
    'mercedes.owner@email.com', '+1-555-0105', 'Miami, FL',
    GETUTCDATE(), GETUTCDATE(), 1, 'user3'
),

-- Car 6: Audi A4 Premium
(
    '2020 Audi A4 Premium Plus Quattro',
    'Audi', 'A4', 2020, 33800.00, 28000,
    'Gasoline', 'Automatic',
    'Premium Audi A4 with Quattro all-wheel drive and Virtual Cockpit. Excellent condition with advanced technology features and superior build quality.',
    'https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800;https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800',
    'audi.sales@premium.com', '+1-555-0106', 'Denver, CO',
    GETUTCDATE(), GETUTCDATE(), 1, 'dealer3'
),

-- Car 7: Ford F-150
(
    '2021 Ford F-150 XLT SuperCrew 4WD',
    'Ford', 'F-150', 2021, 41200.00, 35000,
    'Gasoline', 'Automatic',
    'Powerful Ford F-150 with EcoBoost engine and 4WD capability. Great for work and recreation. Minor scratches on bed liner, otherwise excellent condition.',
    'https://images.unsplash.com/photo-1558618047-3c8c76ca7d13?w=800;https://images.unsplash.com/photo-1558618047-3c8c76ca7d13?w=800',
    'truck.owner@email.com', '+1-555-0107', 'Houston, TX',
    GETUTCDATE(), GETUTCDATE(), 1, 'user4'
),

-- Car 8: Chevrolet Tahoe
(
    '2020 Chevrolet Tahoe LT 4WD',
    'Chevrolet', 'Tahoe', 2020, 47500.00, 38000,
    'Gasoline', 'Automatic',
    'Spacious Chevrolet Tahoe perfect for large families. Features third-row seating, powerful V8 engine, and excellent towing capacity.',
    'https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800;https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800',
    'chevy.dealer@auto.com', '+1-555-0108', 'Phoenix, AZ',
    GETUTCDATE(), GETUTCDATE(), 1, 'dealer4'
),

-- Car 9: Subaru Outback
(
    '2022 Subaru Outback Touring XT',
    'Subaru', 'Outback', 2022, 36200.00, 18000,
    'Gasoline', 'CVT',
    'Adventure-ready Subaru Outback with turbo engine and standard AWD. Perfect for outdoor enthusiasts with excellent ground clearance and cargo space.',
    'https://images.unsplash.com/photo-1544880503-2f0f3b4d1e2c?w=800;https://images.unsplash.com/photo-1544880503-2f0f3b4d1e2c?w=800',
    'outdoor.lover@email.com', '+1-555-0109', 'Portland, OR',
    GETUTCDATE(), GETUTCDATE(), 1, 'user5'
),

-- Car 10: Mazda CX-5
(
    '2021 Mazda CX-5 Grand Touring Reserve',
    'Mazda', 'CX-5', 2021, 29800.00, 22000,
    'Gasoline', 'Automatic',
    'Premium Mazda CX-5 with turbo engine and luxurious interior. Excellent build quality with advanced safety features and refined driving experience.',
    'https://images.unsplash.com/photo-1549317661-bd32c8ce0db2?w=800;https://images.unsplash.com/photo-1549317661-bd32c8ce0db2?w=800',
    'mazda.sales@dealer.com', '+1-555-0110', 'Atlanta, GA',
    GETUTCDATE(), GETUTCDATE(), 1, 'dealer5'
),

-- Car 11: Jeep Wrangler
(
    '2022 Jeep Wrangler Unlimited Sahara 4x4',
    'Jeep', 'Wrangler', 2022, 38900.00, 12000,
    'Gasoline', 'Manual',
    'Iconic Jeep Wrangler with removable doors and roof. Perfect for off-road adventures with manual transmission and excellent 4x4 capability.',
    'https://images.unsplash.com/photo-1606220838315-056192d5e927?w=800;https://images.unsplash.com/photo-1606220838315-056192d5e927?w=800',
    'jeep.enthusiast@email.com', '+1-555-0111', 'Salt Lake City, UT',
    GETUTCDATE(), GETUTCDATE(), 1, 'user6'
),

-- Car 12: Hyundai Elantra
(
    '2023 Hyundai Elantra SEL',
    'Hyundai', 'Elantra', 2023, 23400.00, 8500,
    'Gasoline', 'CVT',
    'Brand new Hyundai Elantra with excellent fuel economy and modern features. Perfect first car or daily commuter with comprehensive warranty coverage.',
    'https://images.unsplash.com/photo-1617531653332-bd46c24f2068?w=800;https://images.unsplash.com/photo-1617531653332-bd46c24f2068?w=800',
    'hyundai.dealer@auto.com', '+1-555-0112', 'Las Vegas, NV',
    GETUTCDATE(), GETUTCDATE(), 1, 'dealer6'
),

-- Car 13: Volkswagen Golf GTI
(
    '2021 Volkswagen Golf GTI S',
    'Volkswagen', 'Golf', 2021, 28900.00, 19000,
    'Gasoline', 'Manual',
    'Fun-to-drive Volkswagen Golf GTI with manual transmission. Perfect hot hatch with excellent handling and practical everyday usability.',
    'https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=800;https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=800',
    'vw.owner@email.com', '+1-555-0113', 'Chicago, IL',
    GETUTCDATE(), GETUTCDATE(), 1, 'user7'
),

-- Car 14: Lexus RX 350
(
    '2020 Lexus RX 350 F Sport',
    'Lexus', 'RX', 2020, 44200.00, 31000,
    'Gasoline', 'Automatic',
    'Luxury Lexus RX 350 with F Sport package. Exceptional reliability and comfort with premium features and smooth V6 engine performance.',
    'https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800;https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800',
    'lexus.sales@luxury.com', '+1-555-0114', 'San Diego, CA',
    GETUTCDATE(), GETUTCDATE(), 1, 'dealer7'
),

-- Car 15: Porsche 911
(
    '2019 Porsche 911 Carrera S',
    'Porsche', '911', 2019, 89500.00, 15000,
    'Gasoline', 'Semi-Automatic',
    'Iconic Porsche 911 Carrera S in classic Guards Red. Meticulously maintained with complete service history. A true drivers car with timeless design.',
    'https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800;https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800',
    'porsche.collector@email.com', '+1-555-0115', 'Beverly Hills, CA',
    GETUTCDATE(), GETUTCDATE(), 1, 'user8'
);

-- Verify the data was inserted
SELECT COUNT(*) as 'Total Users Inserted' FROM Users;
SELECT COUNT(*) as 'Total Cars Inserted' FROM CarListings;
SELECT c.Title, c.Make, c.Model, c.Year, c.Price, u.Name as Owner, u.UserType 
FROM CarListings c 
JOIN Users u ON c.UserId = u.Id 
ORDER BY c.Price DESC;