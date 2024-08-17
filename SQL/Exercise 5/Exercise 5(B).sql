--use AdventureWorks2016;

/*Write a Procedure supplying name information from the Person.Person table and accepting a filter for the first name. Alter the above Store 
Procedure to supply Default Values if user does not enter any value.( Use AdventureWorks)*/


-- Person.DisplayInfo  Procedure was created earlier in a file 


ALTER PROCEDURE Person.DisplayInfo 
  @Name varchar(50) 
AS
IF @Name IS NULL BEGIN;
  SET @Name='Terri'
END;
SELECT FirstName,MiddleName,LastName
FROM Person.Person
WHERE FirstName=@Name; 


