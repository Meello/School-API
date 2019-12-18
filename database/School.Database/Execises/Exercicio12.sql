--12. LISTE O CURSO COM MENOR CARGA HORARIA
/*
	SELECT TOP (expression) [PERCENT] [WITH TIES]
		colmuns
	FROM 
	    table_name
	ORDER BY 
	    column_name;  
*/
SELECT TOP (1)	WITH TIES
	Name,
	Workload
FROM
	[Course]
--WHERE Workload = 280
ORDER BY Workload ASC;