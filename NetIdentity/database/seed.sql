-- Script to create example tables (products, orders, orderitems) and seed some data.
-- NOTE: This script does NOT create Identity tables (AspNetUsers, AspNetRoles, etc.)
-- Run migrations (dotnet ef database update) to create Identity tables, or create them manually.

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Price DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL
);

CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId NVARCHAR(450) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    Total DECIMAL(18,2) NOT NULL
);

CREATE TABLE OrderItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(Id),
    ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL
);

-- Seed products
INSERT INTO Products (Name, Description, Price, Stock) VALUES
('Producto A', 'Descripcion A', 10.50, 100),
('Producto B', 'Descripcion B', 25.00, 50),
('Producto C', 'Descripcion C', 7.99, 200);

-- Example order (you may want to change UserId to an actual AspNetUsers Id)
INSERT INTO Orders (UserId, CreatedAt, Total) VALUES
('sample-user-id-1', GETUTCDATE(), 36.50);

INSERT INTO OrderItems (OrderId, ProductId, Quantity, UnitPrice) VALUES
(1, 1, 2, 10.50),
(1, 2, 1, 15.50);
