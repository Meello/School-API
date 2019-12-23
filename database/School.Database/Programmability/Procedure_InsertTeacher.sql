CREATE PROCEDURE InsertTeacher
@TeacherId bigint,
@Name varchar(32),
@Gender char(1),
@Level char(1),
@Salary decimal(10,2),
@AdmitionDate datetime2
AS
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
		@Level,
		@Salary,
		@AdmitionDate
	);