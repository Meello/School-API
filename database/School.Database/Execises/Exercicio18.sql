--18. LISTE ID DO CURSO, NOME DO CURSO E A QUANTIDADE DE ALUNOS INSCRITOS

SELECT 
	[Course].CourseId,
	[Course].Name,
	COUNT([Subscription].StudentId) AS 'Enrolled_Students'
FROM
	[Subscription]
	INNER JOIN [Class] ON [Subscription].ClassId = [Class].ClassId
	INNER JOIN [Course] ON [Class].CourseId = [Course].CourseId
GROUP BY 
	[Course].CourseId,[Course].Name