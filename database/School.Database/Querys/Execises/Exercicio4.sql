--4. LISTE OS NOME EM MAIÚSCULO E AS CIDADES EM MINUSCULO DOS ALUNOS QUE A DATA DE CADATRO ESTEJA ENTRE 01/02/2013 ATÉ 28/02/2013
DROP TABLE February_Student;
SELECT Name, City, CreatedAt INTO February_Student FROM [Student]
WHERE CreatedAt BETWEEN '2013-02-01' AND '2013-02-28';
/*
	WHERE CreatedAt >= '2013-02-01' AND CreatedAt <= '2013-02-28';
*/
UPDATE February_Student
SET Name = UPPER(Name);
UPDATE February_Student
SET City = LOWER(City);

SELECT * FROM February_Student;
SELECT * FROM [Student];
