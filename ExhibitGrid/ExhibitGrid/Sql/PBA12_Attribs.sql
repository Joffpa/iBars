
-- PBA12_ProgData1

--select * from Zo_pba12_ProgData1

--select * from AttributeDeNorm

--select * from AttributeCol

--UspGetAttribVal 'PBA12_ProgData1'

--UspDropAttribCol 'Class'

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
--UspAddNewAttribCol 'Directive', 'NVARCHAR(100)'
--go
--UspAddNewAttribCol 'Width', 'NVARCHAR(100)'
--go
--UspAddNewAttribCol 'ColSpan', 'INTEGER'
--go
--UspAddNewAttribCol 'Level', 'INTEGER'
--go
--UspAddNewAttribCol 'Class', 'NVARCHAR(100)'
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
--UspAddNewAttribCol 'IsBlank', 'BIT'
--go
--UspAddNewAttribCol 'HoverBase', 'NVARCHAR(1000)'
--go
--UspAddNewAttribCol 'HoverAddition', 'NVARCHAR(300)'
--go
--UspAddNewAttribCol 'ParentRowCode', 'NVARCHAR(255)'
--go
--UspAddNewAttribCol 'Alignment', 'NVARCHAR(50)'
--go


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
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'RowText',  'IsEditable=0,HasHeader=1,IsHidden=0,Directive=''text'',Width=''300px'',DisplayText=''PBA 12'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Py',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{PY}'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Pyprice',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{PY} Price'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Pyprog',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{PY} Prog'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cy',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{CY}'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cyprice',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{CY} Price'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cyprog',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{CY} Prog'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{BY1}'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1price',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{BY1} Price'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1prog',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{BY1} Prog'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By2',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{BY2}'',ColSpan=1,Level=0,Class='''',Alignment=''center''', ''


--Rows
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', '',  'IsEditable=0,Class=''sub-header-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', '',  'IsEditable=1,Class=''data-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', '',  'IsEditable=1,Class=''data-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', '',  'IsEditable=1,Class=''data-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', '',  'IsEditable=0,Class=''sub-header-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', '',  'IsEditable=1,Class=''data-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', '',  'IsEditable=1,Class=''data-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', '',  'IsEditable=1,Class=''data-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', '',  'IsEditable=0,Class=''sub-header-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', '',  'IsEditable=1,Class=''data-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', '',  'IsEditable=1,Class=''data-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', '',  'IsEditable=1,Class=''data-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', '',  'IsEditable=1,Class=''data-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', '',  'IsEditable=0,Class=''total-row'',IsHidden=0,CanCollapse=0,CanSelect=0,CanAdd=0,CanDelete=0', ''


--Cells
--PBA12_ProgData_CommunHdr Row
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'RowText',  'Class='''',ColSpan=11,IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Py',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Pyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Pyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Cy',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Cyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'Cyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'By1',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'By1price',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'By1prog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'By2',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CommunSustBase Row
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CommunLongHaul Row
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CommunDeplMobl
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CmdCntrlHdr
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'RowText',  'Class='''',ColSpan=11,IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Py',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Pyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Pyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Cy',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Cyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'Cyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'By1',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'By1price',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'By1prog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'By2',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CmdCntrlNatnl
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CmdCntrlOpera
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CmdCntrlTact
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_C3RelHdr
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'RowText',  'Class='''',ColSpan=11,IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Py',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Pyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Pyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Cy',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Cyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'Cyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'By1',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'By1price',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'By1prog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'By2',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_C3RelNavig
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_C3RelMetrlgy
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_C3RelCombID
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_C3RelInfoAssur
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_TOTAL
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Py',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Pyprice',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Pyprog',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Cy',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Cyprice',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'Cyprog',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'By1',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'By1price',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'By1prog',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'By2',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''




--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'RowText',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


delete from CalcExpressionOperand
delete from CalcOperand
delete from CalcExpression

--select * from CalcExpression
--select * from CalcOperand
--select * from CalcExpressionOperand

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
