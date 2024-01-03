CREATE TABLE [dbo].[ProductType] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Type]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (255) NULL,
    CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

