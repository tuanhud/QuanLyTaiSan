using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("COSOS")]
    public class CoSo:_EntityAbstract2<CoSo>
    {
        public CoSo():base()
        {
            this.days = new List<Dayy>();
        }
        //public CoSo(MyDB db)
        //    : base(db)
        //{
            
        //}
        #region Định nghĩa
        public virtual ICollection<Dayy> days { get; set; }
        public virtual ICollection<ViTri> vitris { get; set; }
        #endregion
        

        #region Nghiệp vụ
        

        #endregion

        #region Override method
        protected override void init()
        {
            base.init();
            days = new List<Dayy>();
            vitris = new List<ViTri>();
        }
        #endregion

    }
}
