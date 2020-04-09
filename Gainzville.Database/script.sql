IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [ExerciseType] (
    [ExerciseTypeId] uniqueidentifier NOT NULL DEFAULT ((newsequentialid())),
    [Name] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_ExerciseType] PRIMARY KEY ([ExerciseTypeId])
);

GO

CREATE TABLE [Profile] (
    [ProfileId] uniqueidentifier NOT NULL DEFAULT ((newsequentialid())),
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [CreatedDate] datetime2 NOT NULL DEFAULT ((getutcdate())),
    [DateOfBirth] datetime2 NOT NULL,
    [Height] real NOT NULL,
    [Aim] nvarchar(max) NULL,
    CONSTRAINT [PK_Profile] PRIMARY KEY ([ProfileId])
);

GO

CREATE TABLE [ExerciseReading] (
    [ExerciseReadingId] uniqueidentifier NOT NULL DEFAULT ((newsequentialid())),
    [ProfileId] uniqueidentifier NOT NULL,
    [ExerciseTypeId] uniqueidentifier NOT NULL,
    [DateOfReading] datetime2 NOT NULL,
    [Mass] real NOT NULL,
    [Reps] int NOT NULL,
    CONSTRAINT [PK_ExerciseReading] PRIMARY KEY ([ExerciseReadingId]),
    CONSTRAINT [FK_ExerciseReading_ExerciseType] FOREIGN KEY ([ExerciseTypeId]) REFERENCES [ExerciseType] ([ExerciseTypeId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ExerciseReading_Profile] FOREIGN KEY ([ProfileId]) REFERENCES [Profile] ([ProfileId]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_ExerciseReading_ExerciseTypeId] ON [ExerciseReading] ([ExerciseTypeId]);

GO

CREATE INDEX [IX_ExerciseReading_ProfileId] ON [ExerciseReading] ([ProfileId]);

GO

CREATE UNIQUE INDEX [AK_ExerciseTypeName] ON [ExerciseType] ([Name]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200401230109_InitialCreate', N'3.1.1');

GO

