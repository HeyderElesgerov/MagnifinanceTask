using AutoMapper;
using MagnifinanceTask.Application.Dtos.Student;
using MagnifinanceTask.Application.Services.Abstract;
using MagnifinanceTask.Domain.Data;
using MagnifinanceTask.Domain.Models;
using Serilog;

namespace MagnifinanceTask.Application.Services.Concrete;

public class StudentService : IStudentService
{
    private readonly IGenericRepository<Student, int> _studentRepository;
    private readonly IGenericRepository<Course, int> _courseRepository;
    private readonly IMapper _mapper;
    private ILogger _logger;

    public StudentService(IGenericRepository<Student, int> studentRepository, IMapper mapper, ILogger logger, IGenericRepository<Course, int> courseRepository)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _logger = logger;
        _courseRepository = courseRepository;
    }

    public void AddNewStudent(AddStudentDto dto)
    {
        try
        {
            _studentRepository.Add(_mapper.Map<Student>(dto));
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("Can't add new Student");
        }
    }

    public void UpdateStudent(UpdateStudentDto dto)
    {
        var student = _studentRepository.GetById(dto.Id);
        if (student == null)
            throw new Exception("Student not found");
        try
        {
            student.Name = dto.Name;
            student.Birthday = dto.Birthday;
            _studentRepository.Update(student);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("Can't update the Student");
        }
    }

    public void DeleteStudent(int id)
    {
        var student = _studentRepository.GetById(id);
        if (student == null)
            throw new Exception("Student not found");
        try
        {
            _studentRepository.Delete(student);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message +" " + ex.StackTrace);
            throw new Exception("Can't delete the Student");
        }
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _studentRepository.GetAll();
    }

    public Student GetById(int id)
    {
        return _studentRepository.GetById(id);
    }

    public IEnumerable<StudentInfoDto> List()
    {
        var students = _studentRepository.GetAllIncluding("Grades.Subject");
        return _mapper.Map<IEnumerable<StudentInfoDto>>(students);
    }

    public void Enroll(EnrollCourseDto dto)
    {
        var student = _studentRepository.GetByIdIncluding(dto.StudentId, s => s.Courses);
        if (student == null)
            throw new Exception("Student not found");

        List<Course> courses = new List<Course>();
        
        //add existing courses
        foreach (int courseId in dto.CourseIds)
        {
            var enrolledCourse = student.Courses.FirstOrDefault(c => c.Id == courseId);
            if (enrolledCourse != null)
                courses.Add(enrolledCourse);
            else
                courses.Add(_courseRepository.GetById(courseId));
        }
        
        student.Courses = courses;
        try
        {
            _studentRepository.Update(student);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message + " " + ex.StackTrace);
            throw new Exception("Something went wrong");
        }
    }
}