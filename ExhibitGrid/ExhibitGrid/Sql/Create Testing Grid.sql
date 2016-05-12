
EXEC CreateZgridTbls 'TestGrid'

select * from zo_TestGrid

--update zo_TestGrid
--	set ColOne = '0.00', ColTwo = '0.00', ColThree = '0.00', ColFour = '0.00', ColFive = '0.00'
--	where RowCode in ('RowA', 'RowB', 'RowC', 'RowD')   --RowCode = ''
--	and OutType = 'UI'

select * from ColMap 

--update ColMap set ColOrd = .1 where GridCode = 'TestGrid'  and ColCode = 'RowText'

DECLARE @Cols GridCols;
INSERT INTO @Cols ( ColCode, ColOrd, DataType, NumOrTxt)
    VALUES	(  N'ColOne', 10.0, N'DECIMAL(8,0)', N'N'),
			(  N'ColTwo', 11.0, N'DECIMAL(8,0)', N'N'),
			(  N'ColThree', 12.0, N'DECIMAL(8,0)', N'N'),
			(  N'ColFour', 13.0, N'DECIMAL(8,0)', N'N'),
			(  N'ColFive', 14.0, N'DECIMAL(8,0)', N'N')

EXEC AddZgridCols 'TestGrid',@Cols

DECLARE @Rows GridRows;
INSERT INTO @Rows ( RowCode, RowOrd, RowText, RowType, Model)
    VALUES	
	--(  N'RowA', 1.0, N'Row A', N'HEADERROW', N''),
			--(  N'RowB', 2.0, N'Row B', null, N''),
			--(  N'RowC', 3.0, N'Row C', null, N''),
			--(  N'RowD', 4.0, N'Row D', null, N''),
			--(  N'TemplateRowA', 5.0, N'Template Row', null, N'Model'),
			--(  N'TemplateRowB2', 5.0, N'Template Row', null, N'Model'),
			--(  N'TemplateRowB', 5.0, N'Template Row', null, N'Model'),
			--(  N'TemplateRowC1', 1.0, N'Template Row', null, N'Model'),
			--(  N'TemplateRowC2', 2.0, N'Template Row', null, N'Model'),
			--(  N'TemplateRowC3', 2.0, N'Template Row', null, N'Model')
			--(  N'TemplateRowC3', 2.0, N'Template Row', null, N'Model'),
			(  N'TemplateRowD1', 2.0, N'Template Row', null, N'Model'),
			(  N'TemplateRowD2', 2.0, N'Template Row', null, N'Model'),
			(  N'TemplateRowD3', 2.0, N'Template Row', null, N'Model'),
			(  N'TemplateRowD4', 2.0, N'Template Row', null, N'Model'),
			(  N'TemplateRowD5', 2.0, N'Template Row', null, N'Model')

Exec AddZgridRows 'TestGrid', @Rows

--UspPopAttributeDeNormRecs 'TestGrid', 0

--select * from AttributeDeNorm
--where GridCode = 'TestGrid'

--Column attribs
exec UspUpdAttribVal 'TestGrid', '', 'RowText',		'IsEditable=1,HasHeader=1,IsHidden=0,Type=''text'',Width='''',DisplayText='''',ColSpan=1,Level=0,Alignment=''center'',MaxChars=200,DecimalPlaces=2', ''
exec UspUpdAttribVal 'TestGrid', '', 'ColOne',		'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''100px'',DisplayText=''Column 1'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'TestGrid', '', 'ColTwo',		'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''100px'',DisplayText=''Column 2'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'TestGrid', '', 'ColThree',	'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''100px'',DisplayText=''Column 3'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'TestGrid', '', 'ColFour',		'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''100px'',DisplayText=''Column 4'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'TestGrid', '', 'ColFive',		'IsEditable=0,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''100px'',DisplayText=''Column 5'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
--row attribs
exec UspUpdAttribVal 'TestGrid', 'RowA', '',  'Type=''subtotal'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=1,CanDelete=0', ''
exec UspUpdAttribVal 'TestGrid', 'RowB', '',  'Type=''subtotal'',IsEditable=0,IsHidden=0,CanCollapse=1,CanSelect=0,CanAdd=1,CanDelete=0', ''
exec UspUpdAttribVal 'TestGrid', 'RowC', '',  'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=1,CanSelect=0,CanAdd=1,CanDelete=0', ''
exec UspUpdAttribVal 'TestGrid', 'RowD', '',  'Type=''subtotal'',IsEditable=1,IsHidden=0,CanCollapse=1,CanSelect=0,CanAdd=1,CanDelete=0', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowA', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=1,CanAdd=0,CanDelete=1', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=1,CanAdd=0,CanDelete=1', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB2', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=1,CanAdd=0,CanDelete=1', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC1', '',  'Type=''header'',IsEditable=1,IsHidden=0,CanCollapse=1,CanSelect=0,CanAdd=0,CanDelete=1', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC2', '',  'Type=''header'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC3', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD1', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD2', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD3', '',  'Type=''header'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD4', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD5', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
--Cells
--RowA
exec UspUpdAttribVal 'TestGrid', 'RowA', 'RowText',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'RowA', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowA', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowA', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowA', 'ColFour',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowA', 'ColFive',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--RowB
exec UspUpdAttribVal 'TestGrid', 'RowB', 'RowText',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'RowB', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowB', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowB', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowB', 'ColFour',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowB', 'ColFive',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--RowC
exec UspUpdAttribVal 'TestGrid', 'RowC', 'RowText',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'RowC', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowC', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowC', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowC', 'ColFour',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowC', 'ColFive',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--RowD
exec UspUpdAttribVal 'TestGrid', 'RowD', 'RowText',		'ColSpan=1,IsEditable=0,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'RowD', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowD', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowD', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowD', 'ColFour',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'RowD', 'ColFive',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowA
exec UspUpdAttribVal 'TestGrid', 'TemplateRowA', 'RowText',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowA', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowA', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowA', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowA', 'ColFour',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowA', 'ColFive',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowB
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB', 'RowText',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB', 'ColFour',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB', 'ColFive',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowB2
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB2', 'RowText',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB2', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB2', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB2', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB2', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowB2', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowC1
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC1', 'RowText',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC1', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC1', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC1', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC1', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC1', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowC2
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC2', 'RowText',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC2', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC2', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC2', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC2', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC2', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowC3
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC3', 'RowText',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC3', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC3', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC3', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC3', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowC3', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowD1
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD1', 'RowText',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD1', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD1', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD1', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD1', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD1', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowD2
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD2', 'RowText',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD2', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD2', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD2', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD2', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD2', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowD2
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD3', 'RowText',	'ColSpan=1,IsEditable=1,Indent=1,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD3', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD3', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD3', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD3', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD3', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowD4
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD4', 'RowText',	'ColSpan=1,IsEditable=1,Indent=2,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD4', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD4', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD4', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD4', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD4', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
--TemplateRowD5
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD5', 'RowText',	'ColSpan=1,IsEditable=1,Indent=2,OverrideColSettings=0,Type=null,MaxChars=200,DecimalPlaces=0,Alignment=''left''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD5', 'ColOne',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD5', 'ColTwo',		'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD5', 'ColThree',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD5', 'ColFour',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'TestGrid', 'TemplateRowD5', 'ColFive',	'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''


--UspGetAttribVal 'TestGrid'

--select * from RowRelationship

--UspGetRowRelationship 'TestGrid', null

delete from RowRelationship where ParGridCode = 'TestGrid'

insert into RowRelationship (ParGridCode,ParRowCode, ChGridCode, ChRowCode, Context)
select 'TestGrid','RowA','TestGrid','TemplateRowA','total'
union all
select 'TestGrid','RowA','TestGrid','TemplateRowA','addrowtemplate'
union all
select 'TestGrid','RowA','TestGrid','TemplateRowA','collapse'
union all
select 'TestGrid','RowB','TestGrid','TemplateRowB','total'
union all
select 'TestGrid','RowB','TestGrid','TemplateRowB','addrowtemplate'
union all
select 'TestGrid','RowB','TestGrid','TemplateRowB','collapse'
union all
select 'TestGrid','RowB','TestGrid','TemplateRowB2','total'
union all
select 'TestGrid','RowB','TestGrid','TemplateRowB2','addrowtemplate'
union all
select 'TestGrid','RowB','TestGrid','TemplateRowB2','collapse'
union all
select 'TestGrid','RowC','TestGrid','TemplateRowC1','addrowtemplate'
union all
select 'TestGrid','RowC','TestGrid','TemplateRowC1','collapse'
union all
select 'TestGrid','RowC','TestGrid','TemplateRowC2','addrowtemplate'
union all
--select 'TestGrid','RowC','TestGrid','TemplateRowC2','total'
--union all
select 'TestGrid','TemplateRowC1','TestGrid','TemplateRowC2','collapse'
union all
select 'TestGrid','RowC','TestGrid','TemplateRowC3','addrowtemplate'
union all
select 'TestGrid','RowC','TestGrid','TemplateRowC3','total'
union all
select 'TestGrid','TemplateRowC1','TestGrid','TemplateRowC3','collapse'
union all
select 'TestGrid','RowD','TestGrid','TemplateRowD1','collapse'
union all
select 'TestGrid','RowD','TestGrid','TemplateRowD1','addrowtemplate'
union all
select 'TestGrid','RowD','TestGrid','TemplateRowD2','collapse'
union all
select 'TestGrid','RowD','TestGrid','TemplateRowD2','addrowtemplate'
union all
select 'TestGrid','RowD','TestGrid','TemplateRowD3','collapse'
union all
select 'TestGrid','RowD','TestGrid','TemplateRowD3','addrowtemplate'
union all
select 'TestGrid','RowD','TestGrid','TemplateRowD4','collapse'
union all
select 'TestGrid','RowD','TestGrid','TemplateRowD4','addrowtemplate'
union all
select 'TestGrid','RowD','TestGrid','TemplateRowD5','collapse'
union all
select 'TestGrid','RowD','TestGrid','TemplateRowD5','addrowtemplate'

--UspGetCalcs 'TestGrid' 

Select * from CalcExpression

delete from CalcExpressionOperand 
where CalcExpressionId in(
	select CalcExpressionId from CalcExpression 
	where TargetGridCode = 'TestGrid'	
)
delete from CalcOperand where GridCode = 'TestGrid'	
delete from CalcExpression where TargetGridCode = 'TestGrid'	


DECLARE @Calc1 int
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'TestGrid','','ColFive','{TestGrid..ColThree.} + {TestGrid..ColFour.} ', 'CellValue'
SET @Calc1 = @@IDENTITY


insert into CalcOperand (GridCode, RowCode, ColCode)
select 'TestGrid','','ColThree'
union all
select 'TestGrid','','ColFour'


insert into CalcExpressionOperand(CalcExpressionId, CalcOperandId)
select @Calc1, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'TestGrid' and RowCode = '' and ColCode = 'ColThree')
union all
select @Calc1, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'TestGrid' and RowCode = '' and ColCode = 'ColFour')

