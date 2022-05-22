using MagnifinanceTask.Application.Dtos.Subject;
using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Application.Services.Abstract;

public interface ISubjectService
{
    void AddNewSubject(AddSubjectDto dto);
    
    void UpdateSubject(UpdateSubjectDto dto);

    void DeleteSubject(int id);

    IEnumerable<Subject> GetAllSubjects();

    Subject GetById(int id);
    IEnumerable<SubjectInfoDto> ListSubjects();
}