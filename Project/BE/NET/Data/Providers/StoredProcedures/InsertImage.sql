CREATE PROCEDURE [dbo].[InsertImage]
    @Url NVARCHAR(255),
    @ScriptId INT,

    @Id INT OUTPUT
AS
BEGIN
    INSERT INTO [dbo].[Images] ([Url], [ScriptId])
    VALUES (@Url, @ScriptId)

    SET @Id = SCOPE_IDENTITY()
END