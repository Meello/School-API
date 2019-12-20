CREATE PROCEDURE Exists_BirthDate2 AS	
	PRINT N'Old Table';
	SELECT * INTO [Student_Old] FROM [Student]
	SELECT * FROM [Student_Old]
	PRINT N'New Table'
	DELETE FROM [Student]
	WHERE [Student].BirthDate > GETDATE()
	SELECT * FROM [Student];

	exec Exists_BirthDate2;