using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;

namespace TSCD_GUI.ReportTSCD
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        List<DonVi> ListDonVi = new List<DonVi>();

        public frmReport()
        {
            InitializeComponent();

            DonVi objNULL = new DonVi();
            ListDonVi = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
            objNULL.id = Guid.Empty;
            objNULL.ten = "[Không có đơn vị]";
            objNULL.parent = null;
            ListDonVi.Insert(0, objNULL);
            ucComboBoxDonVi_ChonDonVi.DataSource = ListDonVi;
            ucComboBoxDonVi_ChonDonVi.DonVi = objNULL;

            dateEdit_TuNgay.EditValue = DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = DateTime.Today.Date;
        }

        private void comboBoxEdit_LoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit_LoaiBaoCao.SelectedIndex >= 2)
            {
                ucComboBoxDonVi_ChonDonVi.ReadOnly = false;
            }
            else
            {
                ucComboBoxDonVi_ChonDonVi.ReadOnly = true;
            }
        }

        private void simpleButton_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton_Xuat_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Chức năng này chưa có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}