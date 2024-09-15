CREATE PROCEDURE [dbo].[InsertType]
    @Name nvarchar(255),

    @Id INT OUTPUT
AS 
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Type] ([Name])
    VALUES (@Name)

    SET @Id = SCOPE_IDENTITY();
END