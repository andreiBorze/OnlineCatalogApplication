using Data.DAL;
using Data.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCatalogApplication.Dtos;
using OnlineCatalogApplication.Utils;

namespace OnlineCatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;

        public CoursesController(IDataAccessLayerService dataAccessLayer)
        {
            this.dal = dataAccessLayer;
        }

        /// <summary>
        /// Add a new course.
        /// </summary>
        /// <param name="courseToCreate">The course to create.</param>
        /// <returns>The new course.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        public CourseToCreateDto AddCourse([FromBody] CourseToCreateDto courseToCreate) =>
            dal.AddCourse(courseToCreate.Name).ToDto();

        /// <summary>
        /// Get all courses.
        /// </summary>
        /// <returns>The list of all courses.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IEnumerable<CourseToCreateDto> GetAllCourses() =>
            dal.GetAllCourses().Select(s => s.ToDto()).ToList();
    }

}
