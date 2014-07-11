﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
namespace Web
{
    public partial class NhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<NhanVienPTFilter> ListNhanVienPT = NhanVienPTFilter.getAll();
            Grid.DataSource = ListNhanVienPT;
            Grid.DataBind();
            Grid.Styles.Header.HorizontalAlign = HorizontalAlign.Center;
            Grid.Styles.Header.Font.Bold = true;
        }
    }
}