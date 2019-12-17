--8. LISTE o nome, salário, nome do perfil PROFESSORES E SEUS RESPECTIVOS PERFIS
/*
	SELECT Orders.OrderID, Customers.CustomerName, Orders.OrderDate
	FROM Orders
	INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID;
	https://www.w3schools.com/sql/sql_join.asp
*/

SELECT Teacher.Name,Teacher.Salary,[Level].Name,[Profile].Name
FROM [Teacher]
INNER JOIN [Level] ON Teacher.LevelId = Level.LevelId
INNER JOIN [TeacherProfile] ON Teacher.TeacherId = [TeacherProfile].TeacherId
INNER JOIN [Profile] ON [TeacherProfile].ProfileId = [Profile].ProfileId;

SELECT * FROM [Teacher];
SELECT * FROM [Profile];
SELECT * FROM [TeacherProfile];
SELECT * FROM [Level];