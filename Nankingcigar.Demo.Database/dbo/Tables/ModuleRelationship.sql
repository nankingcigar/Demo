CREATE TABLE [dbo].[ModuleRelationship] (
    [Id]                   BIGINT        IDENTITY (1, 1) NOT NULL,
    [ParentId]             BIGINT        NOT NULL,
    [ChildId]              BIGINT        NOT NULL,
    [IsActive]             BIT           NULL,
    [CreatorUserId]        BIGINT        NULL,
    [CreationTime]         DATETIME2 (7) NOT NULL,
    [LastModifierUserId]   BIGINT        NULL,
    [LastModificationTime] DATETIME2 (7) NULL,
    [DeleterUserId]        BIGINT        NULL,
    [DeletionTime]         DATETIME2 (7) NULL,
    [IsDeleted]            BIT           NOT NULL,
    CONSTRAINT [PK_ModuleRelationship_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ModuleRelationship_ChildId] FOREIGN KEY ([ChildId]) REFERENCES [dbo].[Module] ([Id]),
    CONSTRAINT [FK_ModuleRelationship_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_ModuleRelationship_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_ModuleRelationship_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_ModuleRelationship_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Module] ([Id])
);

