CREATE TABLE [dbo].[BasketItem] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [UnitPrice] DECIMAL (18, 4) NOT NULL,
    [Quantity]  INT             NOT NULL,
    [ProductId] INT             NOT NULL,
    [BasketId]  INT             NOT NULL,
    CONSTRAINT [PK_BasketItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BasketItem_Basket] FOREIGN KEY ([BasketId]) REFERENCES [dbo].[Basket] ([Id]),
    CONSTRAINT [FK_BasketItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

