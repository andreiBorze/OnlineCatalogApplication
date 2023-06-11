using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Dtos
{
    /// <summary>
    /// Data transfer object for creating a new course.
    /// </summary>
    public class CourseToCreateDto
    {
        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Name can't be empty!")]
        public string Name { get; set; }
    }

}
