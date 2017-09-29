CREATE TABLE [dbo].[Route] (
    [Id]                   BIGINT         IDENTITY (1, 1) NOT NULL,
    [Path]                 NVARCHAR (50)  NOT NULL,
    [ModuleRelationshipId] BIGINT         NULL,
    [ModuleComponentId]    BIGINT         NULL,
    [ModuleId]             BIGINT         NULL,
    [Config]               NVARCHAR (200) NULL,
    [IsActive]             BIT            NULL,
    [CreatorUserId]        BIGINT         NULL,
    [CreationTime]         DATETIME2 (7)  NOT NULL,
    [LastModifierUserId]   BIGINT         NULL,
    [LastModificationTime] DATETIME2 (7)  NULL,
    [DeleterUserId]        BIGINT         NULL,
    [DeletionTime]         DATETIME2 (7)  NULL,
    [IsDeleted]            BIT            NOT NULL,
    CONSTRAINT [PK_Route_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Route_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Route_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Route_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Route_ModuleComponentId] FOREIGN KEY ([ModuleComponentId]) REFERENCES [dbo].[ModuleComponent] ([Id]),
    CONSTRAINT [FK_Route_ModuleId] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[ModuleComponent] ([Id]),
    CONSTRAINT [FK_Route_ModuleRelationshipId] FOREIGN KEY ([ModuleRelationshipId]) REFERENCES [dbo].[ModuleRelationship] ([Id])
);

