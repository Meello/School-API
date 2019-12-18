--10. LISTE OS CAMPOS TurmaId, Unidade(CASO NÃO EXISTA, INFORMAR A MENSAGEM 'Não informado'), Nome do Curso, Nome do Professor, Perfil do Professor, Turno 
SELECT
	Class.ClassId,
	ISNULL(Class.Local,'Não informado') AS [Local],
	Course.Name,
	Class.Shift,
	Teacher.Name AS 'Teacher',
	Profile.Name AS 'Teacher_Profile'
FROM
	[Class]
	INNER JOIN [Course] ON [Class].CourseId = [Course].CourseId
	INNER JOIN [Teacher] ON Class.TeacherId = [Teacher].TeacherId
	INNER JOIN [TeacherProfile] ON [Teacher].TeacherId = [TeacherProfile].TeacherId
	INNER JOIN [Profile] ON [TeacherProfile].ProfileId = [Profile].ProfileId

	SELECT * FROM [Class]
	SELECT * FROM [Course]
	SELECT * FROM [Teacher]
	SELECT * FROM [TeacherProfile]
	SELECT * FROM [Profile]