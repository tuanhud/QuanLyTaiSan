using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace QuanLyTaiSan.Libraries
{
    public class ServerTimeHelper
    {
        //#region C++ LIB
        //private struct SystemTime
        //{
        //    public ushort wYear;
        //    public ushort wMonth;
        //    public ushort wDayOfWeek;
        //    public ushort wDay;
        //    public ushort wHour;
        //    public ushort wMinute;
        //    public ushort wSecond;
        //    public ushort wMilliseconds;
        //}

        //[DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
        //private extern static void Win32GetSystemTime(ref SystemTime sysTime);

        //[DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        //private extern static bool Win32SetSystemTime(ref SystemTime sysTime);

        ///// <summary>
        ///// Đồng bộ thời gian từ Server về máy local
        ///// </summary>
        ///// <returns></returns>
        //public static int sync_datetime()
        //{
        //    DateTime server_time = getNow();
        //    SystemTime updatedTime = new SystemTime();
        //    //Win32GetSystemTime(ref updatedTime);
        //    updatedTime.wYear = (ushort)server_time.Year;
        //    updatedTime.wMonth = (ushort)server_time.Month;
        //    updatedTime.wDay = (ushort)server_time.Day;
        //    updatedTime.wHour = (ushort)server_time.Hour;
        //    updatedTime.wMinute = (ushort)server_time.Minute;
        //    updatedTime.wSecond = (ushort)server_time.Second;
        //    // Call the unmanaged function that sets the new date and time instantly
        //    return Win32SetSystemTime(ref updatedTime)?1:-1;
        //}
        //#endregion

        /// <summary>
        /// Lấy ngày hiện tại từ Server bằng hàm GETDATE(), nếu lỗi thì return DateTime.Now </summary>
        public static DateTime getNow()
        {
            try
            {
                return DateTime.Now;//DBInstance.DB.Database.SqlQuery<DateTime>("select GETDATE()").FirstOrDefault();                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return DateTime.Now;
            }
        }
    }
}
