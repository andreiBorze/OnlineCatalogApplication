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
                 CourseId = (int)grade.CourseId,
                 StudentId = grade.StudentId,
                 Value = grade.Value,
            };
        }


        public static GradeAverageDto ToDto(this KeyValuePair<int, double> pair)
        {

            var dto = new GradeAverageDto
            {
                CourseId = pair.Key,
                AverageGrade = pair.Value
            };

            return dto;
        }

    }
}
