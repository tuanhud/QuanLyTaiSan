using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                        if (FindNodeTreeList(key))
                            LoadDataObj(Convert.ToInt32(key));
                        else
                            Response.Redirect(Request.Url.AbsolutePath);
                    }
                    catch
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                        return;
                    }
                }
                else
                {
                    LoadFocusedNodeData();
                }
            }
            else
            {
                Panel_ThongBaoLoi.Visible = true;
                Label_ThongBaoLoi.Text = "Chưa có loại thiết bị";
            }
        }

        private void ClearData()
        {
            Label_ThongTin.Text = "Thông tin";
            Label_TenLoai.Text = "";
            Label_Thuoc.Text = "";
            Label_KieuQuanLy.Text = "";
            Label_MoTa.Text = "";
        }

        private void SetError(string strError)
        {
            PanelThongBao.Visible = true;
            LabelThongBao.Text = strError;
        }

        private void LoadDataObj(int id)
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
                ClearData();
                SetError("Không có dữ liệu về cơ sở này");
            }
        }

        protected void ASPxTreeList_LoaiThietBi_FocusedNodeChanged(object sender, EventArgs e)
        {
            LoadFocusedNodeData();
        }

        private Boolean FindNodeTreeList(string key)
        {
            DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList_LoaiThietBi.FindNodeByKeyValue(key);
            if (node != null)
            {
                node.Focus();
                return true;
            }
            return false;
        }

        private void LoadFocusedNodeData()
        {
            if (listLoaiThietBi.Count > 0)
            {
                if (ASPxTreeList_LoaiThietBi.FocusedNode != null && Convert.ToInt32(ASPxTreeList_LoaiThietBi.FocusedNode.GetValue("id")) > 0)
                {
                    LoadDataObj(Convert.ToInt32(ASPxTreeList_LoaiThietBi.FocusedNode.GetValue("id")));
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