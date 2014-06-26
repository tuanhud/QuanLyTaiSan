using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.DataFilter;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars.Ribbon;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.MyForm;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.QLThietBi
{
    public partial class ucQuanLyThietBi : UserControl
    {
        ucTreePhong _ucTreePhong = null;//Chọn phòng bên trái
        ucTreeViTri _ucTreeViTri = null;//Chọn phòng cho thiết bị (bên phải)
        ucTreeLoaiTB _ucTreeLoaiTB = new ucTreeLoaiTB();//Chọn loại thiết bị

        List<ViTriFilter> listViTri = null;
        List<ThietBiFilter> listThietBiFilter = null;
        List<LoaiThietBi> listLoaiThietBi = null;

        ThietBi objThietBi = new ThietBi();
        ThietBiFilter objThietBiFilter = new ThietBiFilter();
        List<HinhAnh> listHinhAnh = new List<HinhAnh>();
        String function = "";

        public ucQuanLyThietBi()
        {
            InitializeComponent();
            loadData();
        }

        //load treelist va tat va cac thiet bi
        private void loadData()
        {
            
            ribbonThietBi.Parent = null;
            //Lấy danh sách phòng
            listViTri = new ViTriFilter().getAllHavePhong();
            //Xủ lí nếu chưa có cơ sở, dãy, tầng và phòng !!!!!!!!!!!!!!

            //Set danh sách phòng vào _ucTreePhong
            _ucTreePhong = new ucTreePhong(listViTri, "QLThietBi");
            _ucTreePhong.Parent = this;

            //set loai thiet bi
            listLoaiThietBi = new LoaiThietBi().getAll().OrderBy(i => i.ten).ToList();
            //if (listLoaiThietBi.Count == 0)
            //{
            //    LoaiThietBi loaiThietBiNULL = new LoaiThietBi();
            //    loaiThietBiNULL.id = -1;
            //    loaiThietBiNULL.ten = "[Chưa có loại thiết bị]";
            //    listLoaiThietBi.Add(loaiThietBiNULL);
            //}

            _ucTreeLoaiTB.loadData(listLoaiThietBi);
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            _ucTreeLoaiTB.setReadOnly(true);
            panelControlLoaiThietBi.Controls.Clear();
            panelControlLoaiThietBi.Controls.Add(_ucTreeLoaiTB);
            _ucTreeLoaiTB.setTextPopupContainerEdit(null);

            //Set danh sách phòng _ucTreeViTri
            _ucTreeViTri = new ucTreeViTri(false, true);
            _ucTreeViTri.loadData(listViTri);
            _ucTreeViTri.Dock = DockStyle.Fill;
            _ucTreeViTri.setReadOnly(true);
            panelControlPhong.Controls.Clear();
            panelControlPhong.Controls.Add(_ucTreeViTri);
            _ucTreeViTri.setTextPopupContainerEdit(null);

            
            listThietBiFilter = new ThietBiFilter().getAllBy4Id(-1,-1,-1,-1);
            gridControlThietBi.DataSource = listThietBiFilter;
            
            //objThietBiFilter = listThietBiFilter.ElementAt(2);
            //objThietBi = new ThietBi().getById(objThietBiFilter.idTB);
            //_ucTreeViTri.setPhong(new Phong().getById(1));
            //setData();
        }

        protected void reLoad()
        {
            listThietBiFilter = new ThietBiFilter().getAllBy4Id(-1, -1, -1, -1);
            gridControlThietBi.DataSource = listThietBiFilter;
        }

        private void checkSuaXoaThietBi()
        {
            if (listThietBiFilter.Count == 0)
            {
                barButtonSuaThietBi.Enabled = false;
                barButtonXoaThietBi.Enabled = false;
            }
            else
            {
                barButtonSuaThietBi.Enabled = true;
                barButtonXoaThietBi.Enabled = true;
            }
        }

        private void deleteData()
        {
            imageSlider1.Images.Clear();
            txtMa.Text = "";
            txtTen.Text = "";
            //_ucTreeLoaiTB.setTextPopupContainerEdit("");
            //_ucTreeViTri.setTextPopupContainerEdit("");
            panelControlLoaiThietBi.Controls.Clear();
            panelControlPhong.Controls.Clear();
            dateMua.EditValue = null;
            dateLap.EditValue = null;
            txtMoTa.Text = "";
            gridControlLog.DataSource = null;
            //if (listLoaiThietBi.Count > 0)
            //    _ucTreeLoaiTB.setLoai(listLoaiThietBi.FirstOrDefault());
            //if(listViTri.Count>0)
            //    _ucTreeViTri.setViTri(
            
        }

        public void enableEdit(bool _enable, String _function)
        {
            function = _function;
            if (_enable)
            {
                btnImage.Visible = true;
                btnOk.Visible = true;
                btnHuy.Visible = true;
                if (objThietBi.loaithietbi.loaichung)
                {
                    txtMa.Properties.ReadOnly = false;
                    txtTen.Properties.ReadOnly = true;
                    txtMoTa.Properties.ReadOnly = false;
                    dateMua.Properties.ReadOnly = true;
                    dateLap.Properties.ReadOnly = true;

                }
                else
                {
                    txtMa.Properties.ReadOnly = false;
                    txtTen.Properties.ReadOnly = false;
                    txtMoTa.Properties.ReadOnly = false;
                    dateMua.Properties.ReadOnly = false;
                    dateLap.Properties.ReadOnly = false;
                }
                _ucTreeLoaiTB.setReadOnly(true);
                _ucTreeViTri.setReadOnly(true);
            }
            else
            {
                btnImage.Visible = false;
                btnOk.Visible = false;
                btnHuy.Visible = false;
                
                txtTen.Properties.ReadOnly = true;
                txtMa.Properties.ReadOnly = true;
                txtMoTa.Properties.ReadOnly = true;
                _ucTreeLoaiTB.setReadOnly(true);
                _ucTreeViTri.setReadOnly(true);
                dateMua.Properties.ReadOnly = true;
                dateLap.Properties.ReadOnly = true;
            }
        }

        public void SetTextGroupControl(String text, Color color)
        {
            groupControl1.Text = text;
            groupControl1.AppearanceCaption.ForeColor = color;
        }



        public TreeList getTreeList()
        {
            return _ucTreePhong.getTreeList();
        }

        public RibbonControl getRibbon()
        {
            return ribbonThietBi;  
        }

        //set data cho gridControlThietBi
        public void setData(int phongid, int cosoid, int dayid, int tangid)
        {
            listThietBiFilter = new ThietBiFilter().getAllBy4Id(phongid, cosoid, dayid, tangid);
            gridControlThietBi.DataSource = null;
            gridControlThietBi.DataSource = listThietBiFilter;
        }

        //set thong tin 1 thiet bi
        private void setData()
        {
            if (listThietBiFilter.Count > 0)
            {
                imageSlider1.Images.Clear();
                if (objThietBi.hinhanhs.Count > 0)
                {
                    foreach (HinhAnh hinhanh in objThietBi.hinhanhs)
                    {
                        imageSlider1.Images.Add(hinhanh.IMAGE);
                    }
                }
                listHinhAnh = objThietBi.hinhanhs.ToList();

                txtTen.Text = objThietBi.ten;
                _ucTreeLoaiTB.setLoai(objThietBi.loaithietbi);
                _ucTreeViTri.setPhong(new Phong().getById(objThietBiFilter.phong_id));
                panelControlLoaiThietBi.Controls.Add(_ucTreeLoaiTB);
                panelControlPhong.Controls.Add(_ucTreeViTri);
                //if (objThietBi.loaithietbi.loaichung)
                //{
                //    txtMa.Visible = false;
                //    dateMua.Visible = false;
                //    dateLap.Visible = false;
                //    txtMoTa.Visible = false;
                //}
                //else
                //{
                //    txtMa.Visible = true;
                //    dateMua.Visible = true;
                //    dateLap.Visible = true;
                //    txtMoTa.Visible = true;
                //    txtMa.Text = objThietBi.subId;
                //    dateMua.DateTime = objThietBi.ngaymua.Value;
                //    dateLap.DateTime = objThietBi.ngaylap.Value;
                //    txtMoTa.Text = objThietBi.mota;
                //}
                txtMa.Text = objThietBi.subId;
                dateMua.EditValue = objThietBi.ngaymua;
                dateLap.EditValue = objThietBi.ngaylap;
                txtMoTa.Text = objThietBi.mota;

                //log
                //gridControlLog.DataSource = objThietBi.logthietbis;
            }
            else
                deleteData();
        }

        private void setDataObj()
        {
            //list hinh
            objThietBi.hinhanhs = listHinhAnh;
            objThietBi.subId = txtMa.Text;
            objThietBi.ten = txtTen.Text;
            //if(function.Equals("add"))
            //{
            //    CTThietBi ctthietbi = new CTThietBi();
            //    ctthietbi.phong = _ucTreeViTri.getPhong();
            //    ctthietbi.tinhtrang = new TinhTrang().getById(4);//tinh trang moi phai co san

            //}
            //chi tiet thiet bi la phong
            if (objThietBi.loaithietbi.loaichung)
            {
                objThietBi.ngaymua = null;
                objThietBi.ngaylap = null;
            }
            else
            {
                objThietBi.ngaymua = dateMua.DateTime;
                objThietBi.ngaylap = dateLap.DateTime;
            }
            objThietBi.mota = txtMoTa.Text;
        }

        private void barButtonThemThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNewThietBi frm = new frmNewThietBi();
            frm.sendMessage = new frmNewThietBi.SendMessage(reLoad);
            frm.ShowDialog();
        }

        private void gridViewThietBi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int row = gridViewThietBi.FocusedRowHandle;
            if (row >= 0)
            {
                //objThietBi = new ThietBi().getById(Convert.ToInt32(gridViewThietBi.GetFocusedRowCellValue(colidTB)));
                objThietBiFilter = gridViewThietBi.GetFocusedRow() as ThietBiFilter;
                objThietBi = new ThietBi().getById(objThietBiFilter.idTB);
                enableEdit(false, "");
                setData();
                barButtonThemThietBi.Enabled = true;
                barButtonXoaThietBi.Enabled = true;
            }
            else
            {
                deleteData();
                barButtonThemThietBi.Enabled = false;
                barButtonXoaThietBi.Enabled = false;
            }
            

            Console.WriteLine();
        }

        private void barButtonSuaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "edit");
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            frmHinhAnh frm = new frmHinhAnh(listHinhAnh);
            frm.Text = "Quản lý hình ảnh " + objThietBi.ten;
            frm.ShowDialog();
            listHinhAnh = frm.getlistHinhs();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            enableEdit(false, "");
            setData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            setDataObj();
            if (objThietBi.update() != -1)
            {
                XtraMessageBox.Show("Sửa thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                enableEdit(false, "");
                reLoad();
                setData();
            }
        }

        private void barButtonXoaThietBi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc là muốn xóa thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                for (int i = 0; i < objThietBi.ctthietbis.Count; i++)
                {
                    objThietBi.ctthietbis.ElementAt(i).delete();
                }
                if (objThietBi.delete() != -1)
                {
                    XtraMessageBox.Show("Xóa thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    enableEdit(false, "");
                    reLoad();
                }
            }
        }
    }
}
