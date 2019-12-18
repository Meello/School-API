declare @Name char = 'B',
	@Genders char = 'F',
	@LevelIds char = 'J',
	@MinSalary decimal = 1000,
	@MaxSalary decimal = 10000,
	@MinAdmitionDate DateTime2 = '1900-01-01',
	@MaxAdmitionDate DateTime2 = '2019-12-17',
	@PageNumber int = 1,
	@PageSize int = 3
	;

SELECT 
    TeacherId,
    Name,
    Gender,
    LevelId,
    Salary,
    AdmitionDate
FROM 
    dbo.Teacher
WHERE Name LIKE @Name + '%' AND Gender IN ('F','M') AND LevelId IN ('S','P','J') AND Salary BETWEEN @MinSalary AND @MaxSalary AND AdmitionDate BETWEEN @MinAdmitionDate AND @MaxAdmitionDate

ORDER BY TeacherId
    OFFSET (@PageNumber - 1)*@PageSize  ROWS
    FETCH NEXT @PageSize ROWS ONLY;

SELECT 
    COUNT(TeacherId)
FROM 
    dbo.Teacher
WHERE Name LIKE @Name + '%' AND Gender IN ('F','M') AND LevelId IN ('S','P','J') AND Salary BETWEEN @MinSalary AND @MaxSalary AND AdmitionDate BETWEEN @MinAdmitionDate AND @MaxAdmitionDate