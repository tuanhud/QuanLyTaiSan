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
using QuanLyTaiSanGUI.QLThietBi;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.MyUserControl;

namespace QuanLyTaiSanGUI.QLPhong.MyForm
{
    public partial class frmAddThietBi : DevExpress.XtraEditors.XtraForm
    {
        ucQuanLyThietBi _ucQuanLyThietBi = new ucQuanLyThietBi(true);
        public ucQuanLyPhongThietBi _ucQuanLyPhongThietBi = null;
        Phong objPhong = new Phong();
        bool loaichung = true;

        public frmAddThietBi()
        {
            InitializeComponent();
        }

        public frmAddThietBi(Phong obj, bool _loaichung)
        {
            InitializeComponent();
            loaichung = _loaichung;
            _ucQuanLyThietBi.Dock = DockStyle.Fill;
            _ucQuanLyThietBi.loadData(loaichung);
            panelControl1.Controls.Add(_ucQuanLyThietBi);
            objPhong = obj;
            dateEdit1.DateTime = DateTime.Now;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThietBi objThietBi = _ucQuanLyThietBi.getThietBi();
            if(objThietBi != null)
            {
                frmTinhTrangVaSoLuong frm = new frmTinhTrangVaSoLuong(loaichung);
                if(frm.ShowDialog().Equals(DialogResult.OK))
                {
                    CTThietBi obj = new CTThietBi();
                    obj.phong = objPhong;
                    obj.thietbi = objThietBi;
                    obj.tinhtrang = frm.objTinhTrang;
                    obj.soluong = frm.SoLuong;
                    //Ngày lắp thiết bị
                    if (!loaichung)
                        obj.thietbi.ngaylap = dateEdit1.EditValue == null ? DateTime.Now : dateEdit1.DateTime;
                    if (obj.add() > 0)
                    {
                        XtraMessageBox.Show("Thêm thiết bị vào phòng thành công!");
                        int id = obj.id;
                        _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                        if (!loaichung)
                        {
                            _ucQuanLyThietBi.loadData(loaichung);
                        }
                    }
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}