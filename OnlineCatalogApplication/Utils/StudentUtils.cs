using Data.Models;
using OnlineCatalogApplication.Dtos;

namespace OnlineCatalogApplication.Utils
{
    public static class StudentUtils
    {
        public static StudentToGetDto ToDto(this Student student)
        {
            if(student==null)
            {
                return null;
            }
            return new StudentToGetDto { 
                Id = student.Id, 
                Name = student.Name, 
                Age = student.Age 
            
            };
        }


    public static Student ToEntity(this StudentToCreateDto student)
    {
        if (student == null)
        {
            return null;
        }
        return new Student { 
            Name = student.Name, 
            Age = student.Age 
        };
    }

        public static Student ToEntity(this StudentToUpdateDto student)
        {
            if (student == null)
            {
                return null;
            }
            return new Student { 
                Id = student.Id, 
                Name = student.Name, 
                Age = student.Age 
            };
        }

        public static Address ToEntity(this AddressToUpdateDto addressToUpdate)
        {
            if(addressToUpdate == null)
            {
                return null;
            }

            return new Address
            {
                Number = addressToUpdate.Number,
                City = addressToUpdate.City,
                Street = addressToUpdate.Street
            };
        }
    }
}
