CREATE TABLE [dbo].[RoleApi] (
    [Id]                   BIGINT        IDENTITY (1, 1) NOT NULL,
    [RoleId]               BIGINT        NOT NULL,
    [ApiId]                BIGINT        NOT NULL,
    [IsActive]             BIT           NULL,
    [CreatorUserId]        BIGINT        NULL,
    [CreationTime]         DATETIME2 (7) NOT NULL,
    [LastModifierUserId]   BIGINT        NULL,
    [LastModificationTime] DATETIME2 (7) NULL,
    [DeleterUserId]        BIGINT        NULL,
    [DeletionTime]         DATETIME2 (7) NULL,
    [IsDeleted]            BIT           NOT NULL,
    CONSTRAINT [PK_RoleApi_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RoleApi_ApiId] FOREIGN KEY ([ApiId]) REFERENCES [dbo].[Api] ([Id]),
    CONSTRAINT [FK_RoleApi_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_RoleApi_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_RoleApi_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_RoleApi_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
);

