CREATE TABLE [dbo].[Api] (
    [Id]                   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Namespace]            NVARCHAR (50) NOT NULL,
    [ClassName]            NVARCHAR (20) NOT NULL,
    [MethodName]           NVARCHAR (20) NOT NULL,
    [IsActive]             BIT           NULL,
    [CreatorUserId]        BIGINT        NULL,
    [CreationTime]         DATETIME2 (7) NOT NULL,
    [LastModifierUserId]   BIGINT        NULL,
    [LastModificationTime] DATETIME2 (7) NULL,
    [DeleterUserId]        BIGINT        NULL,
    [DeletionTime]         DATETIME2 (7) NULL,
    [IsDeleted]            BIT           NOT NULL,
    CONSTRAINT [PK_Api_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Api_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Api_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Api_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[User] ([Id])
);

