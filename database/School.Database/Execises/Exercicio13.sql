--13. LISTE O TOTAL DE ALUNOS INATIVOS
/*
	SELECT COUNT(column_name)
	FROM table_name
	WHERE condition;
*/

SELECT
	COUNT(StudentId) AS 'Inactive_Student'
FROM
	[Student]
WHERE Active = 0;