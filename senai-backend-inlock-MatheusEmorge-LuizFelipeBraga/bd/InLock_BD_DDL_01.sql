CREATE DATABASE InLock_Games_Tarde
GO
USE InLock_Games_Tarde;

CREATE TABLE Estudios (
IdEstudio INT PRIMARY KEY IDENTITY,
NomeEstudio VARCHAR (255)

);

CREATE TABLE Jogos (

IdJogo INT PRIMARY KEY IDENTITY,
NomeJogo VARCHAR (255)NOT NULL ,
Descricao VARCHAR (255),
DataLancamento DATE,
Valor FLOAT ,
IdEstudio INT FOREIGN KEY REFERENCES Estudios (IdEstudio)

);

CREATE TABLE TiposUsuario (

IdTipoUsuario INT PRIMARY KEY IDENTITY,
Titulo VARCHAR (250) NOT NULL

);

CREATE TABLE Usuarios (

IdUsuario INT PRIMARY KEY IDENTITY,
Email VARCHAR (250)NOT NULL UNIQUE ,
Senha VARCHAR (250) NOT NULL,
IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario (IdTipoUsuario)

);
