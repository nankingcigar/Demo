CREATE TABLE [dbo].[ModuleComponent] (
    [Id]          BIGINT IDENTITY (1, 1) NOT NULL,
    [ModuleId]    BIGINT NOT NULL,
    [ComponentId] BIGINT NOT NULL,
    CONSTRAINT [PK_ModuleComponent_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ModuleComponent_ComponentId] FOREIGN KEY ([ComponentId]) REFERENCES [dbo].[Component] ([Id]),
    CONSTRAINT [FK_ModuleComponent_ModuleId] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Module] ([Id])
);

