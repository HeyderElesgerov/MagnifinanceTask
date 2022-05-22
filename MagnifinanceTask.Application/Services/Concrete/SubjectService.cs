using AutoMapper;
using MagnifinanceTask.Application.Dtos.Subject;
using MagnifinanceTask.Application.Services.Abstract;
using MagnifinanceTask.Domain.Data;
using MagnifinanceTask.Domain.Models;
using Serilog;

namespace MagnifinanceTask.Application.Services.Concrete;

public class SubjectService : ISubjectService
{
    private IGenericRepository<Subject, int> _subjectRepository;
    private ILogger _logger;
    private IMapper _mapper;

    public SubjectService(IGenericRepository<Subject, int> subjectRepository, ILogger logger, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public void AddNewSubject(AddSubjectDto dto)
    {
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
        if (!_subjectRepository.Exists(dto.Id))
            throw new Exception("Subject not found");

        try
        {
            _subjectRepository.Update(_mapper.Map<Subject>(dto));
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
}