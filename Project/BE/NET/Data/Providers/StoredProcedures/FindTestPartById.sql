CREATE PROCEDURE [dbo].[FindTestPartById]
    @Id INT
AS
BEGIN
    SELECT 
        Id,
        TestId,
        PartId,
        NoQuestion,
        TimeLimit
    FROM TestPart
    WHERE Id = @Id;
END