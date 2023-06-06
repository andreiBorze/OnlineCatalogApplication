using Data.Models;
using OnlineCatalogApplication.Dtos;

namespace OnlineCatalogApplication.Utils
{
    public static class CourseUtils
    {
        public static CourseToCreateDto ToDto(this Course course)
        {
            if (course == null)
            {
                return null;
            }
            return new CourseToCreateDto
            {
                Name = course.Name,
            };
        }

        public static Course ToEntity(this CourseToCreateDto course)
        {
            if (course == null)
            {
                return null;
            }
            return new Course
            {
                Name = course.Name,
            };
        }
    }
}
