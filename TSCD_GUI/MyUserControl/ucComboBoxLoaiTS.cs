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
using SHARED.Libraries;

namespace TSCD_GUI.MyUserControl
{
    public partial class ucComboBoxLoaiTS : DevExpress.XtraEditors.XtraUserControl
    {
        public ucComboBoxLoaiTS()
        {
            InitializeComponent();
        }

        public void loadData(List<LoaiTaiSan> listLoaiTS)
        {
            treeListLookUpLoaiTS.Properties.DataSource = listLoaiTS;
        }

        public LoaiTaiSan getLoaiTS()
        {
            try
            {
                return LoaiTaiSan.getById(GUID.From(treeListLookUpLoaiTS.EditValue));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->getLoaiTS: " + ex.Message);
                return null;
            }
        }

        public void setLoaiTS(LoaiTaiSan obj)
        {
            try
            {
                if (obj != null)
                    treeListLookUpLoaiTS.EditValue = obj.id;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setLoaiTS: " + ex.Message);
            }
        }

        public void setReadOnly(bool b)
        {
            treeListLookUpLoaiTS.Properties.ReadOnly = b;
        }
    }
}
