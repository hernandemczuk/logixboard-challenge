# Pre-requisites

logixboard-challenge uses ASP .NET Core Web API (https://dotnet.microsoft.com/download), Entity Framework Core Tools (https://docs.microsoft.com/en-us/ef/core/cli/dotnet), and SQL Server (https://www.microsoft.com/en-us/sql-server/sql-server-downloads) on the persistance layer. Make sure to have these installed before continuing with the steps.

# Steps

1. Create appsettings.Development.json in /Logixboard.API folder with the following content:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source={{Server}};Initial Catalog={{Database}};Integrated Security=SSPI;"
  }
}
```
2. Run the following command to instantiate the database: ``dotnet ef database update``

3. On /be-code-challenge_cf72aca folder run: ``npm install``

4. On /Logixboard.API folder run: ``dotnet run``

5. Open a browser and go to http://localhost:5000/swagger/index.html