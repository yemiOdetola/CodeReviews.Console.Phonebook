# Phone Book App

A simple CRUD Console app that allows users to manage a phonebook of their contacts Names, Email address, and Phone numbers. 

The goal is to learn how to use Entity Framework with SQL server.

## Instructions

1. Install SQL Server and configure the connection string in `ConfigurationManager.AppSettings["ConnectionString"]` to match your local SQL server instance.

2. If Entity Framework CLI is not already installed:
```c#
dotnet tool install --global dotnet-ef
```

3. Apply Migrations to create the database schema:
```c#
dotnet ef database update
```

3. Run the application
```c#
dotnet run
```
