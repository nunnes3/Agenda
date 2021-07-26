CREATE TABLE [dbo].[tb_compromisso] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Assunto]     VARCHAR (200) NOT NULL,
    [Local]       VARCHAR (200) NOT NULL,
    [Data]        DATETIME      NOT NULL,
    [HoraInicio]  TIME (7)      NOT NULL,
    [HoraTermino] TIME (7)      NOT NULL,
    [IdContato]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdContato]) REFERENCES [dbo].[tb_contato] ([Id])
);

