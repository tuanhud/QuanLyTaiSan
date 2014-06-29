using QuanLyTaiSan.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Libraries
{
    class ImageCache
    {
        private static Dictionary<String, Bitmap> collection = new Dictionary<string, Bitmap>();
        public static Bitmap get(String file_name)
        {
            if (file_name == null)
            {
                return null;
            }
            if(collection.ContainsKey(file_name))
            {
                return collection[file_name];
            }
            return null;
        }
        public static void register(String file_name, Bitmap image)
        {
            if (collection.ContainsKey(file_name))
            {
                return;
            }
            else
            {
                collection.Add(file_name, image);
            }
        }
    }
}
