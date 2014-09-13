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
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSanGUI.MyForm;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class frmSuaPermission : frmCustomXtraForm
    {
        private List<Permission> input = null;
        public frmSuaPermission()
        {
            InitializeComponent();

            input = new List<Permission>();
        }
        public frmSuaPermission(List<Permission> input)
        {
            InitializeComponent();

            this.input = input;
        }

        private void frmSuaPermission_Load(object sender, EventArgs e)
        {
            //Load ds hạng mục
            listBoxControl_quyenHangMuc.DataSource = Permission.ENTITY_LIST;

            //load ds quyền cố định
            listBoxControl_quyenCoDinh.DataSource = Permission.STAND_ALONE_LIST;

            //load ds quyền hiện có
            gridControl_DSQuyen.DataSource = input;

            //load ds coso
            gridControl_CoSo.DataSource = CoSo.getAll();

            //load ds day
            gridControl_Day.DataSource = DayyFilter.getAll();

            //load ds tang
            gridControl_Tang.DataSource = TangFilter.getAll();

            //load ds phong
            gridControl_Phong.DataSource = PhongFilter2.getAll();
            gridView_Phong.ExpandAllGroups();
        }
        /// <summary>
        /// Lấy ds quyền sau khi chỉnh sửa
        /// </summary>
        /// <returns></returns>
        public List<Permission> getResult()
        {
            return input;
        }

        private void btnThemQuyenCoDinh_Click(object sender, EventArgs e)
        {
            String key = (string)listBoxControl_quyenCoDinh.SelectedValue;
            Permission tmp = Permission.request(key);
            //xét đã có trong list hiện tại
            if (input.Where(c => c.key.ToUpper().Equals(tmp.key.ToUpper())).FirstOrDefault() != null)
            {
                //đã có
                MessageBox.Show("Đã có trong danh sách hiện tại");
                return;
            }
            else
            {
                //chưa có
                input.Add(tmp);
                //reload
                reloadDSQuyen();
            }
        }
        private void reloadDSQuyen()
        {
            gridControl_DSQuyen.DataSource = null;
            gridControl_DSQuyen.DataSource = input;
        }

        private void btn_XoaQuyen_Click(object sender, EventArgs e)
        {
            Permission tmp = (Permission)gridView_DSQuyen.GetFocusedRow();
            Boolean re = input.Remove(tmp);
            //reload
            reloadDSQuyen();
        }

        private void btnThemQuyenCoSo_Click(object sender, EventArgs e)
        {
            //Nếu trong ds hiện tại có quyền cấu hình y chang
            Permission tmp = input.Where(
                c =>
                    c.key.ToUpper().Equals(CoSo.USNAME)
                    &&
                    c.stand_alone == false
                    &&
                    c.recursive_to_child == checkEdit_quyenBaoHam.Checked
                    &&
                    c.allow_or_deny == !checkEdit_quyenDeny.Checked
                    &&
                    c.can_edit == checkEdit_quyenSua.Checked
                    &&
                    c.can_delete == checkEdit_quyenXoa.Checked
                    &&
                    c.can_view == checkEdit_quyenXem.Checked
            ).FirstOrDefault();
            CoSo dangChon = gridView_CoSo.GetFocusedRow() as CoSo;
            if (dangChon == null)
            {
                return;
            }

            if (tmp == null)
            {
                tmp = Permission.request(false, CoSo.USNAME, !checkEdit_quyenDeny.Checked, checkEdit_quyenBaoHam.Checked, checkEdit_quyenXem.Checked, checkEdit_quyenSua.Checked, checkEdit_quyenXoa.Checked);
                
                //add object list to tmp
                tmp.cosos.Add(dangChon);
                //add to input
                input.Add(tmp);
                //reload
                reloadDSQuyen();
            }
            else
            {
                //Nếu CS chưa có trong ds thì mới add
                if (!tmp.cosos.Contains(dangChon))
                {
                    //add object list to tmp
                    tmp.cosos.Add(dangChon);

                    //reload
                    reloadDSQuyen();
                }
            }
        }
        //private Permission getPermissionConfig()
        //{

        //}
        private void checkEdit_quyenFull_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemQuyenHangMuc_Click(object sender, EventArgs e)
        {
            if(listBoxControl_quyenHangMuc.SelectedValue==null)
            {
                return;
            }
            String hangmuc = listBoxControl_quyenHangMuc.SelectedValue.ToString().ToUpper();
            //kiểm tra có trong ds đã có
            Permission tmp = input.Where(
                c =>
                    c.key.ToUpper().Equals(hangmuc)
                    &&
                    c.stand_alone == true
                    &&
                    c.recursive_to_child == checkEdit_quyenBaoHam2.Checked
                    &&
                    c.allow_or_deny == !checkEdit_quyenDeny2.Checked
                    &&
                    c.can_add == checkEdit_quyenThem2.Checked
                    &&
                    c.can_edit == checkEdit_quyenSua2.Checked
                    &&
                    c.can_delete == checkEdit_quyenXoa2.Checked
                    &&
                    c.can_view == checkEdit_quyenXem2.Checked
            ).FirstOrDefault();
            if (tmp == null)
            {
                tmp = Permission.request(true, hangmuc, !checkEdit_quyenDeny2.Checked, checkEdit_quyenBaoHam2.Checked, checkEdit_quyenXem2.Checked, checkEdit_quyenSua2.Checked, checkEdit_quyenXoa2.Checked, checkEdit_quyenThem2.Checked);

                input.Add(tmp);

                reloadDSQuyen();
            }
            else
            {
                MessageBox.Show("Trong DS hiện tại đã có!");
            }
        }

        private void checkEdit_quyenFull2_CheckedChanged(object sender, EventArgs e)
        {
            Boolean tmp = (sender as CheckEdit).Checked;
            checkEdit_quyenXem2.Checked = checkEdit_quyenSua2.Checked = checkEdit_quyenThem2.Checked = checkEdit_quyenXoa2.Checked = tmp;
        }

        private void checkEdit_quyenFull_CheckedChanged_1(object sender, EventArgs e)
        {
            //var tmp = sender as CheckEdit;
            Boolean tmp = (sender as CheckEdit).Checked;
            checkEdit_quyenXem.Checked =
            checkEdit_quyenXoa.Checked =
            checkEdit_quyenSua.Checked = tmp;
        }

        private void btnThemQuyenDay_Click(object sender, EventArgs e)
        {
            //Nếu trong ds hiện tại có quyền cấu hình y chang

            Permission tmp = input.Where(
                c =>
                    c.key.ToUpper().Equals(Dayy.USNAME)
                    &&
                    c.stand_alone == false
                    &&
                    c.recursive_to_child == checkEdit_quyenBaoHam.Checked
                    &&
                    c.allow_or_deny == !checkEdit_quyenDeny.Checked
                    &&
                    c.can_edit == checkEdit_quyenSua.Checked
                    &&
                    c.can_delete == checkEdit_quyenXoa.Checked
                    &&
                    c.can_view == checkEdit_quyenXem.Checked
                    ).FirstOrDefault();
            Dayy dangChon = (gridView_Day.GetFocusedRow() as DayyFilter).day;
            if (dangChon == null)
            {
                return;
            }

            if (tmp == null)
            {
                tmp = Permission.request(false, Dayy.USNAME, !checkEdit_quyenDeny.Checked, checkEdit_quyenBaoHam.Checked, checkEdit_quyenXem.Checked, checkEdit_quyenSua.Checked, checkEdit_quyenXoa.Checked);

                //add object list to tmp
                tmp.days.Add(dangChon);
                //add to input
                input.Add(tmp);
                //reload
                reloadDSQuyen();
            }
            else
            {
                //Nếu CS chưa có trong ds thì mới add
                if (!tmp.days.Contains(dangChon))
                {
                    //add object list to tmp
                    tmp.days.Add(dangChon);

                    //reload
                    reloadDSQuyen();
                }
            }
        }

        private void btnThemQuyenTang_Click(object sender, EventArgs e)
        {
            //Nếu trong ds hiện tại có quyền cấu hình y chang
            Permission tmp = input.Where(
                c =>
                    c.key.ToUpper().Equals(Tang.USNAME)
                    &&
                    c.stand_alone == false
                    &&
                    c.recursive_to_child == checkEdit_quyenBaoHam.Checked
                    &&
                    c.allow_or_deny == !checkEdit_quyenDeny.Checked
                    &&
                    c.can_edit == checkEdit_quyenSua.Checked
                    &&
                    c.can_delete == checkEdit_quyenXoa.Checked
                    &&
                    c.can_view == checkEdit_quyenXem.Checked
                    ).FirstOrDefault();
            Tang dangChon = (gridView_Tang.GetFocusedRow() as TangFilter).tang;
            if (dangChon == null)
            {
                return;
            }

            if (tmp == null)
            {
                tmp = Permission.request(false, Tang.USNAME, !checkEdit_quyenDeny.Checked, checkEdit_quyenBaoHam.Checked, checkEdit_quyenXem.Checked, checkEdit_quyenSua.Checked, checkEdit_quyenXoa.Checked);

                //add object list to tmp
                tmp.tangs.Add(dangChon);
                //add to input
                input.Add(tmp);
                //reload
                reloadDSQuyen();
            }
            else
            {
                //Nếu CS chưa có trong ds thì mới add
                if (!tmp.tangs.Contains(dangChon))
                {
                    //add object list to tmp
                    tmp.tangs.Add(dangChon);

                    //reload
                    reloadDSQuyen();
                }
            }
        }

        private void btnThemQuyenPhong_Click(object sender, EventArgs e)
        {
            //Nếu trong ds hiện tại có quyền cấu hình y chang
            Permission tmp = input.Where(
                c =>
                    c.key.ToUpper().Equals(Phong.USNAME)
                    &&
                    c.stand_alone == false
                    &&
                    c.recursive_to_child == checkEdit_quyenBaoHam.Checked
                    &&
                    c.allow_or_deny == !checkEdit_quyenDeny.Checked
                    &&
                    c.can_edit == checkEdit_quyenSua.Checked
                    &&
                    c.can_delete == checkEdit_quyenXoa.Checked
                    &&
                    c.can_view == checkEdit_quyenXem.Checked
                    ).FirstOrDefault();
            Phong dangChon = (gridView_Phong.GetFocusedRow() as PhongFilter2).phong;
            if (dangChon == null)
            {
                return;
            }

            if (tmp == null)
            {
                tmp = Permission.request(false, Phong.USNAME, !checkEdit_quyenDeny.Checked, checkEdit_quyenBaoHam.Checked, checkEdit_quyenXem.Checked, checkEdit_quyenSua.Checked, checkEdit_quyenXoa.Checked);

                //add object list to tmp
                tmp.phongs.Add(dangChon);
                //add to input
                input.Add(tmp);
                //reload
                reloadDSQuyen();
            }
            else
            {
                //Nếu CS chưa có trong ds thì mới add
                if (!tmp.phongs.Contains(dangChon))
                {
                    //add object list to tmp
                    tmp.phongs.Add(dangChon);

                    //reload
                    reloadDSQuyen();
                }
            }
        }
    }
}