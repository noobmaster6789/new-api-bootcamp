using System.Data;
using Microsoft.Data.SqlClient;


namespace demo.Database;

public class DapperDbConnection: IDapperDbConnection
{
    public string _connectionString;

    public DapperDbConnection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

}