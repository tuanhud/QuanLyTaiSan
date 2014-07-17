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
        QuanLyTaiSanGUI.MyUC.ucTreeViTri _ucTreeViTri = new QuanLyTaiSanGUI.MyUC.ucTreeViTri("QLSuCoPhong");
        List<SuCoPhong> listSuCo = new List<SuCoPhong>();
        SuCoPhong objSuCo = new SuCoPhong();
        String function = "";

        public ucQuanLySuCo()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            ribbonSuCoPhong.Parent = null;
            gridViewSuCo.Columns[colmodified.FieldName].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            gridViewSuCo.Columns[colten.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewSuCo.Columns[coltinhtrang.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewSuCo.Columns[colmota.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            
            gridViewLogSuCo.Columns[collngay.FieldName].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            gridViewLogSuCo.Columns[collngay.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewLogSuCo.Columns[colltinhtrang.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewLogSuCo.Columns[collmota.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            gridViewLogSuCo.Columns[collqtvien.FieldName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;

            _ucTreeViTri.Parent = this;
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbon()
        {
            return ribbonSuCoPhong;
        }

        public DevExpress.XtraTreeList.TreeList getTreeList()
        {
            return _ucTreeViTri.getTreeList();
        }

        public void loadData()
        {
            List<QuanLyTaiSan.DataFilter.ViTriHienThi> listViTri = QuanLyTaiSan.DataFilter.ViTriHienThi.getAllHavePhong();
            _ucTreeViTri.loadData(listViTri);
            List<TinhTrang> listTinhTrang = TinhTrang.getAll();
            lookUpEditTinhTrang.Properties.DataSource = listTinhTrang;
            lookUpEditTinhTrang.EditValue = listTinhTrang.Count > 0 ? listTinhTrang.FirstOrDefault().id.ToString() : "";
            listSuCo = SuCoPhong.getAll();
            gridControlSuCo.DataSource = listSuCo;
        }

        public void loadData(int id)
        {
            //List<TinhTrang> listTinhTrang = TinhTrang.getAll();
            //lookUpEditTinhTrang.Properties.DataSource = listTinhTrang;
            //lookUpEditTinhTrang.EditValue = listTinhTrang.Count > 0 ? listTinhTrang.FirstOrDefault().id.ToString() : "";
            listSuCo = SuCoPhong.getQuery().Where(c=>c.phong_id == id).ToList();
            gridControlSuCo.DataSource = listSuCo;
        }


        private void editGUI(String _type)
        {
            function = _type;
            if (_type.Equals("view"))
            {
                SetTextGroupControl("Chi tiết", Color.Empty);
                enableEdit(false);
            }
            else if (_type.Equals("onlyview"))
            {
                SetTextGroupControl("Chi tiết", Color.Empty);
                enableButton(false);
            }
            else if (_type.Equals("add"))
            {
                SetTextGroupControl("Thêm tình trạng", Color.Red);
                enableEdit(true);
                clearText();
                txtTen.Focus();
            }
            else if (_type.Equals("edit"))
            {
                SetTextGroupControl("Sửa tình trạng", Color.Red);
                enableEdit(true);
                txtTen.Focus();
            }
        }

        private void SetTextGroupControl(String text, Color color)
        {
            groupControl1.Text = text;
            groupControl1.AppearanceCaption.ForeColor = color;
        }

        private void enableEdit(bool _enable)
        {
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            btnImage.Visible = _enable;
            checkEdit1.Visible = _enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtMota.Properties.ReadOnly = !_enable;
            lookUpEditTinhTrang.Properties.ReadOnly = !_enable;
            dateEdit1.Properties.ReadOnly = !_enable;
            enableButton(!_enable);
            barBtnThem.Enabled = !_enable;
            btnR_Them.Enabled = !_enable;
        }

        private void enableButton(bool _enable)
        {
            //btnR_Them.Enabled = _enable;
            btnR_Sua.Enabled = _enable;
            btnR_Xoa.Enabled = _enable;
            barBtnSua.Enabled = _enable;
            barBtnXoa.Enabled = _enable;
        }

        private void clearText()
        {
            txtTen.Text = "";
            lookUpEditTinhTrang.EditValue = null;
            dateEdit1.EditValue = null;
            lblPhong.Text = "";
            lblNhanVien.Text = "";
            txtMota.Text = "";
            imageSlider1.Images.Clear();
        }

        private void setDataView(bool isLog = false, DevExpress.XtraGrid.Views.Grid.GridView view = null)
        {
            try
            {
                //errorProvider1.Clear();
                clearText();
                if (isLog)
                {
                    if (!function.Equals("onlyview"))
                        editGUI("onlyview");
                }
                else
                {
                    if (!function.Equals("view"))
                        editGUI("view");
                }
                if (gridViewSuCo.RowCount > 0)
                {
                    if (gridViewSuCo.FocusedRowHandle > -1 && gridViewSuCo.GetFocusedRow() != null)
                    {                        
                        objSuCo = gridViewSuCo.GetFocusedRow() as SuCoPhong;
                        txtTen.Text = objSuCo.ten;
                        lookUpEditTinhTrang.EditValue = objSuCo.tinhtrang_id;
                        lblPhong.Text = objSuCo.phong.ten;
                        txtMota.Text = objSuCo.mota;
                        if (isLog && view.FocusedRowHandle > -1 && view.GetFocusedRow() != null)
                        {
                            LogSuCoPhong obj = view.GetFocusedRow() as LogSuCoPhong;
                            dateEdit1.EditValue = obj.ngay;
                            lblNhanVien.Text = obj.quantrivien != null ? obj.quantrivien.hoten : "";
                            txtMota.Text = obj.mota;
                        }
                        //else if (objSuCo.logsucophongs.Count > 0 && !isLog)
                        //{
                        //    LogSuCoPhong obj = objSuCo.logsucophongs.OrderByDescending(c => c.ngay).FirstOrDefault();
                        //    dateEdit1.EditValue = obj.ngay;
                        //    lblNhanVien.Text = obj.quantrivien != null ? obj.quantrivien.hoten : "";
                        //    txtMota.Text = obj.mota;
                        //}
                    }
                    else
                    {
                        objSuCo = new SuCoPhong();
                    }
                }
                else
                {
                    objSuCo = new SuCoPhong();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataView: " + ex.Message);
            }
        }

        private void gridViewSuCo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            setDataView();
        }

        private void barBtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (SuCoPhong obj in listSuCo)
            {
                obj.tinhtrang = TinhTrang.getById(21);
                obj.mota = "xyz";
                obj.update();
            }
        }

        private void gridViewSuCo_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            SuCoPhong c = (SuCoPhong)gridViewSuCo.GetRow(e.RowHandle);
            e.IsEmpty = c.logsucophongs.Count == 0;
        }

        private void gridViewSuCo_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gridViewSuCo_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Log";
        }

        private void gridViewSuCo_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            SuCoPhong c = (SuCoPhong)gridViewSuCo.GetRow(e.RowHandle);
            e.ChildList = c.logsucophongs.ToList();
        }

        private void gridViewSuCo_DataSourceChanged(object sender, EventArgs e)
        {
            setDataView();
        }

        private void gridViewLogSuCo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            setDataView(true, sender as DevExpress.XtraGrid.Views.Grid.GridView);
        }

        private void gridControlSuCo_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View.Equals(gridViewSuCo))
            {
                setDataView();
            }
            else
            {
                setDataView(true, e.View as DevExpress.XtraGrid.Views.Grid.GridView);
            }
        }
    }
}
