--3. SELECIONAR APENAS OS NOMES DOS PROFESSORES COM O NIVEL (PLENO E SENIOR) ORDENADOS DE FORMA DECRESCENTE
/* Jeito 1 */
DROP TABLE Plenum_Senior_Teacher;
SELECT Name, LevelId INTO Plenum_Senior_Teacher
FROM [Teacher]
WHERE LevelId IN ('P','S');
SELECT * FROM Plenum_Senior_Teacher
ORDER BY LevelId;
/*
	Como atualizar a tabela para ter os valores organizados na ordem?
	Como criar uma condição para a ordem?
*/
SELECT * FROM Plenum_Senior_Teacher;
SELECT * FROM [Teacher];

/* Jeito 2 */
SELECT Name, LevelId FROM [Teacher]
WHERE LevelId IN ('P','S')
ORDER BY LevelId;