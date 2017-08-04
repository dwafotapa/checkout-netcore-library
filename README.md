checkout-netcore-library
============

checkout-netcore-library is a web API built with ASP.NET Core Web API that manages a list of products (drinks for the office for example).


## Installation

### .NET Core

Go to https://www.microsoft.com/net/core, select your OS and follow the installation guide.

### Nuget packages

If you can, restore the Nuget package dependencies/dlls of all projects with your IDE, then build the solution. Otherwise, at the root of the solution, run:
```sh
$ dotnet restore
$ dotnet build
```

## Projects

The solution consists of 3 projects:
* Checkout.ProductApi.NetCore.UnitTests: the test project for the web API
* Checkout.ProductApi.NetCore: the web API project
* Checkout.ApiClient.NetCore: the web API client


## Usage

### Checkout.ProductApi.NetCore.UnitTests

To run the tests:
```sh
$ cd Checkout.ProductApi.NetCore.UnitTests
$ dotnet xunit
```

### Checkout.ProductApi.NetCore

Start the web API in a terminal:
```sh
$ cd ../Checkout.ProductApi.NetCore
$ dotnet run
```

The web API is now up and running at http://localhost:5000/api/product.

### Checkout.ApiClient.NetCore

Start the web API client in another terminal:
```sh
$ cd ../Checkout.ApiClient.NetCore
$ dotnet run
```