# ITM Vehicle Sales System

## 1. Project Overview
The ITM Vehicle Sales System is a RESTful API built with .NET 8 and C# to manage vehicle sales for a single dealership in Medellín. The system records vehicles, customers, and sales transactions while ensuring that each sale links a customer to a single vehicle.

## 2. Technology Stack
- **Backend**: .NET 8 (ASP.NET Core Web API)
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Authentication**: JWT (if needed in the future)
- **Tools**: Postman (for API testing), Swagger (for API documentation)


### 3 Add Dependencies
```sh
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore
```

## 4. Database Design
### 4.1 Entities & Relationships
- **Agency**: Represents the dealership.
- **Customer**: Stores client details.
- **Brand**: Stores vehicle brands.
- **Vehicle**: Represents the cars being sold.
- **Sale**: Links a customer to a purchased vehicle.

### 4.2 Database Migration
```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 5. API Endpoints

### 5.1 Vehicle Endpoints
| Method | Endpoint           | Description        |
|--------|-------------------|--------------------|
| GET    | /api/vehicles     | Get all vehicles  |
| POST   | /api/vehicles     | Add a new vehicle |
| PUT    | /api/vehicles/{id}| Update a vehicle |
| DELETE | /api/vehicles/{id}| Delete a vehicle |

### 5.2 Sale Endpoints
| Method | Endpoint           | Description           |
|--------|-------------------|-----------------------|
| GET    | /api/sales        | Get all sales records |
| POST   | /api/sales        | Record a new sale     |

## 6. Step-by-Step Development Guide

### 6.1 Define Models
1. Create a **Models** folder.
2. Add classes: `Agency.cs`, `Customer.cs`, `Brand.cs`, `Vehicle.cs`, and `Sale.cs`.
3. Define properties and relationships.

### 6.2 Configure Database Context
1. Create `ApplicationDbContext.cs` in `Data` folder.
2. Add `DbSet<>` properties for each entity.
3. Configure relationships using Fluent API in `OnModelCreating()`.

### 6.3 Implement Repositories
1. Create a `Repositories` folder.
2. Implement `IVehicleRepository.cs`, `ISaleRepository.cs`, etc.
3. Create `VehicleRepository.cs` and `SaleRepository.cs`.

### 6.4 Build Services
1. Create a `Services` folder.
2. Implement `VehicleService.cs` and `SaleService.cs`.

### 6.5 Develop Controllers
1. Create `VehiclesController.cs`.
2. Implement CRUD methods using dependency injection.
3. Add Swagger documentation.

### 6.6 Test API with Postman
1. Start the API: `dotnet run`.
2. Use Postman to test each endpoint.
3. Validate responses and data consistency.

## 7. Deployment
- Deploy to Azure App Service or an on-premise server.
- Use Azure SQL Database for production data storage.

## 8. Future Enhancements
- Implement authentication with JWT.
- Introduce logging and monitoring.
- Add unit tests and integration tests.


