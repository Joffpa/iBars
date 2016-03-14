

if exists (select * from sys.objects where type = 'P' and name = 'GetExpressionAndOperands') drop procedure GetExpressionAndOperands
go
create procedure GetExpressionAndOperands(
	@GridCode varchar(100)
	)
	as
	select TargetGridCode, TargetRowCode, TargetColCode, Expression as Expression1 from Expression where TargetGridCode = @GridCode
	select * from Operand where TargetGridCode = @GridCode
