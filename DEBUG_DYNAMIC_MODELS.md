# Debug Dynamic Model Loading

## Issue
Car models don't load when selecting a brand in the Home page search filters.

## Root Cause Analysis
1. **API Connection**: Fixed - no longer getting connection refused errors
2. **UI Binding**: Fixed - changed from `value` + `@onchange` to `@bind` + `@bind:after`
3. **Method Signature**: Fixed - updated to work with `@bind:after` pattern

## Step-by-Step Testing

### 1. Start the Servers
```bash
# Option A: Use the provided script
./start-servers.sh

# Option B: Manual start (2 terminals)
# Terminal 1:
cd src/CarSelling.Api
dotnet run

# Terminal 2:
cd src/CarSelling.Web
dotnet run
```

### 2. Verify API is Working
```bash
# Test brands endpoint (should return 89+ brands)
curl http://localhost:5004/api/carbrand | wc -l

# Test models for Toyota (should return 10+ models)
curl "http://localhost:5004/api/carmodel/names-by-brand/Toyota"

# Expected models: ["Camry","Corolla","Prius","RAV4","Highlander","4Runner","Tacoma","Tundra","Avalon","Yaris","Venza","Sienna","Sequoia","Land Cruiser","GR86","Supra","GR Corolla"]
```

### 3. Test the UI
1. Open browser: `http://localhost:5209`
2. Go to the search filters section
3. **Check browser console** for debug messages:
   ```
   DEBUG: Loaded 89 car brands
   DEBUG: First few brands: Audi, BMW, Mercedes-Benz, Toyota, Honda
   ```

### 4. Test Brand Selection
1. **Select "Toyota"** from the brand dropdown
2. **Watch browser console** for:
   ```
   DEBUG: Brand changed to: 'Toyota'
   DEBUG: Loading models for brand: Toyota
   DEBUG: Loaded 17 models for Toyota
   ```
3. **Check model dropdown** - should show Toyota models

### 5. Debugging Steps if Still Not Working

#### A. Check Console Logs
Open browser developer tools (F12) → Console tab, look for:
- Brand loading errors
- Model loading errors
- API call failures

#### B. Check Network Tab
1. F12 → Network tab
2. Select a brand
3. Look for API call to: `api/carmodel/names-by-brand/Toyota`
4. Check response status and data

#### C. Manual API Testing
```bash
# Test specific brands
curl "http://localhost:5004/api/carmodel/names-by-brand/BMW"
curl "http://localhost:5004/api/carmodel/names-by-brand/Honda"
curl "http://localhost:5004/api/carmodel/names-by-brand/Mercedes-Benz"
```

## Expected Behavior
- **Brand dropdown**: Shows 89+ brands
- **Model dropdown**: Initially shows "Select brand first"
- **After brand selection**: Model dropdown shows brand-specific models
- **Console logs**: Shows debug information for each step

## Common Issues & Solutions

### Issue: No brands showing
- **Check**: API server is running on port 5004
- **Solution**: Start API server

### Issue: Brands load but models don't
- **Check**: Browser console for JavaScript errors
- **Check**: Network tab for failed API calls
- **Solution**: Verify model API endpoint works

### Issue: Models show "Loading..." forever
- **Check**: CORS errors in browser console
- **Check**: API response format
- **Solution**: Restart both servers

## Files Changed
- `Home.razor`: Fixed binding conflict with `@bind` + `@bind:after`
- `OnBrandChangedAfter()`: Updated method signature
- Added comprehensive debug logging