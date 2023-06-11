using Data.DAL;
using Data.Exceptions;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCatalogApplication.Dtos;
using OnlineCatalogApplication.Utils;

namespace OnlineCatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;

        public GradesController(IDataAccessLayerService dataAccessLayer)
        {
            this.dal = dataAccessLayer;
        }

        /// <summary>
        /// Award a grade to a student for a course.
        /// </summary>
        /// <param name="grade">The grade to award.</param>
        /// <returns>The awarded grade.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GradeToCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        public GradeToCreateDto AwardGrade([FromBody] GradeToCreateDto grade) => dal.AwardGrade(grade.Value, grade.StudentId, grade.CourseId).ToDto();

        /// <summary>
        /// Get all grades for a student.
        /// </summary>
        /// <param name="studentId">The student ID.</param>
        /// <returns>The list of grades for the student.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GradeToCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IEnumerable<GradeToCreateDto> GetAllGradeForStudent(int studentId) => dal.GetAllGradeForStudent(studentId).Select(s => s.ToDto()).ToList();

        /// <summary>
        /// Get all grades for a student for a specific course.
        /// </summary>
        /// <param name="studentId">The student ID.</param>
        /// <param name="courseId">The course ID.</param>
        /// <returns>The list of grades for the student and course.</returns>
        [HttpGet("api/GetAllGradeForStudentForCourse/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GradeToCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IEnumerable<GradeToCreateDto> GetAllGradeForStudentForCourse(int studentId, int courseId) => dal.GetAllGradeForStudentForCourse(studentId, courseId).Select(s => s.ToDto()).ToList();

        /// <summary>
        /// Get the average grade for each course for a student.
        /// </summary>
        /// <param name="studentId">The student ID.</param>
        /// <returns>The dictionary containing course IDs and their average grades.</returns>
        [HttpGet("api/GetAllCourseAverageForStudent/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GradeAverageDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IEnumerable<GradeAverageDto> GetAllCourseAverageForStudent(int studentId) => dal.GetAllCourseAverageForStudent(studentId).Select(s => s.ToDto()).ToList();
    }

}
