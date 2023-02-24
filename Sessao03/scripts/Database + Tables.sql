USE [Blog]
GO

-- DROP TABLE [Usuario]
-- DROP TABLE [Papel]
-- DROP TABLE [UsuarioPapel]
-- DROP TABLE [Post]
-- DROP TABLE [Categoria]
-- DROP TABLE [Tag]
-- DROP TABLE [PostTag]

CREATE TABLE [Usuario] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Nome] NVARCHAR(80) NOT NULL,
    [Email] VARCHAR(200) NOT NULL,
    [Senha] VARCHAR(255) NOT NULL,
    [Biografia] TEXT NOT NULL,
    [Imagem] VARCHAR(2000) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Usuario] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Usuario_Email] UNIQUE([Email]),
    CONSTRAINT [UQ_Usuario_Slug] UNIQUE([Slug])
)
CREATE NONCLUSTERED INDEX [IX_Usuario_Email] ON [Usuario]([Email])
CREATE NONCLUSTERED INDEX [IX_Usuario_Slug] ON [Usuario]([Slug])

CREATE TABLE [Papel] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Nome] VARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Papel] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Papel_Slug] UNIQUE([Slug])
)
CREATE NONCLUSTERED INDEX [IX_Papel_Slug] ON [Papel]([Slug])

CREATE TABLE [UsuarioPapel] (
    [UsuarioId] INT NOT NULL,
    [PapelId] INT NOT NULL,

    CONSTRAINT [PK_UsuarioPapel] PRIMARY KEY([UsuarioId], [PapelId])
)

CREATE TABLE [Categoria] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Nome] VARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Categoria_Slug] UNIQUE([Slug])
)
CREATE NONCLUSTERED INDEX [IX_Categoria_Slug] ON [Categoria]([Slug])

CREATE TABLE [Post] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [CategoriaId] INT NOT NULL,
    [AutorId] INT NOT NULL,
    [Title] VARCHAR(160) NOT NULL,
    [Summary] VARCHAR(255) NOT NULL,
    [Body] TEXT NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    [DataCriacao] DATETIME NOT NULL DEFAULT(GETDATE()),
    [DataUltimaModificacao] DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_Post] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Post_Categoria] FOREIGN KEY([CategoriaId]) REFERENCES [Categoria]([Id]),
    CONSTRAINT [FK_Post_Autor] FOREIGN KEY([AutorId]) REFERENCES [Usuario]([Id]),
    CONSTRAINT [UQ_Post_Slug] UNIQUE([Slug])
)
CREATE NONCLUSTERED INDEX [IX_Post_Slug] ON [Post]([Slug])

CREATE TABLE [Tag] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Nome] VARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Tag] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Tag_Slug] UNIQUE([Slug])
)
CREATE NONCLUSTERED INDEX [IX_Tag_Slug] ON [Tag]([Slug])

CREATE TABLE [PostTag] (
    [PostId] INT NOT NULL,
    [TagId] INT NOT NULL,

    CONSTRAINT PK_PostTag PRIMARY KEY([PostId], [TagId])
)