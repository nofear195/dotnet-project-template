using dotnet_project_template.Models;
using dotnet_project_template.Repositories;
using dotnet_project_template.Utils.DapperORM;
using Microsoft.AspNetCore.Mvc;
using dotnet_project_template.Services;

namespace dotnet_project_template.Controllers.api
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private StudentRepository _repository;
        private StudentService _service;

        public StudentController(IDapperORM dapper)
        {
            _repository = new StudentRepository(dapper);
            _service = new StudentService();
        }

        [HttpGet]
        public async Task<List<Student>> Get()
        {
            var result = await _repository.GetAllStudents();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            var result = await _repository.GetStudentById(id);
            return result;
        }

        [HttpPost]
        public async Task<string> Post(Student data)
        {
            var result = await _repository.CreateNewStudent(data);
            return _service.DataAffected(result);
        }

        [HttpPut]
        public async Task<string> Put(Student data)
        {
            var result = await _repository.UpdateStudent(data);
            return _service.DataAffected(result);
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            var result = await _repository.DeleteStudentById(id);
            return _service.DataAffected(result);
        }
    }
}

