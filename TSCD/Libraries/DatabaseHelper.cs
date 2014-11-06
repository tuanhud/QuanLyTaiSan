using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TSCD.Libraries
{
    public static class DatabaseHelper
    {
        private static System.Timers.Timer aTimer = null;
        /// <summary>
        /// winform only (call when start main form)
        /// </summary>
        public static void autoSyncInNewThread()
        {
            try
            {
                if (Global.working_database.use_db_cache && Global.local_setting.sync_auto){
                    aTimer = new System.Timers.Timer(Global.local_setting.sync_time_second * 1000);
                    aTimer.Elapsed += new System.Timers.ElapsedEventHandler(RunThis);
                    aTimer.AutoReset = true;
                    aTimer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private static void RunThis(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Debug.WriteLine("Auto SYNC in Background");
                Global.client_database.start_sync();
                if (!Global.local_setting.sync_auto)
                {
                    aTimer.Stop();
                    aTimer.Dispose();
                    return;
                }
                aTimer.Interval = Global.local_setting.sync_time_second * 1000;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        
    }
}
