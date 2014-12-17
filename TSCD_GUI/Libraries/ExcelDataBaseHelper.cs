using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TSCD.DataFilter;
using TSCD.Entities;

namespace TSCD_GUI.Libraries
{
    public class ExcelDataBaseHelper
    {
        const String range = "$A2:Q9999";

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

                                                    if (objCTTaiSan2.chuyenDonVi(objDonVi, null, objViTri, objPhong, objCTTaiSan2.parent, objCTTaiSan2.chungtu, objCTTaiSan2.soluong, "", objCTTaiSan2.ngay) != null && DBInstance.commit() > 0)
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
                                                        if (objCTTaiSan.chuyenDonVi(objDonVi, null, objViTri, objPhong, objCTTaiSan.parent, objCTTaiSan.chungtu, objCTTaiSan.soluong, "", objCTTaiSan.ngay) != null && DBInstance.commit() > 0)
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
                                                    if (objCTTaiSan.chuyenDonVi(objDonVi, null, objViTri, objPhong, objCTTaiSan.parent, objCTTaiSan.chungtu, objCTTaiSan.soluong, "", objCTTaiSan.ngay) != null && DBInstance.commit() > 0)
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

        public static bool ImportTaiSan2(String fileName, String sheet)
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
                const int GHICHU = 8;
                const int DONVI = 9;
                const int PHONG = 10;
                //const int TINHTRANG = 11;
                const int LOAI = 12;
                const int PASS = 13;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        line++;
                        if (line % 200 == 0)
                            DBInstance.reNew();
                        //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import... " +
                        //    String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", (line * 1.0 / lines) * 100) + "%");
                        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Import... " + line + "/" + lines);
                        if (row[PASS] == DBNull.Value || (!row[PASS].Equals("Pass") && !row[PASS].Equals("Error (Không đủ thông tin)")))
                        {
                            if (row[TEN] != DBNull.Value && !String.IsNullOrWhiteSpace(row[TEN].ToString()) && row[DONGIA] != DBNull.Value)
                            {
                                TaiSan obj = new TaiSan();
                                obj.ten = row[TEN].ToString().Trim();
                                String str = row[DONGIA].ToString().Trim().Replace(" ", "");
                                long dongia = long.Parse(str);
                                obj.dongia = dongia;
                                if (row[LOAI] == DBNull.Value)
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có loai)");
                                    continue;
                                }
                                string str1 = row[LOAI].ToString().Trim();
                                obj.loaitaisan = LoaiTaiSan.getQuery().Where(c => c.ten.Equals(str1)).FirstOrDefault();
                                CTTaiSan objCTTaiSan = new CTTaiSan();
                                objCTTaiSan.taisan = obj;
                                objCTTaiSan.ngay = row[NGAY] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY]) : null;
                                ChungTu objChungTu = new ChungTu();
                                objChungTu.sohieu = row[SOHIEU] != DBNull.Value ? row[SOHIEU].ToString() : null;
                                objChungTu.ngay = row[NGAY] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY]) : null;
                                objCTTaiSan.chungtu = objChungTu;
                                objCTTaiSan.mota = row[GHICHU] != DBNull.Value ? row[GHICHU].ToString() : null;
                                objCTTaiSan.tinhtrang = TinhTrang.getQuery().FirstOrDefault(c => c.value.Equals("Đang sử dụng"));
                                objCTTaiSan.soluong = 1;
                                if (objCTTaiSan.add() > 0)
                                {
                                    if (row[DONVI] == DBNull.Value)
                                        continue;
                                    string str2 = row[DONVI].ToString().Trim();
                                    DonVi objDonVi = DonVi.getQuery().Where(c => c.subId.Equals(str2)).FirstOrDefault();
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
                                        //else
                                            //objViTri = objPhong.vitri;
                                    }
                                    if (objCTTaiSan.chuyenDonVi(objDonVi, null, objViTri, objPhong, objCTTaiSan.parent, objCTTaiSan.chungtu, objCTTaiSan.soluong, "", objCTTaiSan.ngay) != null && DBInstance.commit() > 0)
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                        continue;
                                    }
                                }
                                else
                                {
                                    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                    continue;
                                }

                                    //if (row[TINHTRANG] != DBNull.Value)
                                    //{
                                    //    String ten_tinhtrang = row[TINHTRANG].ToString().Trim().ToUpper();
                                    //    TinhTrang objTinhTrang = TinhTrang.getQuery().Where(c => c.value.ToUpper().Equals(ten_tinhtrang)).FirstOrDefault();
                                    //    if (objTinhTrang == null)
                                    //    {
                                    //        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có tình trạng)");
                                    //        continue;
                                    //    }
                                    //    if (obj.chuyenTinhTrang(obj.chungtu, objTinhTrang, obj.soluong, obj.ghichu) > 0 && DBInstance.commit() > 0)
                                    //    {
                                    //        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                    //    }
                                    //    else
                                    //    {
                                    //        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                    //    }

                                    //}
 
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

        public static bool ImportTaiSan3(String fileName, String sheet)
        {
            try
            {
                int line = 0;
                System.Data.DataTable dt = new System.Data.DataTable();
                const int STT = 0;
                const int SOHIEU = 1;
                const int NGAY = 3;
                const int TEN = 6;
                const int DONGIA = 13;
                //const int GHICHU = 8;
                const int DONVI = 19;
                const int PHONG = 20;
                const int TINHTRANG = 21;
                //const int LOAI = 12;
                //const int PASS = 13;
                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        line++;
                        if (line % 200 == 0)
                            DBInstance.reNew();
                        //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import... " +
                        //    String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", (line * 1.0 / lines) * 100) + "%");
                        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Import... " + line + "/" + lines);
                        if (row[TINHTRANG] != DBNull.Value)
                        {
                            if (row[TEN] != DBNull.Value && !String.IsNullOrWhiteSpace(row[TEN].ToString()) && row[DONGIA] != DBNull.Value)
                            {
                                String sohieu_ct = row[SOHIEU] != DBNull.Value ? row[SOHIEU].ToString().Trim() : "";
                                DateTime? ngay_ct = row[NGAY] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY]) : null;
                                String ten = row[TEN].ToString().Trim().ToUpper();
                                String str = row[DONGIA].ToString().Trim().Replace(" ", "");
                                long dongia = long.Parse(str);
                                DonVi objDonVi = null;
                                if (row[DONVI] != DBNull.Value)
                                {
                                    String ma_donvi = row[DONVI].ToString().Trim().ToUpper();
                                    objDonVi = DonVi.getQuery().Where(c => c.subId.ToUpper().Equals(ma_donvi)).FirstOrDefault();
                                    if (objDonVi == null)
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có đơn vị)");
                                        continue;
                                    }
                                }
                                Phong objPhong = null;
                                if (row[PHONG] != DBNull.Value && !String.IsNullOrWhiteSpace(row[PHONG].ToString()))
                                {
                                    String ten_phong = row[PHONG].ToString().Trim().ToUpper();
                                    objPhong = Phong.getQuery().Where(c => c.ten.ToUpper().Equals(ten_phong)).FirstOrDefault();
                                    if (objPhong == null)
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có phòng)");
                                        continue;
                                    }
                                }
                                CTTaiSan obj = null;
                                if (objDonVi != null)
                                    obj = CTTaiSan.getQuery().Where(c => c.taisan.ten.ToUpper().Equals(ten) && c.taisan.dongia.Equals(dongia) && c.chungtu.sohieu == sohieu_ct && c.chungtu.ngay == ngay_ct && c.donviquanly_id == objDonVi.id && c.soluong == 1 && c.tinhtrang.value.Equals("Đang sử dụng") && c.phong == objPhong).FirstOrDefault();
                                else
                                    obj = CTTaiSan.getQuery().Where(c => c.taisan.ten.ToUpper().Equals(ten) && c.taisan.dongia.Equals(dongia) && c.chungtu.sohieu == sohieu_ct && c.chungtu.ngay == ngay_ct && c.donviquanly == null && c.soluong == 1 && c.tinhtrang.value.Equals("Đang sử dụng") && c.phong == objPhong).FirstOrDefault();
                                if (obj != null)
                                {
                                    //if (row[LOAI] != DBNull.Value)
                                    //{
                                    //    String ten_loai = row[DONVI].ToString().Trim().ToUpper();
                                    //    LoaiTaiSan objLoaiTS = LoaiTaiSan.getQuery().Where(c => c.ten.ToUpper().Equals(ten_loai)).FirstOrDefault();
                                    //    if (objLoaiTS == null)
                                    //    {
                                    //        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có loại tài sản)");
                                    //        continue;
                                    //    }
                                    //    WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Chưa xử lí)");
                                    //}
                                    //if (row[DONVI] != DBNull.Value)
                                    //{
                                    //    String ma_donvi = row[DONVI].ToString().Trim().ToUpper();
                                    //    DonVi objDonVi = DonVi.getQuery().Where(c => c.subId.ToUpper().Equals(ma_donvi)).FirstOrDefault();
                                    //    if (objDonVi == null)
                                    //    {
                                    //        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có đơn vị)");
                                    //        continue;
                                    //    }
                                    //    String ghichu = row[GHICHU] != DBNull.Value ? row[GHICHU].ToString().Trim() : null;
                                    //    Phong objPhong = null;
                                    //    ViTri objViTri = null;
                                    //    if (row[PHONG] != DBNull.Value)
                                    //    {
                                    //        String ten_phong = row[PHONG] != DBNull.Value ? row[PHONG].ToString().Trim().ToUpper() : null;
                                    //        objPhong = Phong.getQuery().Where(c => c.ten.ToUpper().Equals(ten_phong)).FirstOrDefault();
                                    //        if (objPhong == null)
                                    //        {
                                    //            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có phòng)");
                                    //            continue;
                                    //        }
                                    //        //objViTri = objPhong.vitri;
                                    //    }
                                    //    if (obj.chuyenDonVi(objDonVi, null, objViTri, objPhong, obj.parent, obj.chungtu, obj.soluong, ghichu, obj.ngay) > 0 && DBInstance.commit() > 0)
                                    //    {
                                    //        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                    //    }
                                    //    else
                                    //    {
                                    //        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                    //    }

                                    //}
                                    if (row[TINHTRANG] != DBNull.Value)
                                    {
                                        String ten_tinhtrang = row[TINHTRANG].ToString().Trim().ToUpper();
                                        TinhTrang objTinhTrang = TinhTrang.getQuery().Where(c => c.value.ToUpper().Equals(ten_tinhtrang)).FirstOrDefault();
                                        if (objTinhTrang == null)
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có tình trạng)");
                                            continue;
                                        }
                                        if (obj.chuyenTinhTrang(obj.chungtu, objTinhTrang, obj.soluong, obj.ghichu) != null && DBInstance.commit() > 0)
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                        }
                                        else
                                        {
                                            WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                        }

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
                //const int SOCHONGOI = 4;
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
                                            //obj.sochongoi = row[SOCHONGOI] != DBNull.Value ? Convert.ToInt32(row[SOCHONGOI].ToString()) : 0;
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

        public static bool insert_data_to_Excel(List<TaiSanHienThi> list, String file_path)
        {
            try
            {
                const String ID = "A";
                const String NGAY_CT = "B";
                const String SOHIEU_CT = "C";
                const String TEN = "D";
                const String LOAI = "E";
                const String DONVITINH = "F";
                const String NGAY_SD = "G";
                const String NUOC_SX = "H";
                const String SOLUONG = "I";
                const String DONGIA = "J";
                const String THANHTIEN = "K";
                const String TINHTRANG = "L";
                const String VITRI = "O";
                const String PHONG = "N";
                const String DONVI_QL = "M";
                const String GHICHU = "P";
                
                String currentPath = Directory.GetCurrentDirectory();
                String path = Path.Combine(currentPath, "Excel");
                //String path = "F:";
                String file = "";
                String fileName = "MauExport.xls";
                if (Directory.Exists(path))
                {
                    file = path + "//" + fileName;
                    if (System.IO.File.Exists(file))
                    {
                        File.Delete(file_path);
                        File.Copy(file, file_path);
                        System.Data.OleDb.OleDbConnection MyConnection;

                        MyConnection = new System.Data.OleDb.OleDbConnection(String.Format("provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';Extended Properties=Excel 8.0;", file_path));
                        MyConnection.Open();
                        int i = 0;
                        foreach (TaiSanHienThi ts in list)
                        {
                            i++;
                            if (i % 100 == 0)
                            {
                                MyConnection.Close();
                                MyConnection = new System.Data.OleDb.OleDbConnection(String.Format("provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';Extended Properties=Excel 8.0;", file_path));
                                MyConnection.Open();
                            }
                            System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                            string sql = null;
                            myCommand.Connection = MyConnection;
                            sql = String.Format("Insert into [TaiSan$A2:P9999] ({0}) values(@id, @ngay_ct, @sohieu_ct, @ten, @loai, @donvitinh, @ngay_sd, @nuoc_sx, @soluong, @dongia, @thanhtien, @tinhtrang, @vitri, @phong, @donvi_ql, @ghichu)",
                                ID + "," + NGAY_CT + "," + SOHIEU_CT + "," + TEN + "," + LOAI + "," + DONVITINH + "," + NGAY_SD + "," + NUOC_SX + "," + SOLUONG + "," + DONGIA + "," + THANHTIEN + "," + TINHTRANG + "," + VITRI + "," + PHONG + "," + DONVI_QL + "," + GHICHU);
                            myCommand.CommandText = sql;
                            myCommand.Parameters.AddWithValue("@id", ts.id);
                            myCommand.Parameters.AddWithValue("@ngay_ct", ts.ngay_ct != null ? (Object)((DateTime)ts.ngay_ct).ToShortDateString() : DBNull.Value);
                            myCommand.Parameters.AddWithValue("@sohieu_ct", (Object)ts.sohieu_ct ?? DBNull.Value);
                            myCommand.Parameters.AddWithValue("@ten", ts.ten);
                            myCommand.Parameters.AddWithValue("@loai", ts.loaits);
                            myCommand.Parameters.AddWithValue("@donvitinh", ts.donvitinh);
                            myCommand.Parameters.AddWithValue("@ngay_sd", ts.ngay != null ? (Object)((DateTime)ts.ngay).ToShortDateString() : DBNull.Value);
                            myCommand.Parameters.AddWithValue("@nuoc_sx", (Object)ts.nuocsx ?? DBNull.Value);
                            myCommand.Parameters.AddWithValue("@soluong", ts.soluong);
                            myCommand.Parameters.AddWithValue("@dongia", ts.dongia);
                            myCommand.Parameters.AddWithValue("@thanhtien", ts.thanhtien);
                            myCommand.Parameters.AddWithValue("@tinhtrang", ts.tinhtrang);
                            myCommand.Parameters.AddWithValue("@vitri", (Object)ts.vitri ?? DBNull.Value);
                            myCommand.Parameters.AddWithValue("@phong", (Object)ts.phong ?? DBNull.Value);
                            myCommand.Parameters.AddWithValue("@donvi_ql", (Object)ts.dvquanly ?? DBNull.Value);
                            myCommand.Parameters.AddWithValue("@ghichu", (Object)ts.ghichu ?? DBNull.Value);
                            myCommand.ExecuteNonQuery();
                            if (i % 500 == 0)
                            {
                                
                            }
                        }
                        MyConnection.Close();
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->insert_data_to_Excel: " + ex.Message);
                return false;
            }
        }

        public static bool UpdateTaiSan(String fileName, String sheet)
        {
            try
            {
                int line = 0;
                System.Data.DataTable dt = new System.Data.DataTable();

                const int ID = 0;
                const int NGAY_CT = 1;
                const int SOHIEU_CT = 2;
                const int TEN = 3;
                //const int LOAI = 4;
                //const int DONVITINH = 5;
                const int NGAY_SD = 6;
                const int NUOC_SX = 7;
                //const int SOLUONG = 8;
                //const int DONGIA = 9;
                //const int THANHTIEN = 10;
                const int TINHTRANG = 11;
                const int VITRI = 14;
                const int PHONG = 13;
                const int DONVI_QL = 12;
                const int GHICHU = 15;
                const int CHECK = 16;

                dt = OpenFileWithRange(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        line++;
                        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import... " +
                            String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", (line * 1.0 / lines) * 100) + "%");
                        if (row[CHECK] == DBNull.Value || !row[CHECK].Equals("Pass"))
                        {
                            if (row[ID] != DBNull.Value && !String.IsNullOrWhiteSpace(row[ID].ToString()))
                            {
                                CTTaiSan ct = CTTaiSan.getById(GUID.From(row[ID].ToString()));
                                if (ct == null)
                                {
                                    WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Không tìm thấy tài sản)");
                                    continue;
                                }
                                else
                                {
                                    TinhTrang objTinhTrang = null;
                                    if (row[TINHTRANG] != DBNull.Value && !String.IsNullOrWhiteSpace(row[TINHTRANG].ToString()))
                                    {
                                        String ten_tinhtrang = row[TINHTRANG].ToString().Trim().ToUpper();
                                        objTinhTrang = TinhTrang.getQuery().Where(c => c.value.ToUpper().Equals(ten_tinhtrang)).FirstOrDefault();
                                        if (objTinhTrang == null)
                                        {
                                            WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Không có tình trạng)");
                                            continue;
                                        }
                                    }
                                    DonVi objDonVi = null;
                                    if (row[DONVI_QL] != DBNull.Value && !String.IsNullOrWhiteSpace(row[DONVI_QL].ToString()))
                                    {
                                        String ten_donvi_ql = row[DONVI_QL].ToString().Trim().ToUpper();
                                        objDonVi = DonVi.getQuery().Where(c => c.ten.ToUpper().Equals(ten_donvi_ql)).FirstOrDefault();
                                        if (objDonVi == null)
                                        {
                                            WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Không có đơn vị quản lý)");
                                            continue;
                                        }
                                    }
                                    Phong objPhong = null;
                                    if (row[PHONG] != DBNull.Value && !String.IsNullOrWhiteSpace(row[PHONG].ToString()))
                                    {
                                        String ten_phong = row[PHONG].ToString().Trim().ToUpper();
                                        objPhong = Phong.getQuery().Where(c => c.ten.ToUpper().Equals(ten_phong)).FirstOrDefault();
                                        if (objPhong == null)
                                        {
                                            WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Không có phòng)");
                                            continue;
                                        }
                                    }
                                    ViTri objViTri = null;
                                    CoSo objCoSo = null;
                                    Dayy objDay = null;
                                    Tang objTang = null;
                                    if (row[VITRI] != DBNull.Value && !String.IsNullOrWhiteSpace(row[VITRI].ToString()))
                                    {
                                        String ten_vitri = row[VITRI].ToString().Trim();
                                        string[] words = ten_vitri.Split('-');
                                        if (words.Count() > 0)
                                        {
                                            String ten_coso = words[0].Trim().ToUpper();
                                            objCoSo = CoSo.getQuery().Where(c => c.ten.ToUpper().Equals(ten_coso)).FirstOrDefault();
                                            if (objCoSo == null)
                                            {
                                                WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Không có cơ sở)");
                                                continue;
                                            }
                                        }
                                        if (words.Count() > 1)
                                        {
                                            String ten_day = words[1].Trim().ToUpper();
                                            objDay = objCoSo.days.Where(c => c.ten.ToUpper().Equals(ten_day)).FirstOrDefault();
                                            if (objDay == null)
                                            {
                                                WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Không có dãy)");
                                                continue;
                                            }
                                        }
                                        if (words.Count() > 2)
                                        {
                                            String ten_tang = words[2].Trim().ToUpper();
                                            objTang = objDay.tangs.Where(c => c.ten.ToUpper().Equals(ten_tang)).FirstOrDefault();
                                            if (objTang == null)
                                            {
                                                WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Không có tầng)");
                                                continue;
                                            }
                                        }
                                        objViTri = ViTri.request(objCoSo, objDay, objTang);
                                    }
                                    if (row[TEN] == DBNull.Value || String.IsNullOrWhiteSpace(row[TEN].ToString()))
                                    {
                                        WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Không có tên)");
                                        continue;
                                    }
                                    try
                                    {
                                        ct.taisan.ten = row[TEN].ToString().Trim();
                                        ct.taisan.nuocsx = row[NUOC_SX] != DBNull.Value ? row[NUOC_SX].ToString().Trim() : "";
                                        ct.ngay = row[NGAY_SD] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY_SD]) : null;
                                        ct.chungtu.ngay = row[NGAY_CT] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY_CT]) : null;
                                        ct.chungtu.sohieu = row[SOHIEU_CT] != DBNull.Value ? row[SOHIEU_CT].ToString().Trim() : "";
                                        ct.ghichu = row[GHICHU] != DBNull.Value ? row[GHICHU].ToString().Trim() : "";
                                        if (ct.update() > 0)
                                        {
                                            if(ct.donviquanly != objDonVi || ct.phong != objPhong || ct.vitri != objViTri)
                                                if (ct.chuyenDonVi(objDonVi, null, objViTri, objPhong, ct.parent, ct.chungtu, ct.soluong, "", ct.ngay) != null && DBInstance.commit() > 0)
                                                {
                                                    WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Pass");
                                                }
                                                else
                                                {
                                                    WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Chuyển vị trí)");
                                                    continue;
                                                }
                                            if (ct.tinhtrang != objTinhTrang)
                                                if (ct.chuyenTinhTrang(ct.chungtu, objTinhTrang, ct.soluong, ct.ghichu) != null && DBInstance.commit() > 0)
                                                {
                                                    WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Pass");
                                                }
                                                else
                                                {
                                                    WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Chuyển tình trạng)");
                                                    continue;
                                                }
                                            WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Pass");
                                        }
                                        else
                                        {
                                            WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("ExcelDataBaseHelper->UpdateTaiSan: " + ex.Message);
                                        WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error");
                                    }
                                }
                            }
                            else
                            {
                                WriteFileWithRange(fileName, sheet, row[ID].ToString().Trim(), "Error (Không đủ thông tin)");
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

        public static System.Data.DataTable OpenFileWithRange(String fileName, String sheet)
        {
            //var fullFileName = string.Format("{0}\\{1}", System.IO.Directory.GetCurrentDirectory(), fileName);
            if (!System.IO.File.Exists(fileName))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("File not found");
                return null;
            }
            System.Data.DataTable dt = new System.Data.DataTable();
            var cmdText = String.Format("SELECT * FROM [{0}${1}]", sheet, range);
            using (var adapter = new System.Data.OleDb.OleDbDataAdapter(cmdText, GetConnectionString(fileName)))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        private static void WriteFileWithRange(String fileName, String sheet, String stt, String text)
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
                        sql = String.Format("Update [{0}${1}] set Q = @pass where A = @stt", sheet, range);
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
                Debug.WriteLine("ExcelDataBaseHelper->WriteFileWithRange: " + ex.Message);
            }
        }

        public static bool UpdateLoaiTaiSan(String fileName, String sheet)
        {
            try
            {
                int line = 0;
                System.Data.DataTable dt = new System.Data.DataTable();

                const int ID = 0;
                const int TEN = 6;
                const int LOAI = 18;

                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        line++;
                        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import... " +
                            String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", (line * 1.0 / lines) * 100) + "%");
                        if (row[LOAI] == DBNull.Value && row[TEN] != DBNull.Value)
                        {
                            String ten = row[TEN].ToString().Trim();
                            TaiSan obj = TaiSan.getQuery().Where(c => c.ten.Equals(ten)).FirstOrDefault();
                            if (obj != null)
                            {
                                WriteLoaiTS(fileName, sheet, row[ID].ToString().Trim(), obj.loaitaisan.ten);
                            }
                            else
                            {
                                WriteLoaiTS(fileName, sheet, row[ID].ToString().Trim(), "none");
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

        private static void WriteLoaiTS(String fileName, String sheet, String stt, String text)
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
                        sql = String.Format("Update [{0}$] set Loai = @loai where STT = @stt", sheet);
                        myCommand.CommandText = sql;
                        myCommand.Parameters.AddWithValue("@loai", text);
                        myCommand.Parameters.AddWithValue("@stt", stt);
                        myCommand.ExecuteNonQuery();
                        MyConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->WriteFileWithRange: " + ex.Message);
            }
        }

        public static bool ImportDonVi(String fileName, String sheetDonVi)
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

        public static bool AddTaiSan(String fileName, String sheet)
        {
            try
            {
                int line = 0;
                System.Data.DataTable dt = new System.Data.DataTable();

                const int STT = 0;
                const int NGAY = 3;
                const int SOHIEU_CT = 1;
                const int TEN = 6;
                const int LOAI = 18;
                //const int DONVITINH = 5;
                //const int NGAY_SD = 6;
                //const int NUOC_SX = 7;
                //const int SOLUONG = 8;
                const int DONGIA = 13;
                //const int THANHTIEN = 10;
                const int TINHTRANG = 21;
                //const int VITRI = 12;
                const int PHONG = 20;
                const int DONVI_QL = 19;
                const int GHICHU = 22;
                const int CHECK = 23;

                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        line++;
                        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import... " +
                            String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", (line * 1.0 / lines) * 100) + "%");
                        if (row[CHECK] == DBNull.Value || !row[CHECK].Equals("Pass"))
                        {
                            if (row[TEN] != DBNull.Value && !String.IsNullOrWhiteSpace(row[TEN].ToString()) && row[LOAI] != DBNull.Value && !String.IsNullOrWhiteSpace(row[LOAI].ToString()))
                            {
                                TinhTrang objTinhTrang = null;
                                if (row[TINHTRANG] != DBNull.Value && !String.IsNullOrWhiteSpace(row[TINHTRANG].ToString()))
                                {
                                    String ten_tinhtrang = row[TINHTRANG].ToString().Trim().ToUpper();
                                    objTinhTrang = TinhTrang.getQuery().Where(c => c.value.ToUpper().Equals(ten_tinhtrang)).FirstOrDefault();
                                    if (objTinhTrang == null)
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có tình trạng)");
                                        continue;
                                    }
                                }
                                DonVi objDonVi = null;
                                if (row[DONVI_QL] != DBNull.Value && !String.IsNullOrWhiteSpace(row[DONVI_QL].ToString()))
                                {
                                    String ten_donvi_ql = row[DONVI_QL].ToString().Trim();
                                    objDonVi = DonVi.getQuery().Where(c => c.subId.Equals(ten_donvi_ql)).FirstOrDefault();
                                    if (objDonVi == null)
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có đơn vị quản lý)");
                                        continue;
                                    }
                                }
                                Phong objPhong = null;
                                if (row[PHONG] != DBNull.Value && !String.IsNullOrWhiteSpace(row[PHONG].ToString()))
                                {
                                    String ten_phong = row[PHONG].ToString().Trim().ToUpper();
                                    objPhong = Phong.getQuery().Where(c => c.ten.ToUpper().Equals(ten_phong)).FirstOrDefault();
                                    if (objPhong == null)
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Không có phòng)");
                                        continue;
                                    }
                                }

                                try
                                {
                                    TaiSan obj = new TaiSan();
                                    obj.ten = row[TEN].ToString().Trim();
                                    String str = row[DONGIA].ToString().Trim().Replace(" ", "");
                                    long dongia = long.Parse(str);
                                    obj.dongia = dongia;
                                    string str1 = row[LOAI].ToString().Trim();
                                    obj.loaitaisan = LoaiTaiSan.getQuery().Where(c => c.ten.Equals(str1)).FirstOrDefault();
                                    CTTaiSan objCTTaiSan = new CTTaiSan();
                                    objCTTaiSan.taisan = obj;
                                    objCTTaiSan.ngay = row[NGAY] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY]) : null;
                                    objCTTaiSan.tinhtrang = TinhTrang.getQuery().FirstOrDefault(c => c.value.Equals("Đang sử dụng"));
                                    objCTTaiSan.soluong = 1;
                                    ChungTu chungtu = new ChungTu();
                                    chungtu.ngay = row[NGAY] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[NGAY]) : null;
                                    chungtu.sohieu = row[SOHIEU_CT] != DBNull.Value ? row[SOHIEU_CT].ToString().Trim() : "";
                                    objCTTaiSan.chungtu = chungtu;
                                    objCTTaiSan.ghichu = row[GHICHU] != DBNull.Value ? row[GHICHU].ToString().Trim() : "";
                                    if (objCTTaiSan.add() > 0)
                                    {
                                        if (objDonVi != null)
                                        {
                                            if (objCTTaiSan.chuyenDonVi(objDonVi, null, null, objPhong, objCTTaiSan.parent, objCTTaiSan.chungtu, objCTTaiSan.soluong, "", objCTTaiSan.ngay) != null && DBInstance.commit() > 0)
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Chuyển vị trí)");
                                                continue;
                                            }
                                        }
                                        if (objTinhTrang != null)
                                        {
                                            if (objCTTaiSan.chuyenTinhTrang(objCTTaiSan.chungtu, objTinhTrang, objCTTaiSan.soluong, objCTTaiSan.ghichu) != null && DBInstance.commit() > 0)
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                            }
                                            else
                                            {
                                                WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error (Chuyển tình trạng)");
                                                continue;
                                            }
                                        }
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Pass");
                                    }
                                    else
                                    {
                                        WriteFile(fileName, sheet, row[STT].ToString().Trim(), "Error");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine("ExcelDataBaseHelper->AddTaiSan: " + ex.Message);
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
                Debug.WriteLine("ExcelDataBaseHelper->ImportTaiSan: " + ex.Message);
                return false;
            }
        }

        public static bool UpdateNSX(String fileName, String sheet)
        {
            try
            {
                int line = 0;
                System.Data.DataTable dt = new System.Data.DataTable();

                //const int ID = 0;
                const int TEN = 6;
                const int NSX = 24;

                dt = OpenFile(fileName, sheet);
                if (dt != null)
                {
                    int lines = dt.Rows.Count;
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        line++;
                        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import... " +
                            String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00}", (line * 1.0 / lines) * 100) + "%");
                        if (row[NSX] != DBNull.Value && row[TEN] != DBNull.Value)
                        {
                            String ten = row[TEN].ToString().Trim();
                            TaiSan obj = TaiSan.getQuery().Where(c => c.ten.Equals(ten) && (c.nuocsx == null || c.nuocsx.Equals(""))).FirstOrDefault();
                            if (obj != null)
                            {
                                obj.nuocsx = row[NSX].ToString();
                                obj.update();
                                DBInstance.commit();
                                //WriteNSX(fileName, sheet, row[ID].ToString().Trim(), obj.nuocsx);

                            }
                            else
                            {
                                //WriteLoaiTS(fileName, sheet, row[ID].ToString().Trim(), "none");
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

        private static void WriteNSX(String fileName, String sheet, String stt, String text)
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
                        sql = String.Format("Update [{0}$] set NSX = @nsx where STT = @stt", sheet);
                        myCommand.CommandText = sql;
                        myCommand.Parameters.AddWithValue("@nsx", text);
                        myCommand.Parameters.AddWithValue("@stt", stt);
                        myCommand.ExecuteNonQuery();
                        MyConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ExcelDataBaseHelper->WriteFileWithRange: " + ex.Message);
            }
        }
    }
}
