--1. SELECIONAR TODOS OS PROFS DO SEXO MASCULINO
/*
SELECT * "ou" column1, column2, column3, ...
INTO newtable [IN externaldb]
FROM oldtable
WHERE condition;
*/
DROP TABLE MaleTeacher;
SELECT TeacherId INTO MaleTeacher
FROM [Teacher]
WHERE Gender = 'M';
SELECT * FROM MaleTeacher;