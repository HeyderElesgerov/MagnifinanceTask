using System.ComponentModel.Design;
using AutoMapper;
using MagnifinanceTask.Application.Dtos.Grade;
using MagnifinanceTask.Application.Services.Abstract;
using MagnifinanceTask.Domain.Data;
using MagnifinanceTask.Domain.Models;
using Serilog;

namespace MagnifinanceTask.Application.Services.Concrete;

public class GradeService : IGradeService
{
    private readonly IGenericRepository<Grade, int> _gradeRepository;
    private IGenericRepository<Student, int> _studentRepository;
    private ISubjectRepository _subjectRepository;
    private readonly IMapper _mapper;
    private ILogger _logger;

    public GradeService(IGenericRepository<Grade, int> gradeRepository, IMapper mapper, ILogger logger, IGenericRepository<Student, int> studentRepository, ISubjectRepository subjectRepository)
    {
        _gradeRepository = gradeRepository;
        _mapper = mapper;
        _logger = logger;
        _studentRepository = studentRepository;
        _subjectRepository = subjectRepository;
    }

    public void AddNewGrade(AddGradeDto dto)
    {
        if (!_studentRepository.Exists(dto.StudentId))
            throw new Exception("Invalid student");

        if (!_subjectRepository.Exists(dto.SubjectId))
            throw new Exception("Invalid subject");

        if (_gradeRepository.GetWhere(g => g.StudentId == dto.StudentId && g.SubjectId == dto.SubjectId).Any())
            throw new Exception("Student has already got a grade on this subject");

        try
        {
            _gradeRepository.Add(_mapper.Map<Grade>(dto));
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("Can't add new Grade");
        }
    }

    public void UpdateGrade(UpdateGradeDto dto)
    {
        var grade = _gradeRepository.GetById(dto.Id);
        if (grade == null)
            throw new Exception("Grade not found");
        try
        {
            grade.Value = dto.Value;
            _gradeRepository.Update(grade);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("Can't update the Grade");
        }
    }

    public void DeleteGrade(int id)
    {
        var grade = _gradeRepository.GetById(id);
        if (grade == null)
            throw new Exception("Grade not found");
        try
        {
            _gradeRepository.Delete(grade);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message +" " + ex.StackTrace);
            throw new Exception("Can't delete the Grade");
        }
    }

    public IEnumerable<Grade> GetAllGrades()
    {
        return _gradeRepository.GetAll();
    }

    public Grade GetById(int id)
    {
        return _gradeRepository.GetById(id);
    }

}