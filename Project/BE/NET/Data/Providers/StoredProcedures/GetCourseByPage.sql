    CREATE PROCEDURE [dbo].[GetCourseByPage]
        @PageNumber INT,
        @PageSize INT,
        @TotalPage INT OUTPUT
    AS
    BEGIN
        SET NOCOUNT ON;
        
        DECLARE @TotalCount INT;

        SELECT @TotalCount = COUNT(*) FROM [dbo].[Course];

        SET @TotalPage = CEILING(CAST(@TotalCount AS FLOAT) / @PageSize);

        SELECT
            Course.[Id],
            Course.[Title],
            Course.[Price],
            Course.[Description],
            Course.[NoPurchase],
            Course.[Target],
            Course.[Rating],
            Type.[Name]
        FROM
            [dbo].[Course] AS Course
        JOIN 
            [dbo].[Type] AS Type ON Course.[TypeId] = Type.[Id]
        ORDER BY
            Course.[Id]
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY
    END