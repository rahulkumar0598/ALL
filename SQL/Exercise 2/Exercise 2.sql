use AdventureWorks2008R2
Go
--using join

Select C.CustomerID from Sales.SalesOrderHeader SOH
Right Join Sales.Customer C
on C.CustomerID=SOH.CustomerID
Where SalesOrderID is NULL;

-- Using Subquery
Select CustomerID from Sales.Customer C  
Where C.CustomerID  
Not in (Select CustomerID from Sales.SalesOrderHeader);


-- EXIST
Select C.CustomerID From Sales.Customer C
Where NOT EXISTS (Select s.CustomerID from Sales.SalesOrderHeader as s where s.CustomerID=C.CustomerID); 

-- CTE
With CustomerWithoutOrder(CustomerID)
As

(Select C.CustomerID from Sales.SalesOrderHeader SOH
Right Join Sales.Customer C
on C.CustomerID=SOH.CustomerID
Where SalesOrderID is NULL)

Select * from CustomerWithoutOrder;