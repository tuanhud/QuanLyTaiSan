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

namespace QuanLyTaiSanGUI
{
    public partial class frmShowImage : DevExpress.XtraEditors.XtraForm
    {
        public frmShowImage()
        {
            InitializeComponent();
        }
        public frmShowImage(List<QuanLyTaiSan.Entities.HinhAnh> listHinh)
        {
            InitializeComponent();
            loadImage(listHinh);
        }

        private void loadImage(List<QuanLyTaiSan.Entities.HinhAnh> listHinh)
        {
            try
            {
                imageSlider1.Images.Clear();
                foreach (QuanLyTaiSan.Entities.HinhAnh h in listHinh)
                {
                    imageSlider1.Images.Add(h.getImage());
                }
            }
            catch
            {
            }
        }
    }
}