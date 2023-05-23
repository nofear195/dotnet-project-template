using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using dotnet_project_template.Models;
using dotnet_project_template.Services.DapperORM;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dotnet_project_template.Controllers.api
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IDapperORM _dapper;
        private readonly string _tableName;

        public StudentController(IDapperORM dapper)
        {
            _dapper = dapper;
            _tableName = "Student";
        }

        [HttpGet]
        public async Task<List<Student>> Get()
        {
            string sql = $"Select * from {_tableName}";

            var result = await Task.FromResult(_dapper.GetAll<Student>(sql));
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            string sql = $@"Select * from {_tableName} WHERE ID=@id";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);

            var result = await Task.FromResult(_dapper.Get<Student>(sql, dynamicParameters));
            return result == null ? new Student() : result;
        }

        [HttpPost]
        public async Task<int> Post(Student data)
        {
            string sql = $@"INSERT INTO {_tableName} VALUES (@ID,@Name,@Age)";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(data);

            var result = await Task.FromResult(_dapper.Insert<int>(sql,dynamicParameters));
            return result;
        }

        [HttpPut]
        public async Task<int> Put(Student data)
        {
            string sql = $@"UPDATE {_tableName} SET Name=@Name,Age=@Age WHERE ID=@Id";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(data);

            var result = await Task.FromResult(_dapper.Update<int>(sql, dynamicParameters));
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            string sql = $@"DELETE FROM {_tableName} WHERE ID=@id";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);

            var result = await Task.FromResult(_dapper.Delete<int>(sql, dynamicParameters));
            return result;
        }
    }
}

