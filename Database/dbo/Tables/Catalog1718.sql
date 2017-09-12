CREATE TABLE [dbo].[Catalog1718] (
    [Subject]         NVARCHAR (4)    NOT NULL,
    [Number]          INT             NOT NULL,
    [Name]            NVARCHAR (100)  NOT NULL,
    [Description]     NVARCHAR (1150) NOT NULL,
    [Hours]           NVARCHAR (15)   NOT NULL,
    [Offered]         NVARCHAR (75)   NULL,
    [Prerequisites]   NVARCHAR (510)  NULL,
    [Corequisites]    NVARCHAR (120)  NULL,
    [Requirements]    NVARCHAR (550)  NULL,
    [Recommendations] NVARCHAR (225)  NULL,
    [GE]              NVARCHAR (75)   NULL,
    [SameAs]          NVARCHAR (125)  NULL
);

