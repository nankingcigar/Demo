CREATE TABLE [dbo].[Module] (
    [Id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [RequiredLogin] BIT           NOT NULL,
    CONSTRAINT [PK_Module_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

