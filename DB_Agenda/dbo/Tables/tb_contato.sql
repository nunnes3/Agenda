CREATE TABLE [dbo].[tb_contato] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (200) NOT NULL,
    [Email]    VARCHAR (50)  NOT NULL,
    [Telefone] VARCHAR (15)  NOT NULL,
    [Empresa]  VARCHAR (50)  NOT NULL,
    [Cargo]    VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

