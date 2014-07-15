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
            var cmdText = "SELECT * FROM [NhanVienPT$]";
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
                strConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;\";", excelFileName);
            }
            else
            {
                if (System.IO.Path.GetExtension(excelFileName).ToLower() == ".xls")
                {
                    strConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES;\";", excelFileName);
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
                    //Ghi file Excel
                    System.Data.OleDb.OleDbConnection MyConnection;
                    System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                    string sql = null;
                    MyConnection = new System.Data.OleDb.OleDbConnection(GetConnectionString(fileName));
                    MyConnection.Open();
                    myCommand.Connection = MyConnection;

                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (!row[5].Equals("Pass"))
                        {
                            if (row[1] != DBNull.Value && row[2] != DBNull.Value)
                            {
                                if (QuanLyTaiSan.Entities.NhanVienPT.getAll().Where(c => c.subId.ToUpper() == row[1].ToString().ToUpper()).FirstOrDefault() == null)
                                {
                                    try
                                    {
                                        QuanLyTaiSan.Entities.NhanVienPT obj = new QuanLyTaiSan.Entities.NhanVienPT();
                                        obj.subId = row[1].ToString();
                                        obj.hoten = row[2].ToString();
                                        obj.sodienthoai = row[3].ToString();
                                        if (row[4] != DBNull.Value)
                                        {
                                            String[] file_names = row[3].ToString().Split(',');
                                            foreach (String name in file_names)
                                            {
                                                QuanLyTaiSan.Entities.HinhAnh objHinh = new QuanLyTaiSan.Entities.HinhAnh();
                                                String file_name = name.TrimStart().TrimEnd();
                                                String fPath = System.IO.Path.GetDirectoryName(fileName) + "Images\\" + file_name;
                                                if (System.IO.File.Exists(fPath))
                                                {
                                                    objHinh.FILE_NAME = file_name;
                                                    objHinh.IMAGE = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(fPath);
                                                    objHinh.MAX_SIZE = 400;
                                                    if (objHinh.upload() > 0)
                                                    {
                                                        obj.hinhanhs.Add(objHinh);
                                                    }
                                                }
                                            }
                                        }
                                        obj.add();
                                    }
                                    catch
                                    {
                                        sql = "Update [NhanVienPT$] set Pass = 'Error' where stt=" + row[0];
                                        myCommand.CommandText = sql;
                                        myCommand.ExecuteNonQuery();
                                    }
                                    finally
                                    {
                                        sql = "Update [NhanVienPT$] set Pass = 'Pass' where stt=" + row[0];
                                        myCommand.CommandText = sql;
                                        myCommand.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    sql = "Update [NhanVienPT$] set Pass = 'Exist' where stt=" + row[0];
                                    myCommand.CommandText = sql;
                                    myCommand.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                sql = "Update [NhanVienPT$] set Pass = 'Error' where stt=" + row[0];
                                myCommand.CommandText = sql;
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    MyConnection.Close();
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
