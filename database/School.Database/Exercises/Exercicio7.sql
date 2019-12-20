--7. LISTE OS CURSOS COM SUAS RESPECTIVAS AREAS

SELECT
	dbo.Course.Name,
	dbo.InformationArea.Name 
FROM
	dbo.Course
INNER JOIN dbo.InformationArea ON dbo.Course.AreaId = dbo.InformationArea.AreaId;