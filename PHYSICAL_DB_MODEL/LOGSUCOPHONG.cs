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
    
    public partial class LOGSUCOPHONG
    {
        public LOGSUCOPHONG()
        {
            this.HINHANHS = new HashSet<HINHANH>();
        }
    
        public System.Guid id { get; set; }
        public System.Guid tinhtrang_id { get; set; }
        public System.Guid sucophong_id { get; set; }
        public Nullable<System.Guid> quantrivien_id { get; set; }
        public string subId { get; set; }
        public Nullable<long> order { get; set; }
        public string mota { get; set; }
        public Nullable<System.DateTime> date_create { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
    
        public virtual QUANTRIVIEN QUANTRIVIEN { get; set; }
        public virtual SUCOPHONG SUCOPHONG { get; set; }
        public virtual TINHTRANG TINHTRANG { get; set; }
        public virtual ICollection<HINHANH> HINHANHS { get; set; }
    }
}
