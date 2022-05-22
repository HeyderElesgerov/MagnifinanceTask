using AutoMapper;
using MagnifinanceTask.Application.Dtos.Teacher;
using MagnifinanceTask.Application.Services.Abstract;
using MagnifinanceTask.Domain.Data;
using MagnifinanceTask.Domain.Models;
using Serilog;

namespace MagnifinanceTask.Application.Services.Concrete;

public class TeacherService : ITeacherService
{
    private readonly IGenericRepository<Teacher, int> _teacherRepository;
    private readonly IMapper _mapper;
    private ILogger _logger;

    public TeacherService(IGenericRepository<Teacher, int> teacherRepository, IMapper mapper, ILogger logger)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public void AddNewTeacher(AddTeacherDto dto)
    {
        try
        {
            _teacherRepository.Add(_mapper.Map<Teacher>(dto));
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("Can't add new teacher");
        }
    }

    public void UpdateTeacher(UpdateTeacherDto dto)
    {
        var teacher = _teacherRepository.GetById(dto.Id);
        if (teacher == null)
            throw new Exception("Teacher not found");
        try
        {
            teacher.Name = dto.Name;
            teacher.Birthday = dto.Birthday;
            teacher.Salary = dto.Salary;
            _teacherRepository.Update(teacher);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("Can't update the teacher");
        }
    }

    public void DeleteTeacher(int id)
    {
        var teacher = _teacherRepository.GetById(id);
        if (teacher == null)
            throw new Exception("Teacher not found");
        try
        {
            _teacherRepository.Delete(teacher);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message +" " + ex.StackTrace);
            throw new Exception("Can't delete the teacher");
        }
    }

    public IEnumerable<Teacher> GetAllTeachers()
    {
        return _teacherRepository.GetAll();
    }

    public Teacher GetById(int id)
    {
        return _teacherRepository.GetById(id);
    }
}