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
        #region Initialization
        private readonly IDataAccessLayerService dal;
        public CoursesController(IDataAccessLayerService dataAccessLayer)
        {
            this.dal = dataAccessLayer;
        }
        #endregion

        #region AddCourse

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        public IActionResult AddCourse([FromBody] CourseToCreateDto courseToCreate)
        {
            try
            {
                var addedCourse = dal.AddCourse(courseToCreate.Name);
                return Created("Success", addedCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region GetAllCourses
        /// <summary>
        /// GetAllCourses
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetAllCourses()
        {
            try
            {
                IEnumerable<CourseToCreateDto> allCourse = dal.GetAllCourses().Select(s => s.ToDto()).ToList();
                return Ok(allCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }
        #endregion
    }
}
