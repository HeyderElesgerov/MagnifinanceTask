using MagnifinanceTask.Domain.Models;

namespace MagnifinanceTask.Domain.Data;

public interface ISubjectRepository : IGenericRepository<Subject, int>
{
    IEnumerable<Subject> GetAllIncludingForList();
}