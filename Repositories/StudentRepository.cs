using Dapper;
using dotnet_project_template.Models;
using dotnet_project_template.Utils.DapperORM;

namespace dotnet_project_template.Repositories
{
    public class StudentRepository
	{
        private readonly IDapperORM _dapper;
        private readonly string _tableName;
        public StudentRepository(IDapperORM dapper)
		{
            _dapper = dapper;
            _tableName = "Student";
        }

        public async Task<List<Student>> GetAllStudents()
        {
            string sql = $"Select * from {_tableName}";

            var result = await Task.FromResult(_dapper.GetAll<Student>(sql));
            return result;
        }

        public async Task<Student> GetStudentById(int id)
        {
            string sql = $@"Select * from {_tableName} WHERE ID=@id";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);

            var result = await Task.FromResult(_dapper.Get<Student>(sql, dynamicParameters));
            return result == null ? new Student() : result;
        }

        public async Task<int> CreateNewStudent(Student data)
        {
            string sql = $@"INSERT INTO {_tableName} VALUES (@ID,@Name,@Age)";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(data);

            var result = await Task.FromResult(_dapper.Insert<int>(sql, dynamicParameters));
            return result;
        }

        public async Task<int> UpdateStudent(Student data)
        {
            string sql = $@"UPDATE {_tableName} SET Name=@Name,Age=@Age WHERE ID=@Id";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(data);

            var result = await Task.FromResult(_dapper.Update<int>(sql, dynamicParameters));
            return result;
        }

        public async Task<int> DeleteStudentById(int id)
        {
            string sql = $@"DELETE FROM {_tableName} WHERE ID=@id";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", id);

            var result = await Task.FromResult(_dapper.Delete<int>(sql, dynamicParameters));
            return result;
        }
    }
}

