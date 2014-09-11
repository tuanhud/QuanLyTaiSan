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
using SHARED.Libraries;

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmAddTaiSanExist : DevExpress.XtraEditors.XtraForm
    {
        //ucQuanLyTaiSan
        DonVi objDonVi = null;
        public delegate void ReloadAndFocused(Guid id);
        public ReloadAndFocused reloadAndFocused = null;
        frmInputViTri_DonVi frm = new frmInputViTri_DonVi();

        //ucQuanLyDonVi_TaiSan
        List<CTTaiSan> listCTTaiSan = null;
        bool isTaiSan = false;

        public frmAddTaiSanExist()
        {
            InitializeComponent();
            loadData();
            isTaiSan = true;
        }

        public frmAddTaiSanExist(DonVi obj)
        {
            InitializeComponent();
            loadData();
            objDonVi = obj;
            isTaiSan = true;
        }

        public frmAddTaiSanExist(List<CTTaiSan> list)
        {
            InitializeComponent();
            listCTTaiSan = list;
        }

        private void loadData()
        {
            ucQuanLyTaiSan1.loadData();
            frm.loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CTTaiSan obj = ucQuanLyTaiSan1.CTTaiSan;
                if (obj != null)
                {
                    if (isTaiSan)
                    {
                        frm.reloadAndFocused = new frmInputViTri_DonVi.ReloadAndFocused(reloadData);
                        frm.setData(obj, objDonVi);
                        frm.ShowDialog();
                    }
                    else
                    {
                        listCTTaiSan.Add(obj);
                        if (reloadAndFocused != null)
                            reloadAndFocused(obj.id);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnAdd_Click:" + ex.Message);
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