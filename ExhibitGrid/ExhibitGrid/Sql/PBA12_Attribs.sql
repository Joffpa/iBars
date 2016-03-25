
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


-- SELECT * FROM AttributeCol

--GRID
exec UspUpdAttribVal 'PBA12_ProgData1', '', '',  'DisplayText=''PBA-12'',IsEditable=1', ''


--COLUMNS
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'RowText',  'IsEditable=0,HasHeader=0,IsHidden=0,Directive=''text'',Width=''300px'',DisplayText=null,ColSpan=1,Level=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Py',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{PY}'',ColSpan=1,Level=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Pyprice',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{PY} Price'',ColSpan=1,Level=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Pyprog',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{PY} Prog'',ColSpan=1,Level=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Cy',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{CY}'',ColSpan=1,Level=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Cyprice',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{CY} Price'',ColSpan=1,Level=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Cyprog',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{CY} Prog'',ColSpan=1,Level=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_By1',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{BY1}'',ColSpan=1,Level=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_By1price',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{BY1} Price'',ColSpan=1,Level=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_By1prog',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{BY1} Prog'',ColSpan=1,Level=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_By2',  'IsEditable=1,HasHeader=1,IsHidden=0,Directive=''numeric'',Width=null,DisplayText=''{BY2}'',ColSpan=1,Level=0', ''


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
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'PBA12_ProgData_Py',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'PBA12_ProgData_Pyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'PBA12_ProgData_Pyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'PBA12_ProgData_Cy',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'PBA12_ProgData_Cyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'PBA12_ProgData_Cyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'PBA12_ProgData_By1',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'PBA12_ProgData_By1price',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'PBA12_ProgData_By1prog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunHdr', 'PBA12_ProgData_By2',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CommunSustBase Row
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunSustBase', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CommunLongHaul Row
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunLongHaul', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CommunDeplMobl
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CommunDeplMobl', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CmdCntrlHdr
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'RowText',  'Class='''',ColSpan=11,IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'PBA12_ProgData_Py',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'PBA12_ProgData_Pyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'PBA12_ProgData_Pyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'PBA12_ProgData_Cy',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'PBA12_ProgData_Cyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'PBA12_ProgData_Cyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'PBA12_ProgData_By1',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'PBA12_ProgData_By1price',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'PBA12_ProgData_By1prog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlHdr', 'PBA12_ProgData_By2',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CmdCntrlNatnl
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlNatnl', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CmdCntrlOpera
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlOpera', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_CmdCntrlTact
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_CmdCntrlTact', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_C3RelHdr
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'RowText',  'Class='''',ColSpan=11,IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'PBA12_ProgData_Py',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'PBA12_ProgData_Pyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'PBA12_ProgData_Pyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'PBA12_ProgData_Cy',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'PBA12_ProgData_Cyprice',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'PBA12_ProgData_Cyprog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'PBA12_ProgData_By1',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'PBA12_ProgData_By1price',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'PBA12_ProgData_By1prog',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelHdr', 'PBA12_ProgData_By2',  'Class='''',ColSpan=0,IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_C3RelNavig
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelNavig', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_C3RelMetrlgy
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelMetrlgy', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_C3RelCombID
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelCombID', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_C3RelInfoAssur
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_C3RelInfoAssur', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


--PBA12_ProgData_TOTAL
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'RowText',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'PBA12_ProgData_Py',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'PBA12_ProgData_By1',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''
exec UspUpdAttribVal 'PBA12_ProgData1', 'PBA12_ProgData_TOTAL', 'PBA12_ProgData_By2',  'Class='''',IsEditable=0,Indent=0,IsBlank=0', ''




--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'RowText',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Py',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Pyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Pyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Cy',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Cyprice',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_Cyprog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_By1',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_By1price',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_By1prog',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''
--exec UspUpdAttribVal 'PBA12_ProgData1', '', 'PBA12_ProgData_By2',  'Class='''',IsEditable=1,Indent=0,IsBlank=0', ''


DECLARE @totExprId int
insert into CalcExpression (TargetGridCode, TargetRowCode, TargetColCode, Expression)
select 'PBA12_ProgData1','PBA12_ProgData_TOTAL','','{PBA12_ProgData1.PBA12_ProgData_CommunSustBase..} + {PBA12_ProgData1.PBA12_ProgData_CommunLongHaul..} + {PBA12_ProgData1.PBA12_ProgData_CommunDeplMobl..} + {PBA12_ProgData1.PBA12_ProgData_CmdCntrlNatnl..} + {PBA12_ProgData1.PBA12_ProgData_CmdCntrlOpera..} + {PBA12_ProgData1.PBA12_ProgData_CmdCntrlTact..} + {PBA12_ProgData1.PBA12_ProgData_C3RelNavig..} + {PBA12_ProgData1.PBA12_ProgData_C3RelMetrlgy..} + {PBA12_ProgData1.PBA12_ProgData_C3RelCombID..} + {PBA12_ProgData1.PBA12_ProgData_C3RelInfoAssur..}'
SET @totExprId = @@IDENTITY



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
