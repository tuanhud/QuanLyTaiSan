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
    
    public partial class CTTAISAN
    {
        public CTTAISAN()
        {
            this.CTTAISANS1 = new HashSet<CTTAISAN>();
            this.LOGTAISANS = new HashSet<LOGTAISAN>();
        }
    
        public System.Guid id { get; set; }
        public string ghichu { get; set; }
        public bool isTang { get; set; }
        public bool isChuyen { get; set; }
        public int soluong { get; set; }
        public string nguongoc { get; set; }
        public Nullable<System.DateTime> ngay { get; set; }
        public string chungtu_sohieu { get; set; }
        public Nullable<System.DateTime> chungtu_ngay { get; set; }
        public Nullable<System.Guid> donviquanly_id { get; set; }
        public Nullable<System.Guid> donvisudung_id { get; set; }
        public System.Guid tinhtrang_id { get; set; }
        public Nullable<System.Guid> vitri_id { get; set; }
        public Nullable<System.Guid> phong_id { get; set; }
        public System.Guid taisan_id { get; set; }
        public Nullable<System.Guid> parent_id { get; set; }
        public string subId { get; set; }
        public Nullable<long> order { get; set; }
        public string mota { get; set; }
        public Nullable<System.DateTime> date_create { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
    
        public virtual ICollection<CTTAISAN> CTTAISANS1 { get; set; }
        public virtual CTTAISAN CTTAISAN1 { get; set; }
        public virtual DONVI DONVI { get; set; }
        public virtual DONVI DONVI1 { get; set; }
        public virtual PHONG PHONG { get; set; }
        public virtual TAISAN TAISAN { get; set; }
        public virtual TINHTRANG TINHTRANG { get; set; }
        public virtual VITRI VITRI { get; set; }
        public virtual ICollection<LOGTAISAN> LOGTAISANS { get; set; }
    }
}