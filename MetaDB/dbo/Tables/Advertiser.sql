CREATE TABLE [dbo].[Advertiser] (
    [ID]             INT         IDENTITY (1, 1) NOT NULL,
    [AdvertiserId]   NCHAR (10)  NOT NULL,
    [AdvertiserName] NCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

