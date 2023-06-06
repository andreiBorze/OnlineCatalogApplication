using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        #region AddCourse
        public Course AddCourse(string nameCourse)
        {
            var course = new Course { Name = nameCourse };

            ctx.Courses.Add(course);
            ctx.SaveChanges();  
            return course;
        }
        #endregion

        #region GetAllCourses
        public IEnumerable<Course> GetAllCourses() => ctx.Courses;
        #endregion

    }
}
