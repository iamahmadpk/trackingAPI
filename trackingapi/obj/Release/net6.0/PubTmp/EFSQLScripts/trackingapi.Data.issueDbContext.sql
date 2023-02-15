IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230210094014_createdatabase')
BEGIN
    CREATE TABLE [Issues] (
        [id] int NOT NULL IDENTITY,
        [issueName] nvarchar(max) NOT NULL,
        [issueDescription] nvarchar(max) NOT NULL,
        [priority] int NOT NULL,
        [issueType] int NOT NULL,
        [created] datetime2 NOT NULL,
        [completed] datetime2 NULL,
        CONSTRAINT [PK_Issues] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230210094014_createdatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230210094014_createdatabase', N'7.0.2');
END;
GO

COMMIT;
GO

