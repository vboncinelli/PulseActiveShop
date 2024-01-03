CREATE TABLE [dbo].[Order] (
    [Id]              INT      IDENTITY (1, 1) NOT NULL,
    [CustomerId]      INT      NOT NULL,
    [OrderDate]       DATETIME NOT NULL,
    [ShipToAddressId] INT      NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Address] FOREIGN KEY ([ShipToAddressId]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[User] ([Id])
);

