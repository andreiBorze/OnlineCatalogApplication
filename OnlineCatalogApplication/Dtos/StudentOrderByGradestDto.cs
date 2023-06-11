using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Dtos
{
    /// <summary>
    /// Data transfer object for representing a student's average grades.
    /// </summary>
    public class StudentOrderByGradesDto
    {
        /// <summary>
        /// Gets or sets the student ID.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the average grades of the student (1 - 10).
        /// </summary>
        [Range(1, 10)]
        public double AverageGrades { get; set; }
    }

}
