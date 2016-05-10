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
	TargetGridCode nvarchar(100) not null,
	TargetRowCode nvarchar(100) null,
	TargetColCode nvarchar(100) null,
	Expression nvarchar(1000) not null,
	UpdateContext nvarchar(100) not null
)
go
CREATE UNIQUE NONCLUSTERED INDEX IX_CalcExpression_TargetGridRowColCode
ON [dbo].[CalcExpression](TargetGridCode, TargetRowCode, TargetColCode)
Include (Expression)
go

Create Table CalcOperand(
	CalcOperandId int not null PRIMARY KEY CLUSTERED IDENTITY(1,1),
	GridCode nvarchar(100) not null,
	RowCode nvarchar(100) null,
	ColCode nvarchar(100) null
)

CREATE UNIQUE NONCLUSTERED INDEX IX_CalcOperand_GridRowColCode
ON [dbo].[CalcOperand](GridCode, RowCode, ColCode)
go

Create Table CalcExpressionOperand(
	CalcExpressionId int,
	CalcOperandId int
	PRIMARY KEY CLUSTERED (CalcExpressionId, CalcOperandId),
	CONSTRAINT FK_CalcOperand_CalcOperandId FOREIGN KEY (CalcOperandId) 
    REFERENCES CalcOperand(CalcOperandId) ,
	CONSTRAINT FK_CalcExpression_CalcExpressionId FOREIGN KEY (CalcExpressionId) 
    REFERENCES CalcExpression(CalcExpressionId) 
)

CREATE NONCLUSTERED INDEX IX_CalcExpressionOperand_CalcOperandId
ON [dbo].[CalcExpressionOperand](CalcOperandId)
include(CalcExpressionId)
go
