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
    [Table("TANGS")]
    public class Tang:_EntityAbstract2<Tang>
    {
        public Tang():base()
        {
            
        }
        public Tang(MyDB db)
            : base(db)
        {

        }
        //Lấy list tầng theo dãy id
        public List<Tang> GetByDayId(int id)
        {
            try
            {
                initDb();
                List<Tang> objs = db.Set<Tang>().Where(c => c.day.id == id).ToList();
                foreach (Tang item in objs)
                {
                    item.DB = db;//importance
                }
                return objs;
            }
            catch (Exception ex)
            {
                return new List<Tang>();
            }
            finally
            {

            }
        }
        protected override void init()
        {
            base.init();
            this.vitris = new List<ViTri>();
        }
        /*
         * FK
         */
        [Required]
        public virtual Dayy day { get; set; }
        public virtual ICollection<ViTri> vitris { get; set; }
    }
}
