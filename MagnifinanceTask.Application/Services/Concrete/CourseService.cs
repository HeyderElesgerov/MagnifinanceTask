using AutoMapper;
using MagnifinanceTask.Application.Dtos.Course;
using MagnifinanceTask.Application.Services.Abstract;
using MagnifinanceTask.Domain.Data;
using MagnifinanceTask.Domain.Models;
using Serilog;

namespace MagnifinanceTask.Application.Services.Concrete;

public class CourseService : ICourseService
{
    private IGenericRepository<Course, int> _courseRepo;
    private IMapper _mapper;
    private ILogger _logger;

    public CourseService(IGenericRepository<Course, int> courseRepo, IMapper mapper, ILogger logger)
    {
        _courseRepo = courseRepo;
        _mapper = mapper;
        _logger = logger;
    }
    
    public void AddNewCourse(AddCourseDto dto)
    {
        var course = _mapper.Map<Course>(dto);
        try
        {
            _courseRepo.Add(course);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("An error occured while creating course");
        }
    }

    public void UpdateCourse(UpdateCourseDto dto)
    {
        if (!_courseRepo.Exists(dto.Id))
            throw new Exception("Course not found");
        var course = _mapper.Map<Course>(dto);
        try
        {
            _courseRepo.Update(course);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("An error occured while updating course");
        }
    }

    public void DeleteCourse(int id)
    {
        var course = _courseRepo.GetById(id);
        if (course == null)
            throw new Exception("Course not found");
        _courseRepo.Delete(course);
    }

    public IEnumerable<CourseInfoDto> ListCourses()
    {
        var courses = _courseRepo.GetAllIncluding("Students.Grades.Subject");
        return _mapper.Map<IEnumerable<CourseInfoDto>>(courses);
    }

    public IEnumerable<Course> GetAllCourses()
    {
        return _courseRepo.GetAll();
    }

    public Course GetById(int id)
    {
        return _courseRepo.GetById(id);
    }
}