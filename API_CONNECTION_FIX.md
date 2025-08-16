# Fix API Connection Issue

## Problem
Error: "Nie można nawiązać połączenia, ponieważ komputer docelowy aktywnie go odmawia. (localhost:5004)"

## Root Cause
The Web application is trying to connect to API at `localhost:5004`, but when running through Aspire AppHost, the API runs on a different dynamic port.

## Solution: Run Projects Separately

### Step 1: Run API Server
Open Terminal 1 and run:
```bash
cd src/CarSelling.Api
dotnet run
```

**Expected output:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5004
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
=== STARTING DATABASE INITIALIZATION ===
...
=== DATABASE VERIFICATION ===
Brands: 89
Models: 389
```

### Step 2: Run Web Application
Open Terminal 2 and run:
```bash
cd src/CarSelling.Web
dotnet run
```

**Expected output:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5209
Configured Car Listing API base URL: http://localhost:5004/
Configured Car Brand API base URL: http://localhost:5004/
Configured Car Model API base URL: http://localhost:5004/
```

### Step 3: Test
1. Open browser to `http://localhost:5209`
2. Select a car brand in the search filters
3. Verify that car models load in the model dropdown

## Verification Commands

### Test API directly:
```bash
# Test brands endpoint
curl http://localhost:5004/api/carbrand

# Test models for Toyota
curl http://localhost:5004/api/carmodel/names-by-brand/Toyota
```

### Expected Results:
- Brands endpoint: Should return 89+ brands
- Toyota models: Should return models like ["Camry", "Corolla", "Prius", "RAV4", ...]

## Alternative: Use AppHost (Advanced)
If you prefer to use AppHost, you'll need to:
1. Add Aspire packages to the Web project
2. Configure proper service discovery
3. Update the AppHost configuration

For now, the separate terminal approach is simpler and more reliable.