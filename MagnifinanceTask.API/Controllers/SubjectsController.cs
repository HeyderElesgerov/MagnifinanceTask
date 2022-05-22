using MagnifinanceTask.Application.Dtos.Subject;
using MagnifinanceTask.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MagnifinanceTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectsController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectsController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_subjectService.GetAllSubjects());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var subject = _subjectService.GetById(id);
        if (subject == null)
            return NotFound();
        return Ok(subject);
    }

    [HttpPost]
    public IActionResult AddNew(AddSubjectDto dto)
    {
        try
        {
            _subjectService.AddNewSubject(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Update(UpdateSubjectDto dto)
    {
        try
        {
            _subjectService.UpdateSubject(dto);
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
            _subjectService.DeleteSubject(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}