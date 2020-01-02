CREATE PROCEDURE Verifying_Class AS
	SELECT * FROM [Class]
	WHERE EXISTS
		(SELECT
			[Class].CourseId,
			[Class].TeacherId
		FROM 
			[Class]
			INNER JOIN [Course] ON [Class].CourseId = [Course].CourseId 
			INNER JOIN [Teacher] ON [Class].TeacherId = [Teacher].TeacherId
		WHERE
			[Class].CourseId IS NOT NULL
			AND [Class].TeacherId IS NOT NULL
		);