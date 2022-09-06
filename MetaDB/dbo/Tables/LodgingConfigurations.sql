CREATE TABLE [dbo].[LodgingConfigurations] (
    [ID]                    INT          IDENTITY (1, 1) NOT NULL,
    [AdvertiserId]          INT          NULL,
    [UnitId]                INT          NULL,
    [ChildrenAllowed]       BIT          NULL,
    [EventsAllowedRule]     BIT          NULL,
    [PetsAllowed]           BIT          NULL,
    [SmokingAllowed]        BIT          NULL,
    [BookingPolicy]         NCHAR (10)   NULL,
    [CancellationPolicy]    NCHAR (10)   NULL,
    [CheckInTime]           NCHAR (10)   NULL,
    [CheckOutTime]          NCHAR (10)   NULL,
    [lastUpdatedDate]       NCHAR (60)   NULL,
    [MaximumOccupancy]      INT          NULL,
    [MaximumAge]            INT          NULL,
    [PricingPolicy]         NCHAR (20)   NULL,
    [RentalAgreementPdfUrl] NCHAR (1000) NULL,
    CONSTRAINT [CK_AdvertiserId_OR_UnitId_Allowed_Only] CHECK (case when [AdvertiserId] IS NOT NULL AND [UnitId] IS NULL OR [AdvertiserId] IS NULL AND [UnitId] IS NOT NULL then (1) else (0) end=(1)),
    CONSTRAINT [FK_LodgingConfigurations_Advertiser] FOREIGN KEY ([AdvertiserId]) REFERENCES [dbo].[Advertiser] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_LodgingConfigurations_Unit] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Advertiser] ([ID])
);

