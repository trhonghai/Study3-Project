CREATE PROCEDURE [dbo].[FindTypeById]
    @Id INT
AS
BEGIN
    -- Set NOCOUNT ON to prevent extra result sets from interfering with SELECT statements.
    SET NOCOUNT ON;
    SELECT * FROM [dbo].[Type] WHERE [Id] = @Id;
END