IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ClassificacaoPaciente] (
    [ClassificacaoPacienteId] int NOT NULL IDENTITY,
    [PacienteId] int NOT NULL,
    [ValorResultadoClassificacao] int NOT NULL,
    [ValorResultadoCor] int NOT NULL,
    [ResultadoClassificacaoCor] int NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_ClassificacaoPaciente] PRIMARY KEY ([ClassificacaoPacienteId])
);
GO

CREATE TABLE [Paciente] (
    [PacienteId] int NOT NULL IDENTITY,
    [telefone] varchar(11) NOT NULL,
    [rua] varchar(100) NOT NULL,
    [numero] int NOT NULL,
    [bairro] varchar(100) NOT NULL,
    [municipio] varchar(100) NOT NULL,
    [uf] varchar(2) NOT NULL,
    [cep] int NOT NULL,
    [sexo] char(1) NOT NULL,
    [profissao] varchar(50) NOT NULL,
    [SenhaClassificacao] nvarchar(max) NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    [nome] varchar(100) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [cpf] varchar(11) NOT NULL,
    [rg] varchar(8) NOT NULL,
    [celular] varchar(11) NOT NULL,
    [email] varchar(100) NOT NULL,
    CONSTRAINT [PK_Paciente] PRIMARY KEY ([PacienteId])
);
GO

CREATE TABLE [Pergunta] (
    [PerguntaId] int NOT NULL IDENTITY,
    [DescricaoPergunta] varchar(250) NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_Pergunta] PRIMARY KEY ([PerguntaId])
);
GO

CREATE TABLE [PerguntaSelecionadaPaciente] (
    [PerguntaSelecionadaPacienteId] int NOT NULL IDENTITY,
    [PerguntaId] int NOT NULL,
    [PacienteId] int NOT NULL,
    [ClassificacaoPacienteId] int NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_PerguntaSelecionadaPaciente] PRIMARY KEY ([PerguntaSelecionadaPacienteId])
);
GO

CREATE TABLE [Resposta] (
    [RespostaId] int NOT NULL IDENTITY,
    [RespostaTexto] bit NOT NULL,
    [RespostaTextoArea] bit NOT NULL,
    [RespostaCheckBox] varchar(100) NOT NULL,
    [RespostaComboBox] varchar(100) NOT NULL,
    [RespostaRadioButtom] varchar(100) NOT NULL,
    [RespostaData] Datetime NULL,
    [ValorTipoResposta] int NOT NULL,
    [ValorResposta] int NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_Resposta] PRIMARY KEY ([RespostaId])
);
GO

CREATE TABLE [RespostaSelecionadaPaciente] (
    [RespostaSelecionadaPacienteId] int NOT NULL IDENTITY,
    [RespostaId] int NOT NULL,
    [ValorRespostaTexto] varchar(100) NULL,
    [ValorRespostaTextoArea] varchar(max) NULL,
    [PacienteId] int NOT NULL,
    [ClassificacaoPacienteId] int NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_RespostaSelecionadaPaciente] PRIMARY KEY ([RespostaSelecionadaPacienteId])
);
GO

CREATE TABLE [Usuario] (
    [UsuarioId] int NOT NULL IDENTITY,
    [coren] varchar(8) NOT NULL,
    [crm] varchar(8) NOT NULL,
    [senha] varchar(8) NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    [nome] varchar(100) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [cpf] varchar(11) NOT NULL,
    [rg] varchar(8) NOT NULL,
    [celular] varchar(11) NOT NULL,
    [email] varchar(100) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([UsuarioId])
);
GO

CREATE TABLE [Responsavel] (
    [ResponsavelId] int NOT NULL IDENTITY,
    [PacienteId] int NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    [nome] varchar(100) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [cpf] varchar(11) NOT NULL,
    [rg] varchar(8) NOT NULL,
    [celular] varchar(11) NOT NULL,
    [email] varchar(100) NOT NULL,
    CONSTRAINT [PK_Responsavel] PRIMARY KEY ([ResponsavelId]),
    CONSTRAINT [FK_Responsavel_Paciente_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Paciente] ([PacienteId])
);
GO

CREATE TABLE [CategoriaPergunta] (
    [CategoriaPerguntaId] int NOT NULL IDENTITY,
    [PerguntaId] int NOT NULL,
    [Descricao] varchar(100) NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_CategoriaPergunta] PRIMARY KEY ([CategoriaPerguntaId]),
    CONSTRAINT [FK_CategoriaPergunta_Pergunta_PerguntaId] FOREIGN KEY ([PerguntaId]) REFERENCES [Pergunta] ([PerguntaId]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_CategoriaPergunta_PerguntaId] ON [CategoriaPergunta] ([PerguntaId]);
GO

CREATE UNIQUE INDEX [IX_Paciente_celular] ON [Paciente] ([celular]);
GO

CREATE UNIQUE INDEX [IX_Paciente_cpf] ON [Paciente] ([cpf]);
GO

CREATE UNIQUE INDEX [IX_Responsavel_celular] ON [Responsavel] ([celular]);
GO

CREATE UNIQUE INDEX [IX_Responsavel_cpf] ON [Responsavel] ([cpf]);
GO

CREATE UNIQUE INDEX [IX_Responsavel_PacienteId] ON [Responsavel] ([PacienteId]) WHERE [PacienteId] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_Usuario_celular] ON [Usuario] ([celular]);
GO

CREATE UNIQUE INDEX [IX_Usuario_cpf] ON [Usuario] ([cpf]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231017003124_inicial', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE SEQUENCE PacienteSequence START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1
GO

CREATE SEQUENCE ResponsavelSequence START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE CACHE 1
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231023102656_sequence_paciente', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231102005348_Ajustar relacao categoria e pergunta', N'7.0.12');
GO

COMMIT;
GO

