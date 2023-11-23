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

CREATE TABLE [CategoriaPergunta] (
    [CategoriaPerguntaId] int NOT NULL DEFAULT (NEXT VALUE FOR CategoriaPerguntaSequence),
    [Descricao] varchar(100) NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_CategoriaPergunta] PRIMARY KEY ([CategoriaPerguntaId])
);
GO

CREATE TABLE [ClassificacaoPaciente] (
    [ClassificacaoPacienteId] int NOT NULL DEFAULT (NEXT VALUE FOR ClassificacaoPacienteSequence),
    [PacienteId] int NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_ClassificacaoPaciente] PRIMARY KEY ([ClassificacaoPacienteId])
);
GO

CREATE TABLE [Paciente] (
    [PacienteId] int NOT NULL DEFAULT (NEXT VALUE FOR PacienteSequence),
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

CREATE TABLE [PerguntaSelecionadaPaciente] (
    [PerguntaSelecionadaPacienteId] int NOT NULL DEFAULT (NEXT VALUE FOR PerguntaSelecionadaPacienteSequence),
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
    [RespostaId] int NOT NULL DEFAULT (NEXT VALUE FOR RespostaSequence),
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
    [RespostaSelecionadaPacienteId] int NOT NULL DEFAULT (NEXT VALUE FOR RespostaSelecionadaSequence),
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
    [UsuarioId] int NOT NULL DEFAULT (NEXT VALUE FOR UsuarioSequence),
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

CREATE TABLE [Pergunta] (
    [PerguntaId] int NOT NULL DEFAULT (NEXT VALUE FOR PerguntaSequence),
    [DescricaoPergunta] varchar(250) NOT NULL,
    [CategoriaPerguntaId] int NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_Pergunta] PRIMARY KEY ([PerguntaId]),
    CONSTRAINT [FK_Pergunta_CategoriaPergunta_CategoriaPerguntaId] FOREIGN KEY ([CategoriaPerguntaId]) REFERENCES [CategoriaPergunta] ([CategoriaPerguntaId])
);
GO

CREATE TABLE [Responsavel] (
    [ResponsavelId] int NOT NULL DEFAULT (NEXT VALUE FOR ResponsavelSequence),
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

CREATE UNIQUE INDEX [IX_Paciente_celular] ON [Paciente] ([celular]);
GO

CREATE UNIQUE INDEX [IX_Paciente_cpf] ON [Paciente] ([cpf]);
GO

CREATE INDEX [IX_Pergunta_CategoriaPerguntaId] ON [Pergunta] ([CategoriaPerguntaId]);
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
VALUES (N'20231114013131_Inicial', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [RespostaSelecionadaPaciente] ADD [PerguntaId] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231114110915_Add pergunta id em RespostaSelecionadaPaciente', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE SEQUENCE ResultadoSequence START WITH 1 INCREMENT BY 1
GO

CREATE TABLE [Resultado] (
    [ResultadoId] int NOT NULL DEFAULT (NEXT VALUE FOR ResultadoSequence),
    [PacienteId] int NOT NULL,
    [ClassificacaoPacienteId] int NOT NULL,
    [ValorResultadoClassificacao] int NOT NULL,
    [ResultadoCor] int NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_Resultado] PRIMARY KEY ([ResultadoId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231117012525_Resultado', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Resultado] ADD [ResultadoClassificacaoCor] varchar(100) NOT NULL DEFAULT '';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231117032912_Add Resultado Classificacao Cor', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE Resultado ADD CONSTRAINT unico_resultado_classificacao UNIQUE (ClassificacaoPacienteId)
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231117114647_Resultado unico', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paciente]') AND [c].[name] = N'SenhaClassificacao');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Paciente] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Paciente] DROP COLUMN [SenhaClassificacao];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231120000845_Remover senha da classe paciente', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_Responsavel_PacienteId] ON [Responsavel];
GO

CREATE INDEX [IX_Responsavel_PacienteId] ON [Responsavel] ([PacienteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231120110734_Remover atributo virtual responsavel', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE SEQUENCE AtendimentoSequence START WITH 1 INCREMENT BY 1
GO

ALTER TABLE [ClassificacaoPaciente] ADD [AtendimentoPacienteId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Atendimento] (
    [AtendimentoPacienteId] int NOT NULL DEFAULT (NEXT VALUE FOR AtendimentoSequence),
    [PacienteId] int NOT NULL,
    [SenhaClassificacao] nvarchar(max) NOT NULL,
    [DataAtendimento] datetime2 NOT NULL,
    [InseridoEm] datetime NOT NULL DEFAULT (getdate()),
    [InseridoPor] int NOT NULL DEFAULT (1),
    [ModificadoEm] datetime NOT NULL DEFAULT (getdate()),
    [ModificadoPor] int NOT NULL DEFAULT (1),
    CONSTRAINT [PK_Atendimento] PRIMARY KEY ([AtendimentoPacienteId]),
    CONSTRAINT [FK_Atendimento_ClassificacaoPaciente_AtendimentoPacienteId] FOREIGN KEY ([AtendimentoPacienteId]) REFERENCES [ClassificacaoPaciente] ([ClassificacaoPacienteId]) ON DELETE CASCADE
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231121000858_Add Atendimento', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Paciente]') AND [c].[name] = N'cep');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Paciente] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Paciente] ALTER COLUMN [cep] varchar(8) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231121234637_Ajuste tipo cep string', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Responsavel] DROP CONSTRAINT [FK_Responsavel_Paciente_PacienteId];
GO

DROP INDEX [IX_Responsavel_PacienteId] ON [Responsavel];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Responsavel]') AND [c].[name] = N'PacienteId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Responsavel] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Responsavel] DROP COLUMN [PacienteId];
GO

CREATE TABLE [PacienteResponsavel] (
    [PacienteId] int NOT NULL,
    [ResponsavelId] int NOT NULL,
    CONSTRAINT [PK_PacienteResponsavel] PRIMARY KEY ([PacienteId], [ResponsavelId]),
    CONSTRAINT [FK_PacienteResponsavel_Paciente_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Paciente] ([PacienteId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PacienteResponsavel_Responsavel_ResponsavelId] FOREIGN KEY ([ResponsavelId]) REFERENCES [Responsavel] ([ResponsavelId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_PacienteResponsavel_ResponsavelId] ON [PacienteResponsavel] ([ResponsavelId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231122022254_Add configuração muitos x muitos paciente e responsavel', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE PacienteResponsavel ADD CONSTRAINT unique_combination_paciente_responsavel UNIQUE (PacienteId, ResponsavelId)
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231122094711_unique PacienteId ResppnsavelId', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [PacienteResponsavel] DROP CONSTRAINT [FK_PacienteResponsavel_Paciente_PacienteId];
GO

ALTER TABLE [PacienteResponsavel] DROP CONSTRAINT [FK_PacienteResponsavel_Responsavel_ResponsavelId];
GO

ALTER TABLE [PacienteResponsavel] DROP CONSTRAINT [PK_PacienteResponsavel];
GO

DROP INDEX [IX_PacienteResponsavel_ResponsavelId] ON [PacienteResponsavel];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231122104352_configuração de paciente e responsavel', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE PacienteResponsavel ADD PRIMARY KEY (pacienteId, responsavelId);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231123004558_Primary key paciente e responsavel', N'7.0.12');
GO

COMMIT;
GO

