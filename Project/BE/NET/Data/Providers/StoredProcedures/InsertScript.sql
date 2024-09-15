CREATE PROCEDURE [dbo].[InsertScript]
    @Content NVARCHAR(MAX) NOT NULL,
    @PartId INT,
    @AudioId INT,

    @Id INT OUTPUT
AS
BEGIN
    INSERT INTO Script (Content, PartId, AudioId)
    VALUES (@Content, @PartId, @AudioId)

    SET @Id = SCOPE_IDENTITY()
END