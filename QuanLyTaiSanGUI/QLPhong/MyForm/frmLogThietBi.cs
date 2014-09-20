using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PTB.Entities;
using SHARED.Libraries;

namespace PTB_GUI.QLPhong.MyForm
{
    public partial class frmLogThietBi : DevExpress.XtraEditors.XtraForm
    {
        public frmLogThietBi()
        {
            InitializeComponent();
        }

        public frmLogThietBi(List<LogThietBi> list)
        {
            InitializeComponent();
            gridControlLogThietBi.DataSource = list;
        }

        private void reloadImage(List<HinhAnh> list)
        {
            foreach (HinhAnh h in list)
            {
                try
                {
                    imageSlider1.Images.Add(h.getImage());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(this.Name + "->reloadImage: " + ex.Message);
                }
            }
        }

        private void gridViewLogThietBi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LogThietBi obj = gridViewLogThietBi.GetFocusedRow() != null ? gridViewLogThietBi.GetFocusedRow() as LogThietBi : new LogThietBi();
            imageSlider1.Images.Clear();
            if (obj.hinhanhs.Count > 0)
                reloadImage(obj.hinhanhs.ToList());
        }
    }
}