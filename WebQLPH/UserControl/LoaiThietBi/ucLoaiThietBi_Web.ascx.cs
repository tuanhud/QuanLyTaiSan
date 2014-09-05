using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Libraries;

namespace WebQLPH.UserControl.LoaiThietBis
{
    public partial class ucLoaiThietBi_Web : System.Web.UI.UserControl
    {
        List<QuanLyTaiSan.Entities.LoaiThietBi> listLoaiThietBi = new List<QuanLyTaiSan.Entities.LoaiThietBi>();
        QuanLyTaiSan.Entities.LoaiThietBi objLoaiThietBi = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            listLoaiThietBi = QuanLyTaiSan.Entities.LoaiThietBi.getAll();
            if (listLoaiThietBi.Count > 0)
            {
                Panel_Chinh.Visible = true;
                ASPxTreeList_LoaiThietBi.DataSource = listLoaiThietBi;
                ASPxTreeList_LoaiThietBi.DataBind();

                if (Request.QueryString["key"] != null)
                {
                    try
                    {
                        string key = Request.QueryString["key"].ToString();
                        DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_LoaiThietBi.FindNodeByKeyValue(key);
                        if (node != null)
                        {
                            node.Focus();
                            LoadFocusedNodeData();
                            Panel_ThongTinLoaiThietBi.Visible = true;
                            Label_ChuaChon.Visible = false;
                        }
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                }
                else
                {
                    DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_LoaiThietBi.FindNodeByKeyValue("");
                    node.Focus();
                    Label_ChuaChon.Visible = true;
                    Label_ChuaChon.Text = "Chưa chọn loại thiết bị cần xem";
                }
            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có loại thiết bị";
            }
        }

        private void LoadDataObj(Guid id)
        {
            objLoaiThietBi = QuanLyTaiSan.Entities.LoaiThietBi.getById(id);
            if (objLoaiThietBi != null)
            {
                Label_ThongTin.Text = string.Format("Thông tin {0}", objLoaiThietBi.ten);
                Session["TenLoaiThietBi"] = Label_TenLoai.Text = objLoaiThietBi.ten;
                Label_KieuQuanLy.Text = objLoaiThietBi.loaichung == true ? "Theo số lượng" : "Theo cá thể";
                Label_MoTa.Text = objLoaiThietBi.mota;
                Label_Thuoc.Text = objLoaiThietBi.parent_id.Equals(null) ? "[Không thuộc loại nào]" : objLoaiThietBi.parent.ten;
            }
            else
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        private void LoadFocusedNodeData()
        {
            if (listLoaiThietBi.Count > 0)
            {
                if (ASPxTreeList_LoaiThietBi.FocusedNode != null && GUID.From(ASPxTreeList_LoaiThietBi.FocusedNode.GetValue("id")) != Guid.Empty)
                {
                    LoadDataObj(GUID.From(ASPxTreeList_LoaiThietBi.FocusedNode.GetValue("id")));
                }
            }
        }

        protected void ASPxTreeList_LoaiThietBi_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_LoaiThietBi.FindNodeByKeyValue(key);
            if (node != null)
                e.Result = Request.Url.AbsolutePath + "?key=" + key;
            else
                e.Result = Request.Url.AbsolutePath;
        }
    }
}