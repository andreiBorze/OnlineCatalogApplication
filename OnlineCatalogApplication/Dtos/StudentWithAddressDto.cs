using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Dtos
{
    /// <summary>
    /// Data transfer object for representing a student with address information.
    /// </summary>
    public class StudentWithAddressDto
    {
        /// <summary>
        /// Gets or sets the ID of the student.
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Gets or sets the street name of the student's address.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The street can't be empty!")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the city name of the student's address.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The city can't be empty!")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the street number of the student's address.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Number { get; set; }
    }

}
