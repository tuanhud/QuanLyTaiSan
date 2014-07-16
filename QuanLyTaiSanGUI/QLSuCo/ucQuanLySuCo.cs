using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.QLSuCo
{
    public partial class ucQuanLySuCo : UserControl
    {
        List<SuCoPhong> listSuCo = new List<SuCoPhong>();
        public ucQuanLySuCo()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            listSuCo = SuCoPhong.getAll();
            gridControlSuCo.DataSource = listSuCo;
            gridViewSuCo.PopulateColumns();
        }

        private void gridViewSuCo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(gridViewSuCo.GetFocusedRow() != null)
            {
                //gridControlLogSuCo.DataSource = (gridViewSuCo.GetFocusedRow() as SuCoPhong).logsucophongs.ToList();
                //gridViewLogSuCo.PopulateColumns();
            }
        }
    }
}
