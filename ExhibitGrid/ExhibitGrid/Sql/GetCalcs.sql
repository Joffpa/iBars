--if exists (SELECT * FROM sys.objects WHERE type = 'P' and name = 'GetCalcs') drop procedure GetCalcs
--go

--Create Procedure dbo.GetCalcs(
--	@GridCode varchar(100)
--)
--as

DECLARE @GridCode VARCHAR(100)
SET @GridCode = 'PBA12_ProgData1'
;WITH
AllCalcs AS
	(
		SELECT e.*
		FROM CalcExpression e
		join CalcExpressionOperand eo ON e.CalcExpressionId = eo.CalcExpressionId
		join CalcOperand o ON eo.CalcOperandId = o.CalcOperandId
		WHERE o.GridCode = @GridCode  
		
	UNION ALL
		
		SELECT e2.*
		FROM CalcExpression e2
		join CalcExpressionOperand eo2 ON e2.CalcExpressionId = eo2.CalcExpressionId
		join CalcOperand o2 ON eo2.CalcOperandId = o2.CalcOperandId
		Inner Join AllCalcs a ON a.TargetGridCode = o2.GridCode and a.TargetRowCode = o2.RowCode and a.TargetColCode = o2.ColCode
		WHERE o2.GridCode != @GridCode
	)
	SELECT DISTINCT a.TargetGridCode, a.TargetRowCode, a.TargetColCode, a.Expression, o.GridCode, o.RowCode, o.ColCode
	FROM AllCalcs a
	join CalcExpressionOperand eo ON a.CalcExpressionId = eo.CalcExpressionId
	join CalcOperand o ON eo.CalcOperandId = o.CalcOperandId
	--UNION
	--SELECT e.TargetGridCode, e.TargetRowCode, e.TargetColCode, e.ExpressiON, o.GridCode, o.RowCode, o.ColCode
	--FROM CalcExpression e
	--join CalcExpressionOperand eo ON e.CalcExpressionId = eo.CalcExpressionId
	--join CalcOperand o ON eo.CalcOperandId = o.CalcOperandId
	--WHERE e.TargetGridCode = @GridCode AND o.GridCode != @GridCode
	OPTION(MAXRECURSION 100)
	--order by TargetGridCode, TargetRowCode
	GO