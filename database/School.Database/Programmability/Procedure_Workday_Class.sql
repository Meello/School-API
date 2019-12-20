CREATE PROCEDURE Workday_Class AS
	SELECT * FROM [Class]
	WHERE EXISTS
	(
		SELECT 
			dbo.Class.ClassId,
			DATENAME(weekday,[Class].StartDate) 
		FROM
			dbo.Class
		WHERE
			DATENAME(weekday,[Class].StartDate) IN ('Monday','Tuesday','Wednesday','Thursday','Friday')
	);