using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSanGUI.MyUC
{
    public class MyLayout
    {
        String layout = "";
        public void save(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            System.IO.Stream str = new System.IO.MemoryStream();
            view.SaveLayoutToStream(str);
            str.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.StreamReader reader = new System.IO.StreamReader(str);
            layout = reader.ReadToEnd();
        }
        public void load(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(layout);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
            view.RestoreLayoutFromStream(stream);
        }
    }
}
