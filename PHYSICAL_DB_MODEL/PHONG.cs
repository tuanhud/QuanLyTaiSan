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
    
    public partial class PHONG
    {
        public PHONG()
        {
            this.CTTAISANS = new HashSet<CTTAISAN>();
            this.LOGTAISANS = new HashSet<LOGTAISAN>();
        }
    
        public System.Guid id { get; set; }
        public string ten { get; set; }
        public System.Guid loaiphong_id { get; set; }
        public System.Guid vitri_id { get; set; }
        public string subId { get; set; }
        public Nullable<long> order { get; set; }
        public string mota { get; set; }
        public Nullable<System.DateTime> date_create { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
    
        public virtual ICollection<CTTAISAN> CTTAISANS { get; set; }
        public virtual LOAIPHONG LOAIPHONG { get; set; }
        public virtual ICollection<LOGTAISAN> LOGTAISANS { get; set; }
        public virtual VITRI VITRI { get; set; }
    }
}
