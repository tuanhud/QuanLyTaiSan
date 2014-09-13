using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD_GUI.Libraries
{
    public class ExcelDataBaseHelper
    {
        public static System.Data.DataTable OpenFile(String fileName, String sheet)
        {
            //var fullFileName = string.Format("{0}\\{1}", System.IO.Directory.GetCurrentDirectory(), fileName);
            if (!System.IO.File.Exists(fileName))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("File not found");
                return null;
            }
            System.Data.DataTable dt = new System.Data.DataTable();
            var cmdText = String.Format("SELECT * FROM [{0}$]", sheet);
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

        public static bool ImportTaiSan(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int SUBID = 0;
                const int TEN = 2;
                const int DONGIA = 9;
                const int PASS = 23;
                LoaiTaiSan objLoaiTS = null;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (!row[PASS].Equals("Pass"))
                        {
                            if (row[TEN] != DBNull.Value || String.IsNullOrWhiteSpace(row[TEN].ToString()))
                            {
                                if (row[SUBID] == DBNull.Value || String.IsNullOrWhiteSpace(row[SUBID].ToString()))
                                {
                                    objLoaiTS = getLoai(row[TEN].ToString());
                                }
                                else
                                {
                                    try
                                    {
                                        TaiSan obj = new TaiSan();
                                        obj.subId = row[SUBID].ToString().TrimEnd().TrimStart();
                                        obj.ten = row[TEN].ToString().TrimEnd().TrimStart();
                                        String str = row[DONGIA].ToString().Trim().Replace(" ","");
                                        long dongia = long.Parse(str);
                                        obj.dongia = dongia;
                                        obj.loaitaisan = objLoaiTS;
                                        CTTaiSan objCTTaiSan = new CTTaiSan();
                                        objCTTaiSan.taisan = obj;
                                        objCTTaiSan.tinhtrang = TinhTrang.getQuery().FirstOrDefault();
                                        objCTTaiSan.soluong = 1;
                                        if (objCTTaiSan.add() > 0 && DBInstance.commit() > 0)
                                        {
                                            WriteFile(fileName, sheet, row[SUBID].ToString().TrimEnd().TrimStart(), "Pass");
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[SUBID].ToString().TrimEnd().TrimStart(), "Error");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("ExcelDataBaseHelper : ImportTaiSan : " + ex.Message);
                                        WriteFile(fileName, sheet, row[SUBID].ToString().TrimEnd().TrimStart(), "Error");
                                    }
                                }
                            }
                            else
                            {
                                WriteFile(fileName, sheet, row[SUBID].ToString().TrimEnd().TrimStart(), "Error (Không đủ thông tin)");
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper : ImportNhanVien : " + ex.Message);
                return false;
            }
        }

        private static LoaiTaiSan getLoai(String _ten)
        {
            try
            {
                String ten = _ten.TrimEnd().TrimStart();
                ten = ten.Replace("- ", "");
                LoaiTaiSan obj = LoaiTaiSan.getQuery().Where(c => c.ten.ToUpper().Equals(ten.ToUpper())).FirstOrDefault();
                if (obj == null)
                {
                    obj = new LoaiTaiSan();
                    obj.ten = ten;
                    obj.huuhinh = true;
                    obj.donvitinh = DonViTinh.getQuery().FirstOrDefault();
                    if (obj.add() > 0 && DBInstance.commit() > 0)
                        return obj;
                    else return null;
                }
                return obj;
            }
            catch
            {
                return null;
            }
        }

        private static void WriteFile(String fileName, String sheet, String stt, String text)
        {
            //try
            //{
            //    if (!stt.Equals(""))
            //    {
            //        //Ghi file Excel
            //        using (System.Data.OleDb.OleDbConnection MyConnection = new System.Data.OleDb.OleDbConnection(GetConnectionString(fileName)))
            //        {
            //            System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
            //            string sql = null;
            //            MyConnection.Open();
            //            myCommand.Connection = MyConnection;
            //            sql = String.Format("Update [{0}$] set Pass = '{1}' where STT = {2}", sheet, text, stt);
            //            myCommand.CommandText = sql;
            //            myCommand.ExecuteNonQuery();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("ExcelDataBaseHelper->WriteFile : " + ex.Message);
            //}
        }
    }
}
