using System.Data;
using System.Data.Common;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace dotnet_project_template.Services.DapperORM
{
    public class DapperORM : IDapperORM
    {
        private readonly IConfiguration _config;
        private string Connectionstring;

        public DapperORM(IConfiguration config)
        {
            _config = config;
            var defaultConnection = _config["ConnectionStrings:DefaultConnection"];
            Connectionstring = defaultConnection == null ? "" : defaultConnection;
        }

        public void Dispose()
        {

        }

        public DbConnection GetDbconnection()
        {
            return new NpgsqlConnection(Connectionstring);
        }

        private int Transaction<T>(string sp, DynamicParameters? dynamicParameters)
        {
            int rowsAffected;
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    rowsAffected = db.Execute(sp, dynamicParameters, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return rowsAffected;
        }

        public T? Get<T>(string sql, DynamicParameters? dynamicParameters)
        {
            using IDbConnection db = GetDbconnection();
            return db.Query<T>(sql, dynamicParameters).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sql, DynamicParameters? dynamicParameters)
        {
            using IDbConnection db = GetDbconnection();
            return db.Query<T>(sql, dynamicParameters).ToList();
        }

        public int Insert<T>(string sql, DynamicParameters? dynamicParameters)
        {
            return Transaction<T>(sql, dynamicParameters);
        }

        public int Update<T>(string sql, DynamicParameters? dynamicParameters)
        {
            return Transaction<T>(sql, dynamicParameters);
        }

        public int Delete<T>(string sql, DynamicParameters? dynamicParameters)
        {
            return Transaction<T>(sql, dynamicParameters);
        }
    }
}

