using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvisionServer
{
    public class Program
    {
        public static Boolean old_scope = true;
        public static String scope_name = "QLTSScope";
        static void Main(string[] args)
        {
            SqlConnection serverConn = new SqlConnection("Data Source=172.16.0.158;Initial Catalog=QuanLyTaiSanDB;User Id=sa;Password=123456;");
            if (old_scope)
            {
                try
                {
                    // define a new scope named ProductsScope
                    //DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription("QLTSScope");
                    SqlSyncScopeDeprovisioning del = new SqlSyncScopeDeprovisioning(serverConn);//Delete Current Scope

                    del.DeprovisionScope(scope_name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            // define a new scope named ProductsScope
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(scope_name);
            // get the description of the Products table from SyncDB dtabase
            //List of all Table from Entity Framework
            String[] table_name = new String[] {
                "__MigrationHistory",
                "COSOS",
                "DAYS",
                "HINHANHS",
                "TANGS",
                "VITRIS",
                "PHONGS",
                "NHANVIENPTS",
                "THIETBIS",
                "CTTHIETBIS",
                "TINHTRANGS",
                "LOAITHIETBIS",
                "GROUPS",
                "QUANTRIVIENS",
                "PERMISSIONS",
                "LOGHETHONGS",
                "LOGTHIETBIS",
                "GROUP_PERMISSION",
                "SETTINGS"
            };
            DbSyncTableDescription tableDesc = null;
            foreach (String item in table_name)
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
        }
    }
}
