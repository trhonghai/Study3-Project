using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NET.Data
{
    public static class InitialDatabase
    {
        private static string ConnectionString { get; set; } = string.Empty;
        public static void Initialize(string connectionString)
        {
            ConnectionString = connectionString;
        }

        #region Initialize Database
        /// <summary>
        /// Initialize Database with tables
        /// </summary>
        public static void initDB()
        {
            using var cn = new SqlConnection(ConnectionString);

            cn.Open();

            using var cmd = cn.CreateCommand();
            cmd.CommandText = @"

                            -- Drop table for testing

                            DROP TABLE IF EXISTS [dbo].[DoQuestion];
                            DROP TABLE IF EXISTS [dbo].[Answer];
                            DROP TABLE IF EXISTS [dbo].[Image];
                            DROP TABLE IF EXISTS [dbo].[Question];
                            DROP TABLE IF EXISTS [dbo].[Script];
                            DROP TABLE IF EXISTS [dbo].[Audio];
                            DROP TABLE IF EXISTS [dbo].[TestHistory];
                            DROP TABLE IF EXISTS [dbo].[TestPart];
                            DROP TABLE IF EXISTS [dbo].[Part];
                            DROP TABLE IF EXISTS [dbo].[Test];
                            DROP TABLE IF EXISTS [dbo].[PracticeLesson];
                            DROP TABLE IF EXISTS [dbo].[CourseHistory];
                            DROP TABLE IF EXISTS [dbo].[Course];
                            
                            DROP TABLE IF EXISTS [dbo].[Type];

                            -- Create tables

                            CREATE TABLE [dbo].[Type] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [Name] NVARCHAR(50) NOT NULL    
                            );
                            CREATE TABLE [dbo].[Test] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [Title] NVARCHAR(255) NOT NULL,
                                [Code] NVARCHAR(255) NOT NULL,
                                [Year] INT,
                                [Attempts] INT,
                                [Month] INT,
                                [TimeLimit] INT,
                                [NoCompleted] INT,
                                [TypeId] INT,
                                CONSTRAINT [FK_Test_Type_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[Type] ([Id])
                            );
                            CREATE TABLE [dbo].[Part] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [Title] NVARCHAR(255) NOT NULL,
                            );
                            CREATE TABLE [dbo].[TestPart] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [TestId] INT NOT NULL,
                                [PartId] INT NOT NULL,
                                [NoQuestion] INT,
                                [TimeLimit] INT,
                                CONSTRAINT [FK_TestPart_Test_TestId] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test] ([Id]),
                                CONSTRAINT [FK_TestPart_Part_PartId] FOREIGN KEY ([PartId]) REFERENCES [dbo].[Part] ([Id])
                            );

                            CREATE TABLE [dbo].[TestHistory] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [TestId] INT NOT NULL,
                                [UserId] NVARCHAR(450) NOT NULL,
                                [Score] INT,
                                [Time] INT,
                                [Date] DATETIME,
                                [IsCompleted] BIT,
                                [IsPassed] BIT,
                                [NoCorrect] INT,
                                [NoSkip] INT,
                                CONSTRAINT [FK_TestHistory_Test_TestId] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test] ([Id]),
                                CONSTRAINT [FK_TestHistory_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
                            );
                            CREATE TABLE [dbo].[Audio] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [Url] NVARCHAR(255) NOT NULL,
                            );
                            CREATE TABLE [dbo].[Script] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [Content] NVARCHAR(MAX) NOT NULL,
                                [PartId] INT NOT NULL,
                                [AudioId] INT,
                                CONSTRAINT [FK_Script_Part_PartId] FOREIGN KEY ([PartId]) REFERENCES [dbo].[Part] ([Id]),
                                CONSTRAINT [FK_Script_Audio_AudioId] FOREIGN KEY ([AudioId]) REFERENCES [dbo].[Audio] ([Id])
                            );

                            CREATE TABLE [dbo].[Question] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [Content] NVARCHAR(MAX) NOT NULL,
                                [ScriptId] INT NOT NULL,
                                [AudioId] INT,
                                CONSTRAINT [FK_Question_Script_ScriptId] FOREIGN KEY ([ScriptId]) REFERENCES [dbo].[Script] ([Id]),
                                CONSTRAINT [FK_Question_Audio_AudioId] FOREIGN KEY ([AudioId]) REFERENCES [dbo].[Audio] ([Id])
                            );

                            Create TABLE [dbo].[Image] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [Url] NVARCHAR(255) NOT NULL,
                                [ScriptId] INT NOT NULL,
                                CONSTRAINT [FK_Image_Script_ScriptId] FOREIGN KEY ([ScriptId]) REFERENCES [dbo].[Script] ([Id]),
                            );

                            CREATE TABLE [dbo].[Answer] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [Content] NVARCHAR(255) NOT NULL,
                                [IsCorrect] BIT,
                                [Explanation] NVARCHAR(MAX),
                                [QuestionId] INT NOT NULL,
                                CONSTRAINT [FK_Answer_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
                            );

                            CREATE TABLE [dbo].[DoQuestion] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [UserId] NVARCHAR(450) NOT NULL,
                                [QuestionId] INT NOT NULL,
                                [SelectedAnswer] INT,
                                CONSTRAINT [FK_DoQuestion_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),      
                                CONSTRAINT [FK_DoQuestion_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])                        
                            );
                            
                            CREATE TABLE [dbo].[Course] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [Title] NVARCHAR(500) NOT NULL,                             
                                [Price] DECIMAL(18, 2),
                                [NoPurchase] INT,
                                [Target] NVARCHAR(500),
                                [Rating] DECIMAL(18, 2),
                                [Description] NVARCHAR(MAX),
                                [TypeId] INT NOT NULL,
                                CONSTRAINT [FK_Course_Type_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[Type] ([Id])
                            );

                            CREATE TABLE [dbo].[CourseHistory] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [CourseId] INT NOT NULL,
                                [UserId] NVARCHAR(450) NOT NULL,
                                [RegistrationDate] DATETIME,
                                CONSTRAINT [FK_CourseHistory_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([Id]),
                                CONSTRAINT [FK_CourseHistory_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
                            );

                            CREATE TABLE [dbo].[PracticeLesson] (
                                [Id] INT NOT NULL PRIMARY KEY IDENTITY,
                                [Title] NVARCHAR(500) NOT NULL,
                                [Content] NVARCHAR(MAX),
                                [LinkContent] NVARCHAR(500),
                                [IsLearned] BIT,
                                [CourseId] INT NOT NULL,
                                CONSTRAINT [FK_PracticeLesson_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([Id])
                            );
                            ";



            cmd.ExecuteNonQuery();
        }
        #endregion
    }
}