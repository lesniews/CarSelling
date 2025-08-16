#!/bin/bash

echo "🚀 Starting Car Selling Application Servers"
echo "==========================================="

# Check if we're in the right directory
if [ ! -d "src/CarSelling.Api" ]; then
    echo "❌ Error: Please run this script from the CarSelling root directory"
    exit 1
fi

echo "📡 Starting API Server on port 5004..."
cd src/CarSelling.Api
dotnet run &
API_PID=$!

# Wait a moment for API to start
sleep 3

echo "🌐 Starting Web Server on port 5209..."
cd ../CarSelling.Web
dotnet run &
WEB_PID=$!

echo ""
echo "✅ Servers Started Successfully!"
echo "================================"
echo "📡 API Server: http://localhost:5004"
echo "🌐 Web Server: http://localhost:5209"
echo ""
echo "🔍 Test API directly:"
echo "curl http://localhost:5004/api/carbrand"
echo "curl http://localhost:5004/api/carmodel/names-by-brand/Toyota"
echo ""
echo "📱 Open in browser: http://localhost:5209"
echo ""
echo "⏹️  To stop servers: Press Ctrl+C"

# Wait for user to stop
wait $API_PID $WEB_PID