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

namespace QuanLyTaiSanGUI.QLLoaiThietBi
{
    public partial class ucQuanLyLoaiTB : UserControl
    {
        List<LoaiThietBi> listLoaiThietBis = new List<LoaiThietBi>();
        List<LoaiThietBi> lueLoaiThietBis = new List<LoaiThietBi>();
        string function = "";
        LoaiThietBi objLoaiThietBi = new LoaiThietBi();

        public ucQuanLyLoaiTB()
        {
            InitializeComponent();
            lueThuoc.Properties.ReadOnly = false;
            reLoad();

        }

        private void treeListLoaiTB_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (treeListLoaiTB.GetDataRecordByNode(e.Node) != null)
            {
                LoaiThietBi obj = (LoaiThietBi)treeListLoaiTB.GetDataRecordByNode(e.Node);
                txtTen.Text = obj.ten;
                lueThuoc.EditValue = obj.parent_id;
            }
        }

        public void enableEdit(bool _enable, String _function)
        {
            function = _function;
            if (_enable)
            {
                btnImage.Visible = true;
                btnOk.Visible = true;
                btnHuy.Visible = true;
                txtTen.Properties.ReadOnly = false;
                lueThuoc.Properties.ReadOnly = false;
                ceTBsoluonglon.Properties.ReadOnly = false;
            }
            else
            {
                btnImage.Visible = false;
                btnOk.Visible = false;
                btnHuy.Visible = false;
                txtTen.Properties.ReadOnly = true;
                lueThuoc.Properties.ReadOnly = true;
                ceTBsoluonglon.Properties.ReadOnly = true;
            }
        }

        private void reLoad()
        {
            listLoaiThietBis = new LoaiThietBi().getAll();
            treeListLoaiTB.DataSource = listLoaiThietBis;
            lueLoaiThietBis = new LoaiThietBi().getAllParent();
            lueThuoc.Properties.DataSource = lueLoaiThietBis;
        }

        public void beforeAdd()
        {
            txtTen.Text = "";
            //if (lueLoaiThietBis != null && lueLoaiThietBis.Count > 0)
            //{
            //    lueThuoc.Properties.DataSource = lueLoaiThietBis;
            //}
            imageSlider1.Images.Clear();
        }

        public void beforeEdit()
        {
            //txtMa.Text = objNhanVienPT.subId;
            //txtTen.Text = objNhanVienPT.hoten;
            //txtSodt.Text = objNhanVienPT.sodienthoai;
            //imageSlider1.Images.Clear();
        }
    }
}
