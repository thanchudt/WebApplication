CREATE TABLE [dbo].[Currency] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
	UNIQUE NONCLUSTERED ([Name] ASC),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[UserProfile] (
    [UserId]   INT            IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (256) NULL,
	UNIQUE NONCLUSTERED ([UserName] ASC),
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

CREATE TABLE [dbo].[ItemType] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Type]     NVARCHAR (256) NOT NULL,
    [ParentId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	UNIQUE NONCLUSTERED ([Type] ASC),
	CONSTRAINT [FK_dbo.ItemType_dbo.ItemType_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[ItemType] ([Id])
);

CREATE TABLE [dbo].[Item] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (256) NOT NULL,
    [ItemTypeId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	UNIQUE NONCLUSTERED ([Name] ASC),
	CONSTRAINT [FK_dbo.Item_dbo.Item_ItemTypeId] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id])
);

CREATE TABLE [dbo].[Price] (
    [Id]             INT        IDENTITY (1, 1) NOT NULL,
    [Value]          FLOAT (53) NOT NULL,
    [ItemId]         INT        NOT NULL,
    [CurrencyId]     INT        NOT NULL,
    [UploadByUserId] INT        NOT NULL,
    [UpdateDate]     DATETIME   NOT NULL,
    [EffStartDate]   DATETIME   NOT NULL,
    [EffEndDate]     DATETIME   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Price_dbo.Currency_Id] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Price_dbo.UserProfile_Id] FOREIGN KEY ([UploadByUserId]) REFERENCES [dbo].[UserProfile] ([UserId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Price_dbo.Price_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([Id]) ON DELETE CASCADE
);

--ALTER TABLE UserProfile alter column UserName NVARCHAR (256) NOT NULL
--ALTER TABLE UserProfile
--ADD UNIQUE (UserName)

