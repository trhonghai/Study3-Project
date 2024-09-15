-- CREATE TABLE [dbo].[Test] (
--                                 [Id] INT NOT NULL PRIMARY KEY IDENTITY,
--                                 [Title] NVARCHAR(255) NOT NULL,
--                                 [Code] NVARCHAR(255) NOT NULL,
--                                 [Year] INT,
--                                 [Attempts] INT,
--                                 [Month] INT,
--                                 [TimeLimit] INT,
--                                 [NoCompleted] INT,
--                                 [TypeId] INT,
--                                 CONSTRAINT [FK_Test_Type_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[Type] ([Id])
--                             );

-- INSERT INTO [dbo].[Test] ([Title], [Code], [Year], [Attempts], [Month], [TimeLimit], [NoCompleted], [TypeId]) VALUES ('Test 1', 'T1', 2019, 1, 1, 60, 0, 1);
CREATE PROCEDURE [dbo].[InsertTest]
    @Title NVARCHAR(255),
    @Code NVARCHAR(255),
    @Year INT,
    @Attempts INT,
    @Month INT,
    @TimeLimit INT,
    @NoCompleted INT,
    @TypeId INT,
    @Id INT OUTPUT
AS
BEGIN
    INSERT INTO [dbo].[Test] ([Title], [Code], [Year], [Attempts], [Month], [TimeLimit], [NoCompleted], [TypeId]) VALUES 
                              (@Title, @Code, @Year, @Attempts, @Month, @TimeLimit, @NoCompleted, @TypeId);
    SET @Id = SCOPE_IDENTITY();
END