CREATE PROCEDURE [dbo].[InsertAudio]
    @Url NVARCHAR(255),

    @Id INT OUTPUT
AS
BEGIN
    INSERT INTO [dbo].[Audio] ([Url]) VALUES 
                              (@Url);
    SET @Id = SCOPE_IDENTITY();
END