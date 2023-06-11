using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public Student GetStudentById(int studentId)
        {
            if (!ctx.Students.Any(x => x.Id == studentId))
            {
                throw new InvalidIdException($"Invalid student id {studentId}");
            }
            return ctx.Students.FirstOrDefault(x => x.Id == studentId);
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
            if (!ctx.Students.Any(x => x.Id == studentToUpdate.Id))
                {
                throw new InvalidIdException($"Invalid student id {studentToUpdate.Id}");
            }

            var student = ctx.Students.FirstOrDefault(x => x.Id == studentToUpdate.Id);
            student.Name = studentToUpdate.Name;
            student.Age = studentToUpdate.Age;
            ctx.SaveChanges();

            return student;
        }
        public void DeleteStudent(int studentId)
        {
            if (!ctx.Students.Any(x => x.Id == studentId))
            {
                throw new InvalidIdException($"Invalid student id {studentId}");
            }
            var student = ctx.Students.Include(x => x.Address).FirstOrDefault(x => x.Id == studentId);
            ctx.Students.Remove(student); // Remove the student
            ctx.SaveChanges();
        }
        public bool UpdateOrCreateStudentAddress(int studentId, Address newAddress)
        {
            if (!ctx.Students.Any(x => x.Id == studentId))
            {
                throw new InvalidIdException($"Invalid student id {studentId}");
            }

            var student = ctx.Students.Include(s => s.Address).FirstOrDefault(s => s.Id == studentId);
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
        public IDictionary<int, double> GetAllStudentsOrderByGrades()
        {
            var listStudents = new Dictionary<int, double>();

            var groupedGrades = ctx.Grades
                .GroupBy(x => x.StudentId);

            foreach (var group in groupedGrades)
            {
                var studentId = group.Key;
                var averageGrade = group.Average(x => x.Value);
                listStudents.Add(studentId, averageGrade);
            }

            return listStudents.OrderBy(s => s.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public Student GetAddressForStudent(int studentId)
        {
            if (!ctx.Students.Any(x => x.Id == studentId))
            {
                throw new InvalidIdException($"Invalid student id {studentId}");
            }

            var student = ctx.Students.Include(s => s.Address).FirstOrDefault(s => s.Id == studentId);

            if (student.Address == null)
            {
                throw new InvalidIdException($"Invalid Address for student with the id {studentId}");
            }

            return student;
        }
    }
}
