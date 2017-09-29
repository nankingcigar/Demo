CREATE TABLE [dbo].[RoleRoute] (
    [Id]            BIGINT IDENTITY (1, 1) NOT NULL,
    [RoleId]        BIGINT NULL,
    [RouteId]       BIGINT NULL,
    [HasPermission] BIT    NOT NULL,
    CONSTRAINT [PK_RoleRoute_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RoleRoute_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]),
    CONSTRAINT [FK_RoleRoute_UserId] FOREIGN KEY ([RouteId]) REFERENCES [dbo].[Route] ([Id])
);

