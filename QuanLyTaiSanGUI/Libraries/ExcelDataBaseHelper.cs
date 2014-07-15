using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.Libraries
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

        public static bool ImportNhanVien(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int MANHANVIEN = 1;
                const int TENNHANVIEN = 2;
                const int SODIENTHOAI = 3;
                const int HINHANH = 4;
                const int PASS = 5;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (!row[PASS].Equals("Pass"))
                        {
                            if (row[MANHANVIEN] != DBNull.Value && row[TENNHANVIEN] != DBNull.Value)
                            {
                                if (NhanVienPT.getAll().FirstOrDefault(c => c.subId.ToUpper() == row[MANHANVIEN].ToString().ToUpper()) == null)
                                {
                                    try
                                    {
                                        NhanVienPT obj = new NhanVienPT();
                                        obj.subId = row[MANHANVIEN].ToString();
                                        obj.hoten = row[TENNHANVIEN].ToString();
                                        obj.sodienthoai = row[SODIENTHOAI].ToString();
                                        if (row[HINHANH] != DBNull.Value)
                                        {
                                            String[] file_names = row[HINHANH].ToString().Split(',');
                                            foreach (String name in file_names)
                                            {
                                                HinhAnh objHinh = new HinhAnh();
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
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                                    }
                                    finally
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Pass");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString(), "Exist");
                                }
                            }
                            else
                            {
                                WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không đủ thông tin)");
                            }
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

        public static bool ImportViTri(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int COSO = 1;
                const int DAY = 2;
                const int TANG = 3;
                const int MOTA = 4;
                const int HINHANH = 5;
                const int PASS = 6;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (!row[PASS].Equals("Pass"))
                        {
                            if (row[COSO] != DBNull.Value && row[DAY] != DBNull.Value && row[TANG] != DBNull.Value)
                            {
                                CoSo objCoSo = CoSo.getAll().FirstOrDefault(c => c.ten.ToUpper().Equals(row[COSO].ToString().ToUpper()));
                                if (objCoSo != null)
                                {
                                    Dayy objDay = objCoSo.days.FirstOrDefault(c => c.ten.ToUpper().Equals(row[DAY].ToString().ToUpper()));
                                    if (objDay != null)
                                    {
                                        if (objDay.tangs.FirstOrDefault(c => c.ten.ToUpper().Equals(row[TANG].ToString().ToUpper())) == null)
                                        {
                                            Tang obj = new Tang();
                                            obj.ten = row[TANG].ToString();
                                            obj.mota = row[MOTA].ToString();
                                            obj.day = objDay;
                                            if (obj.add() > 0)
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString(), "Pass");
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                                            }
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString(), "Exist");
                                        }
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có dãy)");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có cơ sở)");
                                }

                            }
                            else if (row[COSO] != DBNull.Value && row[DAY] != DBNull.Value && row[TANG] == DBNull.Value)
                            {
                                CoSo objCoSo = CoSo.getAll().FirstOrDefault(c => c.ten.ToUpper().Equals(row[COSO].ToString().ToUpper()));
                                if (objCoSo != null)
                                {
                                    if (objCoSo.days.FirstOrDefault(c => c.ten.ToUpper().Equals(row[DAY].ToString().ToUpper())) == null)
                                    {
                                        Dayy obj = new Dayy();
                                        obj.ten = row[DAY].ToString();
                                        obj.mota = row[MOTA].ToString();
                                        obj.coso = objCoSo;
                                        if (obj.add() > 0)
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString(), "Pass");
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                                        }
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Exist");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có cơ sở)");
                                }

                            }
                            else if (row[COSO] != DBNull.Value && row[DAY] == DBNull.Value && row[TANG] == DBNull.Value)
                            {
                                if (CoSo.getAll().FirstOrDefault(c => c.ten.ToUpper().Equals(row[COSO].ToString().ToUpper())) == null)
                                {
                                    CoSo obj = new CoSo();
                                    obj.ten = row[COSO].ToString();
                                    obj.mota = row[MOTA].ToString();
                                    if (obj.add() > 0)
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Pass");
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString(), "Exist");
                                }
                            }
                            else
                            {
                                WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không đủ thông tin)");
                            }
                        }
                    }
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                QuanLyTaiSan.Entities.Debug.WriteLine("ExcelDataBaseHelper : ImportNhanVien : " + ex.Message);
                return false;
            }
            finally
            {
            }
        }

        public static bool ImportLoaiThietBi(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int LOAITHIETBI = 1;
                const int PARENT = 2;
                const int LOAICHUNG = 3;
                const int MOTA = 4;
                const int PASS = 5;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (!row[PASS].Equals("Pass"))
                        {
                            if (row[LOAITHIETBI] != DBNull.Value && row[PARENT] != DBNull.Value && row[LOAICHUNG] != DBNull.Value)
                            {
                                LoaiThietBi objParent = LoaiThietBi.getAll().FirstOrDefault(c => c.ten.ToUpper().Equals(row[PARENT].ToString().ToUpper()));
                                if (objParent != null)
                                {
                                    if (objParent.thietbis.FirstOrDefault(c => c.ten.ToUpper().Equals(row[LOAITHIETBI].ToString().ToUpper())) == null)
                                    {
                                        if (objParent.loaichung.Equals(Convert.ToBoolean(row[LOAICHUNG])))
                                        {
                                            LoaiThietBi obj = new LoaiThietBi();
                                            obj.ten = row[LOAITHIETBI].ToString();
                                            obj.mota = row[MOTA].ToString();
                                            obj.loaichung = Convert.ToBoolean(row[LOAICHUNG]);
                                            obj.parent = objParent;
                                            if (obj.add() > 0)
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString(), "Pass");
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                                            }
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString(), "Error (Kiểu quản lý của loại cha và loại con khác nhau)");
                                        }
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Exist");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có loại thiết bị cha)");
                                }

                            }
                            else if (row[LOAITHIETBI] != DBNull.Value && row[PARENT] == DBNull.Value && row[LOAICHUNG] != DBNull.Value)
                            {
                                if (LoaiThietBi.getAll().FirstOrDefault(c => c.ten.ToUpper().Equals(row[LOAITHIETBI].ToString().ToUpper())) == null)
                                {
                                    LoaiThietBi obj = new LoaiThietBi();
                                    obj.ten = row[LOAITHIETBI].ToString();
                                    obj.mota = row[MOTA].ToString();
                                    obj.loaichung = Convert.ToBoolean(row[LOAICHUNG]);
                                    if (obj.add() > 0)
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Pass");
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString(), "Exist");
                                }
                            }
                            else
                            {
                                WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không đủ thông tin)");
                            }
                        }
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                QuanLyTaiSan.Entities.Debug.WriteLine("ExcelDataBaseHelper : ImportNhanVien : " + ex.Message);
                return false;
            }
            finally
            {
            }
        }

        private static void WriteFile(String fileName, String sheet, String stt, String text)
        {
            System.Data.OleDb.OleDbConnection MyConnection = new System.Data.OleDb.OleDbConnection(GetConnectionString(fileName));
            try
            {
                //Ghi file Excel
                System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                string sql = null;
                MyConnection.Open();
                myCommand.Connection = MyConnection;
                sql = String.Format("Update [{0}$] set Pass = '{1}' where STT = {2}", sheet, text, stt);
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                QuanLyTaiSan.Entities.Debug.WriteLine("ExcelDataBaseHelper : WriteFile : " + ex.Message);
                MyConnection.Close();
            }
            finally
            {
                MyConnection.Close();
            }
        }
    }
}
