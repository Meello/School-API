CREATE PROCEDURE GetTeacherById 
@Cpf int
AS
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
	    TeacherId = @Cpf;