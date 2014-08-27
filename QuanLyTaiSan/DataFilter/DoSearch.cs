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
    [Table("Search")]
    public class DoSearch : FilterAbstract<DoSearch>
    {
        public DoSearch()
            : base()
        {
            
        }

        #region Dinh nghia
        [Required]
        public Guid id { get; set; }
        public String ten { get; set; }
        public String loai { get; set; }
        
        #endregion
        #region Nghiệp vụ
        public DoSearch(Guid _id, String _ten, String _loai)
        {
            id = _id;
            ten = _ten;
            loai = _loai;
        }
        #endregion
    }
}
