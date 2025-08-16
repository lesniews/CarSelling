# Database Setup and Migration

## Automatic Migration and Seeding

The CarSelling application now includes **automatic database migration and seeding** that runs every time you start the application.

### What happens on startup:

1. **Database Migration**: The application automatically applies any pending migrations to create/update the database schema
2. **Data Seeding**: If the database is empty, it automatically populates it with:
   - **89 Car Brands** from major global manufacturers
   - **149+ Car Models** across popular brands with production years and categories
   - **Sample Car Listings** for testing
   - **Sample Users** (dealers and individuals)

### Starting the Application

Simply run the AppHost project and everything will be set up automatically:

```bash
dotnet run --project src/CarSelling.AppHost
```

### What You'll See

The console will show logs like:
```
info: Program[0] Applying database migrations...
info: Program[0] Database migrations applied successfully.
info: Program[0] Seeding database with car brands and models...
info: Program[0] Database seeding completed successfully.
```

### Database Features

- **CarBrands Table**: 89 brands with country, luxury status, and active flags
- **CarModels Table**: 149+ models with brand relationships, categories, and production years
- **Dynamic Dropdowns**: Brand selection automatically loads relevant models
- **Performance Optimized**: Indexed columns for fast queries

### Manual Migration (if needed)

If automatic migration fails, you can run the manual SQL script:
```sql
-- Run CarBrandsAndModels_Migration.sql in your database
```

### Environment Configuration

The application uses:
- **Development**: `(localdb)\mssqllocaldb` with database name `CarSellingDb`
- **Production**: Connection string from configuration

### API Endpoints

Once running, test these endpoints:
- `GET /api/carbrand` - All car brands
- `GET /api/carmodel/names-by-brand/Toyota` - Toyota models
- `GET /api/carmodel/search?brandName=BMW&category=SUV` - BMW SUVs

The dynamic dropdown functionality will work immediately after the first startup!