--7. LISTE OS CURSOS COM SUAS RESPECTIVAS AREAS

/*
	SELECT Orders.OrderID, Customers.CustomerName, Orders.OrderDate
	FROM Orders
	INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID;
	https://www.w3schools.com/sql/sql_join.asp
*/


SELECT Course.Name,InformationArea.Name FROM
[Course]
INNER JOIN [InformationArea] ON Course.AreaId = InformationArea.AreaId;

SELECT * FROM [InformationArea];
SELECT * FROM [Course];

