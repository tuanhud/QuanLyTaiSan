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
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.Libraries;
using DevExpress.XtraBars.Ribbon;
using QuanLyTaiSan.Libraries;
using SHARED.Libraries;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Columns;

namespace QuanLyTaiSanGUI.ThongKe
{
    public partial class ucTK_SLTB_TheoTinhTrang : DevExpress.XtraEditors.XtraUserControl, _ourUcInterface
    {
        QuanLyTaiSanGUI.MyUC.ucTreeLoaiTB ucTreeLoaiTB2 = new MyUC.ucTreeLoaiTB(true);
        List<TKSLThietBiFilter> list_tk = new List<TKSLThietBiFilter>();

        public ucTK_SLTB_TheoTinhTrang()
        {
            InitializeComponent();
            ribbonThongKe.Parent = null;
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

            gridControl1.DataSource = null;
        }

        public RibbonControl getRibbon()
        {
            return ribbonThongKe;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

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

            list_tk = TKSLThietBiFilter.getAll(list_coso, list_ltb, list_tinhtrang, from, to, -1, 1);

            gridControl1.DataSource = list_tk;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        public void reLoad()
        {
            throw new NotImplementedException();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //View
            XtraReport_Template _XtraReport_Template = new XtraReport_Template(FillDatasetFromGrid(), gridView1, true);
            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_Template);
            printTool.ShowPreviewDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //design
            XtraReport_Template _XtraReport_Template = new XtraReport_Template(FillDatasetFromGrid(), gridView1, true);
            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_Template);
            designTool.ShowDesignerDialog();
            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
            printTool.ShowPreviewDialog();
        }

        private DataSet FillDatasetFromGrid()
        {
            DataSet _DataSet = new DataSet();
            //Lay Data Tu GridView
            DataTable _DataTable = new DataTable();
            foreach (GridColumn column in gridView1.Columns)
            {
                _DataTable.Columns.Add(column.FieldName, column.ColumnType);
            }
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                DataRow row = _DataTable.NewRow();
                foreach (GridColumn column in gridView1.Columns)
                {
                    row[column.FieldName] = gridView1.GetRowCellValue(i, column);
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
    }
}
