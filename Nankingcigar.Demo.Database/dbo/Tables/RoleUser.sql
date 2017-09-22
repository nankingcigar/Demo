CREATE TABLE [dbo].[RoleUser] (
    [Id]                   BIGINT        IDENTITY (1, 1) NOT NULL,
    [RoleId]               BIGINT        NOT NULL,
    [UserId]               BIGINT        NOT NULL,
    [IsActive]             BIT           NULL,
    [CreatorUserId]        BIGINT        NULL,
    [CreationTime]         DATETIME2 (7) NOT NULL,
    [LastModifierUserId]   BIGINT        NULL,
    [LastModificationTime] DATETIME2 (7) NULL,
    [DeleterUserId]        BIGINT        NULL,
    [DeletionTime]         DATETIME2 (7) NULL,
    [IsDeleted]            BIT           NOT NULL,
    CONSTRAINT [PK_RoleUser_Id] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RoleUser_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_RoleUser_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_RoleUser_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_RoleUser_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]),
    CONSTRAINT [FK_RoleUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

