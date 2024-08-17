use AdventureWorks2008R2
go

CREATE PROCEDURE Person.DisplayInfo 
@Name varchar(20)
AS
BEGIN
SELECT FirstName,MiddleName,LastName
FROM Person.Person
WHERE FirstName=@Name;
END
GO

