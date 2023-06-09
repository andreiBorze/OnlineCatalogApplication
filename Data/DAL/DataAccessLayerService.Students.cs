using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL
{
    internal partial class DataAccessLayerService : IDataAccessLayerService
    {
        private readonly StudentsDbContext ctx;
        public DataAccessLayerService(StudentsDbContext ctx)
        {
            this.ctx = ctx;
        }
        
        public IEnumerable<Student> GetAllStudents() => ctx.Students.ToList();
        

        public Student GetStudentById(int id)
        {
            var student = ctx.Students.FirstOrDefault(x => x.Id == id);
            if(student == null)
            {
                throw new InvalidIdException($"Invalid student id {id}");
            }
            return student;
        }
        

        public Student CreateStudent(Student student)
        {
            if (ctx.Students.Any(x => x.Id == student.Id))
            {
                throw new DuplicatedIdException($"Duplicated student id.");
            }

            ctx.Students.Add(student);
            ctx.SaveChanges();

            return student;
        }
        

        public Student UpdateStudent(Student studentToUpdate)
        {
            var student = ctx.Students.FirstOrDefault(x => x.Id == studentToUpdate.Id);

            if (student == null)
            {
                throw new InvalidIdException($"Invalid student id {studentToUpdate.Id}");
            }

            student.Name = studentToUpdate.Name;
            student.Age = studentToUpdate.Age;

            ctx.SaveChanges();

            return student;
        }
        

        public void DeleteStudent(int studentId)
        {
            var student = ctx.Students.FirstOrDefault(x => x.Id == studentId);

            if (student == null)
            {
                throw new InvalidIdException($"Invalid student id {studentId}");
            }

            ctx.Students.Remove(student);
            ctx.SaveChanges();
        }
        

        public bool UpdateOrCreateStudentAddress(int studentId, Address newAddress)
        {
            var student = ctx.Students.Include(s => s.Address).FirstOrDefault(s => s.Id == studentId);
            if(student == null)
            {
                throw new InvalidIdException($"Invalid student id {studentId}");
            }

            var created = false;
            if(student.Address == null)
            {
                student.Address = newAddress;
                created = true; 
            }

            student.Address.Number = newAddress.Number;
            student.Address.Street = newAddress.Street;
            student.Address.City = newAddress.City;

            ctx.SaveChanges();
            return created;    
        }
        
    }
}
