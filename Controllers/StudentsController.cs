using L3C1WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace L3C1WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StudentsController(IConfiguration config) : ControllerBase
	{
		

		private static List<Student> _students = [];


		//POST: students/add
		[HttpPost("add")]
		public IActionResult Add(Student student)
		{
			_students.Add(student);
			return Created($"students/getbyid/{student.Id}","successfully added!");
		}

		[HttpGet("getall")]
		public List<Student> GetStudentsName()
		{
			return _students;
		}


		//URL: GET: students/getbyid/4

		[HttpGet("getbyid/{id:int}")]
		public IActionResult GetById(int id)
		{
			Student? student =  _students.FirstOrDefault(s => s.Id == id);
			if (student == null)
			{
				return NotFound($"Student having id {id} is not found ");
			}

			return Ok(student);

		}

		[HttpPut("update/{id:int}")]
		public IActionResult Update(int id, Student updatedStudent)
		{
			Student? student = _students.FirstOrDefault(s => s.Id == id);
			if (student == null)
			{
				return NotFound($"Student having id {id} is not found ");
			}

			student.Name = updatedStudent.Name;
			student.Email = updatedStudent.Email;
			student.Age = updatedStudent.Age;

			return Ok("Successfully updated");

		}

		[HttpDelete("delete/{id:int}")]
		public IActionResult Delete(int id)
		{
			Student? student = _students.FirstOrDefault(s => s.Id == id);
			if (student == null)
			{
				return NotFound($"Student having id {id} is not found ");
			}

			_students.Remove(student);
			return Ok("Successfully Deleted");
		}

		[HttpGet("settings")]
		public IActionResult GetStudentFromSetting(IOptions<Student> options)
		{
			//int id = Convert.ToInt32(config["Student:Id"]);
			//string name = config["Student:Name"]!;
			//string email = config["Student:Email"]!;
			//int age = Convert.ToInt32(config["Student:Age"]);


			//return Ok(new Student { Id = id,Name = name, Email = email, Age = age });

			Student student = options.Value;
			return Ok(student);
		}

	}
}
