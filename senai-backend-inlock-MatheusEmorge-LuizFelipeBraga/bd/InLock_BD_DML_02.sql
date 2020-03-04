USE InLock_Games_Tarde
GO

INSERT INTO TiposUsuario (Titulo)
VALUES ('Administrador'), ('Cliente');

INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES ('admin@admin.com','admin',1),('cliente@cliente.com','cliente',2);

INSERT INTO Estudios (NomeEstudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix');

INSERT INTO Jogos (NomeJogo, Descricao,DataLancamento,Valor,IdEstudio)
VALUES ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante,
					seja voc� um novato ou um f�.','2012/04/15',99.00,1);

INSERT INTO Jogos (NomeJogo, Descricao,DataLancamento,Valor,IdEstudio)
VALUES ('Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western','2018/10/26',120,2)

UPDATE Jogos
	Set DataLancamento = '2012/05/15'
	WHERE IdJogo = 1;

