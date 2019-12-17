/*
	CREATE PROCEDURE procedure_name
	AS
	sql_statement
	GO;

	EXEC procedure_name;
*/

CREATE PROCEDURE Exists_BirthDate AS
/*
	SELECT column_name(s)
	FROM table_name
	WHERE EXISTS
	(SELECT column_name FROM table_name WHERE condition);
*/
	SELECT * FROM [Student]
	WHERE EXISTS
		(SELECT 
			[Student].BirthDate
		FROM
			[Student]
		WHERE
			[Student].BirthDate < GETDATE()
		)
	--GO; deu erro usando o GO, por que deu erro?
/*
	Como inserir aviso de que algum valor não é válido?
*/