//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PHYSICAL_DB_MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PERMISSION
    {
        public PERMISSION()
        {
            this.DONVIS = new HashSet<DONVI>();
            this.GROUPS = new HashSet<GROUP>();
        }
    
        public System.Guid id { get; set; }
        public string key { get; set; }
        public bool stand_alone { get; set; }
        public bool allow_or_deny { get; set; }
        public bool recursive_to_child { get; set; }
        public bool can_view { get; set; }
        public bool can_edit { get; set; }
        public bool can_delete { get; set; }
        public bool can_add { get; set; }
        public string subId { get; set; }
        public Nullable<long> order { get; set; }
        public string mota { get; set; }
        public Nullable<System.DateTime> date_create { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
    
        public virtual ICollection<DONVI> DONVIS { get; set; }
        public virtual ICollection<GROUP> GROUPS { get; set; }
    }
}
