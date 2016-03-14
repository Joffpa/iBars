



if exists (select * from sys.objects where type = 'P' and name = 'GetCalcs') drop procedure GetCalcs
go

Create Procedure dbo.GetCalcs(
	@GridCode varchar(100)
)
as

select e.*, o.GridCode, o.RowCode, o.ColCode from Expression e
join Operand o on e.TargetGridCode = o.TargetGridCode and e.TargetRowCode = o.TargetRowCode and e.TargetColCode = o.TargetColCode 
where e.TargetGridCode = @GridCode 
go