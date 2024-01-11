CREATE TABLE [dbo].[OrderItem] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [ProductId]   UNIQUEIDENTIFIER NOT NULL,
    [ProductName] NVARCHAR (50)    NOT NULL,
    [PictureUri]  NVARCHAR (255)   NOT NULL,
    [UnitPrice]   DECIMAL (18, 4)  NOT NULL,
    [Units]       INT              NOT NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);



