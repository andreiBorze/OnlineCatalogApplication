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

        public static StudentOrderByGradesDto ToDtos(this KeyValuePair<int, double> pair)
        {

            var dto = new StudentOrderByGradesDto
            {
                StudentId = pair.Key,
                AverageGrades = pair.Value
            };

            return dto;
        }

        public static StudentWithAddressDto ToDtos(this Student student)
        {
            if (student == null)
            {
                return null;
            }

            return new StudentWithAddressDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                City = student.Address.City,
                Street = student.Address.Street,
                Number = student.Address.Number
            };
        }

    }
}
