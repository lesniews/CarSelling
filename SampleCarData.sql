-- Sample Car Data for CarSelling Database
-- This script inserts 15 comprehensive car listings with all model fields populated

-- Clear existing data (optional - uncomment if needed)
-- DELETE FROM CarListings;

-- Insert 15 sample car listings
INSERT INTO CarListings (
    Title, Make, Model, Year, Price, Mileage,
    ModelGeneration, BodyType, FuelType, Transmission,
    EngineSize, Horsepower, Drivetrain, FuelEconomyCity, FuelEconomyHighway,
    Condition, DamageStatus, CarStatus,
    FinancingOptions, TradeInAccepted, NegotiablePrice,
    Equipment,
    ExteriorColor, InteriorColor, InteriorMaterial,
    PreviousOwners, AccidentHistory, ServiceHistoryAvailable, VIN,
    SellerType, SellerRating,
    Images, VideoUrl, Has360View,
    Description, ContactEmail, ContactPhone,
    Location, City, State, ZipCode,
    AvailableDate, TestDriveAvailable, ViewingAppointmentRequired,
    IsActive, IsFeatured, UserId,
    ViewCount, FavoriteCount
) VALUES
-- Car 1: Toyota Camry
(
    '2022 Toyota Camry LE - Excellent Condition',
    'Toyota', 'Camry', 2022, 28500.00, 15000,
    'Gen 8 (XV70)', 'Sedan', 'Gasoline', 'Automatic',
    '2.5L 4-Cylinder', 203, 'FWD', 28, 39,
    'Excellent', 'No Damage', 'Clean Title',
    'Financing Available', 1, 1,
    'Air Conditioning;Bluetooth;Backup Camera;Cruise Control;Power Seats',
    'Silver Metallic', 'Black', 'Cloth',
    1, 0, 1, '4T1G11AK8NU123456',
    'Private Seller', '4.8',
    'https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=800;https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=800', '', 0,
    'Well-maintained 2022 Toyota Camry with low mileage. Single owner, garage kept, all maintenance records available. Perfect family sedan with excellent fuel economy.',
    'john.smith@email.com', '+1-555-0101',
    'San Francisco, CA', 'San Francisco', 'CA', '94102',
    GETUTCDATE(), 1, 0,
    1, 0, 'user1',
    245, 12
),

-- Car 2: Honda Accord Sport
(
    '2020 Honda Accord Sport - Manual Transmission',
    'Honda', 'Accord', 2020, 26900.00, 32000,
    '10th Generation', 'Sedan', 'Gasoline', 'Manual',
    '1.5L Turbo 4-Cylinder', 192, 'FWD', 26, 35,
    'Very Good', 'Minor Damage', 'Clean Title',
    'Cash Only', 0, 1,
    'Air Conditioning;Bluetooth;Navigation;Sport Package;Premium Audio',
    'Modern Steel Metallic', 'Black', 'Cloth',
    2, 1, 1, '1HGCV1F30LA123456',
    'Professional Dealer', '4.6',
    'https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800;https://images.unsplash.com/photo-1619767886558-efdc259cde1a?w=800', 'https://youtube.com/watch?v=sample1', 1,
    'Sporty Honda Accord with rare manual transmission. Well maintained with minor cosmetic damage on rear bumper. Great for driving enthusiasts.',
    'dealer@acmeauto.com', '+1-555-0102',
    'Los Angeles, CA', 'Los Angeles', 'CA', '90210',
    GETUTCDATE(), 1, 1,
    1, 1, 'dealer1',
    156, 8
),

-- Car 3: Tesla Model 3
(
    '2023 Tesla Model 3 Standard Range Plus',
    'Tesla', 'Model 3', 2023, 42000.00, 8000,
    'Highland Refresh', 'Sedan', 'Electric', 'Automatic',
    'Electric Motor', 272, 'RWD', 136, 123,
    'Excellent', 'No Damage', 'Clean Title',
    'Tesla Financing Available', 1, 0,
    'Autopilot;Navigation;Premium Audio;Supercharging;Mobile Connector',
    'Pearl White Multi-Coat', 'Black', 'Premium Interior',
    1, 0, 1, '5YJ3E1EA5PF123456',
    'Private Seller', '5.0',
    'https://images.unsplash.com/photo-1617788138017-80ad40651399?w=800;https://images.unsplash.com/photo-1617788138017-80ad40651399?w=800', '', 1,
    'Like-new Tesla Model 3 with latest software updates. Includes Enhanced Autopilot and free Supercharging. Perfect electric vehicle for daily commuting.',
    'sarah.wilson@email.com', '+1-555-0103',
    'Seattle, WA', 'Seattle', 'WA', '98101',
    GETUTCDATE(), 1, 0,
    1, 1, 'user2',
    398, 25
),

-- Car 4: BMW 3 Series
(
    '2021 BMW 330i xDrive - Luxury Package',
    'BMW', '3 Series', 2021, 35900.00, 24000,
    'G20', 'Sedan', 'Gasoline', 'Automatic',
    '2.0L Turbo 4-Cylinder', 255, 'AWD', 24, 34,
    'Very Good', 'No Damage', 'Clean Title',
    'BMW Financial Services', 1, 1,
    'Air Conditioning;Leather Seats;Navigation;Premium Package;Sunroof;Driver Assistance',
    'Alpine White', 'Black', 'Leather',
    1, 0, 1, 'WBA5R1C50MA123456',
    'Professional Dealer', '4.7',
    'https://images.unsplash.com/photo-1555215695-3004980ad54e?w=800;https://images.unsplash.com/photo-1555215695-3004980ad54e?w=800', '', 0,
    'Premium BMW 3 Series with xDrive all-wheel drive. Loaded with luxury features including heated seats, premium sound system, and advanced driver assistance.',
    'bmw.dealer@luxury.com', '+1-555-0104',
    'Austin, TX', 'Austin', 'TX', '78701',
    GETUTCDATE(), 1, 1,
    1, 1, 'dealer2',
    189, 15
),

-- Car 5: Mercedes-Benz C-Class
(
    '2019 Mercedes-Benz C300 4MATIC',
    'Mercedes', 'C-Class', 2019, 31500.00, 45000,
    'W205', 'Sedan', 'Gasoline', 'Automatic',
    '2.0L Turbo 4-Cylinder', 241, 'AWD', 22, 31,
    'Good', 'No Damage', 'Clean Title',
    'Mercedes-Benz Financial', 1, 1,
    'Air Conditioning;Leather Seats;Navigation;Premium Audio;Panoramic Roof',
    'Obsidian Black Metallic', 'Black', 'Leather',
    2, 0, 1, 'WDDWF4HB0KR123456',
    'Private Seller', '4.5',
    'https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=800;https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=800', '', 0,
    'Elegant Mercedes-Benz C300 with 4MATIC all-wheel drive. Well-maintained with complete service history. Perfect luxury sedan for daily driving.',
    'mercedes.owner@email.com', '+1-555-0105',
    'Miami, FL', 'Miami', 'FL', '33101',
    GETUTCDATE(), 1, 0,
    1, 0, 'user3',
    134, 7
),

-- Car 6: Audi A4 Premium
(
    '2020 Audi A4 Premium Plus Quattro',
    'Audi', 'A4', 2020, 33800.00, 28000,
    'B9', 'Sedan', 'Gasoline', 'Automatic',
    '2.0L TFSI Turbo', 248, 'AWD', 24, 31,
    'Excellent', 'No Damage', 'Clean Title',
    'Audi Financial Services', 1, 0,
    'Air Conditioning;Leather Seats;MMI Navigation;Virtual Cockpit;Premium Package',
    'Glacier White Metallic', 'Black', 'Leather',
    1, 0, 1, 'WAUENAF40LN123456',
    'Professional Dealer', '4.8',
    'https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800;https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800', 'https://youtube.com/watch?v=sample2', 1,
    'Premium Audi A4 with Quattro all-wheel drive and Virtual Cockpit. Excellent condition with advanced technology features and superior build quality.',
    'audi.sales@premium.com', '+1-555-0106',
    'Denver, CO', 'Denver', 'CO', '80202',
    GETUTCDATE(), 1, 1,
    1, 1, 'dealer3',
    276, 18
),

-- Car 7: Ford F-150
(
    '2021 Ford F-150 XLT SuperCrew 4WD',
    'Ford', 'F-150', 2021, 41200.00, 35000,
    '14th Generation', 'Truck', 'Gasoline', 'Automatic',
    '3.5L EcoBoost V6', 400, '4WD', 20, 24,
    'Very Good', 'Minor Damage', 'Clean Title',
    'Ford Credit Available', 1, 1,
    'Air Conditioning;Bluetooth;Backup Camera;Towing Package;Bed Liner;Running Boards',
    'Oxford White', 'Medium Earth Gray', 'Cloth',
    1, 1, 1, '1FTFW1E50MFA12345',
    'Private Seller', '4.6',
    'https://images.unsplash.com/photo-1558618047-3c8c76ca7d13?w=800;https://images.unsplash.com/photo-1558618047-3c8c76ca7d13?w=800', '', 0,
    'Powerful Ford F-150 with EcoBoost engine and 4WD capability. Great for work and recreation. Minor scratches on bed liner, otherwise excellent condition.',
    'truck.owner@email.com', '+1-555-0107',
    'Houston, TX', 'Houston', 'TX', '77002',
    GETUTCDATE(), 1, 0,
    1, 0, 'user4',
    198, 11
),

-- Car 8: Chevrolet Tahoe
(
    '2020 Chevrolet Tahoe LT 4WD',
    'Chevrolet', 'Tahoe', 2020, 47500.00, 38000,
    '4th Generation', 'SUV', 'Gasoline', 'Automatic',
    '5.3L V8', 355, '4WD', 16, 20,
    'Good', 'No Damage', 'Clean Title',
    'GM Financial Available', 1, 1,
    'Air Conditioning;Leather Seats;Navigation;Backup Camera;Towing Package;Premium Audio',
    'Summit White', 'Jet Black', 'Leather',
    2, 0, 1, '1GNSKCKC8LR123456',
    'Professional Dealer', '4.4',
    'https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800;https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800', '', 0,
    'Spacious Chevrolet Tahoe perfect for large families. Features third-row seating, powerful V8 engine, and excellent towing capacity.',
    'chevy.dealer@auto.com', '+1-555-0108',
    'Phoenix, AZ', 'Phoenix', 'AZ', '85001',
    GETUTCDATE(), 1, 1,
    1, 0, 'dealer4',
    167, 9
),

-- Car 9: Subaru Outback
(
    '2022 Subaru Outback Touring XT',
    'Subaru', 'Outback', 2022, 36200.00, 18000,
    '6th Generation', 'Wagon', 'Gasoline', 'CVT',
    '2.4L Turbo 4-Cylinder', 260, 'AWD', 23, 30,
    'Excellent', 'No Damage', 'Clean Title',
    'Subaru Motor Finance', 1, 0,
    'Air Conditioning;Leather Seats;Navigation;Backup Camera;Panoramic Roof;Driver Assistance',
    'Crystal White Pearl', 'Java Brown', 'Leather',
    1, 0, 1, '4S4BTANC1N3123456',
    'Private Seller', '4.9',
    'https://images.unsplash.com/photo-1544880503-2f0f3b4d1e2c?w=800;https://images.unsplash.com/photo-1544880503-2f0f3b4d1e2c?w=800', '', 1,
    'Adventure-ready Subaru Outback with turbo engine and standard AWD. Perfect for outdoor enthusiasts with excellent ground clearance and cargo space.',
    'outdoor.lover@email.com', '+1-555-0109',
    'Portland, OR', 'Portland', 'OR', '97201',
    GETUTCDATE(), 1, 0,
    1, 1, 'user5',
    223, 14
),

-- Car 10: Mazda CX-5
(
    '2021 Mazda CX-5 Grand Touring Reserve',
    'Mazda', 'CX-5', 2021, 29800.00, 22000,
    '2nd Generation', 'SUV', 'Gasoline', 'Automatic',
    '2.5L Turbo 4-Cylinder', 250, 'AWD', 22, 27,
    'Very Good', 'No Damage', 'Clean Title',
    'Mazda Capital Services', 1, 1,
    'Air Conditioning;Leather Seats;Navigation;Backup Camera;Premium Audio;Sunroof',
    'Deep Crystal Blue Mica', 'Parchment', 'Leather',
    1, 0, 1, 'JM3KFBDM9M0123456',
    'Professional Dealer', '4.7',
    'https://images.unsplash.com/photo-1549317661-bd32c8ce0db2?w=800;https://images.unsplash.com/photo-1549317661-bd32c8ce0db2?w=800', 'https://youtube.com/watch?v=sample3', 0,
    'Premium Mazda CX-5 with turbo engine and luxurious interior. Excellent build quality with advanced safety features and refined driving experience.',
    'mazda.sales@dealer.com', '+1-555-0110',
    'Atlanta, GA', 'Atlanta', 'GA', '30301',
    GETUTCDATE(), 1, 1,
    1, 1, 'dealer5',
    145, 6
),

-- Car 11: Jeep Wrangler
(
    '2022 Jeep Wrangler Unlimited Sahara 4x4',
    'Jeep', 'Wrangler', 2022, 38900.00, 12000,
    'JL', 'SUV', 'Gasoline', 'Manual',
    '3.6L V6', 285, '4WD', 20, 24,
    'Excellent', 'No Damage', 'Clean Title',
    'Chrysler Capital', 1, 1,
    'Air Conditioning;Bluetooth;Navigation;Backup Camera;Premium Audio;Running Boards',
    'Bright White', 'Black', 'Cloth',
    1, 0, 1, '1C4HJXDG8NW123456',
    'Private Seller', '4.8',
    'https://images.unsplash.com/photo-1606220838315-056192d5e927?w=800;https://images.unsplash.com/photo-1606220838315-056192d5e927?w=800', '', 0,
    'Iconic Jeep Wrangler with removable doors and roof. Perfect for off-road adventures with manual transmission and excellent 4x4 capability.',
    'jeep.enthusiast@email.com', '+1-555-0111',
    'Salt Lake City, UT', 'Salt Lake City', 'UT', '84101',
    GETUTCDATE(), 1, 0,
    1, 1, 'user6',
    312, 22
),

-- Car 12: Hyundai Elantra
(
    '2023 Hyundai Elantra SEL',
    'Hyundai', 'Elantra', 2023, 23400.00, 8500,
    '7th Generation', 'Sedan', 'Gasoline', 'CVT',
    '2.0L 4-Cylinder', 147, 'FWD', 31, 41,
    'Excellent', 'No Damage', 'Clean Title',
    'Hyundai Motor Finance', 1, 1,
    'Air Conditioning;Bluetooth;Backup Camera;Cruise Control;Power Seats',
    'Calypso Red', 'Black', 'Cloth',
    1, 0, 1, 'KMHL14JA5PA123456',
    'Professional Dealer', '4.5',
    'https://images.unsplash.com/photo-1617531653332-bd46c24f2068?w=800;https://images.unsplash.com/photo-1617531653332-bd46c24f2068?w=800', '', 0,
    'Brand new Hyundai Elantra with excellent fuel economy and modern features. Perfect first car or daily commuter with comprehensive warranty coverage.',
    'hyundai.dealer@auto.com', '+1-555-0112',
    'Las Vegas, NV', 'Las Vegas', 'NV', '89101',
    GETUTCDATE(), 1, 1,
    1, 0, 'dealer6',
    89, 3
),

-- Car 13: Volkswagen Golf GTI
(
    '2021 Volkswagen Golf GTI S',
    'Volkswagen', 'Golf', 2021, 28900.00, 19000,
    'Mk8', 'Hatchback', 'Gasoline', 'Manual',
    '2.0L Turbo 4-Cylinder', 241, 'FWD', 24, 32,
    'Very Good', 'No Damage', 'Clean Title',
    'VW Credit Available', 0, 1,
    'Air Conditioning;Bluetooth;Navigation;Sport Package;Premium Audio',
    'Pure White', 'Black', 'Cloth',
    2, 0, 1, '3VW5T7AU6MM123456',
    'Private Seller', '4.6',
    'https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=800;https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=800', '', 0,
    'Fun-to-drive Volkswagen Golf GTI with manual transmission. Perfect hot hatch with excellent handling and practical everyday usability.',
    'vw.owner@email.com', '+1-555-0113',
    'Chicago, IL', 'Chicago', 'IL', '60601',
    GETUTCDATE(), 1, 0,
    1, 0, 'user7',
    178, 10
),

-- Car 14: Lexus RX 350
(
    '2020 Lexus RX 350 F Sport',
    'Lexus', 'RX', 2020, 44200.00, 31000,
    '4th Generation', 'SUV', 'Gasoline', 'Automatic',
    '3.5L V6', 295, 'AWD', 20, 27,
    'Very Good', 'No Damage', 'Clean Title',
    'Lexus Financial Services', 1, 0,
    'Air Conditioning;Leather Seats;Navigation;Backup Camera;Premium Audio;Panoramic Roof',
    'Atomic Silver', 'Black', 'Leather',
    1, 0, 1, '2T2BZMCA6LC123456',
    'Professional Dealer', '4.9',
    'https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800;https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=800', 'https://youtube.com/watch?v=sample4', 1,
    'Luxury Lexus RX 350 with F Sport package. Exceptional reliability and comfort with premium features and smooth V6 engine performance.',
    'lexus.sales@luxury.com', '+1-555-0114',
    'San Diego, CA', 'San Diego', 'CA', '92101',
    GETUTCDATE(), 1, 1,
    1, 1, 'dealer7',
    234, 16
),

-- Car 15: Porsche 911
(
    '2019 Porsche 911 Carrera S',
    'Porsche', '911', 2019, 89500.00, 15000,
    '992', 'Coupe', 'Gasoline', 'Semi-Automatic',
    '3.0L Twin-Turbo Flat-6', 443, 'RWD', 18, 24,
    'Excellent', 'No Damage', 'Clean Title',
    'Porsche Financial Services', 0, 1,
    'Air Conditioning;Leather Seats;Navigation;Premium Audio;Sport Package;Premium Package',
    'Guards Red', 'Black', 'Leather',
    2, 0, 1, 'WP0AB2A91KS123456',
    'Private Seller', '5.0',
    'https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800;https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=800', 'https://youtube.com/watch?v=sample5', 1,
    'Iconic Porsche 911 Carrera S in classic Guards Red. Meticulously maintained with complete service history. A true drivers car with timeless design.',
    'porsche.collector@email.com', '+1-555-0115',
    'Beverly Hills, CA', 'Beverly Hills', 'CA', '90210',
    GETUTCDATE(), 1, 1,
    1, 1, 'user8',
    567, 45
);

-- Verify the data was inserted
SELECT COUNT(*) as 'Total Cars Inserted' FROM CarListings;
SELECT Make, Model, Year, Price, Condition FROM CarListings ORDER BY Price DESC;