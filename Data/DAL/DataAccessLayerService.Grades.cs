using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL
{
    internal partial class DataAccessLayerService : IDataAccessLayerService
    {
 
        public Grade AwardGrade(int value, int studentId, int courseId)
        {
            if(!ctx.Students.Any(x => x.Id == studentId))
            {
                throw new InvalidIdException($"Invalid student ID {studentId}");
            }
            if(!ctx.Courses.Any(x => x.Id == courseId))
            {
                throw new InvalidIdException($"Invalid course ID {courseId}");
            }

            var course = ctx.Courses.FirstOrDefault(x => x.Id == courseId);
            var student = ctx.Students.FirstOrDefault(x => x.Id == studentId);

            var grade = new Grade { Value = value, StudentId = studentId, CourseId = courseId, awardDate = DateTime.Now, Course = course , Student = student };
            ctx.Grades.Add(grade);
            ctx.SaveChanges();

            return grade;
        }
       

       /* public Grade GetAllGradeForStudent(int studentId)
        {
            if (!ctx.Students.Any(x => x.Id == studentId))
            {
                throw new InvalidIdException($"Invalid student ID {studentId}");
            }

            var course = ctx.Courses.FirstOrDefault(x => x.Id == courseId);
            var student = ctx.Students.FirstOrDefault(x => x.Id == studentId);

            var grade = new Grade { Value = value, StudentId = studentId, CourseId = courseId, awardDate = DateTime.Now, Course = course, Student = student };
            ctx.Grades.Add(grade);
            ctx.SaveChanges();

            return grade;
        }*/
       
    }
}
