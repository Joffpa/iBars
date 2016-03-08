//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExhibitGrid.EntityDataModel
{
    using System;
    
    public partial class Attributes
    {
        public Attributes()
        {
            this.Class = "";
            this.CanCollapse = false;
            this.CanSelect = false;
            this.DisplayOrder = 0;
            this.IsEditable = false;
            this.IsHidden = false;
            this.DisplayText = "";
            this.Width = "";
            this.HasHeader = false;
            this.Directive = "";
            this.ColSpan = 1;
            this.Level = 0;
            this.CanAdd = false;
            this.CanDelete = false;
            this.Indent = 0;
            this.IsBlank = false;
            this.Value = "";
        }
    
        public string GridCode { get; set; }
        public string RowCode { get; set; }
        public string ColCode { get; set; }
        public string Class { get; set; }
        public Nullable<bool> CanCollapse { get; set; }
        public Nullable<bool> CanSelect { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> IsEditable { get; set; }
        public Nullable<bool> IsHidden { get; set; }
        public string HeaderText { get; set; }
        public string HoverBase { get; set; }
        public string HoverAddition { get; set; }
        public string DisplayText { get; set; }
        public string Width { get; set; }
        public Nullable<bool> HasHeader { get; set; }
        public string Directive { get; set; }
        public Nullable<int> ColSpan { get; set; }
        public Nullable<int> Level { get; set; }
        public Nullable<bool> CanAdd { get; set; }
        public Nullable<bool> CanDelete { get; set; }
        public Nullable<int> Indent { get; set; }
        public Nullable<bool> IsBlank { get; set; }
        public string Value { get; set; }
        public string HoverText { get; set; }
    }
}