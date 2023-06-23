

# Blazor Server App - QuotationMgmtSystem!
QuotationMgmtSystem is Blazor Server App which is written in C# language. There's separate layer for services which is responsible for data transmission.

## Project Abstract
This project have the ability to enter the customer and quotation specific to customer, it also covers authentication module along with role-base page filtering.

## Project Covered Topics
 - Custom Authentication: ProtectedSessionStorage
 - Authorization: Role-based page access
 - State Management: Applicable for "Keep Notes" module
 - Data persistency in database for operations


## System role details with access pages
Below are the only roles exist in Project, consider them if planning to create new user.
 - CSM: UserName as "msshaikh" and Password as "msshaikh"
Access to Home, Customer and Keep Note page

 - QuoteStaff: UserName as "vivekupla" and Password as "vivekupla"
Access to Home, Quotation and Keep Note page

 - Administrator - UserName as "admin" and Password as "admin"
Access to Home, Counter, Fetch Data, Customer, Quotation and Keep Note pages

Note: If you want to create new user with any of above's role, then update the master data in /ApplicationDbContext/ModelBuilderExtensions.cs


## Getting started
For cloning the project into local machine you need to perform following steps
 - Open the solution file (.sln)
 - Open the package manager console and hit the following command "update-database", it should generate database in your localdb. There's a default master data will be populated.
 - CSM user have access to manage Customer and QuoteStaff for Quotation, for admin both ones


### Project-Setup Prerequisites  
 - Visual Studio 2019 16.8 or later (https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
 - .NET 5 SDK (https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
 - Microsoft SQL Server 2016 localdb, steps are below
   (navigate to https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16
    select your visual studio version and the download will gets started, install it and re-launch SSMS to check weather it's installed or not, put server name as "(LocalDB)\MSSQLLocalDB" and you should be able to connected in SSMS,
	alternative link: http://www.hanselman.com/blog/download-sql-server-express)


### Technology Prerequisites  
 - C#
 - HTML
 - CSS


### Run Project in Development enviorment
 - Clone the repository in your local enviorment.
 - Rebuild the project so all the dependant packages will be installed.
 - If you are using visual studio then you can directly run the project.
 - If you are using your local copy of the database then set your connection string in appsettings.json file of your project.


### Dependencies

#### Nuget Packages
Below are the dependant packages consumed
 - Blazored.Toast 
 - Microsoft.EntityFrameworkCore
 - Microsoft.EntityFrameworkCore.SqlServer
 - Microsoft.EntityFrameworkCore.Tools
 - Microsoft.VisualStudio.Web.CodeGeneration.Design


### Database
Below is the database server and database name
Database Server: (localdb)\\mssqllocaldb
Database Name: QuotationMgmtSystem


### Project Architecture
Below is the only project in our solution
 - QuotationMgmtSystem: It contains all the Blazor server app code along with all the data transmission services


### Deployment
N/A


### Deployement prerequistes
N/A


### Deployement Steps
N/A


## License
N/A


## Future Scope to cover
 - Convert current SessionStorage implementation to LocalStorage
 - Extend application to further Quotation Management System's scope

 #blazor #blazordemo #blazorserverapp #blazorexample #blazorauth #blazorauthentication #blazorcustomauthentication
