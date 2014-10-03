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
        CTTaiSan objCTTaiSan = null;
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

        public frmAddTaiSanExist(List<CTTaiSan> list, CTTaiSan obj)
        {
            InitializeComponent();
            loadData();
            listCTTaiSan = list;
            objCTTaiSan = obj;
        }

        private void loadData()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
            ucQuanLyTaiSan1.loadData();
            if(!isTaiSan)
                frm.loadData();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
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
                        if (obj.donviquanly == null || obj.donvisudung == null)
                        {
                            frm.reloadAndFocused = new frmInputViTri_DonVi.ReloadAndFocused(reloadData);
                            frm.setData(obj, objDonVi);
                            frm.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("Tài sản này có đơn vị quản lý hoặc sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (objCTTaiSan != null && obj.id.Equals(objCTTaiSan.id))
                            XtraMessageBox.Show("Tài sản không thể kèm theo chính mình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (obj.parent != null)
                            {
                                if (XtraMessageBox.Show("Tài sản này đã được kèm theo một tài sản khác, bạn có chắc chắn muốn tiếp tục?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    listCTTaiSan.Add(obj);
                                    if (reloadAndFocused != null)
                                        reloadAndFocused(obj.id);
                                    this.Close();
                                }
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