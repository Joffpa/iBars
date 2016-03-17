IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CalcOperand_CalcOperandId]') AND parent_object_id = OBJECT_ID(N'[dbo].[CalcExpressionOperand]'))
ALTER TABLE [dbo].[CalcExpressionOperand] DROP CONSTRAINT [FK_CalcOperand_CalcOperandId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CalcExpression_CalcExpressionId]') AND parent_object_id = OBJECT_ID(N'[dbo].[FK_CalcExpression_CalcExpressionId]'))
ALTER TABLE [dbo].[CalcExpressionOperand] DROP CONSTRAINT [FK_CalcExpression_CalcExpressionId]
GO
/****** Object:  Table [dbo].[CalcExpression] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalcExpressionOperand]') AND type in (N'U'))
DROP TABLE [dbo].[CalcExpressionOperand]
GO
/****** Object:  Table [dbo].[CalcExpression] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalcExpression]') AND type in (N'U'))
DROP TABLE [dbo].[CalcExpression]
GO
/****** Object:  Table [dbo].[CalcOperand] ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalcOperand]') AND type in (N'U'))
DROP TABLE [dbo].[CalcOperand]
GO

CREATE TABLE [dbo].[CalcExpression](
	CalcExpressionId int not null PRIMARY KEY CLUSTERED IDENTITY(1,1),
	TargetGridCode varchar(100) not null,
	TargetRowCode varchar(100) null,
	TargetColCode varchar(100) null,
	Expression varchar(1000) not null
)
go
CREATE UNIQUE NONCLUSTERED INDEX IX_CalcExpression_TargetGridRowColCode
ON [dbo].[CalcExpression](TargetGridCode, TargetRowCode, TargetColCode)
Include (Expression)
go

Create Table CalcOperand(
	CalcOperandId int not null PRIMARY KEY CLUSTERED IDENTITY(1,1),
	GridCode varchar(100) not null,
	RowCode varchar(100) null,
	ColCode varchar(100) null
)

CREATE UNIQUE NONCLUSTERED INDEX IX_CalcOperand_GridRowColCode
ON [dbo].[CalcOperand](GridCode, RowCode, ColCode)
go

Create Table CalcExpressionOperand(
	CalcExpressionOperandId  int  PRIMARY KEY CLUSTERED IDENTITY(1,1),
	CalcExpressionId int,
	CalcOperandId int,
	CONSTRAINT FK_CalcOperand_CalcOperandId FOREIGN KEY (CalcOperandId) 
    REFERENCES CalcOperand(CalcOperandId) ,
	CONSTRAINT FK_CalcExpression_CalcExpressionId FOREIGN KEY (CalcExpressionId) 
    REFERENCES CalcExpression(CalcExpressionId) 
)

CREATE NONCLUSTERED INDEX IX_CalcExpressionOperand_CalcExpressionId
ON [dbo].[CalcExpressionOperand](CalcExpressionId)
include(CalcOperandId)
go

CREATE NONCLUSTERED INDEX IX_CalcExpressionOperand_CalcOperandId
ON [dbo].[CalcExpressionOperand](CalcOperandId)
include(CalcExpressionId)
go

insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'Grid_A','Row_3','','{Grid_A.Row_1..} + {Grid_A.Row_2..}'
union all
select 'Grid_A','Row_5','','{Grid_A.Row_3..} + {Grid_A.Row_4..}'
union all
select 'Grid_B','Row_1','','{Grid_A.Row_1..} + {Grid_A.Row_2..}'
union all
select 'Grid_B','Row_3','','{Grid_B.Row_1..} + {Grid_B.Row_2..}'
union all
select 'Grid_A','Row_6','','{Grid_A.Row_1..} + {Grid_B.Row_1..}'
union all
select 'Grid_C','Row_6','','{Grid_C.Row_1..} + {Grid_C.Row_2..}'
insert into CalcOperand (GridCode, RowCode, ColCode)
select 'Grid_A','Row_1',''
union all
select 'Grid_A','Row_2',''
union all
select 'Grid_A','Row_3',''
union all
select 'Grid_A','Row_4',''
union all
select 'Grid_B','Row_1',''
union all
select 'Grid_B','Row_2',''
union all
select 'Grid_C','Row_1',''
union all
select 'Grid_C','Row_2',''

insert into CalcExpressionOperand(CalcExpressionId, CalcOperandId)
select 1, 1
union all
select 1, 2
union all
select 2, 3
union all
select 2, 4
union all
select 3, 1
union all
select 3, 2
union all
select 4, 5
union all
select 4, 6
union all
select 5, 1
union all
select 5, 5
union all
select 6, 7
union all
select 6, 8

--select * from CalcExpression
--select * from CalcExpressionOperand
--select * from CalcOperand