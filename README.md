
# ProductTest Web Application

Welcome to the ProductTest web application! This application allows you to manage products, including adding, editing, and deleting them.

## Getting Started - Update Database

```
-- Run this script in your local SQL Server Management Studio
-- Create the "Product" table

CREATE TABLE [dbo].[Product](
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [varchar](100) NULL,
    [Description] [varchar](500) NULL,
    [Price] [decimal](10, 2) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
)

-- Insert sample data into the "Product" table

INSERT INTO Product
SELECT NEWID(), 'Product 1', 'Product 1 Desc', 10 UNION ALL
SELECT NEWID(), 'Product 2', 'Product 2 Desc', 20 UNION ALL
SELECT NEWID(), 'Product 3', 'Product 3 Desc', 30

```
## Getting Started Running the Application

1. Clone this repository to your local machine.
2. Make sure you have the .NET SDK and Visual Studio or Visual Studio Code installed.
3. Navigate to the project directory using the terminal or You can also run in Visual Studio directly.
4. Run the application using the following command:

   ```bash
   dotnet run
   
Open your browser and navigate to https://localhost:5001 or https://localhost:7052/ to access the application.

## Features
- Add new products with their details such as name, description, and price.
- Edit existing products' information.
- Delete products from the database.
- Seamless user interface with Blazor WebAssembly.

## Project Structure
- Pages: Contains the Blazor components that represent the different pages of the application.
- Shared: Contains shared models, components, and utilities used across the application.
- Client: Contains the API client for communication with the backend.

## Dependencies
- Blazor WebAssembly
- HttpClient for API communication
- Bootstrap for styling

