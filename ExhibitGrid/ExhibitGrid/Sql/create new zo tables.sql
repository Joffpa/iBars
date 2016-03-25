-- demo Create ZGrid Tables
EXEC CreateZgridTbls 'PBA12_ProgData1'

--select * from ColMap

-- demo add ZGrid Rows
DECLARE @Rows GridRows
INSERT INTO @Rows ( RowCode, RowText, RowOrd, RowType )
    VALUES (  N'PBA12_ProgData_CommunHdr'
                , N'Communications'
            , 1
            , N'HEADERROW'
           ),
		   (  N'PBA12_ProgData_CommunSustBase'
                , N'Sustaining Base Communications'
            , 2
            , N''
           ),
		   (  N'PBA12_ProgData_CommunLongHaul'
                , N'Long Haul Communications'
            , 3
            , N''
           ),
		   (  N'PBA12_ProgData_CommunDeplMobl'
                , N'Deployable and Mobile Communications'
            , 4
            , N''
           ),
		   (  N'PBA12_ProgData_CmdCntrlHdr'
                , N'Command and Control'
            , 5
            , N'HEADERROW'
           ),
		   (  N'PBA12_ProgData_CmdCntrlNatnl'
                , N'National'
            , 6
            , N''
           ),
		   (  N'PBA12_ProgData_CmdCntrlOpera'
                , N'Operational'
            , 7
            , N''
           ),
		   (  N'PBA12_ProgData_CmdCntrlTact'
                , N'Tactical'
            , 8
            , N''
           ),
		   (  N'PBA12_ProgData_C3RelHdr'
                , N'C3 Related'
            , 9
            , N'HEADERROW'
           ),
		   (  N'PBA12_ProgData_C3RelNavig'
                , N'Navigation'
            , 10
            , N''
           ),
		   (  N'PBA12_ProgData_C3RelMetrlgy'
                , N'Meteorology'
            , 11
            , N''
           ),
		   (  N'PBA12_ProgData_C3RelCombID'
                , N'Combat Identification'
            , 12
            , N''
           ),
		   (  N'PBA12_ProgData_C3RelInfoAssur'
                , N'Cybersecurity Activities'
            , 13
            , N''
           ),
		   (  N'PBA12_ProgData_TOTAL'
                , N'Total'
            , 14
            , N'HEADERROW'
           )

EXEC AddZgridRows 'PBA12_ProgData1', @Rows

-- Demo see the results
SELECT * FROM zt_PBA12_ProgData1 ORDER BY rowOrd
SELECT * FROM zs_PBA12_ProgData1 ORDER BY rowOrd
SELECT * FROM zo_PBA12_ProgData1 ORDER BY rowOrd


-- Demo add ZGrid Columns
DECLARE @Cols GridCols
INSERT INTO @Cols ( ColCode, ColOrd, NumOrTxt, DataType )
    VALUES (  N'RowText'
            , 1
                , N'T'
            , N'NVARCHAR(500)'
           ), 
		   (  N'PBA12_ProgData_Py'
            , 2
                , N'N'
            , N'Decimal(15,4)'
           ),
		   (  N'PBA12_ProgData_Pyprice'
            , 3
                , N'N'
            , N'Decimal(15,4)'
           ),
		   (  N'PBA12_ProgData_Pyprog'
            , 4
                , N'N'
            , N'Decimal(15,4)'
           ),
		   (  N'PBA12_ProgData_Cy'
            , 5
                , N'N'
            , N'Decimal(15,4)'
           ),
		   (  N'PBA12_ProgData_Cyprice'
            , 6
                , N'N'
            , N'Decimal(15,4)'
           ),
		   (  N'PBA12_ProgData_Cyprog'
            , 7
                , N'N'
            , N'Decimal(15,4)'
           ),
		   (  N'PBA12_ProgData_By1'
            , 8
                , N'N'
            , N'Decimal(15,4)'
           ),
		   (  N'PBA12_ProgData_By1price'
            , 9
                , N'N'
            , N'Decimal(15,4)'
           ),
		   (  N'PBA12_ProgData_By1prog'
            , 10
                , N'N'
            , N'Decimal(15,4)'
           ),
		   (  N'PBA12_ProgData_By2'
            , 11
                , N'N'
            , N'Decimal(15,4)'
           )

EXEC AddZgridCols 'PBA12_ProgData1', @Cols

-- Demo see the results
SELECT * FROM zt_xyz ORDER BY rowOrd
SELECT * FROM zs_xyz ORDER BY rowOrd
SELECT * FROM zo_xyz ORDER BY rowOrd

--RemZgridRowsCols ''