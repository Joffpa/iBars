



insert into Expression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'MockGrid','Row_1','','{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}'


insert into Operand (TargetGridCode, TargetRowCode, TargetColCode,GridCode, RowCode, ColCode)
select 'MockGrid','Row_1','','MockGrid','Row_2',''
union all
select 'MockGrid','Row_1','','MockGrid','Row_3',''
union all
select 'MockGrid','Row_1','','MockGrid','Row_4',''
union all
select 'MockGrid','Row_1','','MockGrid','Row_5',''
union all
select 'MockGrid','Row_1','','MockGrid','Row_6',''
union all
select 'MockGrid','Row_1','','MockGrid','Row_7',''
union all
select 'MockGrid','Row_1','','MockGrid','Row_8',''
union all
select 'MockGrid','Row_1','','MockGrid','Row_9',''
union all
select 'MockGrid','Row_1','','MockGrid','Row_10',''
union all
select 'MockGrid','Row_1','','MockGrid','Row_11',''
union all
select 'MockGrid','Row_1','','MockGrid','Row_12',''


select * from Operand


select e.*, o.GridCode, o.RowCode, o.ColCode from Expression e
join Operand o on e.TargetGridCode = o.TargetGridCode and e.TargetRowCode = o.TargetRowCode and e.TargetColCode = o.TargetColCode 
where e.TargetGridCode = 'Mockgrid' 



