#!/bin/bash

echo "🧪 Testing Dynamic Model Loading"
echo "==============================="

# Check if API is running
echo "1. Checking API Server..."
if curl -s http://localhost:5004/api/carbrand > /dev/null 2>&1; then
    BRAND_COUNT=$(curl -s http://localhost:5004/api/carbrand | jq '. | length' 2>/dev/null || echo "unknown")
    echo "   ✅ API is running - Found $BRAND_COUNT brands"
else
    echo "   ❌ API is NOT running on port 5004"
    echo "   💡 Start it with: cd src/CarSelling.Api && dotnet run"
    exit 1
fi

# Check if Web app is accessible
echo "2. Checking Web Server..."
if curl -s http://localhost:5209 > /dev/null 2>&1; then
    echo "   ✅ Web server is running on port 5209"
else
    echo "   ❌ Web server is NOT running on port 5209"
    echo "   💡 Start it with: cd src/CarSelling.Web && dotnet run"
    exit 1
fi

# Test specific brand models
echo "3. Testing Brand Model APIs..."
BRANDS=("Toyota" "BMW" "Honda" "Mercedes-Benz")

for brand in "${BRANDS[@]}"; do
    MODEL_COUNT=$(curl -s "http://localhost:5004/api/carmodel/names-by-brand/$brand" | jq '. | length' 2>/dev/null || echo "0")
    if [ "$MODEL_COUNT" -gt "0" ]; then
        echo "   ✅ $brand: $MODEL_COUNT models"
    else
        echo "   ❌ $brand: No models found"
    fi
done

echo ""
echo "🎯 Manual Testing Steps:"
echo "1. Open browser: http://localhost:5209"
echo "2. Look for status messages above the dropdowns:"
echo "   - Should see: '✅ Loaded 89 brands'"
echo "3. Select a brand (e.g., Toyota)"
echo "4. Look for: '✅ Loaded X models for Toyota'"
echo "5. Check model dropdown - should show Toyota models"
echo ""
echo "🔧 Debug Console:"
echo "Open browser F12 → Console, look for:"
echo "- DEBUG: Loaded X car brands"
echo "- DEBUG: Brand changed to: 'Toyota'"
echo "- DEBUG: Loading models for brand: Toyota"
echo "- DEBUG: Loaded X models for Toyota"