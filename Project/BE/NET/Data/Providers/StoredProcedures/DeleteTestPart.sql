CREATE PROCEDURE [dbo].[DeleteTestPart]
    @Id INT
AS
BEGIN
    
    DELETE FROM [dbo].[TestPart]
    WHERE [Id] = @Id;
    
END
