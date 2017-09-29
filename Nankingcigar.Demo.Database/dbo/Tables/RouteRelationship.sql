CREATE TABLE [dbo].[RouteRelationship] (
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
    CONSTRAINT [PK_RouteRelationship_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RouteRelationship_ChildId] FOREIGN KEY ([ChildId]) REFERENCES [dbo].[Route] ([Id]),
    CONSTRAINT [FK_RouteRelationship_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_RouteRelationship_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_RouteRelationship_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_RouteRelationship_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Route] ([Id])
);

