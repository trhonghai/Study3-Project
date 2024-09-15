CREATE PROCEDURE [dbo].[InsertTestPart]
    @TestId INT,
    @PartId INT,
    @NoQuestion INT,
    @TimeLimit INT,

    @Id INT OUTPUT
AS
BEGIN
    INSERT INTO [dbo].[TestPart] ([TestId], [PartId], [NoQuestion], [TimeLimit]) VALUES 
                              (@TestId, @PartId, @NoQuestion, @TimeLimit);
    SET @Id = SCOPE_IDENTITY();
END