﻿CREATE TABLE [dbo].[Basket] (
    [Id]         UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Basket] PRIMARY KEY CLUSTERED ([Id] ASC)
);



