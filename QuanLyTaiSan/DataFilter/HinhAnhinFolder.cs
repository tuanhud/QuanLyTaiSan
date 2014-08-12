using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    [Table("HinhAnhinFolder")]
    public class HinhAnhinFolder : FilterAbstract<HinhAnhinFolder>
    {
        public HinhAnhinFolder()
            : base()
        {
            
        }

        #region Dinh nghia
        [Required]
        public int id { get; set; }
        public String ten { get; set; }
        public String url { get; set; }
        
        #endregion
        #region Nghiệp vụ
        public HinhAnhinFolder(int _id, String _ten, String _url)
        {
            id = _id;
            ten = _ten;
            url = _url;
        }
        #endregion
    }
}
