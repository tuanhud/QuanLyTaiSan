using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.DataFilter;
using TSCD.Entities;

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmAddTaiSan_DonVi : DevExpress.XtraEditors.XtraForm
    {
        DonVi objDonVi = null;
        public delegate void ReloadAndFocused(Guid id);
        public ReloadAndFocused reloadAndFocused = null;
        frmInputViTri_DonVi frm = new frmInputViTri_DonVi();

        public frmAddTaiSan_DonVi()
        {
            InitializeComponent();
            loadData();
        }

        public frmAddTaiSan_DonVi(DonVi obj)
        {
            InitializeComponent();
            loadData();
            objDonVi = obj;
        }

        private void loadData()
        {
            ucQuanLyTaiSan1.loadData();
            frm.loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CTTaiSan obj = ucQuanLyTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frm.reloadAndFocused = new frmInputViTri_DonVi.ReloadAndFocused(reloadData);
                frm .setData(obj, objDonVi);
                frm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reloadData(Guid _id)
        {
            loadData();
            if (reloadAndFocused != null)
                reloadAndFocused(_id);
        }
    }
}