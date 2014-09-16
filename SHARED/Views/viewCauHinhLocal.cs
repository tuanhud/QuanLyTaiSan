using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SHARED.Views
{
    public partial class viewCauHinhLocal : UserControl
    {
        public viewCauHinhLocal()
        {
            InitializeComponent();
        }
        #region View Provider
        public CheckEdit _cbDebugToFile
        {
            get
            {
                return cbDebugToFile;
            }
        }
        public SimpleButton _btnStartSync
        {
            get
            {
                return btnStartSync;
            }
        }
        public CheckEdit _cbAutoSync
        {
            get
            {
                return cbAutoSync;
            }
        }
        public CheckEdit _cbUseDBCache
        {
            get
            {
                return cbUseDBCache;
            }
        }
        public SimpleButton _btnSaveLocal
        {
            get
            {
                return btnSaveLocal;
            }
        }
        public SimpleButton _btnDebugClear
        {
            get
            {
                return btnDebugClear;
            }
        }
        //Client
        public CheckEdit _cbClientWA
        {
            get
            {
                return cbClientWA;
            }
        }
        public SimpleButton _btnClientCleanUp
        {
            get
            {
                return btnClientCleanUp;
            }
        }
        public SimpleButton _btnClientDropDB
        {
            get
            {
                return btnClientDropDB;
            }
        }
        public SimpleButton _btnClientRemoveScope
        {
            get
            {
                return btnClientRemoveScope;
            }
        }
        public SimpleButton _btnClientValidate
        {
            get
            {
                return btnClientValidate;
            }
        }
        public TextEdit _txtClientDBName
        {
            get
            {
                return txtClientDBName;
            }
        }
        public TextEdit _txtClientHost
        {
            get
            {
                return txtClientHost;
            }
        }
        public TextEdit _txtClientPassword
        {
            get
            {
                return txtClientPassword;
            }
        }
        public TextEdit _txtClientPort
        {
            get
            {
                return txtClientPort;
            }
        }
        public TextEdit _txtClientUsername
        {
            get
            {
                return txtClientUsername;
            }
        }
        //Server
        public CheckEdit _cbServerWA
        {
            get
            {
                return cbServerWA;
            }
        }
        public SimpleButton _btnServerCleanUp
        {
            get
            {
                return btnServerCleanUp;
            }
        }
        public SimpleButton _btnServerRemoveScope
        {
            get
            {
                return btnServerRemoveScope;
            }
        }
        public SimpleButton _btnServerValidate
        {
            get
            {
                return btnServerValidate;
            }
        }
        public TextEdit _txtServerDBName
        {
            get
            {
                return txtServerDBName;
            }
        }
        public TextEdit _txtServerHost
        {
            get
            {
                return txtServerHost;
            }
        }
        public TextEdit _txtServerPassword
        {
            get
            {
                return txtServerPassword;
            }
        }
        public TextEdit _txtServerPort
        {
            get
            {
                return txtServerPort;
            }
        }
        public TextEdit _txtServerUsername
        {
            get
            {
                return txtServerUsername;
            }
        }
        public TextEdit _txtSyncSecond
        {
            get
            {
                return txtSyncSecond;
            }
        }

        #endregion

        private void cbServerWA_CheckedChanged(object sender, EventArgs e)
        {
            txtServerUsername.Enabled = txtServerPassword.Enabled = !(sender as CheckEdit).Checked;
        }

        private void cbClientWA_CheckedChanged(object sender, EventArgs e)
        {
            txtClientUsername.Enabled = txtClientPassword.Enabled = !(sender as CheckEdit).Checked;
        }

        private void cbUseDBCache_CheckedChanged(object sender, EventArgs e)
        {
            panelControl_Client.Enabled = (sender as CheckEdit).Checked;
        }

        private void cbAutoSync_CheckedChanged(object sender, EventArgs e)
        {
            txtSyncSecond.Enabled = (sender as CheckEdit).Checked;
        }

        private void btnDebugClear_Click(object sender, EventArgs e)
        {
            SHARED.Libraries.Debug.remove_file();
        }
    }
}
