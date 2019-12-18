--11. LISTE O SALARIO E O NOME E O SALÁRIO DO PROFESSOR QUE GANHA MAIS
/*
	CREATE VIEW view_name AS
	SELECT column1, column2, ...
	FROM table_name
	WHERE condition;

	SELECT MIN(Price) AS SmallestPrice
	FROM Products;
	SELECT MAX(Price) AS BiggestPrice
	FROM Products;
*/
DECLARE @SALARY_MAX DECIMAL(10,2) = (SELECT MAX([Teacher].Salary) FROM [Teacher])
SELECT
	*
FROM 
	[Teacher]
	WHERE [Teacher].Salary = @SALARY_MAX

--11b. LISTE O SALARIO E O NOME E O SALÁRIO DO PROFESSORES QUE GANHAM MENOS
DECLARE @SALARY_MIN DECIMAL(10,2) = (SELECT MIN([Teacher].Salary) FROM [Teacher])
SELECT
	*
FROM 
	[Teacher]
	WHERE [Teacher].Salary = @SALARY_MIN
