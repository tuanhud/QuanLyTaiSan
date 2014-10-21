using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PTB.DataFilter;
using PTB.Entities;
using PTB_GUI.Libraries;
using DevExpress.XtraBars.Ribbon;
using PTB.Libraries;
using SHARED.Libraries;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Columns;
using PTB_GUI.MyUC;

namespace PTB_GUI.ThongKe
{
    public partial class ucTK_SLTB_TheoTinhTrang : DevExpress.XtraEditors.XtraUserControl, _ourUcInterface
    {
        PTB_GUI.MyUC.ucTreeLoaiTB ucTreeLoaiTB2 = new MyUC.ucTreeLoaiTB(true);
        //List<TKSLThietBiFilter> list_tk = new List<TKSLThietBiFilter>();
        MyLayout layout = new MyLayout();

        public ucTK_SLTB_TheoTinhTrang()
        {
            InitializeComponent();
            ribbonThongKe.Parent = null;
            layout.save(gridViewThongKe);
            loadData();
        }

        public void loadData()
        {
            checkedComboBoxEdit_tinhTrang.Properties.DataSource =
                TinhTrang.getAll();

            //ucTreeLoaiTB2
            ucTreeLoaiTB2.loadData(LoaiThietBi.getAll());
            ucTreeLoaiTB2.Dock = DockStyle.Fill;
            panelLoaiTB.Controls.Clear();
            panelLoaiTB.Controls.Add(ucTreeLoaiTB2);

            checkedComboBoxEdit_coso.Properties.DataSource = null;
            checkedComboBoxEdit_coso.Properties.DataSource = CoSo.getAll();

            //datetime
            dateEdit_to.EditValue = ServerTimeHelper.getNow();

            gridControlThongKe.DataSource = null;

            //checkPermission
            btnOK.Enabled = /*btnPrint.Enabled =*/ simpleButton_View.Enabled = simpleButton_Design.Enabled = Permission.canDo(Permission._THONGKE_INBAOCAO);

            layout.load(gridViewThongKe);
        }

        public RibbonControl getRibbon()
        {
            return ribbonThongKe;
        }

        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    gridControl1.ShowPrintPreview();
        //}

        private void btnOK_Click(object sender, EventArgs e)
        {
            //get condition
            DateTime? from = (DateTime?)dateEdit_from.EditValue;
            DateTime? to = (DateTime?)dateEdit_to.EditValue;
            if (from != null && to != null && to < from)
            {
                MessageBox.Show("Ngày chọn chưa đúng!");
                dateEdit_to.EditValue = null;
                return;
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
            //get result
            List<Guid> list_coso = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxEdit_coso);
            List<Guid> list_tinhtrang = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxEdit_tinhTrang);
            List<Guid> list_ltb = ucTreeLoaiTB2.getListLoaiTB().Select(x => x.id).ToList();

            List<TKSLThietBiFilter> list_tk = TKSLThietBiFilter.getAll(list_coso, list_ltb, list_tinhtrang, from, to, -1, 1);

            gridControlThongKe.DataSource = list_tk;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        public void reLoad()
        {
            throw new NotImplementedException();
        }

        private DataSet FillDatasetFromGrid()
        {
            DataSet _DataSet = new DataSet();
            //Lay Data Tu GridView
            DataTable _DataTable = new DataTable();
            foreach (GridColumn column in gridViewThongKe.Columns)
            {
                _DataTable.Columns.Add(column.Name + "_" + column.FieldName, column.ColumnType);
                if (!(column.Visible && column.GroupIndex < 0))
                {
                    if (Object.Equals(column.ColumnType, typeof(Int32)))
                    {
                        _DataTable.Columns.Add(column.Name + "_" + column.FieldName + "_STRING", typeof(String));
                    }
                }
            }
            for (int i = 0; i < gridViewThongKe.DataRowCount; i++)
            {
                DataRow row = _DataTable.NewRow();
                foreach (GridColumn column in gridViewThongKe.Columns)
                {
                    row[column.Name + "_" + column.FieldName] = gridViewThongKe.GetRowCellValue(i, column);
                    if (!(column.Visible && column.GroupIndex < 0))
                    {
                        if (Object.Equals(column.ColumnType, typeof(Int32)))
                        {
                            row[column.Name + "_" + column.FieldName + "_STRING"] = gridViewThongKe.GetRowCellValue(i, column);
                        }
                    }
                }
                _DataTable.Rows.Add(row);
            }

            //Lay Data Tu List

            //PropertyDescriptorCollection _PropertyDescriptorCollection =
            //    TypeDescriptor.GetProperties(typeof(TKSLThietBiFilter));
            //DataTable _DataTable = new DataTable();
            //for (int i = 0; i < _PropertyDescriptorCollection.Count; i++)
            //{
            //    PropertyDescriptor prop = _PropertyDescriptorCollection[i];
            //    _DataTable.Columns.Add(prop.Name, prop.PropertyType);
            //}
            //object[] Values = new object[_PropertyDescriptorCollection.Count];
            //foreach (TKSLThietBiFilter item in list_tk)
            //{
            //    for (int i = 0; i < Values.Length; i++)
            //    {
            //        Values[i] = _PropertyDescriptorCollection[i].GetValue(item);
            //    }
            //    _DataTable.Rows.Add(Values);
            //}
            _DataSet.Tables.Add(_DataTable);
            return _DataSet;
        }

        private void simpleButton_View_Click(object sender, EventArgs e)
        {
            //View
            if (comboBoxEdit_Report.SelectedIndex == 0)
            {
                splashScreenManager_Report.ShowWaitForm();
                splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                XtraReport_Template _XtraReport_Template = new XtraReport_Template(FillDatasetFromGrid(), gridViewThongKe, checkEdit_Landscape.Checked);
                ReportPrintTool printTool = new ReportPrintTool(_XtraReport_Template);
                splashScreenManager_Report.CloseWaitForm();
                printTool.ShowPreviewDialog();
                
            }
            else
            {
                splashScreenManager_Report.ShowWaitForm();
                splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                XtraReport_XtraGrid _XtraReport_XtraGrid = new XtraReport_XtraGrid(gridControlThongKe, checkEdit_Landscape.Checked);
                ReportPrintTool printTool = new ReportPrintTool(_XtraReport_XtraGrid);
                splashScreenManager_Report.CloseWaitForm();
                printTool.ShowPreviewDialog();
                
            }
        }

        private void simpleButton_Design_Click(object sender, EventArgs e)
        {
            //design
            if (comboBoxEdit_Report.SelectedIndex == 0)
            {
                splashScreenManager_Report.ShowWaitForm();
                splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                XtraReport_Template _XtraReport_Template = new XtraReport_Template(FillDatasetFromGrid(), gridViewThongKe, checkEdit_Landscape.Checked);
                ReportDesignTool designTool = new ReportDesignTool(_XtraReport_Template);
                splashScreenManager_Report.CloseWaitForm();
                designTool.ShowDesignerDialog();
                

                ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                printTool.ShowPreviewDialog();
            }
            else
            {
                splashScreenManager_Report.ShowWaitForm();
                splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                XtraReport_XtraGrid _XtraReport_XtraGrid = new XtraReport_XtraGrid(gridControlThongKe, checkEdit_Landscape.Checked);
                ReportDesignTool designTool = new ReportDesignTool(_XtraReport_XtraGrid);
                splashScreenManager_Report.CloseWaitForm();
                designTool.ShowDesignerDialog();
                

                ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                printTool.ShowPreviewDialog();
            }
        }

        private void barBtnDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layout.load(gridViewThongKe);
        }

        private void barBtnExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewThongKe.ExpandAllGroups();
        }

        private void barBtnCollapseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewThongKe.CollapseAllGroups();
        }

        private void barBtnThongKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnOK.PerformClick();
        }
    }
}
