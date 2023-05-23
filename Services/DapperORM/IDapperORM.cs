using System.Data;
using System.Data.Common;
using Dapper;

namespace dotnet_project_template.Services.DapperORM
{
    public interface IDapperORM : IDisposable
    {
        DbConnection GetDbconnection();
        List<T> GetAll<T>(string sql, DynamicParameters? dynamicParameters);
        T? Get<T>(string sql, DynamicParameters? dynamicParameters);
        int Insert<T>(string sql, DynamicParameters? dynamicParameters);
        int Update<T>(string sql, DynamicParameters? dynamicParameters);
        int Delete<T>(string sql, DynamicParameters? dynamicParameters);
    }
}