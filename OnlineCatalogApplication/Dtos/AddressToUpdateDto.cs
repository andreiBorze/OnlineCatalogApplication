using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Dtos
{
    /// <summary>
    /// Address model used for updating an existing address.
    /// </summary>
    public class AddressToUpdateDto
    {
        /// <summary>
        /// Gets or sets the street name.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The street can't be empty!")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the city name.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The city can't be empty!")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the street number.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Number { get; set; }
    }

}
