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
       
        public IEnumerable<Grade> GetAllGradeForStudent(int studentId)
        {
            if (!ctx.Students.Any(x => x.Id == studentId))
            {
                throw new InvalidIdException($"Invalid student ID {studentId}");
            }

            return ctx.Grades.Where(x => x.StudentId == studentId).ToList(); ;
        }

        public IEnumerable<Grade> GetAllGradeForStudentForCourse(int studentId, int courseId)
        {
            if (!ctx.Students.Any(x => x.Id == studentId))
            {
                throw new InvalidIdException($"Invalid student ID {studentId}");
            }
            if (!ctx.Courses.Any(x => x.Id == courseId))
            {
                throw new InvalidIdException($"Invalid course ID {courseId}");
            }
            return ctx.Grades.Where(x => x.StudentId == studentId && x.CourseId == courseId).ToList();
        }

        public IDictionary<int, double> GetAllCourseAverageForStudent(int studentId)
        {
            if (!ctx.Students.Any(x => x.Id == studentId))
            {
                throw new InvalidIdException($"Invalid student ID {studentId}");
            }

            var averageGrades = new Dictionary<int, double>();
            var groupedGrades = ctx.Grades.Where(x => x.StudentId == studentId).GroupBy(x => x.CourseId);

            foreach (var group in groupedGrades)
            {
                var courseId = group.Key;
                var averageGrade = group.Average(x => x.Value);
                averageGrades.Add((int)courseId, averageGrade);
            }

            return (IDictionary<int, double>)averageGrades;
        }
    }
}
