--16. LISTE OS ALUNOS QUE NÃO ESTÃO INSCRITOS EM NENHUM CURSO
	
SELECT
	[Student].Name AS 'Student_Not_Registered'
FROM
	[Subscription]
	RIGHT JOIN [Student] ON [Subscription].StudentId = [Student].StudentId
	WHERE 
		[Subscription].StudentId IS NULL;
