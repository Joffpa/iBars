

insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'MockGrid','Row_1','','{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}'

insert into CalcOperand (GridCode, RowCode, ColCode)
select 'MockGrid','Row_2',''
union all
select 'MockGrid','Row_3',''
union all
select 'MockGrid','Row_4',''
union all
select 'MockGrid','Row_5',''
union all
select 'MockGrid','Row_6',''
union all
select 'MockGrid','Row_7',''
union all
select 'MockGrid','Row_8',''
union all
select 'MockGrid','Row_9',''
union all
select 'MockGrid','Row_10',''
union all
select 'MockGrid','Row_11',''
union all
select 'MockGrid','Row_12',''

insert into CalcExpressionOperand(CalcExpressionId, CalcOperandId)
select 1,1
union all
select 1,2
union all
select 1,3
union all
select 1,4
union all
select 1,5
union all
select 1,6
union all
select 1,7
union all
select 1,8
union all
select 1,9
union all
select 1,10
union all
select 1,11
union all
select 1,12


select * from CalcExpression
select * from CalcExpressionOperand
select * from CalcOperand