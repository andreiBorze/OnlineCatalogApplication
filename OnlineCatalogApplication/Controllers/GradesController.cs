using Data.DAL;
using Data.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCatalogApplication.Dtos;

namespace OnlineCatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        #region Initialization
        private readonly IDataAccessLayerService dal;
        public GradesController(IDataAccessLayerService dataAccessLayer)
        {
            this.dal = dataAccessLayer;
        }
        #endregion

        #region AwardGrade
        /// <summary>
        /// Award Grade 
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>The status</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GradeToCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]

        public IActionResult AwardGrade([FromBody] GradeToCreateDto grade)
        {
            try
            {
                var addedGrade = dal.AwardGrade(grade.Value, grade.StudentId, grade.CourseId);
                return Created("Success", null);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
