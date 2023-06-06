using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Dtos
{
    public class GradeToCreateDto
    {
        /// <summary>
        /// Add Value (1 - 10)
        /// </summary>
        [Range(1,10)]
        public int Value { get; set; }

        /// <summary>
        /// StudentId
        /// </summary>
        [Range(0,int.MaxValue)]
        public int StudentId { get; set; }

        /// <summary>
        /// CourseId
        /// </summary>
        [Range(0, int.MaxValue)]
        public int CourseId { get; set; }
    }
}
