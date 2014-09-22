using PTB.Entities;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PTB.Libraries
{
    public static class ImageHelper
    {
        /// <summary>
        /// Hỗ trợ cache
        /// </summary>
        public static class CACHE
        {
            private static Dictionary<String, Bitmap> collection = new Dictionary<string, Bitmap>();
            private static HashSet<String> fail_url = new HashSet<string>();

            public static Bitmap get(String url)
            {
                if (url == null || fail_url==null || collection == null)
                {
                    return null;// HinhAnh.DEFAULT_IMAGE;
                }
                //Nếu nằm trong fail list thì return ảnh mặc định
                if (fail_url.Contains(url))
                {
                    return null;// HinhAnh.DEFAULT_IMAGE;
                }
                //tìm kiếm trong cache list
                if (collection.ContainsKey(url))
                {
                    return collection[url];
                }
                return null;// HinhAnh.DEFAULT_IMAGE;
            }
            /// <summary>
            /// Đánh dấu url fail, lần get kế tiếp từ CACHE sẽ trả về hình mặc định
            /// </summary>
            /// <param name="url"></param>
            public static void mark_url_fail(String url)
            {
                if (fail_url != null)
                {
                    fail_url.Add(url);
                }
            }
            /// <summary>
            /// Đăng ký ảnh vào cache list, OVERRIDE MODE ON
            /// </summary>
            /// <param name="url"></param>
            /// <param name="image"></param>
            public static void register(String url, Bitmap image)
            {
                try
                {
                    if (collection.ContainsKey(url))
                    {
                        collection.Remove(url);
                    }
                    collection.Add(url, image);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            public static void release()
            {
                try
                {
                    if (collection != null)
                    {
                        collection.Clear();
                    }
                    if (fail_url != null)
                    {
                        fail_url.Clear();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }
    }
}
