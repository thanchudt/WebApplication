CREATE TABLE [dbo].[ItemType] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Type]     NVARCHAR (MAX) NOT NULL,
    [ParentId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_dbo.ItemType_dbo.ItemType_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[ItemType] ([Id])
);

CREATE TABLE [dbo].[Item] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [ItemTypeId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_dbo.Item_dbo.Item_ItemTypeId] FOREIGN KEY ([ItemTypeId]) REFERENCES [dbo].[ItemType] ([Id])
);

CREATE TABLE [dbo].[Price] (
    [Id]             INT        IDENTITY (1, 1) NOT NULL,
    [Value]          FLOAT (53) NOT NULL,
    [ItemId]         INT        NOT NULL,
    [CurrencyId]     INT        NOT NULL,
    [UploadByUserId] INT        NOT NULL,
    [UploadDate]     DATETIME   NOT NULL,
    [EffStartDate]   DATETIME   NOT NULL,
    [EffEndDate]     DATETIME   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Price_dbo.Currency_Id] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Price_dbo.UserProfile_Id] FOREIGN KEY ([UploadByUserId]) REFERENCES [dbo].[UserProfile] ([UserId]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Price_dbo.Price_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([Id]) ON DELETE CASCADE
);



