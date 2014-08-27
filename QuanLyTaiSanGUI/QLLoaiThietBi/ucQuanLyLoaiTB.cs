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
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Localization;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Libraries;

namespace QuanLyTaiSanGUI.QLLoaiThietBi
{
    public partial class ucQuanLyLoaiTB : UserControl,_ourUcInterface
    {
        List<LoaiTBHienThi> loaiThietBis = new List<LoaiTBHienThi>();
        List<LoaiThietBi> listLoaiThietBiCha = new List<LoaiThietBi>();
        List<LoaiThietBi> loaiThietBiParents = new List<LoaiThietBi>();
        List<HinhAnh> listHinhs = new List<HinhAnh>();
        string function = "";
        LoaiThietBi objLoaiThietBi = null;
        LoaiThietBi loaiThietBiNULL = new LoaiThietBi();
        bool working = false;
        Point pointLabelTen, pointTxtTen, pointLabelMota, pointTxtMota, pointLabelLoai, pointPanelLoai, pointBtnOk, pointBtnHuy;
        int khoangcach;

        public ucQuanLyLoaiTB()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            ribbonLoaiTB.Parent = null;
            loaiThietBiNULL.ten = "[Không thuộc loại nào]";
            loaiThietBiNULL.id = Guid.Empty;
            loaiThietBiNULL.parent = null;
            khoangcach = Math.Abs(imageSliderLoaiTB.Location.Y - txtTen.Location.Y);
            pointLabelTen = labelControlTen.Location;
            pointTxtTen = txtTen.Location;
            pointLabelMota = labelControlMota.Location;
            pointTxtMota = txtMoTa.Location;
            pointLabelLoai = labelControlLoai.Location;
            pointPanelLoai = panelControlLoai.Location;
            pointBtnOk = btnOk.Location;
            pointBtnHuy = btnHuy.Location;
        }

        private void treeListLoaiTB_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (treeListLoaiTB.GetDataRecordByNode(e.Node) != null)
                {
                    enableEdit(false, "");
                    SetTextGroupControl("Chi tiết", Color.Black);
                    //objLoaiThietBi = (LoaiThietBi)treeListLoaiTB.GetDataRecordByNode(e.Node);
                    objLoaiThietBi = LoaiThietBi.getById(GUID.From(e.Node.GetValue(colid)));
                    setData();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : treeListLoaiTB_FocusedNodeChanged : " + ex.Message);
            }
            finally
            { }
        }

        public void enableEdit(bool _enable, String _function)
        {
            function = _function;
            btnOk.Visible = _enable;
            btnHuy.Visible = _enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtMoTa.Properties.ReadOnly = !_enable;
            lueThuoc.Properties.ReadOnly = !_enable;
            ceTBsoluonglon.Properties.ReadOnly = !_enable;
            working = _enable;
            //
            rbnGroupLoaiTB.Enabled = !_enable;
            rbnGroupOrder.Enabled = !_enable;
            btnR_Them.Enabled = !_enable;
            btnR_Sua.Enabled = !_enable;
            btnR_Xoa.Enabled = !_enable;
            btnImage.Visible = _enable && ceTBsoluonglon.Checked;
            if (_enable)
                txtTen.Focus();
        }

        public void reLoad()
        {
            try
            {
                enableEdit(false, "");
                loaiThietBis = LoaiTBHienThi.getAll();
                treeListLoaiTB.DataSource = loaiThietBis;
                listLoaiThietBiCha = LoaiThietBi.getAllParent().OrderBy(l => l.order).ToList();
                listLoaiThietBiCha.Insert(0, loaiThietBiNULL);
                lueThuoc.Properties.DataSource = listLoaiThietBiCha;
                checkSuaXoa();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : reLoad : " + ex.Message);
            }
            finally
            { }
        }

        private void reLoadAndFocused(Guid _id)
        {
            try
            {
                reLoad();
                TreeListNode node = treeListLoaiTB.FindNodeByKeyID(_id);
                if (node != null)
                {
                    node.Selected = true;
                    node.Expanded = true;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : reLoadAndFocused : " + ex.Message);
            }
        }

        public void beforeAdd()
        {
            errorProvider1.Clear();
            listHinhs = new List<HinhAnh>();
            imageSliderLoaiTB.Images.Clear();
            txtTen.Text = "";
            txtMoTa.Text = "";
            lueThuoc.EditValue = loaiThietBiNULL.id;
            ceTBsoluonglon.Checked = false;
        }

        public void setData()
        {
            try
            {
                listHinhs = new List<HinhAnh>();
                if (loaiThietBis.Count > 0)
                {
                    errorProvider1.Clear();
                    txtTen.Text = objLoaiThietBi.ten;
                    txtMoTa.Text = objLoaiThietBi.mota;
                    if (objLoaiThietBi.parent_id == null)
                        lueThuoc.EditValue = loaiThietBiNULL.id;
                    else
                        lueThuoc.EditValue = objLoaiThietBi.parent_id;
                    //editGUI
                    editGuiforShowImage(objLoaiThietBi.loaichung);
                    ceTBsoluonglon.Checked = objLoaiThietBi.loaichung;
                    if (objLoaiThietBi.loaichung)
                    {
                        if (objLoaiThietBi.thietbis.Count > 0 && objLoaiThietBi.thietbis.FirstOrDefault().hinhanhs.Count > 0)
                            listHinhs = objLoaiThietBi.thietbis.FirstOrDefault().hinhanhs.ToList();
                        reloadImage();
                    }
                    if (objLoaiThietBi.thietbis.Count > 0 || checkLoaiThietBiConCoThietBiKhong(objLoaiThietBi))
                        ceTBsoluonglon.Properties.ReadOnly = true;
                }
                else
                    beforeAdd();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : setData : " + ex.Message);
            }
            finally
            { }
        }

        private void CRU()
        {
            try
            {
                switch (function)
                {
                    case "add":
                        objLoaiThietBi = new LoaiThietBi();
                        setDataObj();
                        if (objLoaiThietBi.add() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Thêm loại thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Guid id = objLoaiThietBi.id;
                            reLoadAndFocused(id);
                        }
                        else
                        {
                            XtraMessageBox.Show("Đã có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            reLoad();
                        }
                        break;
                    case "edit":
                        setDataObj();
                        if (objLoaiThietBi.update() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Sửa loại thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Guid id = objLoaiThietBi.id;
                            reLoadAndFocused(id);
                        }
                        else
                        {
                            XtraMessageBox.Show("Đã có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            reLoad();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : CRU : " + ex.Message);
            }
            finally
            { }
        }

        public void deleteObj()
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc là muốn xóa loại thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool check = true;
                    Guid id = Guid.Empty;
                    if (objLoaiThietBi.parent_id != null)
                    {
                        id = QuanLyTaiSan.Libraries.GUID.From(objLoaiThietBi.parent_id);
                    }
                    if (objLoaiThietBi.loaichung)
                    {
                        if (objLoaiThietBi.thietbis.Count > 0)
                        {
                            foreach (ThietBi obj in objLoaiThietBi.thietbis.ToList())
                            {
                                if (obj.delete() <= 0)
                                {
                                    check = false;
                                    XtraMessageBox.Show("Không thể xóa loại thiết bị này!\r\nNguyên do: Loại thiết bị này có chứa các thiết bị hoặc loại thiết bị con", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //reLoad();
                                    break;
                                }
                            }
                        }
                    }
                    if (check)
                    {
                        if (objLoaiThietBi.delete() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Xóa loại thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (id != Guid.Empty)
                                reLoadAndFocused(id);
                            else
                                reLoad();
                        }
                        else
                        {
                            XtraMessageBox.Show("Không thể xóa loại thiết bị này!\r\nNguyên do: Loại thiết bị này có chứa các thiết bị hoặc loại thiết bị con", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //reLoad();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "=>deleteObj: " + ex.Message);
            }
        }

        private Boolean checkLoaiThietBiConCoThietBiKhong(LoaiThietBi parent)
        {
            foreach (LoaiThietBi loaiThietBiCon in parent.childs)
            {
                if (loaiThietBiCon.thietbis.Count > 0)
                    return true;
            }
            return false;
        }

        private void setDataObj()
        {
            try
            {
                objLoaiThietBi.ten = txtTen.Text;
                objLoaiThietBi.mota = txtMoTa.Text;
                if (ceTBsoluonglon.Checked)
                {
                    if (objLoaiThietBi.thietbis.Count == 0)
                    {
                        ThietBi obj = new ThietBi();
                        obj.ten = txtTen.Text;
                        obj.mota = txtMoTa.Text;
                        obj.hinhanhs = listHinhs;
                        objLoaiThietBi.thietbis.Add(obj);
                    }
                    else
                    {
                        ThietBi obj = objLoaiThietBi.thietbis.FirstOrDefault();
                        obj.ten = txtTen.Text;
                        obj.mota = txtMoTa.Text;
                        obj.hinhanhs = listHinhs;
                    }
                }
                LoaiThietBi parentLoaiThietBi = (LoaiThietBi)lueThuoc.GetSelectedDataRow();
                if (parentLoaiThietBi.id != Guid.Empty)
                    objLoaiThietBi.parent = LoaiThietBi.getById(parentLoaiThietBi.id);
                else
                {
                    if (function.Equals("edit"))
                    {
                        objLoaiThietBi.parent_id = null;
                    }
                }
                if (ceTBsoluonglon.Checked)
                    objLoaiThietBi.loaichung = true;
                else
                    objLoaiThietBi.loaichung = false;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + " : setDataObj : " + ex.Message);
            }
            finally
            { }
        }

        public void SetTextGroupControl(String text, Color color)
        {
            groupControl1.Text = text;
            groupControl1.AppearanceCaption.ForeColor = color;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetTextGroupControl("Chi tiết", Color.Black);
            lueThuoc.Properties.DataSource = listLoaiThietBiCha;
            setData();
            enableEdit(false, "");
            if (loaiThietBis.Count == 0)
            {
                btnR_Sua.Enabled = false;
                btnR_Xoa.Enabled = false;
            }
            errorProvider1.Clear();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                CRU();
                enableEdit(false, "");
            }
        }

        public void addThietBiChaKhiEdit()
        {
            if (objLoaiThietBi.id != Guid.Empty)
            {
                if (objLoaiThietBi.childs.Count > 0)
                {
                    lueThuoc.EditValue = loaiThietBiNULL.id;
                    lueThuoc.Properties.ReadOnly = true;
                }
                else
                {
                    loaiThietBiParents = new List<LoaiThietBi>(listLoaiThietBiCha);
                    loaiThietBiParents.Remove(objLoaiThietBi);
                    lueThuoc.Properties.DataSource = loaiThietBiParents;
                }
            }
        }

        private Boolean checkInput()
        {
            Boolean check = true;
            errorProvider1.Clear();
            if (txtTen.Text.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtTen, "Chưa điền tên thiết bị");
            }
            else
            {
                if (function.Equals("add"))
                {
                    if (loaiThietBis.Where(c => c.ten.ToUpper().Equals(txtTen.Text.ToUpper())).Count() > 0)
                    {
                        check = false;
                        errorProvider1.SetError(txtTen, "Tên loại thiết bị này đã tồn tại");
                    }
                }
                else if (function.Equals("edit"))
                {
                    if (!objLoaiThietBi.ten.ToUpper().Equals(txtTen.Text.ToUpper()) && loaiThietBis.Where(c => c.ten.ToUpper().Equals(txtTen.Text.ToUpper())).Count() > 0)
                    {
                        check = false;
                        errorProvider1.SetError(txtTen, "Tên loại thiết bị này đã tồn tại");
                    }
                }
            }
            LoaiThietBi cha = (LoaiThietBi)lueThuoc.GetSelectedDataRow();
            if (cha.id != Guid.Empty)
            {
                if (cha.loaichung)
                {
                    if (!ceTBsoluonglon.Checked)
                    {
                        check = false;
                        errorProvider1.SetError(ceTBsoluonglon, "Thiết bị cha được quản lí theo số lượng lớn, thiết bị con cũng phải thế");
                    }
                }
                else
                {
                    if (ceTBsoluonglon.Checked)
                    {
                        check = false;
                        errorProvider1.SetError(ceTBsoluonglon, "Thiết bị cha được quản lí theo đơn lẻ, thiết bị con cũng phải thế");
                    }
                }
            }
            else
            {
                if (function.Equals("edit"))
                {
                    if (objLoaiThietBi.childs.Count > 0)
                    {
                        LoaiThietBi con = objLoaiThietBi.childs.ElementAt(0);
                        if (con.loaichung)
                        {
                            if (!ceTBsoluonglon.Checked)
                            {
                                check = false;
                                errorProvider1.SetError(ceTBsoluonglon, "Các thiết bị con được quản lí theo số lượng lớn, thiết bị cha cũng phải thế");
                            }
                        }
                        else
                        {
                            if (ceTBsoluonglon.Checked)
                            {
                                check = false;
                                errorProvider1.SetError(ceTBsoluonglon, "Các thiết bị con được quản lí theo đơn lẻ, thiết bị cha cũng phải thế");
                            }
                        }
                    }
                }
            }
            return check;
        }

        private void checkSuaXoa()
        {
            if (loaiThietBis.Count == 0)
            {
                beforeAdd();
                enableSuaXoa(false);
            }
            else
            {
                enableSuaXoa(true);
            }
        }

        private void barButtonThemLoaiTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "add");
            SetTextGroupControl("Thêm loại thiết bị", Color.Red);
            beforeAdd();
            if (objLoaiThietBi != null)
            {
                if (objLoaiThietBi.parent != null)
                {
                    lueThuoc.EditValue = objLoaiThietBi.parent_id;
                }
            }
        }

        private void barButtonSuaLoaiTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "edit");
            SetTextGroupControl("Sửa loại thiết bị", Color.Red);
            addThietBiChaKhiEdit();
            setData();
        }

        private void barButtonXoaLoaiTB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        public void enableSuaXoa(Boolean enable)
        {
            barButtonSuaLoaiTB.Enabled = enable;
            barButtonXoaLoaiTB.Enabled = enable;
            rbnGroupOrder.Enabled = enable;
            btnR_Sua.Enabled = enable;
            btnR_Xoa.Enabled = enable;
        }

        public RibbonControl getRibbon()
        {
            return ribbonLoaiTB;
        }

        private void OnFilterNode(object sender, FilterNodeEventArgs e)
        {
            List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>(
                ).ToList();
            if (filteredColumns.Count == 0) return;
            if (string.IsNullOrEmpty(treeListLoaiTB.FindFilterText)) return;
            e.Handled = true;
            e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
            e.Node.Expanded = e.Node.Visible;
        }

        bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
        {
            string filterValue = treeListLoaiTB.FindFilterText;
            if (node.GetDisplayText(column).ToUpper().Contains(filterValue.ToUpper())) return true;
            foreach (TreeListNode n in node.Nodes)
                if (IsNodeMatchFilter(n, column)) return true;
            return false;
        }

        private void btnR_Them_Click(object sender, EventArgs e)
        {
            enableEdit(true, "add");
            SetTextGroupControl("Thêm loại thiết bị", Color.Red);
            beforeAdd();
            if (objLoaiThietBi != null)
            {
                if (objLoaiThietBi.parent != null)
                {
                    lueThuoc.EditValue = objLoaiThietBi.parent_id;
                }
            }
        }

        private void btnR_Sua_Click(object sender, EventArgs e)
        {
            enableEdit(true, "edit");
            SetTextGroupControl("Sửa loại thiết bị", Color.Red);
            addThietBiChaKhiEdit();
            setData();
        }

        private void btnR_Xoa_Click(object sender, EventArgs e)
        {
            deleteObj();
        }

        public bool checkworking()
        {
            try
            {
                if (function.Equals("edit"))
                {
                    if (lueThuoc.EditValue != null && Convert.ToInt32(lueThuoc.EditValue) > -1)
                        return
                            objLoaiThietBi.ten != txtTen.Text||
                            objLoaiThietBi.mota != txtMoTa.Text||
                            objLoaiThietBi.parent_id != GUID.From(lueThuoc.EditValue);
                    else
                        return
                            objLoaiThietBi.ten != txtTen.Text ||
                            objLoaiThietBi.mota != txtMoTa.Text ||
                            objLoaiThietBi.parent_id != null;
                }
                else if (function.Equals("add"))
                {
                    return
                        !txtTen.Text.Equals("") ||
                        !txtMoTa.Text.Equals("");
                }
                else
                {
                    return working;
                }  
            }
            catch(Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkworking: " + ex.Message);
                return true;
            }
        }

        private void barBtnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Excel Files(*.xls,*.xlsx)|*.xls;*.xlsx";
            open.Title = "Chọn tập tin để Import";
            if (open.ShowDialog() == DialogResult.OK)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm1), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import...");
                if (QuanLyTaiSanGUI.Libraries.ExcelDataBaseHelper.ImportLoaiThietBi(open.FileName, "LoaiThietBi"))
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import thành công!");
                    reLoad();
                }
                else
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import không thành công!");
                    reLoad();
                }

            }
        }

        private void barBtnUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (objLoaiThietBi != null && objLoaiThietBi.id != Guid.Empty)
                {
                    objLoaiThietBi.moveUp();
                    DBInstance.commit();
                    reLoadAndFocused(objLoaiThietBi.id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->barBtnUp_ItemClick: " + ex.Message);
            }
        }

        private void barBtnDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (objLoaiThietBi != null && objLoaiThietBi.id != Guid.Empty)
                {
                    objLoaiThietBi.moveDown();
                    DBInstance.commit();
                    reLoadAndFocused(objLoaiThietBi.id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->barBtnUp_ItemClick: " + ex.Message);
            }
        }

        private void editGuiforShowImage(bool _enable)
        {
            labelControlHinh.Visible = _enable;
            imageSliderLoaiTB.Visible = _enable;
            btnImage.Visible = _enable && !function.Equals("");
            if (_enable)
            {
                labelControlTen.Location = pointLabelTen;
                txtTen.Location = pointTxtTen;
                labelControlMota.Location = pointLabelMota;
                txtMoTa.Location = pointTxtMota;
                labelControlLoai.Location = pointLabelLoai;
                panelControlLoai.Location = pointPanelLoai;
                btnOk.Location = pointBtnOk;
                btnHuy.Location = pointBtnHuy;
            }
            else
            {
                labelControlTen.Location = labelControlHinh.Location;
                txtTen.Location = imageSliderLoaiTB.Location;
                labelControlMota.Location = new Point(pointLabelMota.X, pointLabelMota.Y - khoangcach);
                txtMoTa.Location = new Point(pointTxtMota.X, pointTxtMota.Y - khoangcach);
                labelControlLoai.Location = new Point(pointLabelLoai.X, pointLabelLoai.Y - khoangcach);
                panelControlLoai.Location = new Point(pointPanelLoai.X, pointPanelLoai.Y - khoangcach);
                btnOk.Location = new Point(pointBtnOk.X, pointBtnOk.Y - khoangcach);
                btnHuy.Location = new Point(pointBtnHuy.X, pointBtnHuy.Y - khoangcach);
            }
        }

        private void ceTBsoluonglon_CheckedChanged(object sender, EventArgs e)
        {
            editGuiforShowImage(ceTBsoluonglon.Checked);
        }

        private void reloadImage()
        {
            try
            {
                imageSliderLoaiTB.Images.Clear();
                if (listHinhs != null)
                {
                    foreach (HinhAnh h in listHinhs)
                    {
                        imageSliderLoaiTB.Images.Add(h.getImage());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadImage: " + ex.Message);
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                frmHinhAnh frm = new frmHinhAnh(listHinhs);
                if (function.Equals("edit"))
                {
                    frm.Text = "Quản lý hình ảnh " + objLoaiThietBi.ten;

                }
                else
                {
                    frm.Text = "Quản lý hình ảnh loại thiết bị mới";
                }
                frm.ShowDialog();
                listHinhs = frm.getlistHinhs();
                reloadImage();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnImage_Click: " + ex.Message);
            }
        }
    }
}
