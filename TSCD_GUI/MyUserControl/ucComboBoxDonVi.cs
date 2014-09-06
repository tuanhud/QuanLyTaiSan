using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using SHARED.Libraries;

namespace TSCD_GUI.MyUserControl
{
    public partial class ucComboBoxDonVi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucComboBoxDonVi()
        {
            InitializeComponent();
        }

        public void loadData(List<DonVi> listDonVi, List<LoaiDonVi> listLoaiDonVi)
        {
            //repositoryLookUpLoai.DataSource = listLoaiDonVi;
            treeListLookUpDonVi.Properties.DataSource = listDonVi;
        }

        public DonVi getDonVi()
        {
            try
            {
                return DonVi.getById(GUID.From(treeListLookUpDonVi.EditValue));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->getDonVi: " + ex.Message);
                return null;
            }
        }

        public void setDonVi(DonVi obj)
        {
            try
            {
                if (obj != null)
                    treeListLookUpDonVi.EditValue = obj.id;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDonVi: " + ex.Message);
            }
        }

        public void setReadOnly(bool b)
        {
            treeListLookUpDonVi.Properties.ReadOnly = b;
        }
    }
}
