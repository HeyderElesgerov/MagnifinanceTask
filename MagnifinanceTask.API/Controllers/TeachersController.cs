using MagnifinanceTask.Application.Dtos.Teacher;
using MagnifinanceTask.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MagnifinanceTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeachersController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_teacherService.GetAllTeachers());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var teacher = _teacherService.GetById(id);
        if (teacher == null)
            return NotFound();
        return Ok(teacher);
    }

    [HttpPost]
    public IActionResult AddNew(AddTeacherDto dto)
    {
        try
        {
            _teacherService.AddNewTeacher(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Update(UpdateTeacherDto dto)
    {
        try
        {
            _teacherService.UpdateTeacher(dto);
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
            _teacherService.DeleteTeacher(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}