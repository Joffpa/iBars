
-- PBA12_ProgData1

--select * from Zo_pba12_ProgData1

--select * from AttributeDeNorm

--select * from AttributeCol

--select * from ParmActions

--UspGetAttribVal 'PBA12_ProgData1'

--UspDropAttribCol 'Class'

--UspGetCellVal null

--UspPopAttributeDeNormRecs 'PBA12_ProgData1'

--UspInsAttributeDeNormRecs 'PBA12_ProgData1', '', ''

--*******************ADD ATTRIB COLS*******************
--UspAddNewAttribCol 'DisplayText', 'NVARCHAR(500)'
--go
--UspAddNewAttribCol 'IsEditable', 'BIT'
--go
--UspAddNewAttribCol 'HasHeader', 'BIT'
--go
--UspAddNewAttribCol 'IsHidden', 'BIT'
--go
--UspAddNewAttribCol 'Width', 'NVARCHAR(100)'
--go
--UspAddNewAttribCol 'ColSpan', 'INTEGER'
--go
--UspAddNewAttribCol 'Level', 'INTEGER'
--go
--UspAddNewAttribCol 'CanSelect', 'BIT'
--go
--UspAddNewAttribCol 'CanCollapse', 'BIT'
--go
--UspAddNewAttribCol 'CanAdd', 'BIT'
--go
--UspAddNewAttribCol 'CanDelete', 'BIT'
--go
--UspAddNewAttribCol 'Indent', 'INTEGER'
--go
--UspAddNewAttribCol 'HoverBase', 'NVARCHAR(1000)'
--go
--UspAddNewAttribCol 'HoverAddition', 'NVARCHAR(300)'
--go
--UspAddNewAttribCol 'Alignment', 'NVARCHAR(50)'
--go
--UspAddNewAttribCol 'Type', 'NVARCHAR(100)'
--go
--UspAddNewAttribCol 'DisplayOrder', 'decimal(8,2)'
--go


--UspDropAttribCol 'IsBlank'
--UspDropAttribCol 'Directive'
--UspDropAttribCol 'Class'
--UspDropAttribCol 'ParentRowCode'



--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , '' ,'' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_CommunHdr' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_CommunSustBase' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_CommunLongHaul' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_CommunDeplMobl' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_CmdCntrlHdr' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_CmdCntrlNatnl' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_CmdCntrlOpera' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_CmdCntrlTact' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_C3RelHdr' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_C3RelNavig' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_C3RelMetrlgy' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_C3RelCombID' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_C3RelInfoAssur' ,'RowText' 
--exec UspInsAttributeDeNormRecs 'PBA12_ProgData1' , 'PBA12_ProgData_TOTAL' ,'RowText' 

GetCalcs 'PBA12_ProgData1'

-- SELECT * FROM AttributeCol

--GRID
exec UspUpdAttribVal 'PBA12_ProgData1', '', '',  'DisplayText=''PBA-12'',IsEditable=1', ''


--COLUMNS
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'RowText',  'IsEditable=0,HasHeader=1,IsHidden=0,Type=''text'',Width=''300px'',DisplayText=''PBA 12'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Py',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=null,DisplayText=''{PY}'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Pyprice',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=null,DisplayText=''{PY} Price'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Pyprog',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=null,DisplayText=''{PY} Prog'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cy',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=null,DisplayText=''{CY}'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cyprice',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=null,DisplayText=''{CY} Price'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cyprog',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=null,DisplayText=''{CY} Prog'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=null,DisplayText=''{BY1}'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1price',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=null,DisplayText=''{BY1} Price'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1prog',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=null,DisplayText=''{BY1} Prog'',ColSpan=1,Level=0,Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By2',  'IsEditable=1,HasHeader=1,IsHidden=0,Type=''numeric'',Width=null,DisplayText=''{BY2}'',ColSpan=1,Level=0,Alignment=''center''', ''


--Rows
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', '',  'Type=''header'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', '',  'Type=''data'',IsEditable=1,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', '',  'Type=''total'',IsEditable=0,IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''


--Cells
--PBA12_ProgData_CommunHdr Row
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'RowText',  'ColSpan=11,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Py',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Pyprice',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Pyprog',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Cy',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Cyprice',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Cyprog',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'By1',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'By1price',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'By1prog',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'By2',  'ColSpan=0,IsEditable=1,Indent=0', ''


--PBA12_ProgData_CommunSustBase Row
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Py',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Pyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Pyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Cy',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Cyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Cyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'By1',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'By1price',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'By1prog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'By2',  'IsEditable=1,Indent=0', ''


--PBA12_ProgData_CommunLongHaul Row
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Py',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Pyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Pyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Cy',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Cyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Cyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'By1',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'By1price',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'By1prog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'By2',  'IsEditable=1,Indent=0', ''


--PBA12_ProgData_CommunDeplMobl
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Py',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Pyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Pyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Cy',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Cyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Cyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'By1',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'By1price',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'By1prog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'By2',  'IsEditable=1,Indent=0', ''


--PBA12_ProgData_CmdCntrlHdr
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'RowText',  'ColSpan=11,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Py',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Pyprice',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Pyprog',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Cy',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Cyprice',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Cyprog',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'By1',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'By1price',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'By1prog',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'By2',  'ColSpan=0,IsEditable=1,Indent=0', ''


--PBA12_ProgData_CmdCntrlNatnl
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Py',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Pyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Pyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Cy',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Cyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Cyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'By1',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'By1price',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'By1prog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'By2',  'IsEditable=1,Indent=0', ''


--PBA12_ProgData_CmdCntrlOpera
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Py',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Pyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Pyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Cy',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Cyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Cyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'By1',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'By1price',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'By1prog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'By2',  'IsEditable=1,Indent=0', ''


--PBA12_ProgData_CmdCntrlTact
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Py',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Pyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Pyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Cy',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Cyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Cyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'By1',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'By1price',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'By1prog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'By2',  'IsEditable=1,Indent=0', ''


--PBA12_ProgData_C3RelHdr
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'RowText',  'ColSpan=11,IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Py',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Pyprice',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Pyprog',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Cy',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Cyprice',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Cyprog',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'By1',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'By1price',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'By1prog',  'ColSpan=0,IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'By2',  'ColSpan=0,IsEditable=1,Indent=0', ''


--PBA12_ProgData_C3RelNavig
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Py',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Pyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Pyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Cy',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Cyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Cyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'By1',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'By1price',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'By1prog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'By2',  'IsEditable=1,Indent=0', ''


--PBA12_ProgData_C3RelMetrlgy
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Py',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Pyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Pyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Cy',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Cyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Cyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'By1',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'By1price',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'By1prog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'By2',  'IsEditable=1,Indent=0', ''


--PBA12_ProgData_C3RelCombID
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Py',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Pyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Pyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Cy',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Cyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Cyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'By1',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'By1price',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'By1prog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'By2',  'IsEditable=1,Indent=0', ''


--PBA12_ProgData_C3RelInfoAssur
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Py',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Pyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Pyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Cy',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Cyprice',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Cyprog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'By1',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'By1price',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'By1prog',  'IsEditable=1,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'By2',  'IsEditable=1,Indent=0', ''


--PBA12_ProgData_TOTAL
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'RowText',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Py',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Pyprice',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Pyprog',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Cy',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Cyprice',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Cyprog',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'By1',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'By1price',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'By1prog',  'IsEditable=0,Indent=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'By2',  'IsEditable=0,Indent=0', ''




--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'RowText',  'IsEditable=1,Indent=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Py',  'IsEditable=1,Indent=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Pyprice',  'IsEditable=1,Indent=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Pyprog',  'IsEditable=1,Indent=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cy',  'IsEditable=1,Indent=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cyprice',  'IsEditable=1,Indent=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cyprog',  'IsEditable=1,Indent=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1',  'IsEditable=1,Indent=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1price',  'IsEditable=1,Indent=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1prog',  'IsEditable=1,Indent=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By2',  'IsEditable=1,Indent=0', ''


select * from CalcExpression
select * from CalcOperand
select * from CalcExpressionOperand


delete from CalcExpressionOperand
delete from CalcOperand
delete from CalcExpression


DECLARE @totExprId int, @colExprId int, @grandTotExrId int, @sourceExprId int
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'PBA12_ProgData1','PBA12_ProgData_TOTAL','','{PBA12_ProgData1.PBA12_ProgData_CommunSustBase..} + {PBA12_ProgData1.PBA12_ProgData_CommunLongHaul..} + {PBA12_ProgData1.PBA12_ProgData_CommunDeplMobl..} + {PBA12_ProgData1.PBA12_ProgData_CmdCntrlNatnl..} + {PBA12_ProgData1.PBA12_ProgData_CmdCntrlOpera..} + {PBA12_ProgData1.PBA12_ProgData_CmdCntrlTact..} + {PBA12_ProgData1.PBA12_ProgData_C3RelNavig..} + {PBA12_ProgData1.PBA12_ProgData_C3RelMetrlgy..} + {PBA12_ProgData1.PBA12_ProgData_C3RelCombID..} + {PBA12_ProgData1.PBA12_ProgData_C3RelInfoAssur..}'
SET @totExprId = @@IDENTITY

insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'PBA12_ProgData1','','PyProg','{PBA12_ProgData1..Py.} + {PBA12_ProgData1..PyPrice.}'
SET @colExprId = @@IDENTITY


insert into CalcOperand (GridCode, RowCode, ColCode)
select 'PBA12_ProgData1','PBA12_ProgData_CommunSustBase',''
union all
select 'PBA12_ProgData1','PBA12_ProgData_CommunLongHaul',''
union all
select 'PBA12_ProgData1','PBA12_ProgData_CommunDeplMobl',''
union all
select 'PBA12_ProgData1','PBA12_ProgData_CmdCntrlNatnl',''
union all
select 'PBA12_ProgData1','PBA12_ProgData_CmdCntrlOpera',''
union all
select 'PBA12_ProgData1','PBA12_ProgData_CmdCntrlTact',''
union all
select 'PBA12_ProgData1','PBA12_ProgData_C3RelNavig',''
union all
select 'PBA12_ProgData1','PBA12_ProgData_C3RelMetrlgy',''
union all
select 'PBA12_ProgData1','PBA12_ProgData_C3RelCombID',''
union all
select 'PBA12_ProgData1','PBA12_ProgData_C3RelInfoAssur',''
union all
select 'PBA12_ProgData1','','Py'
union all
select 'PBA12_ProgData1','','PyPrice'


insert into CalcExpressionOperand(CalcExpressionId, CalcOperandId)
select @totExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = 'PBA12_ProgData_CommunSustBase' and ColCode = '')
union all
select @totExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = 'PBA12_ProgData_CommunLongHaul' and ColCode = '')
union all
select @totExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = 'PBA12_ProgData_CommunDeplMobl' and ColCode = '')
union all
select @totExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = 'PBA12_ProgData_CmdCntrlNatnl' and ColCode = '')
union all
select @totExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = 'PBA12_ProgData_CmdCntrlOpera' and ColCode = '')
union all
select @totExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = 'PBA12_ProgData_CmdCntrlTact' and ColCode = '')
union all
select @totExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = 'PBA12_ProgData_C3RelNavig' and ColCode = '')
union all
select @totExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = 'PBA12_ProgData_C3RelMetrlgy' and ColCode = '')
union all
select @totExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = 'PBA12_ProgData_C3RelCombID' and ColCode = '')
union all
select @totExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = 'PBA12_ProgData_C3RelInfoAssur' and ColCode = '')
union all
select @colExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = '' and ColCode = 'Py')
union all
select @colExprId, (Select top 1 CalcOperandId from CalcOperand where GridCode = 'PBA12_ProgData1' and RowCode = '' and ColCode = 'PyPrice')
