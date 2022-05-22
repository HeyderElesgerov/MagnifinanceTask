using MagnifinanceTask.Application.Dtos.Student;
using MagnifinanceTask.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MagnifinanceTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_studentService.GetAllStudents());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _studentService.GetById(id);
        if (student == null)
            return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddNew(AddStudentDto dto)
    {
        try
        {
            _studentService.AddNewStudent(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Update(UpdateStudentDto dto)
    {
        try
        {
            _studentService.UpdateStudent(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _studentService.DeleteStudent(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}