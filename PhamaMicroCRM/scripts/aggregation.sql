SELECT
	Note.CompanyId,
	Comp.Name,
	COUNT(Note.CompanyId) AS 'Counted'
FROM Notes AS Note
INNER JOIN Companies AS Comp ON Note.CompanyId = Comp.Id
GROUP BY
	Note.CompanyId,
	Comp.Name