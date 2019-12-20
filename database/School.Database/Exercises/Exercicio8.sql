--8. LISTE o nome, salário, nome do perfil PROFESSORES E SEUS RESPECTIVOS PERFIS
/*
	SELECT Orders.OrderID, Customers.CustomerName, Orders.OrderDate
	FROM Orders
	INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID;
	https://www.w3schools.com/sql/sql_join.asp
*/

SELECT
	dbo.Teacher.Name,
	dbo.Teacher.Salary,
	dbo.[Level].Name,
	dbo.[Profile].Name
FROM 
	dbo.[Teacher]
INNER JOIN dbo.[Level] ON dbo.Teacher.LevelId = dbo.[Level].LevelId
INNER JOIN dbo.[TeacherProfile] ON dbo.Teacher.TeacherId = dbo.[TeacherProfile].TeacherId
INNER JOIN dbo.[Profile] ON dbo.[TeacherProfile].ProfileId = dbo.[Profile].ProfileId;