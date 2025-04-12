CREATE TABLE [dbo].[Dreams] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Value]        DECIMAL           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);