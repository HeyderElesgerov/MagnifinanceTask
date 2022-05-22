using AutoMapper;
using MagnifinanceTask.Application.Dtos.Subject;
using MagnifinanceTask.Application.Services.Abstract;
using MagnifinanceTask.Domain.Data;
using MagnifinanceTask.Domain.Models;
using Serilog;

namespace MagnifinanceTask.Application.Services.Concrete;

public class SubjectService : ISubjectService
{
    private ISubjectRepository _subjectRepository;
    private ICourseService _courseService;
    private ILogger _logger;
    private IMapper _mapper;

    public SubjectService(ISubjectRepository subjectRepository, ILogger logger, IMapper mapper, ICourseService courseService)
    {
        _subjectRepository = subjectRepository;
        _logger = logger;
        _mapper = mapper;
        _courseService = courseService;
    }

    public void AddNewSubject(AddSubjectDto dto)
    {
        if (_courseService.GetById(dto.CourseId) == null)
            throw new Exception("Course not found");
        try
        {
            _subjectRepository.Add(_mapper.Map<Subject>(dto));
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("Can't add new subject");
        }
    }

    public void UpdateSubject(UpdateSubjectDto dto)
    {
        var subject = _subjectRepository.GetById(dto.Id);
        if (subject == null)
            throw new Exception("Subject not found");

        if (_courseService.GetById(dto.CourseId) == null)
            throw new Exception("Course not found");
        
        try
        {
            subject.CourseId = dto.CourseId;
            subject.Name = dto.Name;
            _subjectRepository.Update(subject);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("Can't update the subject");
        }
    }

    public void DeleteSubject(int id)
    {
        var subject = _subjectRepository.GetById(id);
        if (subject == null)
            throw new Exception("Subject not found");
        try
        {
            _subjectRepository.Delete(subject);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message +" " + ex.StackTrace);
            throw new Exception("Can't delete the subject");
        }
    }

    public IEnumerable<Subject> GetAllSubjects()
    {
        return _subjectRepository.GetAll();
    }

    public Subject GetById(int id)
    {
        return _subjectRepository.GetById(id);
    }

    public IEnumerable<SubjectInfoDto> ListSubjects()
    {
        var subjects = _subjectRepository.GetAllIncludingForList();
        return _mapper.Map<IEnumerable<SubjectInfoDto>>(subjects);
    }
}