--14. EXIBA O MENOR, A MÉDIA, O MAIOR E A SOMA DOS SALÁRIOS DOS PROFESSORES
SELECT 
	MIN([Teacher].Salary) AS 'Smallest Salary',
	AVG([Teacher].Salary) AS 'Average',
	MAX([Teacher].Salary) AS 'Biggest Salary'
FROM
	[Teacher];