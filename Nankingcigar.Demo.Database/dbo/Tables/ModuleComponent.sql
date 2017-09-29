CREATE TABLE [dbo].[ModuleComponent] (
    [Id]                   BIGINT        IDENTITY (1, 1) NOT NULL,
    [ModuleId]             BIGINT        NOT NULL,
    [ComponentId]          BIGINT        NOT NULL,
    [IsActive]             BIT           NULL,
    [CreatorUserId]        BIGINT        NULL,
    [CreationTime]         DATETIME2 (7) NOT NULL,
    [LastModifierUserId]   BIGINT        NULL,
    [LastModificationTime] DATETIME2 (7) NULL,
    [DeleterUserId]        BIGINT        NULL,
    [DeletionTime]         DATETIME2 (7) NULL,
    [IsDeleted]            BIT           NOT NULL,
    CONSTRAINT [PK_ModuleComponent_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ModuleComponent_ComponentId] FOREIGN KEY ([ComponentId]) REFERENCES [dbo].[Component] ([Id]),
    CONSTRAINT [FK_ModuleComponent_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_ModuleComponent_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_ModuleComponent_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_ModuleComponent_ModuleId] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Module] ([Id])
);

