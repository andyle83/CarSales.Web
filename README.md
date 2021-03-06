# CarSales.Web

Simple CarSales Web Application built with RESTful API ASP.NET Core 3.1 and React 16.13.x <br />
Allowing users to manage a list of vehicle / vehicles type in an in-memory database.

## Changes list

N/A

## TODO

Here are some pending features need to implement:

- Adding unit test for both front-end and back-end
- Handle edit or update in the vehicle list table
- Manage customizable features in a specified type of a vehicle

## Frameworks and Libraries

### Server

- [ASP.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core);
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) (for data access);
- [Sqlite](https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli) (for testing purposes);
- [AutoMapper](https://automapper.org/) (for mapping resources and models);
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle) (API documentation);
- [Serilog](https://github.com/serilog/serilog-aspnetcore) (logging system);

### Client

- [React](https://reactjs.org) (A JavaScript library for building user interfaces);
- [Redux](https://redux.js.org) (A Predictable State Container for JS Apps);
- [Redux-Sags](https://redux-saga.js.org) (Making application side effect);
- [Bootstrap](https://getbootstrap.com) (A common CSS framework);

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

![API Documentation](https://raw.githubusercontent.com/andyle83/CarSales.Web/master/Screenshots/API.PNG)

### Client

It is bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

In the project directory, you can run:

`yarn start` - Runs the app in the development mode and open [http://localhost:3000](http://localhost:3000) to view

`yarn test` - Launches the test runner in the interactive watch mode.

`yarn build` - Builds the app for production to the `build` folder.

Vehicle Type list selection screenshot

![Select Vehicle Type](https://raw.githubusercontent.com/andyle83/CarSales.Web/master/Screenshots/SelectVehicleType.PNG)

Vehicle management ( Create / Update / Delete ) screenshot

![Vehicle Management Page](https://raw.githubusercontent.com/andyle83/CarSales.Web/master/Screenshots/VehicleManagement.PNG)