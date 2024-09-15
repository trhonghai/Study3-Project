CREATE PROCEDURE [dbo].[FindPartById]
    @Id INT
AS
BEGIN
    -- Set NOCOUNT ON to prevent extra result sets from interfering with SELECT statements.
    SET NOCOUNT ON;
    SELECT * FROM [dbo].[Test] WHERE [Id] = @Id;
END