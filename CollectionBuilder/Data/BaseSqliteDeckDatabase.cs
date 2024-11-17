using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;

namespace CollectionBuilder.Data;

public abstract class BaseSqliteDeckDatabase
{
    public string ConnectionString { get; set; }

    protected string GetFileNameFromConnectionString()
    {
        var regex = new Regex(@"DataSource=""(?<filename>[^/*?\""<>|]+)""");

        var match = regex.Match(ConnectionString);

        if (match.Success) { return match.Groups["filename"].Value; }

        throw new InvalidOperationException("Could not get database filename from connection string. Please verify the connection string and retry.");
    }

    protected void InitializeDatabase(SqliteConnection conn)
    {
        const string cmdText = "create table Collection (Card nvarchar(255))";
        var cmd = new SqliteCommand(cmdText, conn);
        cmd.ExecuteNonQuery();
    }
}
