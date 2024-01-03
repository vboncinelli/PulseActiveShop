CREATE TABLE [dbo].[Address] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [UserId]          INT            NOT NULL,
    [Street]          NVARCHAR (128) NOT NULL,
    [City]            NVARCHAR (128) NOT NULL,
    [StateOrProvince] NVARCHAR (128) NOT NULL,
    [Country]         NVARCHAR (128) NOT NULL,
    [ZipCode]         NVARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Address_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

