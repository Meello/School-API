--18. LISTE ID DO CURSO, NOME DO CURSO E A QUANTIDADE DE ALUNOS INSCRITOS

CREATE VIEW Enrolled_Students
AS
SELECT
	dbo.[Course].CourseId AS 'CourseId',
	dbo.[Course].Name AS 'Course',
	COUNT(dbo.[Subscription].StudentId) AS 'EnrolledStudents'
FROM
	dbo.[Subscription]
	INNER JOIN dbo.[Class] ON dbo.[Subscription].ClassId = dbo.[Class].ClassId
	INNER JOIN dbo.[Course] ON dbo.[Class].CourseId = dbo.[Course].CourseId
GROUP BY 
	dbo.[Course].CourseId,dbo.[Course].Name;