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
            //ThietBi objThietBi = _ucQuanLyThietBi.getThietBi();
            //if(objThietBi != null)
            //{
            //    frmTinhTrangVaSoLuong frm = new frmTinhTrangVaSoLuong(loaichung);
            //    if(frm.ShowDialog().Equals(DialogResult.OK))
            //    {
            //        CTThietBi obj = new CTThietBi();
            //        obj.phong = objPhong;
            //        obj.thietbi = objThietBi;
            //        obj.tinhtrang = frm.objTinhTrang;
            //        obj.soluong = frm.SoLuong;
            //        //Ngày lắp thiết bị
            //        if (!loaichung)
            //            obj.thietbi.ngaylap = dateEdit1.EditValue == null ? DateTime.Now : dateEdit1.DateTime;
            //        if (obj.add() > 0)
            //        {
            //            XtraMessageBox.Show("Thêm thiết bị vào phòng thành công!");
            //            int id = obj.id;
            //            _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
            //            if (!loaichung)
            //            {
            //                _ucQuanLyThietBi.loadData(loaichung);
            //            }
            //        }
            //    }
            //}
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemVaDong_Click(object sender, EventArgs e)
        {
            ThietBi objThietBi = _ucQuanLyThietBi.getThietBi();
            if (objThietBi != null)
            {
                frmTinhTrangVaSoLuong frm = new frmTinhTrangVaSoLuong(loaichung);
                if (frm.ShowDialog().Equals(DialogResult.OK))
                {
                    CTThietBi obj = new CTThietBi();
                    obj.phong = objPhong;
                    obj.thietbi = objThietBi;
                    obj.tinhtrang = frm.objTinhTrang;
                    obj.soluong = frm.SoLuong;
                    //Ngày lắp thiết bị
                    if (!loaichung)
                        obj.thietbi.ngaylap = dateEdit1.EditValue == null ? DateTime.Now : dateEdit1.DateTime;
                    if (obj.add() > 0)
                    {
                        XtraMessageBox.Show("Thêm thiết bị vào phòng thành công!");
                        int id = obj.id;
                        _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                        if (!loaichung)
                        {
                            _ucQuanLyThietBi.loadData(loaichung);
                        }
                        this.Close();
                    }
                }
                else if (frm.ShowDialog().Equals(DialogResult.Yes))
                {
                    CTThietBi obj = new CTThietBi();
                    obj.phong = objPhong;
                    obj.thietbi = objThietBi;
                    obj.tinhtrang = frm.objTinhTrang;
                    obj.soluong = frm.SoLuong;
                    //Ngày lắp thiết bị
                    if (!loaichung)
                        obj.thietbi.ngaylap = dateEdit1.EditValue == null ? DateTime.Now : dateEdit1.DateTime;
                    if (obj.add() > 0)
                    {
                        XtraMessageBox.Show("Thêm thiết bị vào phòng thành công!");
                        int id = obj.id;
                        _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                        if (!loaichung)
                        {
                            _ucQuanLyThietBi.loadData(loaichung);
                        }
                        this.Close();
                    }
                }
            }
        }

        private void themThietBi()
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
                                        XtraMessageBox.Show("Thêm thiết bị vào phòng thành công!");
                                        int id = objct.id;
                                        _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                                        if (!loaichung)
                                        {
                                            _ucQuanLyThietBi.loadData(loaichung);
                                        }
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
                                        XtraMessageBox.Show("Thêm thiết bị vào phòng thành công!");
                                        int id = objct.id;
                                        _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                                        if (!loaichung)
                                        {
                                            _ucQuanLyThietBi.loadData(loaichung);
                                        }
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
                                XtraMessageBox.Show("Thêm thiết bị vào phòng thành công!");
                                int id = objct.id;
                                _ucQuanLyPhongThietBi.reLoadCTThietBisOnlyAndFocused(id);
                                if (!loaichung)
                                {
                                    _ucQuanLyThietBi.loadData(loaichung);
                                }
                            }
                        }
                    }
                }
            }
            yestoall = false;
        }
    }
}