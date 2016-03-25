if exists (select * from sys.objects where type = 'P' and name = 'GetCalcs') drop procedure GetCalcs
go

Create Procedure dbo.GetCalcs(
	@GridCode varchar(100)
)
as

--Declare @GridCode varchar(100)
--Set @GridCode = 'Grid_A'

;WITH
AllCalcs AS
	(
		select e.*
		from CalcExpression e
		join CalcExpressionOperand eo on e.CalcExpressionId = eo.CalcExpressionId
		join CalcOperand o on eo.CalcOperandId = o.CalcOperandId
		where o.GridCode = @GridCode
		
	UNION ALL

		SELECT e2.*
		from CalcExpression e2
		join CalcExpressionOperand eo2 on e2.CalcExpressionId = eo2.CalcExpressionId
		join CalcOperand o2 on eo2.CalcOperandId = o2.CalcOperandId
		Inner Join AllCalcs a on a.TargetGridCode = o2.GridCode and a.TargetRowCode = o2.RowCode and a.TargetColCode = o2.ColCode
		where o2.GridCode != @GridCode
	)
	Select distinct a.TargetGridCode, a.TargetRowCode, a.TargetColCode, a.Expression, o.GridCode, o.RowCode, o.ColCode 
	from AllCalcs a
	join CalcExpressionOperand eo on a.CalcExpressionId = eo.CalcExpressionId
	join CalcOperand o on eo.CalcOperandId = o.CalcOperandId
	OPTION(MAXRECURSION 100)
	--order by TargetGridCode, TargetRowCode
	go