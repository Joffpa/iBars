
if exists (select * from sys.objects where type = 'U' and name = 'CalcExpressionOperand') drop table CalcExpressionOperand
if exists (select * from sys.objects where type = 'U' and name = 'CalcOperand') drop table CalcOperand
if exists (select * from sys.objects where type = 'U' and name = 'CalcExpression') drop table CalcExpression

CREATE TABLE CalcExpression(
	CalcExpressionId int not null PRIMARY KEY IDENTITY(1,1),
	TargetGridCode varchar(100) not null,
	TargetRowCode varchar(100) null,
	TargetColCode varchar(100) null,
	Expression varchar(1000) not null
)


Create Table CalcOperand(
	CalcOperandId int not null PRIMARY KEY IDENTITY(1,1),
	GridCode varchar(100) not null,
	RowCode varchar(100) null,
	ColCode varchar(100) null
)

Create Table CalcExpressionOperand(
	CalcExpressionId int,
	CalcOperandId int,
	Primary KEY (CalcExpressionId,CalcOperandId),
	CONSTRAINT FK_CalcOperand_CalcOperandId FOREIGN KEY (CalcOperandId) 
    REFERENCES CalcOperand(CalcOperandId) ,
	CONSTRAINT FK_CalcExpression_CalcExpressionId FOREIGN KEY (CalcExpressionId) 
    REFERENCES CalcExpression(CalcExpressionId) 
)

