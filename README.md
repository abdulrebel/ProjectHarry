MVC Dapper Project

This project is a simple ASP.NET MVC application that demonstrates the usage of Dapper ORM for data access. It allows users to manage a list of products, including creating, updating, and deleting products.
Technologies Used

    ASP.NET MVC
    C#
    Dapper
    SQL Server

Installation

    Clone the repository to your local machine.
    Open the project in Visual Studio.
    Restore the NuGet packages for the solution.
    Update the connection string in the ProductsController.cs file to point to your SQL Server instance.
    Build the solution to ensure all dependencies are resolved.

Database Setup

    Create a SQL Server database with the name "MVCDapperDb".
    //Create table 
    CREATE TABLE [dbo].[Products] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [ProductName] VARCHAR (255)   NULL,
    [Price]       DECIMAL (18, 2) NULL,
    [Description] VARCHAR (255)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
    );  //Stored Procedure
    
     1. CREATE PROCEDURE AddProduct
    @ProductName VARCHAR(255),
    @Description VARCHAR(255),
    @Price DECIMAL(18, 2)
    AS
    BEGIN
        INSERT INTO Products (ProductName, Description, Price)
        VALUES (@ProductName, @Description, @Price)
    END

    2.CREATE PROCEDURE DeleteProduct
    @Id INT
    AS
    BEGIN
        DELETE FROM Products
        WHERE Id = @Id;
    END

    3.CREATE PROCEDURE GetAllProducts
    AS
    BEGIN
        SELECT * FROM Products;
    END

    4.CREATE PROCEDURE dbo.GetProductById
    @Id INT
    AS
    BEGIN
        SELECT *
        FROM Products
        WHERE Id = @Id
    END
    
    5.CREATE PROCEDURE UpdateProduct
    @Id INT,
    @ProductName VARCHAR(255),
    @Description VARCHAR(255),
	@Price DECIMAL(18, 2)
    AS
    BEGIN
        UPDATE Products
        SET ProductName = @ProductName,
            Description = @Description,
            Price = @Price
        WHERE Id = @Id
    END



Usage

    Launch the application from Visual Studio or deploy it to a web server.
    Navigate to the home page to view the list of products.
    Click on "Create" to add a new product. Fill in the required fields and submit the form.
    Click on "Edit" next to a product to update its details.
    Click on "Delete" next to a product to remove it from the list.

Configuration

    To change the database connection string, update the connectionString variable in the ProductsController.cs file.

File Structure

    Qhrm.Controllers: Contains the controller classes for handling product-related actions.
    Qhrm.Models: Contains the model classes representing the product entity.
    Views: Contains the Razor views for rendering the user interface.
    Database Scripts: Contains SQL scripts for creating the necessary database objects.

Contributing

Contributions to this project are welcome. If you find any issues or have suggestions for improvements, please submit a pull request or open an issue on GitHub.
License

This project is licensed under the MIT License.
Author

Created by Abdul Samad Zafri
