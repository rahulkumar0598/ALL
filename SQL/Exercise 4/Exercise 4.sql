Use AdventureWorks2008R2;
GO
SELECT s.ProductID,SUM((UnitPrice-(UnitPrice*UnitPriceDiscount/100))*OrderQty) AS ConvertedPrice

FROM Sales.SalesOrderDetail s
GROUP BY s.ProductID
having s.ProductID>500
