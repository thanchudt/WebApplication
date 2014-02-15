CREATE TABLE [tmp].[Currency] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL UNIQUE,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [tmp].[UserProfile] (
    [UserId]   INT            IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (MAX) NULL UNIQUE,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

CREATE TABLE [tmp].[ItemType] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Type]     NVARCHAR (MAX) NOT NULL UNIQUE,
    [ParentId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_dbo.ItemType_dbo.ItemType_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [tmp].[ItemType] ([Id])
);

CREATE TABLE [tmp].[Item] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL UNIQUE,
    [ItemTypeId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_dbo.Item_dbo.Item_ItemTypeId] FOREIGN KEY ([ItemTypeId]) REFERENCES [tmp].[ItemType] ([Id])
);

CREATE TABLE [tmp].[Price] (
    [Id]             INT        IDENTITY (1, 1) NOT NULL,
    [Value]          FLOAT (53) NOT NULL,
    [ItemId]         INT        NOT NULL,
    [CurrencyId]     INT        NOT NULL,
    [UploadByUserId] INT        NOT NULL,
    [UpdateDate]     DATETIME   NOT NULL,
    [EffStartDate]   DATETIME   NOT NULL,
    [EffEndDate]     DATETIME   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Price_dbo.Currency_Id] FOREIGN KEY ([CurrencyId]) REFERENCES [tmp].[Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Price_dbo.UserProfile_Id] FOREIGN KEY ([UploadByUserId]) REFERENCES [tmp].[UserProfile] ([UserId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Price_dbo.Price_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [tmp].[Item] ([Id]) ON DELETE CASCADE
);





