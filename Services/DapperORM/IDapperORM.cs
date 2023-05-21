using System.Data;
using System.Data.Common;
using Dapper;

namespace dotnet_project_template.Services.DapperORM
{
    public interface IDapperORM : IDisposable
    {
        DbConnection GetDbconnection();
        List<T> GetAll<T>(string sql, DynamicParameters? parms, CommandType commandType = CommandType.StoredProcedure);
        T Get<T>(string sql, DynamicParameters? parms, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sql, DynamicParameters? parms, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sql, DynamicParameters? parms, CommandType commandType = CommandType.StoredProcedure);
        T Delete<T>(string sql, DynamicParameters? parms, CommandType commandType = CommandType.StoredProcedure);
        int Execute(string sql, object[] items, CommandType commandType = CommandType.StoredProcedure);
    }
}