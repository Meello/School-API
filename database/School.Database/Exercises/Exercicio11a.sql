--11. LISTE O SALARIO E O NOME E O SALÁRIO DO PROFESSOR QUE GANHA MAIS

--DECLARE @SALARY_MAX DECIMAL(10,2) = (SELECT MAX([Teacher].Salary) FROM [Teacher])
SELECT
	*
FROM 
	dbo.[Teacher]
WHERE
	dbo.[Teacher].Salary = (SELECT MAX([Teacher].Salary) FROM [Teacher])