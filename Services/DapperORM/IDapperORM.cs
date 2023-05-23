using System.Data;
using System.Data.Common;
using Dapper;

namespace dotnet_project_template.Services.DapperORM
{
    public interface IDapperORM : IDisposable
    {
        DbConnection GetDbconnection();
        List<T> GetAll<T>(string sql, DynamicParameters? dynamicParameters = null);
        T? Get<T>(string sql, DynamicParameters? dynamicParameters = null);
        int Insert<T>(string sql, DynamicParameters? dynamicParameters = null);
        int Update<T>(string sql, DynamicParameters? dynamicParameters = null);
        int Delete<T>(string sql, DynamicParameters? dynamicParameters = null);
    }
}