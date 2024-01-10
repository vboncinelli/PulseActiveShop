CREATE TABLE [dbo].[Order] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [CustomerId]      INT            NOT NULL,
    [OrderDate]       DATETIME       NOT NULL,
    [Street]          NVARCHAR (128) NOT NULL,
    [City]            NVARCHAR (128) NOT NULL,
    [StateOrProvince] NVARCHAR (128) NOT NULL,
    [Country]         NVARCHAR (128) NOT NULL,
    [ZipCode]         NVARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[User] ([Id])
);



