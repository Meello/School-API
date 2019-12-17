/*
	CREATE PROCEDURE procedure_name
	AS
	sql_statement
	GO;

	EXEC procedure_name;
*/
/*
	SELECT column_name(s)
	FROM table_name
	WHERE EXISTS
	(SELECT column_name FROM table_name WHERE condition);
	
	DELETE FROM "nome_tabela"
	WHERE "condição";
*/

CREATE PROCEDURE Exists_BirthDate2 AS	
	PRINT N'Old Table';
	SELECT * INTO [Student_Old] FROM [Student]
	SELECT * FROM [Student_Old]
	PRINT N'New Table'
	DELETE FROM [Student]
	WHERE [Student].BirthDate > GETDATE()
	SELECT * FROM [Student];

DROP TABLE [Student_Old];
	--GO; deu erro usando o GO, por que deu erro?
/*
	Como inserir aviso de que algum valor não é válido?
*/