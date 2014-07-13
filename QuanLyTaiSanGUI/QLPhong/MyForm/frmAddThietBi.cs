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
    public partial class frmAddThietBi : DevExpress.XtraEditors.XtraForm
    {
        ucQuanLyThietBi _ucQuanLyThietBi = new ucQuanLyThietBi(true);
        public ucQuanLyPhongThietBi _ucQuanLyPhongThietBi = null;
        Phong objPhong = new Phong();
        bool loaichung = true;
        bool yestoall = false;

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
            int sl = 0;
            string str = "";
            try
            {
                TinhTrang objTinhTrang = new TinhTrang();
                int SoLuong = -1;
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
                                CTThietBi objct = new CTThietBi();
                                switch (frm.ShowDialog())
                                {
                                    case DialogResult.OK:
                                        objct.phong = objPhong;
                                        objct.thietbi = obj;
                                        objct.tinhtrang = frm.objTinhTrang;
                                        objct.soluong = frm.SoLuong;
                                        //Ngày lắp thiết bị
                                        if (!loaichung)
                                            objct.thietbi.ngaylap = dateEdit1.EditValue == null ? DateTime.Now : dateEdit1.DateTime;
                                        if (objct.add() > 0)
                                        {
                                            //XtraMessageBox.Show("Thêm thiết bị " + obj.ten + " vào phòng thành công!");

                                            showToolTip("Thêm thiết bị " + obj.ten + " vào phòng thành công!");
                                            int id = objct.id;
                                            _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                                            sl++;
                                        }
                                        break;
                                    case DialogResult.Yes:
                                        objTinhTrang = frm.objTinhTrang;
                                        SoLuong = frm.SoLuong;
                                        yestoall = true;
                                        objct.phong = objPhong;
                                        objct.thietbi = obj;
                                        objct.tinhtrang = frm.objTinhTrang;
                                        objct.soluong = frm.SoLuong;
                                        //Ngày lắp thiết bị
                                        if (!loaichung)
                                            objct.thietbi.ngaylap = dateEdit1.EditValue == null ? DateTime.Now : dateEdit1.DateTime;
                                        if (objct.add() > 0)
                                        {
                                            if (!yestoall)
                                                showToolTip("Thêm thiết bị " + obj.ten + " vào phòng thành công!");
                                            else
                                            {
                                                str += "Thêm thiết bị " + obj.ten + " vào phòng thành công!" + Environment.NewLine;
                                            }
                                            int id = objct.id;
                                            _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                                            sl++;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                CTThietBi objct = new CTThietBi();
                                objct.phong = objPhong;
                                objct.thietbi = obj;
                                objct.tinhtrang = objTinhTrang;
                                objct.soluong = SoLuong;
                                //Ngày lắp thiết bị
                                if (!loaichung)
                                    objct.thietbi.ngaylap = dateEdit1.EditValue == null ? DateTime.Now : dateEdit1.DateTime;
                                if (objct.add() > 0)
                                {
                                    str += "Thêm thiết bị " + obj.ten + " vào phòng thành công!" + Environment.NewLine;
                                    int id = objct.id;
                                    _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                                    sl++;
                                }
                            }
                        }
                    }
                }
                _ucQuanLyThietBi.loadData(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi thêm thiết bị vào phòng!");
            }
            finally
            {
                if (yestoall)
                {
                    showToolTip(str);
                    yestoall = false;
                }
            }
        }

        private void showToolTip(String str)
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
            args.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            args.ToolTipLocation = DevExpress.Utils.ToolTipLocation.TopCenter;
            toolTipController1.ShowHint(args, btnThemVaDong);
        }
    }
}