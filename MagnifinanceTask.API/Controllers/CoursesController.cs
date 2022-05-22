using AutoMapper;
using MagnifinanceTask.Application.Dtos.Course;
using MagnifinanceTask.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MagnifinanceTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_courseService.GetAllCourses());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var course = _courseService.GetById(id);
        if (course == null)
            return NotFound();
        return Ok(course);
    }

    [HttpGet("list")]
    public IActionResult ListCourses()
    {
        return Ok(_courseService.ListCourses());
    }

    [HttpPost]
    public IActionResult Add(AddCourseDto dto)
    {
        try
        {
            _courseService.AddNewCourse(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Update(UpdateCourseDto dto)
    {
        try
        {
            _courseService.UpdateCourse(dto);
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
            _courseService.DeleteCourse(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}