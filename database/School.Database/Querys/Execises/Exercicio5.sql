--5. LISTE OS PROFESSORES COM DATA DE ADMISSÃO SUPERIOR AO ANO DE 1998
SELECT * FROM [Teacher]
WHERE year(AdmitionDate) > '1998';
/*
	WHERE AdmitionDate > '1998-12-31';
	WHERE AdmitionDate >= '1999-01-01';
*/
SELECT * FROM [Teacher];
