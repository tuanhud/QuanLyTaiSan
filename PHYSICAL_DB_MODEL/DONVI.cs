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
    
    public partial class DONVI
    {
        public DONVI()
        {
            this.CTTAISANS = new HashSet<CTTAISAN>();
            this.CTTAISANS1 = new HashSet<CTTAISAN>();
            this.DONVIS1 = new HashSet<DONVI>();
            this.LOGTAISANS = new HashSet<LOGTAISAN>();
            this.LOGTAISANS1 = new HashSet<LOGTAISAN>();
            this.PERMISSIONS = new HashSet<PERMISSION>();
        }
    
        public System.Guid id { get; set; }
        public string ten { get; set; }
        public Nullable<System.Guid> parent_id { get; set; }
        public System.Guid loaidonvi_id { get; set; }
        public string subId { get; set; }
        public Nullable<long> order { get; set; }
        public string mota { get; set; }
        public Nullable<System.DateTime> date_create { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
    
        public virtual ICollection<CTTAISAN> CTTAISANS { get; set; }
        public virtual ICollection<CTTAISAN> CTTAISANS1 { get; set; }
        public virtual ICollection<DONVI> DONVIS1 { get; set; }
        public virtual DONVI DONVI1 { get; set; }
        public virtual LOAIDONVI LOAIDONVI { get; set; }
        public virtual ICollection<LOGTAISAN> LOGTAISANS { get; set; }
        public virtual ICollection<LOGTAISAN> LOGTAISANS1 { get; set; }
        public virtual ICollection<PERMISSION> PERMISSIONS { get; set; }
    }
}
