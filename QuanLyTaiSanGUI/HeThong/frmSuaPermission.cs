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

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class frmSuaPermission : DevExpress.XtraEditors.XtraForm
    {
        private List<Permission> input = new List<Permission>();
        public frmSuaPermission()
        {
            InitializeComponent();
        }
        public frmSuaPermission(List<Permission> input)
        {
            InitializeComponent();

            this.input = input;
        }

        private void frmSuaPermission_Load(object sender, EventArgs e)
        {
            //load ds quyền cố định
            gridControl_quyenCoDinh.DataSource = Permission.getQuery().Where(c => c.stand_alone == true).ToList();

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
            Permission tmp = (Permission)gridView_quyenCoDinh.GetFocusedRow();
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
                    c.key.ToUpper().Equals("COSO")
                    &&
                    c.recursive_to_child == checkEdit_quyenBaoHam.Checked
                    &&
                    c.allow_or_deny == !checkEdit_quyenDeny.Checked
                    &&
                    c.can_add == checkEdit_quyenThem.Checked
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
                tmp = new Permission();
                tmp.key = "COSO";
                tmp.recursive_to_child = checkEdit_quyenBaoHam.Checked;
                tmp.allow_or_deny = !checkEdit_quyenDeny.Checked;
                tmp.can_add = checkEdit_quyenThem.Checked;
                tmp.can_edit = checkEdit_quyenSua.Checked;
                tmp.can_delete = checkEdit_quyenXoa.Checked;
                tmp.can_view = checkEdit_quyenXem.Checked;
                tmp.stand_alone = false;
                
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
            //var tmp = sender as CheckEdit;
            Boolean tmp = (sender as CheckEdit).Checked;
            checkEdit_quyenXem.Checked = 
            checkEdit_quyenThem.Checked = 
            checkEdit_quyenXoa.Checked = 
            checkEdit_quyenSua.Checked = tmp;
        }
    }
}