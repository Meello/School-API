SELECT 
	TeacherId,
	Name,
	Gender,
	LevelId,
	Salary,
	AdmitionDate
FROM 
	dbo.Teacher
ORDER BY TeacherId
	OFFSET (@TeacherPerPage - 1)*@NumberPage ROWS
	FETCH NEXT @NumberPage ROWS ONLY;