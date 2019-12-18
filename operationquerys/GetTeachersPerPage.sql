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
	OFFSET (@PageNumber - 1)*@TeachersPerPage  ROWS
	FETCH NEXT @TeachersPerPage ROWS ONLY;