CREATE TABLE [dbo].[ModuleRelationship] (
    [Id]       BIGINT IDENTITY (1, 1) NOT NULL,
    [ParentId] BIGINT NOT NULL,
    [ChildId]  BIGINT NOT NULL,
    CONSTRAINT [PK_ModuleRelationship_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ModuleRelationship_ChildId] FOREIGN KEY ([ChildId]) REFERENCES [dbo].[Module] ([Id]),
    CONSTRAINT [FK_ModuleRelationship_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Module] ([Id])
);

