using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSanGUI.Libraries
{
    public class ExcelDataBaseHelper
    {
        public static System.Data.DataTable OpenFile(string fileName)
        {
            //var fullFileName = string.Format("{0}\\{1}", System.IO.Directory.GetCurrentDirectory(), fileName);
            if (!System.IO.File.Exists(fileName))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("File not found");
                return null;
            }
            System.Data.DataTable dt = new System.Data.DataTable();
            var cmdText = "SELECT * FROM [Sheet1$A1:AZ]";
            using (var adapter = new System.Data.OleDb.OleDbDataAdapter(cmdText, GetConnectionString(fileName)))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public static string GetConnectionString(string excelFileName)
        {
            var strConnectionString = string.Empty;
            if (System.IO.Path.GetExtension(excelFileName).ToLower() == ".xlsx")
            {
                strConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", excelFileName);
            }
            else
            {
                if (System.IO.Path.GetExtension(excelFileName).ToLower() == ".xls")
                {
                    strConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\";", excelFileName);
                }
            }
            return strConnectionString;
        }

        public static bool ImportNhanVien(string fileName)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = OpenFile(fileName);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (!row[1].Equals(""))
                        {
                            QuanLyTaiSan.Entities.NhanVienPT obj = new QuanLyTaiSan.Entities.NhanVienPT();
                            obj.subId = row[0].ToString();
                            obj.hoten = row[1].ToString();
                            obj.sodienthoai = row[2].ToString();
                            obj.add();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                QuanLyTaiSan.Entities.Debug.WriteLine("ExcelDataBaseHelper : ImportNhanVien : "+ ex.Message);
                return false;
            }
            finally
            {
            }
        }
    }
}
