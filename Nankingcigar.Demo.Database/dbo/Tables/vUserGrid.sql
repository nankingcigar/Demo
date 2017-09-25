CREATE TABLE [dbo].[vUserGrid] (
    [Id]            BIGINT         NOT NULL,
    [Name]      NVARCHAR (50)  NOT NULL,
    [Display]   NVARCHAR (50)  NULL,
    [Email]         NVARCHAR (100) NULL,
    [LastLoginTime] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_vUserGrid_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

