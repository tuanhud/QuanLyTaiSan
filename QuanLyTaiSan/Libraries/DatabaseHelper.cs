using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyTaiSan.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Libraries
{
    public class DatabaseHelper
    {
        public static Boolean dropDB(String connectionString="")
        {
            return System.Data.Entity.Database.Delete(connectionString);
        }
        /// <summary>
        /// Kiểm tra kết nối tới Database thông qua Connection String đưa vào
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static Boolean isExist(String connectionString="")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
        public static Boolean isExist(SqlConnection connectionInstance)
        {
            try
            {
                connectionInstance.Open();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
        private static void sync_error_event_handler(object sender, DbApplyChangeFailedEventArgs e)
        {
            Debug.WriteLine("=========ERROR==========");
            // display conflict type
            Debug.WriteLine(e.Conflict.Type);
            // display error message 
            Debug.WriteLine(e.Error);
            Debug.WriteLine("=========END ERROR==========");
        }
        public static int start_sync(String client_connectionString, String server_connectionString, String scope_name)
        {
            SqlConnection clientConn = new SqlConnection(client_connectionString);
            // create a connection to the SyncDB server database
            SqlConnection serverConn = new SqlConnection(server_connectionString);
            try
            {
                // create the sync orhcestrator
                SyncOrchestrator syncOrchestrator = new SyncOrchestrator();
                
                // set local provider of orchestrator to a CE sync provider associated with the 
                // ProductsScope in the SyncCompactDB compact client database
                syncOrchestrator.LocalProvider = new SqlSyncProvider(scope_name, clientConn);


                // set the remote provider of orchestrator to a server sync provider associated with
                // the ProductsScope in the SyncDB server database
                syncOrchestrator.RemoteProvider = new SqlSyncProvider(scope_name, serverConn);

                // set the direction of sync session to Upload and Download
                syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;
                
                // subscribe for errors that occur when applying changes to the client
                
                ((SqlSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed +=
                    new EventHandler<DbApplyChangeFailedEventArgs>(sync_error_event_handler);

                // execute the synchronization process
                SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();

                // print statistics
                Debug.WriteLine("=========SYNC SUMMARY==========");
                Debug.WriteLine("Start Time: " + syncStats.SyncStartTime);
                Debug.WriteLine("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
                Debug.WriteLine("Total Changes Uploaded Fail: " + syncStats.UploadChangesFailed);
                Debug.WriteLine("Total Changes Downloaded: " + syncStats.DownloadChangesTotal);
                Debug.WriteLine("Total Changes Uploaded Fail: " + syncStats.DownloadChangesFailed);
                Debug.WriteLine("End Time: " + syncStats.SyncEndTime);
                Debug.WriteLine("Total Time (milisec): " + (syncStats.SyncEndTime - syncStats.SyncStartTime).TotalMilliseconds);
                Debug.WriteLine("=========END SYNC SUMMARY==========");
                //Console.ReadLine();
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
            finally
            {
                clientConn.Dispose();
                serverConn.Dispose();
            }
        }
        /// <summary>
        /// Kiểm tra có SCOPE chưa
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="scope_name"></param>
        /// <returns></returns>
        public static int isHasScope(String connectionString, String scope_name, String[] tracking_tables)
        {
            SqlConnection serverConn = new SqlConnection(connectionString);
            if (!isExist(serverConn))
            {
                return -1;
            }

            try
            {
                // define a new scope named ProductsScope
                DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(scope_name);
                DbSyncTableDescription tableDesc = null;
                foreach (String item in tracking_tables)
                {
                    //parse
                    tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable(item, serverConn);

                    // add the table description to the sync scope definition
                    scopeDesc.Tables.Add(tableDesc);
                }
                SqlSyncScopeProvisioning tmp = new SqlSyncScopeProvisioning(serverConn, scopeDesc);
                return tmp.ScopeExists(scope_name)?1:-1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return -1;
            }
        }
        /// <summary>
        /// Xóa 1 SCOPE khỏi 1 Server nếu có
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="scope_name"></param>
        /// <returns></returns>
        public static int drop_sync_scope(String connectionString, String scope_name)
        {
            SqlConnection serverConn = new SqlConnection(connectionString);
            if (!isExist(serverConn))
            {
                return -1;
            }
            
            try
            {
                SqlSyncScopeDeprovisioning del = new SqlSyncScopeDeprovisioning(serverConn);
                //Delete Current Scope
                del.DeprovisionScope(scope_name);
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
            finally
            {
                serverConn.Dispose();
            }
        }
        /// <summary>
        /// Cài đặt SCOPE cho client từ Server SCOPE,
        /// Nếu CLIENT có SCOPE rồi sẽ bỏ qua
        /// </summary>
        /// <param name="client_connectionString"></param>
        /// <param name="server_connectionString"></param>
        public static int fetch_sync_scope(String client_connectionString, String server_connectionString, String server_scope_name)
        {
            try{
                // create a connection to the SyncCompactDB database
                SqlConnection clientConn = new SqlConnection(client_connectionString);

                // create a connection to the SyncDB server database
                SqlConnection serverConn = new SqlConnection(server_connectionString);

                // get the description of ProductsScope from the SyncDB server database
                DbSyncScopeDescription scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope(server_scope_name, serverConn);
                
                // create provisioning object based on the Scope
                SqlSyncScopeProvisioning clientProvision = new SqlSyncScopeProvisioning(clientConn, scopeDesc);
                
                // starts the provisioning process
                clientProvision.Apply();
                return 1;
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
        }
        /// <summary>
        /// Cài đặt Sync SCOPE ở database chỉ định,
        /// yêu cầu bắt buộc phải có cấu trúc CSDL trước,
        /// Nếu Server có Scope trùng tên rồi thì không làm gì cả
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="scopeName"></param>
        /// <param name="tracking_tables"></param>
        public static int setup_sync_scope(String connectionString, String scope_name, String[] tracking_tables)
        {
            try
            {
                SqlConnection serverConn = new SqlConnection(connectionString);
                DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(scope_name);
                // get the description of the Products table from SyncDB dtabase
                
                DbSyncTableDescription tableDesc = null;
                foreach (String item in tracking_tables)
                {
                    //parse
                    tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable(item, serverConn);

                    // add the table description to the sync scope definition
                    scopeDesc.Tables.Add(tableDesc);
                }

                // create a server scope provisioning object based on the ProductScope
                SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);

                // skipping the creation of table since table already exists on server
                serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);

                // start the provisioning process
                serverProvision.Apply();

                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -2;
            }
            finally
            {
               
            }
        }
    }
}
