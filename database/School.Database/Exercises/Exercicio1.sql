--1. SELECIONAR TODOS OS PROFS DO SEXO MASCULINO

SELECT 
	TeacherId INTO MaleTeacher
FROM
	dbo.Teacher
WHERE
	Gender = 'M'