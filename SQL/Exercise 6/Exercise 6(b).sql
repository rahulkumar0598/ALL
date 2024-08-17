
SELECT Production.Product.ProductID,
	   Production.Product.ListPrice
FROM PRODUCTION.Product;

UPDATE PRODUCTION.Product 
SET ListPrice=1
WHERE Product.ProductID=4;

