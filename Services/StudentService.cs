using System;
namespace dotnet_project_template.Services
{
	public class StudentService
	{
		public StudentService()
		{
		}

		public string DataAffected(int input)
		{
			return input != 0 ? "It works!" : "failure";
		}
	}
}

