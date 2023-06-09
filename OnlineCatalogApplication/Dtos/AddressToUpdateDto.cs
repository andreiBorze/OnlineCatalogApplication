using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Dtos
{
    /// <summary>
    /// Address Model that will be used for update
    /// </summary>
    public class AddressToUpdateDto
    {
        /// <summary>
        /// Street Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The street can't be empty!")]
        public string Street { get; set; }

        /// <summary>
        /// City Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The city can't be empty!")]
        public string City { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Number { get; set; }

    }
}
