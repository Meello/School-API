SELECT 
	TeacherId,
	Name,
	Gender,
	LevelId,
	Salary,
	AdmitionDate
FROM 
	dbo.Teacher
WHERE
	TeacherId = @cpf