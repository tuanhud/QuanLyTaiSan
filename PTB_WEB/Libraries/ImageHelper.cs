using System;
using SHARED.Libraries;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PTB_WEB.Libraries
{
    public class ImageHelper
    {
        public static void LoadImageWeb(List<PTB.Entities.HinhAnh> listHinhAnh, DevExpress.Web.ASPxImageSlider.ASPxImageSlider _ASPxImageSlider)
        {
            _ASPxImageSlider.Items.Clear();
            if (listHinhAnh != null)
            {
                if (listHinhAnh.Count > 0)
                {
                    foreach (PTB.Entities.HinhAnh hinhanh in listHinhAnh)
                    {
                        _ASPxImageSlider.Visible = true;
                        DevExpress.Web.ASPxImageSlider.ImageSliderItem item = new DevExpress.Web.ASPxImageSlider.ImageSliderItem();
                        item.ImageUrl = hinhanh.getImageURL();
                        if (hinhanh.mota != null)
                        {
                            if (hinhanh.mota.Length > 0)
                                item.Text = hinhanh.mota;
                            else
                                item.Text = hinhanh.FILE_NAME;
                        }
                        else
                            item.Text = hinhanh.FILE_NAME;
                        _ASPxImageSlider.Items.Add(item);
                    }
                }
                else
                {
                    _ASPxImageSlider.Visible = false;
                }
            }
            else
            {
                _ASPxImageSlider.Visible = false;
            }
        }
    }
}