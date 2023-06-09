using Data.Models;
using OnlineCatalogApplication.Dtos;

namespace OnlineCatalogApplication.Utils
{
    public static class GradeUtils
    {
        public static GradeToCreateDto ToDto(this Grade grade)
        {
            if (grade == null)
            {
                return null;
            }
            return new GradeToCreateDto
            {
                 CourseId = grade.Id,
                 StudentId = grade.StudentId,
                 Value = grade.Value,
            };
        }
    }
}
