CREATE TABLE [dbo].[UserRoute] (
    [Id]            BIGINT IDENTITY (1, 1) NOT NULL,
    [UserId]        BIGINT NOT NULL,
    [RouteId]       BIGINT NOT NULL,
    [HasPermission] BIT    NOT NULL,
    CONSTRAINT [PK_UserRoute_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserRoute_RouteId] FOREIGN KEY ([RouteId]) REFERENCES [dbo].[Route] ([Id]),
    CONSTRAINT [FK_UserRoute_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

