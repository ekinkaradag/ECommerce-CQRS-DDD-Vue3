CREATE DATABASE ECommerceDemo;
GO

USE ECommerceDemo;
GO


CREATE SCHEMA orders AUTHORIZATION dbo
GO

CREATE TABLE orders.Customers
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Email] VARCHAR(255) NOT NULL,
	[Name] VARCHAR(200) NULL,
    [WelcomeEmailWasSent] BIT NOT NULL,
	CONSTRAINT [PK_orders_Customers_Id] PRIMARY KEY ([Id] ASC)
)
GO

INSERT INTO orders.Customers VALUES ('4667C05F-4162-4CCB-8FD6-B73B1B16EED7', 'johndoeemail.com', 'John Doe', 1);
INSERT INTO orders.Customers VALUES ('665A97BD-ED41-4EA2-8340-5A5FE95D500E', 'janedoeemail.com', 'Jane Doe', 1);

CREATE TABLE orders.Orders
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[CustomerId] UNIQUEIDENTIFIER NOT NULL,
	[IsRemoved] BIT DEFAULT 0,
	[Price] DECIMAL (18, 2) NOT NULL,
	[StatusId] TINYINT NOT NULL,
	[OrderDate] DATETIME2 NOT NULL,
	[OrderChangeDate] DATETIME2 NULL,
	CONSTRAINT [PK_orders_Orders_Id] PRIMARY KEY ([Id] ASC)
)
GO

CREATE TABLE orders.Products
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(200),
	[Price] DECIMAL(18, 2) NOT NULL,
	[ImageUrl] VARCHAR(MAX) NOT NULL,
	[IsRemoved] BIT DEFAULT 0,
	CONSTRAINT [PK_orders_Products_Id] PRIMARY KEY ([Id] ASC)
)
GO

INSERT INTO orders.Products VALUES ('8744C356-0E7B-4B44-9CDB-61A041B4F065', 'Jacket', 90.99, '/jacket.png', 0);
INSERT INTO orders.Products VALUES ('15BE82CB-A5C6-4067-B0CF-4D2947B0BB3C', 'T-shirt', 30, '/t-shirt.png', 0);
INSERT INTO orders.Products VALUES ('89B3B84F-53DF-411F-BECB-8AD9F3DA2025', 'Cap', 19.90, '/cap.png', 0);
INSERT INTO orders.Products VALUES ('981AE724-DAF0-4668-861B-877D77D78390', 'Sneakers', 79.50, '/sneakers.png', 0);
GO

CREATE TABLE orders.OrderProducts
(
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[Quantity] INT,
	CONSTRAINT [PK_orders_OrderProducts_OrderId_ProductId] PRIMARY KEY ([OrderId] ASC, [ProductId] ASC)
)
GO

-- Create an example order with 1 T-shirt and 2 caps:
INSERT INTO orders.Orders VALUES (
	'941EC3A6-C454-42B2-B43D-F40C0B425E52',
	'4667C05F-4162-4CCB-8FD6-B73B1B16EED7',
	0,
	69.80,
	0,
	GETDATE(),
	null);
INSERT INTO orders.OrderProducts VALUES ('941EC3A6-C454-42B2-B43D-F40C0B425E52', '15BE82CB-A5C6-4067-B0CF-4D2947B0BB3C', 1);
INSERT INTO orders.OrderProducts VALUES ('941EC3A6-C454-42B2-B43D-F40C0B425E52', '89B3B84F-53DF-411F-BECB-8AD9F3DA2025', 2);
GO

CREATE VIEW orders.v_Orders
AS
(
	SELECT
		[Order].[Id],
		[Order].[CustomerId],
		[Order].[Price],
		[Order].[IsRemoved],
		[Order].[OrderDate],
		[Order].[OrderChangeDate]
	FROM orders.Orders AS [Order]
)
GO

CREATE VIEW orders.v_OrderProducts
AS
(
	SELECT
		[OrderProduct].[OrderId],
		[OrderProduct].[ProductId],
		[OrderProduct].[Quantity],
		[Product].[Price],
		[Product].[Name],
		[Product].[ImageUrl]
	FROM orders.OrderProducts AS [OrderProduct]
		INNER JOIN orders.Products AS [Product]
			ON [OrderProduct].ProductId = [Product].[Id]
)
GO

CREATE SCHEMA app AUTHORIZATION dbo
GO

CREATE TABLE app.OutboxMessages
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[OccurredOn] DATETIME2 NOT NULL,
	[Type] VARCHAR(255) NOT NULL,
	[Data] VARCHAR(MAX) NOT NULL,
	[ProcessedDate] DATETIME2 NULL,
	CONSTRAINT [PK_app_OutboxMessages_Id] PRIMARY KEY ([Id] ASC)
)
GO

CREATE TABLE app.InternalCommands
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[EnqueueDate] DATETIME2 NOT NULL,
	[Type] VARCHAR(255) NOT NULL,
	[Data] VARCHAR(MAX) NOT NULL,
	[ProcessedDate] DATETIME2 NULL,
	CONSTRAINT [PK_app_InternalCommands_Id] PRIMARY KEY ([Id] ASC)
)
GO

CREATE SCHEMA payments AUTHORIZATION dbo
GO

CREATE TABLE payments.Payments
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[CreateDate] DATETIME2 NOT NULL,
	[StatusId] TINYINT NOT NULL,
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
    [EmailNotificationIsSent] BIT NOT NULL
	CONSTRAINT [PK_payments_Payments_Id] PRIMARY KEY ([Id] ASC)
)
GO

CREATE VIEW orders.v_Customers
AS
SELECT
	[Customer].[Id],
	[Customer].[Email],
	[Customer].[Name],
    [Customer].[WelcomeEmailWasSent]
FROM [orders].[Customers] AS [Customer]
GO