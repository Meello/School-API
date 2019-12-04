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
	@TeacherId,
	@Name,
	@Gender,
	@LevelId,
	@Salary,
	@AdmitionDate
)
	