CREATE PROCEDURE Exists_BirthDate AS
	SELECT * FROM [Student]
	WHERE EXISTS
		(SELECT 
			[Student].BirthDate
		FROM
			[Student]
		WHERE
			[Student].BirthDate < GETDATE()
		)
