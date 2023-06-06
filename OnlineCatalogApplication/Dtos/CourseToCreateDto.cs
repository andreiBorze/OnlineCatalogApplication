using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Dtos
{
    public class CourseToCreateDto
    {
        /// <summary>
        ///  Name of the course
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Name can't be empty!")]
        public string Name { get; set; }

    }
}
