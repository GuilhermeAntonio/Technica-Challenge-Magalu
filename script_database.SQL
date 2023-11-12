CREATE DATABASE DbUsersMagalu;
GO

CREATE TABLE DbUsersMagalu.dbo.Tb_Usuarios (
    [Id] INT NOT NULL IDENTITY,
    [UserName] VARCHAR(30) NOT NULL,
    [Password] VARCHAR(30) NOT NULL,
    CONSTRAINT [PK_Tb_Usuarios] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_UserName] UNIQUE ([UserName]) 
);
GO

INSERT INTO DbUsersMagalu.dbo.Tb_Usuarios ([UserName], [Password]) VALUES
        ('magalu', 'm@galu123'),
        ('guilherme', 'gui@magalu'),
        ('Lu', 'lu@2023');