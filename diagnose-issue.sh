#!/bin/bash

echo "🔍 DIAGNOSTIC: Why Models Don't Load"
echo "===================================="

echo "1. Checking running processes on expected ports..."
echo "   Port 5004 (API):"
lsof -i :5004 2>/dev/null | grep LISTEN || echo "   ❌ Nothing listening on port 5004"

echo "   Port 5209 (Web):"
lsof -i :5209 2>/dev/null | grep LISTEN || echo "   ❌ Nothing listening on port 5209"

echo ""
echo "2. Testing API endpoints..."
echo "   Brands endpoint:"
if curl -s --max-time 3 http://localhost:5004/api/carbrand > /dev/null 2>&1; then
    echo "   ✅ Brands API responding"
else
    echo "   ❌ Brands API not responding"
fi

echo "   Toyota models endpoint:"
if curl -s --max-time 3 "http://localhost:5004/api/carmodel/names-by-brand/Toyota" > /dev/null 2>&1; then
    echo "   ✅ Models API responding"
else
    echo "   ❌ Models API not responding"
fi

echo ""
echo "🎯 SOLUTION:"
echo "You need to start BOTH servers simultaneously:"
echo ""
echo "Terminal 1 (API):"
echo "  cd src/CarSelling.Api"
echo "  dotnet run"
echo ""
echo "Terminal 2 (Web):"
echo "  cd src/CarSelling.Web"
echo "  dotnet run"
echo ""
echo "OR use the startup script:"
echo "  ./start-servers.sh"
echo ""
echo "💡 The brands might be loading from browser cache or a different source."
echo "   But models require real-time API calls, which is why they fail."