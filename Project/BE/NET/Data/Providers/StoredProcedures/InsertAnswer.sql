CREATE PROCEDURE    [dbo].[InsertAnswer]
    @Content NVARCHAR(255),
    @IsCorrect INT,
    @Explanation INT,
    @QuestionId BIT,
    @Id INT OUTPUT
AS
BEGIN
    INSERT INTO [dbo].[Answers] ([Content], [IsCorrect], [Explanation], [QuestionId])
    VALUES (@Content, @IsCorrect, @Explanation, @QuestionId)

    SET @Id = SCOPE_IDENTITY()
END