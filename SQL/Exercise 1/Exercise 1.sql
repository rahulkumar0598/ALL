use AdventureWorks2008R2
Go

/*Exercise 1 */
/*Query 1*/
select COUNT(*) as SalesPerson;

/*Query 2*/

Select CONCAT(FirstName,' ', LastName) as FullName 
from Person.Person
where FirstName Like 'B%';

/*Query 3*/

select h.JobTitle as Title  ,p.FirstName ,p.LastName , CONCAT(FirstName,' ',LastName) as FullName
from Person.Person p inner Join HumanResources.Employee h 
ON p.BusinessEntityID=h.BusinessEntityID
AND JobTitle ='Design Engineer' Or JobTitle = 'Tool Designer' or JobTitle = 'Marketing Assistant';


/*Query 4*/
 Select p.Name,p.Color,p.Weight
 from Production.Product p
 where Weight=(select max(weight) from Production.Product);

/*Query 5*/

 select  Description, CoalESce(s.MaxQty,0.00) from Sales.SpecialOffer as s
  
  //Or
  select  Description, ISNull(s.MaxQty,0.00) from Sales.SpecialOffer as s;
  
/*Query 6*/

Select CurrencyRateDate,FromCurrencyCode,ToCurrencyCode,AverageRate
From Sales.CurrencyRate
Where datepart(year,CurrencyRateDate)=2005 and ToCurrencyCode='GBP';

/*Query 7*/


Select ROW_NUMBER() over (order by FirstName,LastName) Row,FirstName, LastName
from Person.Person
where FirstName Like '%ss%';

/*Query 8*/
select CommissionPct ,
case
when CommissionPct=0 then 'band 0'
when CommissionPct>0 and  CommissionPct<=0.01 then 'band 1'
when CommissionPct>0.01 and  CommissionPct<=0.015 then 'band 2'
Else   'band 3'
end as BandType
from Sales.SalesPerson
order by CommissionPct

/*Query 9*/
Declare @id int;
Select @id = BusinessEntityID
From Person.Person
where FirstName='Ruth' and LastName ='Ellerbrock' and PersonType='EM'
Exec dbo.uspGetEmployeeManagers @BusinessEntityID=@ID;

/*Query 10*/

Select Max(dbo.ufnGetStock(ProductID)) 
from Production.Product;

