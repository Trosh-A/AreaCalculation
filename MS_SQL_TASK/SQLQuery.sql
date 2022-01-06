USE TestDb
SELECT DISTINCT(prod.Name), cat.Name
FROM Products as prod
LEFT JOIN ProductCategory prodCut
ON prod.Id = prodCut.ProductId
LEFT JOIN Categories as cat
ON prodCut.CategoryId = cat.Id