CREATE TABLE [dbo].[RouteRelationship] (
    [Id]       BIGINT IDENTITY (1, 1) NOT NULL,
    [ParentId] BIGINT NOT NULL,
    [ChildId]  BIGINT NOT NULL,
    CONSTRAINT [PK_RouteRelationship_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RouteRelationship_ChildId] FOREIGN KEY ([ChildId]) REFERENCES [dbo].[Route] ([Id]),
    CONSTRAINT [FK_RouteRelationship_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Route] ([Id])
);

