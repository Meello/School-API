INSERT INTO dbo.Teacher
(
	TeacherId,
	Name,
	Gender,
	LevelId,
	Salary,
	AdmitionDate
)
VALUES
(
	@teacherToInsert.TeacherId,
	@teacherToInsert.Name,
	@teacherToInsert.Gender,
	@teacherToInsert.LevelId,
	@teacherToInsert.Salary,
	@teacherToInsert.AdmitionDate
)
	