using System.Data;

namespace demo.Database;

public interface IDapperDbConnection
{
        public IDbConnection CreateConnection();
    
}