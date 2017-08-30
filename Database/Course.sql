CREATE TABLE [dbo].[Course]
(
    [Department] NVARCHAR(10) NOT NULL, 
    [Number] INT NOT NULL, 
    [Title] NVARCHAR(50) NULL, 
    [Description] NCHAR(10) NULL, 
    [Hours] NCHAR(10) NULL, 
    CONSTRAINT [PK_Course] PRIMARY KEY ([Department],[Number]) 
)
