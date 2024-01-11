CREATE TABLE [dbo].[User] (
    [Id]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Username] NVARCHAR (50)    NOT NULL,
    [Email]    NVARCHAR (50)    NOT NULL,
    [Password] NVARCHAR (128)   NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);



