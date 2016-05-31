using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.Globals
{
    public static class Literals
    {
        public static class UniversalColCode
        {
            public const string RowText = "RowText";
        }

        public static class RowRelationshipContext
        {
            public static readonly string CollapseAndSumChildrenToParent = "CollapseAndSumChildrenToParent";
            public static readonly string AddRowTemplate = "AddRowTemplate";
        }

        public static class CalcUpdateContext
        {
            public static readonly string CellValue = "cellvalue";
            public static readonly string DeltaCheck = "deltacheck";
        }

        public static class Attribute
        {
            public static class RowType
            {
                public const string Header = "header";
                public const string Data = "data";
                public const string Total = "total";
                public const string Subtotal = "subtotal";
                public const string Blank = "blank";
            }

            public static class OutType
            {
                public static readonly string Ui = "UI";
                public static readonly string Model = "Model";
            }

            //Columns and cells have the same type
            public static class ColCellType
            {
                public static readonly string Text = "text";
                public static readonly string Numeric = "numeric";
                public static readonly string Percent = "percent";
                public static readonly string Dropdown = "dropdown";
                public static readonly string Postit = "postit";
                public static readonly string Narrative = "narrative";
                public static readonly string Blank = "blank";
            }

            public static class Alignment
            {
                public static readonly string Left = "left";
                public static readonly string Right = "right";
                public static readonly string Center = "center";
            }
        }


    }
}