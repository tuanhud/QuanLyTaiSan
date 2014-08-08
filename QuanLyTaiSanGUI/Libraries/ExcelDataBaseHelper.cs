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
                const int NGAYTAO = 4;
                const int HINHANH = 5;
                const int PASS = 6;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (!row[PASS].Equals("Pass"))
                        {
                            if (row[TENNHANVIEN] != DBNull.Value)
                            {
                                if (NhanVienPT.getAll().FirstOrDefault(c => c.hoten.ToUpper() == row[TENNHANVIEN].ToString().ToUpper()) == null)
                                {
                                    try
                                    {
                                        NhanVienPT obj = new NhanVienPT();
                                        obj.subId = row[MANHANVIEN] != DBNull.Value ? row[MANHANVIEN].ToString() : null;
                                        obj.hoten = row[TENNHANVIEN].ToString();
                                        obj.date_create = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYTAO].ToString()) : DateTime.Now;
                                        obj.sodienthoai = row[SODIENTHOAI].ToString();
                                        if (row[HINHANH] != DBNull.Value)
                                        {
                                            String[] file_names = row[HINHANH].ToString().Split(',');
                                            obj.hinhanhs = AddImage(fileName, file_names);
                                        }
                                        if (obj.add() > 0 && DBInstance.commit() > 0)
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString(), "Pass");
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                                        }
                                    }
                                    catch(Exception ex)
                                    {
                                        Debug.WriteLine("ExcelDataBaseHelper : ImportNhanVien : " + ex.Message);
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
                Debug.WriteLine("ExcelDataBaseHelper : ImportNhanVien : "+ ex.Message);
                return false;
            }
        }

        private static List<HinhAnh> AddImage(String fileName, String[] file_names)
        {
            List<HinhAnh> listHinhs = new List<HinhAnh>();
            try
            {
                foreach (String name in file_names)
                {
                    HinhAnh objHinh = new HinhAnh();
                    String file_name = name.TrimStart().TrimEnd();
                    String fPath = System.IO.Path.GetDirectoryName(fileName) + "\\Images\\" + file_name;
                    if (System.IO.File.Exists(fPath))
                    {
                        objHinh.FILE_NAME = file_name;
                        objHinh.IMAGE = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(fPath);
                        objHinh.MAX_SIZE = 400;
                        if (objHinh.upload(true) > 0)
                        {
                            listHinhs.Add(objHinh);
                        }
                    }
                }
                return listHinhs;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->AddImage: " + ex.Message);
                return listHinhs;
            }
        }

        public static bool ImportViTri(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int MACOSO = 1;
                const int COSO = 2;
                const int MADAY = 3;
                const int DAY = 4;
                const int MATANG = 5;
                const int TANG = 6;
                const int MOTA = 7;
                const int NGAYTAO = 8;
                const int HINHANH = 9;
                const int PASS = 10;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        try
                        {
                            if (row[COSO] != DBNull.Value && !row[PASS].Equals("Pass"))
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
                                                obj.subId = row[MATANG] != DBNull.Value ? row[MATANG].ToString() : null;
                                                obj.ten = row[TANG].ToString();
                                                obj.mota = row[MOTA].ToString();
                                                obj.day = objDay;
                                                obj.date_create = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYTAO].ToString()) : DateTime.Now;
                                                if (row[HINHANH] != DBNull.Value)
                                                {
                                                    String[] file_names = row[HINHANH].ToString().Split(',');
                                                    obj.hinhanhs = AddImage(fileName, file_names);
                                                }
                                                if (obj.add() > 0 && DBInstance.commit() > 0)
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
                                            obj.subId = row[MADAY] != DBNull.Value ? row[MADAY].ToString() : null;
                                            obj.ten = row[DAY].ToString();
                                            obj.mota = row[MOTA].ToString();
                                            obj.coso = objCoSo;
                                            obj.date_create = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYTAO].ToString()) : DateTime.Now;
                                            if (row[HINHANH] != DBNull.Value)
                                            {
                                                String[] file_names = row[HINHANH].ToString().Split(',');
                                                obj.hinhanhs = AddImage(fileName, file_names);
                                            }
                                            if (obj.add() > 0 && DBInstance.commit() > 0)
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
                                        obj.subId = row[MACOSO] != DBNull.Value ? row[MACOSO].ToString() : null;
                                        obj.ten = row[COSO].ToString();
                                        obj.mota = row[MOTA].ToString();
                                        obj.date_create = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYTAO].ToString()) : DateTime.Now;
                                        if (row[HINHANH] != DBNull.Value)
                                        {
                                            String[] file_names = row[HINHANH].ToString().Split(',');
                                            obj.hinhanhs = AddImage(fileName, file_names);
                                        }
                                        if (obj.add() > 0 && DBInstance.commit() > 0)
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
                        catch (Exception ex)
                        {
                            Debug.WriteLine("ExcelDataBaseHelper->ImportViTri: " + ex.Message);
                            WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->ImportViTri: " + ex.Message);
                return false;
            }
        }

        public static bool ImportLoaiThietBi(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int LOAITHIETBI = 1;
                const int MOTA = 2;
                const int PARENT = 3;
                const int LOAICHUNG = 4;
                const int NGAYTAO = 5;
                const int PASS = 6;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        try
                        {
                            if (row[LOAITHIETBI] != DBNull.Value && !row[PASS].Equals("Pass"))
                            {
                                if (row[LOAITHIETBI] != DBNull.Value && row[PARENT] != DBNull.Value && row[LOAICHUNG] != DBNull.Value)
                                {
                                    LoaiThietBi objParent = LoaiThietBi.getAll().FirstOrDefault(c => c.ten.ToUpper().Equals(row[PARENT].ToString().ToUpper()));
                                    if (objParent != null)
                                    {
                                        if (objParent.childs.FirstOrDefault(c => c.ten.ToUpper().Equals(row[LOAITHIETBI].ToString().ToUpper())) == null)
                                        {
                                            if (objParent.loaichung.Equals(Convert.ToBoolean(row[LOAICHUNG])))
                                            {
                                                LoaiThietBi obj = new LoaiThietBi();
                                                obj.ten = row[LOAITHIETBI].ToString();
                                                obj.mota = row[MOTA].ToString();
                                                obj.loaichung = Convert.ToBoolean(row[LOAICHUNG]);
                                                obj.date_create = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYTAO].ToString()) : DateTime.Now;
                                                obj.parent = objParent;
                                                if (obj.add() > 0 && DBInstance.commit() > 0)
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
                                        if (obj.add() > 0 && DBInstance.commit() > 0)
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
                        catch (Exception ex)
                        {
                            WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                            Debug.WriteLine("ExcelDataBaseHelper->ImportLoaiThietBi : " + ex.Message);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->ImportLoaiThietBi : " + ex.Message);
                return false;
            }
        }

        public static bool ImportTinhTrang(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int TINHTRANG = 1;
                const int MOTA = 2;
                const int PASS = 3;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        try
                        {
                            if (row[TINHTRANG] != DBNull.Value && !row[PASS].Equals("Pass"))
                            {
                                if (TinhTrang.getAll().FirstOrDefault(c => c.value.ToUpper().Equals(row[TINHTRANG].ToString().ToUpper())) == null)
                                {
                                    TinhTrang obj = new TinhTrang();
                                    obj.value = row[TINHTRANG].ToString();
                                    obj.mota = row[MOTA].ToString();
                                    obj.key = QuanLyTaiSan.Libraries.StringHelper.CoDauThanhKhongDau(row[TINHTRANG].ToString()).Replace(" ", String.Empty).ToUpper();
                                    if (obj.add() > 0 && DBInstance.commit() > 0)
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
                        }
                        catch (Exception ex)
                        {
                            WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                            Debug.WriteLine("ExcelDataBaseHelper->ImportTinhTrang : " + ex.Message);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->ImportTinhTrang : " + ex.Message);
                return false;
            }
        }

        public static bool ImportPhong(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int MAPHONG = 1;
                const int TENPHONG = 2;
                const int MOTA = 3;
                const int COSO = 4;
                const int DAY = 5;
                const int TANG = 6;
                const int NHANVIENPT = 7;
                const int MANHANVIEN = 8;
                const int NGAYTAO = 9;
                const int HINHANH = 10;
                const int PASS = 11;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        bool ok = false;
                        if (!row[PASS].Equals("Pass"))
                        {
                            if (row[TENPHONG] != DBNull.Value)
                            {
                                if (Phong.getAll().FirstOrDefault(c => c.ten.ToUpper() == row[TENPHONG].ToString().ToUpper()) == null)
                                {
                                    try
                                    {
                                        ViTri objViTri = new ViTri();
                                        CoSo objCoSo = new CoSo();
                                        Dayy objDay = new Dayy();
                                        Tang objTang = new Tang();
                                        if(row[COSO] != DBNull.Value)
                                        {
                                            objCoSo = CoSo.getAll().Where(c => c.ten.ToUpper().Equals(row[COSO].ToString().ToUpper())).FirstOrDefault();
                                            if (objCoSo != null && objCoSo.id > 0)
                                            {
                                                if (row[DAY] != DBNull.Value && objCoSo.days.Count > 0)
                                                {
                                                    objDay = objCoSo.days.Where(c => c.ten.ToUpper().Equals(row[DAY].ToString().ToUpper())).FirstOrDefault();
                                                    if (objDay != null && objDay.id > 0)
                                                    {
                                                        if (row[TANG] != DBNull.Value && objDay.tangs.Count > 0)
                                                        {
                                                            objTang = objDay.tangs.Where(c => c.ten.ToUpper().Equals(row[TANG].ToString().ToUpper())).FirstOrDefault();
                                                            if (objTang != null && objTang.id > 0)
                                                            {
                                                                objViTri.coso = objCoSo;
                                                                objViTri.day = objDay;
                                                                objViTri.tang = objTang;
                                                                ok = true;
                                                            }
                                                            else
                                                            {
                                                                WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có tầng)");
                                                            }
                                                        }
                                                        else if (row[TANG] == DBNull.Value)
                                                        {
                                                            objViTri.coso = objCoSo;
                                                            objViTri.day = objDay;
                                                            objViTri.tang = new Tang();
                                                            ok = true;
                                                        }
                                                        else
                                                        {
                                                            WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có tầng)");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có dãy)");
                                                    }
                                                }
                                                else if (row[DAY] == DBNull.Value)
                                                {
                                                    objViTri.coso = objCoSo;
                                                    objViTri.day = new Dayy();
                                                    objViTri.tang = new Tang();
                                                    ok = true;
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

                                        if (ok)
                                        {
                                            Phong obj = new Phong();
                                            obj.subId = row[MAPHONG] != DBNull.Value ? row[MAPHONG].ToString() : null;
                                            obj.vitri = objViTri;
                                            obj.ten = row[TENPHONG].ToString();
                                            obj.date_create = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYTAO].ToString()) : DateTime.Now;
                                            obj.mota = row[MOTA].ToString();
                                            if (row[HINHANH] != DBNull.Value)
                                            {
                                                String[] file_names = row[HINHANH].ToString().Split(',');
                                                obj.hinhanhs = AddImage(fileName, file_names);
                                            }

                                            if(row[NHANVIENPT] != DBNull.Value)
                                            {
                                                if (NhanVienPT.getAll().Where(c => c.hoten.ToUpper() == row[NHANVIENPT].ToString().ToUpper()).Count() == 1)
                                                {
                                                    obj.nhanvienpt = NhanVienPT.getAll().FirstOrDefault(c => c.hoten.ToUpper() == row[NHANVIENPT].ToString().ToUpper());
                                                }
                                                else if (NhanVienPT.getAll().Where(c => c.hoten.ToUpper() == row[NHANVIENPT].ToString().ToUpper()).Count() > 1)
                                                {
                                                    if (row[MANHANVIEN] != DBNull.Value)
                                                    {
                                                        if (NhanVienPT.getAll().Where(c => c.hoten.ToUpper() == row[NHANVIENPT].ToString().ToUpper() && c.subId.ToUpper() == row[MANHANVIEN].ToString().ToUpper()).Count() == 1)
                                                        {
                                                            obj.nhanvienpt = NhanVienPT.getAll().FirstOrDefault(c => c.hoten.ToUpper() == row[NHANVIENPT].ToString().ToUpper() && c.subId.ToUpper() == row[MANHANVIEN].ToString().ToUpper());
                                                        }
                                                        else
                                                        {
                                                            WriteFile(fileName, sheet, row[STT].ToString(), "Pass - Error (Mã nhân viên không đúng)");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        WriteFile(fileName, sheet, row[STT].ToString(), "Pass - Error (Nhân viên trùng tên nhưng không có mã)");
                                                    }
                                                }
                                            }

                                            if (obj.add() > 0 && DBInstance.commit() > 0)
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
                                            //WriteFile(fileName, sheet, row[STT].ToString(), "Error (Vị trí lỗi)");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("ExcelDataBaseHelper->ImportPhong: " + ex.Message);
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
                Debug.WriteLine("ExcelDataBaseHelper->ImportPhong: " + ex.Message);
                return false;
            }
        }

        public static bool ImportThietBiChung(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int LOAITB = 1;
                const int PHONG = 2;
                const int TINHTRANG = 3;
                const int SOLUONG = 4;
                const int NGAYTAO = 5;
                const int NGAYLAP = 6;
                const int HINHANH = 7;
                const int PASS = 8;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (!row[PASS].Equals("Pass"))
                        {
                            bool ok = false;
                            if (row[LOAITB] != DBNull.Value && row[PHONG] != DBNull.Value && row[TINHTRANG] != DBNull.Value && row[SOLUONG] != DBNull.Value)
                            {
                                LoaiThietBi objLoai = LoaiThietBi.getAll().FirstOrDefault(c => c.ten.ToUpper() == row[LOAITB].ToString().ToUpper());
                                if (objLoai != null)
                                {
                                    try
                                    {
                                        TinhTrang objTinhTrang = new TinhTrang();
                                        Phong objPhong = Phong.getAll().FirstOrDefault(c => c.ten.ToUpper() == row[PHONG].ToString().ToUpper());
                                        if (objPhong != null)
                                        {
                                            objTinhTrang = TinhTrang.getAll().FirstOrDefault(c => c.value.ToUpper() == row[TINHTRANG].ToString().ToUpper());
                                            if (objTinhTrang != null)
                                            {
                                                ok = true;
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có tình trạng)");
                                            }
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có phòng)");
                                        }
                                        if (ok)
                                        {
                                            if (objLoai.thietbis.FirstOrDefault(c => c.ten.ToUpper() == row[LOAITB].ToString().ToUpper()) == null)
                                            {
                                                ThietBi objThietBi = new ThietBi();
                                                objThietBi.ten = row[LOAITB].ToString();
                                                objThietBi.loaithietbi = objLoai;
                                                objThietBi.date_create = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYTAO].ToString()) : DateTime.Now;
                                                if (row[HINHANH] != DBNull.Value)
                                                {
                                                    String[] file_names = row[HINHANH].ToString().Split(',');
                                                    objThietBi.hinhanhs = AddImage(fileName, file_names);
                                                }
                                                if (objThietBi.add() > 0 && DBInstance.commit() > 0)
                                                {
                                                    CTThietBi obj = new CTThietBi();
                                                    obj.thietbi = objThietBi;
                                                    obj.phong = objPhong;
                                                    obj.tinhtrang = objTinhTrang;
                                                    obj.soluong = Convert.ToInt32(row[SOLUONG].ToString());
                                                    obj.mota = "Import";
                                                    obj.ngay = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYLAP].ToString()) : DateTime.Now;
                                                    if (obj.add() > 0 && DBInstance.commit() > 0)
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
                                                    WriteFile(fileName, sheet, row[STT].ToString(), "Error (Lỗi khi thêm thiết bị)");
                                                }
                                            }
                                            else
                                            {
                                                ThietBi objThietBi = objLoai.thietbis.FirstOrDefault(c => c.ten.ToUpper() == row[LOAITB].ToString().ToUpper());
                                                CTThietBi obj = new CTThietBi();
                                                obj.thietbi = objThietBi;
                                                obj.phong = objPhong;
                                                obj.tinhtrang = objTinhTrang;
                                                obj.soluong = Convert.ToInt32(row[SOLUONG].ToString());
                                                obj.mota = "Import";
                                                obj.ngay = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYLAP].ToString()) : DateTime.Now;
                                                if (obj.add() > 0 && DBInstance.commit() > 0)
                                                {
                                                    WriteFile(fileName, sheet, row[STT].ToString(), "Pass");
                                                }
                                                else
                                                {
                                                    WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("ExcelDataBaseHelper->ImportThietBiChung: " + ex.Message);
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có loại thiết bị)");
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
                Debug.WriteLine("ExcelDataBaseHelper->ImportThietBiChung: " + ex.Message);
                return false;
            }
        }

        public static bool ImportThietBiRieng(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int MATB = 1;
                const int TENTB = 2;
                const int MOTA = 3;
                const int LOAITB = 4;
                const int PHONG = 5;
                const int TINHTRANG = 6;
                const int NGAYTAO = 7;
                const int NGAYMUA = 8;
                const int NGAYLAP = 9;
                const int HINHANH = 10;
                const int PASS = 11;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (!row[PASS].Equals("Pass"))
                        {
                            bool ok = false;
                            if (row[TENTB] != DBNull.Value && row[LOAITB] != DBNull.Value && row[PHONG] != DBNull.Value && row[TINHTRANG] != DBNull.Value)
                            {
                                LoaiThietBi objLoai = LoaiThietBi.getAll().FirstOrDefault(c => c.ten.ToUpper() == row[LOAITB].ToString().ToUpper());
                                if (objLoai != null)
                                {
                                    try
                                    {
                                        TinhTrang objTinhTrang = new TinhTrang();
                                        Phong objPhong = Phong.getAll().FirstOrDefault(c => c.ten.ToUpper() == row[PHONG].ToString().ToUpper());
                                        if (objPhong != null)
                                        {
                                            objTinhTrang = TinhTrang.getAll().FirstOrDefault(c => c.value.ToUpper() == row[TINHTRANG].ToString().ToUpper());
                                            if (objTinhTrang != null)
                                            {
                                                ok = true;
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có tình trạng)");
                                            }
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có phòng)");
                                        }
                                        if (ok)
                                        {
                                            ThietBi objThietBi = new ThietBi();
                                            objThietBi.subId = row[MATB] != DBNull.Value ? row[MATB].ToString() : null;
                                            objThietBi.ten = row[TENTB].ToString();
                                            objThietBi.loaithietbi = objLoai;
                                            objThietBi.mota = row[MOTA].ToString();
                                            objThietBi.date_create = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYTAO].ToString()) : DateTime.Now;
                                            objThietBi.ngaymua = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYMUA].ToString()) : DateTime.Now;
                                            if (row[HINHANH] != DBNull.Value)
                                            {
                                                String[] file_names = row[HINHANH].ToString().Split(',');
                                                objThietBi.hinhanhs = AddImage(fileName, file_names);
                                            }
                                            if (objThietBi.add() > 0 && DBInstance.commit() > 0)
                                            {
                                                CTThietBi obj = new CTThietBi();
                                                obj.thietbi = objThietBi;
                                                obj.phong = objPhong;
                                                obj.tinhtrang = objTinhTrang;
                                                obj.soluong = 1;
                                                obj.mota = "Import";
                                                obj.ngay = row[NGAYTAO] != DBNull.Value ? DateTime.Parse(row[NGAYLAP].ToString()) : DateTime.Now;
                                                if (obj.add() > 0 && DBInstance.commit() > 0)
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
                                                WriteFile(fileName, sheet, row[STT].ToString(), "Error (Lỗi khi thêm thiết bị)");
                                            }
                                        }
                                        
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("ExcelDataBaseHelper->ImportThietBiChung: " + ex.Message);
                                        WriteFile(fileName, sheet, row[STT].ToString(), "Error");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString(), "Error (Không có loại thiết bị)");
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
                Debug.WriteLine("ExcelDataBaseHelper->ImportThietBiChung: " + ex.Message);
                return false;
            }
        }

        private static void WriteFile(String fileName, String sheet, String stt, String text)
        {
            try
            {
                if (!stt.Equals(""))
                {
                    //Ghi file Excel
                    using (System.Data.OleDb.OleDbConnection MyConnection = new System.Data.OleDb.OleDbConnection(GetConnectionString(fileName)))
                    {
                        System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                        string sql = null;
                        MyConnection.Open();
                        myCommand.Connection = MyConnection;
                        sql = String.Format("Update [{0}$] set Pass = '{1}' where STT = {2}", sheet, text, stt);
                        myCommand.CommandText = sql;
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->WriteFile : " + ex.Message);
            }
        }
    }
}
