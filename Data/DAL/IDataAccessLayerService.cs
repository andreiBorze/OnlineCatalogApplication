using Data.Models;

namespace Data.DAL
{
    public interface IDataAccessLayerService
    {
        void Seed();
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        Student CreateStudent(Student student);
        Student UpdateStudent(Student studentToUpdate);
        void DeleteStudent(int studentId);
        bool UpdateOrCreateStudentAddress(int studentId, Address newAddress);
        Grade AwardGrade(int value, int studentId, int courseId);
        Course AddCourse(string nameCourse);
        IEnumerable<Course> GetAllCourses();
    }
}