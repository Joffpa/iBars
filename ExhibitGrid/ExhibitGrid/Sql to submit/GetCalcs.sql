if exists (SELECT * FROM sys.objects WHERE type = 'P' and name = 'UspGetCalcs') drop procedure UspGetCalcs
go

/*-----------------------------------------------------------------------
CREATED BY Joffrey Pannee
Gets all relevant calcs for a grid, including operands for external grids and calcs that cascade to other grids.
-- TESTING -- TESTING -- TESTING -- TESTING -- TESTING -- TESTING -- TESTING -- TESTING -- TESTING -- TESTING
DECLARE @GridCode VARCHAR(100)
SET @GridCode = 'PBA12_ProgData1'

EXEC UspGetCalcs @GridCode, null ;
-- TESTING -- TESTING -- TESTING -- TESTING -- TESTING -- TESTING -- TESTING -- TESTING -- TESTING -- TESTING

------------------------------------------------------------------------*/
Create Procedure dbo.UspGetCalcs(
	@GridCode nvarchar(100)
)
AS
SET FMTONLY OFF;
SET NOCOUNT ON; 
DECLARE @call VARCHAR(max);
/*LogActivity*/ EXEC USP_LOAD_LOG '17','BeginBeginBeginBeginBeginBeginBeginBeginBeginBegin',@@PROCID,@@error;
SET @call = 'EXEC [UspGetCalcs] @GridCode=' + @GridCode; 
/*LogActivity*/ EXEC USP_LOAD_LOG '25 Proc Call',@call,@@PROCID,@@ERROR;

;WITH
CalcsFromThisGridsOperands AS
	(
		SELECT e.CalcExpressionId, e.TargetGridCode, e.TargetRowCode, e.TargetColCode, e.Expression, e.UpdateContext
		FROM CalcExpression e
		join CalcExpressionOperand eo ON e.CalcExpressionId = eo.CalcExpressionId
		join CalcOperand o ON eo.CalcOperandId = o.CalcOperandId
		WHERE o.GridCode = @GridCode  
		
	UNION ALL
		
		SELECT e2.CalcExpressionId, e2.TargetGridCode, e2.TargetRowCode, e2.TargetColCode, e2.Expression, e2.UpdateContext
		FROM CalcExpression e2
		join CalcExpressionOperand eo2 ON e2.CalcExpressionId = eo2.CalcExpressionId
		join CalcOperand o2 ON eo2.CalcOperandId = o2.CalcOperandId
		Inner Join CalcsFromThisGridsOperands a ON a.TargetGridCode = o2.GridCode and a.TargetRowCode = o2.RowCode and a.TargetColCode = o2.ColCode
		WHERE o2.GridCode != @GridCode
	)
	SELECT DISTINCT a.CalcExpressionId, a.TargetGridCode, a.TargetRowCode, a.TargetColCode, a.Expression, a.UpdateContext, o.GridCode, o.RowCode, o.ColCode
	FROM CalcsFromThisGridsOperands a
	join CalcExpressionOperand eo ON a.CalcExpressionId = eo.CalcExpressionId
	join CalcOperand o ON eo.CalcOperandId = o.CalcOperandId
	UNION
	--include calcs where the target is in this grid, but all operands come from elsewhere
	SELECT e.CalcExpressionId, e.TargetGridCode, e.TargetRowCode, e.TargetColCode, e.Expression, e.UpdateContext, o.GridCode, o.RowCode, o.ColCode
	FROM CalcExpression e
	join CalcExpressionOperand eo ON e.CalcExpressionId = eo.CalcExpressionId
	join CalcOperand o ON eo.CalcOperandId = o.CalcOperandId
	WHERE e.TargetGridCode = @GridCode AND o.GridCode != @GridCode
	OPTION(MAXRECURSION 100)
	GO 
		

/*LogActivity*/ EXEC USP_LOAD_LOG '69  END [UspGetCalcs]' ,@@PROCID,@@ERROR
/*LogActivity*/ EXEC USP_LOAD_LOG '1000 ','EndEndEndEndEndEndEndEndEndEndEndEndEndEnd',@@PROCID,@@ERROR
