CREATE TABLE [dbo].[UserGrid] (
    [Id]            BIGINT         NOT NULL,
    [UserName]      NVARCHAR (50)  NOT NULL,
    [DisplayName]   NVARCHAR (50)  NULL,
    [Email]         NVARCHAR (100) NULL,
    [LastLoginTime] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_UserGrid_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

