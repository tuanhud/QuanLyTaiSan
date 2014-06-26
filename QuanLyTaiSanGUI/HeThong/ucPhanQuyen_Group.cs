using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucPhanQuyen_Group : UserControl
    {
        List<Group> listGroup = null;
        Group objGroup = null;
        public ucPhanQuyen_Group()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            listGroup = new Group().getAll();
            gridControlGroup.DataSource = listGroup;
        }

        public GridControl getLeftControl()
        {
            return gridControlGroup;
        }
        public PanelControl getRightControl()
        {
            return panelControl1;
        }

        private void gridViewGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                objGroup = gridViewGroup.GetRow(e.FocusedRowHandle) as Group;
                setData(objGroup);
            }
        }

        private void setData(Group obj)
        {
            txtKey.Text = obj.key;
            txtTen.Text = obj.ten;
            txtMoTa.Text = obj.mota;
            listBoxQuyen.DataSource = obj.permissions.ToList();
        }
    }
}
