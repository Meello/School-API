--2. SELECIONAR TODOS OS CAMPOS NOME, SEXO E CIDADE DOS ALUNOS ATIVOS
/*
SELECT * "ou" column1, column2, column3, ...
INTO newtable [IN externaldb]
FROM oldtable
WHERE condition;
*/
DROP TABLE ActiveStudent;
SELECT Name,Gender,City INTO ActiveStudent
FROM [Student]
WHERE Active = 1;
SELECT * FROM ActiveStudent;