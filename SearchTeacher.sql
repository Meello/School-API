declare @PageNumber int = 1,
		@PageSize int = 6,
		@NameInitial char = 'B',
		@MinSalary  decimal = 1000,
		@MaxSalary  decimal = 10000,
		@MinAdmitionDate Date = '2019-01-01',
		@MaxAdmitionDate Date = '2019-12-10';

		
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
                    LEFT(Name,1) = @NameInitial
                         AND Gender IN('M' , 'F')
                         AND LevelId IN('P' , 'S')
                         AND Salary < @MaxSalary AND Salary > @MinSalary
                         AND AdmitionDate < @MaxAdmitionDate AND AdmitionDate > @MinAdmitionDate
                        ORDER BY TeacherId
                    OFFSET (@PageNumber - 1)*@PageSize  ROWS
                    FETCH NEXT @PageSize ROWS ONLY

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
	LEFT(Name,1) = @NameInitial
    AND Gender IN('M' , 'F')
    AND LevelId IN('S','P')
    AND Salary < @MaxSalary AND Salary > @MinSalary
    AND AdmitionDate < @MaxAdmitionDate AND AdmitionDate > @MinAdmitionDate
ORDER BY TeacherId
OFFSET (@PageNumber - 1)*@PageSize  ROWS
FETCH NEXT @PageSize ROWS ONLY