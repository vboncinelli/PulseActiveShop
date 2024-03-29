﻿CREATE TABLE [dbo].[Product] (
    [Id]            UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]          NVARCHAR (50)    NOT NULL,
    [Description]   NVARCHAR (255)   NULL,
    [Price]         DECIMAL (18, 4)  NOT NULL,
    [PictureUri]    NVARCHAR (255)   NULL,
    [ProductTypeId] UNIQUEIDENTIFIER NOT NULL,
    [BrandId]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_Brand] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([Id]),
    CONSTRAINT [FK_Product_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([Id])
);



