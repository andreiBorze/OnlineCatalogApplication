using Data.Models;

namespace Data.DAL
{
    public interface IDataAccessLayerService
    {
        #region Initialization - DataAccessLayerService.Seed
        void Seed();
        #endregion

        #region DataAccessLayerService.Students
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        Student CreateStudent(Student student);
        Student UpdateStudent(Student studentToUpdate);
        void DeleteStudent(int studentId);
        bool UpdateOrCreateStudentAddress(int studentId, Address newAddress);
        #endregion

        #region DataAccessLayerService.Grades

        Grade AwardGrade(int value, int studentId, int courseId);

        #endregion

        #region DataAccessLayerService.Courses
        Course AddCourse(string nameCourse);
        IEnumerable<Course> GetAllCourses();


        #endregion
    }
}