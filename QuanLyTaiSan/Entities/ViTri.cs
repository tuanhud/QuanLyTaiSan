using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("VITRIS")]
    public class ViTri : _EntityAbstract1<ViTri>
    {
        public ViTri():base()
        {
            
        }
        public ViTri(MyDB db)
            : base(db)
        {

        }
        public String mota { get; set; }
        
        //Hàm dùng tạm để test dũu liệu
        public ViTri getBy3Id(int id1, int id2, int id3)
        {
            try
            {
                initDb();
                ViTri obj = null;
                if (id3 != -1)
                {
                    obj = db.Set<ViTri>().Where(c => c.coso.id == id1 && c.day.id == id2 && c.tang.id == id3).FirstOrDefault();
                }
                else if (id2 != -1)
                {
                    obj = db.Set<ViTri>().Where(c => c.coso.id == id1 && c.day.id == id2 && c.tang.id == null).FirstOrDefault();
                }
                else
                {
                    obj = db.Set<ViTri>().Where(c => c.coso.id == id1 && c.day.id == null && c.tang.id == null).FirstOrDefault();
                }
                if (obj != null)
                {
                    obj.DB = db;
                }
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        /*
         * FK
         */
        [Index("nothing", 1, IsUnique = true)]
        public virtual CoSo coso { get; set; }

        [Index("nothing", 2, IsUnique = true)]
        public virtual Dayy day { get; set; }

        [Index("nothing", 3, IsUnique = true)]
        public virtual Tang tang { get; set; }

        public virtual ICollection<Phong> phongs { get; set; }
    }
}
