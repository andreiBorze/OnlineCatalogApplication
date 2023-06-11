namespace OnlineCatalogApplication.Dtos
{
    /// <summary>
    /// Data transfer object for representing the average grade for a course.
    /// </summary>
    public class GradeAverageDto
    {
        /// <summary>
        /// Gets or sets the course ID.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the average grade.
        /// </summary>
        public double AverageGrade { get; set; }
    }

}

