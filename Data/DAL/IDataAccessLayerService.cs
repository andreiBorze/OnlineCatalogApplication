using Data.Models;

namespace Data.DAL
{
    public interface IDataAccessLayerService
    {
        /// <summary>
        /// Seeds the database with initial data.
        /// </summary>
        void Seed();

        /// <summary>
        /// Retrieves all students.
        /// </summary>
        /// <returns>An enumerable collection of Student objects.</returns>
        IEnumerable<Student> GetAllStudents();

        /// <summary>
        /// Retrieves a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>The Student object.</returns>
        Student GetStudentById(int id);

        /// <summary>
        /// Creates a new student.
        /// </summary>
        /// <param name="student">The Student object to create.</param>
        /// <returns>The created Student object.</returns>
        Student CreateStudent(Student student);

        /// <summary>
        /// Updates a student.
        /// </summary>
        /// <param name="studentToUpdate">The updated Student object.</param>
        /// <returns>The updated Student object.</returns>
        Student UpdateStudent(Student studentToUpdate);

        /// <summary>
        /// Deletes a student by their ID.
        /// </summary>
        /// <param name="studentId">The ID of the student to delete.</param>
        void DeleteStudent(int studentId);

        /// <summary>
        /// Updates or creates a new address for a student.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="newAddress">The new address for the student.</param>
        /// <returns>True if the address was updated or created successfully, false otherwise.</returns>
        bool UpdateOrCreateStudentAddress(int studentId, Address newAddress);

        /// <summary>
        /// Retrieves the address for a student by their ID.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <returns>The Address object associated with the student.</returns>
        Student GetAddressForStudent(int studentId);

        /// <summary>
        /// Retrieves all students ordered by their grades in ascending order.
        /// </summary>
        /// <returns>A dictionary containing student IDs as keys and their corresponding average grades as values.</returns>
        IDictionary<int, double> GetAllStudentsOrderByGrades();

        /// <summary>
        /// Awards a grade to a student for a specific course.
        /// </summary>
        /// <param name="value">The value of the grade.</param>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>The awarded Grade object.</returns>
        Grade AwardGrade(int value, int studentId, int courseId);

        /// <summary>
        /// Retrieves all grades for a specific student.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <returns>An enumerable collection of Grade objects for the student.</returns>
        IEnumerable<Grade> GetAllGradeForStudent(int studentId);

        /// <summary>
        /// Retrieves all grades for a specific student in a specific course.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>An enumerable collection of Grade objects for the student and course.</returns>
        IEnumerable<Grade> GetAllGradeForStudentForCourse(int studentId, int courseId);

        /// <summary>
        /// Retrieves the average grades for all courses of a specific student.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <returns>A dictionary containing course IDs as keys and their corresponding average grades as values.</returns>
        IDictionary<int, double> GetAllCourseAverageForStudent(int studentId);

        /// <summary>
        /// Adds a new course.
        /// </summary>
        /// <param name="nameCourse">The name of the course.</param>
        /// <returns>The created Course object.</returns>
        Course AddCourse(string nameCourse);

        /// <summary>
        /// Retrieves all courses.
        /// </summary>
        /// <returns>An enumerable collection of Course objects.</returns>
        IEnumerable<Course> GetAllCourses();


    }
}