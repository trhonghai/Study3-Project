CREATE PROCEDURE [dbo].[DeleteTest]
    @Id INT

AS

BEGIN

    DELETE FROM [dbo].[Test]
    WHERE [Id] = @Id;

END
