CREATE TABLE [dbo].[Component] (
    [Id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Component_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

