CREATE PROCEDURE [dbo].[UpdateCourse]
    @Id INT,
    @Title NVARCHAR(50),
    @Price INT,
    @NoPurchase INT,
    @Target NVARCHAR(50),
    @Rating Float,
    @Description NVARCHAR(1000),
    @TypeId INT
AS
BEGIN
    UPDATE [dbo].[Course] 
    SET [Title] = @Title, 
        [Price] = @Price,
        [NoPurchase] = @NoPurchase, 
        [Target] = @Target, 
        [Rating] = @Rating, 
        [Description] = @Description, 
        [TypeId] = @TypeId 
    WHERE [Id] = @Id
    AND ([Title] <> @Title OR
         [Price] <> @Price OR
         [NoPurchase] <> @NoPurchase OR
         [Target] <> @Target OR
         [Rating] <> @Rating OR
         [Description] <> @Description OR
         [TypeId] <> @TypeId);
END