using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Dtos
{
        /// <summary>
        /// Data transfer object for creating a new student.
        /// </summary>
        public class StudentToCreateDto
        {
            /// <summary>
            /// Gets or sets the name of the student.
            /// </summary>
            [Required(AllowEmptyStrings = false, ErrorMessage = "The name can't be empty!")]
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the age of the student.
            /// </summary>
            [Range(1, 100)]
            public int Age { get; set; }
        }
}
