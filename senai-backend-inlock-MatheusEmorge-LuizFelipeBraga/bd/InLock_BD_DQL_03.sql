Use InLock_Games_Tarde

SELECT * FROM Usuarios
SELECT * FROM Estudios
SELECT * FROM Jogos

SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, Estudios.NomeEstudio FROM Jogos
INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio

SELECT NomeEstudio,Jogos.IdJogo, Jogos.NomeJogo, .Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor FROM Estudios
left join Jogos on Estudios.IdEstudio = Jogos.IdEstudio

SELECT Email,Senha FROM Usuarios
Where Email  = 'admin@admin.com' AND Senha = 'admin'

SELECT * FROM Jogos
Where IdJogo = 1

SELECT * FROM Estudios
Where IdEstudio = 2;