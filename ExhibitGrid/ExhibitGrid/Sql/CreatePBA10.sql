
EXEC CreateZgridTbls 'PBA10_PersonnelData'

select * from zo_PBA10_PersonnelData

--update zo_PBA10_PersonnelData
--	set Py = 10, Cy = 50, By1 = 100
--	where RowCode = 'ActFor_Officer'
--	and OutType = 'UI'
--update zo_PBA10_PersonnelData
--	set Py = 20, Cy = 60, By1 = 110
--	where RowCode = 'ActFor_Enlisted'
--	and OutType = 'UI'
--update zo_PBA10_PersonnelData
--	set Py = 30, Cy = 70, By1 = 120
--	where RowCode = 'ResGuard_Officer'
--	and OutType = 'UI'
--update zo_PBA10_PersonnelData
--	set Py = 40, Cy = 80, By1 = 130
--	where RowCode = 'ResGuard_Enlisted'
--	and OutType = 'UI'
--update zo_PBA10_PersonnelData
--	set Py = 50, Cy = 90, By1 = 140
--	where RowCode = 'Civ_UsDirect'
--	and OutType = 'UI'
--update zo_PBA10_PersonnelData
--	set Py = 60, Cy = 100, By1 = 150
--	where RowCode = 'Civ_ForNatDirect'
--	and OutType = 'UI'
--update zo_PBA10_PersonnelData
--	set Py = 70, Cy = 110, By1 = 160
--	where RowCode = 'Civ_ForNatInDir'
--	and OutType = 'UI'


select * from ColMap 

--insert into ColMap (GridCode, ColCode, ColOrd, OutColType, StgColType, tableSpecific, CellType, col_code)
--select 'PBA10_PersonnelData', 'RowText', .5, N'NVARCHAR(255) Default('')', N'NVARCHAR(255) Default('')', '', 'IsGridTxt', 'row_text'

--delete from ColMap where ColMapId =398

DECLARE @Cols GridCols;
INSERT INTO @Cols ( ColCode, ColOrd, DataType, NumOrTxt)
    VALUES (  N'Py', 10.0, N'DECIMAL(8,0)', N'N'),
    (  N'PyCyChange', 11.0, N'DECIMAL(8,0)', N'N'),
    (  N'Cy', 12.0, N'DECIMAL(8,0)', N'N'),
    (  N'CyBy1Change', 13.0, N'DECIMAL(8,0)', N'N'),
    (  N'By1', 14.0, N'DECIMAL(8,0)', N'N')

EXEC AddZgridCols 'PBA10_PersonnelData',@Cols

DECLARE @Rows GridRows;
INSERT INTO @Rows ( RowCode, RowOrd, RowText, RowType)
    VALUES (  N'ActFor_Header', 1.0, N'Active Force Personnel (End Strength)', N'HEADERROW'),
    (  N'ActFor_Officer', 2.0, N'Officer', null),
    (  N'ActFor_Enlisted', 3.0, N'Enlisted', null),
    (  N'ActFor_Total', 4.0, N'Total', null),
    (  N'ActFor_Blank', 5.0, N'', null),
    (  N'ResGuard_Header', 6.0, N'Selected Reserve and Guard Personnel (End Strength)', N'HEADERROW'),
    (  N'ResGuard_Officer', 7.0, N'Officer', null),
    (  N'ResGuard_Enlisted', 8.0, N'Enlisted', null),
    (  N'ResGuard_Total', 9.0, N'Total', null),
    (  N'ResGuard_Blank', 10.0, N'', null),
    (  N'Civ_Header', 11.0, N'Civilian Personnel (Full-Time Equivalents)', N'HEADERROW'),
    (  N'Civ_UsDirect', 12.0, N'U.S. Direct Hires', null),
    (  N'Civ_ForNatDirect', 13.0, N'Foreign National Direct Hire', null),
    (  N'Civ_TotalDirect', 14.0, N'Total Direct Hire', null),
    (  N'Civ_ForNatInDir', 15.0, N'Foreign National Indirect Hire', null),
    (  N'Civ_Total', 16.0, N'Total', null)

Exec AddZgridRows 'PBA10_PersonnelData', @Rows


--UspPopAttributeDeNormRecs 'PBA10_PersonnelData', 0


--select * from AttributeDeNorm
--where GridCode = 'PBA10_PersonnelData'

--Column attribs
exec UspUpdAttribVal 'PBA10_PersonnelData', '', 'RowText',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''text'',Width='''',DisplayText='''',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', '', 'Py',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''100px'',DisplayText=''FY 2015 Enacted'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=5,DecimalPlaces=2', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', '', 'PyCyChange',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''100px'',DisplayText=''Change'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=6,DecimalPlaces=2', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', '', 'Cy',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''100px'',DisplayText=''FY 2016 Estimate'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', '', 'CyBy1Change',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''100px'',DisplayText=''Change'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', '', 'By1',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''100px'',DisplayText=''FY 2017 Estimate'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=8,DecimalPlaces=2', ''

--row attribs 
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Header', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Officer', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Enlisted', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Total', '',  'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Blank', '',  'Type=''blank'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Header', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Officer', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Enlisted', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Total', '',  'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Blank', '',  'Type=''blank'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Header', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_UsDirect', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatDirect', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_TotalDirect', '',  'Type=''subtotal'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatInDir', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Total', '',  'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''



--Cells
--ActFor_Header Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Header', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Header', 'Py',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Header', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Header', 'Cy',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Header', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Header', 'By1',  'ColSpan=1,IsEditable=0,Indent=0', ''


--ActFor_Officer Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Officer', 'RowText',  'ColSpan=1,IsEditable=0,Indent=1,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Officer', 'Py',  'ColSpan=1,IsEditable=1,Indent=0,OverrideColSettings=0,Type=null,MaxChars=5,DecimalPlaces=2,Alignment=''right''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Officer', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Officer', 'Cy',  'ColSpan=1,IsEditable=1,Indent=1', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Officer', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Officer', 'By1',  'ColSpan=1,IsEditable=1,Indent=0', ''

--ActFor_Enlisted Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Enlisted', 'RowText',  'ColSpan=1,IsEditable=0,Indent=1,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Enlisted', 'Py',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Enlisted', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Enlisted', 'Cy',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Enlisted', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Enlisted', 'By1',  'ColSpan=1,IsEditable=1,Indent=0', ''

--ActFor_Total Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Total', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Total', 'Py',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Total', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Total', 'Cy',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Total', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Total', 'By1',  'ColSpan=1,IsEditable=0,Indent=0', ''

--ActFor_Blank Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Blank', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Blank', 'Py',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Blank', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Blank', 'Cy',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Blank', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ActFor_Blank', 'By1',  'ColSpan=1,IsEditable=0,Indent=0', ''

--ResGuard_Header Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Header', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Header', 'Py',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Header', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Header', 'Cy',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Header', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Header', 'By1',  'ColSpan=1,IsEditable=0,Indent=0', ''

--ResGuard_Officer Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Officer', 'RowText',  'ColSpan=1,IsEditable=0,Indent=1,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Officer', 'Py',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Officer', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Officer', 'Cy',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Officer', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Officer', 'By1',  'ColSpan=1,IsEditable=1,Indent=0', ''

--ResGuard_Enlisted Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Enlisted', 'RowText',  'ColSpan=1,IsEditable=0,Indent=1,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Enlisted', 'Py',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Enlisted', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Enlisted', 'Cy',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Enlisted', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Enlisted', 'By1',  'ColSpan=1,IsEditable=1,Indent=0', ''

--ResGuard_Total Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Total', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Total', 'Py',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Total', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Total', 'Cy',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Total', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Total', 'By1',  'ColSpan=1,IsEditable=0,Indent=0', ''

--ResGuard_Blank Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Blank', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Blank', 'Py',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Blank', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Blank', 'Cy',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Blank', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'ResGuard_Blank', 'By1',  'ColSpan=1,IsEditable=0,Indent=0', ''

--Civ_Header Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Header', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Header', 'Py',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Header', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Header', 'Cy',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Header', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Header', 'By1',  'ColSpan=1,IsEditable=0,Indent=0', ''
--Civ_UsDirect Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_UsDirect', 'RowText',  'ColSpan=1,IsEditable=0,Indent=1,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_UsDirect', 'Py',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_UsDirect', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_UsDirect', 'Cy',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_UsDirect', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_UsDirect', 'By1',  'ColSpan=1,IsEditable=1,Indent=0', ''
--Civ_ForNatDirect Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatDirect', 'RowText',  'ColSpan=1,IsEditable=0,Indent=1,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatDirect', 'Py',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatDirect', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatDirect', 'Cy',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatDirect', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatDirect', 'By1',  'ColSpan=1,IsEditable=1,Indent=0', ''

--Civ_TotalDirect Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_TotalDirect', 'RowText',  'ColSpan=1,IsEditable=0,Indent=2,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_TotalDirect', 'Py',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_TotalDirect', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_TotalDirect', 'Cy',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_TotalDirect', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_TotalDirect', 'By1',  'ColSpan=1,IsEditable=0,Indent=0', ''

--Civ_ForNatInDir Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatInDir', 'RowText',  'ColSpan=1,IsEditable=0,Indent=1,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatInDir', 'Py',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatInDir', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatInDir', 'Cy',  'ColSpan=1,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatInDir', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_ForNatInDir', 'By1',  'ColSpan=1,IsEditable=1,Indent=0', ''

--Civ_Total Row
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Total', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''left''', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Total', 'Py',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Total', 'PyCyChange',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Total', 'Cy',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Total', 'CyBy1Change',  'ColSpan=1,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA10_PersonnelData', 'Civ_Total', 'By1',  'ColSpan=1,IsEditable=0,Indent=0', ''



--UspGetAttribVal 'PBA10_PersonnelData'



select * from RowRelationship

UspGetRowRelationship 'PBA10_PersonnelData', null

delete from RowRelationship where ParGridCode = 'PBA10_PersonnelData'

insert into RowRelationship (ParGridCode,ParRowCode, ChGridCode, ChRowCode, Context)
select 'PBA10_PersonnelData','ActFor_Total','PBA10_PersonnelData','ActFor_Officer','total'
union all
select 'PBA10_PersonnelData','ActFor_Total','PBA10_PersonnelData','ActFor_Enlisted','total'


delete from CalcExpressionOperand 
where CalcExpressionOperandId in(
	select CalcExpressionOperandId from CalcExpressionOperand eo
	Join CalcExpression o on eo.CalcExpressionId = o.CalcExpressionId
	where o.TargetGridCode = 'PBA10_PersonnelData'	
)
delete from CalcOperand where GridCode = 'PBA10_PersonnelData'	
delete from CalcExpression where TargetGridCode = 'PBA10_PersonnelData'	

delete from CalcExpressionOperand 
where CalcExpressionOperandId in(
	select CalcExpressionOperandId from CalcExpressionOperand eo
	Join CalcExpression o on eo.CalcExpressionId = o.CalcExpressionId
	where o.TargetGridCode = 'PBA12_ProgData1' and o.TargetRowCode = 'PBA12_ProgData_CommunSustBase' and o.TargetColCode = 'Py'
)
delete from CalcOperand where GridCode = 'PBA12_ProgData1'	and RowCode = 'PBA12_ProgData_CommunSustBase' and ColCode = 'Py'





DECLARE @ActTotal int, @ResTotal int, @DirHireTotal int, @CivTotal int, @PyCyChange int, @CyBy1Change int, @CrossGrid int
--insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
--select 'PBA10_PersonnelData','ActFor_Total','','{PBA10_PersonnelData.ActFor_Officer..} + {PBA10_PersonnelData.ActFor_Enlisted..} '
--SET @ActTotal = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'PBA10_PersonnelData','ResGuard_Total','','{PBA10_PersonnelData.ResGuard_Officer..} + {PBA10_PersonnelData.ResGuard_Enlisted..} '
SET @ResTotal = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'PBA10_PersonnelData','Civ_TotalDirect','','{PBA10_PersonnelData.Civ_UsDirect..} + {PBA10_PersonnelData.Civ_ForNatDirect..} '
SET @DirHireTotal = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'PBA10_PersonnelData','Civ_Total','','{PBA10_PersonnelData.Civ_UsDirect..} + {PBA10_PersonnelData.Civ_ForNatDirect..} + {PBA10_PersonnelData.Civ_ForNatInDir..}'
SET @CivTotal = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'PBA10_PersonnelData','','PyCyChange','{PBA10_PersonnelData..Cy.} - {PBA10_PersonnelData..Py.}'
SET @PyCyChange = @@IDENTITY
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'PBA10_PersonnelData','','CyBy1Change','{PBA10_PersonnelData..By1.} - {PBA10_PersonnelData..Cy.}'
SET @CyBy1Change = @@IDENTITY


insert into CalcOperand (GridCode, RowCode, ColCode)
--select 'PBA10_PersonnelData','ActFor_Officer',''
--union all
--select 'PBA10_PersonnelData','ActFor_Enlisted',''
--union all
select 'PBA10_PersonnelData','ResGuard_Officer',''
union all
select 'PBA10_PersonnelData','ResGuard_Enlisted',''
union all
select 'PBA10_PersonnelData','Civ_UsDirect',''
union all
select 'PBA10_PersonnelData','Civ_ForNatDirect',''
union all
select 'PBA10_PersonnelData','Civ_ForNatInDir',''
union all
select 'PBA10_PersonnelData','','Py'
union all
select 'PBA10_PersonnelData','','Cy'
union all
select 'PBA10_PersonnelData','','By1'


insert into CalcExpressionOperand(CalcExpressionId, CalcOperandId)
--select @ActTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = 'ActFor_Officer' and ColCode = '')
--union all
--select @ActTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = 'ActFor_Enlisted' and ColCode = '')
--union all
select @ResTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = 'ResGuard_Officer' and ColCode = '')
union all
select @ResTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = 'ResGuard_Enlisted' and ColCode = '')
union all
select @DirHireTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = 'Civ_UsDirect' and ColCode = '')
union all
select @DirHireTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = 'Civ_ForNatDirect' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = 'Civ_UsDirect' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = 'Civ_ForNatDirect' and ColCode = '')
union all
select @CivTotal, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = 'Civ_ForNatInDir' and ColCode = '')
union all
select @PyCyChange, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = '' and ColCode = 'Py')
union all
select @PyCyChange, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = '' and ColCode = 'Cy')
union all
select @CyBy1Change, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = '' and ColCode = 'Cy')
union all
select @CyBy1Change, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA10_PersonnelData' and RowCode = '' and ColCode = 'By1')






--GetCalcs 'PBA10_PersonnelData' 


--select * from DEF_ELEMENT
--where element_value like '%pba-10%' --513

--select * from DEF_TABS where element_id_fk = 513 --670

--select * from DEF_TAB_CONTROLS where tab_id_fk = 670 -- 1037  PBA10_PER_GRID

-- select * from DATA_ROW where section_id_fk   = 223

--select * from DEF_SECTION where element_id_fk = 513 --223

