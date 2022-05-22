using MagnifinanceTask.Application.Dtos.Grade;
using MagnifinanceTask.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MagnifinanceTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradesController : ControllerBase
{
    private readonly IGradeService _gradeService;

    public GradesController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_gradeService.GetAllGrades());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var grade = _gradeService.GetById(id);
        if (grade == null)
            return NotFound();
        return Ok(grade);
    }

    [HttpPost]
    public IActionResult AddNew(AddGradeDto dto)
    {
        try
        {
            _gradeService.AddNewGrade(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Update(UpdateGradeDto dto)
    {
        try
        {
            _gradeService.UpdateGrade(dto);
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
            _gradeService.DeleteGrade(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}