CREATE PROCEDURE [dbo].[InsertQuestion]
    @Content NVARCHAR(MAX) NOT NULL,
    @ScriptId INT,
    @AudioId INT,

    @Id INT OUTPUT

AS
BEGIN
    INSERT INTO Question (Content, ScriptId, AudioId)
    VALUES (@Content, @ScriptId, @AudioId)

    SET @Id = SCOPE_IDENTITY()
END