using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSCE;
using System.Data.SqlClient;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using ProvisionServer;
namespace ProvisionClient
{
    class Program
    {
        public static Boolean old_scope = false;
        static void Main(string[] args)
        {
            // create a connection to the SyncCompactDB database
            //SqlCeConnection clientConn = new SqlCeConnection(@"Data Source=C:\Users\quocdunginfo\Documents\GitHub\QuanLyTaiSan\ProvisionClient\local_db.sdf");
            SqlConnection clientConn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyTaiSanDB_cache;Integrated Security=True");

            if (false && old_scope)
            {
                try
                {
                    // define a new scope named ProductsScope
                    //DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription("QLTSScope");
                    //SqlCeSyncScopeDeprovisioning del = new SqlCeSyncScopeDeprovisioning(clientConn);//Delete Current Scope
                    SqlSyncScopeDeprovisioning del = new SqlSyncScopeDeprovisioning(clientConn);//Delete Current Scope

                    del.DeprovisionScope(ProvisionServer.Program.scope_name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            // create a connection to the SyncDB server database
            SqlConnection serverConn = new SqlConnection("Data Source=172.16.0.158;Initial Catalog=QuanLyTaiSanDB;User Id=sa;Password=123456;");

            // get the description of ProductsScope from the SyncDB server database
            DbSyncScopeDescription scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope(ProvisionServer.Program.scope_name, serverConn);

            // create CE provisioning object based on the ProductsScope
            //SqlCeSyncScopeProvisioning clientProvision = new SqlCeSyncScopeProvisioning(clientConn, scopeDesc);
            SqlSyncScopeProvisioning clientProvision = new SqlSyncScopeProvisioning(clientConn, scopeDesc);
            // starts the provisioning process
            clientProvision.Apply();

        }
    }
}
