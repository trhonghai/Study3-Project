CREATE PROCEDURE [dbo].[FindTestById]
    @Id INT
AS
BEGIN
    -- Set NOCOUNT ON to prevent extra result sets from interfering with SELECT statements.
    SET NOCOUNT ON;
    SELECT [Id], 
        [Title], 
        [Code], 
        [Year], 
        [Attempts], 
        [Month], 
        [TimeLimit], 
        [NoCompleted], 
        [TypeId] 
        FROM [dbo].[Test] WHERE [Id] = @Id;
END