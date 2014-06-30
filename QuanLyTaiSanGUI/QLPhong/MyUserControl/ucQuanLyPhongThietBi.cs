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
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraBars.Ribbon;
using QuanLyTaiSanGUI.MyUC;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid.Views.Grid;
using QuanLyTaiSanGUI.MyForm;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucQuanLyPhongThietBi : UserControl
    {
        Phong objPhong = new Phong();
        CTThietBi objCTThietBi = new CTThietBi();
        List<ChiTietTBHienThi> listCTThietBis = null;
        List<HinhAnh> listHinh = new List<HinhAnh>();
        ucTreeViTri _ucTreeViTri = new ucTreeViTri("QLPhongThietBi");
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();
        String function = "";

        public ucQuanLyPhongThietBi()
        {
            InitializeComponent();
            //loadData();
            //enableEdit(false, "");
            //enableBar(false);
            init();
        }

        private void init()
        {
            ribbonPhongThietBi.Parent = null;
            _ucTreeViTri.Parent = this;
            panelControl1.Controls.Add(_ucTreeLoaiTB);
            _ucTreeLoaiTB.setReadOnly(true);
        }

        // Load dữ liệu
        public void loadData()
        {
            List<LoaiThietBi> listLoai = LoaiThietBi.getAll();
            _ucTreeLoaiTB.loadData(listLoai);
            List<ViTriHienThi> listVitris = ViTriHienThi.getAllHavePhong();
            _ucTreeViTri.loadData(listVitris);
            objPhong = _ucTreeViTri.getPhong();
            listCTThietBis = ChiTietTBHienThi.getAllByPhongId(objPhong.id);
            gridControlCTThietBi.DataSource = listCTThietBis;
            if (objPhong != null)
            {
                groupPhong.Text = objPhong.ten;
            }
        }

        public void setData(int _phongid)
        {
            objPhong = Phong.getById(_phongid);
            listCTThietBis = ChiTietTBHienThi.getAllByPhongId(_phongid);
            gridControlCTThietBi.DataSource = listCTThietBis;
            if (objPhong != null)
            {
                groupPhong.Text = objPhong.ten;
            }
        }

        public RibbonControl getRibbon()
        {
            return ribbonPhongThietBi;
        }

        public TreeList getTreeList()
        {
            return _ucTreeViTri.getTreeList();
        }

        private void gridViewCTThietBi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                objCTThietBi = CTThietBi.getById(Convert.ToInt32(gridViewCTThietBi.GetRowCellValue(e.FocusedRowHandle, colid)));
                setThongTinThietBi(objCTThietBi);
            }
        }

        private void gridViewCTThietBi_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                objCTThietBi = CTThietBi.getById(Convert.ToInt32(gridViewCTThietBi.GetRowCellValue(e.RowHandle, colid)));
                setThongTinThietBi(objCTThietBi);
            }
        }

        private void setThongTinThietBi(CTThietBi _obj)
        {
            try
            {
                txtMa.Text = _obj.thietbi.subId;
                txtTen.Text = _obj.thietbi.ten;
                txtMoTa.Text = _obj.thietbi.mota;
                lblTenPhong.Text = _obj.phong.ten;
                dateMua.DateTime = _obj.thietbi.ngaymua.Value;
                dateLap.DateTime = _obj.thietbi.ngaylap.Value;
                _ucTreeLoaiTB.setLoai(_obj.thietbi.loaithietbi);
                listHinh = _obj.thietbi.hinhanhs.ToList();
                reloadImage();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": setThongTinThietBi :" + ex.Message);
            }
            finally
            { }
        }

        private void reloadImage()
        {
            imageSlider1.Images.Clear();
            foreach (HinhAnh h in listHinh)
            {
                imageSlider1.Images.Add(h.getImage());
            }
        }

        private void gridViewCTThietBi_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridViewCTThietBi.FocusedRowHandle >= 0)
            {
                objCTThietBi = CTThietBi.getById(Convert.ToInt32(gridViewCTThietBi.GetRowCellValue(gridViewCTThietBi.FocusedRowHandle, colid)));
                setThongTinThietBi(objCTThietBi);
            }
        }
    }
}
