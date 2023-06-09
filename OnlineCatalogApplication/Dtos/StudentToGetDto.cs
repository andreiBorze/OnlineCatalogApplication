using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineCatalogApplication.Dtos
{
    public class StudentToGetDto
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The name can't be empty!")]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }

        //public Address Address { get; set; }

    }
}
