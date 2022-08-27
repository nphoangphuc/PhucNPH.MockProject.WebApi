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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220827142932_add_jobtitle_department_entity')
BEGIN
    ALTER TABLE [Employees] DROP CONSTRAINT [PK_Employees];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220827142932_add_jobtitle_department_entity')
BEGIN
    ALTER TABLE [Employees] ADD CONSTRAINT [EmployeeId] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220827142932_add_jobtitle_department_entity')
BEGIN
    CREATE TABLE [Departments] (
        [Id] uniqueidentifier NOT NULL,
        [DepartmentName] nvarchar(max) NOT NULL,
        [DepartmentLocation] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Departments] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220827142932_add_jobtitle_department_entity')
BEGIN
    CREATE TABLE [JobDetail] (
        [Id] uniqueidentifier NOT NULL,
        [JobTitle] nvarchar(max) NOT NULL,
        [JobDescription] nvarchar(max) NOT NULL,
        [JobLevel] int NOT NULL,
        CONSTRAINT [PK_JobDetail] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_JobDetail_Employees_Id] FOREIGN KEY ([Id]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220827142932_add_jobtitle_department_entity')
BEGIN
    ALTER TABLE [Employees] ADD CONSTRAINT [FK_Employees_Departments_Id] FOREIGN KEY ([Id]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220827142932_add_jobtitle_department_entity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220827142932_add_jobtitle_department_entity', N'6.0.8');
END;
GO

COMMIT;
GO

