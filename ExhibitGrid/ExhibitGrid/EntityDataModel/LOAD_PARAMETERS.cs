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
    
    public partial class LOAD_PARAMETERS
    {
        public int parameter_id_pk { get; set; }
        public string parm_name { get; set; }
        public string parm_value { get; set; }
        public string parm_type { get; set; }
        public string parm_label { get; set; }
        public Nullable<int> parm_order { get; set; }
        public Nullable<System.DateTime> last_modified_date { get; set; }
        public string parm_page { get; set; }
        public string interface_element { get; set; }
        public string dropdown_value { get; set; }
        public Nullable<bool> visible { get; set; }
        public Nullable<int> parm_block_fk { get; set; }
        public string HoverText { get; set; }
    }
}
