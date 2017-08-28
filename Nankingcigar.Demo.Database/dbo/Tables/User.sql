CREATE TABLE [dbo].[User] (
    [Id]                   BIGINT             IDENTITY (1, 1) NOT NULL,
    [UserName]             NVARCHAR (50)      NOT NULL,
    [Password]             NVARCHAR (500)     NOT NULL,
    [DisplayName]          NVARCHAR (50)      NULL,
    [AuthenticationSource] NVARCHAR (50)      NULL,
    [LastLoginTime]        DATETIMEOFFSET (7) NULL,
    [IsActive]             BIT                NULL,
    [CreatorUserId]        BIGINT             NULL,
    [CreationTime]         DATETIMEOFFSET (7) NULL,
    [LastModifierUserId]   BIGINT             NULL,
    [LastModificationTime] DATETIMEOFFSET (7) NULL,
    [DeleterUserId]        BIGINT             NULL,
    [DeletionTime]         DATETIMEOFFSET (7) NULL,
    [IsDeleted]            BIT                NULL,
    CONSTRAINT [PK_User_Id] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_User_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_User_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[User] ([Id])
);







