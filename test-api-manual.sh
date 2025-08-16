#!/bin/bash

echo "🧪 Manual API Test"
echo "=================="

# Function to test API endpoint
test_endpoint() {
    local url="$1"
    local description="$2"
    
    echo "Testing: $description"
    echo "URL: $url"
    
    if response=$(curl -s --max-time 5 "$url" 2>/dev/null); then
        if [ -n "$response" ] && [ "$response" != "null" ]; then
            echo "✅ Success!"
            echo "Response length: $(echo "$response" | wc -c) characters"
            if command -v jq >/dev/null 2>&1; then
                echo "JSON length: $(echo "$response" | jq '. | length' 2>/dev/null || echo "Not valid JSON")"
            fi
            echo "First 200 chars: $(echo "$response" | head -c 200)..."
        else
            echo "❌ Empty or null response"
        fi
    else
        echo "❌ Failed to connect"
    fi
    echo "---"
}

# Test endpoints
test_endpoint "http://localhost:5004/api/carbrand" "Car Brands"
test_endpoint "http://localhost:5004/api/carmodel/names-by-brand/Toyota" "Toyota Models"
test_endpoint "http://localhost:5004/api/carmodel/names-by-brand/BMW" "BMW Models"
test_endpoint "http://localhost:5004/api/carmodel/names-by-brand/Honda" "Honda Models"

echo ""
echo "🎯 If all tests pass, the API is working correctly."
echo "   The issue is likely in the UI event binding or method execution."
echo ""
echo "Next steps:"
echo "1. Open browser to http://localhost:5209"
echo "2. Open Developer Tools (F12) → Console"
echo "3. Select a brand and look for debug messages:"
echo "   🔥 DEBUG: OnBrandChanged called! Brand: 'Toyota'"
echo "   🚀 DEBUG: Loading models for brand: Toyota"
echo "   ✅ DEBUG: Loaded X models for Toyota"