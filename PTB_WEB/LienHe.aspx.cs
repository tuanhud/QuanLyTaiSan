using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PTB_WEB
{
    public partial class LienHe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Default SetClassActive = this.Master as Default;
            SetClassActive.page = "LIENHE";
        }

        protected void ButtonLienHe_Click(object sender, EventArgs e)
        {
            string to = PTB.Global.remote_setting.smtp_config.SMTP_USERNAME;
            string sub = string.Format("Liên hệ từ {0}",TextHoVaTen.Text);
            string msg = string.Format("<p>Họ và tên: {0}</p><p>Email: {1}</p><p>Điện thoại: {2}</p><p>Nội dung: {3}</p>", TextHoVaTen.Text, TextBoxEmail.Text, TextBoxDienThoai.Text, TextBoxNoiDung.Text);
            if (PTB.Libraries.EmailHelper.sendMail(to, sub, msg) > 0)
            {
                HideAllAlert();
                ucSuccess.LabelInfo.Text += "Đã gửi thông tin của bạn đến Quản trị. Chúng tôi sẽ hồi âm trong thời gian sớm nhất.";
                ucSuccess.Visible = true;
            }
            else
            {
                HideAllAlert();
                ucDanger.LabelInfo.Text = "Có lỗi xảy ra. Vui lòng thử lại";
                ucDanger.Visible = true;
            }
        }

        private void HideAllAlert()
        {
            ucDanger.Visible = ucSuccess.Visible = false;
        }
    }
}