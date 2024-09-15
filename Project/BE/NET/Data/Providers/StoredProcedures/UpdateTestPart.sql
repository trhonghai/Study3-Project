CREATE PROCEDURE [dbo].[UpdateTestPart]
    @Id INT,
    @TestId INT,
    @PartId INT,
    @NoQuestion INT,
    @TimeLimit INT
AS
BEGIN

    UPDATE TestPart
    SET 
        TestId = @TestId,
        PartId = @PartId,
        NoQuestion = @NoQuestion,
        TimeLimit = @TimeLimit
    WHERE Id = @Id  
    AND (ISNULL(TestId, -1) <> ISNULL(@TestId, -1) OR
         ISNULL(PartId, -1) <> ISNULL(@PartId, -1) OR
         ISNULL(NoQuestion, -1) <> ISNULL(@NoQuestion, -1) OR
         ISNULL(TimeLimit, -1) <> ISNULL(@TimeLimit, -1));
END;