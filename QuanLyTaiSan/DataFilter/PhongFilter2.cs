using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    /// <summary>
    /// Suwr dujng trong frmSuaPermission
    /// </summary>
    public class PhongFilter2 : FilterAbstract<PhongFilter2>
    {
        public int id { get; set; }
        public String ten { get; set; }
        public String ten_coso { get; set; }
        public String ten_day { get; set; }
        public String ten_tang { get; set; }
        public Phong phong { get; set; }

        public static List<PhongFilter2> getAll()
        {
            return db.PHONGS.Select(c => new PhongFilter2 { id = c.id, ten = c.ten, ten_coso = c.vitri.coso.ten, ten_day = c.vitri.day == null ? "" : c.vitri.day.ten, ten_tang = c.vitri.tang == null ? "" : c.vitri.tang.ten, phong = c}).ToList();
        }
    }
}
