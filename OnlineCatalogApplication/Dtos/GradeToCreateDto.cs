using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Dtos
{
    /// <summary>
    /// Data transfer object for creating a new grade.
    /// </summary>
    public class GradeToCreateDto
    {
        /// <summary>
        /// Gets or sets the value of the grade (1 - 10).
        /// </summary>
        [Range(1, 10)]
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the student ID.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the course ID.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int CourseId { get; set; }
    }

}
