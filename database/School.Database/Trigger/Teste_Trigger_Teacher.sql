GO
INSERT INTO [Teacher]
VALUES (13843917701,'Bruno','M','S',3000,'2019-10-10');

GO
UPDATE [Teacher]
SET Name = 'Bruno M',
	Salary = 2001,
	AdmitionDate = '2019-10-22'
WHERE TeacherId = 13843917701;

GO
DELETE [Teacher]
WHERE TeacherId = 13843917701;

GO
SELECT * FROM [ChangeHistory]
ORDER BY ChangeDateUTC DESC;

GO
SELECT * FROM [ChangeHistoryDetail];

GO
SELECT * FROM [Teacher];