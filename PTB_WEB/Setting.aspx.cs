using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB
{
    public partial class Setting : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Đặt tên để set class, đặt tên in hoa
                Default SetClassActive = this.Master as Default;
                SetClassActive.page = "SETTING";

                try
                {
                    if (Convert.ToString(Session["Username"]).Equals(String.Empty))
                        DangNhap.Visible = true;
                    else
                    {
                        if (!PTB.Libraries.PermissionHelper.QuyenConfigEmailTemplate())
                        {
                            _ucWarning.Visible = true;
                            _ucWarning.LabelInfo.Text = "Bạn không được phép chỉnh sửa cài đặt";
                        }
                        else
                        {
                            PanelThongTin.Visible = true;
                            PTB.Entities.QuanTriVien _QuanTriVien = PTB.Entities.QuanTriVien.getByUserName(Session["Username"].ToString());
                            TextBoxMailTieuDe.Text = PTB.Global.remote_setting.email_template.DEFAULT_TITLE_TEMPLATE;
                            TextBoxMailNoiDung.Text = PTB.Global.remote_setting.email_template.DEFAULT_CONTENT_TEMPLATE;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        protected void ButtonSaveMailTemplate_Click(object sender, EventArgs e)
        {
            SetAlertVisible();
            PTB.Global.remote_setting.email_template.DEFAULT_TITLE_TEMPLATE = TextBoxMailTieuDe.Text;
            PTB.Global.remote_setting.email_template.DEFAULT_CONTENT_TEMPLATE = TextBoxMailNoiDung.Text;
            if (PTB.Global.remote_setting.email_template.save() > 0 && PTB.Entities.DBInstance.commit() > 0)
            {
                ucSuccess.LabelInfo.Text = "Lưu mẫu gửi mail thành công";
                ucSuccess.Visible = true;

            }
            else
            {
                ucWarning.LabelInfo.Text = "Có lỗi trong khi lưu mẫu. Vui lòng kiểm tra lại";
                ucWarning.Visible = true;
            }
        }

        public void SetAlertVisible()
        {
            ucDanger.Visible = false;
            ucInfo.Visible = false;
            ucSuccess.Visible = false;
            ucWarning.Visible = false;
        }
    }
}