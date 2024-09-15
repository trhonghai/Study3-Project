CREATE PROCEDURE [dbo].[InsertPart]
    @Title nvarchar(255),

    @Id INT OUTPUT
AS 
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Part] ([Title])
    VALUES (@Title)

    SET @Id = SCOPE_IDENTITY();
END