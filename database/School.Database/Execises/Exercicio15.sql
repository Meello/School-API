--15. LISTE A QUANTOS PROFESSORES EXISTEM DO SEXO MASCULINO E FEMININO

SELECT
	Gender,
	COUNT(TeacherId) AS 'Quantidade'
FROM
	[Teacher]
GROUP BY Gender

/*
	GROUP BY --> agrupa os dadas para poder realizar o COUNT
		Pode usar mais de um fazendo varios grupos, estilo filtro do Excel
*/