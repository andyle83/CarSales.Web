# CarSales.Web

Simple RESTful API built with ASP.NET Core 3.1 to create RESTful services to manage a list of Cars or Vehicles

## Changes list

## Frameworks and Libraries

- [ASP.NET Core 3.1] (https://dotnet.microsoft.com/download/dotnet-core);
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) (for data access);
- [Sqlite](https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli) (for testing purposes);
- [AutoMapper](https://automapper.org/) (for mapping resources and models);
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle) (API documentation);
- [Serilog] (https://github.com/serilog/serilog-aspnetcore) (logging system);

## How to Run

### Server

First, install [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/). 
Then, open the terminal or command prompt at the API root path (```/CarSales.Web```) 
Run the following commands:

```
dotnet restore
dotnet run --project CarSales.Web.Ap
```

Navigate to ```https://localhost:5001/api/vehicletype``` to check if the API is working. 
Navigate to ```https://localhost:5001/``` to check the API documentation.

To test all endpoints, you'll need to use a software such as [Postman](https://www.getpostman.com/).

### Client

