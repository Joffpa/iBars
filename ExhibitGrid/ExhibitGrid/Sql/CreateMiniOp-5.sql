
DeleteGrid 'MiniOp5'

EXEC CreateZgridTbls 'MiniOp5'

--select * from Zo_MiniOp5

update Zo_MiniOp5
	set  CyBase = '12354', ForeignCurr = '123', PriceGrowth = '345', Stub = '2044' , Mdep = 'FPDP' , Ape = '122011', Cmd ='5D0' , Ftes = '0', Op0101 = '0',Op0103 = '0',Op0104 = '0',Op0105 = '0',Op0106 = '0',Op0107 = '0',Op0110 = '0',Op0111 = '0',Op0308 = '0'
	where RowCode = 'ProgGrowth_TactEx_c1'
	and OutType = 'UI'
update Zo_MiniOp5
	set  CyBase = '38686', ForeignCurr = '123', PriceGrowth = '345', Stub = '10430' , Mdep = 'FL8D' , Ape = '122011', Cmd ='740' , Ftes = '0', Op0101 = '0',Op0103 = '0',Op0104 = '0',Op0105 = '0',Op0106 = '0',Op0107 = '0',Op0110 = '0',Op0111 = '0',Op0308 = '0'
	where RowCode = 'ProgGrowth_CombSup_c1'
	and OutType = 'UI'
update Zo_MiniOp5
	set  CyBase = '5000', ForeignCurr = '123', PriceGrowth = '345', Stub = '-10000' , Mdep = 'HSMR' , Ape = '122018', Cmd ='All CMDs except 570' , Ftes = '-2', Op0101 = '0',Op0103 = '0',Op0104 = '0',Op0105 = '0',Op0106 = '0',Op0107 = '0',Op0110 = '0',Op0111 = '0',Op0308 = '0'
	where RowCode = 'TransProgDec_CivWork_c1'
	and OutType = 'UI'
update Zo_MiniOp5
	set  CyBase = '5000', ForeignCurr = '123', PriceGrowth = '345', Stub = '-10000' , Mdep = 'VTRD' , Ape = '122018', Cmd ='570' , Ftes = '-26', Op0101 = '0',Op0103 = '0',Op0104 = '0',Op0105 = '0',Op0106 = '0',Op0107 = '0',Op0110 = '0',Op0111 = '0',Op0308 = '0'
	where RowCode = 'TransProgDec_CivWork_c2'
	and OutType = 'UI'
update Zo_MiniOp5
	set  CyBase = '45345', ForeignCurr = '123', PriceGrowth = '345', Stub = '-3434' , Mdep = 'WSCC' , Ape = '122152', Cmd ='890' , Ftes = '-2', Op0101 = '0',Op0103 = '0',Op0104 = '0',Op0105 = '0',Op0106 = '0',Op0107 = '0',Op0110 = '0',Op0111 = '0',Op0308 = '0'
	where RowCode = 'TransProgDec_CivWork_c3'
	and OutType = 'UI'
update Zo_MiniOp5
	set  CyBase = '19708', ForeignCurr = '123', PriceGrowth = '345', Stub = '-2511' , Mdep = 'WSCC' , Ape = '122152', Cmd ='740' , Ftes = '-2', Op0101 = '0',Op0103 = '0',Op0104 = '0',Op0105 = '0',Op0106 = '0',Op0107 = '0',Op0110 = '0',Op0111 = '0',Op0308 = '0'
	where RowCode = 'TransProgDec_ArSer_c1'
	and OutType = 'UI'



--update Zo_MiniOp5
--set  RowText = 'FY 2017 Program Decreases Title'  
--where RowCode = 'TransProgDec_Header'
--and OutType = 'UI'








select * from ColMap where GridCode ='MiniOp5'

----insert into ColMap (GridCode, ColCode, ColOrd, OutColType, StgColType, tableSpecific, CellType, col_code)
----select 'PBA10_PersonnelData', 'RowText', .5, N'NVARCHAR(255) Default('')', N'NVARCHAR(255) Default('')', '', 'IsGridTxt', 'row_text'

update ColMap set ColOrd = .5 where GridCode ='MiniOp5' and ColCode = 'RowText'

----delete from ColMap 
----where GridCode ='MiniOp5' and ColCode != 'RowText'

DECLARE @Cols GridCols;
INSERT INTO @Cols ( ColCode, ColOrd, DataType, NumOrTxt)
    VALUES 
    (  N'Narrative', 9.0, N'NVARCHAR(255)', N'T'),
    (  N'CyBase', 10.0, N'DECIMAL(8,2)', N'N'),
    (  N'ForeignCurr', 11.0, N'DECIMAL(8,2)', N'N'),
    (  N'PriceGrowth', 12.0, N'DECIMAL(8,2)', N'N'),
    (  N'Stub', 13.0, N'DECIMAL(8,2)', N'N'),
    (  N'By1Prog', 14.0, N'DECIMAL(8,2)', N'N'),
    (  N'Mdep', 15.0, N'NVARCHAR(255)', N'T'),
    (  N'Ape', 16.0, N'NVARCHAR(255)', N'T'),
    (  N'Cmd', 17.0, N'NVARCHAR(255)', N'T'),
    (  N'Ftes', 18.0, N'NVARCHAR(255)', N'T'),
    (  N'CMEs', 19.0, N'DECIMAL(8,2)', N'N'),
    (  N'MILs', 20.0, N'DECIMAL(8,2)', N'N'),
    (  N'Op32Total', 21.0, N'DECIMAL(8,2)', N'N'),
    (  N'Op0101', 22.0, N'DECIMAL(8,2)', N'N'),
    (  N'Op0103', 23.0, N'DECIMAL(8,2)', N'N'),
    (  N'Op0104', 24.0, N'DECIMAL(8,2)', N'N'),
    (  N'Op0105', 25.0, N'DECIMAL(8,2)', N'N'),
    (  N'Op0106', 26.0, N'DECIMAL(8,2)', N'N'),
    (  N'Op0107', 27.0, N'DECIMAL(8,2)', N'N'),
    (  N'Op0110', 28.0, N'DECIMAL(8,2)', N'N'),
    (  N'Op0111', 29.0, N'DECIMAL(8,2)', N'N'),
    (  N'Op0308', 30.0, N'DECIMAL(8,2)', N'N')

	
EXEC AddZgridCols 'MiniOp5',@Cols



DECLARE @Rows GridRows;
INSERT INTO @Rows ( RowCode, RowOrd, RowText, RowType)
    VALUES (  N'TransIn_Header', 1.0, N'FY 2017 Transfer-in Title ', N'HEADERROW'),
	(  N'TransIn_Total', 3.0, N'Total', null),
	(  N'TransIn_Blank', 4.0, N'', null),
	(  N'TransOut_Header', 5.0, N'FY 2017 Transfer-out Title',  N'HEADERROW'),
	(  N'TransOut_Total', 7.0, N'Total',  null),
	(  N'TransOut_Blank', 8.0, N'', null),
	(  N'ProgGrowth_Header', 9.0, N'FY 2017 Program Growth Title ',  N'HEADERROW'),
	(  N'ProgGrowth_TactEx', 10.0, N'Tactical Exploitation of National Capabilities (TENCAP) Military Exploitation of Reconnaissance and Intelligence Technology (MERIT) Projects ',  null),
	(  N'ProgGrowth_TactEx_c1', 11.0, N'',  null),
	(  N'ProgGrowth_CombSup', 12.0, N'Combat Support Medical ',  null),
	(  N'ProgGrowth_CombSup_c1', 12.0, N'',  null),
	(  N'ProgGrowth_Total', 13.0, N'Total ',  null),
	(  N'ProgGrowth_Blank', 14.0, N'', null),
	(  N'TransProgDec_Header', 15.0, N'FY 2017 Transfer-out Title',  N'HEADERROW'),
	(  N'TransProgDec_CivWork', 16.0, N'Civilian Workforce Reduction ', null),
	(  N'TransProgDec_CivWork_c1', 17.0, N'', null),
	(  N'TransProgDec_CivWork_c2', 18.0, N'', null),
	(  N'TransProgDec_CivWork_c3', 19.0, N'', null),
	(  N'TransProgDec_ArSer', 20.0, N'Army Service Component Command Tactical Units', null),
	(  N'TransProgDec_ArSer_c1', 21.0, N'', null),
	(  N'TransProgDec_Total', 21.0, N'Total', null)

Exec AddZgridRows 'MiniOp5', @Rows


--UspPopAttributeDeNormRecs 'MiniOp5', 0

--UspInsAttributeDeNormRecsVirtualCol 'MiniOp5', 'Op5Header,Op32HEader'

--UspGetAttribVal 'MiniOp5'

--select * from AttributeDeNorm
--where GridCode = 'MiniOp5'

--Column attribs
exec UspUpdAttribVal 'MiniOp5', '', 'Op5Header',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''text'',Width='''',DisplayText=''OP 5'',ColSpan=13,Level=1,Alignment=''center'',DisplayOrder=1', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op32HEader',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''text'',Width='''',DisplayText=''OP 32'',ColSpan=10,Level=1,Alignment=''center'',DisplayOrder=2', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Narrative',  'IsEditable=1,HasHeader=0,IsHidden=0,Type=''narrative'',Width='''',DisplayText='''',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'RowText',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''text'',Width=''300px'',DisplayText='''',ColSpan=2,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'CyBase',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''FY 2017 Baseline '',ColSpan=1,Level=0,Alignment=''center'',MaxChars=10,DecimalPlaces=2', ''
exec UspUpdAttribVal 'MiniOp5', '', 'ForeignCurr',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''Foreign Currency '',ColSpan=1,Level=0,Alignment=''center'',MaxChars=10,DecimalPlaces=2', ''
exec UspUpdAttribVal 'MiniOp5', '', 'PriceGrowth',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''Price Growth'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=10,DecimalPlaces=2', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Stub',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''Stub Amount'',ColSpan=1,Level=0,Alignment=''center'',MaxChars=10,DecimalPlaces=2', ''
exec UspUpdAttribVal 'MiniOp5', '', 'By1Prog',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''FY 2018 Program '',ColSpan=1,Level=0,Alignment=''center'',MaxChars=10,DecimalPlaces=2', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Mdep',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''text'',Width=''60px'',DisplayText=''MDEP'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Ape',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''text'',Width=''60px'',DisplayText=''APE'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Cmd',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''text'',Width=''90px'',DisplayText=''CMD'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Ftes',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''60px'',DisplayText=''FTEs'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'CMEs',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''60px'',DisplayText=''CMEs'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'MILs',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''60px'',DisplayText=''MILs'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op32Total',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''Op32Total'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op0101',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''0101'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op0103',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''0103'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op0104',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''0104'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op0105',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''0105'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op0106',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''0106'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op0107',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''0107'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op0110',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''0110'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op0111',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''0111'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'MiniOp5', '', 'Op0308',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=''80px'',DisplayText=''0308'',ColSpan=1,Level=0,Alignment=''center''', ''


--row attribs 
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', '',  'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Blank', '',  'Type=''blank'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Header', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', '',  'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Blank', '',  'Type=''blank'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Header', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', '',  'Type=''subtotal'',IsEditable=1,IsHidden=0,CanCollapse=1,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', '',  'Type=''data'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', '',  'Type=''subtotal'',IsEditable=1,IsHidden=0,CanCollapse=1,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', '',  'Type=''data'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', '',  'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Blank', '',  'Type=''blank'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Header', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', '',  'Type=''subtotal'',IsEditable=1,IsHidden=0,CanCollapse=1,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', '',  'Type=''data'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', '',  'Type=''data'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', '',  'Type=''data'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', '',  'Type=''subtotal'',IsEditable=1,IsHidden=0,CanCollapse=1,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', '',  'Type=''data'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', '',  'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''



--Cells
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''left''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'CyBase',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Stub',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Op32Total',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Op0101',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Op0103',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Op0104',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Op0105',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Op0106',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Op0107',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Op0110',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Op0111',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Header', 'Op0308',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''


exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'CyBase',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'ForeignCurr',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'PriceGrowth',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Stub',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'CMEs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'MILs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Op32Total',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Op0101',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Op0103',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Op0104',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Op0105',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Op0106',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Op0107',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Op0110',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Op0111',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransIn_Total', 'Op0308',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''


exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'CyBase',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'ForeignCurr',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'PriceGrowth',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Stub',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'CMEs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'MILs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Op32Total',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Op0101',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Op0103',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Op0104',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Op0105',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Op0106',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Op0107',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Op0110',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Op0111',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransOut_Total', 'Op0308',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''



exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Narrative',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'CyBase',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'ForeignCurr',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'PriceGrowth',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Stub',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'By1Prog',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Ftes',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'CMEs',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'MILs',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Op32Total',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Op0101',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Op0103',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Op0104',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Op0105',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Op0106',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Op0107',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Op0110',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Op0111',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx', 'Op0308',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''


exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'CyBase',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'ForeignCurr',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'PriceGrowth',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Stub',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'CMEs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'MILs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Op32Total',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Op0101',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Op0103',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Op0104',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Op0105',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Op0106',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Op0107',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Op0110',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Op0111',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_TactEx_c1', 'Op0308',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''



exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'CyBase',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'ForeignCurr',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'PriceGrowth',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Stub',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'By1Prog',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Ftes',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'CMEs',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'MILs',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Op32Total',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Op0101',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Op0103',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Op0104',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Op0105',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Op0106',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Op0107',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Op0110',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Op0111',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup', 'Op0308',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''


exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'CyBase',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'ForeignCurr',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'PriceGrowth',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Stub',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'CMEs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'MILs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Op32Total',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Op0101',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Op0103',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Op0104',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Op0105',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Op0106',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Op0107',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Op0110',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Op0111',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_CombSup_c1', 'Op0308',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''



exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'CyBase',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'ForeignCurr',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'PriceGrowth',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Stub',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'CMEs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'MILs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Op32Total',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Op0101',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Op0103',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Op0104',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Op0105',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Op0106',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Op0107',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Op0110',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Op0111',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'ProgGrowth_Total', 'Op0308',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''


exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Narrative',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'CyBase',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'ForeignCurr',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'PriceGrowth',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Stub',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'By1Prog',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Ftes',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'CMEs',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'MILs',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Op32Total',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Op0101',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Op0103',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Op0104',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Op0105',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Op0106',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Op0107',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Op0110',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Op0111',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork', 'Op0308',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''




exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'CyBase',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'ForeignCurr',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'PriceGrowth',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Stub',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'CMEs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'MILs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Op32Total',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Op0101',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Op0103',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Op0104',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Op0105',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Op0106',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Op0107',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Op0110',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Op0111',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c1', 'Op0308',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''

exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'CyBase',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'ForeignCurr',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'PriceGrowth',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Stub',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'CMEs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'MILs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Op32Total',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Op0101',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Op0103',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Op0104',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Op0105',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Op0106',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Op0107',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Op0110',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Op0111',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c2', 'Op0308',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''


exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'CyBase',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'ForeignCurr',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'PriceGrowth',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Stub',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'CMEs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'MILs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Op32Total',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Op0101',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Op0103',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Op0104',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Op0105',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Op0106',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Op0107',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Op0110',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Op0111',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_CivWork_c3', 'Op0308',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''




exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Narrative',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'CyBase',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'ForeignCurr',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'PriceGrowth',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Stub',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'By1Prog',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Ftes',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'CMEs',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'MILs',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Op32Total',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Op0101',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Op0103',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Op0104',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Op0105',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Op0106',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Op0107',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Op0110',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Op0111',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer', 'Op0308',  'ColSpan=1,IsEditable=1,Indent=0,Alignment=''right''', ''



exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'CyBase',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'ForeignCurr',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'PriceGrowth',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Stub',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'CMEs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'MILs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Op32Total',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Op0101',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Op0103',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Op0104',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Op0105',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Op0106',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Op0107',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Op0110',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Op0111',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_ArSer_c1', 'Op0308',  'Type=''blank'',ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1', ''



exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Narrative',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right'',OverrideColSettings=1,Type=''blank''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'RowText',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'CyBase',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'ForeignCurr',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'PriceGrowth',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Stub',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'By1Prog',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Mdep',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Ape',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Cmd',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Ftes',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'CMEs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'MILs',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Op32Total',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Op0101',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Op0103',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Op0104',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Op0105',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Op0106',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Op0107',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Op0110',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Op0111',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''
exec UspUpdAttribVal 'MiniOp5', 'TransProgDec_Total', 'Op0308',  'ColSpan=1,IsEditable=0,Indent=0,Alignment=''right''', ''





--select * from RowRelationship

--UspGetRowRelationship 'MiniOp5', null

delete from RowRelationship where ParGridCode = 'MiniOp5'

insert into RowRelationship (ParGridCode,ParRowCode, ChGridCode, ChRowCode, Context)
select 'MiniOp5','ProgGrowth_TactEx','MiniOp5','ProgGrowth_TactEx_c1','total'
union all
select 'MiniOp5','ProgGrowth_TactEx','MiniOp5','ProgGrowth_TactEx_c1','collapse'
union all
select 'MiniOp5','ProgGrowth_CombSup','MiniOp5','ProgGrowth_CombSup_c1','total'
union all
select 'MiniOp5','ProgGrowth_CombSup','MiniOp5','ProgGrowth_CombSup_c1','collapse'
union all
select 'MiniOp5','TransProgDec_CivWork','MiniOp5','TransProgDec_CivWork_c1','total'
union all
select 'MiniOp5','TransProgDec_CivWork','MiniOp5','TransProgDec_CivWork_c1','collapse'
union all
select 'MiniOp5','TransProgDec_CivWork','MiniOp5','TransProgDec_CivWork_c2','total'
union all
select 'MiniOp5','TransProgDec_CivWork','MiniOp5','TransProgDec_CivWork_c2','collapse'
union all
select 'MiniOp5','TransProgDec_CivWork','MiniOp5','TransProgDec_CivWork_c3','total'
union all
select 'MiniOp5','TransProgDec_CivWork','MiniOp5','TransProgDec_CivWork_c3','collapse'
union all
select 'MiniOp5','TransProgDec_ArSer','MiniOp5','TransProgDec_ArSer_c1','total'
union all
select 'MiniOp5','TransProgDec_ArSer','MiniOp5','TransProgDec_ArSer_c1','collapse'



GetCalcs 'MiniOp5'




delete from CalcExpressionOperand 
where CalcExpressionId in(
	select CalcExpressionId from CalcExpression 
	where TargetGridCode = 'MiniOp5'	
)
delete from CalcOperand where GridCode = 'MiniOp5'	
delete from CalcExpression where TargetGridCode = 'MiniOp5'	



DECLARE  @ProgRowTot int, @By1Col int, @Op32Col int, @ProgDecRowTot int

insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'MiniOp5','ProgGrowth_Total','','{MiniOp5.ProgGrowth_CombSup..} + {MiniOp5.ProgGrowth_TactEx..}', 'CellValue'
SET @ProgRowTot = @@IDENTITY

insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'MiniOp5','','By1Prog','{MiniOp5..CyBase.} + {MiniOp5..Stub.} + {MiniOp5..ForeignCurr.} + {MiniOp5..PriceGrowth.}', 'CellValue'
SET @By1Col = @@IDENTITY

insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'MiniOp5','','Op32Total','{MiniOp5..Op0101.} + {MiniOp5..Op0103.} + {MiniOp5..Op0104.} + {MiniOp5..Op0105.} + {MiniOp5..Op0106.} + {MiniOp5..Op0107.} + {MiniOp5..Op0110.} + {MiniOp5..Op0111.} + {MiniOp5..Op0308.} ', 'CellValue'
SET @Op32Col = @@IDENTITY

insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression, UpdateContext)
select 'MiniOp5','TransProgDec_Total','','{MiniOp5.TransProgDec_ArSer..} + {MiniOp5.TransProgDec_CivWork..}', 'CellValue'
SET @ProgDecRowTot = @@IDENTITY





insert into CalcOperand (GridCode, RowCode, ColCode)
--select 'MiniOp5','ProgGrowth_TactEx_c1',''
--union all
--select 'MiniOp5','ProgGrowth_CombSup_c1',''
--union all
select 'MiniOp5','ProgGrowth_CombSup',''
union all
select 'MiniOp5','ProgGrowth_TactEx',''
union all
select 'MiniOp5','','CyBase'
union all
select 'MiniOp5','','Stub'
union all
select 'MiniOp5','','ForeignCurr'
union all
select 'MiniOp5','','PriceGrowth'
union all
select 'MiniOp5','','Op0101'
union all
select 'MiniOp5','','Op0103'
union all
select 'MiniOp5','','Op0104'
union all
select 'MiniOp5','','Op0105'
union all
select 'MiniOp5','','Op0106'
union all
select 'MiniOp5','','Op0107'
union all
select 'MiniOp5','','Op0110'
union all
select 'MiniOp5','','Op0111'
union all
select 'MiniOp5','','Op0308'
union all
--select 'MiniOp5','TransProgDec_CivWork_c1',''
--union all
--select 'MiniOp5','TransProgDec_CivWork_c2',''
--union all
--select 'MiniOp5','TransProgDec_CivWork_c3',''
--union all
--select 'MiniOp5','TransProgDec_ArSer_c1',''
--union all
select 'MiniOp5','TransProgDec_ArSer',''
union all
select 'MiniOp5','TransProgDec_CivWork',''




insert into CalcExpressionOperand(CalcExpressionId, CalcOperandId)
--select @TenCapRow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = 'ProgGrowth_TactEx_c1' and ColCode = '')
--union all
--select @ComRow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = 'ProgGrowth_CombSup_c1' and ColCode = '')
--union all
select @ProgRowTot, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = 'ProgGrowth_CombSup' and ColCode = '')
union all
select @ProgRowTot, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = 'ProgGrowth_TactEx' and ColCode = '')
union all
select @By1Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'CyBase')
union all
select @By1Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'Stub')
union all
select @By1Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'ForeignCurr')
union all
select @By1Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'PriceGrowth')
union all
select @Op32Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'Op0101')
union all
select @Op32Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'Op0103')
union all
select @Op32Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'Op0104')
union all
select @Op32Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'Op0105')
union all
select @Op32Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'Op0106')
union all
select @Op32Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'Op0107')
union all
select @Op32Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'Op0110')
union all
select @Op32Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'Op0111')
union all
select @Op32Col, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = '' and ColCode = 'Op0308')
union all
--select @CivRow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = 'TransProgDec_CivWork_c1' and ColCode = '')
--union all
--select @CivRow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = 'TransProgDec_CivWork_c2' and ColCode = '')
--union all
--select @CivRow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = 'TransProgDec_CivWork_c3' and ColCode = '')
--union all
--select @ArmRow, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = 'TransProgDec_ArSer_c1' and ColCode = '')
--union all
select @ProgDecRowTot, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = 'TransProgDec_CivWork' and ColCode = '')
union all
select @ProgDecRowTot, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'MiniOp5' and RowCode = 'TransProgDec_ArSer' and ColCode = '')


