CREATE TABLE [dbo].[Role] (
    [Id]                   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (50) NOT NULL,
    [IsActive]             BIT           NULL,
    [CreatorUserId]        BIGINT        NULL,
    [CreationTime]         DATETIME2 (7) NOT NULL,
    [LastModifierUserId]   BIGINT        NULL,
    [LastModificationTime] DATETIME2 (7) NULL,
    [DeleterUserId]        BIGINT        NULL,
    [DeletionTime]         DATETIME2 (7) NULL,
    [IsDeleted]            BIT           NOT NULL,
    CONSTRAINT [PK_Role_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Role_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Role_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Role_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[User] ([Id])
);

