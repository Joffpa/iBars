
--*******************ADD ATTRIB COLS*******************
UspAddNewAttribCol 'DisplayText', 'NVARCHAR(500)'
go
UspAddNewAttribCol 'IsEditable', 'BIT'
go
UspAddNewAttribCol 'HasHeader', 'BIT'
go
UspAddNewAttribCol 'IsHidden', 'BIT'
go
UspAddNewAttribCol 'Width', 'NVARCHAR(100)'
go
UspAddNewAttribCol 'ColSpan', 'INTEGER'
go
UspAddNewAttribCol 'Level', 'INTEGER'
go
UspAddNewAttribCol 'CanSelect', 'BIT'
go
UspAddNewAttribCol 'CanCollapse', 'BIT'
go
UspAddNewAttribCol 'CanAdd', 'BIT'
go
UspAddNewAttribCol 'CanDelete', 'BIT'
go
UspAddNewAttribCol 'Indent', 'INTEGER'
go
UspAddNewAttribCol 'HoverBase', 'NVARCHAR(1000)'
go
UspAddNewAttribCol 'HoverAddition', 'NVARCHAR(300)'
go
UspAddNewAttribCol 'Alignment', 'NVARCHAR(50)'
go
UspAddNewAttribCol 'Type', 'NVARCHAR(100)'
go
UspAddNewAttribCol 'DisplayOrder', 'decimal(8,2)'
go
UspAddNewAttribCol 'MaxChars', 'INTEGER'
go
UspAddNewAttribCol 'DecimalPlaces', 'INTEGER'
go
UspAddNewAttribCol 'OverrideColSettings', 'BIT'
go


--UspDropAttribCol 'OverrideType'