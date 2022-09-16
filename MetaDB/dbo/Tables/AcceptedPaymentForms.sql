CREATE TABLE [dbo].[AcceptedPaymentForms] (
    [ID]              INT        IDENTITY (1, 1) NOT NULL,
    [AdvertiserId]    INT        NOT NULL,
    [PaymentFormType] NCHAR (10) NULL,
    [CardCode]        NCHAR (20) NULL,
    [CardType]        NCHAR (6)  NULL,
    CONSTRAINT [FK_AcceptedPaymentForms_Advertiser] FOREIGN KEY ([AdvertiserId]) REFERENCES [dbo].[Advertiser] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

