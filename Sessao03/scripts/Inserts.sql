DELETE FROM [Categoria]
GO

INSERT INTO [Categoria] VALUES('Backend', 'backend')
INSERT INTO [Categoria] VALUES('Frontend', 'frontend')
INSERT INTO [Categoria] VALUES('Full Stack', 'fullstack')
INSERT INTO [Categoria] VALUES('Mobile', 'mobile')

INSERT INTO [Tag] VALUES('ASP.NET', 'aspnet')
INSERT INTO [Tag] VALUES('.NET', 'dotnet')
INSERT INTO [Tag] VALUES('C#', 'csharp')
INSERT INTO [Tag] VALUES('Angular', 'angular')
INSERT INTO [Tag] VALUES('Flutter', 'flutter')
INSERT INTO [Tag] VALUES('Entity Framework', 'ef')
INSERT INTO [Tag] VALUES('Java', 'java')
INSERT INTO [Tag] VALUES('Java Script', 'js')

INSERT INTO [Papel] VALUES('user', 'user')
INSERT INTO [Papel] VALUES('author', 'author')
INSERT INTO [Papel] VALUES('admin', 'admin')

INSERT INTO [Usuario] VALUES('Peter Parker', 'pparker@balta.io', '1234', 'https://balta.io/', 'peter-parker', 'Sou o Homem Aranha')
INSERT INTO [Usuario] VALUES('Bruce Wayne', 'wayne@balta.io', '1234', 'https://balta.io/', 'bruce-wayne', 'Sou o Batman')
INSERT INTO [Usuario] VALUES('Diana Prince', 'diana@balta.io', '1234', 'https://balta.io/', 'diana-prince', 'Sou a Mulher Maravilha')

-- POST
INSERT INTO [Post] VALUES('Começando com C#', 'Neste post vamos começar com C#', '<h1>Começando com C#</h1>', 'comecando-com-csharp', GETDATE(), GETDATE(), (SELECT TOP 1 [Id] FROM [Categoria] WHERE [Slug]='backend'), (SELECT TOP 1 [Id] FROM [Usuario] WHERE [Slug]='peter-parker'))
INSERT INTO [Post] VALUES('Começando com Angular', 'Neste post vamos começar com Angular', '<h1>Começando com Angular</h1>', 'comecando-com-angular', GETDATE(), GETDATE(), (SELECT TOP 1 [Id] FROM [Categoria] WHERE [Slug]='frontend'), (SELECT TOP 1 [Id] FROM [Usuario] WHERE [Slug]='diana-prince'))

-- Se der erro de índice ao inserir os PostTag, remover as chaves
-- DROP INDEX [IX_PostTag_TagId] ON [PostTag]
-- ALTER TABLE [PostTag] DROP CONSTRAINT [PK_PostTag]  
-- ALTER TABLE [PostTag] DROP CONSTRAINT [FK_PostTag_TagId ]
INSERT INTO [PostTag] VALUES(1, 2)
INSERT INTO [PostTag] VALUES(1, 3)
INSERT INTO [PostTag] VALUES(2, 4)
INSERT INTO [PostTag] VALUES(2, 8)

INSERT INTO [UsuarioPapel] VALUES(1, 1)
INSERT INTO [UsuarioPapel] VALUES(1, 2)
INSERT INTO [UsuarioPapel] VALUES(2, 1)
INSERT INTO [UsuarioPapel] VALUES(2, 2)
INSERT INTO [UsuarioPapel] VALUES(2, 3)
INSERT INTO [UsuarioPapel] VALUES(3, 1)
INSERT INTO [UsuarioPapel] VALUES(3, 2)