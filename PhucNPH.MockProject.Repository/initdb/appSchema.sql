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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220814145348_initdb')
BEGIN
    CREATE TABLE [Employees] (
        [Id] uniqueidentifier NOT NULL,
        [Username] nvarchar(450) NOT NULL,
        [DOB] datetime2 NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [YearExperience] int NOT NULL,
        [Deleted] bit NOT NULL,
        [RecordVersion] bigint NOT NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220814145348_initdb')
BEGIN
    CREATE UNIQUE INDEX [IX_Employees_Username] ON [Employees] ([Username]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220814145348_initdb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220814145348_initdb', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    ALTER TABLE [Employees] DROP CONSTRAINT [PK_Employees];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'RecordVersion');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Employees] DROP COLUMN [RecordVersion];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    ALTER TABLE [Employees] ADD [DepartmentId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    ALTER TABLE [Employees] ADD [JobDetailId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    ALTER TABLE [Employees] ADD CONSTRAINT [EmployeeId] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    CREATE TABLE [Departments] (
        [Id] uniqueidentifier NOT NULL,
        [DepartmentName] nvarchar(max) NOT NULL,
        [DepartmentLocation] nvarchar(max) NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Departments] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    CREATE TABLE [JobDetail] (
        [Id] uniqueidentifier NOT NULL,
        [JobTitle] nvarchar(max) NOT NULL,
        [JobDescription] nvarchar(max) NOT NULL,
        [JobLevel] int NOT NULL,
        CONSTRAINT [PK_JobDetail] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    CREATE INDEX [IX_Employees_DepartmentId] ON [Employees] ([DepartmentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    CREATE UNIQUE INDEX [IX_Employees_JobDetailId] ON [Employees] ([JobDetailId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    ALTER TABLE [Employees] ADD CONSTRAINT [FK_Employees_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    ALTER TABLE [Employees] ADD CONSTRAINT [FK_Employees_JobDetail_JobDetailId] FOREIGN KEY ([JobDetailId]) REFERENCES [JobDetail] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220828043632_update_jobdetail_department_entities')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220828043632_update_jobdetail_department_entities', N'6.0.8');
END;
GO

COMMIT;
GO

