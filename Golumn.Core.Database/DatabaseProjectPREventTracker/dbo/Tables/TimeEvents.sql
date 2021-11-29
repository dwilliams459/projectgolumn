CREATE TABLE [dbo].[TimeEvents] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [EventDate]   DATETIME2 (7)   NOT NULL,
    [UserStory]   INT             NULL,
    [Length]      DECIMAL (18, 2) NULL,
    [Description] NVARCHAR (MAX)  NULL,
    [Contract]    NVARCHAR (MAX)  NULL,
    [Workstream]  NVARCHAR (MAX)  NULL,
    [Parent]      NVARCHAR (MAX)  NULL,
    [Name]        NVARCHAR (MAX)  NULL,
    [ParentId]    NVARCHAR (MAX)  NULL,
    [UserId]      NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_TimeEvents] PRIMARY KEY CLUSTERED ([Id] ASC)
);

