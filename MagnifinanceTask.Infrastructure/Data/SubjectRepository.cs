using MagnifinanceTask.Domain.Data;
using MagnifinanceTask.Domain.Models;
using MagnifinanceTask.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace MagnifinanceTask.Infrastructure.Data;

public class SubjectRepository : GenericRepository<Subject, int>, ISubjectRepository
{
    public SubjectRepository(TaskDbContext context) : base(context)
    {
    }

    public IEnumerable<Subject> GetAllIncludingForList()
    {
        return _context.Subjects
            .Include(s => s.Course)
                .ThenInclude(c => c.Teacher)
            .Include(s => s.Course)
                .ThenInclude(c => c.Students)
                    .ThenInclude(s => s.Grades);
    }
}