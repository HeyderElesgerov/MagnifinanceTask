using MagnifinanceTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MagnifinanceTask.Infrastructure.EF;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    
    public DbSet<Student> Students { get; set; }
    
    public DbSet<Teacher> Teachers { get; set; }
    
    public DbSet<Subject> Subjects { get; set; }
    
    public DbSet<Grade> Grades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //course
        var courseBuilder = modelBuilder.Entity<Course>();
        courseBuilder.Property(c => c.Name).IsRequired();
        courseBuilder
            .HasOne(c => c.Teacher)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        //student
        var studentBuilder = modelBuilder.Entity<Student>();
        studentBuilder.Property(s => s.Name).IsRequired();
        
        //teacher
        var teacherBuilder = modelBuilder.Entity<Teacher>();
        teacherBuilder.Property(t => t.Name).IsRequired();
        
        //subject
        var subjectBuilder = modelBuilder.Entity<Subject>();
        subjectBuilder.Property(p => p.Name).IsRequired();
        subjectBuilder
            .HasOne(p => p.Course)
            .WithMany(c => c.Subjects)
            .HasForeignKey(p => p.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        
        //grade
        var gradeBuilder = modelBuilder.Entity<Grade>();
        gradeBuilder
            .HasOne(p => p.Student)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        gradeBuilder
            .HasOne(g => g.Subject)
            .WithMany(s => s.Grades)
            .HasForeignKey(p => p.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.OnModelCreating(modelBuilder);
    }
}