CREATE PROCEDURE [dbo].[UpdateTest]
    @Id INT,
    @Title NVARCHAR(50),
    @Code NVARCHAR(50),
    @Year INT,
    @Attempts INT,
    @Month INT,
    @TimeLimit INT,
    @NoCompleted INT,
    @TypeId INT
AS
BEGIN

    UPDATE Test
    SET Title = @Title,
        Code = @Code,
        Year = @Year,
        Attempts = @Attempts,
        Month = @Month,
        TimeLimit = @TimeLimit,
        NoCompleted = @NoCompleted,
        TypeId = @TypeId
    WHERE Id = @Id
      AND (Title <> @Title OR
           Code <> @Code OR
           Year <> @Year OR
           Attempts <> @Attempts OR
           Month <> @Month OR
           TimeLimit <> @TimeLimit OR
           NoCompleted <> @NoCompleted OR
           TypeId <> @TypeId);
END