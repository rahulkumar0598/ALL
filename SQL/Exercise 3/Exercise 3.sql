use AdventureWorks2008R2
go
Select Top 5 SalesOrderID,OrderDate 
from Sales.SalesOrderHeader
where AccountNumber IN
	(Select AccountNumber from Sales.SalesOrderHeader 
	group by AccountNumber Having SUM(SubTotal)>70000)
Order By OrderDate ;


