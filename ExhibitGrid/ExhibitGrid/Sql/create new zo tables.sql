-- demo Create ZGrid Tables
EXEC CreateZgridTbls 'xyz'


-- demo add ZGrid Rows
DECLARE @Rows GridRows
INSERT INTO @Rows ( RowCode, RowText, RowOrd, RowType )
    VALUES (  N'MyTextRow'
                , N'Whatever Text I might want to type'
            , 3
            , N''
           )
           ,   (  N'MyTextRow2'
                , N'Brand New Row'
            , 2
            , N''
           )
           ,  (  N'Head1'
                , N''
            , 1
            , N'HEADERROW'
           )
           ,  (  N'Value1'
                , N''
            , 3
            , N''
           )
           ,  (  N'Head2'
                , N''
            , 4
            , N'HeaderRow'
           )
           ,  (  N'Total'
                , N''
            , 5
            , N''
           )

EXEC AddZgridRows 'xyz', @Rows

-- Demo see the results
SELECT * FROM zt_xyz ORDER BY rowOrd
SELECT * FROM zs_xyz ORDER BY rowOrd
SELECT * FROM zo_xyz ORDER BY rowOrd


-- Demo add ZGrid Columns
DECLARE @Cols GridCols
INSERT INTO @Cols ( ColCode, ColOrd, NumOrTxt, DataType )
    VALUES (  N'PE'
            , 1
                , N'T'
            , N'NVARCHAR(200)'
           )
           ,  (  N'PY'
            , 2
                , N'N'
            , N'Decimal(15,4)'
           )
           ,  (  N'PyInflation'
            , 3
                , N'N'
            , N'Decimal(8,4)'
           )
           ,  (  N'Cy'
            , 4
                , N'N'
            , N'Decimal(15,2)'
           )
           ,  (  N'CyInflation'
            , 5
                , N'N'
            , N'Decimal(10,2)'
           )
           ,  (  N'By1'
            , 6
                , N'N'
            , N'Decimal(10,2)'
           )

EXEC AddZgridCols 'xyz', @Cols

-- Demo see the results
SELECT * FROM zt_xyz ORDER BY rowOrd
SELECT * FROM zs_xyz ORDER BY rowOrd
SELECT * FROM zo_xyz ORDER BY rowOrd

