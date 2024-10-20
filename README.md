# SW4BAD Assignment 2

This is an ASP.NET Core project using Entity Framework Core and SQL Server. The project includes API endpoints to interact with a database.

## Prerequisites

Before you can run the project, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Azure Data Studio](https://docs.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio)

## Setup Instructions

1. **Clone the Repository**

   First, clone the GitHub repository to your local machine:

   ```bash
   git clone https://github.com/YOUR_USERNAME/SW4BAD_Assignment2.git
   cd SW4BAD_Assignment2
   ```

2. **Configure the Connection String**

    Open appsettings.json and update the connection string to point to your local or remote SQL Server instance.

3. **Install the .NET Dependencies**

    Install the required .NET dependencies using the following command:
    ```bash
    dotnet restore
    ```
    Install the `dotnet-ef` tool for migrations and database update commands
    ```bash
    dotnet tool install --global dotnet-ef
    ```
4. **Apply Migrations to the Database**
    Run the migrations to set up the database schema:
    ```bash
    dotnet ef database update
    ```
    This will create the database and the necessary tables.

5. **Run the Application**
    To run the project, execute the following command:
    ```bash
    dotnet run
    ```
    The application will be hosted at http://localhost:5000 (or another available port).

6. **Access the API Endpoints**
    You can access the API using your browser:

    * Get all dishes: `GET http://localhost:5000/dish`
    * Create a new dish: `POST http://localhost:5000/dish`
    * Update a dish: `PUT http://localhost:5000/dish/{id}`
    * Delete a dish: `DELETE http://localhost:5000/dish/{id}`

7. **Use Azure Data Studio to View the Database**

    You can view and query the database using Azure Data Studio:

    Connect to your SQL Server instance.
    Locate the Assignment2DB database.
    Run queries to inspect data or manually modify tables.

   
 ## Migrations
   First add the change for the migrations and generate the migration:
    ```bash
   dotnet ef migrations add <change>
   ```
   Apply the migration to the database:
   ```bash
   dotnet ef database update
   ```
