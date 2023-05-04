IF (EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_add_calculation]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 ))
BEGIN
    DROP PROCEDURE [dbo].[usp_add_calculation]
END
GO

CREATE PROCEDURE [dbo].[usp_add_calculation] 
    @FirstNumber [float], 
    @SecondNumber [float], 
    @OperationName [nvarchar](20), 
    @ResultNumber [float]
AS
    SET NOCOUNT ON;  
    INSERT INTO [dbo].[Calculations] 
    ([FirstNumber], [SecondNumber], [OperationName], [ResultNumber])
    VALUES
    (@FirstNumber, @SecondNumber, @OperationName, @ResultNumber);
GO