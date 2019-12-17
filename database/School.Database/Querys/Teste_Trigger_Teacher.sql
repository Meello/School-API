
INSERT INTO [Teacher]
VALUES (13843917701,'Bruno','M','S',3000,'2019-10-10');

UPDATE [Teacher]
SET Name = 'Bruno M',
	Salary = 2001,
	AdmitionDate = '2019-10-22'
WHERE TeacherId = 13843917701;

DELETE [Teacher]
WHERE TeacherId = 13843917701;

SELECT * FROM [ChangeHistory]
ORDER BY ChangeDateUTC DESC;
SELECT * FROM [ChangeHistoryDetail];
SELECT * FROM [Teacher];

DROP TABLE [ChangeHistory]
DROP TABLE [ChangeHistoryDetail]
