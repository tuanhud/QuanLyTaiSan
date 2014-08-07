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

namespace QuanLyTaiSanGUI.PhanCongQTV
{
    public partial class ucPhanCongQTV : UserControl,_ourUcInterface
    {
        QuanLyTaiSanGUI.MyUC.ucTreePhongHaveCheck _ucTreePhongHaveCheck = new QuanLyTaiSanGUI.MyUC.ucTreePhongHaveCheck(true);
        List<QuanTriVien> QuanTriViens = new List<QuanTriVien>();
        List<Phong> listPhong = new List<Phong>();
        QuanTriVien objQuanTriVien = new QuanTriVien();
        public Boolean working = false;

        QuanLyTaiSanGUI.MyUC.MyLayout layout = new QuanLyTaiSanGUI.MyUC.MyLayout();

        public ucPhanCongQTV()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            ribbonPhanCongQTV.Parent = null;
            _ucTreePhongHaveCheck.Dock = DockStyle.Fill;
            //gridViewQuanTriVien.Columns[colhoten.FieldName].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            listBoxPhong.SortOrder = SortOrder.Ascending;
            gridViewQuanTriVien.Columns[colhoten.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewQuanTriVien.Columns[colsodienthoai.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            layout.save(gridViewQuanTriVien);
        }

        public void loadData()
        {
            try
            {
                PhanCong(false);
                layout.load(gridViewQuanTriVien);
                QuanTriViens = QuanTriVien.getQuery().OrderBy(c=>c.hoten).ToList();
                gridControlQuanTriVien.DataSource = QuanTriViens;
                if (QuanTriViens.Count == 0)
                {
                    barBtnPhanCong.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }

        public void PhanCong(bool _bool)
        {
            try
            {
                splitContainerControl1.Panel1.Controls.Clear();
                if (_bool)
                {
                    List<ViTriHienThi> listVT = ViTriHienThi.getAllHavePhongNotQuanTriVien(objQuanTriVien.id);
                    _ucTreePhongHaveCheck.loadData(listVT, objQuanTriVien);
                    splitContainerControl1.Panel1.Controls.Add(_ucTreePhongHaveCheck);
                }
                else
                {
                    splitContainerControl1.Panel1.Controls.Add(gridControlQuanTriVien);
                }
                working = _bool;
                btnOK.Visible = _bool;
                btnHuy.Visible = _bool;
                barBtnPhanCong.Enabled = !_bool;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->PhanCong: " + ex.Message);
            }
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbon()
        {
            return ribbonPhanCongQTV;
        }

        private void gridViewQuanTriVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            setDataView();
        }

        private void clearText()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtUsername.Text = "";
            listBoxPhong.DataSource = null;
        }

        private void setDataView()
        {
            try
            {
                if (gridViewQuanTriVien.RowCount > 0)
                {
                    if (gridViewQuanTriVien.FocusedRowHandle > -1 && gridViewQuanTriVien.GetFocusedRow() != null)
                    {
                        objQuanTriVien = gridViewQuanTriVien.GetFocusedRow() as QuanTriVien;
                        txtMa.Text = objQuanTriVien.subId;
                        txtTen.Text = objQuanTriVien.hoten;
                        txtUsername.Text = objQuanTriVien.username;
                        txtMota.Text = objQuanTriVien.mota;
                        listPhong = objQuanTriVien.phongs.ToList();
                        listBoxPhong.DataSource = listPhong;
                    }
                    else
                    {
                        clearText();
                        objQuanTriVien = new QuanTriVien();
                    }
                }
                else
                {
                    clearText();
                    objQuanTriVien = new QuanTriVien();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataView: " + ex.Message);
            }
        }

        private void barBtnPhanCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhanCong(true);
        }

        public void LoadListPhong(List<Phong> list)
        {
            listBoxPhong.DataSource = list;
            listPhong = list;
        }

        private void gridViewQuanTriVien_DataSourceChanged(object sender, EventArgs e)
        {
            setDataView();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int id = objQuanTriVien.id;
            try
            {

                //Quan hệ 0 - n nên không thể gán list
                List<Phong> listToRemove = objQuanTriVien.phongs.ToList();
                foreach (Phong objToRemove in listToRemove)
                {
                    objToRemove.quantrivien = null;
                    objToRemove.update();
                }
                foreach (Phong objToAdd in listPhong)
                {
                    objToAdd.quantrivien = objQuanTriVien;
                    objToAdd.update();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnOK_PhanCong_Click: " + ex.Message);
            }
            finally
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Phân công quản trị viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PhanCong(false);
                reLoadAndFocused(id);
            }
        }

        private void reLoadAndFocused(int _id)
        {
            try
            {
                loadData();
                int rowHandle = gridViewQuanTriVien.LocateByValue(colid.FieldName, _id);
                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    gridViewQuanTriVien.FocusedRowHandle = rowHandle;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reLoadAndFocused: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            int id = objQuanTriVien.id;
            PhanCong(false);
            int rowHandle = gridViewQuanTriVien.LocateByValue(colid.FieldName, id);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridViewQuanTriVien.FocusedRowHandle = rowHandle;
        }

        public bool checkworking()
        {
            try
            {
                if (working)
                {
                    return
                        objQuanTriVien.phongs.Except(listPhong).Count() > 0 ||
                        listPhong.Except(objQuanTriVien.phongs).Count() > 0;
                }
                else 
                    return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkworking: " + ex.Message);
                return true;
            }
        }

        public void reLoad()
        {
            throw new NotImplementedException();
        }
    }
}
