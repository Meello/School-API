--9. LISTE OS CAMPOS TurmaId, Nome do Curso, Turno (Deve aparecer na Tela: 'Manhã' se for 'M', 'Tarde' se for 'T' e 'Noite' se for 'N')
/*
	SELECT Orders.OrderID, Customers.CustomerName, Orders.OrderDate
	FROM Orders
	INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID;
	https://www.w3schools.com/sql/sql_join.asp
*/

SELECT 
	Class.ClassId, 
	Course.Name, 
	CASE Class.Shift 
		WHEN 'M' THEN 'Manhã' 
		WHEN 'T' THEN 'Tarde' 
		WHEN 'N' THEN 'Noite' 
	END AS [Shift]
	-- as 'NOME' altera nome da coluna
FROM 
	[Class]
	INNER JOIN Course ON Class.CourseId = Course.CourseId
