--3. SELECIONAR APENAS OS NOMES DOS PROFESSORES COM O NIVEL (PLENO E SENIOR) ORDENADOS DE FORMA DECRESCENTE

SELECT 
	Name, 
	LevelId
FROM
	dbo.[Teacher]
WHERE
	LevelId IN ('P','S')
ORDER BY
	LevelId;