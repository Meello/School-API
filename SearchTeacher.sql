declare @Page int = 0,
		@PageSize int = 0,
		@Tudo int = 6;

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
	OFFSET iif(@Page = 0, 0, (@Page - 1)*@PageSize) ROWS
	FETCH NEXT iif(@PageSize = 0, @Tudo, @PageSize) ROWS ONLY