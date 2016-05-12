
EXEC CreateZgridTbls 'CalcGrid1'

select * from zo_CalcGrid1

--update zo_CalcGrid1
--set Pe = '0101', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row1'
--and OutType = 'UI'

--update zo_CalcGrid1
--set Pe = '0103', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row2'
--and OutType = 'UI'

--update zo_CalcGrid1
--set Pe = '0104', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row3'
--and OutType = 'UI'

--update zo_CalcGrid1
--set Pe = '0105', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row4'
--and OutType = 'UI'

--update zo_CalcGrid1
--set Pe = '0106', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row5'
--and OutType = 'UI'

--update zo_CalcGrid1
--set Pe = '0107', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row6'
--and OutType = 'UI'

--update zo_CalcGrid1
--set Pe = '0110', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row7'
--and OutType = 'UI'

--update zo_CalcGrid1
--set Pe = '0111', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row8'
--and OutType = 'UI'

--update zo_CalcGrid1
--set Pe = '0308', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row11'
--and OutType = 'UI'

select * from ColMap 

--update ColMap set ColOrd = 1 where GridCode = 'CalcGrid1'  and ColCode = 'Pe'

DECLARE @Cols GridCols;
INSERT INTO @Cols ( ColCode, ColOrd, DataType, NumOrTxt)
    VALUES	(  N'Pe', 10.0, N'DECIMAL(8,0)', N'N')
   -- ,
			--(  N'ColTwo', 11.0, N'DECIMAL(8,0)', N'N'),
			--(  N'ColThree', 12.0, N'DECIMAL(8,0)', N'N'),
			--(  N'ColFour', 13.0, N'DECIMAL(8,0)', N'N'),
			--(  N'ColFive', 14.0, N'DECIMAL(8,0)', N'N'),
			--(  N'ColSix', 15.0, N'DECIMAL(8,0)', N'N')

EXEC AddZgridCols 'CalcGrid1',@Cols

DECLARE @Rows GridRows;
INSERT INTO @Rows ( RowCode, RowOrd, RowText, RowType)
    VALUES	(  N'CivPersHeader', 1.0, N'CIVILIAN PERSONNEL COMPENSATION', N'HEADERROW'),
			(  N'Row1', 2.0, N'Executive, General and Special Schedules', null),
			(  N'Row2', 3.0, N'Wage board', null),
			(  N'Row3', 4.0, N'Foreign national Direct Hire', null),
			(  N'Row4', 5.0, N'Separation Liability', null),
			(  N'Row5', 6.0, N'Benefits to Former Employees', null),
			(  N'Row6', 7.0, N'Voluntary Separation Incentive Pay', null),
			(  N'Row7', 8.0, N'Unemployment Compensation', null),
			(  N'Row8', 9.0, N'Disability Compensation', null),
			(  N'Row9', 10.0, N'TOTAL CIVILIAN PERSONNEL COMPENSATION', null),
			(  N'BlankRow1', 11.0, N'', null),
			(  N'Row10', 12.0, N'TRAVEL', null),
			(  N'Row11', 13.0, N'TRAVEL OF PERSONS', null),
			(  N'Row12', 14.0, N'TOTAL TRAVEL', null),
			(  N'Row13', 15.0, N'GRAND TOTAL', null)

Exec AddZgridRows 'CalcGrid1', @Rows

EXEC UspPopAttributeDeNormRecs 'CalcGrid1', 0

--select * from AttributeDeNorm
--where GridCode = 'CalcGrid1'

--Column attribs
exec UspUpdAttribVal 'CalcGrid1', '', 'Pe',			'IsEditable=0,HasHeader=0,IsHidden=0,Type=''text'',Width=''80px'',DisplayText='''',ColSpan=1,Level=0,Alignment=''center'',MaxChars=200,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid1', '', 'RowText',	'IsEditable=0,HasHeader=1,IsHidden=0,Type=''text'',Width='''',DisplayText='''',ColSpan=2,Level=0,Alignment=''center'',MaxChars=200,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid1', '', 'ColOne',		'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''120px'',DisplayText=''FY 2016 Program'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid1', '', 'ColTwo',		'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''120px'',DisplayText=''FC Rate Diff'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid1', '', 'ColThree',	'IsEditable=1,HasHeader=1,IsHidden=0,Type=''percent'',Width=''120px'',DisplayText=''Price Growth<br/> Percent'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid1', '', 'ColFour',	'IsEditable=0,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''120px'',DisplayText=''Price Growth'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid1', '', 'ColFive',	'IsEditable=0,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''120px'',DisplayText=''Program Growth'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid1', '', 'ColSix',		'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''120px'',DisplayText=''FY 2017 Program'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''

--row attribs
exec UspUpdAttribVal 'CalcGrid1', 'CivPersHeader', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row1', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row2', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row3', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row4', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row5', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row6', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row7', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row8', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row9', '',			'Type=''subtotal'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'BlankRow1', '',		'Type=''blank'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row10', '',			'Type=''header'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row11', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row12', '',			'Type=''subtotal'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row13', '',			'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''

--Cells
--CivPersHeader
exec UspUpdAttribVal 'CalcGrid1', 'CivPersHeader', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'CivPersHeader', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'CivPersHeader', 'ColOne',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'CivPersHeader', 'ColTwo',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'CivPersHeader', 'ColThree',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'CivPersHeader', 'ColFour',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'CivPersHeader', 'ColFive',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'CivPersHeader', 'ColSix',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row1
exec UspUpdAttribVal 'CalcGrid1', 'Row1', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row1', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row1', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row1', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row1', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row1', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row1', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row1', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row2
exec UspUpdAttribVal 'CalcGrid1', 'Row2', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row2', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row2', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row2', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row2', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row2', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row2', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row2', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row3
exec UspUpdAttribVal 'CalcGrid1', 'Row3', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row3', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row3', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row3', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row3', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row3', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row3', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row3', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row4
exec UspUpdAttribVal 'CalcGrid1', 'Row4', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row4', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row4', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row4', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row4', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row4', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row4', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row4', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row5
exec UspUpdAttribVal 'CalcGrid1', 'Row5', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row5', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row5', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row5', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row5', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row5', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row5', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row5', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row6
exec UspUpdAttribVal 'CalcGrid1', 'Row6', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row6', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row6', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row6', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row6', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row6', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row6', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row6', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row7
exec UspUpdAttribVal 'CalcGrid1', 'Row7', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row7', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row7', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row7', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row7', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row7', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row7', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row7', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row8
exec UspUpdAttribVal 'CalcGrid1', 'Row8', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row8', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row8', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row8', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row8', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row8', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row8', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row8', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row9
exec UspUpdAttribVal 'CalcGrid1', 'Row9', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row9', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row9', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row9', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row9', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=1,Type=''blank'',MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row9', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row9', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row9', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--BlankRow1
exec UspUpdAttribVal 'CalcGrid1', 'BlankRow1', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'BlankRow1', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'BlankRow1', 'ColOne',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'BlankRow1', 'ColTwo',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'BlankRow1', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'BlankRow1', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'BlankRow1', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'BlankRow1', 'ColSix',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row10
exec UspUpdAttribVal 'CalcGrid1', 'Row10', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row10', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row10', 'ColOne',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row10', 'ColTwo',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row10', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row10', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row10', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row10', 'ColSix',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row11
exec UspUpdAttribVal 'CalcGrid1', 'Row11', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row11', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row11', 'ColOne',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row11', 'ColTwo',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row11', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row11', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row11', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row11', 'ColSix',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row12
exec UspUpdAttribVal 'CalcGrid1', 'Row12', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row12', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row12', 'ColOne',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row12', 'ColTwo',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row12', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=1,Type=''blank'',MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row12', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row12', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row12', 'ColSix',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row13
exec UspUpdAttribVal 'CalcGrid1', 'Row13', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row13', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row13', 'ColOne',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row13', 'ColTwo',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row13', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=1,Type=''blank'',MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row13', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row13', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right'',HoverBase=''Delta Check with<br/>Program Growth for Cy/By1''', ''
exec UspUpdAttribVal 'CalcGrid1', 'Row13', 'ColSix',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--

--UspGetAttribVal 'CalcGrid1'

--select * from RowRelationship

--UspGetRowRelationship 'CalcGrid1', null

--delete from RowRelationship where ParGridCode = 'CalcGrid1'

--insert into RowRelationship (ParGridCode,ParRowCode, ChGridCode, ChRowCode, Context)
--select 'CalcGrid1','','CalcGrid1','','total'
--union all
--select 'CalcGrid1','','CalcGrid1','','template'
--union all
--select 'CalcGrid1','','CalcGrid1','','collapse'

--UspGetCalcs 'CalcGrid1' 

Select * from CalcExpression

declare @ExprOper Table(
	CalcExpressionId int,
	CalcOperandId int
)

Insert into @ExprOper
select CalcExpressionId, CalcOperandId 
from CalcExpressionOperand where CalcExpressionId in(
	select e.CalcExpressionId from CalcExpression e
	where e.TargetGridCode = 'CalcGrid1'
) 

delete from CalcExpressionOperand where CalcExpressionId in (Select CalcExpressionId from @ExprOper)

delete from CalcOperand where GridCode = 'CalcGrid1' 
	
delete from CalcExpression where TargetGridCode = 'CalcGrid1' 


DECLARE @CivTotal int, @TravelTotal int, @GrandTotal int, @ProgGrow int, @PriceGrow int, @TotalCivGrowthCell int, @TotalTravGrowthCell int, @GrandTotGrowthCell int, @DeltaCheck int
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid1','Row9','','{CalcGrid1.Row1..} + {CalcGrid1.Row2..} + {CalcGrid1.Row3..} + {CalcGrid1.Row4..} + {CalcGrid1.Row5..} + {CalcGrid1.Row6..} + {CalcGrid1.Row7..} + {CalcGrid1.Row8..}', 'CellValue'
SET @CivTotal = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid1','Row12','','{CalcGrid1.Row11..}', 'CellValue'
SET @TravelTotal = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid1','Row13','','{CalcGrid1.Row9..} + {CalcGrid1.Row12..}', 'CellValue'
SET @GrandTotal = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid1','','ColFive','{CalcGrid1..ColSix.} - {CalcGrid1..ColOne.} - {CalcGrid1..ColTwo.} - {CalcGrid1..ColFour.}', 'CellValue'
SET @ProgGrow = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid1','','ColFour','({CalcGrid1..ColOne.} + {CalcGrid1..ColTwo.}) * {CalcGrid1..ColThree.}', 'CellValue'
SET @PriceGrow = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid1','Row9','ColFour','{CalcGrid1.Row1.ColFour.} + {CalcGrid1.Row2.ColFour.} + {CalcGrid1.Row3.ColFour.} + {CalcGrid1.Row4.ColFour.} + {CalcGrid1.Row5.ColFour.} + {CalcGrid1.Row6.ColFour.} + {CalcGrid1.Row7.ColFour.} + {CalcGrid1.Row8.ColFour.}', 'CellValue'
SET @TotalCivGrowthCell = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid1','Row12','ColFour','{CalcGrid1.Row11.ColFour.}', 'CellValue'
SET @TotalTravGrowthCell = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid1','Row13','ColFour','{CalcGrid1.Row9.ColFour.} + {CalcGrid1.Row12.ColFour.}', 'CellValue'
SET @GrandTotGrowthCell = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid1','Row13','ColFive','{CalcGrid1.Row13.ColFive.} - {CalcGrid2.Row13.ColFive.}', 'DeltaCheck'
SET @DeltaCheck = @@IDENTITY

insert into CalcOperand (GridCode, RowCode, ColCode)
select 'CalcGrid1','Row1',''
union all
select 'CalcGrid1','Row2',''
union all
select 'CalcGrid1','Row3',''
union all
select 'CalcGrid1','Row4',''
union all
select 'CalcGrid1','Row5',''
union all
select 'CalcGrid1','Row6',''
union all
select 'CalcGrid1','Row7',''
union all
select 'CalcGrid1','Row8',''
union all
select 'CalcGrid1','Row1','ColFour'
union all
select 'CalcGrid1','Row2','ColFour'
union all
select 'CalcGrid1','Row3','ColFour'
union all
select 'CalcGrid1','Row4','ColFour'
union all
select 'CalcGrid1','Row5','ColFour'
union all
select 'CalcGrid1','Row6','ColFour'
union all
select 'CalcGrid1','Row7','ColFour'
union all
select 'CalcGrid1','Row8','ColFour'
union all
select 'CalcGrid1','Row9',''
union all
select 'CalcGrid1','Row9','ColFour'
union all
select 'CalcGrid1','Row11',''
union all
select 'CalcGrid1','Row11','ColFour'
union all
select 'CalcGrid1','Row12',''
union all
select 'CalcGrid1','Row12','ColFour'
union all
select 'CalcGrid1','','ColOne'
union all
select 'CalcGrid1','','ColTwo'
union all
select 'CalcGrid1','','ColThree'
union all
select 'CalcGrid1','','ColFour'
union all
select 'CalcGrid1','','ColSix'
union all
select 'CalcGrid1','Row13','ColFive'
union all
select 'CalcGrid2','Row13','ColFive'

insert into CalcExpressionOperand(CalcExpressionId, CalcOperandId)
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row1' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row2' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row3' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row4' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row5' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row6' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row7' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row8' and ColCode = '')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row1' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row2' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row3' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row4' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row5' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row6' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row7' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row8' and ColCode = 'ColFour')
union all
select @TravelTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row11' and ColCode = '')
union all
select @TotalTravGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row11' and ColCode = 'ColFour')
union all
select @GrandTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row9' and ColCode = '')
union all
select @GrandTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row12' and ColCode = '')
union all
select @ProgGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = '' and ColCode = 'ColSix')
union all
select @ProgGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = '' and ColCode = 'ColOne')
union all
select @ProgGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = '' and ColCode = 'ColTwo')
union all
select @ProgGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = '' and ColCode = 'ColFour')
union all
select @PriceGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = '' and ColCode = 'ColOne')
union all
select @PriceGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = '' and ColCode = 'ColTwo')
union all
select @PriceGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = '' and ColCode = 'ColThree')
union all
select @GrandTotGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row9' and ColCode = 'ColFour')
union all
select @GrandTotGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row12' and ColCode = 'ColFour')
union all
select @DeltaCheck, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row13' and ColCode = 'ColFive')
union all
select @DeltaCheck, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row13' and ColCode = 'ColFive')



--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
--Calc Grid 2

EXEC CreateZgridTbls 'CalcGrid2'

select * from zo_CalcGrid2


--update zo_CalcGrid2
--set Pe = '0101', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row1'
--and OutType = 'UI'

--update zo_CalcGrid2
--set Pe = '0103', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row2'
--and OutType = 'UI'

--update zo_CalcGrid2
--set Pe = '0104', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row3'
--and OutType = 'UI'

--update zo_CalcGrid2
--set Pe = '0105', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row4'
--and OutType = 'UI'

--update zo_CalcGrid2
--set Pe = '0106', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row5'
--and OutType = 'UI'

--update zo_CalcGrid2
--set Pe = '0107', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row6'
--and OutType = 'UI'

--update zo_CalcGrid2
--set Pe = '0110', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row7'
--and OutType = 'UI'

--update zo_CalcGrid2
--set Pe = '0111', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row8'
--and OutType = 'UI'

--update zo_CalcGrid2
--set Pe = '0308', ColOne = 0.00, ColTwo = 0.00, ColThree = 0.00, ColFour = 0.00, ColFive = 0.00, ColSix = 0.00
--where RowCode = 'Row11'
--and OutType = 'UI'



update ColMap set ColOrd = .2 where GridCode = 'CalcGrid2'  and ColCode = 'RowText'

DECLARE @Cols GridCols;
INSERT INTO @Cols ( ColCode, ColOrd, DataType, NumOrTxt)
    VALUES	(  N'Pe', .1, N'NVARCHAR(100)', N'N'),
			(  N'ColOne', 11.0, N'DECIMAL(8,2)', N'N'),
			(  N'ColTwo', 12.0, N'DECIMAL(8,2)', N'N'),
			(  N'ColThree', 13.0, N'DECIMAL(8,2)', N'N'),
			(  N'ColFour', 14.0, N'DECIMAL(8,2)', N'N'),
			(  N'ColFive', 15.0, N'DECIMAL(8,2)', N'N'),
			(  N'ColSix', 16.0, N'DECIMAL(8,2)', N'N')

EXEC AddZgridCols 'CalcGrid2',@Cols

DECLARE @Rows GridRows;
INSERT INTO @Rows ( RowCode, RowOrd, RowText, RowType)
    VALUES	(  N'CivPersHeader', 1.0, N'CIVILIAN PERSONNEL COMPENSATION', N'HEADERROW'),
			(  N'Row1', 2.0, N'Executive, General and Special Schedules', null),
			(  N'Row2', 3.0, N'Wage board', null),
			(  N'Row3', 4.0, N'Foreign national Direct Hire', null),
			(  N'Row4', 5.0, N'Separation Liability', null),
			(  N'Row5', 6.0, N'Benefits to Former Employees', null),
			(  N'Row6', 7.0, N'Voluntary Separation Incentive Pay', null),
			(  N'Row7', 8.0, N'Unemployment Compensation', null),
			(  N'Row8', 9.0, N'Disability Compensation', null),
			(  N'Row9', 10.0, N'TOTAL CIVILIAN PERSONNEL COMPENSATION', null),
			(  N'BlankRow1', 11.0, N'', null),
			(  N'Row10', 12.0, N'TRAVEL', N'HEADERROW'),
			(  N'Row11', 13.0, N'TRAVEL OF PERSONS', null),
			(  N'Row12', 14.0, N'TOTAL TRAVEL', null),
			(  N'Row13', 15.0, N'GRAND TOTAL', null)

Exec AddZgridRows 'CalcGrid2', @Rows


EXEC UspPopAttributeDeNormRecs 'CalcGrid2', 0



--Column attribs
exec UspUpdAttribVal 'CalcGrid2', '', 'Pe',			'IsEditable=0,HasHeader=0,IsHidden=0,Type=''text'',Width=''80px'',DisplayText='''',ColSpan=1,Level=0,Alignment=''center'',MaxChars=200,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid2', '', 'RowText',	'IsEditable=0,HasHeader=1,IsHidden=0,Type=''text'',Width='''',DisplayText='''',ColSpan=2,Level=0,Alignment=''center'',MaxChars=200,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid2', '', 'ColOne',		'IsEditable=0,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''120px'',DisplayText=''FY 2017 Program'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid2', '', 'ColTwo',		'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''120px'',DisplayText=''FC Rate Diff'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid2', '', 'ColThree',	'IsEditable=1,HasHeader=1,IsHidden=0,Type=''percent'',Width=''120px'',DisplayText=''Price Growth<br/> Percent'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid2', '', 'ColFour',	'IsEditable=0,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''120px'',DisplayText=''Price Growth'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid2', '', 'ColFive',	'IsEditable=0,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''120px'',DisplayText=''Program Growth'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'CalcGrid2', '', 'ColSix',		'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''120px'',DisplayText=''FY 2018 Program'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''

--row attribs
exec UspUpdAttribVal 'CalcGrid2', 'CivPersHeader', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row1', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row2', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row3', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row4', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row5', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row6', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row7', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row8', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row9', '',			'Type=''subtotal'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'BlankRow1', '',		'Type=''blank'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row10', '',			'Type=''header'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row11', '',			'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row12', '',			'Type=''subtotal'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row13', '',			'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''

--Cells
--CivPersHeader
exec UspUpdAttribVal 'CalcGrid2', 'CivPersHeader', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'CivPersHeader', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'CivPersHeader', 'ColOne',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'CivPersHeader', 'ColTwo',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'CivPersHeader', 'ColThree',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'CivPersHeader', 'ColFour',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'CivPersHeader', 'ColFive',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'CivPersHeader', 'ColSix',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row1
exec UspUpdAttribVal 'CalcGrid2', 'Row1', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row1', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row1', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row1', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row1', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row1', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row1', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row1', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row2
exec UspUpdAttribVal 'CalcGrid2', 'Row2', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row2', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row2', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row2', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row2', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row2', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row2', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row2', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row3
exec UspUpdAttribVal 'CalcGrid2', 'Row3', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row3', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row3', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row3', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row3', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row3', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row3', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row3', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row4
exec UspUpdAttribVal 'CalcGrid2', 'Row4', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row4', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row4', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row4', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row4', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row4', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row4', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row4', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row5
exec UspUpdAttribVal 'CalcGrid2', 'Row5', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row5', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row5', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row5', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row5', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row5', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row5', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row5', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row6
exec UspUpdAttribVal 'CalcGrid2', 'Row6', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row6', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row6', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row6', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row6', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row6', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row6', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row6', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row7
exec UspUpdAttribVal 'CalcGrid2', 'Row7', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row7', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row7', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row7', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row7', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row7', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row7', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row7', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row8
exec UspUpdAttribVal 'CalcGrid2', 'Row8', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row8', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row8', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row8', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row8', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row8', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row8', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row8', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row9
exec UspUpdAttribVal 'CalcGrid2', 'Row9', 'Pe',			'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row9', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row9', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row9', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row9', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=1,Type=''blank'',MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row9', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row9', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row9', 'ColSix',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--BlankRow1
exec UspUpdAttribVal 'CalcGrid2', 'BlankRow1', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'BlankRow1', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'BlankRow1', 'ColOne',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'BlankRow1', 'ColTwo',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'BlankRow1', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'BlankRow1', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'BlankRow1', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'BlankRow1', 'ColSix',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row10
exec UspUpdAttribVal 'CalcGrid2', 'Row10', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row10', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row10', 'ColOne',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row10', 'ColTwo',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row10', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row10', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row10', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row10', 'ColSix',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row11
exec UspUpdAttribVal 'CalcGrid2', 'Row11', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row11', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row11', 'ColOne',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row11', 'ColTwo',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row11', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row11', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row11', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row11', 'ColSix',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row12
exec UspUpdAttribVal 'CalcGrid2', 'Row12', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row12', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row12', 'ColOne',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row12', 'ColTwo',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row12', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=1,Type=''blank'',MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row12', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row12', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row12', 'ColSix',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--Row13
exec UspUpdAttribVal 'CalcGrid2', 'Row13', 'Pe',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''center''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row13', 'RowText',	'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row13', 'ColOne',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row13', 'ColTwo',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row13', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=1,Type=''blank'',MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row13', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row13', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'CalcGrid2', 'Row13', 'ColSix',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--




--UspGetCalcs 'CalcGrid2' 

Select * from CalcExpression

delete from CalcExpressionOperand 
where CalcExpressionId in(
	select CalcExpressionId from CalcExpression 
	where TargetGridCode = 'CalcGrid2'	
)
delete from CalcOperand where GridCode = 'CalcGrid2'	
delete from CalcExpression where TargetGridCode = 'CalcGrid2'	

DECLARE @CivTotal int, @TravelTotal int, @GrandTotal int, @ProgGrow int, @PriceGrow int, @TotalCivGrowthCell int, @TotalTravGrowthCell int, @GrandTotGrowthCell int
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row9','','{CalcGrid2.Row1..} + {CalcGrid2.Row2..} + {CalcGrid2.Row3..} + {CalcGrid2.Row4..} + {CalcGrid2.Row5..} + {CalcGrid2.Row6..} + {CalcGrid2.Row7..} + {CalcGrid2.Row8..}', 'CellValue'
SET @CivTotal = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row12','','{CalcGrid2.Row11..}', 'CellValue'
SET @TravelTotal = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row13','','{CalcGrid2.Row9..} + {CalcGrid2.Row12..}', 'CellValue'
SET @GrandTotal = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','','ColFive','{CalcGrid2..ColSix.} - {CalcGrid2..ColOne.} - {CalcGrid2..ColTwo.} - {CalcGrid2..ColFour.}', 'CellValue'
SET @ProgGrow = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','','ColFour','({CalcGrid2..ColOne.} + {CalcGrid2..ColTwo.}) * {CalcGrid2..ColThree.}', 'CellValue'
SET @PriceGrow = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row9','ColFour','{CalcGrid2.Row1.ColFour.} + {CalcGrid2.Row2.ColFour.} + {CalcGrid2.Row3.ColFour.} + {CalcGrid2.Row4.ColFour.} + {CalcGrid2.Row5.ColFour.} + {CalcGrid2.Row6.ColFour.} + {CalcGrid2.Row7.ColFour.} + {CalcGrid2.Row8.ColFour.}', 'CellValue'
SET @TotalCivGrowthCell = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row12','ColFour','{CalcGrid2.Row11.ColFour.}', 'CellValue'
SET @TotalTravGrowthCell = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row13','ColFour','{CalcGrid2.Row9.ColFour.} + {CalcGrid2.Row12.ColFour.}', 'CellValue'
SET @GrandTotGrowthCell = @@IDENTITY

insert into CalcOperand (GridCode, RowCode, ColCode)
select 'CalcGrid2','Row1',''
union all
select 'CalcGrid2','Row2',''
union all
select 'CalcGrid2','Row3',''
union all
select 'CalcGrid2','Row4',''
union all
select 'CalcGrid2','Row5',''
union all
select 'CalcGrid2','Row6',''
union all
select 'CalcGrid2','Row7',''
union all
select 'CalcGrid2','Row8',''
union all
select 'CalcGrid2','Row1','ColFour'
union all
select 'CalcGrid2','Row2','ColFour'
union all
select 'CalcGrid2','Row3','ColFour'
union all
select 'CalcGrid2','Row4','ColFour'
union all
select 'CalcGrid2','Row5','ColFour'
union all
select 'CalcGrid2','Row6','ColFour'
union all
select 'CalcGrid2','Row7','ColFour'
union all
select 'CalcGrid2','Row8','ColFour'
union all
select 'CalcGrid2','Row9',''
union all
select 'CalcGrid2','Row9','ColFour'
union all
select 'CalcGrid2','Row11',''
union all
select 'CalcGrid2','Row11','ColFour'
union all
select 'CalcGrid2','Row12',''
union all
select 'CalcGrid2','Row12','ColFour'
union all
select 'CalcGrid2','','ColOne'
union all
select 'CalcGrid2','','ColTwo'
union all
select 'CalcGrid2','','ColThree'
union all
select 'CalcGrid2','','ColFour'
union all
select 'CalcGrid2','','ColSix'

insert into CalcExpressionOperand(CalcExpressionId, CalcOperandId)
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row1' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row2' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row3' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row4' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row5' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row6' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row7' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row8' and ColCode = '')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row1' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row2' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row3' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row4' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row5' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row6' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row7' and ColCode = 'ColFour')
union all
select @TotalCivGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row8' and ColCode = 'ColFour')
union all
select @TravelTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row11' and ColCode = '')
union all
select @TotalTravGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row11' and ColCode = 'ColFour')
union all
select @GrandTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row9' and ColCode = '')
union all
select @GrandTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row12' and ColCode = '')
union all
select @ProgGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = '' and ColCode = 'ColSix')
union all
select @ProgGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = '' and ColCode = 'ColOne')
union all
select @ProgGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = '' and ColCode = 'ColTwo')
union all
select @ProgGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = '' and ColCode = 'ColFour')
union all
select @PriceGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = '' and ColCode = 'ColOne')
union all
select @PriceGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = '' and ColCode = 'ColTwo')
union all
select @PriceGrow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = '' and ColCode = 'ColThree')
union all
select @GrandTotGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row9' and ColCode = 'ColFour')
union all
select @GrandTotGrowthCell, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid2' and RowCode = 'Row12' and ColCode = 'ColFour')





--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
--Cross Grids

--declare @ExprOper table

declare @ExprOper Table(
	CalcExpressionId int,
	CalcOperandId int
)

Insert into @ExprOper
select CalcExpressionId, CalcOperandId 
from CalcExpressionOperand where CalcExpressionId in(
	select e.CalcExpressionId from CalcExpression e
	join CalcExpressionOperand eo on e.CalcExpressionId = eo.CalcExpressionId
	join CalcOperand o on eo.CalcOperandId = o.CalcOperandId
	where e.TargetGridCode = 'CalcGrid2'  And  o.GridCode = 'CalcGrid1' 
) 

delete from CalcExpressionOperand where CalcExpressionId in (Select CalcExpressionId from @ExprOper)

delete from CalcOperand where CalcOperandId in (Select CalcOperandId from @ExprOper)
	
delete from CalcExpression where CalcExpressionId in (Select CalcExpressionId from @ExprOper)



DECLARE @CrossRow1 int, @CrossRow2 int, @CrossRow3 int, @CrossRow4 int, @CrossRow5 int, @CrossRow6 int, @CrossRow7 int, @CrossRow8 int, @CrossRow11 int
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row1','ColOne','{CalcGrid1.Row1.ColSix.}', 'CellValue'
SET @CrossRow1 = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row2','ColOne','{CalcGrid1.Row2.ColSix.}', 'CellValue'
SET @CrossRow2 = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row3','ColOne','{CalcGrid1.Row3.ColSix.}', 'CellValue'
SET @CrossRow3 = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row4','ColOne','{CalcGrid1.Row4.ColSix.}', 'CellValue'
SET @CrossRow4 = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row5','ColOne','{CalcGrid1.Row5.ColSix.}', 'CellValue'
SET @CrossRow5 = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row6','ColOne','{CalcGrid1.Row6.ColSix.}', 'CellValue'
SET @CrossRow6 = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row7','ColOne','{CalcGrid1.Row7.ColSix.}', 'CellValue'
SET @CrossRow7 = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row8','ColOne','{CalcGrid1.Row8.ColSix.}', 'CellValue'
SET @CrossRow8 = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'CalcGrid2','Row11','ColOne','{CalcGrid1.Row11.ColSix.}', 'CellValue'
SET @CrossRow11 = @@IDENTITY


insert into CalcOperand (GridCode, RowCode, ColCode)
select 'CalcGrid1','Row1','ColSix'
union all
select 'CalcGrid1','Row2','ColSix'
union all
select 'CalcGrid1','Row3','ColSix'
union all
select 'CalcGrid1','Row4','ColSix'
union all
select 'CalcGrid1','Row5','ColSix'
union all
select 'CalcGrid1','Row6','ColSix'
union all
select 'CalcGrid1','Row7','ColSix'
union all
select 'CalcGrid1','Row8','ColSix'
union all
select 'CalcGrid1','Row11','ColSix'



insert into CalcExpressionOperand(CalcExpressionId, CalcOperandId)
select @CrossRow1, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row1' and ColCode = 'ColSix')
union all
select @CrossRow2, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row2' and ColCode = 'ColSix')
union all
select @CrossRow3, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row3' and ColCode = 'ColSix')
union all
select @CrossRow4, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row4' and ColCode = 'ColSix')
union all
select @CrossRow5, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row5' and ColCode = 'ColSix')
union all
select @CrossRow6, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row6' and ColCode = 'ColSix')
union all
select @CrossRow7, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row7' and ColCode = 'ColSix')
union all
select @CrossRow8, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row8' and ColCode = 'ColSix')
union all
select @CrossRow11, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'CalcGrid1' and RowCode = 'Row11' and ColCode = 'ColSix')
