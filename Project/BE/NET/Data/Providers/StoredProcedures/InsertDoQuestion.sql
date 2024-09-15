CREATE PROCEDURE [dbo].[InsertDoQuestion]
    @UserId NVARCHAR(450) NOT NULL,
    @QuestionId INT,
    @SelectedAnswer INT,

    @Id INT OUTPUT
AS
BEGIN
    INSERT INTO [dbo].[DoQuestions] ([UserId], [QuestionId], [SelectedAnswer])
    VALUES (@UserId, @QuestionId, @SelectedAnswer)

    SET @Id = SCOPE_IDENTITY()
END