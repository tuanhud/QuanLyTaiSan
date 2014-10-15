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

        public static bool ImportTaiSan(String fileName, String sheet, DonVi objDonVi = null)
        {
            try
            {
                int line = 0;
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int SUBID = 1;
                const int TEN = 2;
                const int NSX = 3;
                const int NGAY = 4;
                const int DONGIA = 5;
                const int PASS = 6;
                const int PHONG = 7;
                LoaiTaiSan objLoaiTS = null;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        line++;
                        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import... " +
                            String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", (line * 1.0 / lines) * 100) + "%");
                        if (row[PASS] == DBNull.Value || !row[PASS].Equals("Pass"))
                        {
                            if (row[TEN] != DBNull.Value && !String.IsNullOrWhiteSpace(row[TEN].ToString()))
                            {
                                if (row[SUBID] == DBNull.Value || String.IsNullOrWhiteSpace(row[SUBID].ToString()))
                                {
                                    objLoaiTS = getLoai(row[TEN].ToString());
                                }
                                else
                                {
                                    try
                                    {
                                        if (objDonVi == null)
                                        {
                                            TaiSan obj = new TaiSan();
                                            obj.subId = row[SUBID].ToString().Trim();
                                            obj.ten = row[TEN].ToString().Trim();
                                            obj.nuocsx = row[NSX] != DBNull.Value ? row[NSX].ToString().Trim() : "";
                                            String str = row[DONGIA].ToString().Trim().Replace(" ", "");
                                            long dongia = long.Parse(str);
                                            obj.dongia = dongia;
                                            obj.loaitaisan = objLoaiTS;
                                            CTTaiSan objCTTaiSan = new CTTaiSan();
                                            objCTTaiSan.chungtu = new ChungTu();
                                            objCTTaiSan.taisan = obj;
                                            objCTTaiSan.ngay = row[NGAY] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY]) : null;
                                            if (TinhTrang.getQuery().FirstOrDefault(c => c.value.Equals("Đang sử dụng")) == null)
                                            {
                                                TinhTrang objTinhTrang = new TinhTrang();
                                                objTinhTrang.value = "Đang sử dụng";
                                                objTinhTrang.add();
                                                DBInstance.commit();
                                            }
                                            objCTTaiSan.tinhtrang = TinhTrang.getQuery().FirstOrDefault(c => c.value.Equals("Đang sử dụng"));
                                            objCTTaiSan.soluong = 1;
                                            if (objCTTaiSan.add() > 0 && DBInstance.commit() > 0)
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                            }
                                        }
                                        else
                                        {
                                            String subId = row[SUBID].ToString().Trim().ToUpper();
                                            TaiSan obj = TaiSan.getQuery().Where(c => c.subId.ToString().ToUpper().Equals(subId)).FirstOrDefault();
                                            if (obj != null)
                                            {
                                                CTTaiSan objCTTaiSan2 = CTTaiSan.getQuery().Where(c => c.taisan_id == obj.id).FirstOrDefault();
                                                if (objCTTaiSan2 != null)
                                                {
                                                    Phong objPhong = null;
                                                    ViTri objViTri = null;
                                                    if(row[PHONG] != DBNull.Value)
                                                    {
                                                        string phong = row[PHONG].ToString().Trim();
                                                        objPhong = Phong.getQuery().Where(c => c.ten.Equals(phong)).FirstOrDefault();
                                                        if (objPhong == null)
                                                        {
                                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có phòng)");
                                                            continue;
                                                        }
                                                        else
                                                            objViTri = objPhong.vitri;
                                                    }

                                                    if (objCTTaiSan2.chuyenDonVi(objDonVi, null, objViTri, objPhong, objCTTaiSan2.parent, objCTTaiSan2.chungtu, objCTTaiSan2.soluong, "", objCTTaiSan2.ngay) > 0 && DBInstance.commit() > 0)
                                                    {
                                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                                    }
                                                    else
                                                    {
                                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                                    }
                                                }
                                                else
                                                {
                                                    CTTaiSan objCTTaiSan = new CTTaiSan();
                                                    objCTTaiSan.taisan = obj;
                                                    objCTTaiSan.chungtu = new ChungTu();
                                                    objCTTaiSan.ngay = row[NGAY] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY]) : null;
                                                    if (TinhTrang.getQuery().FirstOrDefault(c => c.value.Equals("Đang sử dụng")) == null)
                                                    {
                                                        TinhTrang objTinhTrang = new TinhTrang();
                                                        objTinhTrang.value = "Đang sử dụng";
                                                        objTinhTrang.add();
                                                        DBInstance.commit();
                                                    }
                                                    objCTTaiSan.tinhtrang = TinhTrang.getQuery().FirstOrDefault(c => c.value.Equals("Đang sử dụng"));
                                                    objCTTaiSan.soluong = 1;
                                                    if (objCTTaiSan.add() > 0)
                                                    {
                                                        Phong objPhong = null;
                                                        ViTri objViTri = null;
                                                        if (row[PHONG] != DBNull.Value)
                                                        {
                                                            string phong = row[PHONG].ToString().Trim();
                                                            objPhong = Phong.getQuery().Where(c => c.ten.Equals(phong)).FirstOrDefault();
                                                            if (objPhong == null)
                                                            {
                                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có phòng)");
                                                                continue;
                                                            }
                                                            else
                                                                objViTri = objPhong.vitri;
                                                        }
                                                        if (objCTTaiSan.chuyenDonVi(objDonVi, null, objViTri, objPhong, objCTTaiSan.parent, objCTTaiSan.chungtu, objCTTaiSan.soluong, "", objCTTaiSan.ngay) > 0 && DBInstance.commit() > 0)
                                                        {
                                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                                        }
                                                        else
                                                        {
                                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                obj = new TaiSan();
                                                obj.subId = row[SUBID].ToString().Trim();
                                                obj.ten = row[TEN].ToString().Trim();
                                                obj.nuocsx = row[NSX] != DBNull.Value ? row[NSX].ToString().Trim() : "";
                                                String str = row[DONGIA].ToString().Trim().Replace(" ", "");
                                                long dongia = long.Parse(str);
                                                obj.dongia = dongia;
                                                obj.loaitaisan = objLoaiTS;
                                                CTTaiSan objCTTaiSan = new CTTaiSan();
                                                objCTTaiSan.taisan = obj;
                                                objCTTaiSan.ngay = row[NGAY] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY]) : null;
                                                if (TinhTrang.getQuery().FirstOrDefault(c => c.value.Equals("Đang sử dụng")) == null)
                                                {
                                                    TinhTrang objTinhTrang = new TinhTrang();
                                                    objTinhTrang.value = "Đang sử dụng";
                                                    objTinhTrang.add();
                                                    DBInstance.commit();
                                                }
                                                objCTTaiSan.tinhtrang = TinhTrang.getQuery().FirstOrDefault(c => c.value.Equals("Đang sử dụng"));
                                                objCTTaiSan.soluong = 1;
                                                if (objCTTaiSan.add() > 0)
                                                {
                                                    Phong objPhong = null;
                                                    ViTri objViTri = null;
                                                    if (row[PHONG] != DBNull.Value)
                                                    {
                                                        string phong = row[PHONG].ToString().Trim();
                                                        objPhong = Phong.getQuery().Where(c => c.ten.Equals(phong)).FirstOrDefault();
                                                        if (objPhong == null)
                                                        {
                                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có phòng)");
                                                            continue;
                                                        }
                                                        else
                                                            objViTri = objPhong.vitri;
                                                    }
                                                    if (objCTTaiSan.chuyenDonVi(objDonVi, null, objViTri, objPhong, objCTTaiSan.parent, objCTTaiSan.chungtu, objCTTaiSan.soluong, "", objCTTaiSan.ngay) > 0 && DBInstance.commit() > 0)
                                                    {
                                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                                    }
                                                    else
                                                    {
                                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                                    }
                                                }
                                                else
                                                {
                                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("ExcelDataBaseHelper->ImportTaiSan: " + ex.Message);
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                    }
                                }
                            }
                            else
                            {
                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không đủ thông tin)");
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->ImportTaiSan: " + ex.Message);
                return false;
            }
        }

        public static bool ImportChungTu(String fileName, String sheet)
        {
            try
            {
                int line = 0;
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int SOHIEU = 1;
                const int NGAY = 2;
                const int TEN = 3;
                const int DONGIA = 6;
                const int PASS = 8;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        line++;
                        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import... " +
                            String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", (line * 1.0 / lines) * 100) + "%");
                        if (row[PASS] == DBNull.Value || !row[PASS].Equals("Pass"))
                        {
                            if (row[TEN] != DBNull.Value && !String.IsNullOrWhiteSpace(row[TEN].ToString()) && row[DONGIA] != DBNull.Value)
                            {
                                String ten = row[TEN].ToString().Trim().ToUpper();
                                String str = row[DONGIA].ToString().Trim().Replace(" ", "");
                                long dongia = long.Parse(str);
                                CTTaiSan obj = CTTaiSan.getQuery().Where(c => c.taisan.ten.ToUpper().Equals(ten) && c.taisan.dongia.Equals(dongia) && (c.chungtu == null || (c.chungtu.sohieu == null && c.chungtu.ngay == null))).FirstOrDefault();
                                if (obj != null)
                                {
                                    if (obj.chungtu == null)
                                    {
                                        ChungTu objChungTu = new ChungTu();
                                        objChungTu.sohieu = row[SOHIEU] != DBNull.Value ? row[SOHIEU].ToString().Trim() : null;
                                        objChungTu.ngay = row[NGAY] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY]) : null;
                                        obj.chungtu = objChungTu;
                                    }
                                    else
                                    {
                                        obj.chungtu.sohieu = row[SOHIEU] != DBNull.Value ? row[SOHIEU].ToString().Trim() : null;
                                        obj.chungtu.ngay = row[NGAY] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY]) : null;
                                    }
                                    if (obj.update() > 0 && DBInstance.commit() > 0)
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không tìm thấy tài sản)");
                                }
                            }
                            else
                            {
                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không đủ thông tin)");
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->ImportTaiSan: " + ex.Message);
                return false;
            }
        }

        public static bool ImportDonVi(String fileName, String sheetDonVi, String sheetTaiSan)
        {
            try
            {
                DonVi objDonVi = null;
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int SUBID = 1;
                const int TEN = 2;
                const int PARENT = 3;
                const int LOAI = 4;
                const int PASS = 5;
                dt = OpenFile(fileName, sheetDonVi);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (row[PASS] == DBNull.Value || !row[PASS].Equals("Pass"))
                        {
                            if (row[SUBID] != DBNull.Value && row[TEN] != DBNull.Value && row[LOAI] != DBNull.Value)
                            {
                                try
                                {
                                    String _subId = row[SUBID].ToString().Trim().ToUpper();
                                    DonVi obj2 = DonVi.getQuery().Where(c => c.subId.ToUpper().Equals(_subId)).FirstOrDefault();
                                    if (obj2 == null)
                                    {
                                        DonVi obj = new DonVi();
                                        obj.subId = row[SUBID] != DBNull.Value ? row[SUBID].ToString().Trim() : null;
                                        obj.ten = row[TEN].ToString().Trim();
                                        obj.parent = row[PARENT] != DBNull.Value ? getParent(row[PARENT].ToString()) : null;
                                        obj.loaidonvi = getLoaiDonVi(row[LOAI].ToString());
                                        if (obj.add() > 0 && DBInstance.commit() > 0)
                                        {
                                            objDonVi = obj;
                                            WriteFile(fileName, sheetDonVi, row[STT].ToString().Trim(), "Pass");
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheetDonVi, row[STT].ToString().Trim(), "Error");
                                        }
                                    }
                                    else
                                    {
                                        objDonVi = obj2;
                                        WriteFile(fileName, sheetDonVi, row[STT].ToString().Trim(), "Exist");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine("ExcelDataBaseHelper->ImportDonVi: " + ex.Message);
                                    WriteFile(fileName, sheetDonVi, row[STT].ToString().Trim(), "Error");
                                }
                            }
                            else
                            {
                                WriteFile(fileName, sheetDonVi, row[STT].ToString().Trim(), "Error (Không đủ thông tin)");
                            }
                        }
                        else
                        {
                            String _subId = row[SUBID].ToString().Trim().ToUpper();
                            DonVi obj2 = DonVi.getQuery().Where(c => c.subId.ToUpper().Equals(_subId)).FirstOrDefault();
                            if(obj2 != null)
                                objDonVi = obj2;
                        }
                    }
                    if (objDonVi != null)
                        ImportTaiSan(fileName, sheetTaiSan, objDonVi);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->ImportDonVi: " + ex.Message);
                return false;
            }
        }

        public static bool ImportLoaiTS(String fileName, String sheet)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int TEN = 1;
                const int DONVITINH = 2;
                const int LOAI = 3;
                const int PARENT = 4;
                const int PASS = 5;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (row[PASS] == DBNull.Value || !row[PASS].Equals("Pass"))
                        {
                            if (row[TEN] != DBNull.Value && row[LOAI] != DBNull.Value)
                            {
                                try
                                {
                                    if (row[PARENT] != DBNull.Value)
                                    {
                                        String tenParent = row[PARENT].ToString().Trim().ToUpper();
                                        LoaiTaiSan objParent = LoaiTaiSan.getQuery().Where(c => c.ten.ToUpper().Equals(tenParent)).FirstOrDefault();
                                        if (objParent != null)
                                        {
                                            String ten = row[TEN].ToString().Trim().ToUpper();
                                            LoaiTaiSan obj = LoaiTaiSan.getQuery().Where(c => c.ten.ToUpper().Equals(ten)).FirstOrDefault();
                                            if (obj == null)
                                            {
                                                obj = new LoaiTaiSan();
                                                obj.ten = row[TEN].ToString().Trim();
                                                obj.parent = objParent;
                                                obj.donvitinh = row[DONVITINH] != DBNull.Value ? getDonViTinh(row[DONVITINH].ToString()) : null;
                                                obj.huuhinh = Convert.ToBoolean(row[LOAI]);
                                                if (obj.add() > 0 && DBInstance.commit() > 0)
                                                {
                                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                                }
                                                else
                                                {
                                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                                }
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Exist");
                                            }
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có loại tài sản cha)");
                                        }
                                    }
                                    else
                                    {
                                        String ten = row[TEN].ToString().Trim().ToUpper();
                                        LoaiTaiSan obj = LoaiTaiSan.getQuery().Where(c => c.ten.ToUpper().Equals(ten)).FirstOrDefault();
                                        if (obj == null)
                                        {
                                            obj = new LoaiTaiSan();
                                            obj.ten = row[TEN].ToString().Trim();
                                            obj.donvitinh = row[DONVITINH] != DBNull.Value ? getDonViTinh(row[DONVITINH].ToString()) : null;
                                            obj.huuhinh = Convert.ToBoolean(row[LOAI]);
                                            if (obj.add() > 0 && DBInstance.commit() > 0)
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                            }
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Exist");
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine("ExcelDataBaseHelper->ImportDonVi: " + ex.Message);
                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                }
                            }
                            else
                            {
                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không đủ thông tin)");
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->ImportDonVi: " + ex.Message);
                return false;
            }
        }

        private static LoaiTaiSan getLoai(String _ten)
        {
            try
            {
                String ten = _ten.Trim();
                ten = ten.Replace("- ", "");
                LoaiTaiSan obj = LoaiTaiSan.getQuery().Where(c => c.ten.ToUpper().Equals(ten.ToUpper())).FirstOrDefault();
                if (obj == null)
                {
                    obj = new LoaiTaiSan();
                    obj.ten = ten;
                    obj.huuhinh = true;
                    obj.donvitinh = null;
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

        private static DonViTinh getDonViTinh(String _ten)
        {
            try
            {
                String ten = _ten.Trim();
                if (String.IsNullOrEmpty(ten))
                    return null;
                DonViTinh obj = DonViTinh.getQuery().Where(c => c.ten.ToUpper().Equals(ten.ToUpper())).FirstOrDefault();
                if (obj == null)
                {
                    obj = new DonViTinh();
                    obj.ten = ten;
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

        private static LoaiDonVi getLoaiDonVi(String _ten)
        {
            try
            {
                String ten = _ten.Trim();
                LoaiDonVi obj = LoaiDonVi.getQuery().Where(c => c.ten.ToUpper().Equals(ten.ToUpper())).FirstOrDefault();
                if (obj == null)
                {
                    obj = new LoaiDonVi();
                    obj.ten = ten;
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

        private static DonVi getParent(String _ten)
        {
            try
            {
                String ten = _ten.Trim();
                DonVi obj = DonVi.getQuery().Where(c => c.ten.ToUpper().Equals(ten.ToUpper())).FirstOrDefault();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public static bool ImportViTri(String fileName, String sheet)
        {
            try
            {
                int line = 0;
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int MACOSO = 1;
                const int COSO = 2;
                const int MADAY = 3;
                const int DAY = 4;
                const int MATANG = 5;
                const int TANG = 6;
                const int MOTA = 7;
                const int PASS = 8;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        try
                        {
                            line++;
                            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Import Vị trí... " +
                                String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.0}", (line * 1.0 / lines) * 100) + "%");
                            if (row[COSO] != DBNull.Value && !row[PASS].Equals("Pass"))
                            {
                                if (row[COSO] != DBNull.Value && row[DAY] != DBNull.Value && row[TANG] != DBNull.Value)
                                {
                                    CoSo objCoSo = CoSo.getAll().FirstOrDefault(c => c.ten.ToUpper().Equals(row[COSO].ToString().Trim().ToUpper()));
                                    if (objCoSo != null)
                                    {
                                        Dayy objDay = objCoSo.days.FirstOrDefault(c => c.ten.ToUpper().Equals(row[DAY].ToString().Trim().ToUpper()));
                                        if (objDay != null)
                                        {
                                            if (objDay.tangs.FirstOrDefault(c => c.ten.ToUpper().Equals(row[TANG].ToString().Trim().ToUpper())) == null)
                                            {
                                                Tang obj = new Tang();
                                                obj.subId = row[MATANG] != DBNull.Value ? row[MATANG].ToString().Trim() : null;
                                                obj.ten = row[TANG].ToString().Trim();
                                                obj.mota = row[MOTA].ToString().Trim();
                                                obj.day = objDay;
                                                if (obj.add() > 0 && DBInstance.commit() > 0)
                                                {
                                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                                }
                                                else
                                                {
                                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                                }
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Exist");
                                            }
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có dãy)");
                                        }
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có cơ sở)");
                                    }

                                }
                                else if (row[COSO] != DBNull.Value && row[DAY] != DBNull.Value && row[TANG] == DBNull.Value)
                                {
                                    CoSo objCoSo = CoSo.getAll().FirstOrDefault(c => c.ten.ToUpper().Equals(row[COSO].ToString().Trim().ToUpper()));
                                    if (objCoSo != null)
                                    {
                                        if (objCoSo.days.FirstOrDefault(c => c.ten.ToUpper().Equals(row[DAY].ToString().Trim().ToUpper())) == null)
                                        {
                                            Dayy obj = new Dayy();
                                            obj.subId = row[MADAY] != DBNull.Value ? row[MADAY].ToString().Trim() : null;
                                            obj.ten = row[DAY].ToString().Trim();
                                            obj.mota = row[MOTA].ToString().Trim();
                                            obj.coso = objCoSo;
                                            if (obj.add() > 0 && DBInstance.commit() > 0)
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                            }
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Exist");
                                        }
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có cơ sở)");
                                    }

                                }
                                else if (row[COSO] != DBNull.Value && row[DAY] == DBNull.Value && row[TANG] == DBNull.Value)
                                {
                                    if (CoSo.getAll().FirstOrDefault(c => c.ten.ToUpper().Equals(row[COSO].ToString().Trim().ToUpper())) == null)
                                    {
                                        CoSo obj = new CoSo();
                                        obj.subId = row[MACOSO] != DBNull.Value ? row[MACOSO].ToString().Trim() : null;
                                        obj.ten = row[COSO].ToString().Trim();
                                        obj.mota = row[MOTA].ToString().Trim();
                                        if (obj.add() > 0 && DBInstance.commit() > 0)
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                        }
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Exist");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không đủ thông tin)");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("ExcelDataBaseHelper->ImportViTri: " + ex.Message);
                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
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

        public static bool ImportLoaiPhong(String fileName, String sheet)
        {
            try
            {
                int line = 0;
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int LOAIPHONG = 1;
                const int MOTA = 2;
                const int PASS = 3;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        try
                        {
                            line++;
                            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Import Loại phòng... " +
                                String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.0}", (line * 1.0 / lines) * 100) + "%");
                            if (row[LOAIPHONG] != DBNull.Value && !row[PASS].Equals("Pass"))
                            {
                                if (LoaiPhong.getAll().FirstOrDefault(c => c.ten.ToUpper().Equals(row[LOAIPHONG].ToString().Trim().ToUpper())) == null)
                                {
                                    LoaiPhong obj = new LoaiPhong();
                                    obj.ten = row[LOAIPHONG].ToString().Trim();
                                    obj.mota = row[MOTA].ToString().Trim();
                                    if (obj.add() > 0 && DBInstance.commit() > 0)
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Exist");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                            Debug.WriteLine("ExcelDataBaseHelper->ImportLoaiPhong: " + ex.Message);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->ImportLoaiPhong: " + ex.Message);
                return false;
            }
        }

        public static bool ImportPhong(String fileName, String sheet)
        {
            try
            {
                int line = 0;
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int MAPHONG = 1;
                const int TENPHONG = 2;
                const int LOAIPHONG = 3;
                const int SOCHONGOI = 4;
                const int MOTA = 5;
                const int COSO = 6;
                const int DAY = 7;
                const int TANG = 8;
                const int PASS = 9;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        line++;
                        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Import Phòng... " +
                            String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.0}", (line * 1.0 / lines) * 100) + "%");
                        bool ok = false;
                        if (!row[PASS].Equals("Pass"))
                        {
                            if (row[TENPHONG] != DBNull.Value)
                            {
                                if (Phong.getAll().FirstOrDefault(c => c.ten.ToUpper() == row[TENPHONG].ToString().Trim().ToUpper()) == null)
                                {
                                    try
                                    {
                                        ViTri objViTri = new ViTri();
                                        CoSo objCoSo = new CoSo();
                                        Dayy objDay = new Dayy();
                                        Tang objTang = new Tang();
                                        LoaiPhong objLoai = new LoaiPhong();
                                        if (row[COSO] != DBNull.Value)
                                        {
                                            objCoSo = CoSo.getAll().Where(c => c.ten.ToUpper().Equals(row[COSO].ToString().Trim().ToUpper())).FirstOrDefault();
                                            if (objCoSo != null && objCoSo.id != Guid.Empty)
                                            {
                                                if (row[DAY] != DBNull.Value && objCoSo.days.Count > 0)
                                                {
                                                    objDay = objCoSo.days.Where(c => c.ten.ToUpper().Equals(row[DAY].ToString().Trim().ToUpper())).FirstOrDefault();
                                                    if (objDay != null && objDay.id != Guid.Empty)
                                                    {
                                                        if (row[TANG] != DBNull.Value && objDay.tangs.Count > 0)
                                                        {
                                                            objTang = objDay.tangs.Where(c => c.ten.ToUpper().Equals(row[TANG].ToString().Trim().ToUpper())).FirstOrDefault();
                                                            if (objTang != null && objTang.id != Guid.Empty)
                                                            {
                                                                objViTri.coso = objCoSo;
                                                                objViTri.day = objDay;
                                                                objViTri.tang = objTang;
                                                                ok = true;
                                                            }
                                                            else
                                                            {
                                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có tầng)");
                                                            }
                                                        }
                                                        else if (row[TANG] == DBNull.Value)
                                                        {
                                                            objViTri.coso = objCoSo;
                                                            objViTri.day = objDay;
                                                            objViTri.tang = null;
                                                            ok = true;
                                                        }
                                                        else
                                                        {
                                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có tầng)");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có dãy)");
                                                    }
                                                }
                                                else if (row[DAY] == DBNull.Value)
                                                {
                                                    objViTri.coso = objCoSo;
                                                    objViTri.day = null;
                                                    objViTri.tang = null;
                                                    ok = true;
                                                }
                                                else
                                                {
                                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có dãy)");
                                                }
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có cơ sở)");
                                            }
                                        }

                                        if (row[LOAIPHONG] != DBNull.Value)
                                        {
                                            objLoai = LoaiPhong.getAll().Where(c => c.ten.ToUpper().Equals(row[LOAIPHONG].ToString().Trim().ToUpper())).FirstOrDefault();
                                            if (objLoai == null || objLoai.id == Guid.Empty)
                                            {
                                                objLoai = new LoaiPhong();
                                                objLoai.ten = row[LOAIPHONG].ToString().Trim();
                                                objLoai.mota = row[LOAIPHONG].ToString().Trim();
                                                //ok = false;
                                                //WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có loại phòng)");
                                            }
                                        }
                                        else
                                        {
                                            ok = false;
                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có loại phòng)");
                                        }

                                        if (ok)
                                        {
                                            Phong obj = new Phong();
                                            obj.subId = row[MAPHONG] != DBNull.Value ? row[MAPHONG].ToString().Trim() : null;
                                            obj.vitri = objViTri;
                                            obj.ten = row[TENPHONG].ToString().Trim();
                                            obj.sochongoi = row[SOCHONGOI] != DBNull.Value ? Convert.ToInt32(row[SOCHONGOI].ToString()) : 0;
                                            obj.mota = row[MOTA].ToString().Trim();
                                            obj.loaiphong = objLoai;
                                            if (obj.add() > 0 && DBInstance.commit() > 0)
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("ExcelDataBaseHelper->ImportPhong: " + ex.Message);
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Exist");
                                }
                            }
                            else
                            {
                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không đủ thông tin)");
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
                        sql = String.Format("Update [{0}$] set PASS = @pass where STT = @stt", sheet);
                        myCommand.CommandText = sql;
                        myCommand.Parameters.AddWithValue("@pass", text);
                        myCommand.Parameters.AddWithValue("@stt", stt);
                        myCommand.ExecuteNonQuery();
                        MyConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->WriteFile : " + ex.Message);
            }
        }
    }
}
