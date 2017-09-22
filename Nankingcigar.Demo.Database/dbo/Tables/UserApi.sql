CREATE TABLE [dbo].[UserApi] (
    [Id]                   BIGINT        IDENTITY (1, 1) NOT NULL,
    [UserId]               BIGINT        NOT NULL,
    [ApiId]               BIGINT        NOT NULL,
    [HasPermission]        BIT           NOT NULL,
    [IsActive]             BIT           NULL,
    [CreatorUserId]        BIGINT        NULL,
    [CreationTime]         DATETIME2 (7) NOT NULL,
    [LastModifierUserId]   BIGINT        NULL,
    [LastModificationTime] DATETIME2 (7) NULL,
    [DeleterUserId]        BIGINT        NULL,
    [DeletionTime]         DATETIME2 (7) NULL,
    [IsDeleted]            BIT           NOT NULL,
    CONSTRAINT [PK_UserApi_Id] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserApi_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserApi_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserApi_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserApi_ApiId] FOREIGN KEY (ApiId) REFERENCES [dbo].Api ([Id]),
    CONSTRAINT [FK_UserApi_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

