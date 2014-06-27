using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization.Data.SqlServerCe;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvisionServer;

namespace ProvisionController
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a connection to the SyncCompactDB database
            //SqlCeConnection clientConn = new SqlCeConnection(@"Data Source=C:\Users\quocdunginfo\Documents\GitHub\QuanLyTaiSan\ProvisionClient\local_db.sdf");
            SqlConnection clientConn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyTaiSanDB_cache;Integrated Security=True");

            // create a connection to the SyncDB server database
            SqlConnection serverConn = new SqlConnection("Data Source=172.16.0.158;Initial Catalog=QuanLyTaiSanDB;User Id=sa;Password=123456;");

            // create the sync orhcestrator
            SyncOrchestrator syncOrchestrator = new SyncOrchestrator();

            // set local provider of orchestrator to a CE sync provider associated with the 
            // ProductsScope in the SyncCompactDB compact client database
            //syncOrchestrator.LocalProvider = new SqlCeSyncProvider(ProvisionServer.Program.scope_name, clientConn);
            syncOrchestrator.LocalProvider = new SqlSyncProvider(ProvisionServer.Program.scope_name, clientConn);


            // set the remote provider of orchestrator to a server sync provider associated with
            // the ProductsScope in the SyncDB server database
            syncOrchestrator.RemoteProvider = new SqlSyncProvider(ProvisionServer.Program.scope_name, serverConn);

            // set the direction of sync session to Upload and Download
            syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;

            // subscribe for errors that occur when applying changes to the client
            //((SqlCeSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);
            ((SqlSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);

            // execute the synchronization process
            SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();

            // print statistics
            Console.WriteLine("=========SUMMARY==========");
            Console.WriteLine("Start Time: " + syncStats.SyncStartTime);
            Console.WriteLine("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
            Console.WriteLine("Total Changes Downloaded: " + syncStats.DownloadChangesTotal);
            Console.WriteLine("Complete Time: " + syncStats.SyncEndTime);
            Console.ReadLine();
        }

        private static void Program_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e)
        {
            Console.WriteLine("=========ERROR==========");
            //throw new NotImplementedException();
            // display conflict type
            Console.WriteLine(e.Conflict.Type);

            // display error message 
            Console.WriteLine(e.Error);

            Console.ReadLine();
        }
    }
}
