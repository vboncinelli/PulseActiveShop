CREATE TABLE [dbo].[BasketItem] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UnitPrice] DECIMAL (18, 4)  NOT NULL,
    [Quantity]  INT              NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [BasketId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_BasketItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BasketItem_Basket] FOREIGN KEY ([BasketId]) REFERENCES [dbo].[Basket] ([Id]),
    CONSTRAINT [FK_BasketItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);



