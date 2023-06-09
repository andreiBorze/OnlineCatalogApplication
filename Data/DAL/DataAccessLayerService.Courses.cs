using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL
{
    internal partial class DataAccessLayerService : IDataAccessLayerService
    {
        public Course AddCourse(string nameCourse)
        {
            var course = new Course { Name = nameCourse };

            ctx.Courses.Add(course);
            ctx.SaveChanges();  
            return course;
        }

        public IEnumerable<Course> GetAllCourses() => ctx.Courses;

    }
}
