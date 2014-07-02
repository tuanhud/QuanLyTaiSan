using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.MyUC
{
    public delegate void MyEventHandler(object sender, EventArgs e);
    public partial class ucThemSuaXoaButton : DevExpress.XtraEditors.XtraUserControl
    {
        public event MyEventHandler ButtonThemClick;
        public event MyEventHandler ButtonSuaClick;
        public event MyEventHandler ButtonXoaClick;
        public ucThemSuaXoaButton()
        {
            InitializeComponent();
        }
        #region getter
        public DevExpress.XtraEditors.SimpleButton btnThem
        {
            get
            {
                return this.btnR_Them;
            }
        }
        public DevExpress.XtraEditors.SimpleButton btnSua
        {
            get
            {
                return this.btnR_Sua;
            }
        }
        public DevExpress.XtraEditors.SimpleButton btnXoa
        {
            get
            {
                return this.btnR_Xoa;
            }
        }
        #endregion

        private void btnR_Them_Click(object sender, EventArgs e)
        {
            if (ButtonThemClick != null)
            {
                ButtonThemClick(this, e);
            }
        }

        private void btnR_Sua_Click(object sender, EventArgs e)
        {
            if (ButtonSuaClick != null)
            {
                ButtonSuaClick(this, e);
            }
        }

        private void btnR_Xoa_Click(object sender, EventArgs e)
        {
            if (ButtonXoaClick != null)
            {
                ButtonXoaClick(this, e);
            }
        }
    }
}
