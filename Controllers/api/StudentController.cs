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
            var result = await Task.FromResult(_dapper.GetAll<Student>
                (sql, null, commandType: CommandType.Text));
            return result;
        }

        [HttpGet("{Id}")]
        public async Task<Student> Get(int Id)
        {
            string sql = $@"Select * from {_tableName} where Id = {Id}";
            var result = await Task.FromResult(_dapper.Get<Student>
                (sql, null, commandType: CommandType.Text));
            return result;
        }

        [HttpPost]
        public async Task<int> Post(Student data)
        {
            string sql = $@"INSERT INTO {_tableName} VALUES ({data.Id},{data.Name},{data.Age})";
            var result = await Task.FromResult(_dapper.Insert<int>
                (sql,null, commandType: CommandType.Text));
            return result;
        }

        [HttpPut]
        public async Task<int> Put(Student data)
        {
            string sql = $@"UPDATE {_tableName} SET Name={data.Name},Age={data.Age} WHERE ID={data.Id}";
            var result = await Task.FromResult(_dapper.Update<int>
            (sql, null, commandType: CommandType.Text));
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            string sql = $@"DELETE FROM {_tableName} WHERE ID={id}";
            var result = await Task.FromResult(_dapper.Execute
            (sql, null, commandType: CommandType.Text));
            return result;
        }
    }
}

