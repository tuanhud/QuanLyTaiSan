using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmLogTaiSan : DevExpress.XtraEditors.XtraForm
    {
        public frmLogTaiSan()
        {
            InitializeComponent();
        }

        public frmLogTaiSan(CTTaiSan obj)
        {
            InitializeComponent();
            gridControlLog.DataSource = LogSuaTaiSan.getQuery().Where(c=>c.taisan_id.Equals(obj.taisan_id)).ToList();
            gridViewLog.PopulateColumns();
        }
    }
}