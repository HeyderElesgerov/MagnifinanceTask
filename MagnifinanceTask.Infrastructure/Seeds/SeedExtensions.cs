using System.Runtime.InteropServices.ComTypes;
using MagnifinanceTask.Domain.Models;
using MagnifinanceTask.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MagnifinanceTask.Infrastructure.Seeds;

public static class SeedExtensions
{
    public static void MigrateDatabase(this ServiceProvider serviceProvider)
    {
        using var dbContext = serviceProvider.GetService<TaskDbContext>();
        dbContext.Database.Migrate();
    }

    public static void SeedData(this ServiceProvider serviceProvider)
    {
        using var dbContext = serviceProvider.GetService<TaskDbContext>();
        if (!dbContext.Teachers.Any())
        {
            var teacher1 = new Teacher() {Birthday = new DateTime(2002, 05, 23), Name = "Teacher 1", Salary = 3500};
            var teacher2 = new Teacher() {Birthday = new DateTime(2001, 05, 23), Name = "Teacher 2", Salary = 4500};
            var teacher3 = new Teacher() {Birthday = new DateTime(2000, 05, 23), Name = "Teacher 3", Salary = 5500};
            
            //if there is no teachers, there is no courses
            var course1 = new Course() {Name = "Course 1", Teacher = teacher1};
            course1.Subjects = new[] {
                new Subject(){Name = "Subject 1", Course = course1},
                new Subject(){Name = "Subject 2", Course = course1},
                new Subject(){Name = "Subject 3", Course = course1}
            };
            var course2 = new Course() {Name = "Course 2", Teacher = teacher2};
            course2.Subjects = new[] {
                new Subject(){Name = "Subject 1", Course = course2},
                new Subject(){Name = "Subject 2", Course = course2},
                new Subject(){Name = "Subject 3", Course = course2}
            };
            var course3 = new Course() {Name = "Course 3", Teacher = teacher3};
            course3.Subjects = new[] {
                new Subject(){Name = "Subject 1", Course = course3},
                new Subject(){Name = "Subject 2", Course = course3},
                new Subject(){Name = "Subject 3", Course = course3}
            };

            if (!dbContext.Students.Any())
            {
                var course1Subjects = course1.Subjects.ToArray();
                var course2Subjects = course2.Subjects.ToArray();
                var course3Subjects = course3.Subjects.ToArray();
                var student1 = new Student()
                {
                    Birthday = new DateTime(2010, 5, 12),
                    Name = "Student 1",
                    RegistrationNumber = 0001,
                    Courses = new List<Course>(){course1, course2}
                };
                
                student1.Grades = new List<Grade>()
                {
                    new Grade(){ Student = student1, Subject = course1Subjects[0], Value = 90},
                    new Grade(){ Student = student1, Subject = course1Subjects[1], Value = 100},
                    new Grade(){ Student = student1, Subject = course1Subjects[2], Value = 85},
                    new Grade(){ Student = student1, Subject = course2Subjects[0], Value = 90},
                };
                var student2 = new Student()
                {
                    Birthday = new DateTime(2011, 1, 20),
                    Name = "Student 2",
                    RegistrationNumber = 0002,
                    Courses = new List<Course>() { course3}
                };
                student2.Grades = new List<Grade>()
                {
                    new Grade(){ Student = student1, Subject = course3Subjects[0], Value = 50}
                };
                dbContext.Students.AddRange(student1, student2);
            }
            else
            {
                dbContext.Courses.AddRange(course1, course2, course3);
            }
            dbContext.SaveChanges();

        }
    }
}