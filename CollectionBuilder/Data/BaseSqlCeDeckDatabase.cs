using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CollectionBuilder.Data
{
    public abstract class BaseSqlCeDeckDatabase
    {
        public string ConnectionString { get; set; }

        protected string GetFileNameFromConnectionString()
        {
            var regex = new Regex(@"DataSource=""(?<filename>[^/*?\""<>|]+)""");

            Match match = regex.Match(ConnectionString);

            if (match.Success)
            {
                return match.Groups["filename"].Value;
            }

            throw new InvalidOperationException("Could not get database filename from connection string. Please verify the connection string and retry.");
        }

        protected void InitializeDatabase(SqlCeConnection conn)
        {
            const string cmdText = "create table Collection (Card nvarchar(255))";
            var cmd = new SqlCeCommand(cmdText, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
