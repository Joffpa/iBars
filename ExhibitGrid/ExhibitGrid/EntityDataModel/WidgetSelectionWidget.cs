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
    using System.Collections.Generic;
    
    public partial class WidgetSelectionWidget
    {
        public int WidgetSelectionId { get; set; }
        public int WidgetId { get; set; }
        public Nullable<int> ValueOrder { get; set; }
    
        public virtual Widget Widget { get; set; }
        public virtual WidgetSelection WidgetSelection { get; set; }
    }
}
