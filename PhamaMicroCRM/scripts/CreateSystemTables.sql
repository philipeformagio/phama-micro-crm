IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Companies] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(200) NOT NULL,
    [Field] varchar(100) NOT NULL,
    [Active] bit NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [CompanyUnits] (
    [Id] uniqueidentifier NOT NULL,
    [CompanyId] uniqueidentifier NOT NULL,
    [Phone_1] varchar(50) NULL,
    [Phone_2] varchar(50) NULL,
    [Phone_3] varchar(50) NULL,
    [Active] bit NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_CompanyUnits] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CompanyUnits_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Addresses] (
    [Id] uniqueidentifier NOT NULL,
    [CompanyUnitId] uniqueidentifier NOT NULL,
    [Street] varchar(200) NULL,
    [ZipCode] varchar(8) NULL,
    [State] varchar(15) NULL,
    [City] varchar(50) NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Addresses_CompanyUnits_CompanyUnitId] FOREIGN KEY ([CompanyUnitId]) REFERENCES [CompanyUnits] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Contacts] (
    [Id] uniqueidentifier NOT NULL,
    [CompanyUnitId] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Phone_1] varchar(100) NULL,
    [Phone_2] varchar(100) NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_CompanyUnits_CompanyUnitId] FOREIGN KEY ([CompanyUnitId]) REFERENCES [CompanyUnits] ([Id]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_Addresses_CompanyUnitId] ON [Addresses] ([CompanyUnitId]);

GO

CREATE INDEX [IX_CompanyUnits_CompanyId] ON [CompanyUnits] ([CompanyId]);

GO

CREATE INDEX [IX_Contacts_CompanyUnitId] ON [Contacts] ([CompanyUnitId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200610121513_Initial_Create', N'2.2.6-servicing-10079');

GO

