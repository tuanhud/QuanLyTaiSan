using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyTaiSanGUI.QLThietBi;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.MyUserControl;

namespace QuanLyTaiSanGUI.QLPhong.MyForm
{
    public partial class frmAddThietBi : QuanLyTaiSanGUI.MyForm.frmCustomXtraForm
    {
        ucQuanLyThietBi _ucQuanLyThietBi = new ucQuanLyThietBi(true);
        public ucQuanLyPhongThietBi _ucQuanLyPhongThietBi = null;
        Phong objPhong = new Phong();
        bool loaichung = true;
        bool yestoall = false;
        string text = "";

        public frmAddThietBi()
        {
            InitializeComponent();
        }

        public frmAddThietBi(Phong obj, bool _loaichung)
        {
            InitializeComponent();
            loaichung = _loaichung;
            _ucQuanLyThietBi.Dock = DockStyle.Fill;
            _ucQuanLyThietBi.loadData(loaichung);
            panelControl1.Controls.Add(_ucQuanLyThietBi);
            objPhong = obj;
            dateEdit1.DateTime = DateTime.Now;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themThietBi();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnThemVaDong_Click(object sender, EventArgs e)
        {
            themThietBi();
            this.Close();
            this.Dispose();
        }

        private void themThietBi()
        {
            bool show = true;
            bool open = false;
            int id = -1;
            try
            {
                TinhTrang objTinhTrang = new TinhTrang();
                int SoLuong = -1;
                String GhiChu = "";
                List<ThietBi> list = new List<ThietBi>();
                list = _ucQuanLyThietBi.getListThietBi();
                if (list != null && list.Count > 0)
                {
                    foreach (ThietBi obj in list)
                    {
                        if (obj != null)
                        {
                            if (!yestoall)
                            {
                                frmTinhTrangVaSoLuong frm = new frmTinhTrangVaSoLuong(loaichung);
                                frm.Text += " " + obj.ten;
                                switch (frm.ShowDialog())
                                {
                                    case DialogResult.OK:
                                        text = "";
                                        id = AddObj(obj, frm.objTinhTrang, frm.SoLuong, frm.GhiChu);
                                        showToolTip(text);
                                        if (id > 0)
                                            _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                                        break;
                                    case DialogResult.Yes:
                                        yestoall = true;
                                        show = true;
                                        text = "";
                                        objTinhTrang = frm.objTinhTrang;
                                        SoLuong = frm.SoLuong;
                                        GhiChu = frm.GhiChu;
                                        int id2 = AddObj(obj, objTinhTrang, SoLuong, GhiChu);
                                        id = id2 > 0 ? id2 : id;
                                        //if (id > 0)
                                        //    _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                                        break;
                                }
                            }
                            else
                            {
                                if (show)
                                {
                                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                                    DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                                    open = true;
                                    show = false;
                                }
                                int id2 = AddObj(obj, objTinhTrang, SoLuong, GhiChu);
                                id = id2 > 0 ? id2 : id;
                                //if (id > 0)
                                //    _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                            }
                        }
                    }
                    if(yestoall)
                        _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                    _ucQuanLyThietBi.loadData(loaichung);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->themThietBi: " + ex.Message);
                XtraMessageBox.Show("Lỗi khi thêm thiết bị vào phòng!");
            }
            finally
            {
                if (open)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                }
                if (yestoall)
                {
                    showToolTip(text);
                    yestoall = false;
                }
            }
        }

        private int AddObj(ThietBi objThietBi, TinhTrang objTinhTrang, int SoLuong, String GhiChu)
        {
            try
            {
                CTThietBi obj = new CTThietBi();
                obj.phong = objPhong;
                obj.thietbi = objThietBi;
                obj.tinhtrang = objTinhTrang;
                obj.soluong = SoLuong;
                obj.mota = GhiChu;
                obj.ngay = dateEdit1.EditValue == null ? DateTime.Now : dateEdit1.DateTime;
                if (obj.add() > 0 && DBInstance.commit() > 0)
                {
                    text += "Thêm thiết bị " + objThietBi.ten + " vào phòng thành công!" + Environment.NewLine;
                    return obj.id;
                }
                else
                    text += "Thêm thiết bị " + objThietBi.ten + " vào phòng không thành công!" + Environment.NewLine;
                    return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->AddObj: " + ex.Message);
                return -1;
            }
        }

        private void showToolTip(String str)
        {
            try
            {
                toolTipController1.HideHint();
                DevExpress.Utils.ToolTipControllerShowEventArgs args = new DevExpress.Utils.ToolTipControllerShowEventArgs();
                DevExpress.Utils.SuperToolTip tip = new DevExpress.Utils.SuperToolTip();
                //setup the SuperToolTip...
                DevExpress.Utils.ToolTipTitleItem titleItem1 = new DevExpress.Utils.ToolTipTitleItem();
                titleItem1.Text = "Thông báo";
                // Create a tooltip item that represents the SuperTooltip's contents.
                DevExpress.Utils.ToolTipItem item1 = new DevExpress.Utils.ToolTipItem();
                item1.Text = str;
                // Add the tooltip items to the SuperTooltip.
                tip.Items.Add(titleItem1);
                tip.Items.Add(item1);
                args.SuperTip = tip;
                args.IconType = DevExpress.Utils.ToolTipIconType.Information;
                args.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
                args.ToolTipLocation = DevExpress.Utils.ToolTipLocation.BottomCenter;
                Point p = new Point((this.Location.X + this.Size.Width / 2), this.Location.Y + this.Size.Height / 2);
                toolTipController1.ShowHint(args, p);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->showToolTip: " + ex.Message);
            }
        }
    }
}