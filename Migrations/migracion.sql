IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Albums] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Style] int NOT NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190621102544_Inicial', N'3.0.0-preview6.19304.10');

GO

ALTER TABLE [Albums] ADD [Year] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [Bands] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Bands] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190621103916_Banda', N'3.0.0-preview6.19304.10');

GO

