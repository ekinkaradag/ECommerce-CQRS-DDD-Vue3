USE [tempdb];
GO
DECLARE @SQL nvarchar(1000);
IF EXISTS (SELECT 1 FROM sys.databases WHERE [name] = N'ECommerceDemo')
BEGIN
    SET @SQL = N'USE [ECommerceDemo];

                 ALTER DATABASE ECommerceDemo SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                 USE [tempdb];

                 DROP DATABASE ECommerceDemo;';
    EXEC (@SQL);
END;
