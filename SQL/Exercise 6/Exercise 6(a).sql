
GO
CREATE OR ALTER TRIGGER [Production].UpdateTrigger
ON Production.Product
-- For Update function
INSTEAD OF UPDATE
AS
-- For Number of Affected Row or column
SET NOCOUNT ON
BEGIN
	-- Modification A.T.Q second requirement
	IF UPDATE(ListPrice)						
	DECLARE @OldListPrice money -- mony is a dataType
	DECLARE @InsertedListPrice money
	DECLARE @ID int
	SELECT @OldListPrice = p.ListPrice,
		   @InsertedListPrice=inserted.ListPrice,
		   @ID = inserted.ProductID
	FROM Production.Product p, inserted
	WHERE p.ProductID = inserted.ProductID;

	IF( @InsertedListPrice > ( @OldListPrice + (0.15*@OldListPrice) ) ) 
	BEGIN
		RAISERROR('LIST PRICE MORE THAN 15 PERCENT, TRANSACTION FAILED',16,0) --   (0-10) – informational messages & (11-18) – errors

		ROLLBACK TRANSACTION
	END
	ELSE
	BEGIN
		Update Production.Product SET ListPrice=@InsertedListPrice 
		WHERE Production.Product.ProductID = @ID;
	END
	
END;



