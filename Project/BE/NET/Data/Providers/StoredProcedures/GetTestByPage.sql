CREATE PROCEDURE [dbo].[GetTestByPage]
    @PageNumber INT,
    @PageSize INT,
    @TotalPages INT OUTPUT  -- Chỉ cần sử dụng OUTPUT cho @TotalPages
AS
BEGIN
    -- Set NOCOUNT ON to prevent extra result sets from interfering with SELECT statements.
    SET NOCOUNT ON;

    DECLARE @TotalRecords INT;  -- Khai báo @TotalRecords bên trong procedure

    -- Calculate the total number of records
    SELECT @TotalRecords = COUNT(*) FROM [dbo].[Test];

    -- In ra giá trị của @TotalRecords để kiểm tra
    PRINT 'TotalRecords inside procedure: ' + CAST(@TotalRecords AS VARCHAR(10));

    -- Calculate the total number of pages
    IF @TotalRecords > 0
    BEGIN
        SET @TotalPages = CEILING(CAST(@TotalRecords AS FLOAT) / @PageSize);
        PRINT 'TotalPages inside procedure: ' + CAST(@TotalPages AS VARCHAR(10));
    END
    ELSE
    BEGIN
        SET @TotalPages = 0;
        PRINT 'TotalPages set to 0 because there are no records.';
    END

    -- Select the paginated results
    SELECT 
        Test.[Id], 
        Test.[Title], 
        Test.[Code], 
        Test.[Year], 
        Test.[Attempts], 
        Test.[Month], 
        Test.[TimeLimit], 
        Test.[NoCompleted],
        Type.[Name]
    FROM 
        [dbo].[Test] AS Test
    JOIN 
        [dbo].[Type] AS Type ON Test.[TypeId] = Type.[Id]
    ORDER BY 
        Test.[Id] 
    OFFSET 
        (@PageNumber - 1) * @PageSize ROWS 
    FETCH NEXT 
        @PageSize ROWS ONLY;
END
