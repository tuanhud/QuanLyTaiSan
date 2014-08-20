using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;

namespace WebQLPH.UserControl.LoaiThietBis
{
    public partial class ucLoaiThietBi_Web : System.Web.UI.UserControl
    {
        List<LoaiThietBi> ListLoaiThietBi = new List<LoaiThietBi>();
        LoaiThietBi objLoaiThietBi = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            Panel_Chinh.Visible = true;
            ListLoaiThietBi = LoaiThietBi.getAll();
            if (ListLoaiThietBi.Count > 0)
            {
                Panel_Chinh.Visible = true;
                ClearData();
                ASPxTreeList_LoaiThietBi.DataSource = ListLoaiThietBi;
                ASPxTreeList_LoaiThietBi.DataBind();
                ASPxTreeList_LoaiThietBi.ExpandToLevel(1);
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
            TextBox_Ten.Text = "";
            TextBox_Thuoc.Text = "";
            TextBox_KieuQuanLy.Text = "";
            TextBox_Mota.Text = "";
        }

        private void SetError(string strError)
        {
            PanelThongBao.Visible = true;
            LabelThongBao.Text = strError;
        }

        private void LoadDataObj(int id)
        {
            objLoaiThietBi = LoaiThietBi.getById(id);
            if (objLoaiThietBi != null)
            {
                Label_ThongTin.Text = string.Format("Thông tin {0}", objLoaiThietBi.ten);
                TextBox_Ten.Text = objLoaiThietBi.ten;
                TextBox_KieuQuanLy.Text = objLoaiThietBi.loaichung == true ? "Theo số lượng" : "Theo cá thể";
                TextBox_Mota.Text = objLoaiThietBi.mota;
                TextBox_Thuoc.Text = objLoaiThietBi.parent_id.Equals(null) ? "[Không thuộc loại nào]" : getParent(Convert.ToInt32(objLoaiThietBi.parent_id));
            }
            else
            {
                ClearData();
                SetError("Không có dữ liệu về cơ sở này");
            }
        }

        protected string getParent(int parent_id)
        {
            LoaiThietBi _objLoaiThietBi = LoaiThietBi.getById(parent_id);
            return _objLoaiThietBi.ten;
        }

        protected void ASPxTreeList_LoaiThietBi_FocusedNodeChanged(object sender, EventArgs e)
        {
            if (ListLoaiThietBi.Count > 0)
            {
                if (ASPxTreeList_LoaiThietBi.FocusedNode != null && Convert.ToInt32(ASPxTreeList_LoaiThietBi.FocusedNode.GetValue("id")) > 0)
                {
                    LoadDataObj(Convert.ToInt32(ASPxTreeList_LoaiThietBi.FocusedNode.GetValue("id")));
                }
            }
        }
    }
}