/*
	CREATE PROCEDURE procedure_name
	AS
	sql_statement
	GO;

	EXEC procedure_name;

	SELECT column_name(s)
	FROM table_name
	WHERE EXISTS
	(SELECT column_name FROM table_name WHERE condition);

	DELETE FROM "nome_tabela"
	WHERE "condição";	
	
	SELECT DATENAME(year, '12:10:30.123')  
		,DATENAME(month, '12:10:30.123')  
		,DATENAME(day, '12:10:30.123')  
		,DATENAME(dayofyear, '12:10:30.123')  
		,DATENAME(weekday, '12:10:30.123');  
*/

CREATE PROCEDURE Workday_Class AS
	SELECT * FROM [Class]
	WHERE EXISTS
	(
		SELECT 
			[Class].StartDate
		FROM
			[Class]
		WHERE
			--Não funcionou
			--DATENAME(weekday,[Class].StartDate) IN ('Monday','Tuesday','Wednesday','Thursday','Friday')
			/*
			DATENAME(weekday,[Class].StartDate) = 'Monday'		
			OR DATENAME(weekday,[Class].StartDate)  = 'Tuesday'
			OR DATENAME(weekday,[Class].StartDate) = 'Wednesday'
			OR DATENAME(weekday,[Class].StartDate) = 'Thursday'
			OR DATENAME(weekday,[Class].StartDate) = 'Friday'
			*/
	);
DROP PROCEDURE Workday_Class;

--FUNCIONOU
	SELECT 
	(SELECT DATENAME(weekday,[Class].StartDate))
	from [Class];
