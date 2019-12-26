CREATE PROCEDURE Verifying_Times AS
	SELECT *,
	IIF(
		DATEDIFF(MINUTE, [Class].StartTime,[Class].EndTime) = 180,
		'OK',
		DATEDIFF(MINUTE, [Class].StartTime,[Class].EndTime)
		)	AS 'Class_Minutes',
	IIF(
		[Class].StartTime >= '08:00',
		'Yes',
		'No'
		) AS 'StartTime >= 8:00',
	IIF(
		[Class].EndTime <= '22:00',
		'Yes',
		'No'
		) AS 'EndTime <= 22:00'
	FROM [Class];