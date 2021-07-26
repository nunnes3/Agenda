CREATE TABLE [dbo].[tb_tarefa] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]        VARCHAR (200) NOT NULL,
    [DataCriacao]   DATETIME      NOT NULL,
    [DataConclusao] DATETIME      NULL,
    [Percentual]    INT           NOT NULL,
    [Prioridade]    VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

