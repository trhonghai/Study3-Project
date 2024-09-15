CREATE PROCEDURE [dbo].[InsertCourse]
    @Title NVARCHAR(50),
    @Price INT,
    @NoPurchase INT,
    @Target NVARCHAR(50),
    @Rating Float,
    @Description NVARCHAR(1000),
    @TypeId INT,
    @Id INT OUTPUT
AS
BEGIN
    INSERT INTO [dbo].[Course] ([Title], [Price], [NoPurchase], [Target], [Rating], [Description], [TypeId]) VALUES 
                              (@Title, @Price, @NoPurchase, @Target, @Rating, @Description, @TypeId);
    SET @Id = SCOPE_IDENTITY();
END
