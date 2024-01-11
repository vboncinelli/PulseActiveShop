CREATE TABLE [dbo].[ProductType] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Type]        NVARCHAR (50)    NOT NULL,
    [Description] NVARCHAR (255)   NULL,
    CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED ([Id] ASC)
);



