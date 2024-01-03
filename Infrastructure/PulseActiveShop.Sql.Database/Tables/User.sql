﻿CREATE TABLE [dbo].[User] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50)  NOT NULL,
    [Email]    NVARCHAR (50)  NOT NULL,
    [Password] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

