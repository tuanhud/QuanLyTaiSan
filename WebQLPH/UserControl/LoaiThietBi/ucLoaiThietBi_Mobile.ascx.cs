using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLPH.UserControl.LoaiThietBis
{
    public partial class ucLoaiThietBi_Mobile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            if (Request.QueryString["id"] != null)
            {
                int id = -1;
                try
                {
                    id = Int32.Parse(Request.QueryString["id"].ToString());
                }
                catch
                {
                    Response.Redirect(Request.Url.AbsolutePath);
                    return;
                }

                LoaiThietBi objLoaiThietBi = LoaiThietBi.getById(id);
                if (objLoaiThietBi != null)
                {
                    Panel_Chinh.Visible = true;
                    Panel_ThongTinObj.Visible = true;
                    Label_ThongTin.Text = "Thông tin " + objLoaiThietBi.ten;
                    TextBox_Ten.Text = objLoaiThietBi.ten;
                    TextBox_KieuQuanLy.Text = objLoaiThietBi.loaichung == true ? "Theo số lượng" : "Theo cá thể";
                    TextBox_Mota.Text = objLoaiThietBi.mota;
                    TextBox_Thuoc.Text = objLoaiThietBi.parent_id.Equals(null) ? "[Không thuộc loại nào]" : getParent(Convert.ToInt32(objLoaiThietBi.parent_id));
                }
                else
                {
                    Panel_ThongBaoLoi.Visible = true;
                    Label_ThongBaoLoi.Text = "Không có tầng này";
                }
            }
            else
            {
                List<LoaiThietBi> ListLoaiThietBi = LoaiThietBi.getAll();
                if (ListLoaiThietBi.Count > 0)
                {
                    Panel_Chinh.Visible = true;
                    Panel_TreeViTri.Visible = true;
                    ASPxTreeList_LoaiThietBi.DataSource = ListLoaiThietBi;
                    ASPxTreeList_LoaiThietBi.DataBind();
                }
                else
                {
                    Panel_ThongBaoLoi.Visible = true;
                    Label_ThongBaoLoi.Text = "Chưa có loại thiết bị";
                }
            }
        }

        protected string getParent(int parent_id)
        {
            LoaiThietBi _objLoaiThietBi = LoaiThietBi.getById(parent_id);
            return _objLoaiThietBi.ten;
        }

        protected void Button_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsolutePath);
        }
    }
}