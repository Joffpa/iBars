


if exists (select * from sys.objects where type = 'U' and name = 'Operand') drop table Operand
if exists (select * from sys.objects where type = 'U' and name = 'Expression') drop table Expression

Create Table Expression(	
	TargetGridCode varchar(100) not null,
	TargetRowCode varchar(100) not null,
	TargetColCode varchar(100) not null,
	Expression varchar(1000) not null,
	Primary Key (TargetGridCode, TargetRowCode, TargetColCode)
)



Create Table Operand(
	TargetGridCode varchar(100) not null,
	TargetRowCode varchar(100) not null,
	TargetColCode varchar(100) not null,
	GridCode varchar(100) not null,
	RowCode varchar(100) not null,
	ColCode varchar(100) not null,	
	Primary Key (TargetGridCode, TargetRowCode,TargetColCode,GridCode, RowCode, ColCode),
	Foreign Key (TargetGridCode, TargetRowCode,TargetColCode)
	REFERENCES Expression(TargetGridCode, TargetRowCode,TargetColCode),
)