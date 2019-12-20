--6. LISTE OS PROFESSORES CUJO O MÍS DE ADMISS√O SEJA Novembro OU Dezembro.
SELECT 
	*
INTO 
	Nov_Dec_Teacher
FROM
	[Teacher]
WHERE
	month(AdmitionDate) IN(11,12);