CREATE TABLE [dbo].[Unit] (
    [ID]           INT         IDENTITY (1, 1) NOT NULL,
    [AdvertiserId] INT         NOT NULL,
    [Name]         NCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Unit_Advertiser] FOREIGN KEY ([AdvertiserId]) REFERENCES [dbo].[Advertiser] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

