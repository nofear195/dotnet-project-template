using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_project_template.Controllers.api
{
    [Route("api/[controller]")]
    public class WeatherForecastController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string connectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=;";
            NpgsqlConnection? connection = null;
            try
            {
                connection = new NpgsqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e);
            }

            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = connection;

                // Create the Student table
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Student (
                        Id SERIAL PRIMARY KEY,
                        Name VARCHAR(255),
                        Age INT
                    );";

                command.ExecuteNonQuery();
            }

            Console.WriteLine("Student table created successfully.");

            connection.Close();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

